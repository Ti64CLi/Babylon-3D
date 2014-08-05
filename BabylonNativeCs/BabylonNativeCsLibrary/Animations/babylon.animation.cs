using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Animation
    {
        private Array<AnimationKey> _keys;
        private IDictionary<string, object> _offsetsCache = new Dictionary<string, object>();
        private IDictionary<string, object> _highLimitsCache = new Dictionary<string, object>();
        private bool _stopped = false;
        public IAnimatable _target;
        public string[] targetPropertyPath;
        public double currentFrame;
        public string name;
        public string targetProperty;
        public double framePerSecond;
        public int dataType;
        public int loopMode;
        public Animation(string name, string targetProperty, double framePerSecond, int dataType, int loopMode = 0)
        {
            this.name = name;
            this.framePerSecond = framePerSecond;
            this.targetPropertyPath = targetProperty.Split('.');
            this.dataType = dataType;
            this.loopMode = (loopMode == 0) ? Animation.ANIMATIONLOOPMODE_CYCLE : loopMode;
        }
        public virtual bool isStopped()
        {
            return this._stopped;
        }
        public virtual Array<AnimationKey> getKeys()
        {
            return this._keys;
        }
        public virtual double floatInterpolateFunction(double startValue, double endValue, double gradient)
        {
            return startValue + (endValue - startValue) * gradient;
        }
        public virtual Quaternion quaternionInterpolateFunction(Quaternion startValue, Quaternion endValue, double gradient)
        {
            return BABYLON.Quaternion.Slerp(startValue, endValue, gradient);
        }
        public virtual Vector3 vector3InterpolateFunction(Vector3 startValue, Vector3 endValue, double gradient)
        {
            return BABYLON.Vector3.Lerp(startValue, endValue, gradient);
        }
        public virtual Color3 color3InterpolateFunction(Color3 startValue, Color3 endValue, double gradient)
        {
            return BABYLON.Color3.Lerp(startValue, endValue, gradient);
        }
        public virtual Animation clone()
        {
            var clone = new Animation(this.name, string.Join(".", this.targetPropertyPath), this.framePerSecond, this.dataType, this.loopMode);
            clone.setKeys(this._keys);
            return clone;
        }
        public virtual void setKeys(Array<AnimationKey> values)
        {
            this._keys = values.slice(0);
            this._offsetsCache = new Dictionary<string, object>();
            this._highLimitsCache = new Dictionary<string, object>();
        }
        private object _interpolate(int currentFrame, int repeatCount, int loopMode, object offsetValue = null, object highLimitValue = null)
        {
            if (loopMode == Animation.ANIMATIONLOOPMODE_CONSTANT && repeatCount > 0)
            {
                var cloneable = highLimitValue as ICloneable;
                return (cloneable != null) ? cloneable.clone() : highLimitValue;
            }
            this.currentFrame = currentFrame;
            for (var key = 0; key < this._keys.Length; key++)
            {
                if (this._keys[key + 1].frame >= currentFrame)
                {
                    var startValue = this._keys[key].value;
                    var endValue = this._keys[key + 1].value;
                    var gradient = (double)(currentFrame - this._keys[key].frame) / (double)(this._keys[key + 1].frame - this._keys[key].frame);
                    switch (this.dataType)
                    {
                        case Animation._ANIMATIONTYPE_FLOAT:
                            switch (loopMode)
                            {
                                case Animation._ANIMATIONLOOPMODE_CYCLE:
                                case Animation._ANIMATIONLOOPMODE_CONSTANT:
                                    return this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                                case Animation._ANIMATIONLOOPMODE_RELATIVE:
                                    return (double)offsetValue * repeatCount + this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                            }
                            break;
                        case Animation._ANIMATIONTYPE_QUATERNION:
                            Quaternion quaternion = null;
                            switch (loopMode)
                            {
                                case Animation._ANIMATIONLOOPMODE_CYCLE:
                                case Animation._ANIMATIONLOOPMODE_CONSTANT:
                                    quaternion = this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, (double)gradient);
                                    break;
                                case Animation._ANIMATIONLOOPMODE_RELATIVE:
                                    quaternion = this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, gradient).add(((Quaternion)offsetValue).scale(repeatCount));
                                    break;
                            }
                            return quaternion;
                        case Animation._ANIMATIONTYPE_VECTOR3:
                            switch (loopMode)
                            {
                                case Animation._ANIMATIONLOOPMODE_CYCLE:
                                case Animation._ANIMATIONLOOPMODE_CONSTANT:
                                    return this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient);
                                case Animation._ANIMATIONLOOPMODE_RELATIVE:
                                    return this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient).add(((Vector3)offsetValue).scale(repeatCount));
                            }
                            break;
                        case Animation._ANIMATIONTYPE_COLOR3:
                            switch (loopMode)
                            {
                                case Animation._ANIMATIONLOOPMODE_CYCLE:
                                case Animation._ANIMATIONLOOPMODE_CONSTANT:
                                    return this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient);
                                case Animation._ANIMATIONLOOPMODE_RELATIVE:
                                    return this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient).add(((Color3)offsetValue).scale(repeatCount));
                            }
                            break;
                        case Animation._ANIMATIONTYPE_MATRIX:
                            switch (loopMode)
                            {
                                case Animation._ANIMATIONLOOPMODE_CYCLE:
                                case Animation._ANIMATIONLOOPMODE_CONSTANT:
                                case Animation._ANIMATIONLOOPMODE_RELATIVE:
                                    return startValue;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return this._keys[this._keys.Length - 1].value;
        }
        public virtual bool animate(int delay, int from, int to, bool loop, double speedRatio)
        {
            if (this.targetPropertyPath == null || this.targetPropertyPath.Length < 1)
            {
                this._stopped = true;
                return false;
            }
            var returnValue = true;
            if (this._keys[0].frame != 0)
            {
                var newKey = new Array<AnimationKey>();
                this._keys.splice(0, 0, newKey);
            }
            if (from < this._keys[0].frame || from > this._keys[this._keys.Length - 1].frame)
            {
                from = this._keys[0].frame;
            }
            if (to < this._keys[0].frame || to > this._keys[this._keys.Length - 1].frame)
            {
                to = this._keys[this._keys.Length - 1].frame;
            }

            object offsetValue = null;
            object highLimitValue = null;

            var range = to - from;
            var ratio = delay * (this.framePerSecond * speedRatio) / 1000.0;
            if (ratio > range && !loop)
            {
                offsetValue = null;
                returnValue = false;
                highLimitValue = this._keys[this._keys.Length - 1].value;
            }
            else
            {
                offsetValue = null;
                highLimitValue = null;
                if (this.loopMode != Animation.ANIMATIONLOOPMODE_CYCLE)
                {
                    var keyOffset = to.ToString() + from.ToString();
                    if (!this._offsetsCache.ContainsKey(keyOffset))
                    {
                        var fromValue = this._interpolate(from, 0, Animation.ANIMATIONLOOPMODE_CYCLE);
                        var toValue = this._interpolate(to, 0, Animation.ANIMATIONLOOPMODE_CYCLE);
                        switch (this.dataType)
                        {
                            case Animation._ANIMATIONTYPE_FLOAT:
                                this._offsetsCache[keyOffset] = ((double)toValue - (double)fromValue);
                                break;
                            case Animation._ANIMATIONTYPE_QUATERNION:
                                this._offsetsCache[keyOffset] = ((Quaternion)toValue).subtract((Quaternion)fromValue);
                                break;
                            case Animation._ANIMATIONTYPE_VECTOR3:
                                this._offsetsCache[keyOffset] = ((Vector3)toValue).subtract((Vector3)fromValue);
                                break;
                            case Animation._ANIMATIONTYPE_COLOR3:
                                this._offsetsCache[keyOffset] = ((Color3)toValue).subtract((Color3)fromValue);
                                break;
                            default:
                                break;
                        }
                        this._highLimitsCache[keyOffset] = toValue;
                    }
                    highLimitValue = this._highLimitsCache[keyOffset];
                    offsetValue = this._offsetsCache[keyOffset];
                }
            }
            var repeatCount = (int)(ratio / range);
            var currentFrame = (int) ((returnValue) ? from + ratio % range : to);
            var currentValue = this._interpolate(currentFrame, repeatCount, this.loopMode, offsetValue, highLimitValue);
            if (this.targetPropertyPath.Length > 1)
            {
                var property = this._target[this.targetPropertyPath[0]];
                for (var index = 1; index < this.targetPropertyPath.Length - 1; index++)
                {
                    property = property[this.targetPropertyPath[index]];
                }
                property[this.targetPropertyPath[this.targetPropertyPath.Length - 1]].value = currentValue;
            }
            else
            {
                this._target[this.targetPropertyPath[0]].value = currentValue;
            }
            this._target.markAsDirty(this.targetProperty);
            if (!returnValue)
            {
                this._stopped = true;
            }
            return returnValue;
        }
        private const int _ANIMATIONTYPE_FLOAT = 0;
        private const int _ANIMATIONTYPE_VECTOR3 = 1;
        private const int _ANIMATIONTYPE_QUATERNION = 2;
        private const int _ANIMATIONTYPE_MATRIX = 3;
        private const int _ANIMATIONTYPE_COLOR3 = 4;
        private const int _ANIMATIONLOOPMODE_RELATIVE = 0;
        private const int _ANIMATIONLOOPMODE_CYCLE = 1;
        private const int _ANIMATIONLOOPMODE_CONSTANT = 2;
        public static int ANIMATIONTYPE_FLOAT
        {
            get
            {
                return Animation._ANIMATIONTYPE_FLOAT;
            }
        }
        public static int ANIMATIONTYPE_VECTOR3
        {
            get
            {
                return Animation._ANIMATIONTYPE_VECTOR3;
            }
        }
        public static int ANIMATIONTYPE_QUATERNION
        {
            get
            {
                return Animation._ANIMATIONTYPE_QUATERNION;
            }
        }
        public static int ANIMATIONTYPE_MATRIX
        {
            get
            {
                return Animation._ANIMATIONTYPE_MATRIX;
            }
        }
        public static int ANIMATIONTYPE_COLOR3
        {
            get
            {
                return Animation._ANIMATIONTYPE_COLOR3;
            }
        }
        public static int ANIMATIONLOOPMODE_RELATIVE
        {
            get
            {
                return Animation._ANIMATIONLOOPMODE_RELATIVE;
            }
        }
        public static int ANIMATIONLOOPMODE_CYCLE
        {
            get
            {
                return Animation._ANIMATIONLOOPMODE_CYCLE;
            }
        }
        public static int ANIMATIONLOOPMODE_CONSTANT
        {
            get
            {
                return Animation._ANIMATIONLOOPMODE_CONSTANT;
            }
        }
    }
}