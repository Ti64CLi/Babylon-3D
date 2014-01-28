#include "light.h"
#include "engine.h"
#include "shadowGenerator.h"

using namespace Babylon;

// Members
float Babylon::Light::intensity = 1.0;

Babylon::Light::Light(string name, Scene::Ptr scene) : Node(scene)
{
	this->name = name;
	this->id = name;

	this->_scene = scene;

	scene->lights.push_back(enable_shared_from_this<Light>::shared_from_this());

	// Animations
	this->animations.clear();

	// Exclusions
	this->excludedMeshes.clear();
}

// Properties
Scene::Ptr Babylon::Light::getScene() {
	return this->_scene;
};

ShadowGenerator::Ptr Babylon::Light::getShadowGenerator() {
	return this->_shadowGenerator;
};

// Methods
void Babylon::Light::transferToEffect() {
};

// TODO: my addon
bool Babylon::Light::_computeTransformedPosition() {
	return false;
}

Matrix::Ptr Babylon::Light::getWorldMatrix() {
	this->_syncChildFlag();

	auto worldMatrix = this->_getWorldMatrix();

	auto parentLight = dynamic_pointer_cast<Light>(this->parent);
	if (parentLight) {
		if (!this->_parentedWorldMatrix) {
			this->_parentedWorldMatrix = Matrix::Identity();
		}

		worldMatrix->multiplyToRef(parentLight->getWorldMatrix(), this->_parentedWorldMatrix);

		return this->_parentedWorldMatrix;
	}

	return worldMatrix;
};

void Babylon::Light::dispose(bool doNotRecurse) {
	if (this->_shadowGenerator) {
		this->_shadowGenerator->dispose();
		this->_shadowGenerator = nullptr;
	}

	// Remove from scene
	auto it = find( begin(this->_scene->lights), end(this->_scene->lights), enable_shared_from_this<Light>::shared_from_this());
	if (it != end(this->_scene->lights))
	{
		this->_scene->lights.erase(it);
	}
};
