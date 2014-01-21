#include "ray.h"
#include <limits>
#include <algorithm>

using namespace Babylon;

Babylon::Ray::Ray(Vector3::Ptr origin, Vector3::Ptr direction) {
	this->origin = origin;
	this->direction = direction;
};

// Methods
bool Babylon::Ray::intersectsBox(BoundingBox::Ptr box) {
	auto d = 0.0;
	auto maxValue = numeric_limits<double>::max();

	if (abs(this->direction->x) < 0.0000001) {
		if (this->origin->x < box->minimum->x || this->origin->x > box->maximum->x) {
			return false;
		}
	}
	else {
		auto inv = 1.0 / this->direction->x;
		auto min = (box->minimum->x - this->origin->x) * inv;
		auto max = (box->maximum->x - this->origin->x) * inv;

		if (min > max) {
			auto temp = min;
			min = max;
			max = temp;
		}

		d = std::max(min, d);
		maxValue = std::min(max, maxValue);

		if (d > maxValue) {
			return false;
		}
	}

	if (abs(this->direction->y) < 0.0000001) {
		if (this->origin->y < box->minimum->y || this->origin->y > box->maximum->y) {
			return false;
		}
	}
	else {
		auto inv = 1.0 / this->direction->y;
		auto min = (box->minimum->y - this->origin->y) * inv;
		auto max = (box->maximum->y - this->origin->y) * inv;

		if (min > max) {
			auto temp = min;
			min = max;
			max = temp;
		}

		d = std::max(min, d);
		maxValue = std::min(max, maxValue);

		if (d > maxValue) {
			return false;
		}
	}

	if (abs(this->direction->z) < 0.0000001) {
		if (this->origin->z < box->minimum->z || this->origin->z > box->maximum->z) {
			return false;
		}
	}
	else {
		auto inv = 1.0 / this->direction->z;
		auto min = (box->minimum->z - this->origin->z) * inv;
		auto max = (box->maximum->z - this->origin->z) * inv;

		if (min > max) {
			auto temp = min;
			min = max;
			max = temp;
		}

		d = std::max(min, d);
		maxValue = std::min(max, maxValue);

		if (d > maxValue) {
			return false;
		}
	}
	return true;
};

bool Babylon::Ray::intersectsSphere(BoundingSphere::Ptr sphere) {
	auto x = sphere->center->x - this->origin->x;
	auto y = sphere->center->y - this->origin->y;
	auto z = sphere->center->z - this->origin->z;
	auto pyth = (x * x) + (y * y) + (z * z);
	auto rr = sphere->radius * sphere->radius;

	if (pyth <= rr) {
		return true;
	}

	auto dot = (x * this->direction->x) + (y * this->direction->y) + (z * this->direction->z);
	if (dot < 0.0) {
		return false;
	}

	auto temp = pyth - (dot * dot);

	return temp <= rr;
};

bool Babylon::Ray::intersectsTriangle(Vector3::Ptr vertex0, Vector3::Ptr vertex1, Vector3::Ptr vertex2) {
	if (!this->_edge1) {
		this->_edge1 = Vector3::Zero();
		this->_edge2 = Vector3::Zero();
		this->_pvec = Vector3::Zero();
		this->_tvec = Vector3::Zero();
		this->_qvec = Vector3::Zero();
	}

	vertex1->subtractToRef(vertex0, this->_edge1);
	vertex2->subtractToRef(vertex0, this->_edge2);
	Vector3::CrossToRef(this->direction, this->_edge2, this->_pvec);
	auto det = Vector3::Dot(this->_edge1, this->_pvec);

	if (det == 0) {
		return 0;
	}

	auto invdet = 1 / det;

	this->origin->subtractToRef(vertex0, this->_tvec);

	auto bu = Vector3::Dot(this->_tvec, this->_pvec) * invdet;

	if (bu < 0 || bu > 1.0) {
		return 0;
	}

	Vector3::CrossToRef(this->_tvec, this->_edge1, this->_qvec);

	auto bv = Vector3::Dot(this->direction, this->_qvec) * invdet;

	if (bv < 0 || bu + bv > 1.0) {
		return 0;
	}

	return Vector3::Dot(this->_edge2, this->_qvec) * invdet;
};

// Statics
Ray::Ptr Babylon::Ray::CreateNew(float x, float y, int viewportWidth, int viewportHeight, Matrix::Ptr world, Matrix::Ptr view, Matrix::Ptr projection) {
	auto start = Vector3::Unproject(make_shared<Vector3>(x, y, 0), viewportWidth, viewportHeight, world, view, projection);
	auto end = Vector3::Unproject(make_shared<Vector3>(x, y, 1), viewportWidth, viewportHeight, world, view, projection);

	auto direction = end->subtract(start);
	direction->normalize();

	return make_shared<Ray>(start, direction);
};

Ray::Ptr Babylon::Ray::Transform(Ray::Ptr ray, Matrix::Ptr matrix) {
	auto newOrigin = Vector3::TransformCoordinates(ray->origin, matrix);
	auto newDirection = Vector3::TransformNormal(ray->direction, matrix);

	return make_shared<Ray>(newOrigin, newDirection);
};
