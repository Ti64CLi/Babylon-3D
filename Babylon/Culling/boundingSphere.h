#ifndef BABYLON_BOUNDINGSPHERE_H
#define BABYLON_BOUNDINGSPHERE_H

#include "decls.h"

#include "vector3.h"
#include "matrix.h"
#include "plane.h"

namespace Babylon {

	class BoundingSphere : public enable_shared_from_this<BoundingSphere> {

	public:

		typedef shared_ptr_t<BoundingSphere> Ptr;
		typedef vector_t<Ptr> Array;

	public:
		Vector3::Ptr minimum;
		Vector3::Ptr maximum;
		Vector3::Ptr centerWorld;
		Vector3::Ptr center;
		float radiusWorld;
		float radius;

	public: 
		BoundingSphere(Vector3::Ptr minimum, Vector3::Ptr maximum);

		virtual void _update(Matrix::Ptr world, float scale);
		virtual bool isInFrustum(Plane::Array& frustumPlanes);
		virtual bool intersectsPoint(Vector3::Ptr point);
		static bool intersects(BoundingSphere::Ptr sphere0, BoundingSphere::Ptr sphere1);
	};

};

#endif // BABYLON_BOUNDINGSPHERE_H