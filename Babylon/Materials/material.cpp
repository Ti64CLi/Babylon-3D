#include "material.h"
#include <algorithm>
#include "engine.h"
#include "mesh.h"

using namespace Babylon;

Babylon::Material::Material(string name, Scene::Ptr scene) {
	// Members
	checkReadyOnEveryCall = true;
	checkReadyOnlyOnce = false;
	alpha = 1.0;
	wireframe = false;
	backFaceCulling = true;
	_effect = nullptr;
	_wasPreviouslyReady = false;

	onDispose = nullptr;

	this->name = name;
	this->id = name;

	this->_scene = scene;
	// TODO: do not forget to add all derived materials to the scene
	////scene->materials.push_back(shared_from_this());
};

Effect::Ptr Babylon::Material::getEffect() {
	return this->_effect;
};

bool Babylon::Material::needAlphaBlending() {
	return (this->alpha < 1.0);
};

bool Babylon::Material::needAlphaTesting() {
	return false;
};

// Methods   
void Babylon::Material::_preBind() {
	auto engine = this->_scene->getEngine();

	engine->enableEffect(this->_effect);
	engine->setState(this->backFaceCulling);
};

void Babylon::Material::bind(Matrix::Ptr world, Mesh::Ptr mesh) {       
};

void Babylon::Material::unbind() {
};

void Babylon::Material::baseDispose() {
	// Remove from scene
	auto it = find (begin(this->_scene->materials), end(this->_scene->materials), shared_from_this());
	if (it != end(this->_scene->materials))
	{
		this->_scene->materials.erase(it);
	}

	// Callback
	if (this->onDispose) {
		this->onDispose();
	}
};

void Babylon::Material::dispose(bool doNotRecurse) {
	this->baseDispose();
};

// my addon to support getRenderTargetTextures
IRenderable::Array Babylon::Material::getRenderTargetTextures() {
	IRenderable::Array _renderTargets;
	return _renderTargets;
};

// TODO: return property object to read/write AnimatedValue
AnimationValue Babylon::Material::operator[](string key)
{
	// TODO: finish it. it is better to return PropertyAnimationValue with object and value to be update to update it
	return AnimationValue();
}

void Babylon::Material::markAsDirty(string property) {
};