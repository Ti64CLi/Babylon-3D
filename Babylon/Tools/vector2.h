#ifndef BABYLON_VECTOR2_H
#define BABYLON_VECTOR2_H

#include <memory>
#include <vector>

#include "igl.h"
#include "viewport.h"

using namespace std;

namespace Babylon {

	class Matrix;
	typedef shared_ptr<Matrix> MatrixPtr;

	struct Vector2: public enable_shared_from_this<Vector2> {

	public:
		typedef shared_ptr<Vector2> Ptr;
		typedef vector<Ptr> Array;

	public:
		float x;
		float y;

	public: 
		Vector2(float initialX, float initialY);		

		// Operators
		virtual Float32Array asArray();
		virtual void toArray(Float32Array& array, int index);
		virtual void addInPlace(Vector2::Ptr otherVector);
		virtual Vector2::Ptr add(Vector2::Ptr otherVector);
		virtual void addToRef(Vector2::Ptr otherVector, Vector2::Ptr result);
		virtual void subtractInPlace(Vector2::Ptr otherVector);
		virtual Vector2::Ptr subtract(Vector2::Ptr otherVector);
		virtual void subtractToRef(Vector2::Ptr otherVector, Vector2::Ptr result);
		virtual Vector2::Ptr subtractFromFloats(float x, float y);
		virtual void subtractFromFloatsToRef(float x, float y, Vector2::Ptr result);
		virtual Vector2::Ptr negate();
		virtual void scaleInPlace(float scale);
		virtual Vector2::Ptr scale(float scale);
		virtual void scaleToRef(float scale, Vector2::Ptr result);
		virtual bool equals(Vector2::Ptr otherVector);
		virtual bool equalsToFloats(float x, float y);
		virtual void multiplyInPlace(Vector2::Ptr otherVector);
		virtual Vector2::Ptr multiply(Vector2::Ptr otherVector);
		virtual void multiplyToRef(Vector2::Ptr otherVector, Vector2::Ptr result);
		virtual Vector2::Ptr multiplyByFloats(float x, float y);
		virtual Vector2::Ptr divide(Vector2::Ptr otherVector);
		virtual void divideToRef(Vector2::Ptr otherVector, Vector2::Ptr result);

		// Properties
		virtual float length();
		virtual float lengthSquared();

		// Methods
		virtual void normalize();
		virtual Vector2::Ptr clone();
		virtual void copyFrom(Vector2::Ptr source);
		virtual void copyFromFloats(float x, float y);

		// Statics
		static Vector2::Ptr FromArray(Float32Array array, int offset);
		static void FromArrayToRef(Float32Array array, int offset, Vector2::Ptr result);
		static void FromFloatsToRef(float x, float y, Vector2::Ptr result);
		static Vector2::Ptr Zero();
		static Vector2::Ptr CatmullRom(Vector2::Ptr value1, Vector2::Ptr value2, Vector2::Ptr value3, Vector2::Ptr value4, float amount);
		static Vector2::Ptr Clamp(Vector2::Ptr value, Vector2::Ptr min, Vector2::Ptr max);
		static Vector2::Ptr Hermite(Vector2::Ptr value1, Vector2::Ptr tangent1, Vector2::Ptr value2, Vector2::Ptr tangent2, float amount);
		static Vector2::Ptr Lerp(Vector2::Ptr start, Vector2::Ptr end, float amount);
		static float Dot(Vector2::Ptr left, Vector2::Ptr right);
		static Vector2::Ptr Normalize(Vector2::Ptr vector);
		static void NormalizeToRef(Vector2::Ptr vector, Vector2::Ptr result);
		static Vector2::Ptr Project(Vector2::Ptr vector, MatrixPtr world, MatrixPtr transform, Viewport::Ptr viewport);
		static Vector2::Ptr Unproject(Vector2::Ptr source, int viewportWidth, int viewportHeight, MatrixPtr world, MatrixPtr view, MatrixPtr projection);
		static Vector2::Ptr Minimize(Vector2::Ptr left, Vector2::Ptr right);
		static Vector2::Ptr Maximize(Vector2::Ptr left, Vector2::Ptr right);
		static Vector2::Ptr Transform(Vector2::Ptr vector, MatrixPtr transformation);
		static float Distance(Vector2::Ptr value1, Vector2::Ptr value2);
		static float DistanceSquared(Vector2::Ptr value1, Vector2::Ptr value2);
	};
};

#endif // BABYLON_VECTOR2_H