#ifndef BABYLON_BOUNDINGINFO_H
#define BABYLON_BOUNDINGINFO_H

#include <memory>
#include <vector>
#include <map>

#include "vector3.h"
#include "plane.h"
#include "boundingBox.h"
#include "boundingSphere.h"

using namespace std;

namespace Babylon {

	class BoundingInfo : public enable_shared_from_this<BoundingInfo> {

	public:

		typedef shared_ptr<BoundingInfo> Ptr;
		typedef vector<Ptr> Array;

	public:
		BoundingBox::Ptr boundingBox;
		BoundingSphere::Ptr boundingSphere;

	public: 
		BoundingInfo(Vector3::Ptr minimum, Vector3::Ptr maximum);

		// Methods
		virtual void _update(Matrix::Ptr world, float scale);
		virtual bool extentsOverlap(float min0, float max0, float min1, float max1);
		virtual Range computeBoxExtents(Vector3::Ptr axis, BoundingBox::Ptr box);
		virtual bool axisOverlap(Vector3::Ptr axis, BoundingBox::Ptr box0, BoundingBox::Ptr box1);
		virtual bool isInFrustum(Plane::Array& frustumPlanes);
		virtual bool intersectsPoint(Vector3::Ptr point);
		virtual bool intersects(BoundingInfo::Ptr boundingInfo, float precise);

		// Statics
		virtual bool intersects(BoundingInfo::Ptr box0, BoundingInfo::Ptr box1);
	};

};

#endif // BABYLON_BOUNDINGINFO_H