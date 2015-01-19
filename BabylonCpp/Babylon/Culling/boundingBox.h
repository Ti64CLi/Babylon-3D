#ifndef BABYLON_BOUNDINGBOX_H
#define BABYLON_BOUNDINGBOX_H

#include "decls.h"

#include "vector3.h"
#include "matrix.h"
#include "plane.h"
#include "boundingSphere.h"

namespace Babylon {

	class BoundingBox : public enable_shared_from_this<BoundingBox> {

	public:

		typedef shared_ptr_t<BoundingBox> Ptr;
		typedef vector_t<Ptr> Array;

	public:
		Vector3::Ptr minimum;
		Vector3::Ptr maximum;
		Vector3::Ptr center;
		Vector3::Ptr extends;
		Vector3::Ptr minimumWorld;
		Vector3::Ptr maximumWorld;
		Vector3::Array directions;
		Vector3::Array vectors;
		Vector3::Array vectorsWorld;	

	public: 
		BoundingBox(Vector3::Ptr minimum, Vector3::Ptr maximum);

		// Methods
		virtual void _update(Matrix::Ptr world);
		virtual bool isInFrustum(Plane::Array& frustumPlanes);
		virtual bool intersectsPoint(Vector3::Ptr point);
		virtual bool intersectsSphere(BoundingSphere::Ptr sphere);
		virtual bool intersectsMinMax(Vector3::Ptr min, Vector3::Ptr max);
		// Statics
		static bool intersects(BoundingBox::Ptr box0, BoundingBox::Ptr box1);
		static bool IsInFrustum(Vector3::Array boundingVectors, Plane::Array& frustumPlanes);
	};

};

#endif // BABYLON_BOUNDINGBOX_H