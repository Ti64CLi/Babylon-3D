#ifndef BABYLON_lensFlare_H
#define BABYLON_lensFlare_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class LensFlare : public enable_shared_from_this<LensFlare> {

	public:

		typedef shared_ptr<LensFlare> Ptr;
		typedef vector<Ptr> Array;

	protected:
		ScenePtr _scene;

	public: 
		LensFlare(ScenePtr scene);
	};

};

#endif // BABYLON_lensFlare_H