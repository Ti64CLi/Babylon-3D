#ifndef BABYLON_ISCENE_H
#define BABYLON_ISCENE_H

#include <memory>
#include <vector>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class BaseTexture;
	class Mesh;

	class IScene {

	public:
		typedef shared_ptr<IScene> Ptr;

	public:
		virtual void _addPendingData(IGLTexture::Ptr texture) = 0;
		virtual void _addPendingData(IImage::Ptr image) = 0;
		virtual void _removePendingData(IGLTexture::Ptr texture) = 0;
		virtual void _removePendingData(IImage::Ptr image) = 0;

		virtual vector<shared_ptr<BaseTexture>>& getTextures() = 0;
		virtual vector<shared_ptr<Mesh>>& getMeshes() = 0;
		virtual IEngine::Ptr getEngine() = 0;
		// Dispose
		virtual void dispose() = 0;
	};

};

#endif // BABYLON_ISCENE_H