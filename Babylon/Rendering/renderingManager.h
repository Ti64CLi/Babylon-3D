#ifndef BABYLON_RENDERINGMANAGER_H
#define BABYLON_RENDERINGMANAGER_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class RenderingManager : public enable_shared_from_this<RenderingManager> {

	public:

		typedef shared_ptr<RenderingManager> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		RenderingManager(ScenePtr scene);
	};

};

#endif // BABYLON_RENDERINGMANAGER_H