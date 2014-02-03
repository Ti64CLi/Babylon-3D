#include "skeleton.h"
#include "engine.h"
#include <algorithm>

using namespace Babylon;

Babylon::Skeleton::Skeleton(string name, string id, Scene::Ptr scene)
{
	this->_scene = scene;

	this->id = id;
	this->name = name;
	this->bones.clear();

	this->_scene = scene;

	// moved to new
	////scene->skeletons.push_back(shared_from_this());

	this->_isDirty = true;
}

Skeleton::Ptr Babylon::Skeleton::New(string name, string id, Scene::Ptr scene) {
	auto skeleton = make_shared<Skeleton>(Skeleton(name, id, scene));
	scene->skeletons.push_back(skeleton);
	return skeleton;
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

	auto index = 0;
	for (auto bone : this->bones) {
		auto parentBone = bone->getParent();

		if (parentBone) {
			bone->_matrix->multiplyToRef(parentBone->_worldTransform, bone->_worldTransform);
		} else {
			bone->_worldTransform->copyFrom(bone->_matrix);
		}

		bone->_invertedAbsoluteTransform->multiplyToArray(bone->_worldTransform, this->_transformMatrices, index++ * 16);
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
	auto result = Skeleton::New(name, id, this->_scene);

	for (auto source : this->bones) {
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
