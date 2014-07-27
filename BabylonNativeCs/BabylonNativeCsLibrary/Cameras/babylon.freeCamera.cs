using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class FreeCamera: Camera {
public dynamic cameraDirection=new BABYLON.Vector3(0, 0, 0);
public dynamic cameraRotation=new BABYLON.Vector2(0, 0);
public dynamic rotation=new BABYLON.Vector3(0, 0, 0);
public dynamic ellipsoid=new BABYLON.Vector3(0.5, 1, 0.5);
public dynamic keysUp=new Array<object>();
public dynamic keysDown=new Array<object>();
public dynamic keysLeft=new Array<object>();
public dynamic keysRight=new Array<object>();
public dynamic speed=2.0;
public dynamic checkCollisions=false;
public dynamic applyGravity=false;
public dynamic noRotationConstraint=false;
public dynamic angularSensibility=2000.0;
public dynamic lockedTarget=null;
public dynamic onCollide=null;
private dynamic _keys=new Array<object>();
private dynamic _collider=new Collider();
private dynamic _needMoveForGravity=true;
public dynamic _currentTarget=BABYLON.Vector3.Zero();
public dynamic _viewMatrix=BABYLON.Matrix.Zero();
private dynamic _camMatrix=BABYLON.Matrix.Zero();
private dynamic _cameraTransformMatrix=BABYLON.Matrix.Zero();
public dynamic _cameraRotationMatrix=BABYLON.Matrix.Zero();
public dynamic _referencePoint=new BABYLON.Vector3(0, 0, 1);
public dynamic _transformedReferencePoint=BABYLON.Vector3.Zero();
private dynamic _oldPosition=BABYLON.Vector3.Zero();
private dynamic _diffPosition=BABYLON.Vector3.Zero();
private dynamic _newPosition=BABYLON.Vector3.Zero();
private dynamic _lookAtTemp=BABYLON.Matrix.Zero();
private dynamic _tempMatrix=BABYLON.Matrix.Zero();
private HTMLElement _attachedElement;
private Vector3 _localDirection;
private Vector3 _transformedDirection;
private Func<MouseEvent, object> _onMouseDown;
private Func<MouseEvent, object> _onMouseUp;
private Func<MouseEvent, object> _onMouseOut;
private Func<MouseEvent, object> _onMouseMove;
private Func<KeyboardEvent, object> _onKeyDown;
private Func<KeyboardEvent, object> _onKeyUp;
public Func<FocusEvent, object> _onLostFocus;
private Func<object> _reset;
public string _waitingLockedTargetId;
public FreeCamera(string name, Vector3 position, Scene scene) {
base(name, position, scene);
}
public virtual Vector3 _getLockedTargetPosition() {
if (!this.lockedTarget) 
{
return null;
}
return this.lockedTarget.position||this.lockedTarget;
}
public virtual void _initCache() {
base._initCache();
this._cache.lockedTarget=new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
this._cache.rotation=new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
}
public virtual void _updateCache(bool ignoreParentClass) {
if (!ignoreParentClass) 
{
base._updateCache();
}
var lockedTargetPosition = this._getLockedTargetPosition();
if (!lockedTargetPosition) 
{
this._cache.lockedTarget=null;
}
else 
{
if (!this._cache.lockedTarget) 
{
this._cache.lockedTarget=lockedTargetPosition.clone();
}
else 
{
this._cache.lockedTarget.copyFrom(lockedTargetPosition);
}
}
this._cache.rotation.copyFrom(this.rotation);
}
public virtual bool _isSynchronizedViewMatrix() {
if (!base._isSynchronizedViewMatrix()) 
{
return false;
}
var lockedTargetPosition = this._getLockedTargetPosition();
return ((this._cache.lockedTarget) ? this._cache.lockedTarget.equals(lockedTargetPosition) : !lockedTargetPosition)&&this._cache.rotation.equals(this.rotation);
}
public virtual float _computeLocalCameraSpeed() {
return this.speed*((BABYLON.Tools.GetDeltaTime()/(BABYLON.Tools.GetFps()*10.0)));
}
public virtual void setTarget(Vector3 target) {
this.upVector.normalize();
BABYLON.Matrix.LookAtLHToRef(this.position, target, this.upVector, this._camMatrix);
this._camMatrix.invert();
this.rotation.x=Math.atan(this._camMatrix.m[6]/this._camMatrix.m[10]);
var vDir = target.subtract(this.position);
if (vDir.x>=0.0) 
{
this.rotation.y=(-Math.atan(vDir.z/vDir.x)+Math.PI/2.0);
}
else 
{
this.rotation.y=(-Math.atan(vDir.z/vDir.x)-Math.PI/2.0);
}
this.rotation.z=-Math.acos(BABYLON.Vector3.Dot(new BABYLON.Vector3(0, 1.0, 0), this.upVector));
if (isNaN(this.rotation.x)) 
{
this.rotation.x=0;
}
if (isNaN(this.rotation.y)) 
{
this.rotation.y=0;
}
if (isNaN(this.rotation.z)) 
{
this.rotation.z=0;
}
}
public virtual Vector3 getTarget() {
return this._currentTarget;
}
public virtual void attachControl(HTMLElement element, bool noPreventDefault) {
var previousPosition;
var engine = this.getEngine();
if (this._attachedElement) 
{
return;
}
this._attachedElement=element;
if (this._onMouseDown==undefined) 
{
this._onMouseDown=(dynamic evt) => {
previousPosition=new dynamic();
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
;
this._onMouseUp=(dynamic evt) => {
previousPosition=null;
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
;
this._onMouseOut=(dynamic evt) => {
previousPosition=null;
this._keys=new Array<object>();
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
;
this._onMouseMove=(dynamic evt) => {
if (!previousPosition&&!engine.isPointerLock) 
{
return;
}
var offsetX;
var offsetY;
if (!engine.isPointerLock) 
{
offsetX=evt.clientX-previousPosition.x;
offsetY=evt.clientY-previousPosition.y;
}
else 
{
offsetX=evt.movementX||evt.mozMovementX||evt.webkitMovementX||evt.msMovementX||0;
offsetY=evt.movementY||evt.mozMovementY||evt.webkitMovementY||evt.msMovementY||0;
}
this.cameraRotation.y+=offsetX/this.angularSensibility;
this.cameraRotation.x+=offsetY/this.angularSensibility;
previousPosition=new dynamic();
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
;
this._onKeyDown=(dynamic evt) => {
if (this.keysUp.indexOf(evt.keyCode)!=-1||this.keysDown.indexOf(evt.keyCode)!=-1||this.keysLeft.indexOf(evt.keyCode)!=-1||this.keysRight.indexOf(evt.keyCode)!=-1) 
{
var index = this._keys.indexOf(evt.keyCode);
if (index==-1) 
{
this._keys.push(evt.keyCode);
}
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
}
;
this._onKeyUp=(dynamic evt) => {
if (this.keysUp.indexOf(evt.keyCode)!=-1||this.keysDown.indexOf(evt.keyCode)!=-1||this.keysLeft.indexOf(evt.keyCode)!=-1||this.keysRight.indexOf(evt.keyCode)!=-1) 
{
var index = this._keys.indexOf(evt.keyCode);
if (index>=0) 
{
this._keys.splice(index, 1);
}
if (!noPreventDefault) 
{
evt.preventDefault();
}
}
}
;
this._onLostFocus=() => {
this._keys=new Array<object>();
}
;
this._reset=() => {
this._keys=new Array<object>();
previousPosition=null;
this.cameraDirection=new BABYLON.Vector3(0, 0, 0);
this.cameraRotation=new BABYLON.Vector2(0, 0);
}
;
}
element.addEventListener("mousedow", this._onMouseDown, false);
element.addEventListener("mouseu", this._onMouseUp, false);
element.addEventListener("mouseou", this._onMouseOut, false);
element.addEventListener("mousemov", this._onMouseMove, false);
Tools.RegisterTopRootEvents(new Array<object>());
}
public virtual void detachControl(HTMLElement element) {
if (this._attachedElement!=element) 
{
return;
}
element.removeEventListener("mousedow", this._onMouseDown);
element.removeEventListener("mouseu", this._onMouseUp);
element.removeEventListener("mouseou", this._onMouseOut);
element.removeEventListener("mousemov", this._onMouseMove);
Tools.UnregisterTopRootEvents(new Array<object>());
this._attachedElement=null;
if (this._reset) 
{
this._reset();
}
}
public virtual void _collideWithWorld(Vector3 velocity) {
var globalPosition;
if (this.parent) 
{
globalPosition=BABYLON.Vector3.TransformCoordinates(this.position, this.parent.getWorldMatrix());
}
else 
{
globalPosition=this.position;
}
globalPosition.subtractFromFloatsToRef(0, this.ellipsoid.y, 0, this._oldPosition);
this._collider.radius=this.ellipsoid;
this.getScene()._getNewPosition(this._oldPosition, velocity, this._collider, 3, this._newPosition);
this._newPosition.subtractToRef(this._oldPosition, this._diffPosition);
if (this._diffPosition.length()>Engine.CollisionsEpsilon) 
{
this.position.addInPlace(this._diffPosition);
if (this.onCollide) 
{
this.onCollide(this._collider.collidedMesh);
}
}
}
public virtual void _checkInputs() {
if (!this._localDirection) 
{
this._localDirection=BABYLON.Vector3.Zero();
this._transformedDirection=BABYLON.Vector3.Zero();
}
for (var index = 0;index<this._keys.length;index++) 
{
var keyCode = this._keys[index];
var speed = this._computeLocalCameraSpeed();
if (this.keysLeft.indexOf(keyCode)!=-1) 
{
this._localDirection.copyFromFloats(-speed, 0, 0);
}
else 
if (this.keysUp.indexOf(keyCode)!=-1) 
{
this._localDirection.copyFromFloats(0, 0, speed);
}
else 
if (this.keysRight.indexOf(keyCode)!=-1) 
{
this._localDirection.copyFromFloats(speed, 0, 0);
}
else 
if (this.keysDown.indexOf(keyCode)!=-1) 
{
this._localDirection.copyFromFloats(0, 0, -speed);
}
this.getViewMatrix().invertToRef(this._cameraTransformMatrix);
BABYLON.Vector3.TransformNormalToRef(this._localDirection, this._cameraTransformMatrix, this._transformedDirection);
this.cameraDirection.addInPlace(this._transformedDirection);
}
}
public virtual void _update() {
this._checkInputs();
var needToMove = this._needMoveForGravity||Math.abs(this.cameraDirection.x)>0||Math.abs(this.cameraDirection.y)>0||Math.abs(this.cameraDirection.z)>0;
var needToRotate = Math.abs(this.cameraRotation.x)>0||Math.abs(this.cameraRotation.y)>0;
if (needToMove) 
{
if (this.checkCollisions&&this.getScene().collisionsEnabled) 
{
this._collideWithWorld(this.cameraDirection);
if (this.applyGravity) 
{
var oldPosition = this.position;
this._collideWithWorld(this.getScene().gravity);
this._needMoveForGravity=(BABYLON.Vector3.DistanceSquared(oldPosition, this.position)!=0);
}
}
else 
{
this.position.addInPlace(this.cameraDirection);
}
}
if (needToRotate) 
{
this.rotation.x+=this.cameraRotation.x;
this.rotation.y+=this.cameraRotation.y;
if (!this.noRotationConstraint) 
{
var limit = (Math.PI/2)*0.95;
if (this.rotation.x>limit) 
this.rotation.x=limit;
if (this.rotation.x<-limit) 
this.rotation.x=-limit;
}
}
if (needToMove) 
{
if (Math.abs(this.cameraDirection.x)<BABYLON.Engine.Epsilon) 
{
this.cameraDirection.x=0;
}
if (Math.abs(this.cameraDirection.y)<BABYLON.Engine.Epsilon) 
{
this.cameraDirection.y=0;
}
if (Math.abs(this.cameraDirection.z)<BABYLON.Engine.Epsilon) 
{
this.cameraDirection.z=0;
}
this.cameraDirection.scaleInPlace(this.inertia);
}
if (needToRotate) 
{
if (Math.abs(this.cameraRotation.x)<BABYLON.Engine.Epsilon) 
{
this.cameraRotation.x=0;
}
if (Math.abs(this.cameraRotation.y)<BABYLON.Engine.Epsilon) 
{
this.cameraRotation.y=0;
}
this.cameraRotation.scaleInPlace(this.inertia);
}
}
public virtual Matrix _getViewMatrix() {
if (!this.lockedTarget) 
{
if (this.upVector.x!=0||this.upVector.y!=1.0||this.upVector.z!=0) 
{
BABYLON.Matrix.LookAtLHToRef(BABYLON.Vector3.Zero(), this._referencePoint, this.upVector, this._lookAtTemp);
BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
this._lookAtTemp.multiplyToRef(this._cameraRotationMatrix, this._tempMatrix);
this._lookAtTemp.invert();
this._tempMatrix.multiplyToRef(this._lookAtTemp, this._cameraRotationMatrix);
}
else 
{
BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
}
BABYLON.Vector3.TransformCoordinatesToRef(this._referencePoint, this._cameraRotationMatrix, this._transformedReferencePoint);
this.position.addToRef(this._transformedReferencePoint, this._currentTarget);
}
else 
{
this._currentTarget.copyFrom(this._getLockedTargetPosition());
}
BABYLON.Matrix.LookAtLHToRef(this.position, this._currentTarget, this.upVector, this._viewMatrix);
return this._viewMatrix;
}
}
}
