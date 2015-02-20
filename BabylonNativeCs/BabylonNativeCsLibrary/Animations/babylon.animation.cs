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
        private Map<string, object> _highLimitsCache = new Map<string, object>();

        /// <summary>
        /// </summary>
        private Array<AnimationKey> _keys;

        /// <summary>
        /// </summary>
        private Map<string, object> _offsetsCache = new Map<string, object>();

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
                            case ANIMATIONTYPE_FLOAT:
                                this._offsetsCache[keyOffset] = (double)toValue - (double)fromValue;
                                break;
                            case ANIMATIONTYPE_QUATERNION:
                                this._offsetsCache[keyOffset] = ((Quaternion)toValue).subtract((Quaternion)fromValue);
                                break;
                            case ANIMATIONTYPE_VECTOR3:
                                this._offsetsCache[keyOffset] = ((Vector3)toValue).subtract((Vector3)fromValue);
                                break;
                            case ANIMATIONTYPE_COLOR3:
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
                var property = this._target[this.targetPropertyPath[0]] as IAnimatable;
                for (var index = 1; index < this.targetPropertyPath.Length - 1; index++)
                {
                    property = property[this.targetPropertyPath[index]] as IAnimatable;
                }

                property[this.targetPropertyPath[this.targetPropertyPath.Length - 1]] = currentValue;
            }
            else
            {
                this._target[this.targetPropertyPath[0]] = currentValue;
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
            this._offsetsCache = new Map<string, object>();
            this._highLimitsCache = new Map<string, object>();
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
                        case ANIMATIONTYPE_FLOAT:
                            switch (loopMode)
                            {
                                case ANIMATIONLOOPMODE_CYCLE:
                                case ANIMATIONLOOPMODE_CONSTANT:
                                    return this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                                case ANIMATIONLOOPMODE_RELATIVE:
                                    return (double)offsetValue * repeatCount + this.floatInterpolateFunction((double)startValue, (double)endValue, gradient);
                            }

                            break;
                        case ANIMATIONTYPE_QUATERNION:
                            Quaternion quaternion = null;
                            switch (loopMode)
                            {
                                case ANIMATIONLOOPMODE_CYCLE:
                                case ANIMATIONLOOPMODE_CONSTANT:
                                    quaternion = this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, gradient);
                                    break;
                                case ANIMATIONLOOPMODE_RELATIVE:
                                    quaternion =
                                        this.quaternionInterpolateFunction((Quaternion)startValue, (Quaternion)endValue, gradient)
                                            .add(((Quaternion)offsetValue).scale(repeatCount));
                                    break;
                            }

                            return quaternion;
                        case ANIMATIONTYPE_VECTOR3:
                            switch (loopMode)
                            {
                                case ANIMATIONLOOPMODE_CYCLE:
                                case ANIMATIONLOOPMODE_CONSTANT:
                                    return this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient);
                                case ANIMATIONLOOPMODE_RELATIVE:
                                    return
                                        this.vector3InterpolateFunction((Vector3)startValue, (Vector3)endValue, gradient)
                                            .add(((Vector3)offsetValue).scale(repeatCount));
                            }

                            break;
                        case ANIMATIONTYPE_COLOR3:
                            switch (loopMode)
                            {
                                case ANIMATIONLOOPMODE_CYCLE:
                                case ANIMATIONLOOPMODE_CONSTANT:
                                    return this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient);
                                case ANIMATIONLOOPMODE_RELATIVE:
                                    return
                                        this.color3InterpolateFunction((Color3)startValue, (Color3)endValue, gradient)
                                            .add(((Color3)offsetValue).scale(repeatCount));
                            }

                            break;
                        case ANIMATIONTYPE_MATRIX:
                            switch (loopMode)
                            {
                                case ANIMATIONLOOPMODE_CYCLE:
                                case ANIMATIONLOOPMODE_CONSTANT:
                                case ANIMATIONLOOPMODE_RELATIVE:
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
        public const int ANIMATIONTYPE_FLOAT = 0;

        /// <summary>
        /// </summary>
        public const int ANIMATIONTYPE_VECTOR3 = 1;

        /// <summary>
        /// </summary>
        public const int ANIMATIONTYPE_QUATERNION = 2;

        /// <summary>
        /// </summary>
        public const int ANIMATIONTYPE_MATRIX = 3;

        /// <summary>
        /// </summary>
        public const int ANIMATIONTYPE_COLOR3 = 4;

        /// <summary>
        /// </summary>
        public const int ANIMATIONLOOPMODE_RELATIVE = 0;

        /// <summary>
        /// </summary>
        public const int ANIMATIONLOOPMODE_CYCLE = 1;

        /// <summary>
        /// </summary>
        public const int ANIMATIONLOOPMODE_CONSTANT = 2;
    }
}