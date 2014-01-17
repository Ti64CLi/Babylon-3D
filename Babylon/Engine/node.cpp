#include "node.h"

using namespace Babylon;

Babylon::Node::Node() 
{
	parent = nullptr;
	_childrenFlag = false;
	_isReady = true;
	_isEnabled = true;
}

Babylon::Node::Node(Node::Ptr parent)
{
	this->parent = parent;
	_childrenFlag = false;
	_isReady = true;
	_isEnabled = true;
}

bool Babylon::Node::isSynchronized () {
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

