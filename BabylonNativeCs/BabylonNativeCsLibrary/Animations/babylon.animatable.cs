using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Animatable {
        private double _localDelayOffset;
        private Array < Animation > _animations = new Array < Animation > ();
        private bool _paused = false;
        private Scene _scene;
        public bool animationStarted = false;
        public dynamic target;
        public double fromFrame;
        public double toFrame;
        public bool loopAnimation;
        public double speedRatio;
        public dynamic onAnimationEnd;
        public Animatable(Scene scene, object target, double fromFrame = 0, double toFrame = 100, bool loopAnimation = false, double speedRatio = 1.0, object onAnimationEnd = null, object animations = null) {
            if (animations) {
                this.appendAnimations(target, animations);
            }
            this._scene = scene;
            scene._activeAnimatables.push(this);
        }
        public virtual void appendAnimations(object target, Array < Animation > animations) {
            for (var index = 0; index < animations.Length; index++) {
                var animation = animations[index];
                animation._target = target;
                this._animations.push(animation);
            }
        }
        public virtual void getAnimationByTargetProperty(string property) {
            var animations = this._animations;
            for (var index = 0; index < animations.Length; index++) {
                if (animations[index].targetProperty == property) {
                    return animations[index];
                }
            }
            return null;
        }
        public virtual void pause() {
            this._paused = true;
        }
        public virtual void restart() {
            this._paused = false;
        }
        public virtual void stop() {
            var index = this._scene._activeAnimatables.indexOf(this);
            if (index > -1) {
                this._scene._activeAnimatables.splice(index, 1);
            }
            if (this.onAnimationEnd) {
                this.onAnimationEnd();
            }
        }
        public virtual bool _animate(double delay) {
            if (this._paused) {
                return true;
            }
            if (!this._localDelayOffset) {
                this._localDelayOffset = delay;
            }
            var running = false;
            var animations = this._animations;
            for (var index = 0; index < animations.Length; index++) {
                var animation = animations[index];
                var isRunning = animation.animate(delay - this._localDelayOffset, this.fromFrame, this.toFrame, this.loopAnimation, this.speedRatio);
                running = running || isRunning;
            }
            if (!running && this.onAnimationEnd) {
                this.onAnimationEnd();
            }
            return running;
        }
    }
}