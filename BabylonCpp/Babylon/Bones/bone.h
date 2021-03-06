#ifndef BABYLON_BONE_H
#define BABYLON_BONE_H

#include "decls.h"
#include "tools_math.h"

#include "animation.h"
#include "animatable.h"

namespace Babylon {

	class Skeleton;
	typedef shared_ptr_t<Skeleton> SkeletonPtr;

	class Bone : public Animatable, public enable_shared_from_this<Bone> {

	public:

		typedef shared_ptr_t<Bone> Ptr;
		typedef vector_t<Ptr> Array;

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
		// Animatable
		virtual void markAsDirty(string property = "");
		virtual AnimationValue operator[](string key);
	};

};

#endif // BABYLON_BONE_H