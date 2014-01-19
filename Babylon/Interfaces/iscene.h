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
		virtual vector<shared_ptr<BaseTexture>>& getTextures() = 0;
		virtual vector<shared_ptr<Mesh>>& getMeshes() = 0;
		virtual IEngine::Ptr getEngine() = 0;
	};

};

#endif // BABYLON_ISCENE_H