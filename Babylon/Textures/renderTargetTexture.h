#ifndef BABYLON_RENDERTARGETTEXTURE_H
#define BABYLON_RENDERTARGETTEXTURE_H

#include "decls.h"

#include "iengine.h"
#include "texture.h"
#include "mesh.h"
#include "renderingManager.h"

namespace Babylon {

	class RenderTargetTexture: public Texture, public IRenderable {

	public:
		typedef shared_ptr<RenderTargetTexture> Ptr;
		typedef vector<Ptr> Array;

		typedef void (*OnBeforeRenderFunc)();
		typedef void (*OnAfterRenderFunc)();

		string name;
		bool _generateMipMaps;
		Mesh::Array renderList;

		RenderingManager::Ptr _renderingManager;

		bool renderParticles;
		bool renderSprites;
		bool isRenderTarget;
		MODES coordinatesMode;

		OnBeforeRenderFunc onBeforeRender;
		OnAfterRenderFunc onAfterRender;

		CustomRenderFunctionFunc customRenderFunction;

	protected:
		ScenePtr scene;

	private:
		vector<string> _waitingRenderList;

	protected: 
		RenderTargetTexture(string name, Size size, ScenePtr scene, bool generateMipMaps);		
	public: 
		static RenderTargetTexture::Ptr New(string name, Size size, ScenePtr scene, bool generateMipMaps);		

		// Methods  
		virtual void resize(Size size, bool generateMipMaps);
		virtual void render();
		virtual Texture::Ptr clone();
	};

};

#endif // BABYLON_RENDERTARGETTEXTURE_H