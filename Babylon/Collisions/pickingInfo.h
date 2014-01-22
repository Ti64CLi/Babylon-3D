#ifndef BABYLON_PICKINGINFO_H
#define BABYLON_PICKINGINFO_H

#include <memory>
#include <vector>
#include <map>

#include "vector3.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class PickingInfo : public enable_shared_from_this<PickingInfo> {

	public:

		typedef shared_ptr<PickingInfo> Ptr;
		typedef vector<Ptr> Array;

		bool hit;
		float distance;
		Vector3::Ptr pickedPoint;
		Mesh::Ptr pickedMesh;

		PickingInfo();
	};

};

#endif // BABYLON_PICKINGINFO_H