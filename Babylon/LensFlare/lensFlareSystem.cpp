#include "lensFlareSystem.h"
#include "engine.h"

using namespace Babylon;

Babylon::LensFlareSystem::LensFlareSystem(string name, Mesh::Ptr emitter, Scene::Ptr scene)
{
	this->_scene = scene;

	this->lensFlares.clear();
	this->_scene = scene;
	this->_emitter = emitter;
	this->name = name;

	scene->lensFlareSystems.push_back(shared_from_this());

	this->meshesSelectionPredicate = [](Mesh::Ptr m) {
		return m->material && m->isVisible && m->isEnabled() && m->checkCollisions;
	};

	// VBO
	Float32Array vertices;
	vertices.push_back(1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);

	this->_vertexDeclaration.clear();
	_vertexDeclaration.push_back(2);

	this->_vertexStrideSize = 2 * 4;
	this->_vertexBuffer = scene->getEngine()->createVertexBuffer(vertices);

	// Indices
	Uint16Array indices;
	indices.push_back(0);
	indices.push_back(1);
	indices.push_back(2);

	indices.push_back(0);
	indices.push_back(2);
	indices.push_back(3);

	this->_indexBuffer = scene->getEngine()->createIndexBuffer(indices);

	vector<string> attributes;
	attributes.push_back("position");

	vector<string> uniformsNames;
	uniformsNames.push_back("color");
	uniformsNames.push_back("viewportMatrix");

	vector<string> samplers;
	samplers.push_back("textureSampler");   

	// Effects
	this->_effect = this->_scene->getEngine()->createEffect("layer",
		attributes,
		uniformsNames,
		samplers, "", "");

	// Members
	borderLimit = 300;
}

// Properties
Scene::Ptr Babylon::LensFlareSystem::getScene() {
	return this->_scene;
};

Vector3::Ptr Babylon::LensFlareSystem::getEmitterPosition() {
	////return this->_emitter->getAbsolutePosition ? this->_emitter->getAbsolutePosition() : this->_emitter->position;
	return this->_emitter->getAbsolutePosition();
};

// Methods
bool Babylon::LensFlareSystem::computeEffectivePosition (Viewport::Ptr globalViewport) {
	auto position = this->getEmitterPosition();

	position = Vector3::Project(position, Matrix::Identity(), this->_scene->getTransformMatrix(), globalViewport);

	this->_positionX = position->x;
	this->_positionY = position->y;

	position = Vector3::TransformCoordinates(this->getEmitterPosition(), this->_scene->getViewMatrix());

	if (position->z > 0) {
		if ((this->_positionX > globalViewport->x) && (this->_positionX < globalViewport->x + globalViewport->width)) {
			if ((this->_positionY > globalViewport->y) && (this->_positionY < globalViewport->y + globalViewport->height))
				return true;
		}
	}

	return false;
};

bool Babylon::LensFlareSystem::_isVisible () {
	auto emitterPosition = this->getEmitterPosition();
	auto direction = emitterPosition->subtract(this->_scene->activeCamera->position);
	auto distance = direction->length();
	direction->normalize();

	auto ray = make_shared<Ray>(this->_scene->activeCamera->position, direction);
	auto pickInfo = this->_scene->pickWithRay(ray, this->meshesSelectionPredicate, true);

	return !pickInfo->hit || pickInfo->distance > distance;
};

bool Babylon::LensFlareSystem::render () {
	if (!this->_effect->isReady())
		return false;

	auto engine = this->_scene->getEngine();
	auto viewport = this->_scene->activeCamera->viewport;
	auto globalViewport = viewport->toGlobal(engine);

	// Position
	if (!this->computeEffectivePosition(globalViewport)) {
		return false;
	}

	// Visibility
	if (!this->_isVisible()) {
		return false;
	}

	// Intensity
	int awayX;
	int awayY;

	if (this->_positionX < this->borderLimit + globalViewport->x) {
		awayX = this->borderLimit + globalViewport->x - this->_positionX;
	} else if (this->_positionX > globalViewport->x + globalViewport->width - this->borderLimit) {
		awayX = this->_positionX - globalViewport->x - globalViewport->width + this->borderLimit;
	} else {
		awayX = 0;
	}

	if (this->_positionY < this->borderLimit + globalViewport->y) {
		awayY = this->borderLimit + globalViewport->y - this->_positionY;
	} else if (this->_positionY > globalViewport->y + globalViewport->height - this->borderLimit) {
		awayY = this->_positionY - globalViewport->y - globalViewport->height + this->borderLimit;
	} else {
		awayY = 0;
	}

	auto away = (awayX > awayY) ? awayX : awayY;
	if (away > this->borderLimit) {
		away = this->borderLimit;
	}

	auto intensity = 1.0 - (away / this->borderLimit);
	if (intensity < 0) {
		return false;
	}

	if (intensity > 1.0) {
		intensity = 1.0;
	}

	// Position
	auto centerX = globalViewport->x + globalViewport->width / 2;
	auto centerY = globalViewport->y + globalViewport->height / 2;
	auto distX = centerX - this->_positionX;
	auto distY = centerY - this->_positionY;

	// Effects
	engine->enableEffect(this->_effect);
	engine->setState(false);
	engine->setDepthBuffer(false);
	engine->setAlphaMode(ALPHA_ADD);

	// VBOs
	engine->bindBuffers(this->_vertexBuffer, this->_indexBuffer, this->_vertexDeclaration, this->_vertexStrideSize, this->_effect);

	// Flares
	for (auto flare : this->lensFlares) {
		//// INFO: I have added ->x, ->y into position
		auto x = centerX - (distX * flare->position->x);
		auto y = centerY - (distY * flare->position->y);

		auto cw = flare->size;
		auto ch = flare->size * engine->getAspectRatio();
		auto cx = 2 * (x / globalViewport->width) - 1.0;
		auto cy = 1.0 - 2 * (y / globalViewport->height);

		auto viewportMatrix = Matrix::FromValues(
			cw / 2, 0, 0, 0,
			0, ch / 2, 0, 0,
			0, 0, 1, 0,
			cx, cy, 0, 1);

		this->_effect->setMatrix("viewportMatrix", viewportMatrix);

		// Texture
		this->_effect->setTexture("textureSampler", flare->texture);

		// Color
		this->_effect->setFloat4("color", flare->color->r * intensity, flare->color->g * intensity, flare->color->b * intensity, 1.0);

		// Draw order
		engine->draw(true, 0, 6);
	}

	engine->setDepthBuffer(true);
	engine->setAlphaMode(ALPHA_DISABLE);
	return true;
};

void Babylon::LensFlareSystem::dispose () {
	if (this->_vertexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_vertexBuffer);
		this->_vertexBuffer = nullptr;
	}

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}

	for (auto lensFlare : this->lensFlares) {
		lensFlare->dispose();
	}

	this->lensFlares.clear();

	// Remove from scene
	auto it = find(begin( this->_scene->lensFlareSystems), end( this->_scene->lensFlareSystems),  shared_from_this());
	if (it != end(this->_scene->lensFlareSystems))
	{
		this->_scene->lensFlareSystems.erase(it);
	}
};

