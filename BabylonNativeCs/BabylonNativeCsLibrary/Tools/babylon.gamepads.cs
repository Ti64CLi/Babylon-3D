using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Gamepads {
private Array<Gamepad> babylonGamepads=new Array<object>();
private bool oneGamepadConnected=false;
private bool isMonitoring=false;
private bool gamepadEventSupported="GamepadEven"inwindow;
private bool gamepadSupportAvailable=(bool)(navigator.getGamepads||!!navigator.webkitGetGamepads||!!navigator.msGetGamepads||!!navigator.webkitGamepads);
private Func<Gamepad, object> _callbackGamepadConnected;
private string buttonADataURL="data:image/png;base64,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";
private static HTMLElement gamepadDOMInfo;
public Gamepads(Func<Gamepad, object> ongamedpadconnected) {
this._callbackGamepadConnected=ongamedpadconnected;
if (this.gamepadSupportAvailable) 
{
if (this.gamepadEventSupported) 
{
window.addEventListener("gamepadconnecte", (dynamic evt) => {
this._onGamepadConnected(evt);
}
, false);
window.addEventListener("gamepaddisconnecte", (dynamic evt) => {
this._onGamepadDisconnected(evt);
}
, false);
}
else 
{
this._startMonitoringGamepads();
}
if (!this.oneGamepadConnected) 
{
this._insertGamepadDOMInstructions();
}
}
else 
{
this._insertGamepadDOMNotSupported();
}
}
private virtual void _insertGamepadDOMInstructions() {
Gamepads.gamepadDOMInfo=(HTMLDivElement)document.createElement("di");
var buttonAImage = (HTMLImageElement)document.createElement("im");
buttonAImage.src=this.buttonADataURL;
var spanMessage = (HTMLSpanElement)document.createElement("spa");
spanMessage.innerHTML="<strong>to activate gamepad</strong";
Gamepads.gamepadDOMInfo.appendChild(buttonAImage);
Gamepads.gamepadDOMInfo.appendChild(spanMessage);
Gamepads.gamepadDOMInfo.style.position="absolut";
Gamepads.gamepadDOMInfo.style.width="100";
Gamepads.gamepadDOMInfo.style.height="48p";
Gamepads.gamepadDOMInfo.style.bottom="0p";
Gamepads.gamepadDOMInfo.style.backgroundColor="rgba(1, 1, 1, 0.15";
Gamepads.gamepadDOMInfo.style.textAlign="cente";
Gamepads.gamepadDOMInfo.style.zIndex="1";
buttonAImage.style.position="relativ";
buttonAImage.style.bottom="8p";
spanMessage.style.position="relativ";
spanMessage.style.fontSize="32p";
spanMessage.style.bottom="32p";
spanMessage.style.color="gree";
document.body.appendChild(Gamepads.gamepadDOMInfo);
}
private virtual void _insertGamepadDOMNotSupported() {
Gamepads.gamepadDOMInfo=(HTMLDivElement)document.createElement("di");
var spanMessage = (HTMLSpanElement)document.createElement("spa");
spanMessage.innerHTML="<strong>gamepad not supported</strong";
Gamepads.gamepadDOMInfo.appendChild(spanMessage);
Gamepads.gamepadDOMInfo.style.position="absolut";
Gamepads.gamepadDOMInfo.style.width="100";
Gamepads.gamepadDOMInfo.style.height="40p";
Gamepads.gamepadDOMInfo.style.bottom="0p";
Gamepads.gamepadDOMInfo.style.backgroundColor="rgba(1, 1, 1, 0.15";
Gamepads.gamepadDOMInfo.style.textAlign="cente";
Gamepads.gamepadDOMInfo.style.zIndex="1";
spanMessage.style.position="relativ";
spanMessage.style.fontSize="32p";
spanMessage.style.color="re";
document.body.appendChild(Gamepads.gamepadDOMInfo);
}
public virtual void dispose() {
document.body.removeChild(Gamepads.gamepadDOMInfo);
}
private virtual void _onGamepadConnected(dynamic evt) {
var newGamepad = this._addNewGamepad(evt.gamepad);
if (this._callbackGamepadConnected) 
this._callbackGamepadConnected(newGamepad);
this._startMonitoringGamepads();
}
private virtual Gamepad _addNewGamepad(dynamic gamepad) {
if (!this.oneGamepadConnected) 
{
this.oneGamepadConnected=true;
if (Gamepads.gamepadDOMInfo) 
{
document.body.removeChild(Gamepads.gamepadDOMInfo);
Gamepads.gamepadDOMInfo=null;
}
}
var newGamepad;
if (((string)gamepad.id).search("Xbox 36")!=-1||((string)gamepad.id).search("xinpu")!=-1) 
{
newGamepad=new BABYLON.Xbox360Pad(gamepad.id, gamepad.index, gamepad);
}
else 
{
newGamepad=new BABYLON.GenericPad(gamepad.id, gamepad.index, gamepad);
}
this.babylonGamepads.push(newGamepad);
return newGamepad;
}
private virtual void _onGamepadDisconnected(dynamic evt) {
foreach (var i in this.babylonGamepads) 
{
if (this.babylonGamepads[i].index==evt.gamepad.index) 
{
this.babylonGamepads.splice(i, 1);
break;
}
}
if (this.babylonGamepads.length==0) 
{
this._stopMonitoringGamepads();
}
}
private virtual void _startMonitoringGamepads() {
if (!this.isMonitoring) 
{
this.isMonitoring=true;
this._checkGamepadsStatus();
}
}
private virtual void _stopMonitoringGamepads() {
this.isMonitoring=false;
}
private virtual void _checkGamepadsStatus() {
this._updateGamepadObjects();
foreach (var i in this.babylonGamepads) 
{
this.babylonGamepads[i].update();
}
if (this.isMonitoring) 
{
if (window.requestAnimationFrame) 
{
window.requestAnimationFrame(() => {
this._checkGamepadsStatus();
}
);
}
else 
if (window.mozRequestAnimationFrame) 
{
window.mozRequestAnimationFrame(() => {
this._checkGamepadsStatus();
}
);
}
else 
if (window.webkitRequestAnimationFrame) 
{
window.webkitRequestAnimationFrame(() => {
this._checkGamepadsStatus();
}
);
}
}
}
private virtual void _updateGamepadObjects() {
var gamepads = (navigator.getGamepads) ? navigator.getGamepads() : ((navigator.webkitGetGamepads) ? navigator.webkitGetGamepads() : new Array<object>());
for (var i = 0;i<gamepads.length;i++) 
{
if (gamepads[i]) 
{
if (!(gamepads[i].indexinthis.babylonGamepads)) 
{
var newGamepad = this._addNewGamepad(gamepads[i]);
if (this._callbackGamepadConnected) 
{
this._callbackGamepadConnected(newGamepad);
}
}
else 
{
this.babylonGamepads[i].browserGamepad=gamepads[i];
}
}
}
}
}
public class StickValues {
public dynamic x;
public dynamic y;
public StickValues(dynamic x, dynamic y) {
}
}
public class Gamepad {
private StickValues _leftStick;
private StickValues _rightStick;
private Func<StickValues, object> _onleftstickchanged;
private Func<StickValues, object> _onrightstickchanged;
public string id;
public float index;
public dynamic browserGamepad;
public Gamepad(string id, float index, dynamic browserGamepad) {
if (this.browserGamepad.axes.length>=2) 
{
this._leftStick=new dynamic();
}
if (this.browserGamepad.axes.length>=4) 
{
this._rightStick=new dynamic();
}
}
public virtual void onleftstickchanged(Func<StickValues, object> callback) {
this._onleftstickchanged=callback;
}
public virtual void onrightstickchanged(Func<StickValues, object> callback) {
this._onrightstickchanged=callback;
}
public virtual void update() {
if (this._leftStick) 
{
this.leftStick=new dynamic();
}
if (this._rightStick) 
{
this.rightStick=new dynamic();
}
}
}
public class GenericPad: Gamepad {
private Array<float> _buttons;
private Func<float, object> _onbuttondown;
private Func<float, object> _onbuttonup;
public virtual void onbuttondown(Func<float, object> callback) {
this._onbuttondown=callback;
}
public virtual void onbuttonup(Func<float, object> callback) {
this._onbuttonup=callback;
}
public string id;
public float index;
public dynamic gamepad;
public GenericPad(string id, float index, dynamic gamepad) {
base(id, index, gamepad);
this._buttons=new Array(gamepad.buttons.length);
}
private virtual float _setButtonValue(float newValue, float currentValue, float buttonIndex) {
if (newValue!=currentValue) 
{
if (this._onbuttondown&&newValue==1) 
{
this._onbuttondown(buttonIndex);
}
if (this._onbuttonup&&newValue==0) 
{
this._onbuttonup(buttonIndex);
}
}
return newValue;
}
public virtual void update() {
base.update();
for (var index = 0;index<this._buttons.length;index++) 
{
this._buttons[index]=this._setButtonValue(this.gamepad.buttons[index].value, this._buttons[index], index);
}
}
}
public enum Xbox360Button {
A,B,X,Y,Start,Back,LB,RB,LeftStick,RightStick}
public enum Xbox360Dpad {
Up,Down,Left,Right}
public class Xbox360Pad: Gamepad {
private float _leftTrigger=0;
private float _rightTrigger=0;
private Func<float, object> _onlefttriggerchanged;
private Func<float, object> _onrighttriggerchanged;
private Func<Xbox360Button, object> _onbuttondown;
private Func<Xbox360Button, object> _onbuttonup;
private Func<Xbox360Dpad, object> _ondpaddown;
private Func<Xbox360Dpad, object> _ondpadup;
private float _buttonA=0;
private float _buttonB=0;
private float _buttonX=0;
private float _buttonY=0;
private float _buttonBack=0;
private float _buttonStart=0;
private float _buttonLB=0;
private float _buttonRB=0;
private float _buttonLeftStick=0;
private float _buttonRightStick=0;
private float _dPadUp=0;
private float _dPadDown=0;
private float _dPadLeft=0;
private float _dPadRight=0;
public virtual void onlefttriggerchanged(Func<float, object> callback) {
this._onlefttriggerchanged=callback;
}
public virtual void onrighttriggerchanged(Func<float, object> callback) {
this._onrighttriggerchanged=callback;
}
public virtual void onbuttondown(Func<Xbox360Button, object> callback) {
this._onbuttondown=callback;
}
public virtual void onbuttonup(Func<Xbox360Button, object> callback) {
this._onbuttonup=callback;
}
public virtual void ondpaddown(Func<Xbox360Dpad, object> callback) {
this._ondpaddown=callback;
}
public virtual void ondpadup(Func<Xbox360Dpad, object> callback) {
this._ondpadup=callback;
}
private virtual float _setButtonValue(float newValue, float currentValue, Xbox360Button buttonType) {
if (newValue!=currentValue) 
{
if (this._onbuttondown&&newValue==1) 
{
this._onbuttondown(buttonType);
}
if (this._onbuttonup&&newValue==0) 
{
this._onbuttonup(buttonType);
}
}
return newValue;
}
private virtual float _setDPadValue(float newValue, float currentValue, Xbox360Dpad buttonType) {
if (newValue!=currentValue) 
{
if (this._ondpaddown&&newValue==1) 
{
this._ondpaddown(buttonType);
}
if (this._ondpadup&&newValue==0) 
{
this._ondpadup(buttonType);
}
}
return newValue;
}
public virtual void update() {
base.update();
this.buttonA=this.browserGamepad.buttons[0].value;
this.buttonB=this.browserGamepad.buttons[1].value;
this.buttonX=this.browserGamepad.buttons[2].value;
this.buttonY=this.browserGamepad.buttons[3].value;
this.buttonLB=this.browserGamepad.buttons[4].value;
this.buttonRB=this.browserGamepad.buttons[5].value;
this.leftTrigger=this.browserGamepad.buttons[6].value;
this.rightTrigger=this.browserGamepad.buttons[7].value;
this.buttonBack=this.browserGamepad.buttons[8].value;
this.buttonStart=this.browserGamepad.buttons[9].value;
this.buttonLeftStick=this.browserGamepad.buttons[10].value;
this.buttonRightStick=this.browserGamepad.buttons[11].value;
this.dPadUp=this.browserGamepad.buttons[12].value;
this.dPadDown=this.browserGamepad.buttons[13].value;
this.dPadLeft=this.browserGamepad.buttons[14].value;
this.dPadRight=this.browserGamepad.buttons[15].value;
}
}
}
public interface Navigator {
object getGamepads(object func);
object webkitGetGamepads(object func);
object msGetGamepads(object func);
object webkitGamepads(object func);
}
