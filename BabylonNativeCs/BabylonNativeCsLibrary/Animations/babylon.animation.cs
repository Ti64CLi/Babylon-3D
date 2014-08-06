// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.animation.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System.Collections.Generic;

    /// <summary>
    /// </summary>
    public partial class Animation
    {
        /// <summary>
        /// </summary>
        public IAnimatable _target;

        /// <summary>
        /// </summary>
        public double currentFrame;

        /// <summary>
        /// </summary>
        public int dataType;

        /// <summary>
        /// </summary>
        public double framePerSecond;

        /// <summary>
        /// </summary>
        public int loopMode;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public string targetProperty;

        /// <summary>
        /// </summary>
        public string[] targetPropertyPath;

        /// <summary>
        /// </summary>
        private IDictionary<string, object> _highLimitsCache = new Dictionary<string, object>();

        /// <summary>
        /// </summary>
        private Array<AnimationKey> _keys;

        /// <summary>
        /// </summary>
        private IDictionary<string, object> _offsetsCache = new Dictionary<string, object>();

        /// <summary>
        /// </summary>
        private bool _stopped;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="targetProperty">
        /// </param>
        /// <param name="framePerSecond">
        /// </param>
        /// <param name="dataType">
        /// </param>
        /// <param name="loopMode">
        /// </param>
        public Animation(string name, string targetProperty, double framePerSecond, int dataType, int loopMode = 0)
        {
            this.name = name;
            this.framePerSecond = framePerSecond;
            this.targetPropertyPath = targetProperty.Split('.');
            this.dataType = dataType;
            this.loopMode = (loopMode == 0) ? ANIMATIONLOOPMODE_CYCLE : loopMode;
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONLOOPMODE_CONSTANT
        {
            get
            {
                return _ANIMATIONLOOPMODE_CONSTANT;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONLOOPMODE_CYCLE
        {
            get
            {
                return _ANIMATIONLOOPMODE_CYCLE;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONLOOPMODE_RELATIVE
        {
            get
            {
                return _ANIMATIONLOOPMODE_RELATIVE;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONTYPE_COLOR3
        {
            get
            {
                return _ANIMATIONTYPE_COLOR3;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONTYPE_FLOAT
        {
            get
            {
                return _ANIMATIONTYPE_FLOAT;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONTYPE_MATRIX
        {
            get
            {
                return _ANIMATIONTYPE_MATRIX;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONTYPE_QUATERNION
        {
            get
            {
                return _ANIMATIONTYPE_QUATERNION;
            }
        }

        /// <summary>
        /// </summary>
        public static int ANIMATIONTYPE_VECTOR3
        {
            get
            {
                return _ANIMATIONTYPE_VECTOR3;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="delay">
        /// </param>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <param name="loop">
        /// </param>
        /// <param name="speedRatio">
        /// </param>
        /// <returns>
        /// </returns>
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
                if (this.loopMode != ANIMATIONLOOPMODE_CYCLE)
                {
                    var keyOffset = to.ToString() + from.ToString();
                    if (!this._offsetsCache.ContainsKey(keyOffset))
                    {
                        var fromValue = this._interpolate(from, 0, ANIMATIONLOOPMODE_CYCLE);
                        var toValue = this._interpolate(to, 0, ANIMATIONLOOPMODE_CYCLE);
                        switch (this.dataType)
                        {
                            case _ANIMATIONTYPE_FLOAT:
                                this._offsetsCache[keyOffset] = (double)toValue - (double)fromValue;
                                break;
                            case _ANIMATIONTYPE_QUATERNION:
                                this._offsetsCache[keyOffset] = ((Quaternion)toValue).subtract((Quaternion)fromValue);
                                break;
                            case _ANIMATIONTYPE_VECTOR3:
                                this._offsetsCache[keyOffset] = ((Vector3)toValue).subtract((Vector3)fromValue);
                                break;
                            case _ANIMATIONTYPE_COLOR3:
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
            var currentFrame = (int)(returnValue ? from + ratio % range : to);
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Animation clone()
        {
            var clone = new Animation(this.name, string.Join(".", this.targetPropertyPath), this.framePerSecond, this.dataType, this.loopMode);
            clone.setKeys(this._keys);
            return clone;
        }

        /// <summary>
        /// </summary>
        /// <param name="startValue">
        /// </param>
        /// <param name="endValue">
        /// </param>
        /// <param name="gradient">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Color3 color3InterpolateFunction(Color3 startValue, Color3 endValue, double gradient)
        {
            return Color3.Lerp(startValue, endValue, gradient);
        }

        /// <summary>
        /// </summary>
        /// <param name="startValue">
        /// </param>
        /// <param name="endValue">
        /// </param>
        /// <param name="gradient">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual double floatInterpolateFunction(double startValue, double endValue, double gradient)
        {
            return startValue + (endValue - startValue) * gradient;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<AnimationKey> getKeys()
        {
            return this._keys;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isStopped()
        {
            return this._stopped;
        }

        /// <summary>
        /// </summary>
        /// <param name="startValue">
        /// </param>
        /// <param name="endValue">
        /// </param>
        /// <param name="gradient">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Quaternion quaternionInterpolateFunction(Quaternion startValue, Quaternion endValue, double gradient)
        {
            return Quaternion.Slerp(startValue, endValue, gradient);
        }

        /// <summary>
        /// </summary>
        /// <param name="values">
        /// </param>
        public virtual void setKeys(Array<AnimationKey> values)
        {
            this._keys = values.slice(0);
            this._offsetsCache = new Dictionary<string, object>();
            this._highLimitsCache = new Dictionary<string, object>();
        }

        /// <summary>
        /// </summary>
        /// <param name="startValue">
        /// </param>
        /// <param name="endValue">
        /// </param>
        /// <param name="gradient">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 vector3InterpolateFunction(Vector3 startValue, Vector3 endValue, double gradient)
        {
            return Vector3.Lerp(startValue, endValue, gradient);
        }

        /// <summary>
        /// </summary>
        /// <param name="currentFrame">
        /// </param>
        /// <param name="repeatCount">
        /// </param>
        /// <param name="loopMode">
        /// </param>
        /// <param name="offsetValue">
        /// </param>
        /// <param name="highLimitValue">
        /// </param>
        /// <returns>
        /// </returns>
        private object _interpolate(int currentFrame, int repeatCount, int loopMode, object offsetValue = null, object highLimitValue = null)
        {
            if (loopMode == ANIMATIONLOOPMODE_CONSTANT && repeatCount > 0)
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
                    var gradient = (currentFrame - this._keys[key].frame) / (double)(this._keys[key + 1].frame - this._keys[key].frame);
                    switch (this.dataType)
                    {
                        case _ANIMATIONTYPE_FLOAT:
                            switch (loopMode)
                            {
                                case _ANIMATIONLOOPMODE_CYCLE:
                                case _ANIMATIONLOOPMODE_CONSTANT:
                                    return this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                                case _ANIMATIONLOOPMODE_RELATIVE:
                                    return (double)offsetValue * repeatCount + this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                            }

                            break;
                        case _ANIMATIONTYPE_QUATERNION:
                            Quaternion quaternion = null;
                            switch (loopMode)
                            {
                                case _ANIMATIONLOOPMODE_CYCLE:
                                case _ANIMATIONLOOPMODE_CONSTANT:
                                    quaternion = this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, gradient);
                                    break;
                                case _ANIMATIONLOOPMODE_RELATIVE:
                                    quaternion =
                                        this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, gradient)
                                            .add(((Quaternion)offsetValue).scale(repeatCount));
                                    break;
                            }

                            return quaternion;
                        case _ANIMATIONTYPE_VECTOR3:
                            switch (loopMode)
                            {
                                case _ANIMATIONLOOPMODE_CYCLE:
                                case _ANIMATIONLOOPMODE_CONSTANT:
                                    return this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient);
                                case _ANIMATIONLOOPMODE_RELATIVE:
                                    return
                                        this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient)
                                            .add(((Vector3)offsetValue).scale(repeatCount));
                            }

                            break;
                        case _ANIMATIONTYPE_COLOR3:
                            switch (loopMode)
                            {
                                case _ANIMATIONLOOPMODE_CYCLE:
                                case _ANIMATIONLOOPMODE_CONSTANT:
                                    return this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient);
                                case _ANIMATIONLOOPMODE_RELATIVE:
                                    return
                                        this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient)
                                            .add(((Color3)offsetValue).scale(repeatCount));
                            }

                            break;
                        case _ANIMATIONTYPE_MATRIX:
                            switch (loopMode)
                            {
                                case _ANIMATIONLOOPMODE_CYCLE:
                                case _ANIMATIONLOOPMODE_CONSTANT:
                                case _ANIMATIONLOOPMODE_RELATIVE:
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

        /// <summary>
        /// </summary>
        private const int _ANIMATIONTYPE_FLOAT = 0;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONTYPE_VECTOR3 = 1;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONTYPE_QUATERNION = 2;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONTYPE_MATRIX = 3;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONTYPE_COLOR3 = 4;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONLOOPMODE_RELATIVE = 0;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONLOOPMODE_CYCLE = 1;

        /// <summary>
        /// </summary>
        private const int _ANIMATIONLOOPMODE_CONSTANT = 2;
    }
}