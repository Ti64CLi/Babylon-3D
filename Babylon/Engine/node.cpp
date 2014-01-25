#include "node.h"
#include "scene.h"

using namespace Babylon;

Babylon::Node::Node(Scene::Ptr scene)
{
	this->_scene = scene;
	// Cache
	_initCache();

	_childrenFlag = false;
	_isReady = true;
	_isEnabled = true;
	this->parent = nullptr;
}

void Babylon::Node::_initCache() {
	////this->_cache.clear();
	this->_cache_parent = nullptr;
};

void Babylon::Node::updateCache (bool force) {
	if (!force && this->isSynchronized())
		return;

	this->_cache_parent = this->parent;

	this->_updateCache();
};

void Babylon::Node::_updateCache (bool ignoreParentClass) {
	// override it in derived class if you add new variables to the cache
	// and call the parent class method if !ignoreParentClass
};

void Babylon::Node::_syncChildFlag() {
	this->_childrenFlag = this->parent ? this->parent->_childrenFlag : this->_scene->getRenderId();
};

bool Babylon::Node::isSynchronizedWithParent() {
	return this->parent ? !this->parent->_needToSynchonizeChildren(this->_childrenFlag) : true;
};

bool Babylon::Node::_isSynchronized () {
	return true;
};

bool Babylon::Node::isSynchronized (bool updateCache) {
	auto check = this->hasNewParent();

	check = check || !this->isSynchronizedWithParent();

	check = check || !this->_isSynchronized();

	if (updateCache)
		this->updateCache(true);

	return !check;
};

bool Babylon::Node::hasNewParent(bool update) {
	if (this->_cache_parent == this->parent)
		return false;

	if(update)
		this->_cache_parent = this->parent;

	return true;
};

bool Babylon::Node::_needToSynchonizeChildren (bool childFlag) {
	return this->_childrenFlag != childFlag;
};

bool Babylon::Node::isReady () {
	return this->_isReady;
};

bool Babylon::Node::isEnabled () {
	if (!this->isReady() || !this->_isEnabled) {
		return false;
	}

	if (this->parent) {
		return this->parent->isEnabled();
	}

	return true;
};

void Babylon::Node::setEnabled (bool value) {
	this->_isEnabled = value;
};

bool Babylon::Node::isDescendantOf (Node::Ptr ancestor) {
	if (this->parent) {
		if (this->parent == ancestor) {
			return true;
		}

		return this->parent->isDescendantOf(ancestor);
	}

	return false;
};

void Babylon::Node::_getDescendants(Node::Array list, Node::Array& results) {
	for (const auto& item : list) {
		if (item->isDescendantOf(shared_from_this())) {
			results.push_back(item);
		}
	}
};

Matrix::Ptr Babylon::Node::getWorldMatrix() {
	return nullptr;
}

Node::Array Babylon::Node::getDescendants () {
	Node::Array results;
	// todo: finish node
	//this->_getDescendants(this->_scene.meshes, results);
	//this->_getDescendants(this->_scene.lights, results);
	//this->_getDescendants(this->_scene.cameras, results);

	return results;
};

