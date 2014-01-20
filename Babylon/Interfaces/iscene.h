#ifndef BABYLON_ISCENE_H
#define BABYLON_ISCENE_H

#include <memory>
#include <vector>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class BaseTexture;
	typedef shared_ptr<BaseTexture> BaseTexturePtr;
	typedef vector<BaseTexturePtr> BaseTextureArray;
	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;
	typedef vector<MeshPtr> MeshArray;

	class IScene {

	public:
		typedef shared_ptr<IScene> Ptr;

	public:
		virtual bool getUseDelayedTextureLoading() = 0;

		virtual void _addPendingData(IGLTexture::Ptr texture) = 0;
		virtual void _addPendingData(IImage::Ptr image) = 0;
		virtual void _removePendingData(IGLTexture::Ptr texture) = 0;
		virtual void _removePendingData(IImage::Ptr image) = 0;

		virtual BaseTextureArray& getTextures() = 0;
		virtual MeshArray& getMeshes() = 0;
		virtual IEngine::Ptr getEngine() = 0;
		// Dispose
		virtual void dispose() = 0;
	};

};

#endif // BABYLON_ISCENE_H