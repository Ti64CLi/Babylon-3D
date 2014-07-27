using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public enum JoystickAxis {
X,Y,Z}
public class VirtualJoystick {
public bool reverseLeftRight;
public bool reverseUpDown;
public Vector3 deltaPosition;
public bool pressed;
private static float _globalJoystickIndex=0;
private static HTMLCanvasElement vjCanvas;
private static CanvasRenderingContext2D vjCanvasContext;
private static float vjCanvasWidth;
private static float vjCanvasHeight;
private static float halfWidth;
private static float halfHeight;
private Func<object> _action;
private JoystickAxis _axisTargetedByLeftAndRight;
private JoystickAxis _axisTargetedByUpAndDown;
private float _joystickSensibility;
private float _inversedSensibility;
private float _rotationSpeed;
private float _inverseRotationSpeed;
private bool _rotateOnAxisRelativeToMesh;
private float _joystickPointerID;
private string _joystickColor;
private Vector2 _joystickPointerPos;
private Vector2 _joystickPointerStartPos;
private Vector2 _deltaJoystickVector;
private bool _leftJoystick;
private float _joystickIndex;
private BABYLON.VirtualJoystick.Collection<PointerEvent> _touches;
public VirtualJoystick(bool leftJoystick) {
if (leftJoystick) 
{
this._leftJoystick=true;
}
else 
{
this._leftJoystick=false;
}
this._joystickIndex=VirtualJoystick._globalJoystickIndex;
VirtualJoystick._globalJoystickIndex++;
this._axisTargetedByLeftAndRight=JoystickAxis.X;
this._axisTargetedByUpAndDown=JoystickAxis.Y;
this.reverseLeftRight=false;
this.reverseUpDown=false;
this._touches=new BABYLON.VirtualJoystick.Collection();
this.deltaPosition=BABYLON.Vector3.Zero();
this._joystickSensibility=25;
this._inversedSensibility=1/(this._joystickSensibility/1000);
this._rotationSpeed=25;
this._inverseRotationSpeed=1/(this._rotationSpeed/1000);
this._rotateOnAxisRelativeToMesh=false;
if (!VirtualJoystick.vjCanvas) 
{
window.addEventListener("resiz", () {
VirtualJoystick.vjCanvasWidth=window.innerWidth;
VirtualJoystick.vjCanvasHeight=window.innerHeight;
VirtualJoystick.vjCanvas.width=VirtualJoystick.vjCanvasWidth;
VirtualJoystick.vjCanvas.height=VirtualJoystick.vjCanvasHeight;
VirtualJoystick.halfWidth=VirtualJoystick.vjCanvasWidth/2;
VirtualJoystick.halfHeight=VirtualJoystick.vjCanvasHeight/2;
}
, false);
VirtualJoystick.vjCanvas=document.createElement("canva");
VirtualJoystick.vjCanvasWidth=window.innerWidth;
VirtualJoystick.vjCanvasHeight=window.innerHeight;
VirtualJoystick.vjCanvas.width=window.innerWidth;
VirtualJoystick.vjCanvas.height=window.innerHeight;
VirtualJoystick.vjCanvas.style.width="100";
VirtualJoystick.vjCanvas.style.height="100";
VirtualJoystick.vjCanvas.style.position="absolut";
VirtualJoystick.vjCanvas.style.backgroundColor="transparen";
VirtualJoystick.vjCanvas.style.top="0p";
VirtualJoystick.vjCanvas.style.left="0p";
VirtualJoystick.vjCanvas.style.zIndex="";
VirtualJoystick.vjCanvas.style.msTouchAction="non";
VirtualJoystick.vjCanvasContext=VirtualJoystick.vjCanvas.getContext("2");
VirtualJoystick.vjCanvasContext.strokeStyle="#fffff";
VirtualJoystick.vjCanvasContext.lineWidth=2;
document.body.appendChild(VirtualJoystick.vjCanvas);
}
VirtualJoystick.halfWidth=VirtualJoystick.vjCanvas.width/2;
VirtualJoystick.halfHeight=VirtualJoystick.vjCanvas.height/2;
this.pressed=false;
this._joystickColor="cya";
this._joystickPointerID=-1;
this._joystickPointerPos=new BABYLON.Vector2(0, 0);
this._joystickPointerStartPos=new BABYLON.Vector2(0, 0);
this._deltaJoystickVector=new BABYLON.Vector2(0, 0);
VirtualJoystick.vjCanvas.addEventListener("pointerdow", (dynamic evt) => {
this._onPointerDown(evt);
}
, false);
VirtualJoystick.vjCanvas.addEventListener("pointermov", (dynamic evt) => {
this._onPointerMove(evt);
}
, false);
VirtualJoystick.vjCanvas.addEventListener("pointeru", (dynamic evt) => {
this._onPointerUp(evt);
}
, false);
VirtualJoystick.vjCanvas.addEventListener("pointerou", (dynamic evt) => {
this._onPointerUp(evt);
}
, false);
VirtualJoystick.vjCanvas.addEventListener("contextmen", (dynamic evt) => {
evt.preventDefault();
}
, false);
requestAnimationFrame(() => {
this._drawVirtualJoystick();
}
);
}
public virtual void setJoystickSensibility(float newJoystickSensibility) {
this._joystickSensibility=newJoystickSensibility;
this._inversedSensibility=1/(this._joystickSensibility/1000);
}
private virtual void _onPointerDown(PointerEvent e) {
var positionOnScreenCondition;
e.preventDefault();
if (this._leftJoystick==true) 
{
positionOnScreenCondition=(e.clientX<VirtualJoystick.halfWidth);
}
else 
{
positionOnScreenCondition=(e.clientX>VirtualJoystick.halfWidth);
}
if (positionOnScreenCondition&&this._joystickPointerID<0) 
{
this._joystickPointerID=e.pointerId;
this._joystickPointerStartPos.x=e.clientX;
this._joystickPointerStartPos.y=e.clientY;
this._joystickPointerPos=this._joystickPointerStartPos.clone();
this._deltaJoystickVector.x=0;
this._deltaJoystickVector.y=0;
this.pressed=true;
this._touches.add(e.pointerId.toString(), e);
}
else 
{
if (VirtualJoystick._globalJoystickIndex<2&&this._action) 
{
this._action();
this._touches.add(e.pointerId.toString(), e);
}
}
}
private virtual void _onPointerMove(PointerEvent e) {
if (this._joystickPointerID==e.pointerId) 
{
this._joystickPointerPos.x=e.clientX;
this._joystickPointerPos.y=e.clientY;
this._deltaJoystickVector=this._joystickPointerPos.clone();
this._deltaJoystickVector=this._deltaJoystickVector.subtract(this._joystickPointerStartPos);
var directionLeftRight = (this.reverseLeftRight) ? -1 : 1;
var deltaJoystickX = directionLeftRight*this._deltaJoystickVector.x/this._inversedSensibility;
switch (this._axisTargetedByLeftAndRight) {
case JoystickAxis.X: 
this.deltaPosition.x=Math.min(1, Math.max(-1, deltaJoystickX));
break;
case JoystickAxis.Y: 
this.deltaPosition.y=Math.min(1, Math.max(-1, deltaJoystickX));
break;
case JoystickAxis.Z: 
this.deltaPosition.z=Math.min(1, Math.max(-1, deltaJoystickX));
break;
}
var directionUpDown = (this.reverseUpDown) ? 1 : -1;
var deltaJoystickY = directionUpDown*this._deltaJoystickVector.y/this._inversedSensibility;
switch (this._axisTargetedByUpAndDown) {
case JoystickAxis.X: 
this.deltaPosition.x=Math.min(1, Math.max(-1, deltaJoystickY));
break;
case JoystickAxis.Y: 
this.deltaPosition.y=Math.min(1, Math.max(-1, deltaJoystickY));
break;
case JoystickAxis.Z: 
this.deltaPosition.z=Math.min(1, Math.max(-1, deltaJoystickY));
break;
}
}
else 
{
if (this._touches.item(e.pointerId.toString())) 
{
this._touches.item(e.pointerId.toString()).x=e.clientX;
this._touches.item(e.pointerId.toString()).y=e.clientY;
}
}
}
private virtual void _onPointerUp(PointerEvent e) {
this._clearCanvas();
if (this._joystickPointerID==e.pointerId) 
{
this._joystickPointerID=-1;
this.pressed=false;
}
this._deltaJoystickVector.x=0;
this._deltaJoystickVector.y=0;
this._touches.remove(e.pointerId.toString());
}
public virtual void setJoystickColor(string newColor) {
this._joystickColor=newColor;
}
public virtual void setActionOnTouch(Func<object> action) {
this._action=action;
}
public virtual void setAxisForLeftRight(JoystickAxis axis) {
switch (axis) {
case JoystickAxis.X: 
case JoystickAxis.Y: 
case JoystickAxis.Z: 
this._axisTargetedByLeftAndRight=axis;
break;
this._axisTargetedByLeftAndRight=axis;
break;
default: 
this._axisTargetedByLeftAndRight=JoystickAxis.X;
break;
}
}
public virtual void setAxisForUpDown(JoystickAxis axis) {
switch (axis) {
case JoystickAxis.X: 
case JoystickAxis.Y: 
case JoystickAxis.Z: 
this._axisTargetedByUpAndDown=axis;
break;
default: 
this._axisTargetedByUpAndDown=JoystickAxis.Y;
break;
}
}
private virtual void _clearCanvas() {
if (this._leftJoystick) 
{
VirtualJoystick.vjCanvasContext.clearRect(0, 0, VirtualJoystick.vjCanvasWidth/2, VirtualJoystick.vjCanvasHeight);
}
else 
{
VirtualJoystick.vjCanvasContext.clearRect(VirtualJoystick.vjCanvasWidth/2, 0, VirtualJoystick.vjCanvasWidth, VirtualJoystick.vjCanvasHeight);
}
}
private virtual void _drawVirtualJoystick() {
if (this.pressed) 
{
this._clearCanvas();
this._touches.forEach((PointerEvent touch) => {
if (touch.pointerId==this._joystickPointerID) 
{
VirtualJoystick.vjCanvasContext.beginPath();
VirtualJoystick.vjCanvasContext.strokeStyle=this._joystickColor;
VirtualJoystick.vjCanvasContext.lineWidth=6;
VirtualJoystick.vjCanvasContext.arc(this._joystickPointerStartPos.x, this._joystickPointerStartPos.y, 40, 0, Math.PI*2, true);
VirtualJoystick.vjCanvasContext.stroke();
VirtualJoystick.vjCanvasContext.beginPath();
VirtualJoystick.vjCanvasContext.strokeStyle=this._joystickColor;
VirtualJoystick.vjCanvasContext.lineWidth=2;
VirtualJoystick.vjCanvasContext.arc(this._joystickPointerStartPos.x, this._joystickPointerStartPos.y, 60, 0, Math.PI*2, true);
VirtualJoystick.vjCanvasContext.stroke();
VirtualJoystick.vjCanvasContext.beginPath();
VirtualJoystick.vjCanvasContext.strokeStyle=this._joystickColor;
VirtualJoystick.vjCanvasContext.arc(this._joystickPointerPos.x, this._joystickPointerPos.y, 40, 0, Math.PI*2, true);
VirtualJoystick.vjCanvasContext.stroke();
}
else 
{
VirtualJoystick.vjCanvasContext.beginPath();
VirtualJoystick.vjCanvasContext.fillStyle="whit";
VirtualJoystick.vjCanvasContext.beginPath();
VirtualJoystick.vjCanvasContext.strokeStyle="re";
VirtualJoystick.vjCanvasContext.lineWidth=6;
VirtualJoystick.vjCanvasContext.arc(touch.x, touch.y, 40, 0, Math.PI*2, true);
VirtualJoystick.vjCanvasContext.stroke();
}
;
}
);
}
requestAnimationFrame(() => {
this._drawVirtualJoystick();
}
);
}
public virtual void releaseCanvas() {
if (VirtualJoystick.vjCanvas) 
{
document.body.removeChild(VirtualJoystick.vjCanvas);
VirtualJoystick.vjCanvas=null;
}
}
}
}
namespace BABYLON.VirtualJoystick {
public class Collection {
private float _count;
private Array<T> _collection;
public Collection() {
this._count=0;
this._collection=new Array();
}
public virtual float Count() {
return this._count;
}
public virtual float add(string key, T item) {
if (this._collection[key]!=undefined) 
{
return undefined;
}
this._collection[key]=item;
return ++this._count;
}
public virtual float remove(string key) {
if (this._collection[key]==undefined) 
{
return undefined;
}
this._collection[key] = null;
return --this._count;
}
public virtual void item(string key) {
return this._collection[key];
}
public virtual void forEach(Func<T, object> block) {
var key;
foreach (key in this._collection) 
{
if (this._collection.hasOwnProperty(key)) 
{
block(this._collection[key]);
}
}
}
}
}
