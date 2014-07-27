using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Animatable {
private float _localDelayOffset;
private dynamic _animations=new Array();
private dynamic _paused=false;
private Scene _scene;
public dynamic animationStarted=false;
public dynamic target;
public float fromFrame;
public float toFrame;
public bool loopAnimation;
public float speedRatio;
public dynamic onAnimationEnd;
public Animatable(Scene scene, dynamic target, float fromFrame, float toFrame, bool loopAnimation, float speedRatio, dynamic onAnimationEnd, object animations) {
if (animations) 
{
this.appendAnimations(target, animations);
}
this._scene=scene;
scene._activeAnimatables.push(this);
}
public virtual void appendAnimations(object target, Animation[] animations) {
for (var index = 0;index<animations.length;index++) 
{
var animation = animations[index];
animation._target=target;
this._animations.push(animation);
}
}
public virtual void getAnimationByTargetProperty(string property) {
var animations = this._animations;
for (var index = 0;index<animations.length;index++) 
{
if (animations[index].targetProperty==property) 
{
return animations[index];
}
}
return null;
}
public virtual void pause() {
this._paused=true;
}
public virtual void restart() {
this._paused=false;
}
public virtual void stop() {
var index = this._scene._activeAnimatables.indexOf(this);
if (index>-1) 
{
this._scene._activeAnimatables.splice(index, 1);
}
if (this.onAnimationEnd) 
{
this.onAnimationEnd();
}
}
public virtual bool _animate(float delay) {
if (this._paused) 
{
return true;
}
if (!this._localDelayOffset) 
{
this._localDelayOffset=delay;
}
var running = false;
var animations = this._animations;
for (var index = 0;index<animations.length;index++) 
{
var animation = animations[index];
var isRunning = animation.animate(delay-this._localDelayOffset, this.fromFrame, this.toFrame, this.loopAnimation, this.speedRatio);
running=running||isRunning;
}
if (!running&&this.onAnimationEnd) 
{
this.onAnimationEnd();
}
return running;
}
}
}
