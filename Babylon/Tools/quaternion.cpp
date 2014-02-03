#include "quaternion.h"
#include <sstream>
#include <cmath>

using namespace Babylon;

Babylon::Quaternion::Quaternion(float initialX, float initialY, float initialZ, float initialW) {
	this->x = initialX;
	this->y = initialY;
	this->z = initialZ;
	this->w = initialW;
};

string Babylon::Quaternion::toString() {
	string r;
	stringstream ss;
	ss << "{X: " << this->x << " Y:" << this->y << " Z:" << this->z << " W:" << this->w << "}";
	r.append(ss.str());
	return r;
};

bool Babylon::Quaternion::equals(Quaternion::Ptr otherQuaternion) {
	return otherQuaternion && this->x == otherQuaternion->x && this->y == otherQuaternion->y && this->z == otherQuaternion->z && this->w == otherQuaternion->w;
};

Quaternion::Ptr Babylon::Quaternion::clone() {
	return make_shared<Quaternion>(this->x, this->y, this->z, this->w);
};

void Babylon::Quaternion::copyFrom(Quaternion::Ptr other) {
	this->x = other->x;
	this->y = other->y;
	this->z = other->z;
	this->w = other->w;
};

Quaternion::Ptr Babylon::Quaternion::add(Quaternion::Ptr other) {
	return make_shared<Quaternion>(this->x + other->x, this->y + other->y, this->z + other->z, this->w + other->w);
};

Quaternion::Ptr Babylon::Quaternion::subtract(Quaternion::Ptr other) {
	return make_shared<Quaternion>(this->x - other->x, this->y - other->y, this->z - other->z, this->w - other->w);
};

Quaternion::Ptr Babylon::Quaternion::scale(float value) {
	return make_shared<Quaternion>(this->x * value, this->y * value, this->z * value, this->w * value);
};

Quaternion::Ptr Babylon::Quaternion::multiply(Quaternion::Ptr q1) {
	auto result = make_shared<Quaternion>(0, 0, 0, 1.0);
	this->multiplyToRef(q1, result);
	return result;
};

void Babylon::Quaternion::multiplyToRef(Quaternion::Ptr q1, Quaternion::Ptr result) {
	result->x = this->x * q1->w + this->y * q1->z - this->z * q1->y + this->w * q1->x;
	result->y = -this->x * q1->z + this->y * q1->w + this->z * q1->x + this->w * q1->y;
	result->z = this->x * q1->y - this->y * q1->x + this->z * q1->w + this->w * q1->z;
	result->w = -this->x * q1->x - this->y * q1->y - this->z * q1->z + this->w * q1->w;
};

float Babylon::Quaternion::length() {
	return sqrt((this->x * this->x) + (this->y * this->y) + (this->z * this->z) + (this->w * this->w));
};

void Babylon::Quaternion::normalize() {
	auto length = 1.0 / this->length();
	this->x *= length;
	this->y *= length;
	this->z *= length;
	this->w *= length;
};

Vector3::Ptr Babylon::Quaternion::toEulerAngles() {
	auto qx = this->x;
	auto qy = this->y;
	auto qz = this->z;
	auto qw = this->w;

	auto sqx = qx * qx;
	auto sqy = qy * qy;
	auto sqz = qz * qz;

	auto yaw = atan2(2.0 * (qy * qw - qx * qz), 1.0 - 2.0 * (sqy + sqz));
	auto pitch = asin(2.0 * (qx * qy + qz * qw));
	auto roll = atan2(2.0 * (qx * qw - qy * qz), 1.0 - 2.0 * (sqx + sqz));

	auto gimbaLockTest = qx * qy + qz * qw;
	if (gimbaLockTest > 0.499) {
		yaw = 2.0 * atan2(qx, qw);
		roll = 0;
	} else if (gimbaLockTest < -0.499) {
		yaw = -2.0 * atan2(qx, qw);
		roll = 0;
	}

	return make_shared<Vector3>(pitch, yaw, roll);
};

void Babylon::Quaternion::toRotationMatrix(Matrix::Ptr result) {
	auto xx = this->x * this->x;
	auto yy = this->y * this->y;
	auto zz = this->z * this->z;
	auto xy = this->x * this->y;
	auto zw = this->z * this->w;
	auto zx = this->z * this->x;
	auto yw = this->y * this->w;
	auto yz = this->y * this->z;
	auto xw = this->x * this->w;

	result->m[0] = 1.0 - (2.0 * (yy + zz));
	result->m[1] = 2.0 * (xy + zw);
	result->m[2] = 2.0 * (zx - yw);
	result->m[3] = 0;
	result->m[4] = 2.0 * (xy - zw);
	result->m[5] = 1.0 - (2.0 * (zz + xx));
	result->m[6] = 2.0 * (yz + xw);
	result->m[7] = 0;
	result->m[8] = 2.0 * (zx + yw);
	result->m[9] = 2.0 * (yz - xw);
	result->m[10] = 1.0 - (2.0 * (yy + xx));
	result->m[11] = 0;
	result->m[12] = 0;
	result->m[13] = 0;
	result->m[14] = 0;
	result->m[15] = 1.0;
};

// Statics
Quaternion::Ptr Babylon::Quaternion::FromArray(Float32Array array, int offset) {
	if (!offset) {
		offset = 0;
	}

	return make_shared<Quaternion>(array[offset], array[offset + 1], array[offset + 2], array[offset + 3]);
};

Quaternion::Ptr Babylon::Quaternion::RotationYawPitchRoll(float yaw, float pitch, float roll) {
	auto result = make_shared<Quaternion>(0., 0., 0., 0.);
	Quaternion::RotationYawPitchRollToRef(yaw, pitch, roll, result);
	return result;
};

void Babylon::Quaternion::RotationYawPitchRollToRef(float yaw, float pitch, float roll, Quaternion::Ptr result) {
	auto halfRoll = roll * 0.5;
	auto halfPitch = pitch * 0.5;
	auto halfYaw = yaw * 0.5;

	auto sinRoll = sin(halfRoll);
	auto cosRoll = cos(halfRoll);
	auto sinPitch = sin(halfPitch);
	auto cosPitch = cos(halfPitch);
	auto sinYaw = sin(halfYaw);
	auto cosYaw = cos(halfYaw);

	result->x = (cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll);
	result->y = (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll);
	result->z = (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll);
	result->w = (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll);
};

Quaternion::Ptr Babylon::Quaternion::Slerp(Quaternion::Ptr left, Quaternion::Ptr right, float amount) {
	auto num2 = 0.;
	auto num3 = 0.;
	auto num = amount;
	auto num4 = (((left->x * right->x) + (left->y * right->y)) + (left->z * right->z)) + (left->w * right->w);
	auto flag = false;

	if (num4 < 0) {
		flag = true;
		num4 = -num4;
	}

	if (num4 > 0.999999) {
		num3 = 1 - num;
		num2 = flag ? -num : num;
	}
	else {
		auto num5 = acos(num4);
		auto num6 = (1.0 / sin(num5));
		num3 = (sin((1.0 - num) * num5)) * num6;
		num2 = flag ? ((-sin(num * num5)) * num6) : ((sin(num * num5)) * num6);
	}

	float x = (num3 * left->x) + (num2 * right->x);
	float y = (num3 * left->y) + (num2 * right->y);
	float z = (num3 * left->z) + (num2 * right->z);
	float w = (num3 * left->w) + (num2 * right->w);
	return make_shared<Quaternion>(x, y, z, w);
};
