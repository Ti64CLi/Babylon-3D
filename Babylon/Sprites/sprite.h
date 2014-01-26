#ifndef BABYLON_Sprite_H
#define BABYLON_Sprite_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class Sprite : public enable_shared_from_this<Sprite> {

	public:

		typedef shared_ptr<Sprite> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		Sprite(ScenePtr scene);
	};

};

#endif // BABYLON_Sprite_H