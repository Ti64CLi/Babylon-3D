using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Animation {
        private Array < object > _keys;
        private dynamic _offsetsCache = new {};
        private dynamic _highLimitsCache = new {};
        private bool _stopped = false;
        public dynamic _target;
        public Array < string > targetPropertyPath;
        public double currentFrame;
        public string name;
        public string targetProperty;
        public double framePerSecond;
        public double dataType;
        public double loopMode;
        public Animation(string name, string targetProperty, double framePerSecond, double dataType, double loopMode = 0.0) {
            this.targetPropertyPath = targetProperty.Split(".");
            this.dataType = dataType;
            this.loopMode = (loopMode == null) ? Animation.ANIMATIONLOOPMODE_CYCLE : loopMode;
        }
        public virtual bool isStopped() {
            return this._stopped;
        }
        public virtual Array < object > getKeys() {
            return this._keys;
        }
        public virtual double floatInterpolateFunction(double startValue, double endValue, double gradient) {
            return startValue + (endValue - startValue) * gradient;
        }
        public virtual Quaternion quaternionInterpolateFunction(Quaternion startValue, Quaternion endValue, double gradient) {
            return BABYLON.Quaternion.Slerp(startValue, endValue, gradient);
        }
        public virtual Vector3 vector3InterpolateFunction(Vector3 startValue, Vector3 endValue, double gradient) {
            return BABYLON.Vector3.Lerp(startValue, endValue, gradient);
        }
        public virtual Color3 color3InterpolateFunction(Color3 startValue, Color3 endValue, double gradient) {
            return BABYLON.Color3.Lerp(startValue, endValue, gradient);
        }
        public virtual Animation clone() {
            var clone = new Animation(this.name, this.targetPropertyPath.join("."), this.framePerSecond, this.dataType, this.loopMode);
            clone.setKeys(this._keys);
            return clone;
        }
        public virtual void setKeys(Array < object > values) {
            this._keys = values.slice(0);
            this._offsetsCache = new {};
            this._highLimitsCache = new {};
        }
        private void _interpolate(double currentFrame, double repeatCount, double loopMode, object offsetValue = null, object highLimitValue = null) {
            if (loopMode == Animation.ANIMATIONLOOPMODE_CONSTANT && repeatCount > 0) {
                return (highLimitValue.clone) ? highLimitValue.clone() : highLimitValue;
            }
            this.currentFrame = currentFrame;
            for (var key = 0; key < this._keys.Length; key++) {
                if (this._keys[key + 1].frame >= currentFrame) {
                    var startValue = this._keys[key].value;
                    var endValue = this._keys[key + 1].value;
                    var gradient = (currentFrame - this._keys[key].frame) / (this._keys[key + 1].frame - this._keys[key].frame);
                    switch (this.dataType) {
                        case Animation.ANIMATIONTYPE_FLOAT:
                            switch (loopMode) {
                                case Animation.ANIMATIONLOOPMODE_CYCLE:
                                case Animation.ANIMATIONLOOPMODE_CONSTANT:
                                    return this.floatInterpolateFunction(startValue, endValue, gradient);
                                case Animation.ANIMATIONLOOPMODE_RELATIVE:
                                    return offsetValue * repeatCount + this.floatInterpolateFunction(startValue, endValue, gradient);
                            }
                            break;
                        case Animation.ANIMATIONTYPE_QUATERNION:
                            var quaternion = null;
                            switch (loopMode) {
                                case Animation.ANIMATIONLOOPMODE_CYCLE:
                                case Animation.ANIMATIONLOOPMODE_CONSTANT:
                                    quaternion = this.quaternionInterpolateFunction(startValue, endValue, gradient);
                                    break;
                                case Animation.ANIMATIONLOOPMODE_RELATIVE:
                                    quaternion = this.quaternionInterpolateFunction(startValue, endValue, gradient).add(offsetValue.scale(repeatCount));
                                    break;
                            }
                            return quaternion;
                        case Animation.ANIMATIONTYPE_VECTOR3:
                            switch (loopMode) {
                                case Animation.ANIMATIONLOOPMODE_CYCLE:
                                case Animation.ANIMATIONLOOPMODE_CONSTANT:
                                    return this.vector3InterpolateFunction(startValue, endValue, gradient);
                                case Animation.ANIMATIONLOOPMODE_RELATIVE:
                                    return this.vector3InterpolateFunction(startValue, endValue, gradient).add(offsetValue.scale(repeatCount));
                            }
                        case Animation.ANIMATIONTYPE_COLOR3:
                            switch (loopMode) {
                                case Animation.ANIMATIONLOOPMODE_CYCLE:
                                case Animation.ANIMATIONLOOPMODE_CONSTANT:
                                    return this.color3InterpolateFunction(startValue, endValue, gradient);
                                case Animation.ANIMATIONLOOPMODE_RELATIVE:
                                    return this.color3InterpolateFunction(startValue, endValue, gradient).add(offsetValue.scale(repeatCount));
                            }
                        case Animation.ANIMATIONTYPE_MATRIX:
                            switch (loopMode) {
                                case Animation.ANIMATIONLOOPMODE_CYCLE:
                                case Animation.ANIMATIONLOOPMODE_CONSTANT:
                                case Animation.ANIMATIONLOOPMODE_RELATIVE:
                                    return startValue;
                            }
                        default:
                            break;
                    }
                    break;
                }
            }
            return this._keys[this._keys.Length - 1].value;
        }
        public virtual bool animate(double delay, double from, double to, bool loop, double speedRatio) {
            if (!this.targetPropertyPath || this.targetPropertyPath.Length < 1) {
                this._stopped = true;
                return false;
            }
            var returnValue = true;
            if (this._keys[0].frame != 0) {
                var newKey = new {};
                this._keys.splice(0, 0, newKey);
            }
            if (from < this._keys[0].frame || from > this._keys[this._keys.Length - 1].frame) {
                from = this._keys[0].frame;
            }
            if (to < this._keys[0].frame || to > this._keys[this._keys.Length - 1].frame) {
                to = this._keys[this._keys.Length - 1].frame;
            }
            var range = to - from;
            var ratio = delay * (this.framePerSecond * speedRatio) / 1000.0;
            if (ratio > range && !loop) {
                offsetValue = 0;
                returnValue = false;
                highLimitValue = this._keys[this._keys.Length - 1].value;
            } else {
                var offsetValue = 0;
                var highLimitValue = 0;
                if (this.loopMode != Animation.ANIMATIONLOOPMODE_CYCLE) {
                    var keyOffset = to.toString() + from.toString();
                    if (!this._offsetsCache[keyOffset]) {
                        var fromValue = this._interpolate(from, 0, Animation.ANIMATIONLOOPMODE_CYCLE);
                        var toValue = this._interpolate(to, 0, Animation.ANIMATIONLOOPMODE_CYCLE);
                        switch (this.dataType) {
                            case Animation.ANIMATIONTYPE_FLOAT:
                                this._offsetsCache[keyOffset] = toValue - fromValue;
                                break;
                            case Animation.ANIMATIONTYPE_QUATERNION:
                                this._offsetsCache[keyOffset] = toValue.subtract(fromValue);
                                break;
                            case Animation.ANIMATIONTYPE_VECTOR3:
                                this._offsetsCache[keyOffset] = toValue.subtract(fromValue);
                            case Animation.ANIMATIONTYPE_COLOR3:
                                this._offsetsCache[keyOffset] = toValue.subtract(fromValue);
                            default:
                                break;
                        }
                        this._highLimitsCache[keyOffset] = toValue;
                    }
                    highLimitValue = this._highLimitsCache[keyOffset];
                    offsetValue = this._offsetsCache[keyOffset];
                }
            }
            var repeatCount = (ratio / range) << 0;
            var currentFrame = (returnValue) ? from + ratio % range : to;
            var currentValue = this._interpolate(currentFrame, repeatCount, this.loopMode, offsetValue, highLimitValue);
            if (this.targetPropertyPath.Length > 1) {
                var property = this._target[this.targetPropertyPath[0]];
                for (var index = 1; index < this.targetPropertyPath.Length - 1; index++) {
                    property = property[this.targetPropertyPath[index]];
                }
                property[this.targetPropertyPath[this.targetPropertyPath.Length - 1]] = currentValue;
            } else {
                this._target[this.targetPropertyPath[0]] = currentValue;
            }
            if (this._target.markAsDirty) {
                this._target.markAsDirty(this.targetProperty);
            }
            if (!returnValue) {
                this._stopped = true;
            }
            return returnValue;
        }
        private
        const double _ANIMATIONTYPE_FLOAT = 0;
        private
        const double _ANIMATIONTYPE_VECTOR3 = 1;
        private
        const double _ANIMATIONTYPE_QUATERNION = 2;
        private
        const double _ANIMATIONTYPE_MATRIX = 3;
        private
        const double _ANIMATIONTYPE_COLOR3 = 4;
        private
        const double _ANIMATIONLOOPMODE_RELATIVE = 0;
        private
        const double _ANIMATIONLOOPMODE_CYCLE = 1;
        private
        const double _ANIMATIONLOOPMODE_CONSTANT = 2;
        public static double ANIMATIONTYPE_FLOAT {
            get {
                return Animation._ANIMATIONTYPE_FLOAT;
            }
        }
        public static double ANIMATIONTYPE_VECTOR3 {
            get {
                return Animation._ANIMATIONTYPE_VECTOR3;
            }
        }
        public static double ANIMATIONTYPE_QUATERNION {
            get {
                return Animation._ANIMATIONTYPE_QUATERNION;
            }
        }
        public static double ANIMATIONTYPE_MATRIX {
            get {
                return Animation._ANIMATIONTYPE_MATRIX;
            }
        }
        public static double ANIMATIONTYPE_COLOR3 {
            get {
                return Animation._ANIMATIONTYPE_COLOR3;
            }
        }
        public static double ANIMATIONLOOPMODE_RELATIVE {
            get {
                return Animation._ANIMATIONLOOPMODE_RELATIVE;
            }
        }
        public static double ANIMATIONLOOPMODE_CYCLE {
            get {
                return Animation._ANIMATIONLOOPMODE_CYCLE;
            }
        }
        public static double ANIMATIONLOOPMODE_CONSTANT {
            get {
                return Animation._ANIMATIONLOOPMODE_CONSTANT;
            }
        }
    }
}