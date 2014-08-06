using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Sprite {
        public Vector3 position;
        public BABYLON.Color4 color = new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
        public double size = 1.0;
        public double angle = 0;
        public int cellIndex = 0;
        public bool invertU = false;
        public bool invertV = false;
        public System.Action disposeWhenFinishedAnimating;
        public Array < Animation > animations = new Array < Animation > ();
        private bool _animationStarted = false;
        private bool _loopAnimation = false;
        private int _fromIndex = 0;
        private int _toIndex = 0;
        private double _delay = 0;
        private int _direction = 1;
        private SpriteManager _manager;
        private double _time = 0;
        public string name;
        public Sprite(string name, SpriteManager manager)
        {
            this.name = name;
            this._manager = manager;
            this._manager.sprites.Add(this);
            this.position = BABYLON.Vector3.Zero();
        }
        public virtual void playAnimation(int from, int to, bool loop, double delay) {
            this._fromIndex = from;
            this._toIndex = to;
            this._loopAnimation = loop;
            this._delay = delay;
            this._animationStarted = true;
            this._direction = (from < to) ? 1 : -1;
            this.cellIndex = from;
            this._time = 0;
        }
        public virtual void stopAnimation() {
            this._animationStarted = false;
        }
        public virtual void _animate(double deltaTime) {
            if (!this._animationStarted)
                return;
            this._time += deltaTime;
            if (this._time > this._delay) {
                this._time = this._time % this._delay;
                this.cellIndex += this._direction;
                if (this.cellIndex == this._toIndex) {
                    if (this._loopAnimation) {
                        this.cellIndex = this._fromIndex;
                    } else {
                        this._animationStarted = false;
                        if (this.disposeWhenFinishedAnimating != null) {
                            this.dispose();
                        }
                    }
                }
            }
        }
        public virtual void dispose() {
            for (var i = 0; i < this._manager.sprites.Length; i++) {
                if (this._manager.sprites[i] == this) {
                    this._manager.sprites.RemoveAt(i);
                }
            }
        }
    }
}