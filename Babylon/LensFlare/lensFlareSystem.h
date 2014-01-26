#ifndef BABYLON_lensFlareSystem_H
#define BABYLON_LensFlareSystem_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class LensFlareSystem : public enable_shared_from_this<LensFlareSystem> {

	public:

		typedef shared_ptr<LensFlareSystem> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		LensFlareSystem(ScenePtr scene);
	};

};

#endif // BABYLON_LensFlareSystem_H