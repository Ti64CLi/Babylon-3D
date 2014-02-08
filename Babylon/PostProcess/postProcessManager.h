#ifndef BABYLON_POSTPROCESSMANAGER_H
#define BABYLON_POSTPROCESSMANAGER_H

#include "decls.h"

#include "iengine.h"

using namespace std;

namespace Babylon {

	class PostProcessManager : public IDisposable, public enable_shared_from_this<PostProcessManager> {

	public:

		typedef shared_ptr<PostProcessManager> Ptr;
		typedef vector<Ptr> Array;

		IGLBuffer::Ptr _vertexBuffer;
		vector<VertexBufferKind> _vertexDeclarations;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

	protected:
		ScenePtr _scene;

	public: 
		PostProcessManager(ScenePtr scene);

		// Methods
		virtual void _prepareFrame();
		virtual void _finalizeFrame();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_POSTPROCESSMANAGER_H