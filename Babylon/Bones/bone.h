#ifndef BABYLON_BONE_H
#define BABYLON_BONE_H

#include <memory>
#include <vector>
#include <map>

#include "matrix.h"
#include "animation.h"
#include "animatable.h"

using namespace std;

namespace Babylon {

	class Skeleton;
	typedef shared_ptr<Skeleton> SkeletonPtr;

	class Bone : public Animatable, public enable_shared_from_this<Bone> {

	public:

		typedef shared_ptr<Bone> Ptr;
		typedef vector<Ptr> Array;

		string name;
		SkeletonPtr _skeleton;
		Matrix::Ptr _matrix;
		Matrix::Ptr _baseMatrix;
		Matrix::Ptr _worldTransform;
		Matrix::Ptr _absoluteTransform;
		Matrix::Ptr _invertedAbsoluteTransform;
		Bone::Array children;
		Animation::Array animations;

		Bone::Ptr _parent;

	public: 
		Bone(string name, SkeletonPtr skeleton, Bone::Ptr parentBone, Matrix::Ptr matrix);
		virtual Bone::Ptr getParent();
		virtual Matrix::Ptr getLocalMatrix();
		virtual Matrix::Ptr getAbsoluteMatrix();
		virtual void updateMatrix(Matrix::Ptr matrix);
		virtual void _updateDifferenceMatrix();
		virtual void markAsDirty(string property = "");
		virtual AnimationValue operator[](string key);
	};

};

#endif // BABYLON_BONE_H