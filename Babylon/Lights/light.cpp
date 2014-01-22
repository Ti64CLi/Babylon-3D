#include "light.h"

using namespace Babylon;

// Members
float Babylon::Light::intensity = 1.0;

Babylon::Light::Light(string name, IScene::Ptr scene) : Node(scene)
{
	this->name = name;
	this->id = name;

	this->_scene = scene;

	scene->getLights().push_back(enable_shared_from_this<Light>::shared_from_this());

	// Animations
	this->animations.clear();

	// Exclusions
	this->excludedMeshes.clear();
}

// Properties
IScene::Ptr Babylon::Light::getScene() {
	return this->_scene;
};

ShadowGenerator::Ptr Babylon::Light::getShadowGenerator() {
	return this->_shadowGenerator;
};

// Methods
void Babylon::Light::transferToEffect() {
};

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

void Babylon::Light::dispose() {
	if (this->_shadowGenerator) {
		this->_shadowGenerator->dispose();
		this->_shadowGenerator = nullptr;
	}

	// Remove from scene
	auto it = find( begin(this->_scene->getLights()), end(this->_scene->getLights()), enable_shared_from_this<Light>::shared_from_this());
	if (it != end(this->_scene->getLights()))
	{
		this->_scene->getLights().erase(it);
	}
};
