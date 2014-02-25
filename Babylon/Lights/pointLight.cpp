#include "pointLight.h"
#include "defs.h"
#include "engine.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::PointLight::PointLight(string name, Vector3::Ptr position, Scene::Ptr scene) : Light(name, scene)
{
    this->position = position;
    this->diffuse = make_shared<Color3>(1.0, 1.0, 1.0);
    this->specular = make_shared<Color3>(1.0, 1.0, 1.0);
}

PointLight::Ptr Babylon::PointLight::New(string name, Vector3::Ptr position, Scene::Ptr scene)
{
	auto pointLight = make_shared<PointLight>(PointLight(name, position, scene));
	scene->lights.push_back(dynamic_pointer_cast<Light>(pointLight));
	return pointLight;
}

// Methods
void Babylon::PointLight::transferToEffect(Effect::Ptr effect, string positionUniformName, string dummay) {
	if (this->parent && this->parent->hasWorldMatrix()) {
		if (!this->_transformedPosition) {
			this->_transformedPosition = Vector3::Zero();
		}

		Vector3::TransformCoordinatesToRef(this->position, this->parent->getWorldMatrix(), this->_transformedPosition);
		effect->setFloat4(positionUniformName, this->_transformedPosition->x, this->_transformedPosition->y, this->_transformedPosition->z, 0);

		return;
	}

	effect->setFloat4(positionUniformName, this->position->x, this->position->y, this->position->z, 0);
};

ShadowGenerator::Ptr Babylon::PointLight::getShadowGenerator() {
	return nullptr;
};

bool Babylon::PointLight::hasWorldMatrix() {
	return true;
}

Matrix::Ptr Babylon::PointLight::_getWorldMatrix() {
	if (!this->_worldMatrix) {
		this->_worldMatrix = Matrix::Identity();
	}

	Matrix::TranslationToRef(this->position->x, this->position->y, this->position->z, this->_worldMatrix);

	return this->_worldMatrix;
};
