#include "bone.h"
#include "skeleton.h"

using namespace Babylon;

Babylon::Bone::Bone(string name, Skeleton::Ptr skeleton, Bone::Ptr parentBone, Matrix::Ptr matrix)
{
	this->name = name;
	this->_skeleton = skeleton;
	this->_matrix = matrix;
	this->_baseMatrix = matrix;
	this->_worldTransform = make_shared<Matrix>();
	this->_absoluteTransform = make_shared<Matrix>();
	this->_invertedAbsoluteTransform = make_shared<Matrix>();
	this->children.clear();
	this->animations.clear();

	skeleton->bones.push_back(shared_from_this());

	if (parentBone) {
		this->_parent = parentBone;
		parentBone->children.push_back(shared_from_this());
	} else {
		this->_parent = nullptr;
	}

	this->_updateDifferenceMatrix();

}

// Members
Bone::Ptr Babylon::Bone::getParent() {
	return this->_parent;
};

Matrix::Ptr Babylon::Bone::getLocalMatrix () {
	return this->_matrix;
};

Matrix::Ptr Babylon::Bone::getAbsoluteMatrix () {
	auto matrix = this->_matrix->clone();
	auto parent = this->_parent;

	while (parent) {
		matrix = matrix->multiply(parent->getLocalMatrix());
		parent = parent->getParent();
	}

	return matrix;
};

// Methods
void Babylon::Bone::updateMatrix(Matrix::Ptr matrix) {
	this->_matrix = matrix;
	this->_skeleton->_markAsDirty();

	this->_updateDifferenceMatrix();
};

void Babylon::Bone::_updateDifferenceMatrix() {
	if (this->_parent) {
		this->_matrix->multiplyToRef(this->_parent->_absoluteTransform, this->_absoluteTransform);
	} else {
		this->_absoluteTransform->copyFrom(this->_matrix);
	}

	this->_absoluteTransform->invertToRef(this->_invertedAbsoluteTransform);

	for (auto child : this->children.size()) {
		child->_updateDifferenceMatrix();
	}
};

void Babylon::Bone::markAsDirty() {
	this->_skeleton->_markAsDirty();
};
