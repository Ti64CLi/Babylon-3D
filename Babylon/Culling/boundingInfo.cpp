#include "boundingInfo.h"
#include <limits>

using namespace Babylon;

Babylon::BoundingInfo::BoundingInfo(BoundingBox::Ptr boundingBox, BoundingSphere::Ptr boundingSphere) 
{
	this->boundingBox = boundingBox;
	this->boundingSphere = boundingSphere;
}

// Methods
void Babylon::BoundingInfo::_update(Matrix::Ptr world, float scale) {
	this->boundingBox->_update(world);
	this->boundingSphere->_update(world, scale);
};

bool Babylon::BoundingInfo::extentsOverlap(float min0, float max0, float min1, float max1) {
	return !(min0 > max1 || min1 > max0);
};

Range Babylon::BoundingInfo::computeBoxExtents(Vector3::Ptr axis, BoundingBox::Ptr box) {
	auto p = Vector3::Dot(box->center, axis);

	auto r0 = abs(Vector3::Dot(box->directions[0], axis)) * box->extends->x;
	auto r1 = abs(Vector3::Dot(box->directions[1], axis)) * box->extends->y;
	auto r2 = abs(Vector3::Dot(box->directions[2], axis)) * box->extends->z;

	auto r = r0 + r1 + r2;
	return Range(p - r, p + r);
};

bool Babylon::BoundingInfo::axisOverlap(Vector3::Ptr axis, BoundingBox::Ptr box0, BoundingBox::Ptr box1) {
	auto result0 = computeBoxExtents(axis, box0);
	auto result1 = computeBoxExtents(axis, box1);

	return extentsOverlap(result0.min, result0.max, result1.min, result1.max);
};

bool Babylon::BoundingInfo::isInFrustum(Plane::Array& frustumPlanes) {
	if (!this->boundingSphere->isInFrustum(frustumPlanes))
		return false;

	return this->boundingBox->isInFrustum(frustumPlanes);
};

// TODO: finish it (add collider)
/*
bool Babylon::BoundingInfo::_checkCollision(Collider::Ptr collider) {
	return collider->_canDoCollision(this->boundingSphere->centerWorld, this->boundingSphere->radiusWorld, this->boundingBox->minimumWorld, this->boundingBox->maximumWorld);
};
*/

bool Babylon::BoundingInfo::intersectsPoint(Vector3::Ptr point) {
	if (!this->boundingSphere->centerWorld) {
		return false;
	}

	if (!this->boundingSphere->intersectsPoint(point)) {
		return false;
	}

	if (!this->boundingBox->intersectsPoint(point)) {
		return false;
	}

	return true;
};

bool Babylon::BoundingInfo::intersects(BoundingInfo::Ptr boundingInfo, float precise) {
	if (!this->boundingSphere->centerWorld || !boundingInfo->boundingSphere->centerWorld) {
		return false;
	}

	if (!BoundingSphere::intersects(this->boundingSphere, boundingInfo->boundingSphere)) {
		return false;
	}

	if (!BoundingBox::intersects(this->boundingBox, boundingInfo->boundingBox)) {
		return false;
	}

	if (!precise) {
		return true;
	}

	auto box0 = this->boundingBox;
	auto box1 = boundingInfo->boundingBox;

	if (!axisOverlap(box0->directions[0], box0, box1)) return false;
	if (!axisOverlap(box0->directions[1], box0, box1)) return false;
	if (!axisOverlap(box0->directions[2], box0, box1)) return false;
	if (!axisOverlap(box1->directions[0], box0, box1)) return false;
	if (!axisOverlap(box1->directions[1], box0, box1)) return false;
	if (!axisOverlap(box1->directions[2], box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[0], box1->directions[0]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[0], box1->directions[1]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[0], box1->directions[2]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[1], box1->directions[0]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[1], box1->directions[1]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[1], box1->directions[2]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[2], box1->directions[0]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[2], box1->directions[1]), box0, box1)) return false;
	if (!axisOverlap(Vector3::Cross(box0->directions[2], box1->directions[2]), box0, box1)) return false;

	return true;
};
