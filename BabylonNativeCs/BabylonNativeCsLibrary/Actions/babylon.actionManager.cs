using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class ActionEvent {
public AbstractMesh source;
public float pointerX;
public float pointerY;
public AbstractMesh meshUnderPointer;
public ActionEvent(AbstractMesh source, float pointerX, float pointerY, AbstractMesh meshUnderPointer) {
}
public static virtual ActionEvent CreateNew(AbstractMesh source) {
var scene = source.getScene();
return new ActionEvent(source, scene.pointerX, scene.pointerY, scene.meshUnderPointer);
}
}
public class ActionManager {
private static dynamic _NothingTrigger=0;
private static dynamic _OnPickTrigger=1;
private static dynamic _OnLeftPickTrigger=2;
private static dynamic _OnRightPickTrigger=3;
private static dynamic _OnCenterPickTrigger=4;
private static dynamic _OnPointerOverTrigger=5;
private static dynamic _OnPointerOutTrigger=6;
private static dynamic _OnEveryFrameTrigger=7;
private static dynamic _OnIntersectionEnterTrigger=8;
private static dynamic _OnIntersectionExitTrigger=9;
public dynamic actions=new Array();
private Scene _scene;
public ActionManager(Scene scene) {
this._scene=scene;
scene._actionManagers.push(this);
}
public virtual void dispose() {
var index = this._scene._actionManagers.indexOf(this);
if (index>-1) 
{
this._scene._actionManagers.splice(index, 1);
}
}
public virtual Scene getScene() {
return this._scene;
}
public virtual bool hasSpecificTriggers(float[] triggers) {
for (var index = 0;index<this.actions.length;index++) 
{
var action = this.actions[index];
if (triggers.indexOf(action.trigger)>-1) 
{
return true;
}
}
return false;
}
public virtual Action registerAction(Action action) {
if (action.trigger==ActionManager.OnEveryFrameTrigger) 
{
if (this.getScene().actionManager!=this) 
{
Tools.Warn("OnEveryFrameTrigger can only be used with scene.actionManage");
return null;
}
}
this.actions.push(action);
action._actionManager=this;
action._prepare();
return action;
}
public virtual void processTrigger(float trigger, ActionEvent evt) {
for (var index = 0;index<this.actions.length;index++) 
{
var action = this.actions[index];
if (action.trigger==trigger) 
{
action._executeCurrent(evt);
}
}
}
public virtual object _getEffectiveTarget(object target, string propertyPath) {
var properties = propertyPath.split("");
for (var index = 0;index<properties.length-1;index++) 
{
target=target[properties[index]];
}
return target;
}
public virtual string _getProperty(string propertyPath) {
var properties = propertyPath.split("");
return properties[properties.length-1];
}
}
}
