#ifndef BABYLON_PostProcessManager_H
#define BABYLON_PostProcessManager_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"

using namespace std;

namespace Babylon {

	class PostProcessManager : public enable_shared_from_this<PostProcessManager> {

	public:

		typedef shared_ptr<PostProcessManager> Ptr;
		typedef vector<Ptr> Array;

	protected:
		IScene::Ptr _scene;

	public: 
		PostProcessManager(IScene::Ptr scene);
	};

};

#endif // BABYLON_PostProcessManager_H