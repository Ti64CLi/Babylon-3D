#ifndef BABYLON_RENDERINGGROUP_H
#define BABYLON_RENDERINGGROUP_H

#include <memory>
#include <vector>
#include <map>
#include <functional>

#include "iengine.h"
#include "subMesh.h"


using namespace std;

namespace Babylon {

	typedef function<void ()> BeforeTransparentsFunc;
	typedef function<void (SubMesh::Array&, SubMesh::Array&, SubMesh::Array&, BeforeTransparentsFunc)> CustomRenderFunctionFunc;

	class RenderingGroup : public enable_shared_from_this<RenderingGroup> {

	public:

		typedef shared_ptr<RenderingGroup> Ptr;
		typedef vector<Ptr> Array;

		int index;

		SubMesh::Array _opaqueSubMeshes;
		SubMesh::Array _alphaTestSubMeshes;
		SubMesh::Array _transparentSubMeshes;

		int _activeVertices;

	protected:
		ScenePtr _scene;

	public: 
		RenderingGroup(int index, ScenePtr scene);

		// Methods
		virtual bool render(CustomRenderFunctionFunc customRenderFunction, BeforeTransparentsFunc beforeTransparents);
		virtual void prepare();
		virtual void dispatch(SubMesh::Ptr subMesh);
	};

};

#endif // BABYLON_RENDERINGGROUP_H