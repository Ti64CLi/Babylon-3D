#include "collisionPlane.h"

using namespace Babylon;

Babylon::CollisionPlane::CollisionPlane(Vector3::Ptr normal, Vector3::Ptr origin)
{
	this->normal = normal;
	this->origin = origin;

	normal->normalize();

	this->equation.reserve(4);
	this->equation[0] = normal->x;
	this->equation[1] = normal->y;
	this->equation[2] = normal->z;
	this->equation[3] = -(normal->x * origin->x + normal->y * origin->y + normal->z * origin->z);
}

// Methods
bool Babylon::CollisionPlane::isFrontFacingTo(Vector3::Ptr direction, float epsilon) {
	auto dot = Vector3::Dot(this->normal, direction);

	return (dot <= epsilon);
};

float Babylon::CollisionPlane::signedDistanceTo(Vector3::Ptr point) {
	return Vector3::Dot(point, this->normal) + this->equation[3];
};

// Statics
CollisionPlane::Ptr Babylon::CollisionPlane::CreateFromPoints(Vector3::Ptr p1, Vector3::Ptr p2, Vector3::Ptr p3) {
	auto normal = Vector3::Cross(p2->subtract(p1), p3->subtract(p1));

	return make_shared<CollisionPlane>(p1, normal);
};
