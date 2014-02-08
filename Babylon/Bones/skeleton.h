#ifndef BABYLON_SKELETON_H
#define BABYLON_SKELETON_H

#include "decls.h"
#include "iengine.h"

#include "bone.h"
#include "animatable.h"

namespace Babylon {

	class Skeleton : public _Animatable {

	public:

		typedef shared_ptr<Skeleton> Ptr;
		typedef vector<Ptr> Array;

	private:
		bool _isDirty;
		Animatable::Array _animatables;
		Float32Array _transformMatrices;

	public:
		ScenePtr _scene;
		string id;
		string name;
		Bone::Array bones;

	protected: 
		Skeleton(string name, string id, ScenePtr scene);
	public: 
		static Skeleton::Ptr New(string name, string id, ScenePtr scene);

		virtual Float32Array getTransformMatrices();
		virtual void _markAsDirty();
		virtual void prepare();
		Animatable::Array getAnimatables();
		virtual Skeleton::Ptr clone(string name, string id);
	};

};

#endif // BABYLON_SKELETON_H