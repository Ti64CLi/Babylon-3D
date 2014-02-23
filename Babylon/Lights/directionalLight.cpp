#include "directionalLight.h"
#include "engine.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::DirectionalLight::DirectionalLight(string name, Vector3::Ptr direction, ScenePtr scene) : Light(name, scene)
{
	this->position = direction->scale(-1);
	this->direction = direction;
	this->diffuse = make_shared<Color3>(1.0, 1.0, 1.0);
	this->specular = make_shared<Color3>(1.0, 1.0, 1.0);
}

DirectionalLight::Ptr Babylon::DirectionalLight::New(string name, Vector3::Ptr direction, ScenePtr scene)
{
	auto directionalLight = make_shared<DirectionalLight>(DirectionalLight(name, direction, scene));
	scene->lights.push_back(dynamic_pointer_cast<Light>(directionalLight));
	return directionalLight;
}

// Methods
void Babylon::DirectionalLight::transferToEffect(Effect::Ptr effect, string directionUniformName, string dummy) {
	if (this->parent && this->parent->hasWorldMatrix()) {
		if (!this->_transformedDirection) {
			this->_transformedDirection = Vector3::Zero();
		}

		Vector3::TransformNormalToRef(this->direction, this->parent->getWorldMatrix(), this->_transformedDirection);
		effect->setFloat4(directionUniformName, this->_transformedDirection->x, this->_transformedDirection->y, this->_transformedDirection->z, 1);

		return;
	}

	effect->setFloat4(directionUniformName, this->direction->x, this->direction->y, this->direction->z, 1);
};

bool Babylon::DirectionalLight::hasWorldMatrix() {
	return true;
}

Matrix::Ptr Babylon::DirectionalLight::_getWorldMatrix() {
	if (!this->_worldMatrix) {
		this->_worldMatrix = Matrix::Identity();
	}

	Matrix::TranslationToRef(this->position->x, this->position->y, this->position->z, this->_worldMatrix);

	return this->_worldMatrix;
};
