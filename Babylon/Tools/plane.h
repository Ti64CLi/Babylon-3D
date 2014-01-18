#ifndef BABYLON_PLANE_H
#define BABYLON_PLANE_H

#include <memory>
#include <vector>

#include "vector3.h"
#include "matrix.h"

using namespace std;

namespace Babylon {

	class Plane: public enable_shared_from_this<Plane> {

	public:
		typedef shared_ptr<Plane> Ptr;

	public:
		Vector3::Ptr normal;
		float d;

	public: 
		Plane(float a, float b, float c, float d);		

		// Methods
		virtual void normalize();
		virtual Plane::Ptr transform(Matrix::Ptr transformation);
		virtual float dotCoordinate(Vector3::Ptr point);
		virtual void copyFromPoints(Vector3::Ptr point1, Vector3::Ptr point2, Vector3::Ptr point3);
		virtual bool isFrontFacingTo(Vector3::Ptr direction, float epsilon);
		virtual float signedDistanceTo(Vector3::Ptr point);
		// Statics
		static Plane::Ptr FromArray(Float32Array array);
		static Plane::Ptr FromPoints(Vector3::Ptr point1, Vector3::Ptr point2, Vector3::Ptr point3);
		static Plane::Ptr FromPositionAndNormal(Vector3::Ptr origin, Vector3::Ptr normal);
		static float SignedDistanceToPlaneFromPositionAndNormal(Vector3::Ptr origin, Vector3::Ptr normal, Vector3::Ptr point);
	};

};

#endif // BABYLON_PLANE_H