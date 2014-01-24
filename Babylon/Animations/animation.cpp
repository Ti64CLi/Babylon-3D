#include "animation.h"
#include <string>
#include "animatable.h"

using namespace Babylon;

Babylon::Animation::Animation(string name, string targetProperty, float framePerSecond, ANIMATIONTYPES dataType, ANIMATIONLOOPMODES loopMode)
{
	this->name = name;
	this->targetProperty = targetProperty;
	this->framePerSecond = framePerSecond;
	this->dataType = dataType;
	this->loopMode = loopMode;

	this->_keys.clear();

	// Cache
	this->_offsetsCache.clear();
	this->_highLimitsCache.clear();
};

// Methods   
float Babylon::Animation::floatInterpolateFunction(float startValue, float  endValue, float  gradient) {
	return startValue + (endValue - startValue) * gradient;
};

Quaternion::Ptr Babylon::Animation::quaternionInterpolateFunction(Quaternion::Ptr startValue, Quaternion::Ptr endValue, float gradient) {
	return Quaternion::Slerp(startValue, endValue, gradient);
};

Vector3::Ptr Babylon::Animation::vector3InterpolateFunction(Vector3::Ptr startValue, Vector3::Ptr endValue, float gradient) {
	return Vector3::Lerp(startValue, endValue, gradient);
};

Animation::Ptr Babylon::Animation::clone() {
	auto clone = make_shared<Animation>(this->name, this->targetProperty, this->framePerSecond, this->dataType, this->loopMode);
	clone->setKeys(this->_keys);
	return clone;
};

void Babylon::Animation::setKeys(vector<AnimationKey> values) {
	this->_keys = values;//.slice(0);
	values.clear();

	this->_offsetsCache.clear();
	this->_highLimitsCache.clear();
};

AnimationValue Babylon::Animation::_interpolate(int currentFrame, int repeatCount, ANIMATIONLOOPMODES loopMode, AnimationValue offsetValue, AnimationValue highLimitValue) {
	if (loopMode == ANIMATIONLOOPMODE_CONSTANT && repeatCount > 0) {
		return highLimitValue.clone();
	}

	this->currentFrame = currentFrame;

	for (auto key = 0; key < this->_keys.size(); key++) {
		if (this->_keys[key + 1].frame >= currentFrame) {
			auto gradient = (currentFrame - this->_keys[key].frame) / (this->_keys[key + 1].frame - this->_keys[key].frame);
			auto newVale = this->_keys[key].value.clone();
			auto startValue = this->_keys[key].value;
			auto endValue = this->_keys[key + 1].value;

			switch (this->dataType) {
				// Float
			case ANIMATIONTYPE_FLOAT:
				switch (loopMode) {
				case ANIMATIONLOOPMODE_CYCLE:
				case ANIMATIONLOOPMODE_CONSTANT:
					newVale.floatData = this->floatInterpolateFunction(startValue.floatData, endValue.floatData, gradient);                                
					return newVale;
				case ANIMATIONLOOPMODE_RELATIVE:
					newVale.floatData = offsetValue.floatData * repeatCount + this->floatInterpolateFunction(startValue.floatData, endValue.floatData, gradient);
					return newVale;
				}
				break;
				// Quaternion
			case ANIMATIONTYPE_QUATERNION:
				switch (loopMode) {
				case ANIMATIONLOOPMODE_CYCLE:
				case ANIMATIONLOOPMODE_CONSTANT:
					newVale.quaternionData = this->quaternionInterpolateFunction(startValue.quaternionData, endValue.quaternionData, gradient);
					return newVale;
				case ANIMATIONLOOPMODE_RELATIVE:
					newVale.quaternionData = this->quaternionInterpolateFunction(startValue.quaternionData, endValue.quaternionData, gradient)->add(offsetValue.quaternionData->scale(repeatCount));
					return newVale;
				}
				// Vector3
			case ANIMATIONTYPE_VECTOR3:
				switch (loopMode) {
				case ANIMATIONLOOPMODE_CYCLE:
				case ANIMATIONLOOPMODE_CONSTANT:
					newVale.vector3Data = this->vector3InterpolateFunction(startValue.vector3Data, endValue.vector3Data, gradient);
					return newVale;
				case ANIMATIONLOOPMODE_RELATIVE:
					newVale.vector3Data = this->vector3InterpolateFunction(startValue.vector3Data, endValue.vector3Data, gradient)->add(offsetValue.vector3Data->scale(repeatCount));
					return newVale;
				}
				// Matrix
			case ANIMATIONTYPE_MATRIX:
				switch (loopMode) {
				case ANIMATIONLOOPMODE_CYCLE:
				case ANIMATIONLOOPMODE_CONSTANT:
				case ANIMATIONLOOPMODE_RELATIVE:
					return newVale;
				}
			default:
				break;
			}
			break;
		}
	}
	return this->_keys[this->_keys.size() - 1].value;
};

bool Babylon::Animation::animate(_AnimationContainer::Ptr target, float delay, int from, int to, ANIMATIONLOOPMODES loop, float speedRatio) {
	if (this->targetProperty.empty()) {
		return false;
	}

	auto returnValue = true;
	// Adding a start key at frame 0 if missing
	if (this->_keys[0].frame != 0) {
		auto newKey = AnimationKey(0, this->_keys[0].value);
		this->_keys.clear();
		this->_keys.push_back(newKey);
	}

	// Check limits
	if (from < this->_keys[0].frame || from > this->_keys[this->_keys.size() - 1].frame) {
		from = this->_keys[0].frame;
	}
	if (to < this->_keys[0].frame || to > this->_keys[this->_keys.size() - 1].frame) {
		to = this->_keys[this->_keys.size() - 1].frame;
	}

	// Compute ratio
	auto range = to - from;
	auto ratio = delay * (this->framePerSecond * speedRatio) / 1000.0;

	auto offsetValue = AnimationValue();
	auto highLimitValue = AnimationValue();
	if (ratio > range && !loop) { // If we are out of range and not looping get back to caller
		auto offsetValue = AnimationValue();
		returnValue = false;
	} else {
		// Get max value if required
		if (this->loopMode != ANIMATIONLOOPMODE_CYCLE) {
			auto keyOffset = to_string(to) + to_string(from);
			if (!this->_offsetsCache.count(keyOffset)) {
				auto fromValue = this->_interpolate(from, 0, ANIMATIONLOOPMODE_CYCLE);
				auto toValue = this->_interpolate(to, 0, ANIMATIONLOOPMODE_CYCLE);
				this->_offsetsCache[keyOffset] = fromValue - fromValue;
				this->_highLimitsCache[keyOffset] = toValue;
			}

			highLimitValue = this->_highLimitsCache[keyOffset];
			offsetValue = this->_offsetsCache[keyOffset];
		}
	}

	// Compute value
	auto repeatCount = (int)(ratio / (float)range) >> 0;
	auto currentFrame = returnValue ? from + (int)ratio % range : to;
	auto currentValue = this->_interpolate(currentFrame, repeatCount, this->loopMode, offsetValue, highLimitValue);

	// Set value
	////target[this->targetPropertyPath[0]] = currentValue;
	//// TODO: of property has . inside pass it to nested objects
	target->setValue(this->targetProperty, currentValue);

	target->markAsDirty(this->targetProperty);

	return returnValue;
};
