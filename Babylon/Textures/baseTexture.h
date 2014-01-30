#ifndef BABYLON_BASETEXTURE_H
#define BABYLON_BASETEXTURE_H

#include <memory>
#include <vector>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class BaseTexture: public IDisposable, public enable_shared_from_this<BaseTexture> {

	public:
		typedef shared_ptr<BaseTexture> Ptr;
		typedef vector<Ptr> Array;
		typedef void (*OnDisposeFunc) ();

	protected:
		string url;
		ScenePtr _scene;
		IGLTexture::Ptr _texture;
		OnDisposeFunc onDispose;

	public:
		bool hasAlpha;
		int level;
		DELAYLOADSTATE delayLoadState;

		// base property
		bool isCube;

	public: 
		BaseTexture(string url, ScenePtr scene);		

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