#ifndef BABYLON_BASETEXTURE_H
#define BABYLON_BASETEXTURE_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "iscene.h"

using namespace std;

namespace Babylon {

	class BaseTexture: public enable_shared_from_this<BaseTexture> {

	public:
		typedef shared_ptr<BaseTexture> Ptr;
		typedef vector<Ptr> Array;
		typedef void (*OnDisposeFunc) ();

	private:
		string url;
		IScene::Ptr scene;

	protected:
		DELAYLOADSTATE delayLoadState;
		bool hasAlpha;
		int level;
		IGLTexture::Ptr _texture;
		OnDisposeFunc onDispose;

	public: 
		BaseTexture(string url, IScene::Ptr scene);		
	};

};

#endif // BABYLON_BASETEXTURE_H