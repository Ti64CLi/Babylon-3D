#ifndef BABYLON_RENDERINGMANAGER_H
#define BABYLON_RENDERINGMANAGER_H

#include <memory>
#include <vector>
#include <map>
#include <functional>

#include "iengine.h"
#include "renderingGroup.h"
#include "mesh.h"
#include "subMesh.h"

using namespace std;

namespace Babylon {

	class RenderingManager : public enable_shared_from_this<RenderingManager> {

	public:

		typedef shared_ptr<RenderingManager> Ptr;
		typedef vector<Ptr> Array;

		static int MAX_RENDERINGGROUPS;

		RenderingGroup::Array _renderingGroups;
		bool _depthBufferAlreadyCleaned;

	protected:
		ScenePtr _scene;

	public: 
		RenderingManager(ScenePtr scene);

		// Methods
		virtual void _renderParticles (int index, Mesh::Array activeMeshess);
		virtual void _renderSprites (int index);
		virtual void _clearDepthBuffer ();
		virtual void render (CustomRenderFunctionFunc customRenderFunction, Mesh::Array activeMeshes, bool renderParticles, bool renderSprites);
		virtual void reset ();
		virtual void dispatch (SubMesh::Ptr subMesh);
	};

};

#endif // BABYLON_RENDERINGMANAGER_H