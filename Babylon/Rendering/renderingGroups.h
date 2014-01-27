#ifndef BABYLON_RENDERINGGROUPS_H
#define BABYLON_RENDERINGGROUPS_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "subMesh.h"


using namespace std;

namespace Babylon {

	class RenderingGroups : public enable_shared_from_this<RenderingGroups> {

	public:

		typedef shared_ptr<RenderingGroups> Ptr;
		typedef vector<Ptr> Array;

		//typedef function<int ()> BeforeTransparentsFunc;
		typedef void (*BeforeTransparentsFunc)();
		//typedef function<int (SubMesh::Array, SubMesh::Array, SubMesh::Array, BeforeTransparentsFunc)> CustomRenderFunctionFunc;
		typedef void (*CustomRenderFunctionFunc)(SubMesh::Array, SubMesh::Array, SubMesh::Array, BeforeTransparentsFunc);

		int index;

		SubMesh::Array _opaqueSubMeshes;
		SubMesh::Array _transparentSubMeshes;
		SubMesh::Array _alphaTestSubMeshes;

		int _activeVertices;

	protected:
		ScenePtr _scene;

	public: 
		RenderingGroups(int index, ScenePtr scene);

		// Methods
		virtual bool render(CustomRenderFunctionFunc customRenderFunction, BeforeTransparentsFunc beforeTransparents);
		virtual void prepare();
		virtual void dispatch(SubMesh::Ptr subMesh);
	};

};

#endif // BABYLON_RENDERINGGROUPS_H