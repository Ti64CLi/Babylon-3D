#include "skeleton.h"
#include "engine.h"

using namespace Babylon;

Babylon::Skeleton::Skeleton(string name, string id, Scene::Ptr scene)
{
	this->_scene = scene;

	this->id = id;
	this->name = name;
	this->bones.clear();

	this->_scene = scene;

	scene->skeletons.push_back(enable_shared_from_this<Skeleton>::shared_from_this());

	this->_isDirty = true;
}

// Members
Float32Array Babylon::Skeleton::getTransformMatrices() {       
	return this->_transformMatrices;
};

// Methods
void Babylon::Skeleton::_markAsDirty() {
	this->_isDirty = true;
};

void Babylon::Skeleton::prepare() {
	if (!this->_isDirty) {
		return;
	}

	if (this->_transformMatrices.size() != 16 * this->bones.size()) {
		this->_transformMatrices = Float32Array(16 * this->bones.size());
	}

	for (auto index = 0; index < this->bones.size(); index++) {
		auto bone = this->bones[index];
		auto parentBone = bone->getParent();

		if (parentBone) {
			bone->_matrix->multiplyToRef(parentBone->_worldTransform, bone->_worldTransform);
		} else {
			bone->_worldTransform->copyFrom(bone->_matrix);
		}

		bone->_invertedAbsoluteTransform->multiplyToArray(bone->_worldTransform, this->_transformMatrices, index * 16);
	}

	this->_isDirty = false;
};

Animatable::Array Babylon::Skeleton::getAnimatables() {
	if (this->_animatables.size() != this->bones.size()) {
		this->_animatables.clear();

		for (auto bone : this->bones) {
			this->_animatables.push_back(bone);
		}
	}

	return this->_animatables;
};

Skeleton::Ptr Babylon::Skeleton::clone(string name, string id) {
	auto result = make_shared<Skeleton>(name, id, this->_scene);

	for (auto index = 0; index < this->bones.size(); index++) {
		auto source = this->bones[index];
		Bone::Ptr parentBone = nullptr;

		if (source->getParent()) {
			auto parentIndex = find(begin(this->bones), end(this->bones), source->getParent()) - begin(this->bones);
			parentBone = result->bones[parentIndex];
		}

		auto bone = make_shared<Bone>(source->name, result, parentBone, source->_baseMatrix);

		// TODO: finish
		////Tools::DeepCopy(source->animations, bone->animations);
	}

	return result;
};
