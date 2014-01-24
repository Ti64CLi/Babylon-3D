#ifndef BABYLON_SKELETON_H
#define BABYLON_SKELETON_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"

#include "bone.h"
#include "animatable.h"

using namespace std;

namespace Babylon {

	class Skeleton : public ISkeleton, public _Animatable, public enable_shared_from_this<Skeleton> {

	public:

		typedef shared_ptr<Skeleton> Ptr;
		typedef vector<Ptr> Array;

	private:
		bool _isDirty;
		_Animatable::Array _animatables;
		Float32Array _transformMatrices;

	public:
		IScene::Ptr _scene;
		string id;
		string name;
		Bone::Array bones;

	public: 
		Skeleton(string name, string id, IScene::Ptr scene);

		virtual Float32Array getTransformMatrices();
		virtual void _markAsDirty();
		virtual void prepare();
		_Animatable::Array Babylon::Skeleton::getAnimatables();
		virtual Skeleton::Ptr clone(string name, string id);
	};

};

#endif // BABYLON_SKELETON_H