#ifndef BABYLON_BASETEXTURE_H
#define BABYLON_BASETEXTURE_H

#include "decls.h"

#include "iengine.h"

namespace Babylon {

	class BaseTexture: public IDisposable, public enable_shared_from_this<BaseTexture> {

	public:
		typedef shared_ptr_t<BaseTexture> Ptr;
		typedef vector_t<Ptr> Array;
		typedef void (*OnDisposeFunc) ();

	protected:
		string url;
		IGLTexture::Ptr _texture;
		OnDisposeFunc onDispose;

	public:
		ScenePtr _scene;
		bool hasAlpha;
		int level;
		DELAYLOADSTATE delayLoadState;

		// base property
		bool isCube;

	protected: 
		BaseTexture(string url, ScenePtr scene);		

	public: 
		virtual IGLTexture::Ptr getInternalTexture();
		virtual bool isReady();
		// Methods
		virtual Size getSize();
		virtual Size getBaseSize();
		virtual IGLTexture::Ptr _getFromCache(string url, bool noMipmap);
		virtual void delayLoad();
		virtual void releaseInternalTexture();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_BASETEXTURE_H