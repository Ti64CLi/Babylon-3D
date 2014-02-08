#include "particleSystem.h"
#include "defs.h"
#include "engine.h"

using namespace Babylon;

Babylon::ParticleSystem::ParticleSystem(string name, int capacity, Scene::Ptr scene)
{
	this->name = name;
	this->id = name;
	this->_capacity = capacity;

	this->_scene = scene;

	scene->particleSystems.push_back(shared_from_this());

	// Members
	this->renderingGroupId = 0;
	this->emitter = nullptr;
	this->emitRate = 10;
	this->manualEmitCount = -1;
	this->updateSpeed = 0.01;
	this->targetStopDuration = 0;
	this->disposeOnStop = false;

	this->minEmitPower = 1;
	this->maxEmitPower = 1;

	this->minLifeTime = 1;
	this->maxLifeTime = 1;

	this->minSize = 1;
	this->maxSize = 1;
	this->minAngularSpeed = 0;
	this->maxAngularSpeed = 0;

	this->particleTexture = nullptr;

	this->onDispose = nullptr;

	this->blendMode = BLENDMODE_ONEONE;

	// Vectors and colors
	this->gravity = Vector3::Zero();
	this->direction1 = make_shared<Vector3>(0, 1.0, 0);
	this->direction2 = make_shared<Vector3>(0, 1.0, 0);
	this->minEmitBox = make_shared<Vector3>(-0.5, -0.5, -0.5);
	this->maxEmitBox = make_shared<Vector3>(0.5, 0.5, 0.5);
	this->color1 = make_shared<Color4>(1.0, 1.0, 1.0, 1.0);
	this->color2 = make_shared<Color4>(1.0, 1.0, 1.0, 1.0);
	this->colorDead = make_shared<Color4>(0, 0, 0, 1.0);
	this->textureMask = make_shared<Color4>(1.0, 1.0, 1.0, 1.0);

	// Particles
	this->particles.clear();
	this->_stockParticles.clear();
	this->_newPartsExcess = 0;

	// VBO
	this->_vertexDeclarations.push_back(VertexBufferKind_UVKind);
	this->_vertexDeclarations.push_back(VertexBufferKind_UV2Kind);
	this->_vertexDeclarations.push_back(VertexBufferKind_UV2Kind);
	this->_vertexStrideSize = 11 * 4; // 11 floats per particle (x, y, z, r, g, b, a, angle, size, offsetX, offsetY)
	this->_vertexBuffer = scene->getEngine()->createDynamicVertexBuffer(capacity * this->_vertexStrideSize * 4);

	Uint16Array indices;
	auto index = 0;
	for (auto  count = 0; count < capacity; count++) {
		indices.push_back(index);
		indices.push_back(index + 1);
		indices.push_back(index + 2);
		indices.push_back(index);
		indices.push_back(index + 2);
		indices.push_back(index + 3);
		index += 4;
	}

	this->_indexBuffer = scene->getEngine()->createIndexBuffer(indices);

	this->_vertices.reserve(capacity * this->_vertexStrideSize);

	// Internals
	this->_scaledColorStep = make_shared<Color4>(0, 0, 0, 0);
	this->_colorDiff = make_shared<Color4>(0, 0, 0, 0);
	this->_scaledDirection = Vector3::Zero();
	this->_scaledGravity = Vector3::Zero();
	this->_currentRenderId = -1;
};


float Babylon::ParticleSystem::randomNumber(float min, float max) {
	if (min == max) {
		return (min);
	}

	auto random = rand();

	return ((random * (max - min)) + min);
};

// Methods   
bool Babylon::ParticleSystem::isAlive() {
	return this->_alive;
};

void Babylon::ParticleSystem::start() {
	this->_started = true;
	this->_stopped = false;
	this->_actualFrame = 0;
};

void  Babylon::ParticleSystem::stop() {
	this->_stopped = true;
};

void Babylon::ParticleSystem::_appendParticleVertex(int index, Particle::Ptr particle, float offsetX, float offsetY) {
	auto  offset = index * 11;
	this->_vertices[offset] = particle->position->x;
	this->_vertices[offset + 1] = particle->position->y;
	this->_vertices[offset + 2] = particle->position->z;
	this->_vertices[offset + 3] = particle->color->r;
	this->_vertices[offset + 4] = particle->color->g;
	this->_vertices[offset + 5] = particle->color->b;
	this->_vertices[offset + 6] = particle->color->a;
	this->_vertices[offset + 7] = particle->angle;
	this->_vertices[offset + 8] = particle->size;
	this->_vertices[offset + 9] = offsetX;
	this->_vertices[offset + 10] = offsetY;
};

void Babylon::ParticleSystem::_update(size_t newParticles) {
	// Update current
	this->_alive = this->particles.size() > 0;
	for (auto  particle : this->particles) {
		particle->age += this->_scaledUpdateSpeed;

		if (particle->age >= particle->lifeTime) {
			this->_stockParticles.push_back(particle);
			continue;
		}
		else {
			particle->colorStep->scaleToRef(this->_scaledUpdateSpeed, this->_scaledColorStep);
			particle->color->addInPlace(this->_scaledColorStep);

			if (particle->color->a < 0)
				particle->color->a = 0;

			particle->direction->scaleToRef(this->_scaledUpdateSpeed, this->_scaledDirection);
			particle->position->addInPlace(this->_scaledDirection);

			particle->angle += particle->angularSpeed * this->_scaledUpdateSpeed;

			this->gravity->scaleToRef(this->_scaledUpdateSpeed, this->_scaledGravity);
			particle->direction->addInPlace(this->_scaledGravity);
		}
	}

	// Add new ones
	Matrix::Ptr worldMatrix;

	if (this->emitter->position) {
		worldMatrix = this->emitter->getWorldMatrix();
	} else {
		worldMatrix = Matrix::Translation(this->emitter->position->x, this->emitter->position->y, this->emitter->position->z);
	}

	for (size_t index = 0; index < newParticles; index++) {
		if (this->particles.size() == this->_capacity) {
			break;
		}

		Particle::Ptr particle;
		if (this->_stockParticles.size() != 0) {
			particle = this->_stockParticles[ this->_stockParticles.size() - 1 ];
			this->_stockParticles.pop_back();
			particle->age = 0;
		} else {
			particle = make_shared<Particle>();
		}
		this->particles.push_back(particle);

		auto  emitPower = randomNumber(this->minEmitPower, this->maxEmitPower);

		auto  randX = randomNumber(this->direction1->x, this->direction2->x);
		auto  randY = randomNumber(this->direction1->y, this->direction2->y);
		auto  randZ = randomNumber(this->direction1->z, this->direction2->z);

		Vector3::TransformNormalFromFloatsToRef(randX * emitPower, randY * emitPower, randZ * emitPower, worldMatrix, particle->direction);

		particle->lifeTime = randomNumber(this->minLifeTime, this->maxLifeTime);

		particle->size = randomNumber(this->minSize, this->maxSize);
		particle->angularSpeed = randomNumber(this->minAngularSpeed, this->maxAngularSpeed);

		randX = randomNumber(this->minEmitBox->x, this->maxEmitBox->x);
		randY = randomNumber(this->minEmitBox->y, this->maxEmitBox->y);
		randZ = randomNumber(this->minEmitBox->z, this->maxEmitBox->z);

		Vector3::TransformCoordinatesFromFloatsToRef(randX, randY, randZ, worldMatrix, particle->position);

		auto  step = randomNumber(0, 1.0);

		Color4::LerpToRef(this->color1, this->color2, step, particle->color);

		this->colorDead->subtractToRef(particle->color, this->_colorDiff);
		this->_colorDiff->scaleToRef(1.0 / particle->lifeTime, particle->colorStep);
	}
};

Effect::Ptr Babylon::ParticleSystem::_getEffect() {
	vector<string> defines;

	// TODO: what todo with clipPlane
	////if (BABYLON.clipPlane) {
	////	defines.push_back("#define CLIPPLANE");
	////}

	vector<VertexBufferKind> attributes;
	attributes.push_back(VertexBufferKind_PositionKind);
	attributes.push_back(VertexBufferKind_ColorKind); 
	attributes.push_back(Attribute_Options);

	vector<string> uniformNames;
	uniformNames.push_back("invView");
	uniformNames.push_back("view"); 
	uniformNames.push_back("projection");
	uniformNames.push_back("vClipPlane");
	uniformNames.push_back("textureMask");

	vector<string> samplers;
	samplers.push_back("diffuseSampler");
	
	// Effect
	stringstream ss;
	for_each(begin(defines), end(defines), [&](string& item) { ss << item << endl; });
	auto join = ss.str();

	vector<string> optionalDefines;

	if (this->_cachedDefines != join) {
		this->_cachedDefines = join;
		this->_effect = this->_scene->getEngine()->createEffect("particles",
			attributes,
			uniformNames,
			samplers, 
			join, 
			optionalDefines);
	}

	return this->_effect;
};

void Babylon::ParticleSystem::animate() {
	if (!this->_started)
		return;

	auto effect = this->_getEffect();

	// Check
	if (!this->emitter || !effect->isReady() || !this->particleTexture || !this->particleTexture->isReady())
		return;

	if (this->_currentRenderId == this->_scene->getRenderId()) {
		return;
	}

	this->_currentRenderId = this->_scene->getRenderId();

	this->_scaledUpdateSpeed = this->updateSpeed * this->_scene->getAnimationRatio();

	// determine the number of particles we need to create   
	int emitCout;

	if (this->manualEmitCount > -1) {
		emitCout = this->manualEmitCount;
		this->manualEmitCount = 0;
	} else {
		emitCout = this->emitRate;
	}

	auto  newParticles = ((int)(emitCout * this->_scaledUpdateSpeed) >> 0);
	this->_newPartsExcess += emitCout * this->_scaledUpdateSpeed - newParticles;

	if (this->_newPartsExcess > 1.0) {
		newParticles += this->_newPartsExcess >> 0;
		this->_newPartsExcess -= this->_newPartsExcess >> 0;
	}

	this->_alive = false;

	if (!this->_stopped) {
		this->_actualFrame += this->_scaledUpdateSpeed;

		if (this->targetStopDuration && this->_actualFrame >= this->targetStopDuration)
			this->stop();
	} else {
		newParticles = 0;
	}

	this->_update(newParticles);

	// Stopped?
	if (this->_stopped) {
		if (!this->_alive) {
			this->_started = false;
			if (this->disposeOnStop) {
				this->_scene->_toBeDisposed.push_back(shared_from_this());
			}
		}
	}

	// Update VBO
	auto  offset = 0;
	for (auto particle : this->particles) {

		this->_appendParticleVertex(offset++, particle, 0, 0);
		this->_appendParticleVertex(offset++, particle, 1, 0);
		this->_appendParticleVertex(offset++, particle, 1, 1);
		this->_appendParticleVertex(offset++, particle, 0, 1);
	}
	auto engine = this->_scene->getEngine();
	engine->updateDynamicVertexBuffer(this->_vertexBuffer, this->_vertices, this->particles.size() * this->_vertexStrideSize);
};

// TODO: find out where clipPlane is coming from. seems it is static somewhere
int Babylon::ParticleSystem::render() {
	auto effect = this->_getEffect();

	// Check
	if (!this->emitter || !effect->isReady() || !this->particleTexture || !this->particleTexture->isReady() || !this->particles.size())
		return 0;

	auto  engine = this->_scene->getEngine();

	// Render
	engine->enableEffect(effect);

	auto  viewMatrix = this->_scene->getViewMatrix();
	effect->setTexture("diffuseSampler", this->particleTexture);
	effect->setMatrix("view", viewMatrix);
	effect->setMatrix("projection", this->_scene->getProjectionMatrix());
	effect->setFloat4("textureMask", this->textureMask->r, this->textureMask->g, this->textureMask->b, this->textureMask->a);

	// TODO: find out where clipPlane coming from 
	Plane::Ptr clipPlane = nullptr;
	if (clipPlane) {
		auto  invView = viewMatrix->clone();
		invView->invert();
		effect->setMatrix("invView", invView);
		effect->setFloat4("vClipPlane", clipPlane->normal->x, clipPlane->normal->y, clipPlane->normal->z, clipPlane->d);
	}        

	// VBOs
	engine->bindBuffers(this->_vertexBuffer, this->_indexBuffer, this->_vertexDeclarations, this->_vertexStrideSize, effect);

	// Draw order
	if (this->blendMode == BLENDMODE_ONEONE) {
		engine->setAlphaMode(ALPHA_ADD);
	} else {
		engine->setAlphaMode(ALPHA_COMBINE);
	}
	engine->draw(true, 0, this->particles.size() * 6);
	engine->setAlphaMode(ALPHA_DISABLE);

	return this->particles.size();
};

void Babylon::ParticleSystem::dispose(bool doNotRecurse) {
	if (this->_vertexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_vertexBuffer);
		this->_vertexBuffer = nullptr;
	}

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}

	if (this->particleTexture) {
		this->particleTexture->dispose();
		this->particleTexture = nullptr;
	}

	// Remove from scene
	auto it = find(begin(this->_scene->particleSystems), end(this->_scene->particleSystems), shared_from_this());
	if (it != end(this->_scene->particleSystems))
	{
		this->_scene->particleSystems.erase(it);
	}

	// Callback
	if (this->onDispose) {
		this->onDispose();
	}
};

// Clone
ParticleSystem::Ptr Babylon::ParticleSystem::clone(string name, Mesh::Ptr newEmitter) {
	auto  result = make_shared<ParticleSystem>(name, this->_capacity, this->_scene);

	// TODO: finish it DeepCopy
	////Tools::DeepCopy(this, result, ["particles"], ["_vertexDeclarations", "_vertexStrideSize"]);

	if (!newEmitter) {
		newEmitter = this->emitter;
	}

	result->emitter = newEmitter;
	if (this->particleTexture) {
		result->particleTexture = Texture::New(this->particleTexture->name, this->_scene);
	}

	result->start();

	return result;
};
