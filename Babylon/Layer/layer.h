#ifndef BABYLON_Layer_H
#define BABYLON_Layer_H

#include "decls.h"

#include "iengine.h"
#include "texture.h"
#include "color4.h"
#include "effect.h"

namespace Babylon {

	class Layer : public IDisposable, public enable_shared_from_this<Layer> {

	public:

		typedef shared_ptr<Layer> Ptr;
		typedef vector<Ptr> Array;
		typedef void (*OnDisposeFunc)();

		OnDisposeFunc onDispose;

		string name;
		Texture::Ptr texture;
		bool isBackground;
		Color4::Ptr color;

		ScenePtr _scene;
		IGLBuffer::Ptr _vertexBuffer;
		vector<VertexBufferKind> _vertexDeclarations;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		Effect::Ptr _effect;

	public: 
		Layer(string name, string imgUrl, ScenePtr scene, bool isBackground = true, Color4::Ptr color = nullptr);

		// Methods
		virtual void render();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_Layer_H