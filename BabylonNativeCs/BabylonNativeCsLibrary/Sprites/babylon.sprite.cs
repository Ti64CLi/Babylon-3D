using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Sprite {
public Vector3 position;
dynamic color=new BABYLON.Color4(1.0, 1.0, 1.0, 1.0);
dynamic size=1.0;
dynamic angle=0;
dynamic cellIndex=0;
dynamic invertU=0;
dynamic invertV=0;
public Func<object> disposeWhenFinishedAnimating;
dynamic animations=new Array();
dynamic _animationStarted=false;
dynamic _loopAnimation=false;
dynamic _fromIndex=0;
dynamic _toIndex=0;
dynamic _delay=0;
dynamic _direction=1;
dynamic _frameCount=0;
private SpriteManager _manager;
dynamic _time=0;
public string name;
public Sprite(string name, SpriteManager manager) {
this._manager=manager;
this._manager.sprites.push(this);
this.position=BABYLON.Vector3.Zero();
}
public virtual void playAnimation(float from, float to, bool loop, float delay) {
this._fromIndex=from;
this._toIndex=to;
this._loopAnimation=loop;
this._delay=delay;
this._animationStarted=true;
this._direction=(from<to) ? 1 : -1;
this.cellIndex=from;
this._time=0;
}
public virtual void stopAnimation() {
this._animationStarted=false;
}
public virtual void _animate(float deltaTime) {
if (!this._animationStarted) 
return;
this._time+=deltaTime;
if (this._time>this._delay) 
{
this._time=this._time%this._delay;
this.cellIndex+=this._direction;
if (this.cellIndex==this._toIndex) 
{
if (this._loopAnimation) 
{
this.cellIndex=this._fromIndex;
}
else 
{
this._animationStarted=false;
if (this.disposeWhenFinishedAnimating) 
{
this.dispose();
}
}
}
}
}
public virtual void dispose() {
for (var i = 0;i<this._manager.sprites.length;i++) 
{
if (this._manager.sprites[i]==this) 
{
this._manager.sprites.splice(i, 1);
}
}
}
}
}
