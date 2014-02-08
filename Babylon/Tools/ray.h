#ifndef BABYLON_RAY_H
#define BABYLON_RAY_H

#include "decls.h"

#include "iengine.h"
#include "vector3.h"
#include "matrix.h"
#include "boundingSphere.h"
#include "boundingBox.h"

namespace Babylon {

	struct Ray: public enable_shared_from_this<Ray> {

	public:
		typedef shared_ptr_t<Ray> Ptr;

	public:
		Vector3::Ptr origin;
		Vector3::Ptr direction;

	private:
		Vector3::Ptr _edge1;
		Vector3::Ptr _edge2;
		Vector3::Ptr _pvec;
		Vector3::Ptr _tvec;
		Vector3::Ptr _qvec;

	public: 
		Ray(Vector3::Ptr origin, Vector3::Ptr direction);		

		// Methods
		virtual bool intersectsBox(BoundingBox::Ptr box);
		virtual bool intersectsSphere(BoundingSphere::Ptr sphere);
		virtual float intersectsTriangle(Vector3::Ptr vertex0, Vector3::Ptr vertex1, Vector3::Ptr vertex2);
		// Statics
		static Ray::Ptr CreateNew(float x, float y, int viewportWidth, int viewportHeight, Matrix::Ptr world, Matrix::Ptr view, Matrix::Ptr projection);
		static Ray::Ptr Transform(Ray::Ptr ray, Matrix::Ptr matrix);
	};

};

#endif // BABYLON_RAY_H