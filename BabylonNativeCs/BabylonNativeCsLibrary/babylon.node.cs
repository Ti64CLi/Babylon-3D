using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Node {
public Node parent;
public string name;
public string id;
public dynamic state="\"";
public dynamic animations=new Array();
public Func<Node, object> onReady;
private dynamic _childrenFlag=-1;
private dynamic _isEnabled=true;
private dynamic _isReady=true;
public dynamic _currentRenderId=-1;
private Scene _scene;
public dynamic _cache;
public Node(string name, dynamic scene) {
this.name=name;
this.id=name;
this._scene=scene;
this._initCache();
}
public virtual Scene getScene() {
return this._scene;
}
public virtual Engine getEngine() {
return this._scene.getEngine();
}
public virtual Matrix getWorldMatrix() {
return Matrix.Identity();
}
public virtual void _initCache() {
this._cache=new dynamic();
this._cache.parent=undefined;
}
public virtual void updateCache(bool force) {
if (!force&&this.isSynchronized()) 
return;
this._cache.parent=this.parent;
this._updateCache();
}
public virtual void _updateCache(bool ignoreParentClass) {
}
public virtual bool _isSynchronized() {
return true;
}
public virtual bool isSynchronizedWithParent() {
return (this.parent) ? this.parent._currentRenderId<=this._currentRenderId : true;
}
public virtual bool isSynchronized(bool updateCache) {
var check = this.hasNewParent();
check=check||!this.isSynchronizedWithParent();
check=check||!this._isSynchronized();
if (updateCache) 
this.updateCache(true);
return !check;
}
public virtual bool hasNewParent(bool update) {
if (this._cache.parent==this.parent) 
return false;
if (update) 
this._cache.parent=this.parent;
return true;
}
public virtual bool isReady() {
return this._isReady;
}
public virtual bool isEnabled() {
if (!this._isEnabled) 
{
return false;
}
if (this.parent) 
{
return this.parent.isEnabled();
}
return true;
}
public virtual void setEnabled(bool value) {
this._isEnabled=value;
}
public virtual bool isDescendantOf(Node ancestor) {
if (this.parent) 
{
if (this.parent==ancestor) 
{
return true;
}
return this.parent.isDescendantOf(ancestor);
}
return false;
}
public virtual void _getDescendants(Node[] list, Node[] results) {
for (var index = 0;index<list.length;index++) 
{
var item = list[index];
if (item.isDescendantOf(this)) 
{
results.push(item);
}
}
}
public virtual Node[] getDescendants() {
var results = new Array<object>();
this._getDescendants(this._scene.meshes, results);
this._getDescendants(this._scene.lights, results);
this._getDescendants(this._scene.cameras, results);
return results;
}
public virtual void _setReady(bool state) {
if (state==this._isReady) 
{
return;
}
if (!state) 
{
this._isReady=false;
return;
}
this._isReady=true;
if (this.onReady) 
{
this.onReady(this);
}
}
}
}
