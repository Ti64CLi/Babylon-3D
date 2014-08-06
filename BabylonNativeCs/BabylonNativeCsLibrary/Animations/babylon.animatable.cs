// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.animatable.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class Animatable
    {
        /// <summary>
        /// </summary>
        public bool animationStarted = false;

        /// <summary>
        /// </summary>
        public int fromFrame;

        /// <summary>
        /// </summary>
        public bool loopAnimation;

        /// <summary>
        /// </summary>
        public System.Action onAnimationEnd;

        /// <summary>
        /// </summary>
        public double speedRatio;

        /// <summary>
        /// </summary>
        public IAnimatable target;

        /// <summary>
        /// </summary>
        public int toFrame;

        /// <summary>
        /// </summary>
        private readonly Array<Animation> _animations = new Array<Animation>();

        /// <summary>
        /// </summary>
        private int _localDelayOffset;

        /// <summary>
        /// </summary>
        private bool _paused;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        /// <param name="target">
        /// </param>
        /// <param name="fromFrame">
        /// </param>
        /// <param name="toFrame">
        /// </param>
        /// <param name="loopAnimation">
        /// </param>
        /// <param name="speedRatio">
        /// </param>
        /// <param name="onAnimationEnd">
        /// </param>
        /// <param name="animations">
        /// </param>
        public Animatable(
            Scene scene, 
            IAnimatable target, 
            int fromFrame = 0, 
            int toFrame = 100, 
            bool loopAnimation = false, 
            double speedRatio = 1.0, 
            System.Action onAnimationEnd = null, 
            Array<Animation> animations = null)
        {
            this.fromFrame = fromFrame;
            this.toFrame = toFrame;
            this.loopAnimation = loopAnimation;
            this.speedRatio = speedRatio;
            this.onAnimationEnd = onAnimationEnd;

            if (animations != null)
            {
                this.appendAnimations(target, animations);
            }

            this._scene = scene;
            scene._activeAnimatables.Add(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="delay">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _animate(int delay)
        {
            if (this._paused)
            {
                return true;
            }

            if (this._localDelayOffset == 0.0)
            {
                this._localDelayOffset = delay;
            }

            var running = false;
            var animations = this._animations;
            for (var index = 0; index < animations.Length; index++)
            {
                var animation = animations[index];
                var isRunning = animation.animate(delay - this._localDelayOffset, this.fromFrame, this.toFrame, this.loopAnimation, this.speedRatio);
                running = running || isRunning;
            }

            if (!running && this.onAnimationEnd != null)
            {
                this.onAnimationEnd();
            }

            return running;
        }

        /// <summary>
        /// </summary>
        /// <param name="target">
        /// </param>
        /// <param name="animations">
        /// </param>
        public virtual void appendAnimations(IAnimatable target, Array<Animation> animations)
        {
            for (var index = 0; index < animations.Length; index++)
            {
                var animation = animations[index];
                animation._target = target;
                this._animations.Add(animation);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="property">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Animation getAnimationByTargetProperty(string property)
        {
            var animations = this._animations;
            for (var index = 0; index < animations.Length; index++)
            {
                if (animations[index].targetProperty == property)
                {
                    return animations[index];
                }
            }

            return null;
        }

        /// <summary>
        /// </summary>
        public virtual void pause()
        {
            this._paused = true;
        }

        /// <summary>
        /// </summary>
        public virtual void restart()
        {
            this._paused = false;
        }

        /// <summary>
        /// </summary>
        public virtual void stop()
        {
            var index = this._scene._activeAnimatables.IndexOf(this);
            if (index > -1)
            {
                this._scene._activeAnimatables.RemoveAt(index);
            }

            if (this.onAnimationEnd != null)
            {
                this.onAnimationEnd();
            }
        }
    }
}