#ifndef BABYLON_COLLISIONPLANE_H
#define BABYLON_COLLISIONPLANE_H

#include "decls.h"

#include "vector3.h"

namespace Babylon {

	class CollisionPlane : public enable_shared_from_this<CollisionPlane> {

	public:

		typedef shared_ptr_t<CollisionPlane> Ptr;
		typedef vector_t<Ptr> Array;

		Vector3::Ptr normal;
		Vector3::Ptr origin;
		Float32Array equation;

		CollisionPlane(Vector3::Ptr normal, Vector3::Ptr origin);

		// Methods
		virtual bool isFrontFacingTo (Vector3::Ptr direction, float epsilon);
		virtual float signedDistanceTo (Vector3::Ptr point);
		static CollisionPlane::Ptr CreateFromPoints (Vector3::Ptr p1, Vector3::Ptr p2, Vector3::Ptr p3);
	};

};

#endif // BABYLON_COLLISIONPLANE_H