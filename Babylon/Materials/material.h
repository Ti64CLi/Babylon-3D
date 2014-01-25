#ifndef BABYLON_MATERIAL_H
#define BABYLON_MATERIAL_H

#include <memory>
#include <vector>
#include <string>
#include <map>

#include "igl.h"
#include "iengine.h"
#include "tools_math.h"
#include "effect.h"
#include "animatable.h"

using namespace std;

namespace Babylon {

	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;

	// TODO: finish it
	class Material: public Animatable, public enable_shared_from_this<Material> {

	public:
		typedef shared_ptr<Material> Ptr;
		typedef vector<Ptr> Array;
		typedef void (*OnDisposeFunc)();

		string id;
		string name;
		ScenePtr _scene;

		// Members
		bool checkReadyOnEveryCall;
		bool checkReadyOnlyOnce;
		float alpha;
		bool wireframe;
		bool backFaceCulling;
		Effect::Ptr _effect;
		bool _wasPreviouslyReady;

		OnDisposeFunc onDispose;

	public: 
		Material(string name, ScenePtr scene);

		virtual bool isReady(MeshPtr mesh);
		virtual Effect::Ptr getEffect();
		virtual bool needAlphaBlending();
		virtual bool needAlphaTesting();
		virtual void _preBind();
		virtual void bind(Matrix::Ptr world, MeshPtr mesh);
		virtual void unbind();
		virtual void baseDispose();
		virtual void dispose();
	};

};

#endif // BABYLON_MATERIAL_H