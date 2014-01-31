#ifndef BABYLON_LENSFLARESYSTEM_H
#define BABYLON_LENSFLARESYSTEM_H

#include <memory>
#include <vector>
#include <map>
#include <functional>

#include "iengine.h"
#include "lensFlare.h"
#include "mesh.h"
#include "texture.h"
#include "effect.h"

using namespace std;

namespace Babylon {

	class LensFlareSystem : public IDisposable, public enable_shared_from_this<LensFlareSystem> {

	public:

		typedef shared_ptr<LensFlareSystem> Ptr;
		typedef vector<Ptr> Array;

		string name;
		LensFlare::Array lensFlares;
		Mesh::Ptr _emitter;

		IGLBuffer::Ptr _vertexBuffer;
		vector<VertexBufferKind> _vertexDeclarations;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		Effect::Ptr _effect;

		std::function<bool (Mesh::Ptr)> meshesSelectionPredicate;

		float _positionX;
		float _positionY;

		int borderLimit;

	protected:
		ScenePtr _scene;

	public: 
		LensFlareSystem(string name, Mesh::Ptr emitter, ScenePtr scene);

		// Properties
		virtual ScenePtr getScene();
		virtual Vector3::Ptr getEmitterPosition();
		// Methods
		virtual bool computeEffectivePosition(Viewport::Ptr globalViewport);
		virtual bool _isVisible();
		virtual bool render();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_LENSFLARESYSTEM_H