#include "matrix.h"
#include <cmath>
#include "quaternion.h"
#include "plane.h"

using namespace Babylon;

Babylon::Matrix::Matrix() {
	m.reserve(16);
	for (auto i = 0; i < 16; i++)
	{
		m.push_back(0.0f);
	}
};

// Properties
bool Babylon::Matrix::isIdentity() {
	if (this->m[0] != 1.0 || this->m[5] != 1.0 || this->m[10] != 1.0 || this->m[15] != 1.0)
		return false;

	if (this->m[1] != 0.0 || this->m[2] != 0.0 || this->m[3] != 0.0 ||
		this->m[4] != 0.0 || this->m[6] != 0.0 || this->m[7] != 0.0 ||
		this->m[8] != 0.0 || this->m[9] != 0.0 || this->m[11] != 0.0 ||
		this->m[12] != 0.0 || this->m[13] != 0.0 || this->m[14] != 0.0)
		return false;

	return true;
};

float Babylon::Matrix::determinant() {
	auto temp1 = (this->m[10] * this->m[15]) - (this->m[11] * this->m[14]);
	auto temp2 = (this->m[9] * this->m[15]) - (this->m[11] * this->m[13]);
	auto temp3 = (this->m[9] * this->m[14]) - (this->m[10] * this->m[13]);
	auto temp4 = (this->m[8] * this->m[15]) - (this->m[11] * this->m[12]);
	auto temp5 = (this->m[8] * this->m[14]) - (this->m[10] * this->m[12]);
	auto temp6 = (this->m[8] * this->m[13]) - (this->m[9] * this->m[12]);

	return ((((this->m[0] * (((this->m[5] * temp1) - (this->m[6] * temp2)) + (this->m[7] * temp3))) - (this->m[1] * (((this->m[4] * temp1) -
		(this->m[6] * temp4)) + (this->m[7] * temp5)))) + (this->m[2] * (((this->m[4] * temp2) - (this->m[5] * temp4)) + (this->m[7] * temp6)))) -
		(this->m[3] * (((this->m[4] * temp3) - (this->m[5] * temp5)) + (this->m[6] * temp6))));
};

// Methods
Float32Array Babylon::Matrix::toArray() {
	return this->m;
};

void Babylon::Matrix::invert() {
	this->invertToRef(shared_from_this());
};

void Babylon::Matrix::invertToRef(Matrix::Ptr other) {
	auto l1 = this->m[0];
	auto l2 = this->m[1];
	auto l3 = this->m[2];
	auto l4 = this->m[3];
	auto l5 = this->m[4];
	auto l6 = this->m[5];
	auto l7 = this->m[6];
	auto l8 = this->m[7];
	auto l9 = this->m[8];
	auto l10 = this->m[9];
	auto l11 = this->m[10];
	auto l12 = this->m[11];
	auto l13 = this->m[12];
	auto l14 = this->m[13];
	auto l15 = this->m[14];
	auto l16 = this->m[15];
	auto l17 = (l11 * l16) - (l12 * l15);
	auto l18 = (l10 * l16) - (l12 * l14);
	auto l19 = (l10 * l15) - (l11 * l14);
	auto l20 = (l9 * l16) - (l12 * l13);
	auto l21 = (l9 * l15) - (l11 * l13);
	auto l22 = (l9 * l14) - (l10 * l13);
	auto l23 = ((l6 * l17) - (l7 * l18)) + (l8 * l19);
	auto l24 = -(((l5 * l17) - (l7 * l20)) + (l8 * l21));
	auto l25 = ((l5 * l18) - (l6 * l20)) + (l8 * l22);
	auto l26 = -(((l5 * l19) - (l6 * l21)) + (l7 * l22));
	auto l27 = 1.0 / ((((l1 * l23) + (l2 * l24)) + (l3 * l25)) + (l4 * l26));
	auto l28 = (l7 * l16) - (l8 * l15);
	auto l29 = (l6 * l16) - (l8 * l14);
	auto l30 = (l6 * l15) - (l7 * l14);
	auto l31 = (l5 * l16) - (l8 * l13);
	auto l32 = (l5 * l15) - (l7 * l13);
	auto l33 = (l5 * l14) - (l6 * l13);
	auto l34 = (l7 * l12) - (l8 * l11);
	auto l35 = (l6 * l12) - (l8 * l10);
	auto l36 = (l6 * l11) - (l7 * l10);
	auto l37 = (l5 * l12) - (l8 * l9);
	auto l38 = (l5 * l11) - (l7 * l9);
	auto l39 = (l5 * l10) - (l6 * l9);

	other->m[0] = l23 * l27;
	other->m[4] = l24 * l27;
	other->m[8] = l25 * l27;
	other->m[12] = l26 * l27;
	other->m[1] = -(((l2 * l17) - (l3 * l18)) + (l4 * l19)) * l27;
	other->m[5] = (((l1 * l17) - (l3 * l20)) + (l4 * l21)) * l27;
	other->m[9] = -(((l1 * l18) - (l2 * l20)) + (l4 * l22)) * l27;
	other->m[13] = (((l1 * l19) - (l2 * l21)) + (l3 * l22)) * l27;
	other->m[2] = (((l2 * l28) - (l3 * l29)) + (l4 * l30)) * l27;
	other->m[6] = -(((l1 * l28) - (l3 * l31)) + (l4 * l32)) * l27;
	other->m[10] = (((l1 * l29) - (l2 * l31)) + (l4 * l33)) * l27;
	other->m[14] = -(((l1 * l30) - (l2 * l32)) + (l3 * l33)) * l27;
	other->m[3] = -(((l2 * l34) - (l3 * l35)) + (l4 * l36)) * l27;
	other->m[7] = (((l1 * l34) - (l3 * l37)) + (l4 * l38)) * l27;
	other->m[11] = -(((l1 * l35) - (l2 * l37)) + (l4 * l39)) * l27;
	other->m[15] = (((l1 * l36) - (l2 * l38)) + (l3 * l39)) * l27;
};

void Babylon::Matrix::setTranslation(Vector3::Ptr vector3) {
	this->m[12] = vector3->x;
	this->m[13] = vector3->y;
	this->m[14] = vector3->z;
};

Matrix::Ptr Babylon::Matrix::multiply(Matrix::Ptr other) {
	auto result = make_shared<Matrix>();
	this->multiplyToRef(other, result);
	return result;
};

void Babylon::Matrix::copyFrom(Matrix::Ptr other) {
	for (auto index = 0; index < 16; index++) {
		this->m[index] = other->m[index];
	}
};

void Babylon::Matrix::multiplyToRef(Matrix::Ptr other, Matrix::Ptr result) {
	this->multiplyToArray(other, result->m, 0);
};

void Babylon::Matrix::multiplyToArray(Matrix::Ptr other, Float32Array& result, int offset) {
	result[offset] = this->m[0] * other->m[0] + this->m[1] * other->m[4] + this->m[2] * other->m[8] + this->m[3] * other->m[12];
	result[offset + 1] = this->m[0] * other->m[1] + this->m[1] * other->m[5] + this->m[2] * other->m[9] + this->m[3] * other->m[13];
	result[offset + 2] = this->m[0] * other->m[2] + this->m[1] * other->m[6] + this->m[2] * other->m[10] + this->m[3] * other->m[14];
	result[offset + 3] = this->m[0] * other->m[3] + this->m[1] * other->m[7] + this->m[2] * other->m[11] + this->m[3] * other->m[15];

	result[offset + 4] = this->m[4] * other->m[0] + this->m[5] * other->m[4] + this->m[6] * other->m[8] + this->m[7] * other->m[12];
	result[offset + 5] = this->m[4] * other->m[1] + this->m[5] * other->m[5] + this->m[6] * other->m[9] + this->m[7] * other->m[13];
	result[offset + 6] = this->m[4] * other->m[2] + this->m[5] * other->m[6] + this->m[6] * other->m[10] + this->m[7] * other->m[14];
	result[offset + 7] = this->m[4] * other->m[3] + this->m[5] * other->m[7] + this->m[6] * other->m[11] + this->m[7] * other->m[15];

	result[offset + 8] = this->m[8] * other->m[0] + this->m[9] * other->m[4] + this->m[10] * other->m[8] + this->m[11] * other->m[12];
	result[offset + 9] = this->m[8] * other->m[1] + this->m[9] * other->m[5] + this->m[10] * other->m[9] + this->m[11] * other->m[13];
	result[offset + 10] = this->m[8] * other->m[2] + this->m[9] * other->m[6] + this->m[10] * other->m[10] + this->m[11] * other->m[14];
	result[offset + 11] = this->m[8] * other->m[3] + this->m[9] * other->m[7] + this->m[10] * other->m[11] + this->m[11] * other->m[15];

	result[offset + 12] = this->m[12] * other->m[0] + this->m[13] * other->m[4] + this->m[14] * other->m[8] + this->m[15] * other->m[12];
	result[offset + 13] = this->m[12] * other->m[1] + this->m[13] * other->m[5] + this->m[14] * other->m[9] + this->m[15] * other->m[13];
	result[offset + 14] = this->m[12] * other->m[2] + this->m[13] * other->m[6] + this->m[14] * other->m[10] + this->m[15] * other->m[14];
	result[offset + 15] = this->m[12] * other->m[3] + this->m[13] * other->m[7] + this->m[14] * other->m[11] + this->m[15] * other->m[15];
};

bool Babylon::Matrix::equals(Matrix::Ptr value) {
	return value && (this->m[0] == value->m[0] && this->m[1] == value->m[1] && this->m[2] == value->m[2] && this->m[3] == value->m[3] &&
		this->m[4] == value->m[4] && this->m[5] == value->m[5] && this->m[6] == value->m[6] && this->m[7] == value->m[7] &&
		this->m[8] == value->m[8] && this->m[9] == value->m[9] && this->m[10] == value->m[10] && this->m[11] == value->m[11] &&
		this->m[12] == value->m[12] && this->m[13] == value->m[13] && this->m[14] == value->m[14] && this->m[15] == value->m[15]);
};

Matrix::Ptr Babylon::Matrix::clone() {
	return Matrix::FromValues(this->m[0], this->m[1], this->m[2], this->m[3],
		this->m[4], this->m[5], this->m[6], this->m[7],
		this->m[8], this->m[9], this->m[10], this->m[11],
		this->m[12], this->m[13], this->m[14], this->m[15]);
};

// Statics
Matrix::Ptr Babylon::Matrix::FromArray(Float32Array array, int offset) {
	auto result = make_shared<Matrix>();
	Matrix::FromArrayToRef(array, offset, result);
	return result;
};

void Babylon::Matrix::FromArrayToRef(Float32Array array, int offset, Matrix::Ptr result) {
	if (!offset) {
		offset = 0;
	}

	for (auto index = 0; index < 16; index++) {
		result->m[index] = array[index + offset];
	}
};

void Babylon::Matrix::FromValuesToRef(float initialM11, float initialM12, float initialM13, float initialM14,
									  float initialM21, float initialM22, float initialM23, float initialM24,
									  float initialM31, float initialM32, float initialM33, float initialM34,
									  float initialM41, float initialM42, float initialM43, float initialM44, Matrix::Ptr result) {

										  result->m[0] = initialM11;
										  result->m[1] = initialM12;
										  result->m[2] = initialM13;
										  result->m[3] = initialM14;
										  result->m[4] = initialM21;
										  result->m[5] = initialM22;
										  result->m[6] = initialM23;
										  result->m[7] = initialM24;
										  result->m[8] = initialM31;
										  result->m[9] = initialM32;
										  result->m[10] = initialM33;
										  result->m[11] = initialM34;
										  result->m[12] = initialM41;
										  result->m[13] = initialM42;
										  result->m[14] = initialM43;
										  result->m[15] = initialM44;
};

Matrix::Ptr Babylon::Matrix::FromValues(float initialM11, float initialM12, float initialM13, float initialM14,
										float initialM21, float initialM22, float initialM23, float initialM24,
										float initialM31, float initialM32, float initialM33, float initialM34,
										float initialM41, float initialM42, float initialM43, float initialM44) {

											auto result = make_shared<Matrix>();

											result->m[0] = initialM11;
											result->m[1] = initialM12;
											result->m[2] = initialM13;
											result->m[3] = initialM14;
											result->m[4] = initialM21;
											result->m[5] = initialM22;
											result->m[6] = initialM23;
											result->m[7] = initialM24;
											result->m[8] = initialM31;
											result->m[9] = initialM32;
											result->m[10] = initialM33;
											result->m[11] = initialM34;
											result->m[12] = initialM41;
											result->m[13] = initialM42;
											result->m[14] = initialM43;
											result->m[15] = initialM44;

											return result;
};

Matrix::Ptr Babylon::Matrix::Identity() {
	return Matrix::FromValues(1.0, 0, 0, 0,
		0, 1.0, 0, 0,
		0, 0, 1.0, 0,
		0, 0, 0, 1.0);
};

void Babylon::Matrix::IdentityToRef(Matrix::Ptr result) {
	Matrix::FromValuesToRef(1.0, 0, 0, 0,
		0, 1.0, 0, 0,
		0, 0, 1.0, 0,
		0, 0, 0, 1.0, result);
};

Matrix::Ptr Babylon::Matrix::Zero() {
	return Matrix::FromValues(0, 0, 0, 0,
		0, 0, 0, 0,
		0, 0, 0, 0,
		0, 0, 0, 0);
};

Matrix::Ptr Babylon::Matrix::RotationX(float angle) {
	auto result = make_shared<Matrix>();
	Matrix::RotationXToRef(angle, result);
	return result;
};

void Babylon::Matrix::RotationXToRef(float angle, Matrix::Ptr result) {
	auto s = sin(angle);
	auto c = cos(angle);

	result->m[0] = 1.0;
	result->m[15] = 1.0;

	result->m[5] = c;
	result->m[10] = c;
	result->m[9] = -s;
	result->m[6] = s;

	result->m[1] = 0;
	result->m[2] = 0;
	result->m[3] = 0;
	result->m[4] = 0;
	result->m[7] = 0;
	result->m[8] = 0;
	result->m[11] = 0;
	result->m[12] = 0;
	result->m[13] = 0;
	result->m[14] = 0;
};

Matrix::Ptr Babylon::Matrix::RotationY(float angle) {
	auto result = make_shared<Matrix>();
	Matrix::RotationYToRef(angle, result);
	return result;
};

void Babylon::Matrix::RotationYToRef(float angle, Matrix::Ptr result) {
	auto s = sin(angle);
	auto c = cos(angle);

	result->m[5] = 1.0;
	result->m[15] = 1.0;

	result->m[0] = c;
	result->m[2] = -s;
	result->m[8] = s;
	result->m[10] = c;

	result->m[1] = 0;
	result->m[3] = 0;
	result->m[4] = 0;
	result->m[6] = 0;
	result->m[7] = 0;
	result->m[9] = 0;
	result->m[11] = 0;
	result->m[12] = 0;
	result->m[13] = 0;
	result->m[14] = 0;
};

Matrix::Ptr Babylon::Matrix::RotationZ(float angle) {
	auto result = make_shared<Matrix>();
	Matrix::RotationZToRef(angle, result);
	return result;
};

void Babylon::Matrix::RotationZToRef(float angle, Matrix::Ptr result) {
	auto s = sin(angle);
	auto c = cos(angle);

	result->m[10] = 1.0;
	result->m[15] = 1.0;

	result->m[0] = c;
	result->m[1] = s;
	result->m[4] = -s;
	result->m[5] = c;

	result->m[2] = 0;
	result->m[3] = 0;
	result->m[6] = 0;
	result->m[7] = 0;
	result->m[8] = 0;
	result->m[9] = 0;
	result->m[11] = 0;
	result->m[12] = 0;
	result->m[13] = 0;
	result->m[14] = 0;
};

Matrix::Ptr Babylon::Matrix::RotationAxis(Vector3::Ptr axis, float angle) {
	auto s = sin(-angle);
	auto c = cos(-angle);
	auto c1 = 1 - c;

	axis->normalize();
	auto result = Matrix::Zero();

	result->m[0] = (axis->x * axis->x) * c1 + c;
	result->m[1] = (axis->x * axis->y) * c1 - (axis->z * s);
	result->m[2] = (axis->x * axis->z) * c1 + (axis->y * s);
	result->m[3] = 0.0;

	result->m[4] = (axis->y * axis->x) * c1 + (axis->z * s);
	result->m[5] = (axis->y * axis->y) * c1 + c;
	result->m[6] = (axis->y * axis->z) * c1 - (axis->x * s);
	result->m[7] = 0.0;

	result->m[8] = (axis->z * axis->x) * c1 - (axis->y * s);
	result->m[9] = (axis->z * axis->y) * c1 + (axis->x * s);
	result->m[10] = (axis->z * axis->z) * c1 + c;
	result->m[11] = 0.0;

	result->m[15] = 1.0;

	return result;
};

Matrix::Ptr Babylon::Matrix::RotationYawPitchRoll(float yaw, float pitch, float roll) {
	auto result = make_shared<Matrix>();
	Matrix::RotationYawPitchRollToRef(yaw, pitch, roll, result);
	return result;
};

void Babylon::Matrix::RotationYawPitchRollToRef(float yaw, float pitch, float roll, Matrix::Ptr result) {
	auto tempQuaternion = make_shared<Quaternion>(0., 0., 0., 0.);
	Quaternion::RotationYawPitchRollToRef(yaw, pitch, roll, tempQuaternion);
	tempQuaternion->toRotationMatrix(result);
};

Matrix::Ptr Babylon::Matrix::Scaling(float x, float y, float z) {
	auto result = Matrix::Zero();
	Matrix::ScalingToRef(x, y, z, result);
	return result;
};

void Babylon::Matrix::ScalingToRef(float x, float y, float z, Matrix::Ptr result) {
	result->m[0] = x;
	result->m[1] = 0;
	result->m[2] = 0;
	result->m[3] = 0;
	result->m[4] = 0;
	result->m[5] = y;
	result->m[6] = 0;
	result->m[7] = 0;
	result->m[8] = 0;
	result->m[9] = 0;
	result->m[10] = z;
	result->m[11] = 0;
	result->m[12] = 0;
	result->m[13] = 0;
	result->m[14] = 0;
	result->m[15] = 1.0;
};

Matrix::Ptr Babylon::Matrix::Translation(float x, float y, float z) {
	auto result = Matrix::Identity();
	Matrix::TranslationToRef(x, y, z, result);
	return result;
};

void Babylon::Matrix::TranslationToRef(float x, float y, float z, Matrix::Ptr result) {
	Matrix::FromValuesToRef(1.0, 0, 0, 0,
		0, 1.0, 0, 0,
		0, 0, 1.0, 0,
		x, y, z, 1.0, result);
};

Matrix::Ptr Babylon::Matrix::LookAtLH(Vector3::Ptr eye, Vector3::Ptr target, Vector3::Ptr up) {
	auto result = Matrix::Zero();
	Matrix::LookAtLHToRef(eye, target, up, result);
	return result;
};

Vector3::Ptr Babylon::Matrix::xAxis = Vector3::Zero();
Vector3::Ptr Babylon::Matrix::yAxis = Vector3::Zero();
Vector3::Ptr Babylon::Matrix::zAxis = Vector3::Zero();
void Babylon::Matrix::LookAtLHToRef(Vector3::Ptr eye, Vector3::Ptr target, Vector3::Ptr up, Matrix::Ptr result) {
	// Z axis
	target->subtractToRef(eye, zAxis);
	zAxis->normalize();

	// X axis
	Vector3::CrossToRef(up, zAxis, xAxis);
	xAxis->normalize();

	// Y axis
	Vector3::CrossToRef(zAxis, xAxis, yAxis);
	yAxis->normalize();

	// Eye angles
	auto ex = -Vector3::Dot(xAxis, eye);
	auto ey = -Vector3::Dot(yAxis, eye);
	auto ez = -Vector3::Dot(zAxis, eye);

	Matrix::FromValuesToRef(xAxis->x, yAxis->x, zAxis->x, 0,
		xAxis->y, yAxis->y, zAxis->y, 0,
		xAxis->z, yAxis->z, zAxis->z, 0,
		ex, ey, ez, 1, result);
};

Matrix::Ptr Babylon::Matrix::OrthoLH(float width, float height, float znear, float zfar) {
	auto hw = 2.0 / width;
	auto hh = 2.0 / height;
	auto id = 1.0 / (zfar - znear);
	auto nid = znear / (znear - zfar);

	return Matrix::FromValues(hw, 0, 0, 0,
		0, hh, 0, 0,
		0, 0, id, 0,
		0, 0, nid, 1);
};

Matrix::Ptr Babylon::Matrix::OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar) {
	auto matrix = Matrix::Zero();
	Matrix::OrthoOffCenterLHToRef(left, right, bottom, top, znear, zfar, matrix);
	return matrix;
};

void Babylon::Matrix::OrthoOffCenterLHToRef(float left, float right, float bottom, float top, float znear, float zfar, Matrix::Ptr result) {
	result->m[0] = 2.0 / (right - left);
	result->m[1] = result->m[2] = result->m[3] = 0;
	result->m[5] = 2.0 / (top - bottom);
	result->m[4] = result->m[6] = result->m[7] = 0;
	result->m[10] = -1.0 / (znear - zfar);
	result->m[8] = result->m[9] = result->m[11] = 0;
	result->m[12] = (left + right) / (left - right);
	result->m[13] = (top + bottom) / (bottom - top);
	result->m[14] = znear / (znear - zfar);
	result->m[15] = 1.0;
};

Matrix::Ptr Babylon::Matrix::PerspectiveLH(float width, float height, float znear, float zfar) {
	auto matrix = Matrix::Zero();

	matrix->m[0] = (2.0 * znear) / width;
	matrix->m[1] = matrix->m[2] = matrix->m[3] = 0.0;
	matrix->m[5] = (2.0 * znear) / height;
	matrix->m[4] = matrix->m[6] = matrix->m[7] = 0.0;
	matrix->m[10] = -zfar / (znear - zfar);
	matrix->m[8] = matrix->m[9] = 0.0;
	matrix->m[11] = 1.0;
	matrix->m[12] = matrix->m[13] = matrix->m[15] = 0.0;
	matrix->m[14] = (znear * zfar) / (znear - zfar);

	return matrix;
};

Matrix::Ptr Babylon::Matrix::PerspectiveFovLH(float fov, float aspect, float znear, float zfar) {
	auto matrix = Matrix::Zero();
	Matrix::PerspectiveFovLHToRef(fov, aspect, znear, zfar, matrix);
	return matrix;
};

void Babylon::Matrix::PerspectiveFovLHToRef(float fov, float aspect, float znear, float zfar, Matrix::Ptr result) {
	auto _tan = 1.0 / (tan(fov * 0.5));

	result->m[0] = _tan / aspect;
	result->m[1] = result->m[2] = result->m[3] = 0.0;
	result->m[5] = _tan;
	result->m[4] = result->m[6] = result->m[7] = 0.0;
	result->m[8] = result->m[9] = 0.0;
	result->m[10] = -zfar / (znear - zfar);
	result->m[11] = 1.0;
	result->m[12] = result->m[13] = result->m[15] = 0.0;
	result->m[14] = (znear * zfar) / (znear - zfar);
};

Matrix::Ptr Babylon::Matrix::GetFinalMatrix(Viewport::Ptr viewport, Matrix::Ptr world, Matrix::Ptr view, Matrix::Ptr projection, float zmin, float zmax) {
	auto cw = viewport->width;
	auto ch = viewport->height;
	auto cx = viewport->x;
	auto cy = viewport->y;

	auto viewportMatrix = Matrix::FromValues(cw / 2.0, 0., 0., 0.,
		0., -ch / 2.0, 0., 0.,
		0., 0., zmax - zmin, 0.,
		cx + cw / 2.0, ch / 2.0 + cy, zmin, 1.);

	return world->multiply(view)->multiply(projection)->multiply(viewportMatrix);
};

Matrix::Ptr Babylon::Matrix::Transpose(Matrix::Ptr matrix) {
	auto result = make_shared<Matrix>();

	result->m[0] = matrix->m[0];
	result->m[1] = matrix->m[4];
	result->m[2] = matrix->m[8];
	result->m[3] = matrix->m[12];

	result->m[4] = matrix->m[1];
	result->m[5] = matrix->m[5];
	result->m[6] = matrix->m[9];
	result->m[7] = matrix->m[13];

	result->m[8] = matrix->m[2];
	result->m[9] = matrix->m[6];
	result->m[10] = matrix->m[10];
	result->m[11] = matrix->m[14];

	result->m[12] = matrix->m[3];
	result->m[13] = matrix->m[7];
	result->m[14] = matrix->m[11];
	result->m[15] = matrix->m[15];

	return result;
};

Matrix::Ptr Babylon::Matrix::Reflection(Plane::Ptr plane) {
	auto matrix = make_shared<Matrix>();
	Matrix::ReflectionToRef(plane, matrix);
	return matrix;
};

void Babylon::Matrix::ReflectionToRef(Plane::Ptr plane, Matrix::Ptr result) {
	plane->normalize();
	auto x = plane->normal->x;
	auto y = plane->normal->y;
	auto z = plane->normal->z;
	auto temp = -2 * x;
	auto temp2 = -2 * y;
	auto temp3 = -2 * z;
	result->m[0] = (temp * x) + 1;
	result->m[1] = temp2 * x;
	result->m[2] = temp3 * x;
	result->m[3] = 0.0;
	result->m[4] = temp * y;
	result->m[5] = (temp2 * y) + 1;
	result->m[6] = temp3 * y;
	result->m[7] = 0.0;
	result->m[8] = temp * z;
	result->m[9] = temp2 * z;
	result->m[10] = (temp3 * z) + 1;
	result->m[11] = 0.0;
	result->m[12] = temp * plane->d;
	result->m[13] = temp2 * plane->d;
	result->m[14] = temp3 * plane->d;
	result->m[15] = 1.0;
};
