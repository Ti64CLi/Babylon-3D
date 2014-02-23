#include "spotLight.h"
#include "engine.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::SpotLight::SpotLight(string name, Vector3::Ptr position, Vector3::Ptr direction, float angle, float exponent, ScenePtr scene) : Light(name, scene)
{
	this->position = position;
	this->direction = direction;
	this->angle = angle;
	this->exponent = exponent;
	this->diffuse = make_shared<Color3>(1.0, 1.0, 1.0);
	this->specular = make_shared<Color3>(1.0, 1.0, 1.0);
}

SpotLight::Ptr Babylon::SpotLight::New(string name, Vector3::Ptr position, Vector3::Ptr direction, float angle, float exponent, ScenePtr scene)
{
	auto spotLight = make_shared<SpotLight>(SpotLight(name, position, direction, angle, exponent, scene));
	scene->lights.push_back(dynamic_pointer_cast<Light>(spotLight));
	return spotLight;
}

// Methods
void Babylon::SpotLight::transferToEffect(Effect::Ptr effect, string positionUniformName, string directionUniformName) {
	Vector3::Ptr normalizeDirection;

	if (this->parent && this->parent->hasWorldMatrix()) {
		if (!this->_transformedDirection) {
			this->_transformedDirection = Vector3::Zero();
		}
		if (!this->_transformedPosition) {
			this->_transformedPosition = Vector3::Zero();
		}

		auto parentWorldMatrix = this->parent->getWorldMatrix();

		Vector3::TransformCoordinatesToRef(this->position, parentWorldMatrix, this->_transformedPosition);
		Vector3::TransformNormalToRef(this->direction, parentWorldMatrix, this->_transformedDirection);

		effect->setFloat4(positionUniformName, this->_transformedPosition->x, this->_transformedPosition->y, this->_transformedPosition->z, this->exponent);
		normalizeDirection = Vector3::Normalize(this->_transformedDirection);
	} else {
		effect->setFloat4(positionUniformName, this->position->x, this->position->y, this->position->z, this->exponent);
		normalizeDirection = Vector3::Normalize(this->direction);
	}

	effect->setFloat4(directionUniformName, normalizeDirection->x, normalizeDirection->y, normalizeDirection->z, cos(this->angle * 0.5));
};

bool Babylon::SpotLight::hasWorldMatrix() {
	return true;
}

Matrix::Ptr Babylon::SpotLight::_getWorldMatrix() {
	if (!this->_worldMatrix) {
		this->_worldMatrix = Matrix::Identity();
	}

	Matrix::TranslationToRef(this->position->x, this->position->y, this->position->z, this->_worldMatrix);

	return this->_worldMatrix;
};
