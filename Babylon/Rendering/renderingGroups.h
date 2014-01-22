#ifndef BABYLON_RenderingGroups_H
#define BABYLON_RenderingGroups_H

#include <memory>
#include <vector>
#include <map>

#include "iscene.h"

using namespace std;

namespace Babylon {

	class RenderingGroups : public enable_shared_from_this<RenderingGroups> {

	public:

		typedef shared_ptr<RenderingGroups> Ptr;
		typedef vector<Ptr> Array;

	protected:
		IScene::Ptr _scene;

	public: 
		RenderingGroups(IScene::Ptr scene);
	};

};

#endif // BABYLON_RenderingGroups_H