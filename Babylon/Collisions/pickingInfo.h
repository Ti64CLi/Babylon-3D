#ifndef BABYLON_PICKINGINFO_H
#define BABYLON_PICKINGINFO_H

#include "decls.h"

#include "vector3.h"

namespace Babylon {

	class Mesh;
	typedef shared_ptr_t<Mesh> MeshPtr;

	class PickingInfo : public enable_shared_from_this<PickingInfo> {

	public:

		typedef shared_ptr_t<PickingInfo> Ptr;
		typedef vector_t<Ptr> Array;

		bool hit;
		float distance;
		Vector3::Ptr pickedPoint;
		MeshPtr pickedMesh;

		PickingInfo();
	};

};

#endif // BABYLON_PICKINGINFO_H