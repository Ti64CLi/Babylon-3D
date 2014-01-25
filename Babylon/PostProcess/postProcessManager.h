#ifndef BABYLON_POSTPROCESSMANAGER_H
#define BABYLON_POSTPROCESSMANAGER_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class PostProcessManager : public enable_shared_from_this<PostProcessManager> {

	public:

		typedef shared_ptr<PostProcessManager> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		PostProcessManager(ScenePtr scene);
	};

};

#endif // BABYLON_POSTPROCESSMANAGER_H