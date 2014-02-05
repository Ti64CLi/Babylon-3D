#include "vector3.h"
#include <cmath>
#include "matrix.h"
#include "tools.h"

using namespace Babylon;

Babylon::Vector3::Vector3(float initialX, float initialY, float initialZ) {
	this->x = initialX;
	this->y = initialY;
	this->z = initialZ;
};

// Operators
void Babylon::Vector3::toArray(Float32Array& array, int index) {
	array[index] = this->x;
	array[index + 1] = this->y;
	array[index + 2] = this->z;
};

void Babylon::Vector3::addInPlace(Vector3::Ptr otherVector) {
	this->x += otherVector->x;
	this->y += otherVector->y;
	this->z += otherVector->z;
};

Vector3::Ptr Babylon::Vector3::add(Vector3::Ptr otherVector) {
	return make_shared<Vector3>(this->x + otherVector->x, this->y + otherVector->y, this->z + otherVector->z);
};

void Babylon::Vector3::addToRef(Vector3::Ptr otherVector, Vector3::Ptr result) {
	result->x = this->x + otherVector->x;
	result->y = this->y + otherVector->y;
	result->z = this->z + otherVector->z;
};

void Babylon::Vector3::subtractInPlace(Vector3::Ptr otherVector) {
	this->x -= otherVector->x;
	this->y -= otherVector->y;
	this->z -= otherVector->z;
};

Vector3::Ptr Babylon::Vector3::subtract(Vector3::Ptr otherVector) {
	return make_shared<Vector3>(this->x - otherVector->x, this->y - otherVector->y, this->z - otherVector->z);
};

void Babylon::Vector3::subtractToRef(Vector3::Ptr otherVector, Vector3::Ptr result) {
	result->x = this->x - otherVector->x;
	result->y = this->y - otherVector->y;
	result->z = this->z - otherVector->z;
};

Vector3::Ptr Babylon::Vector3::subtractFromFloats(float x, float y, float z) {
	return make_shared<Vector3>(this->x - x, this->y - y, this->z - z);
};

void Babylon::Vector3::subtractFromFloatsToRef(float x, float y, float z, Vector3::Ptr result) {
	result->x = this->x - x;
	result->y = this->y - y;
	result->z = this->z - z;
};

Vector3::Ptr Babylon::Vector3::negate() {
	return make_shared<Vector3>(-this->x, -this->y, -this->z);
};

void Babylon::Vector3::scaleInPlace(float scale) {
	this->x *= scale;
	this->y *= scale;
	this->z *= scale;
};

Vector3::Ptr Babylon::Vector3::scale(float scale) {
	return make_shared<Vector3>(this->x * scale, this->y * scale, this->z * scale);
};

void Babylon::Vector3::scaleToRef(float scale, Vector3::Ptr result) {
	result->x = this->x * scale;
	result->y = this->y * scale;
	result->z = this->z * scale;
};

bool Babylon::Vector3::equals(Vector3::Ptr otherVector) {
	return otherVector && this->x == otherVector->x && this->y == otherVector->y && this->z == otherVector->z;
};

bool Babylon::Vector3::equalsToFloats(float x, float y, float z) {
	return this->x == x && this->y == y && this->z == z;
};

void Babylon::Vector3::multiplyInPlace(Vector3::Ptr otherVector) {
	this->x *= otherVector->x;
	this->y *= otherVector->y;
	this->z *= otherVector->z;
};

Vector3::Ptr Babylon::Vector3::multiply(Vector3::Ptr otherVector) {
	return make_shared<Vector3>(this->x * otherVector->x, this->y * otherVector->y, this->z * otherVector->z);
};

void Babylon::Vector3::multiplyToRef(Vector3::Ptr otherVector, Vector3::Ptr result) {
	result->x = this->x * otherVector->x;
	result->y = this->y * otherVector->y;
	result->z = this->z * otherVector->z;
};

Vector3::Ptr Babylon::Vector3::multiplyByFloats(float x, float y, float z) {
	return make_shared<Vector3>(this->x * x, this->y * y, this->z * z);
};

Vector3::Ptr Babylon::Vector3::divide(Vector3::Ptr otherVector) {
	return make_shared<Vector3>(this->x / otherVector->x, this->y / otherVector->y, this->z / otherVector->z);
};

void Babylon::Vector3::divideToRef(Vector3::Ptr otherVector, Vector3::Ptr result) {
	result->x = this->x / otherVector->x;
	result->y = this->y / otherVector->y;
	result->z = this->z / otherVector->z;
};

// Properties
float Babylon::Vector3::length() {
	return sqrt(this->x * this->x + this->y * this->y + this->z * this->z);
};

float Babylon::Vector3::lengthSquared() {
	return (this->x * this->x + this->y * this->y + this->z * this->z);
};

// Methods
void Babylon::Vector3::normalize() {
	auto len = this->length();

	if (len == 0)
		return;

	auto num = 1.0 / len;

	this->x *= num;
	this->y *= num;
	this->z *= num;
};

Vector3::Ptr Babylon::Vector3::clone() {
	return make_shared<Vector3>(this->x, this->y, this->z);
};

void Babylon::Vector3::copyFrom(Vector3::Ptr source) {
	this->x = source->x;
	this->y = source->y;
	this->z = source->z;
};

void Babylon::Vector3::copyFromFloats(float x, float y, float z) {
	this->x = x;
	this->y = y;
	this->z = z;
};

// Statics
Vector3::Ptr Babylon::Vector3::FromArray(Float32Array array, int offset) {
	if (!offset) {
		offset = 0;
	}

	return make_shared<Vector3>(array[offset], array[offset + 1], array[offset + 2]);
};

void Babylon::Vector3::FromArrayToRef(Float32Array array, int offset, Vector3::Ptr result) {
	if (!offset) {
		offset = 0;
	}

	result->x = array[offset];
	result->y = array[offset + 1];
	result->z = array[offset + 2];
};

void Babylon::Vector3::FromFloatsToRef(float x, float y, float z, Vector3::Ptr result) {
	result->x = x;
	result->y = y;
	result->z = z;
};

Vector3::Ptr Babylon::Vector3::Zero() {
	return make_shared<Vector3>(0, 0, 0);
};

Vector3::Ptr Babylon::Vector3::Up() {
	return make_shared<Vector3>(0, 1.0, 0);
};

Vector3::Ptr Babylon::Vector3::TransformCoordinates(Vector3::Ptr vector, Matrix::Ptr transformation) {
	auto result = Vector3::Zero();
	Vector3::TransformCoordinatesToRef(vector, transformation, result);
	return result;
};

void Babylon::Vector3::TransformCoordinatesToRef(Vector3::Ptr vector, Matrix::Ptr transformation, Vector3::Ptr result) {
	auto x = (vector->x * transformation->m[0]) + (vector->y * transformation->m[4]) + (vector->z * transformation->m[8]) + transformation->m[12];
	auto y = (vector->x * transformation->m[1]) + (vector->y * transformation->m[5]) + (vector->z * transformation->m[9]) + transformation->m[13];
	auto z = (vector->x * transformation->m[2]) + (vector->y * transformation->m[6]) + (vector->z * transformation->m[10]) + transformation->m[14];
	auto w = (vector->x * transformation->m[3]) + (vector->y * transformation->m[7]) + (vector->z * transformation->m[11]) + transformation->m[15];

	result->x = x / w;
	result->y = y / w;
	result->z = z / w;
};

void Babylon::Vector3::TransformCoordinatesFromFloatsToRef(float x, float y, float z, Matrix::Ptr transformation, Vector3::Ptr result) {
	auto rx = (x * transformation->m[0]) + (y * transformation->m[4]) + (z * transformation->m[8]) + transformation->m[12];
	auto ry = (x * transformation->m[1]) + (y * transformation->m[5]) + (z * transformation->m[9]) + transformation->m[13];
	auto rz = (x * transformation->m[2]) + (y * transformation->m[6]) + (z * transformation->m[10]) + transformation->m[14];
	auto rw = (x * transformation->m[3]) + (y * transformation->m[7]) + (z * transformation->m[11]) + transformation->m[15];

	result->x = rx / rw;
	result->y = ry / rw;
	result->z = rz / rw;
};

Vector3::Ptr Babylon::Vector3::TransformNormal(Vector3::Ptr vector, Matrix::Ptr transformation) {
	auto result = Vector3::Zero();
	Vector3::TransformNormalToRef(vector, transformation, result);
	return result;
};

void Babylon::Vector3::TransformNormalToRef(Vector3::Ptr vector, Matrix::Ptr transformation, Vector3::Ptr result) {
	result->x = (vector->x * transformation->m[0]) + (vector->y * transformation->m[4]) + (vector->z * transformation->m[8]);
	result->y = (vector->x * transformation->m[1]) + (vector->y * transformation->m[5]) + (vector->z * transformation->m[9]);
	result->z = (vector->x * transformation->m[2]) + (vector->y * transformation->m[6]) + (vector->z * transformation->m[10]);
};

void Babylon::Vector3::TransformNormalFromFloatsToRef(float x, float y, float z, Matrix::Ptr transformation, Vector3::Ptr result) {
	result->x = (x * transformation->m[0]) + (y * transformation->m[4]) + (z * transformation->m[8]);
	result->y = (x * transformation->m[1]) + (y * transformation->m[5]) + (z * transformation->m[9]);
	result->z = (x * transformation->m[2]) + (y * transformation->m[6]) + (z * transformation->m[10]);
};

Vector3::Ptr Babylon::Vector3::CatmullRom(Vector3::Ptr value1, Vector3::Ptr value2, Vector3::Ptr value3, Vector3::Ptr value4, float amount) {
	auto squared = amount * amount;
	auto cubed = amount * squared;

	auto x = 0.5 * ((((2.0 * value2->x) + ((-value1->x + value3->x) * amount)) +
		(((((2.0 * value1->x) - (5.0 * value2->x)) + (4.0 * value3->x)) - value4->x) * squared)) +
		((((-value1->x + (3.0 * value2->x)) - (3.0 * value3->x)) + value4->x) * cubed));

	auto y = 0.5 * ((((2.0 * value2->y) + ((-value1->y + value3->y) * amount)) +
		(((((2.0 * value1->y) - (5.0 * value2->y)) + (4.0 * value3->y)) - value4->y) * squared)) +
		((((-value1->y + (3.0 * value2->y)) - (3.0 * value3->y)) + value4->y) * cubed));

	auto z = 0.5 * ((((2.0 * value2->z) + ((-value1->z + value3->z) * amount)) +
		(((((2.0 * value1->z) - (5.0 * value2->z)) + (4.0 * value3->z)) - value4->z) * squared)) +
		((((-value1->z + (3.0 * value2->z)) - (3.0 * value3->z)) + value4->z) * cubed));

	return make_shared<Vector3>(x, y, z);
};

Vector3::Ptr Babylon::Vector3::Clamp(Vector3::Ptr value, Vector3::Ptr min, Vector3::Ptr max) {
	auto x = value->x;
	x = (x > max->x) ? max->x : x;
	x = (x < min->x) ? min->x : x;

	auto y = value->y;
	y = (y > max->y) ? max->y : y;
	y = (y < min->y) ? min->y : y;

	auto z = value->z;
	z = (z > max->z) ? max->z : z;
	z = (z < min->z) ? min->z : z;

	return make_shared<Vector3>(x, y, z);
};

Vector3::Ptr Babylon::Vector3::Hermite(Vector3::Ptr value1, Vector3::Ptr tangent1, Vector3::Ptr value2, Vector3::Ptr tangent2, float amount) {
	auto squared = amount * amount;
	auto cubed = amount * squared;
	auto part1 = ((2.0 * cubed) - (3.0 * squared)) + 1.0;
	auto part2 = (-2.0 * cubed) + (3.0 * squared);
	auto part3 = (cubed - (2.0 * squared)) + amount;
	auto part4 = cubed - squared;

	auto x = (((value1->x * part1) + (value2->x * part2)) + (tangent1->x * part3)) + (tangent2->x * part4);
	auto y = (((value1->y * part1) + (value2->y * part2)) + (tangent1->y * part3)) + (tangent2->y * part4);
	auto z = (((value1->z * part1) + (value2->z * part2)) + (tangent1->z * part3)) + (tangent2->z * part4);

	return make_shared<Vector3>(x, y, z);
};

Vector3::Ptr Babylon::Vector3::Lerp(Vector3::Ptr start, Vector3::Ptr end, float amount) {
	auto x = start->x + ((end->x - start->x) * amount);
	auto y = start->y + ((end->y - start->y) * amount);
	auto z = start->z + ((end->z - start->z) * amount);

	return make_shared<Vector3>(x, y, z);
};

float Babylon::Vector3::Dot(Vector3::Ptr left, Vector3::Ptr right) {
	return (left->x * right->x + left->y * right->y + left->z * right->z);
};

Vector3::Ptr Babylon::Vector3::Cross(Vector3::Ptr left, Vector3::Ptr right) {
	auto result = Vector3::Zero();
	Vector3::CrossToRef(left, right, result);
	return result;
};

void Babylon::Vector3::CrossToRef(Vector3::Ptr left, Vector3::Ptr right, Vector3::Ptr result) {
	result->x = left->y * right->z - left->z * right->y;
	result->y = left->z * right->x - left->x * right->z;
	result->z = left->x * right->y - left->y * right->x;
};

Vector3::Ptr Babylon::Vector3::Normalize(Vector3::Ptr vector) {
	auto result = Vector3::Zero();
	Vector3::NormalizeToRef(vector, result);
	return result;
};

void Babylon::Vector3::NormalizeToRef(Vector3::Ptr vector, Vector3::Ptr result) {
	result->copyFrom(vector);
	result->normalize();
};

Vector3::Ptr Babylon::Vector3::Project(Vector3::Ptr vector, Matrix::Ptr world, Matrix::Ptr transform, Viewport::Ptr viewport) {
	auto cw = viewport->width;
	auto ch = viewport->height;
	auto cx = viewport->x;
	auto cy = viewport->y;

	auto viewportMatrix = Matrix::FromValues(
		cw / 2.0, 0, 0, 0,
		0, -ch / 2.0, 0, 0,
		0, 0, 1, 0,
		cx + cw / 2.0, ch / 2.0 + cy, 0, 1);

	auto finalMatrix = world->multiply(transform)->multiply(viewportMatrix);

	return Vector3::TransformCoordinates(vector, finalMatrix);
};

Vector3::Ptr Babylon::Vector3::Unproject(Vector3::Ptr source, int viewportWidth, int viewportHeight, Matrix::Ptr world, Matrix::Ptr view, Matrix::Ptr projection) {
	auto matrix = world->multiply(view)->multiply(projection);
	matrix->invert();
	source->x = source->x / viewportWidth * 2 - 1;
	source->y = -(source->y / viewportHeight * 2 - 1);
	auto vector = Vector3::TransformCoordinates(source, matrix);
	auto num = source->x * matrix->m[3] + source->y * matrix->m[7] + source->z * matrix->m[11] + matrix->m[15];

	if (Tools::WithinEpsilon(num, 1.0)) {
		vector = vector->scale(1.0 / num);
	}

	return vector;
};

Vector3::Ptr Babylon::Vector3::Minimize(Vector3::Ptr left, Vector3::Ptr right) {
	auto x = (left->x < right->x) ? left->x : right->x;
	auto y = (left->y < right->y) ? left->y : right->y;
	auto z = (left->z < right->z) ? left->z : right->z;
	return make_shared<Vector3>(x, y, z);
};

Vector3::Ptr Babylon::Vector3::Maximize(Vector3::Ptr left, Vector3::Ptr right) {
	auto x = (left->x > right->x) ? left->x : right->x;
	auto y = (left->y > right->y) ? left->y : right->y;
	auto z = (left->z > right->z) ? left->z : right->z;
	return make_shared<Vector3>(x, y, z);
};

float Babylon::Vector3::Distance(Vector3::Ptr value1, Vector3::Ptr value2) {
	return sqrt(Vector3::DistanceSquared(value1, value2));
};

float Babylon::Vector3::DistanceSquared(Vector3::Ptr value1, Vector3::Ptr value2) {
	auto x = value1->x - value2->x;
	auto y = value1->y - value2->y;
	auto z = value1->z - value2->z;

	return (x * x) + (y * y) + (z * z);
};
