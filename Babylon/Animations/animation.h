#ifndef BABYLON_ANIMATION_H
#define BABYLON_ANIMATION_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "vector3.h"
#include "quaternion.h"

using namespace std;

namespace Babylon {

	struct AnimationValue
	{
	public:
		ANIMATIONTYPES dataType;
		float floatData;
		Quaternion::Ptr quaternionData;
		Vector3::Ptr vector3Data;
		Matrix::Ptr matrixData;

		AnimationValue() :
			dataType(ANIMATIONTYPE_FLOAT),
			floatData(0.)
		{
		};

		AnimationValue(float value) :
			dataType(ANIMATIONTYPE_FLOAT),
			floatData(value)
		{
		};

		AnimationValue(Quaternion::Ptr value) :
			dataType(ANIMATIONTYPE_QUATERNION),
			quaternionData(value)
		{
		};

		AnimationValue(Vector3::Ptr value) :
			dataType(ANIMATIONTYPE_VECTOR3),
			vector3Data(value)
		{
		};

		AnimationValue(Matrix::Ptr value) :
			dataType(ANIMATIONTYPE_MATRIX),
			matrixData(value)
		{
		};

		AnimationValue operator-(AnimationValue& fromValue)
		{
			switch (this->dataType) {
				// Float
			case ANIMATIONTYPE_FLOAT:
				return AnimationValue(this->floatData - fromValue.floatData);
				// Quaternion
			case ANIMATIONTYPE_QUATERNION:
				return AnimationValue(this->quaternionData->subtract(fromValue.quaternionData));
				// Vector3
			case ANIMATIONTYPE_VECTOR3:
				return AnimationValue(this->vector3Data->subtract(fromValue.vector3Data));
			}

			return *this;
		};

		AnimationValue clone() {
			AnimationValue v;
			switch (dataType)
			{
			case ANIMATIONTYPE_FLOAT:
				v.floatData = floatData;
			case ANIMATIONTYPE_QUATERNION:
				v.quaternionData = quaternionData->clone();
			case ANIMATIONTYPE_VECTOR3:
				v.vector3Data = vector3Data->clone();
			case ANIMATIONTYPE_MATRIX:
				v.matrixData = matrixData->clone();
			}

			return v;
		};
	};

	struct AnimationKey
	{
	public:
		int frame;
		AnimationValue value;

		AnimationKey(int frame_, AnimationValue value_) : frame(frame_), value(value_) {
		};
	};

	class _AnimationContainer;
	typedef shared_ptr<_AnimationContainer> _AnimationContainerPtr;

	class Animation : public enable_shared_from_this<Animation> {

	public:

		typedef shared_ptr<Animation> Ptr;
		typedef vector<Ptr> Array;

	private:
		// Cache
		map<string, AnimationValue> _offsetsCache;
		map<string, AnimationValue> _highLimitsCache;
		int currentFrame;

	public:
		string name;
		string targetProperty;
		float framePerSecond;
		ANIMATIONTYPES dataType;
		ANIMATIONLOOPMODES loopMode;

		vector<AnimationKey> _keys;

	public: 
		Animation(string name, string targetProperty, float framePerSecond, ANIMATIONTYPES dataType, ANIMATIONLOOPMODES loopMode = ANIMATIONLOOPMODE_CYCLE);

		virtual float floatInterpolateFunction(float startValue, float  endValue, float  gradient);
		virtual Quaternion::Ptr quaternionInterpolateFunction(Quaternion::Ptr startValue, Quaternion::Ptr endValue, float gradient);
		virtual Vector3::Ptr vector3InterpolateFunction(Vector3::Ptr startValue, Vector3::Ptr endValue, float gradient);
		virtual Animation::Ptr clone();

		virtual void setKeys(vector<AnimationKey> values);
		virtual AnimationValue _interpolate(int currentFrame, int repeatCount, ANIMATIONLOOPMODES loopMode, AnimationValue offsetValue = AnimationValue(), AnimationValue highLimitValue = AnimationValue());
		virtual bool animate(_AnimationContainerPtr target, float delay, int from, int to, ANIMATIONLOOPMODES loop, float speedRatio);
	};

};

#endif // BABYLON_ANIMATION_H