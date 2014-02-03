#include "boundingSphere.h"
#include <cmath>

using namespace Babylon;

Babylon::BoundingSphere::BoundingSphere(Vector3::Ptr minimum, Vector3::Ptr maximum) 
{
	this->minimum = minimum;
	this->maximum = maximum;

	auto distance = Vector3::Distance(minimum, maximum);

	this->center = Vector3::Lerp(minimum, maximum, 0.5);;
	this->radius = distance * 0.5;

	this->centerWorld = Vector3::Zero();
	this->_update(Matrix::Identity(), 0);

}

// Methods
void Babylon::BoundingSphere::_update(Matrix::Ptr world, float scale) {
	Vector3::TransformCoordinatesToRef(this->center, world, this->centerWorld);
	this->radiusWorld = this->radius * scale;
};

bool Babylon::BoundingSphere::isInFrustum(Plane::Array& frustumPlanes) {
	for (auto i = 0; i < 6; i++) {
		if (frustumPlanes[i]->dotCoordinate(this->centerWorld) <= -this->radiusWorld)
			return false;
	}

	return true;
};

bool Babylon::BoundingSphere::intersectsPoint(Vector3::Ptr point) {
	auto x = this->centerWorld->x - point->x;
	auto y = this->centerWorld->y - point->y;
	auto z = this->centerWorld->z - point->z;

	auto distance = sqrt((x * x) + (y * y) + (z * z));

	if (this->radiusWorld < distance)
		return false;

	return true;
};

// Statics
bool Babylon::BoundingSphere::intersects(BoundingSphere::Ptr sphere0, BoundingSphere::Ptr sphere1) {
	auto x = sphere0->centerWorld->x - sphere1->centerWorld->x;
	auto y = sphere0->centerWorld->y - sphere1->centerWorld->y;
	auto z = sphere0->centerWorld->z - sphere1->centerWorld->z;

	auto distance = sqrt((x * x) + (y * y) + (z * z));

	if (sphere0->radiusWorld + sphere1->radiusWorld < distance)
		return false;

	return true;
};
