#ifndef BABYLON_QUATERNION_H
#define BABYLON_QUATERNION_H

#include "decls.h"

#include "vector3.h"
#include "matrix.h"

namespace Babylon {

	struct Quaternion: public enable_shared_from_this<Quaternion> {

	public:
		typedef shared_ptr_t<Quaternion> Ptr;

	public:
		float x;
		float y;
		float z;
		float w;

	public: 
		Quaternion(float x, float y, float z, float w);		

		virtual bool equals(Quaternion::Ptr otherQuaternion);
		virtual Quaternion::Ptr clone();
		virtual void copyFrom(Quaternion::Ptr other);
		virtual Quaternion::Ptr add(Quaternion::Ptr other);
		virtual Quaternion::Ptr subtract(Quaternion::Ptr other);
		virtual Quaternion::Ptr scale(float value);
		virtual Quaternion::Ptr multiply(Quaternion::Ptr q1);
		virtual void multiplyToRef(Quaternion::Ptr q1, Quaternion::Ptr result);
		virtual float length();
		virtual void normalize();
		virtual Vector3::Ptr toEulerAngles();
		virtual void toRotationMatrix(Matrix::Ptr result);
		// Statics
		static Quaternion::Ptr FromArray(Float32Array array, int offset);
		static Quaternion::Ptr RotationYawPitchRoll(float yaw, float pitch, float roll);
		static void RotationYawPitchRollToRef(float yaw, float pitch, float roll, Quaternion::Ptr result);
		static Quaternion::Ptr Slerp(Quaternion::Ptr left, Quaternion::Ptr right, float amount);
	};

};

#endif // BABYLON_QUATERNION_H