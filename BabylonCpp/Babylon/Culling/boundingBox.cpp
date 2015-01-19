#include "boundingBox.h"
#include "defs.h"

using namespace Babylon;

Babylon::BoundingBox::BoundingBox(Vector3::Ptr minimum, Vector3::Ptr maximum) 
{
	this->minimum = minimum;
	this->maximum = maximum;

	// Bounding vectors
	this->vectors.clear();

	this->vectors.push_back(this->minimum->clone());
	this->vectors.push_back(this->maximum->clone());

	this->vectors.push_back(this->minimum->clone());
	this->vectors[2]->x = this->maximum->x;

	this->vectors.push_back(this->minimum->clone());
	this->vectors[3]->y = this->maximum->y;

	this->vectors.push_back(this->minimum->clone());
	this->vectors[4]->z = this->maximum->z;

	this->vectors.push_back(this->maximum->clone());
	this->vectors[5]->z = this->minimum->z;

	this->vectors.push_back(this->maximum->clone());
	this->vectors[6]->x = this->minimum->x;

	this->vectors.push_back(this->maximum->clone());
	this->vectors[7]->y = this->minimum->y;

	// OBB
	this->center = this->maximum->add(this->minimum)->scale(0.5);
	this->extends = this->maximum->subtract(this->minimum)->scale(0.5);
	this->directions.push_back(Vector3::Zero());
	this->directions.push_back(Vector3::Zero());
	this->directions.push_back(Vector3::Zero());

	// World
	this->vectorsWorld.clear();
	this->vectorsWorld.reserve(this->vectors.size());
	for (auto index = 0; index < this->vectors.size(); index++) {
		this->vectorsWorld.push_back(Vector3::Zero());
	}

	this->minimumWorld = Vector3::Zero();
	this->maximumWorld = Vector3::Zero();

	this->_update(Matrix::Identity());
}

// Methods
void Babylon::BoundingBox::_update(Matrix::Ptr world) {
	Vector3::FromFloatsToRef(numeric_limits<int>::max(), numeric_limits<int>::max(), numeric_limits<int>::max(), this->minimumWorld);
	Vector3::FromFloatsToRef(-numeric_limits<int>::max(), -numeric_limits<int>::max(), -numeric_limits<int>::max(), this->maximumWorld);

	for (auto index = 0; index < this->vectors.size(); index++) {
		auto v = this->vectorsWorld[index];
		Vector3::TransformCoordinatesToRef(this->vectors[index], world, v);

		if (v->x < this->minimumWorld->x)
			this->minimumWorld->x = v->x;
		if (v->y < this->minimumWorld->y)
			this->minimumWorld->y = v->y;
		if (v->z < this->minimumWorld->z)
			this->minimumWorld->z = v->z;

		if (v->x > this->maximumWorld->x)
			this->maximumWorld->x = v->x;
		if (v->y > this->maximumWorld->y)
			this->maximumWorld->y = v->y;
		if (v->z > this->maximumWorld->z)
			this->maximumWorld->z = v->z;
	}

	// OBB
	this->maximumWorld->addToRef(this->minimumWorld, this->center);
	this->center->scaleInPlace(0.5);

	Vector3::FromArrayToRef(world->m, 0, this->directions[0]);
	Vector3::FromArrayToRef(world->m, 4, this->directions[1]);
	Vector3::FromArrayToRef(world->m, 8, this->directions[2]);
};

bool Babylon::BoundingBox::isInFrustum(Plane::Array& frustumPlanes) {
	return BoundingBox::IsInFrustum(this->vectorsWorld, frustumPlanes);
};

bool Babylon::BoundingBox::intersectsPoint(Vector3::Ptr point) {
	if (this->maximumWorld->x < point->x || this->minimumWorld->x > point->x)
		return false;

	if (this->maximumWorld->y < point->y || this->minimumWorld->y > point->y)
		return false;

	if (this->maximumWorld->z < point->z || this->minimumWorld->z > point->z)
		return false;

	return true;
};

bool Babylon::BoundingBox::intersectsSphere(BoundingSphere::Ptr sphere) {
	auto vector = Vector3::Clamp(sphere->centerWorld, this->minimumWorld, this->maximumWorld);
	auto num = Vector3::DistanceSquared(sphere->centerWorld, vector);
	return (num <= (sphere->radiusWorld * sphere->radiusWorld));
};

bool Babylon::BoundingBox::intersectsMinMax(Vector3::Ptr  min, Vector3::Ptr  max) {
	if (this->maximumWorld->x < min->x || this->minimumWorld->x > max->x)
		return false;

	if (this->maximumWorld->y < min->y || this->minimumWorld->y > max->y)
		return false;

	if (this->maximumWorld->z < min->z || this->minimumWorld->z > max->z)
		return false;

	return true;
};

// Statics
bool Babylon::BoundingBox::intersects(BoundingBox::Ptr box0, BoundingBox::Ptr box1) {
	if (box0->maximumWorld->x < box1->minimumWorld->x || box0->minimumWorld->x > box1->maximumWorld->x)
		return false;

	if (box0->maximumWorld->y < box1->minimumWorld->y || box0->minimumWorld->y > box1->maximumWorld->y)
		return false;

	if (box0->maximumWorld->z < box1->minimumWorld->z || box0->minimumWorld->z > box1->maximumWorld->z)
		return false;

	return true;
};

bool Babylon::BoundingBox::IsInFrustum(Vector3::Array boundingVectors, Plane::Array& frustumPlanes) {
	for (auto p = 0; p < 6; p++) {
		auto inCount = 8;

		for (auto i = 0; i < 8; i++) {
			if (frustumPlanes[p]->dotCoordinate(boundingVectors[i]) < 0) {
				--inCount;
			} else {
				break;
			}
		}
		if (inCount == 0)
			return false;
	}
	return true;
};
