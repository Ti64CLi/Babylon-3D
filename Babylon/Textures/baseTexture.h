#ifndef BABYLON_BASETEXTURE_H
#define BABYLON_BASETEXTURE_H

#include <memory>
#include <vector>

#include "iscene.h"

using namespace std;

namespace Babylon {

	class BaseTexture: public enable_shared_from_this<BaseTexture> {

	public:
		typedef shared_ptr<BaseTexture> Ptr;
		typedef vector<Ptr> Array;
		typedef void (*OnDisposeFunc) ();

	protected:
		string url;
		IScene::Ptr _scene;
		bool hasAlpha;
		int level;
		IGLTexture::Ptr _texture;
		OnDisposeFunc onDispose;

	public:
		DELAYLOADSTATE delayLoadState;

	public: 
		BaseTexture(string url, IScene::Ptr scene);		

		virtual IGLTexture::Ptr getInternalTexture();
		virtual bool isReady();
		// Methods
		virtual Size getSize();
		virtual Size getBaseSize();
		virtual IGLTexture::Ptr _getFromCache(string url, bool noMipmap);
		virtual void delayLoad();
		virtual void releaseInternalTexture();
		virtual void dispose();
	};

};

#endif // BABYLON_BASETEXTURE_H