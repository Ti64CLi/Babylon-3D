#ifndef BABYLON_SpriteManager_H
#define BABYLON_SpriteManager_H

#include "decls.h"

#include "iengine.h"
#include "sprite.h"
#include "texture.h"
#include "effect.h"

using namespace std;

namespace Babylon {

	class SpriteManager : public IDisposable, public enable_shared_from_this<SpriteManager> {

	public:

		typedef shared_ptr_t<SpriteManager> Ptr;
		typedef vector_t<Ptr> Array;
		typedef void (*OnDisposeFunc) ();

		string name;
		size_t _capacity;
		size_t cellSize;
		Texture::Ptr _spriteTexture;
		float _epsilon;

		Float32Array _vertices;
		IGLBuffer::Ptr _vertexBuffer;
		vector_t<VertexBufferKind> _vertexDeclarations;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		Effect::Ptr _effectBase;
		Effect::Ptr _effectFog;

		Sprite::Array sprites;

		int renderingGroupId;
		OnDisposeFunc onDispose;

	protected:
		ScenePtr _scene;

	public: 
		SpriteManager(string name, string imgUrl, size_t capacity, size_t cellSize, ScenePtr scene, float epsilon = 0.01);

		virtual void _appendSpriteVertex(int index, Sprite::Ptr sprite, int offsetX, int offsetY, size_t rowSize);
		virtual bool render();
		virtual void dispose(bool doNotRecurse = false);
	};
};

#endif // BABYLON_SpriteManager_H