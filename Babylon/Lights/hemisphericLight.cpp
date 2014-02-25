#include "hemisphericLight.h"
#include "defs.h"
#include "engine.h"
#include "shadowGenerator.h"

using namespace Babylon;

Babylon::HemisphericLight::HemisphericLight(string name, Vector3::Ptr direction, ScenePtr scene) : Light(name, scene)
{
	this->direction = direction;
	this->diffuse = make_shared<Color3>(1.0, 1.0, 1.0);
	this->specular = make_shared<Color3>(1.0, 1.0, 1.0);
    this->groundColor = make_shared<Color3>(0.0, 0.0, 0.0);
}

HemisphericLight::Ptr Babylon::HemisphericLight::New(string name, Vector3::Ptr direction, ScenePtr scene)
{
	auto hemisphericLight = make_shared<HemisphericLight>(HemisphericLight(name, direction, scene));
	scene->lights.push_back(dynamic_pointer_cast<Light>(hemisphericLight));
	return hemisphericLight;
}

// Methods
void Babylon::HemisphericLight::transferToEffect(Effect::Ptr effect, string directionUniformName, string groundColorUniformName) {
    auto normalizeDirection = Vector3::Normalize(this->direction);
    effect->setFloat4(directionUniformName, normalizeDirection->x, normalizeDirection->y, normalizeDirection->z, 0);
    effect->setColor3(groundColorUniformName, this->groundColor->scale(this->intensity));
};

bool Babylon::HemisphericLight::hasWorldMatrix() {
	return true;
}

Matrix::Ptr Babylon::HemisphericLight::_getWorldMatrix() {
	if (!this->_worldMatrix) {
		this->_worldMatrix = Matrix::Identity();
	}

	return this->_worldMatrix;
};
