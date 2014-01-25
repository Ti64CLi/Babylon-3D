#ifndef BABYLON_MULTIMATERIAL_H
#define BABYLON_MULTIMATERIAL_H

#include <memory>
#include <vector>
#include <string>
#include <map>

#include "igl.h"
#include "iengine.h"
#include "tools_math.h"
#include "effect.h"
#include "animatable.h"
#include "material.h"

using namespace std;

namespace Babylon {

	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;

	// TODO: finish it
	class MultiMaterial: public Animatable, public enable_shared_from_this<MultiMaterial> {

	public:
		typedef shared_ptr<MultiMaterial> Ptr;
		typedef vector<Ptr> Array;

		string id;
		string name;
		ScenePtr _scene;
		
		Material::Array subMaterials;

	public: 
		MultiMaterial(string name, ScenePtr scene);

		virtual bool isReady(MeshPtr mesh);
		virtual Material::Ptr getSubMaterial(int index);
	};

};

#endif // BABYLON_MULTIMATERIAL_H