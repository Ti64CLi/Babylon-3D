#ifndef BABYLON_RENDERINGGROUPS_H
#define BABYLON_RENDERINGGROUPS_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class RenderingGroups : public enable_shared_from_this<RenderingGroups> {

	public:

		typedef shared_ptr<RenderingGroups> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		RenderingGroups(ScenePtr scene);
	};

};

#endif // BABYLON_RENDERINGGROUPS_H