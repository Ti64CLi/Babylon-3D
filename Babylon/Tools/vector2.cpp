#include "Vector2.h"
#include <sstream>
#include "matrix.h"
#include "tools.h"

using namespace Babylon;

Babylon::Vector2::Vector2(float initialX, float initialY) {
	this->x = initialX;
	this->y = initialY;
};

string Babylon::Vector2::toString() {
	string r;
	stringstream ss;
	ss << "{X: " << this->x << " Y:" << this->y << "}";
	r.append(ss.str());
	return r;
};

// Operators
Float32Array Babylon::Vector2::asArray() {
	Float32Array result;
	result.push_back(0);
	result.push_back(0);
	this->toArray(result, 0);
	return result;
};

void Babylon::Vector2::toArray(Float32Array& array, int index) {
	array[index] = this->x;
	array[index + 1] = this->y;
};

void Babylon::Vector2::addInPlace(Vector2::Ptr otherVector) {
	this->x += otherVector->x;
	this->y += otherVector->y;
};

Vector2::Ptr Babylon::Vector2::add(Vector2::Ptr otherVector) {
	return make_shared<Vector2>(this->x + otherVector->x, this->y + otherVector->y);
};

void Babylon::Vector2::addToRef(Vector2::Ptr otherVector, Vector2::Ptr result) {
	result->x = this->x + otherVector->x;
	result->y = this->y + otherVector->y;
};

void Babylon::Vector2::subtractInPlace(Vector2::Ptr otherVector) {
	this->x -= otherVector->x;
	this->y -= otherVector->y;
};

Vector2::Ptr Babylon::Vector2::subtract(Vector2::Ptr otherVector) {
	return make_shared<Vector2>(this->x - otherVector->x, this->y - otherVector->y);
};

void Babylon::Vector2::subtractToRef(Vector2::Ptr otherVector, Vector2::Ptr result) {
	result->x = this->x - otherVector->x;
	result->y = this->y - otherVector->y;
};

Vector2::Ptr Babylon::Vector2::subtractFromFloats(float x, float y) {
	return make_shared<Vector2>(this->x - x, this->y - y);
};

void Babylon::Vector2::subtractFromFloatsToRef(float x, float y, Vector2::Ptr result) {
	result->x = this->x - x;
	result->y = this->y - y;
};

Vector2::Ptr Babylon::Vector2::negate() {
	return make_shared<Vector2>(-this->x, -this->y);
};

void Babylon::Vector2::scaleInPlace(float scale) {
	this->x *= scale;
	this->y *= scale;
};

Vector2::Ptr Babylon::Vector2::scale(float scale) {
	return make_shared<Vector2>(this->x * scale, this->y * scale);
};

void Babylon::Vector2::scaleToRef(float scale, Vector2::Ptr result) {
	result->x = this->x * scale;
	result->y = this->y * scale;
};

bool Babylon::Vector2::equals(Vector2::Ptr otherVector) {
	return otherVector && this->x == otherVector->x && this->y == otherVector->y;
};

bool Babylon::Vector2::equalsToFloats(float x, float y) {
	return this->x == x && this->y == y;
};

void Babylon::Vector2::multiplyInPlace(Vector2::Ptr otherVector) {
	this->x *= otherVector->x;
	this->y *= otherVector->y;
};

Vector2::Ptr Babylon::Vector2::multiply(Vector2::Ptr otherVector) {
	return make_shared<Vector2>(this->x * otherVector->x, this->y * otherVector->y);
};

void Babylon::Vector2::multiplyToRef(Vector2::Ptr otherVector, Vector2::Ptr result) {
	result->x = this->x * otherVector->x;
	result->y = this->y * otherVector->y;
};

Vector2::Ptr Babylon::Vector2::multiplyByFloats(float x, float y) {
	return make_shared<Vector2>(this->x * x, this->y * y);
};

Vector2::Ptr Babylon::Vector2::divide(Vector2::Ptr otherVector) {
	return make_shared<Vector2>(this->x / otherVector->x, this->y / otherVector->y);
};

void Babylon::Vector2::divideToRef(Vector2::Ptr otherVector, Vector2::Ptr result) {
	result->x = this->x / otherVector->x;
	result->y = this->y / otherVector->y;
};

// Properties
float Babylon::Vector2::length() {
	return sqrt(this->x * this->x + this->y * this->y);
};

float Babylon::Vector2::lengthSquared() {
	return (this->x * this->x + this->y * this->y);
};

// Methods
void Babylon::Vector2::normalize() {
	auto len = this->length();

	if (len == 0)
		return;

	auto num = 1.0 / len;

	this->x *= num;
	this->y *= num;
};

Vector2::Ptr Babylon::Vector2::clone() {
	return make_shared<Vector2>(this->x, this->y);
};

void Babylon::Vector2::copyFrom(Vector2::Ptr source) {
	this->x = source->x;
	this->y = source->y;
};

void Babylon::Vector2::copyFromFloats(float x, float y) {
	this->x = x;
	this->y = y;
};

// Statics
Vector2::Ptr Babylon::Vector2::FromArray(Float32Array array, int offset) {
	if (!offset) {
		offset = 0;
	}

	return make_shared<Vector2>(array[offset], array[offset + 1]);
};

void Babylon::Vector2::FromArrayToRef(Float32Array array, int offset, Vector2::Ptr result) {
	if (!offset) {
		offset = 0;
	}

	result->x = array[offset];
	result->y = array[offset + 1];
};

void Babylon::Vector2::FromFloatsToRef(float x, float y, Vector2::Ptr result) {
	result->x = x;
	result->y = y;
};

Vector2::Ptr Babylon::Vector2::Zero() {
	return make_shared<Vector2>(0, 0);
};

Vector2::Ptr Babylon::Vector2::CatmullRom(Vector2::Ptr value1, Vector2::Ptr value2, Vector2::Ptr value3, Vector2::Ptr value4, float amount) {
	auto squared = amount * amount;
	auto cubed = amount * squared;

	auto x = 0.5 * ((((2.0 * value2->x) + ((-value1->x + value3->x) * amount)) +
		(((((2.0 * value1->x) - (5.0 * value2->x)) + (4.0 * value3->x)) - value4->x) * squared)) +
		((((-value1->x + (3.0 * value2->x)) - (3.0 * value3->x)) + value4->x) * cubed));

	auto y = 0.5 * ((((2.0 * value2->y) + ((-value1->y + value3->y) * amount)) +
		(((((2.0 * value1->y) - (5.0 * value2->y)) + (4.0 * value3->y)) - value4->y) * squared)) +
		((((-value1->y + (3.0 * value2->y)) - (3.0 * value3->y)) + value4->y) * cubed));

	return make_shared<Vector2>(x, y);
};

Vector2::Ptr Babylon::Vector2::Clamp(Vector2::Ptr value, Vector2::Ptr min, Vector2::Ptr max) {
	auto x = value->x;
	x = (x > max->x) ? max->x : x;
	x = (x < min->x) ? min->x : x;

	auto y = value->y;
	y = (y > max->y) ? max->y : y;
	y = (y < min->y) ? min->y : y;

	return make_shared<Vector2>(x, y);
};

Vector2::Ptr Babylon::Vector2::Hermite(Vector2::Ptr value1, Vector2::Ptr tangent1, Vector2::Ptr value2, Vector2::Ptr tangent2, float amount) {
	auto squared = amount * amount;
	auto cubed = amount * squared;
	auto part1 = ((2.0 * cubed) - (3.0 * squared)) + 1.0;
	auto part2 = (-2.0 * cubed) + (3.0 * squared);
	auto part3 = (cubed - (2.0 * squared)) + amount;
	auto part4 = cubed - squared;

	auto x = (((value1->x * part1) + (value2->x * part2)) + (tangent1->x * part3)) + (tangent2->x * part4);
	auto y = (((value1->y * part1) + (value2->y * part2)) + (tangent1->y * part3)) + (tangent2->y * part4);

	return make_shared<Vector2>(x, y);
};

Vector2::Ptr Babylon::Vector2::Lerp(Vector2::Ptr start, Vector2::Ptr end, float amount) {
	auto x = start->x + ((end->x - start->x) * amount);
	auto y = start->y + ((end->y - start->y) * amount);

	return make_shared<Vector2>(x, y);
};

float Babylon::Vector2::Dot(Vector2::Ptr left, Vector2::Ptr right) {
	return (left->x * right->x + left->y * right->y);
};

Vector2::Ptr Babylon::Vector2::Normalize(Vector2::Ptr vector) {
	auto result = Vector2::Zero();
	Vector2::NormalizeToRef(vector, result);
	return result;
};

void Babylon::Vector2::NormalizeToRef(Vector2::Ptr vector, Vector2::Ptr result) {
	result->copyFrom(vector);
	result->normalize();
};

Vector2::Ptr Babylon::Vector2::Minimize(Vector2::Ptr left, Vector2::Ptr right) {
	auto x = (left->x < right->x) ? left->x : right->x;
	auto y = (left->y < right->y) ? left->y : right->y;
	return make_shared<Vector2>(x, y);
};

Vector2::Ptr Babylon::Vector2::Maximize(Vector2::Ptr left, Vector2::Ptr right) {
	auto x = (left->x > right->x) ? left->x : right->x;
	auto y = (left->y > right->y) ? left->y : right->y;
	return make_shared<Vector2>(x, y);
};

Vector2::Ptr Babylon::Vector2::Transform(Vector2::Ptr vector, MatrixPtr transformation) {
	auto x = (vector->x * transformation->m[0]) + (vector->y * transformation->m[4]);
	auto y = (vector->x * transformation->m[1]) + (vector->y * transformation->m[5]);

	return make_shared<Vector2>(x, y);
};

float Babylon::Vector2::Distance(Vector2::Ptr value1, Vector2::Ptr value2) {
	return sqrt(Vector2::DistanceSquared(value1, value2));
};

float Babylon::Vector2::DistanceSquared(Vector2::Ptr value1, Vector2::Ptr value2) {
	auto x = value1->x - value2->x;
	auto y = value1->y - value2->y;

	return (x * x) + (y * y);
};
