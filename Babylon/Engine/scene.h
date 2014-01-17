#ifndef BABYLON_SCENE_H
#define BABYLON_SCENE_H

#include <memory>
#include <vector>

#include "baseTexture.h"
#include "iscene.h"
#include "engine.h"

using namespace std;

namespace Babylon {

	class Scene: public enable_shared_from_this<Scene>, IScene {
	
	public:

		typedef shared_ptr<Scene> Ptr;

	private: 
		Engine::Ptr engine;

	public:
		BaseTexture::Array textures;

	public: 
		Scene(Engine::Ptr engine);
	};

};

#endif // BABYLON_NODE_H