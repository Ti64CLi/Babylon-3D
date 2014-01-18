#ifndef BABYLON_MATRIX_H
#define BABYLON_MATRIX_H

#include <memory>
#include <vector>

#include "igl.h"
#include "vector3.h"

using namespace std;

namespace Babylon {

	class Plane;
	typedef shared_ptr<Plane> PlanePtr;

	struct Matrix: public enable_shared_from_this<Matrix> {

	public:
		typedef shared_ptr<Matrix> Ptr;

	public:
		Float32Array m;

	public: 
		Matrix();		

		static Vector3::Ptr xAxis;
		static Vector3::Ptr yAxis;
		static Vector3::Ptr zAxis;

		virtual bool isIdentity();
		virtual float determinant();
		// Methods
		virtual Float32Array toArray();
		virtual void invert();
		virtual void invertToRef(Matrix::Ptr other);
		virtual void setTranslation(Vector3::Ptr vector3);
		virtual Matrix::Ptr multiply(Matrix::Ptr other);
		virtual void copyFrom(Matrix::Ptr other);
		virtual void multiplyToRef(Matrix::Ptr other, Matrix::Ptr result);
		virtual void multiplyToArray(Matrix::Ptr other, Float32Array result, int offset);
		virtual bool equals(Matrix::Ptr value);
		virtual Matrix::Ptr clone();
		// Statics
		virtual Matrix::Ptr FromArray(Float32Array array, int offset);
		virtual void FromArrayToRef(Float32Array array, int offset, Matrix::Ptr result);
		virtual void FromValuesToRef(float initialM11, float initialM12, float initialM13, float initialM14, float initialM21, float initialM22, float initialM23, float initialM24,
			float initialM31, float initialM32, float initialM33, float initialM34,
			float initialM41, float initialM42, float initialM43, float initialM44, Matrix::Ptr result);
		static Matrix::Ptr FromValues(float initialM11, float initialM12, float initialM13, float initialM14, float initialM21, float initialM22, float initialM23, float initialM24,
			float initialM31, float initialM32, float initialM33, float initialM34,
			float initialM41, float initialM42, float initialM43, float initialM44);
		static Matrix::Ptr Identity();
		virtual void IdentityToRef(Matrix::Ptr result);
		static Matrix::Ptr Zero();
		virtual Matrix::Ptr RotationX(float angle);
		static void RotationXToRef(float angle, Matrix::Ptr result);
		static Matrix::Ptr RotationY(float angle);
		static void RotationYToRef(float angle, Matrix::Ptr result);
		static Matrix::Ptr RotationZ(float angle);
		static void RotationZToRef(float angle, Matrix::Ptr result);
		static Matrix::Ptr RotationAxis(Vector3::Ptr axis, float angle);
		//virtual void RotationYawPitchRoll(yaw, pitch, roll);
		//virtual void RotationYawPitchRollToRef(yaw, pitch, roll, Matrix::Ptr result);
		virtual Matrix::Ptr Scaling(float x, float y, float z);
		virtual void ScalingToRef(float x, float y, float z, Matrix::Ptr result);
		virtual Matrix::Ptr Translation(float x, float y, float z);
		virtual void TranslationToRef(float x, float y, float z, Matrix::Ptr result);
		virtual Matrix::Ptr LookAtLH(Vector3::Ptr eye, Vector3::Ptr target, Vector3::Ptr up);
		virtual void LookAtLHToRef(Vector3::Ptr eye, Vector3::Ptr target, Vector3::Ptr up, Matrix::Ptr result);
		virtual Matrix::Ptr OrthoLH(float width, float height, float znear, float zfar);
		virtual Matrix::Ptr OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar);
		static void OrthoOffCenterLHToRef(float left, float right, float bottom, float top, float znear, float zfar, Matrix::Ptr result);
		virtual Matrix::Ptr PerspectiveLH(float width, float height, float znear, float zfar);
		virtual Matrix::Ptr PerspectiveFovLH(float fov, float aspect, float znear, float zfar);
		static void PerspectiveFovLHToRef(float fov, float aspect, float znear, float zfar, Matrix::Ptr result);
		//virtual Matrix::Ptr AffineTransformation(float scaling, rotationCenter, rotation, translation);
		virtual Matrix::Ptr GetFinalMatrix(Viewport::Ptr viewport, Matrix::Ptr world, Matrix::Ptr view, Matrix::Ptr projection, float zmin, float zmax);
		static Matrix::Ptr Transpose(Matrix::Ptr matrix);
		virtual Matrix::Ptr Reflection(PlanePtr plane);
		virtual void ReflectionToRef(PlanePtr plane, Matrix::Ptr result);
	};

};

#endif // BABYLON_MATRIX_H