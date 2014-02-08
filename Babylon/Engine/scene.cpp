#include "scene.h"
#include "defs.h"
#include "engine.h"
#include "tools.h"
#include "frustum.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::Scene::Scene(Engine::Ptr engine) 
{
	this->_engine = engine;
	this->autoClear = true;
	this->forceWireframe = false;
	this->clearColor = make_shared<Color4>(0.2, 0.2, 0.3, 1.0);
	this->ambientColor = make_shared<Color3>(0, 0, 0);

	// moved to new
	////engine->scenes.push_back(shared_from_this());

	this->_totalVertices = 0;
	this->_activeVertices = 0;
	this->_activeParticles = 0;
	this->_lastFrameDuration = 0;
	this->_evaluateActiveMeshesDuration = 0;
	this->_renderTargetsDuration = 0;
	this->_renderDuration = 0;
	this->_particlesDuration = 0;
	this->_spritesDuration = 0;
	this->_animationRatio = 1;

	this->_renderId = 0;
	this->_executeWhenReadyTimeoutId = -1;

	this->_toBeDisposed.reserve(256);

	this->_onReadyCallbacks.clear();
	this->_pendingData.clear();

	this->_onBeforeRenderCallbacks.clear();

	// Fog
	this->fogMode = FOGMODE_NONE;
	this->fogColor = make_shared<Color3>(0.2, 0.2, 0.3);
	this->fogDensity = 0.1f;
	this->fogStart = 0.f;
	this->fogEnd = 1000.0f;

	// Lights
	this->lightsEnabled = true;
	this->lights.clear();

	// Cameras
	this->cameras.clear();
	this->activeCamera = nullptr;

	// Meshes
	this->meshes.clear();

	// Internal smart arrays
	this->_activeMeshes.reserve(256);
	this->_processedMaterials.reserve(256);
	this->_renderTargets.reserve(256);
	this->_activeParticleSystems.reserve(256);
	this->_activeSkeletons.reserve(32);

	// Rendering groups
	// moved to new
	////this->_renderingManager = make_shared<RenderingManager>(shared_from_this());

	// Materials
	this->materials.clear();
	this->multiMaterials.clear();
	// moved to new
	////this->defaultMaterial = make_shared<StandardMaterial>("default material", shared_from_this());

	// Textures
	this->texturesEnabled = true;
	this->textures.clear();

	// Particles
	this->particlesEnabled = true;
	this->particleSystems.clear();

	// Sprites
	this->spriteManagers.clear();

	// Layers
	this->layers.clear();

	// Skeletons
	this->skeletons.clear();

	// Lens flares
	this->lensFlareSystems.clear();

	// Collisions
	this->collisionsEnabled = true;
	this->gravity = make_shared<Vector3>(0, -9.0, 0);

	// Animations
	this->_activeAnimatables.clear();

	// Matrices
	this->_transformMatrix = Matrix::Zero();

	// Internals
	this->_scaledPosition = Vector3::Zero();
	this->_scaledVelocity = Vector3::Zero();

	// Postprocesses
	this->postProcessesEnabled = true;
	// moved to new
	////this->postProcessManager = make_shared<PostProcessManager>(shared_from_this());

	// Customs render targets
	this->renderTargetsEnabled = true;
	this->customRenderTargets.clear();

	// Multi-cameras
	this->activeCameras.clear();

	_animationStartDate = 0;
}

Scene::Ptr Babylon::Scene::New(Engine::Ptr engine) {
	auto scene = make_shared<Scene>(Scene(engine));
	engine->scenes.push_back(scene);
	scene->_renderingManager = make_shared<RenderingManager>(scene);
	scene->postProcessManager = make_shared<PostProcessManager>(scene);
	scene->defaultMaterial = StandardMaterial::New("default material", scene);
	return scene;
}

Engine::Ptr Babylon::Scene::getEngine() {
	return this->_engine;
};

int Babylon::Scene::getTotalVertices() {
	return this->_totalVertices;
};

int Babylon::Scene::getActiveVertices() {
	return this->_activeVertices;
};

int Babylon::Scene::getActiveParticles() {
	return this->_activeParticles;
};
// Stats
int Babylon::Scene::getLastFrameDuration() {
	return this->_lastFrameDuration;
};

int Babylon::Scene::getEvaluateActiveMeshesDuration() {
	return this->_evaluateActiveMeshesDuration;
};

Mesh::Array& Babylon::Scene::geActiveMeshes() {
	return this->_activeMeshes;
};

int Babylon::Scene::getRenderTargetsDuration() {
	return this->_renderTargetsDuration;
};

int Babylon::Scene::getRenderDuration() {
	return this->_renderDuration;
};

int Babylon::Scene::getParticlesDuration() {
	return this->_particlesDuration;
};

int Babylon::Scene::getSpritesDuration() {
	return this->_spritesDuration;
};

int Babylon::Scene::getAnimationRatio() {
	return this->_animationRatio;
};

int Babylon::Scene::getRenderId() {
	return this->_renderId;
};

// Ready
bool Babylon::Scene::isReady() {
	if (this->_pendingData.size() > 0) {
		return false;
	}

	for (auto mesh : this->meshes) {
		auto mat = mesh->material;

		if (mesh->delayLoadState == DELAYLOADSTATE_LOADING) {
			return false;
		}

		if (mat) {
			if (!mat->isReady(mesh)) {
				return false;
			}
		}
	}

	return true;
};

void Babylon::Scene::registerBeforeRender(BeforeRenderFunc func) {
	this->_onBeforeRenderCallbacks.push_back(func);
};

void Babylon::Scene::unregisterBeforeRender(BeforeRenderFunc func) {
	auto it = find ( begin( this->_onBeforeRenderCallbacks ), end (this->_onBeforeRenderCallbacks), func);

	if (it != end (this->_onBeforeRenderCallbacks)) {
		this->_onBeforeRenderCallbacks.erase(it);
	}
};

void Babylon::Scene::_addPendingData(shared_ptr<void> data) {
	this->_pendingData.push_back(data);
};

void Babylon::Scene::_removePendingData(shared_ptr<void> data) {
	auto it = find ( begin( this->_pendingData ), end (this->_pendingData), data);

	if (it != end (this->_pendingData)) {
		this->_pendingData.erase(it);
	}
};

int Babylon::Scene::getWaitingItemsCount() {
	return this->_pendingData.size();
};

void Babylon::Scene::executeWhenReady(ExecuteWhenReadyFunc func) {
	this->_onReadyCallbacks.push_back(func);

	if (this->_executeWhenReadyTimeoutId != -1) {
		return;
	}

	
	// TODO: finish it
	////this->_executeWhenReadyTimeoutId = setTimeout([&] () {
	////	this->_checkIsReady();
	////}, 150);
};

void Babylon::Scene::_checkIsReady() {
	if (this->isReady()) {
		for (auto func : this->_onReadyCallbacks) {
			(*func)();
		};

		this->_onReadyCallbacks.clear();
		this->_executeWhenReadyTimeoutId = -1;
		return;
	}

	
	// TODO: finish it
	////this->_executeWhenReadyTimeoutId = setTimeout([] () {
	////	this->_checkIsReady();
	////}, 150);
};

// Animations
/*
void Babylon::Scene::beginAnimation(target, from, to, loop, float speedRatio, onAnimationEnd) {
	// Local animations
	if (target->animations) {
		this->stopAnimation(target);

		auto animatable = make_shared<_Animatable>(target, from, to, loop, speedRatio, onAnimationEnd);

		this->_activeAnimatables.push_back(animatable);
	}

	// Children animations
	if (target->getAnimatables.size() > 0) {
		auto animatables = target.getAnimatables();
		for (auto animatable : animatables) {
			this->beginAnimation(animatable, from, to, loop, speedRatio, onAnimationEnd);
		}
	}
};

void Babylon::Scene::stopAnimation(target) {
	for (auto index = 0; index < this->_activeAnimatables.size(); index++) {
		if (this->_activeAnimatables[index].target == target) {
			this->_activeAnimatables.splice(index, 1);
			return;
		}
	}
};

void Babylon::Scene::_animate() {
	if (this->_animationStartDate) {
		localtime(&this->_animationStartDate);
	}
	// Getting time
	time_t now;
	localtime(&now);
	auto delay = now - this->_animationStartDate;

	for (auto activeAnimatable : this->_activeAnimatables) {
		if (!activeAnimatable->_animate(delay)) {
			// TODO: finish it
			////this->_activeAnimatables.splice(index, 1);
		}
	}
};
*/

// Matrix
Matrix::Ptr Babylon::Scene::getViewMatrix() {
	return this->_viewMatrix;
};

Matrix::Ptr Babylon::Scene::getProjectionMatrix() {
	return this->_projectionMatrix;
};

Matrix::Ptr Babylon::Scene::getTransformMatrix() {
	return this->_transformMatrix;
};

void Babylon::Scene::setTransformMatrix(Matrix::Ptr view, Matrix::Ptr projection) {
	this->_viewMatrix = view;
	this->_projectionMatrix = projection;

	this->_viewMatrix->multiplyToRef(this->_projectionMatrix, this->_transformMatrix);
};

// Methods
void Babylon::Scene::activeCameraByID(string id) {
	for (auto camera : cameras) {
		if (camera->id == id) {
			this->activeCamera = camera;
			return;
		}
	}
};

Material::Ptr Babylon::Scene::getMaterialByID(string id) {
	for (auto material : this->materials) {
		if (material->id == id) {
			return material;
		}
	}

	return nullptr;
};

Material::Ptr Babylon::Scene::getMaterialByName(string name) {
	for (auto material : this->materials) {
		if (material->name == name) {
			return material;
		}
	}

	return nullptr;
};

Camera::Ptr Babylon::Scene::getCameraByName(string name) {
	for (auto camera : cameras) {
		if (camera->name == name) {
			return camera;
		}
	}

	return nullptr;
};

Light::Ptr Babylon::Scene::getLightByID(string id) {
	for (auto light : this->lights) {
		if (light->id == id) {
			return light;
		}
	}

	return nullptr;
};

Mesh::Ptr Babylon::Scene::getMeshByID(string id) {
	for (auto mesh : this->meshes) {
		if (mesh->id == id) {
			return mesh;
		}
	}

	return nullptr;
};

Mesh::Ptr Babylon::Scene::getLastMeshByID(string id) {
	for (auto index = this->meshes.size() - 1; index >= 0 ; index--) {
		if (this->meshes[index]->id == id) {
			return this->meshes[index];
		}
	}

	return nullptr;
};

Node::Ptr Babylon::Scene::getLastEntryByID(string id) {
	for (auto index = this->meshes.size() - 1; index >= 0 ; index--) {
		if (this->meshes[index]->id == id) {
			return this->meshes[index];
		}
	}

	for (auto index = this->cameras.size() - 1; index >= 0 ; index--) {
		if (this->cameras[index]->id == id) {
			return this->cameras[index];
		}
	}

	for (auto index = this->lights.size() - 1; index >= 0 ; index--) {
		if (this->lights[index]->id == id) {
			return this->lights[index];
		}
	}

	return nullptr;
};

Mesh::Ptr Babylon::Scene::getMeshByName(string name) {
	for (auto mesh : this->meshes) {
		if (mesh->name == name) {
			return mesh;
		}
	}

	return nullptr;
};

Skeleton::Ptr Babylon::Scene::getLastSkeletonByID(string id) {
	for (auto index = this->skeletons.size() - 1; index >= 0 ; index--) {
		if (this->skeletons[index]->id == id) {
			return this->skeletons[index];
		}
	}

	return nullptr;
};

Skeleton::Ptr Babylon::Scene::getSkeletonById(string id) {
	for (auto skeleton : this->skeletons) {
		if (skeleton->id == id) {
			return skeleton;
		}
	}

	return nullptr;
};

Skeleton::Ptr Babylon::Scene::getSkeletonByName(string name) {
	for (auto skeleton : this->skeletons) {
		if (skeleton->name == name) {
			return skeleton;
		}
	}

	return nullptr;
};

bool Babylon::Scene::isActiveMesh(Mesh::Ptr mesh) {
	return find ( begin(this->_activeMeshes), end(this->_activeMeshes) , mesh) != end (this->_activeMeshes);
};

void Babylon::Scene::_evaluateSubMesh(SubMesh::Ptr subMesh, Mesh::Ptr mesh) {
	if (mesh->subMeshes.size() == 1 || subMesh->isInFrustum(this->_frustumPlanes)) {
		auto material = subMesh->getMaterial();

		if (material) {
			// Render targets
			if (material->getRenderTargetTextures().size() > 0) {
				if (find ( begin ( this->_processedMaterials ), end (this->_processedMaterials), material) != end(this->_processedMaterials)) {
					this->_processedMaterials.push_back(material);

					// concat
					////this->_renderTargets.insert(end(this->_renderTargets), begin(material->getRenderTargetTextures()), end(material->getRenderTargetTextures()));
					
					for_each(begin(material->getRenderTargetTextures()), end(material->getRenderTargetTextures()), [&](const IRenderable::Ptr renderable) {
						this->_renderTargets.push_back(dynamic_pointer_cast<IRenderable>(renderable));
					});
				}                                 
			}

			// Dispatch
			this->_activeVertices += subMesh->verticesCount;
			this->_renderingManager->dispatch(subMesh);
		}
	}
};

void Babylon::Scene::_evaluateActiveMeshes() {
	this->_activeMeshes.clear();
	this->_renderingManager->reset();
	this->_processedMaterials.clear();
	this->_activeParticleSystems.clear();
	this->_activeSkeletons.clear();

	if (this->_frustumPlanes.size() == 0) 
	{
		this->_frustumPlanes = Frustum::GetPlanes(this->_transformMatrix);
	}
	else 
	{
		Frustum::GetPlanesToRef(this->_transformMatrix, this->_frustumPlanes);
	}

	// Meshes
	if (this->_selectionOctree) { // Octree
		auto selection = this->_selectionOctree->select(this->_frustumPlanes);

		for (auto block : selection) {
			size_t meshIndex = 0;
			for (auto mesh : block->meshes) {

				if (abs(mesh->_renderId) != this->_renderId) {
					this->_totalVertices += mesh->getTotalVertices();

					if (!mesh->isReady()) {
						continue;
					}

					mesh->computeWorldMatrix();
					mesh->_renderId = 0;
				}

				if (mesh->_renderId == this->_renderId || (mesh->_renderId == 0 && mesh->isEnabled() && mesh->isVisible && mesh->visibility > 0 && mesh->isInFrustum(this->_frustumPlanes))) {
					if (mesh->_renderId == 0) {
						this->_activeMeshes.push_back(mesh);
					}
					mesh->_renderId = this->_renderId;

					if (mesh->skeleton) {
						//this->_activeSkeletons.pushNoDuplicate(mesh->skeleton);
						if (find (begin(this->_activeSkeletons), end(this->_activeSkeletons), mesh->skeleton) != end(this->_activeSkeletons))
						{
							this->_activeSkeletons.push_back(mesh->skeleton);
						}
					}

					auto subMeshes = block->subMeshes[meshIndex];
					for (auto subMesh : subMeshes) {
						if (subMesh->_renderId == this->_renderId) {
							continue;
						}

						subMesh->_renderId = this->_renderId;

						this->_evaluateSubMesh(subMesh, mesh);
					}
				} else {
					mesh->_renderId = -this->_renderId;
				}

				meshIndex++;
			}
		}
	} else { // Full scene traversal
		for (auto mesh : this->meshes) {

			this->_totalVertices += mesh->getTotalVertices();

			if (!mesh->isReady()) {
				continue;
			}

			mesh->computeWorldMatrix();

			if (mesh->isEnabled() && mesh->isVisible && mesh->visibility > 0 && mesh->isInFrustum(this->_frustumPlanes)) {
				this->_activeMeshes.push_back(mesh);

				if (mesh->skeleton) {
					//this->_activeSkeletons.pushNoDuplicate(mesh->skeleton);
					if (find (begin(this->_activeSkeletons), end(this->_activeSkeletons), mesh->skeleton) != end(this->_activeSkeletons))
					{
						this->_activeSkeletons.push_back(mesh->skeleton);
					}
				}

				for (auto subMesh : mesh->subMeshes) {
					this->_evaluateSubMesh(subMesh, mesh);
				}
			}
		}
	}

	// Particle systems
	time_t beforeParticlesDate;
	localtime(&beforeParticlesDate);
	if (this->particlesEnabled) {
		for (auto particleSystem : this->particleSystems) {

			if (!particleSystem->emitter->position || (particleSystem->emitter && particleSystem->emitter->isEnabled())) {
				this->_activeParticleSystems.push_back(particleSystem);
				particleSystem->animate();
			}
		}
	}

	time_t now;
	localtime(&now);
	this->_particlesDuration += now - beforeParticlesDate;
};

void Babylon::Scene::_renderForCamera(Camera::Ptr camera) {
	auto engine = this->_engine;

	this->activeCamera = camera;

	if (!this->activeCamera)
		throw "Active camera not set";

	// Viewport
	engine->setViewport(this->activeCamera->viewport);

	// Camera
	this->_renderId++;
	this->setTransformMatrix(this->activeCamera->getViewMatrix(), this->activeCamera->getProjectionMatrix());

	// Meshes
	time_t beforeEvaluateActiveMeshesDate;
	localtime(&beforeEvaluateActiveMeshesDate);
	this->_evaluateActiveMeshes();
	time_t now;
	localtime(&now);
	this->_evaluateActiveMeshesDuration += now - beforeEvaluateActiveMeshesDate;

	// Skeletons
	for (auto skeleton : this->_activeSkeletons) {
		skeleton->prepare();
	}

	// Customs render targets registration
	for (auto customRenderTarget : this->customRenderTargets) {
		this->_renderTargets.push_back(customRenderTarget);
	}

	// Render targets
	time_t beforeRenderTargetDate;
	localtime(&beforeRenderTargetDate);
	if (this->renderTargetsEnabled) {
		for (auto renderTarget : this->_renderTargets) {
			this->_renderId++;
			renderTarget->render();
		}
	}

	if (this->_renderTargets.size() > 0) { // Restore back buffer
		engine->restoreDefaultFramebuffer();
	}

	localtime(&now);
	this->_renderTargetsDuration = now - beforeRenderTargetDate;

	// Prepare Frame
	this->postProcessManager->_prepareFrame();

	time_t beforeRenderDate;        
	localtime(&beforeRenderDate);
	// Backgrounds
	if (this->layers.size() > 0) {
		engine->setDepthBuffer(false);
		for (auto layer : this->layers) {
			if (layer->isBackground) {
				layer->render();
			}
		}

		engine->setDepthBuffer(true);
	}

	// Render
	Mesh::Array dummy;
	this->_renderingManager->render(nullptr, dummy, true, true);

	// Lens flares
	for (auto lensFlareSystem : this->lensFlareSystems) {
		lensFlareSystem->render();
	}

	// Foregrounds
	if (this->layers.size()) {
		engine->setDepthBuffer(false);
		for (auto layer : this->layers) {
			if (!layer->isBackground) {
				layer->render();
			}
		}

		engine->setDepthBuffer(true);
	}

	localtime(&now);
	this->_renderDuration += now - beforeRenderDate;

	// Finalize frame
	this->postProcessManager->_finalizeFrame();

	// Update camera
	this->activeCamera->_updateFromScene();

	// Reset some special arrays
	this->_renderTargets.clear();
};

void Babylon::Scene::render() {
	time_t startDate;
	localtime(&startDate);
	this->_particlesDuration = 0;
	this->_spritesDuration = 0;
	this->_activeParticles = 0;
	this->_renderDuration = 0;
	this->_evaluateActiveMeshesDuration = 0;
	this->_totalVertices = 0;
	this->_activeVertices = 0;

	// Before render
	// TODO: is ity used?
	////if (this->beforeRender) {
	////	this->beforeRender();
	////}

	for (auto _onBeforeRenderCallback : this->_onBeforeRenderCallbacks) {
		_onBeforeRenderCallback();
	}

	// Animations
	auto deltaTime = Tools::GetDeltaTime();
	this->_animationRatio = deltaTime * (60.0f / 1000.0f);
	// TODO: finish animation
	////this->_animate();

	// Physics
	if (this->_physicsEngine) {
		this->_physicsEngine->_runOneStep(deltaTime / 1000.0f);
	}

	// Clear
	this->_engine->clear(this->clearColor, this->autoClear || this->forceWireframe, true);

	// Shadows
	for (auto light : this->lights) {
		auto shadowGenerator = light->getShadowGenerator();

		if (light->isEnabled() && shadowGenerator) {
			this->_renderTargets.push_back(shadowGenerator->getShadowMap());
		}
	}

	// Multi-cameras?
	if (this->activeCameras.size() > 0) {
		auto currentRenderId = this->_renderId;
		for (auto activeCamera : this->activeCameras) {
			this->_renderId = currentRenderId;
			this->_renderForCamera(activeCamera);
		}
	} else {
		this->_renderForCamera(this->activeCamera);
	}

	// After render
	// TODO: is it used?
	////if (this->afterRender) {
	////	this->afterRender();
	////}

	// Cleaning
	for (auto _toBeDisposedItem : this->_toBeDisposed) {
		_toBeDisposedItem->dispose();
	}

	this->_toBeDisposed.clear();

	time_t now;
	localtime(&now);
	this->_lastFrameDuration = now - startDate;
};

void Babylon::Scene::dispose(bool doNotRecurse) {
	// TODO: is it used?
	////this->beforeRender = nullptr;
	////this->afterRender = nullptr;

	this->skeletons.clear();

	// Detach cameras
	auto canvas = this->_engine->getRenderingCanvas();
	for (auto camera : this->cameras) {
		camera->detachControl(canvas);
	}

	// Release lights
	for (auto light : this->lights) {
		light->dispose();
	}

	this->lights.clear();

	// Release meshes
	for (auto mesh : this->meshes) {
		mesh->dispose(true);
	}

	this->meshes.clear();


	// Release cameras
	for (auto camera : this->cameras) {
		camera->dispose();
	}

	this->cameras.clear();

	// Release materials
	for (auto material : this->materials) {
		material->dispose();
	}

	this->materials.clear();

	// Release particles
	for (auto particleSystem : this->particleSystems) {
		particleSystem->dispose();
	}

	this->particleSystems.clear();

	// Release sprites
	for (auto spriteManager : this->spriteManagers) {
		spriteManager->dispose();
	}

	this->spriteManagers.clear();

	// Release layers
	for (auto layer : this->layers) {
		layer->dispose();
	}

	this->layers.clear();

	// Release textures
	for (auto texture : this->textures) {
		texture->dispose();
	}

	this->textures.clear();

	// Post-processes
	this->postProcessManager->dispose();

	// Physics
	if (this->_physicsEngine) {
		this->disablePhysicsEngine();
	}

	// Remove from engine
	auto it = find ( begin(this->_engine->scenes), end(this->_engine->scenes), shared_from_this());
	if (it != end(this->_engine->scenes))
	{
		this->_engine->scenes.erase(it);
	}

	this->_engine->wipeCaches();
};

// Collisions
/*
void Babylon::Scene::_getNewPosition(Vector3::Ptr position, velocity, Collider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition) {
	position->divideToRef(collider->radius, this->_scaledPosition);
	velocity->divideToRef(collider->radius, this->_scaledVelocity);

	collider->retry = 0;
	collider->initialVelocity = this->_scaledVelocity;
	collider->initialPosition = this->_scaledPosition;
	this->_collideWithWorld(this->_scaledPosition, this->_scaledVelocity, collider, maximumRetry, finalPosition);

	finalPosition->multiplyInPlace(collider->radius);
};

void Babylon::Scene::_collideWithWorld(Vector3::Ptr position, velocity, ollider::Ptr collider, int maximumRetry, Vector3::Ptr finalPosition) {
	auto closeDistance = Engine::collisionsEpsilon * 10.0;

	if (collider->retry >= maximumRetry) {
		finalPosition->copyFrom(position);
		return;
	}

	collider->_initialize(position, velocity, closeDistance);

	// Check all meshes
	for (auto mesh : this->meshes) {
		if (mesh->isEnabled() && mesh->checkCollisions) {
			mesh->_checkCollision(collider);
		}
	}

	if (!collider->collisionFound) {
		position->addToRef(velocity, finalPosition);
		return;
	}

	if (velocity->x != 0 || velocity->y != 0 || velocity->z != 0) {
		collider->_getResponse(position, velocity);
	}

	if (velocity.length() <= closeDistance) {
		finalPosition->copyFrom(position);
		return;
	}

	collider->retry++;
	this->_collideWithWorld(position, velocity, collider, maximumRetry, finalPosition);
};
*/

void Babylon::Scene::checkExtends(Vector3::Ptr v, Vector3::Ptr min, Vector3::Ptr max) {
	if (v->x < min->x)
		min->x = v->x;
	if (v->y < min->y)
		min->y = v->y;
	if (v->z < min->z)
		min->z = v->z;

	if (v->x > max->x)
		max->x = v->x;
	if (v->y > max->y)
		max->y = v->y;
	if (v->z > max->z)
		max->z = v->z;
};

// Octrees
void Babylon::Scene::createOrUpdateSelectionOctree() {
	if (!this->_selectionOctree) {
		this->_selectionOctree = make_shared<Octree>();
	}

	// World limits
	auto min = make_shared<Vector3>(numeric_limits<float>::max(), numeric_limits<float>::max(), numeric_limits<float>::max());
	auto max = make_shared<Vector3>(-numeric_limits<float>::max(), -numeric_limits<float>::max(), -numeric_limits<float>::max());
	for (auto mesh : this->meshes) {
		mesh->computeWorldMatrix(true);
		auto minBox = mesh->getBoundingInfo()->boundingBox->minimumWorld;
		auto maxBox = mesh->getBoundingInfo()->boundingBox->maximumWorld;

		checkExtends(minBox, min, max);
		checkExtends(maxBox, min, max);
	}

	// Update octree
	this->_selectionOctree->update(min, max, this->meshes);
};

// Picking
Ray::Ptr Babylon::Scene::createPickingRay(float x, float y, Matrix::Ptr world) {
	auto engine = this->_engine;

	if (!this->_viewMatrix) {
		if (!this->activeCamera)
			throw "Active camera not set";

		this->setTransformMatrix(this->activeCamera->getViewMatrix(), this->activeCamera->getProjectionMatrix());
	}
	
	auto viewport = this->activeCamera->viewport->toGlobal(engine);

	return Ray::CreateNew(x, y, viewport->width, viewport->height, world, this->_viewMatrix, this->_projectionMatrix);
};

PickingInfo::Ptr Babylon::Scene::_internalPick(RayFunctionFunc rayFunction, PredicateFunc predicate, bool fastCheck) {
	auto pickingInfo =  make_shared<PickingInfo>();

	for (auto mesh : this->meshes) {
		if (predicate) {
			if (!predicate(mesh)) {
				continue;
			}
		} else if (!mesh->isEnabled() || !mesh->isVisible || !mesh->isPickable) {
			continue;
		}

		auto world = mesh->getWorldMatrix();
		auto ray = rayFunction(world);

		auto result = mesh->intersects(ray, fastCheck);
		if (!result->hit)
			continue;

		if (!fastCheck && pickingInfo != nullptr && result->distance >= pickingInfo->distance)
			continue;

		pickingInfo = result;

		if (fastCheck) {
			break;
		}
	}

	return pickingInfo;
};

PickingInfo::Ptr Babylon::Scene::pick(float x, float y, PredicateFunc predicate, bool fastCheck) {
	
	return this->_internalPick([=](Matrix::Ptr world) {
		return this->createPickingRay(x, y, world);
	}, predicate, fastCheck);
};

PickingInfo::Ptr Babylon::Scene::pickWithRay(Ray::Ptr ray, PredicateFunc predicate, bool fastCheck) {
	
	return this->_internalPick([=](Matrix::Ptr world) {
		if (!this->_pickWithRayInverseMatrix) {
			this->_pickWithRayInverseMatrix = Matrix::Identity();
		}
		world->invertToRef(this->_pickWithRayInverseMatrix);
		return Ray::Transform(ray, this->_pickWithRayInverseMatrix);
	}, predicate, fastCheck);
};

// Physics
bool Babylon::Scene::enablePhysics(float gravity, int iterations) {
	if (this->_physicsEngine) {
		return true;
	}

	if (!PhysicsEngine::IsSupported()) {
		return false;
	}

	this->_physicsEngine = make_shared<PhysicsEngine>(gravity, iterations);

	return true;
};

void Babylon::Scene::disablePhysicsEngine() {
	if (!this->_physicsEngine) {
		return;
	}

	this->_physicsEngine->dispose();
	this->_physicsEngine = nullptr;
};

bool Babylon::Scene::isPhysicsEnabled() {
	return this->_physicsEngine != nullptr;
};

void Babylon::Scene::setGravity(Vector3::Ptr gravity) {
	if (!this->_physicsEngine) {
		return;
	}

	this->_physicsEngine->_setGravity(gravity);
};

// TODO: is it used?
/*
Compound::Ptr Babylon::Scene::createCompoundImpostor(options) {
	if (!this->_physicsEngine) {
		return nullptr;
	}

	for (auto index = 0; index < options->parts.size(); index++) {
		auto mesh = options->parts[index].mesh;

		mesh->_physicImpostor = options->parts[index]->impostor;
		mesh->_physicsMass = options->mass / options->parts.size();
		mesh->_physicsFriction = options->friction;
		mesh->_physicRestitution = options->restitution;
	}

	return this->_physicsEngine->_registerCompound(options);
};

void Babylon::Scene::deleteCompoundImpostor(Compound::Ptr compound) {
	for (auto index = 0; index < compound->parts.size(); index++) {
		auto mesh = compound->parts[index]->mesh;
		mesh->_physicImpostor = PhysicsEngine::NoImpostor;
		this->_physicsEngine->_unregisterMesh(mesh);
	}
};
*/
