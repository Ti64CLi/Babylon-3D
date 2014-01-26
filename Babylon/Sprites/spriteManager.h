#ifndef BABYLON_SpriteManager_H
#define BABYLON_SpriteManager_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class SpriteManager : public enable_shared_from_this<SpriteManager> {

	public:

		typedef shared_ptr<SpriteManager> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		SpriteManager(ScenePtr scene);
	};

};

#endif // BABYLON_SpriteManager_H