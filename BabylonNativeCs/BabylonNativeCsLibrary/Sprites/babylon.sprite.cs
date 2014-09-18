// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.sprite.cs" company="">
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
    public partial class Sprite
    {
        /// <summary>
        /// </summary>
        public double angle = 0;

        /// <summary>
        /// </summary>
        public Array<Animation> animations = new Array<Animation>();

        /// <summary>
        /// </summary>
        public int cellIndex = 0;

        /// <summary>
        /// </summary>
        public Color4 color = new Color4(1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        public System.Action disposeWhenFinishedAnimating;

        /// <summary>
        /// </summary>
        public bool invertU = false;

        /// <summary>
        /// </summary>
        public bool invertV = false;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public Vector3 position;

        /// <summary>
        /// </summary>
        public double size = 1.0;

        /// <summary>
        /// </summary>
        private bool _animationStarted;

        /// <summary>
        /// </summary>
        private double _delay;

        /// <summary>
        /// </summary>
        private int _direction = 1;

        /// <summary>
        /// </summary>
        private int _fromIndex;

        /// <summary>
        /// </summary>
        private bool _loopAnimation;

        /// <summary>
        /// </summary>
        private readonly SpriteManager _manager;

        /// <summary>
        /// </summary>
        private double _time;

        /// <summary>
        /// </summary>
        private int _toIndex;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="manager">
        /// </param>
        public Sprite(string name, SpriteManager manager)
        {
            this.name = name;
            this._manager = manager;
            this._manager.sprites.Add(this);
            this.position = Vector3.Zero();
        }

        /// <summary>
        /// </summary>
        /// <param name="deltaTime">
        /// </param>
        public virtual void _animate(double deltaTime)
        {
            if (!this._animationStarted)
            {
                return;
            }

            this._time += deltaTime;
            if (this._time > this._delay)
            {
                this._time = this._time % this._delay;
                this.cellIndex += this._direction;
                if (this.cellIndex == this._toIndex)
                {
                    if (this._loopAnimation)
                    {
                        this.cellIndex = this._fromIndex;
                    }
                    else
                    {
                        this._animationStarted = false;
                        if (this.disposeWhenFinishedAnimating != null)
                        {
                            this.dispose();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            for (var i = 0; i < this._manager.sprites.Length; i++)
            {
                if (this._manager.sprites[i] == this)
                {
                    this._manager.sprites.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="from">
        /// </param>
        /// <param name="to">
        /// </param>
        /// <param name="loop">
        /// </param>
        /// <param name="delay">
        /// </param>
        public virtual void playAnimation(int from, int to, bool loop, double delay)
        {
            this._fromIndex = from;
            this._toIndex = to;
            this._loopAnimation = loop;
            this._delay = delay;
            this._animationStarted = true;
            this._direction = (from < to) ? 1 : -1;
            this.cellIndex = from;
            this._time = 0;
        }

        /// <summary>
        /// </summary>
        public virtual void stopAnimation()
        {
            this._animationStarted = false;
        }
    }
}