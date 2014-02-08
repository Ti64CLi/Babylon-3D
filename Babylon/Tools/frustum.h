#ifndef BABYLON_FRUSTUM_H
#define BABYLON_FRUSTUM_H

#include "decls.h"

#include "plane.h"

namespace Babylon {

	class Frustum: public enable_shared_from_this<Frustum> {

	public: 
	    static Plane::Array GetPlanes(Matrix::Ptr transform);
		static void GetPlanesToRef(Matrix::Ptr transform, Plane::Array& frustumPlanes);

	};

};

#endif // BABYLON_FRUSTUM_H