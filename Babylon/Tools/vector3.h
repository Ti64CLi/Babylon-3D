#ifndef BABYLON_VECTOR3_H
#define BABYLON_VECTOR3_H

#include <memory>
#include <vector>

#include "igl.h"
#include "viewport.h"

using namespace std;

namespace Babylon {

	class Matrix;
	typedef shared_ptr<Matrix> MatrixPtr;

	struct Vector3: public enable_shared_from_this<Vector3> {

	public:
		typedef shared_ptr<Vector3> Ptr;
		typedef vector<Ptr> Array;

	public:
		float x;
		float y;
		float z;

	public: 
		Vector3(float initialX, float initialY, float initialZ);		

		virtual string toString();
		// Operators
		virtual void toArray(Float32Array array, int index);
		virtual void addInPlace(Vector3::Ptr otherVector);
		virtual Vector3::Ptr add(Vector3::Ptr otherVector);
		virtual void addToRef(Vector3::Ptr otherVector, Vector3::Ptr result);
		virtual void subtractInPlace(Vector3::Ptr otherVector);
		virtual Vector3::Ptr subtract(Vector3::Ptr otherVector);
		virtual void subtractToRef(Vector3::Ptr otherVector, Vector3::Ptr result);
		virtual Vector3::Ptr subtractFromFloats(float x, float y, float z);
		virtual void subtractFromFloatsToRef(float x, float y, float z, Vector3::Ptr result);
		virtual Vector3::Ptr negate();
		virtual void scaleInPlace(float scale);
		virtual Vector3::Ptr scale(float scale);
		virtual void scaleToRef(float scale, Vector3::Ptr result);
		virtual bool equals(Vector3::Ptr otherVector);
		virtual bool equalsToFloats(float x, float y, float z);
		virtual void multiplyInPlace(Vector3::Ptr otherVector);
		virtual Vector3::Ptr multiply(Vector3::Ptr otherVector);
		virtual void multiplyToRef(Vector3::Ptr otherVector, Vector3::Ptr result);
		virtual Vector3::Ptr multiplyByFloats(float x, float y, float z);
		virtual Vector3::Ptr divide(Vector3::Ptr otherVector);
		virtual void divideToRef(Vector3::Ptr otherVector, Vector3::Ptr result);

		// Properties
		virtual float length();
		virtual float lengthSquared();

		// Methods
		virtual void normalize();
		virtual Vector3::Ptr clone();
		virtual void copyFrom(Vector3::Ptr source);
		virtual void copyFromFloats(float x, float y, float z);

		// Statics
		static Vector3::Ptr FromArray(Float32Array array, int offset);
		static void FromArrayToRef(Float32Array array, int offset, Vector3::Ptr result);
		static void FromFloatsToRef(float x, float y, float z, Vector3::Ptr result);
		static Vector3::Ptr Zero();
		static Vector3::Ptr Up();
		static Vector3::Ptr TransformCoordinates(Vector3::Ptr vector, MatrixPtr transformation);
		static void TransformCoordinatesToRef(Vector3::Ptr vector, MatrixPtr transformation, Vector3::Ptr result);
		static void TransformCoordinatesFromFloatsToRef(float x, float y, float z, MatrixPtr transformation, Vector3::Ptr result);
		static Vector3::Ptr TransformNormal(Vector3::Ptr vector, MatrixPtr transformation);
		static void TransformNormalToRef(Vector3::Ptr vector, MatrixPtr transformation, Vector3::Ptr result);
		static void TransformNormalFromFloatsToRef(float x, float y, float z, MatrixPtr transformation, Vector3::Ptr result);
		static Vector3::Ptr CatmullRom(Vector3::Ptr value1, Vector3::Ptr value2, Vector3::Ptr value3, Vector3::Ptr value4, float amount);
		static Vector3::Ptr Clamp(Vector3::Ptr value, Vector3::Ptr min, Vector3::Ptr max);
		static Vector3::Ptr Hermite(Vector3::Ptr value1, Vector3::Ptr tangent1, Vector3::Ptr value2, Vector3::Ptr tangent2, float amount);
		static Vector3::Ptr Lerp(Vector3::Ptr start, Vector3::Ptr end, float amount);
		static float Dot(Vector3::Ptr left, Vector3::Ptr right);
		static Vector3::Ptr Cross(Vector3::Ptr left, Vector3::Ptr right);
		static void CrossToRef(Vector3::Ptr left, Vector3::Ptr right, Vector3::Ptr result);
		static Vector3::Ptr Normalize(Vector3::Ptr vector);
		static void NormalizeToRef(Vector3::Ptr vector, Vector3::Ptr result);
		static Vector3::Ptr Project(Vector3::Ptr vector, MatrixPtr world, MatrixPtr transform, Viewport::Ptr viewport);
		static Vector3::Ptr Unproject(Vector3::Ptr source, int viewportWidth, int viewportHeight, MatrixPtr world, MatrixPtr view, MatrixPtr projection);
		static Vector3::Ptr Minimize(Vector3::Ptr left, Vector3::Ptr right);
		static Vector3::Ptr Maximize(Vector3::Ptr left, Vector3::Ptr right);
		static float Distance(Vector3::Ptr value1, Vector3::Ptr value2);
		static float DistanceSquared(Vector3::Ptr value1, Vector3::Ptr value2);
	};

	struct RangeVector {
	public:
		Vector3::Ptr minimum;
		Vector3::Ptr maximum;
		
		RangeVector(Vector3::Ptr min_, Vector3::Ptr max_)
			: minimum(min_), maximum(max_)
		{
		}
	};

};

#endif // BABYLON_VECTOR3_H