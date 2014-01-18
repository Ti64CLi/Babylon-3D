#include "node.h"

using namespace Babylon;

Babylon::Node::Node() 
{
	// Cache
	_initCache();

	_init(nullptr);
}

Babylon::Node::Node(Node::Ptr parent)
{
	// Cache
	_initCache();

	_init(parent);
}

void Babylon::Node::_init(Node::Ptr parent)
{
	_childrenFlag = false;
	_isReady = true;
	_isEnabled = true;
	this->parent = parent;
}

void Babylon::Node::_initCache() {
	this->_cache.clear();
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

bool Babylon::Node::_isSynchronized () {
	return true;
};

bool Babylon::Node::isSynchronized (bool updateCache) {
	auto r = this->hasNewParent();

	r = r || (this->parent && this->parent->_needToSynchonizeChildren());

	r = r || !this->_isSynchronized();

	if (updateCache)
	{
		this->updateCache(true);
	}

	return !r;
};

bool Babylon::Node::hasNewParent(bool update) {
    if (this->_cache_parent == this->parent)
        return false;
        
    if(update)
        this->_cache_parent = this->parent;
        
    return true;
};

bool Babylon::Node::_needToSynchonizeChildren () {
	return this->_childrenFlag;
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

Node::Array Babylon::Node::getDescendants () {
	Node::Array results;
	// todo: finish node
	//this->_getDescendants(this->_scene.meshes, results);
	//this->_getDescendants(this->_scene.lights, results);
	//this->_getDescendants(this->_scene.cameras, results);

	return results;
};

