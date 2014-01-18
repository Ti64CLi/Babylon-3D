#include "plane.h"

using namespace Babylon;

Babylon::Plane::Plane(float a, float b, float c, float d) {
	this->normal = make_shared<Vector3>(a, b, c);
	this->d = d;
};

// Methods
void Babylon::Plane::normalize() {
	auto norm = (sqrt((this->normal->x * this->normal->x) + (this->normal->y * this->normal->y) + (this->normal->z * this->normal->z)));
	auto magnitude = 0;

	if (norm != 0) {
		magnitude = 1.0 / norm;
	}

	this->normal->x *= magnitude;
	this->normal->y *= magnitude;
	this->normal->z *= magnitude;

	this->d *= magnitude;
};

Plane::Ptr Babylon::Plane::transform(Matrix::Ptr transformation) {
	auto transposedMatrix = Matrix::Transpose(transformation);
	auto x = this->normal->x;
	auto y = this->normal->y;
	auto z = this->normal->z;
	auto d = this->d;

	auto normalX = (((x * transposedMatrix->m[0]) + (y * transposedMatrix->m[1])) + (z * transposedMatrix->m[2])) + (d * transposedMatrix->m[3]);
	auto normalY = (((x * transposedMatrix->m[4]) + (y * transposedMatrix->m[5])) + (z * transposedMatrix->m[6])) + (d * transposedMatrix->m[7]);
	auto normalZ = (((x * transposedMatrix->m[8]) + (y * transposedMatrix->m[9])) + (z * transposedMatrix->m[10])) + (d * transposedMatrix->m[11]);
	auto finalD = (((x * transposedMatrix->m[12]) + (y * transposedMatrix->m[13])) + (z * transposedMatrix->m[14])) + (d * transposedMatrix->m[15]);

	return make_shared<Plane>(normalX, normalY, normalZ, finalD);
};


float Babylon::Plane::dotCoordinate(Vector3::Ptr point) {
	return ((((this->normal->x * point->x) + (this->normal->y * point->y)) + (this->normal->z * point->z)) + this->d);
};

void Babylon::Plane::copyFromPoints(Vector3::Ptr point1, Vector3::Ptr point2, Vector3::Ptr point3) {
	auto x1 = point2->x - point1->x;
	auto y1 = point2->y - point1->y;
	auto z1 = point2->z - point1->z;
	auto x2 = point3->x - point1->x;
	auto y2 = point3->y - point1->y;
	auto z2 = point3->z - point1->z;
	auto yz = (y1 * z2) - (z1 * y2);
	auto xz = (z1 * x2) - (x1 * z2);
	auto xy = (x1 * y2) - (y1 * x2);
	auto pyth = (sqrt((yz * yz) + (xz * xz) + (xy * xy)));
	auto invPyth = 0.;

	if (pyth != 0) {
		invPyth = 1.0 / pyth;
	}
	else {
		invPyth = 0;
	}

	this->normal->x = yz * invPyth;
	this->normal->y = xz * invPyth;
	this->normal->z = xy * invPyth;
	this->d = -((this->normal->x * point1->x) + (this->normal->y * point1->y) + (this->normal->z * point1->z));
};

bool Babylon::Plane::isFrontFacingTo(Vector3::Ptr direction, float epsilon) {
	auto dot = Vector3::Dot(this->normal, direction);
	return (dot <= epsilon);
};

float Babylon::Plane::signedDistanceTo(Vector3::Ptr point) {
	return Vector3::Dot(point, this->normal) + this->d;
};

// Statics
Plane::Ptr Babylon::Plane::FromArray(Float32Array array) {
	return make_shared<Plane>(array[0], array[1], array[2], array[3]);
};

Plane::Ptr Babylon::Plane::FromPoints(Vector3::Ptr point1, Vector3::Ptr point2, Vector3::Ptr point3) {
	auto result = make_shared<Plane>(0, 0, 0, 0);
	result->copyFromPoints(point1, point2, point3);
	return result;
};

Plane::Ptr Babylon::Plane::FromPositionAndNormal(Vector3::Ptr origin, Vector3::Ptr normal) {
	auto result = make_shared<Plane>(0, 0, 0, 0);
	normal->normalize();

	result->normal = normal;
	result->d = -(normal->x * origin->x + normal->y * origin->y + normal->z * origin->z);

	return result;
};

float Babylon::Plane::SignedDistanceToPlaneFromPositionAndNormal(Vector3::Ptr origin, Vector3::Ptr normal, Vector3::Ptr point) {
	auto d = -(normal->x * origin->x + normal->y * origin->y + normal->z * origin->z);
	return Vector3::Dot(point, normal) + d;
};
