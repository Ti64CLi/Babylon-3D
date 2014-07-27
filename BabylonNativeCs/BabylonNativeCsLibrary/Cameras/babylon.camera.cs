using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Camera: Node {
public static dynamic PERSPECTIVE_CAMERA=0;
public static dynamic ORTHOGRAPHIC_CAMERA=1;
public dynamic upVector=Vector3.Up();
public dynamic orthoLeft=null;
public dynamic orthoRight=null;
public dynamic orthoBottom=null;
public dynamic orthoTop=null;
public dynamic fov=0.8;
public dynamic minZ=0.1;
public dynamic maxZ=1000.0;
public dynamic inertia=0.9;
public dynamic mode=Camera.PERSPECTIVE_CAMERA;
public dynamic isIntermediate=false;
public dynamic viewport=new Viewport(0, 0, 1.0, 1.0);
public dynamic subCameras=new Array<object>();
public float layerMask=0xFFFFFFFF;
private dynamic _computedViewMatrix=BABYLON.Matrix.Identity();
public dynamic _projectionMatrix=new BABYLON.Matrix();
private Matrix _worldMatrix;
public dynamic _postProcesses=new Array();
public dynamic _postProcessesTakenIndices=new Array<object>();
public string _waitingParentId;
public Vector3 position;
public Camera(string name, Vector3 position, Scene scene) {
base(name, scene);
scene.cameras.push(this);
if (!scene.activeCamera) 
{
scene.activeCamera=this;
}
}
public virtual void _initCache() {
base._initCache();
this._cache.position=new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
this._cache.upVector=new BABYLON.Vector3(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE);
this._cache.mode=undefined;
this._cache.minZ=undefined;
this._cache.maxZ=undefined;
this._cache.fov=undefined;
this._cache.aspectRatio=undefined;
this._cache.orthoLeft=undefined;
this._cache.orthoRight=undefined;
this._cache.orthoBottom=undefined;
this._cache.orthoTop=undefined;
this._cache.renderWidth=undefined;
this._cache.renderHeight=undefined;
}
public virtual void _updateCache(bool ignoreParentClass) {
if (!ignoreParentClass) 
{
base._updateCache();
}
var engine = this.getEngine();
this._cache.position.copyFrom(this.position);
this._cache.upVector.copyFrom(this.upVector);
this._cache.mode=this.mode;
this._cache.minZ=this.minZ;
this._cache.maxZ=this.maxZ;
this._cache.fov=this.fov;
this._cache.aspectRatio=engine.getAspectRatio(this);
this._cache.orthoLeft=this.orthoLeft;
this._cache.orthoRight=this.orthoRight;
this._cache.orthoBottom=this.orthoBottom;
this._cache.orthoTop=this.orthoTop;
this._cache.renderWidth=engine.getRenderWidth();
this._cache.renderHeight=engine.getRenderHeight();
}
public virtual void _updateFromScene() {
this.updateCache();
this._update();
}
public virtual bool _isSynchronized() {
return this._isSynchronizedViewMatrix()&&this._isSynchronizedProjectionMatrix();
}
public virtual bool _isSynchronizedViewMatrix() {
if (!base._isSynchronized()) 
return false;
return this._cache.position.equals(this.position)&&this._cache.upVector.equals(this.upVector)&&this.isSynchronizedWithParent();
}
public virtual bool _isSynchronizedProjectionMatrix() {
var check = this._cache.mode==this.mode&&this._cache.minZ==this.minZ&&this._cache.maxZ==this.maxZ;
if (!check) 
{
return false;
}
var engine = this.getEngine();
if (this.mode==BABYLON.Camera.PERSPECTIVE_CAMERA) 
{
check=this._cache.fov==this.fov&&this._cache.aspectRatio==engine.getAspectRatio(this);
}
else 
{
check=this._cache.orthoLeft==this.orthoLeft&&this._cache.orthoRight==this.orthoRight&&this._cache.orthoBottom==this.orthoBottom&&this._cache.orthoTop==this.orthoTop&&this._cache.renderWidth==engine.getRenderWidth()&&this._cache.renderHeight==engine.getRenderHeight();
}
return check;
}
public virtual void attachControl(HTMLElement element) {
}
public virtual void detachControl(HTMLElement element) {
}
public virtual void _update() {
}
public virtual float attachPostProcess(PostProcess postProcess, float insertAt) {
if (!postProcess.isReusable()&&this._postProcesses.indexOf(postProcess)>-1) 
{
Tools.Exception("You're trying to reuse a post process not defined as reusable");
return 0;
}
if (insertAt==null||insertAt<0) 
{
this._postProcesses.push(postProcess);
this._postProcessesTakenIndices.push(this._postProcesses.length-1);
return this._postProcesses.length-1;
}
var add = 0;
if (this._postProcesses[insertAt]) 
{
var start = this._postProcesses.length-1;
for (var i = start;i>=insertAt+1;--i) 
{
this._postProcesses[i+1]=this._postProcesses[i];
}
add=1;
}
for (i=0;i<this._postProcessesTakenIndices.length;++i) 
{
if (this._postProcessesTakenIndices[i]<insertAt) 
{
continue;
}
start=this._postProcessesTakenIndices.length-1;
for (var j = start;j>=i;--j) 
{
this._postProcessesTakenIndices[j+1]=this._postProcessesTakenIndices[j]+add;
}
this._postProcessesTakenIndices[i]=insertAt;
break;
}
if (!add&&this._postProcessesTakenIndices.indexOf(insertAt)==-1) 
{
this._postProcessesTakenIndices.push(insertAt);
}
var result = insertAt+add;
this._postProcesses[result]=postProcess;
return result;
}
public virtual float[] detachPostProcess(PostProcess postProcess, object atIndices) {
var result = new Array<object>();
if (!atIndices) 
{
var length = this._postProcesses.length;
for (var i = 0;i<length;i++) 
{
if (this._postProcesses[i]!=postProcess) 
{
continue;
}
this._postProcesses[i] = null;
var index = this._postProcessesTakenIndices.indexOf(i);
this._postProcessesTakenIndices.splice(index, 1);
}
}
else 
{
atIndices=((atIndicesisArray)) ? atIndices : new Array<object>();
for (i=0;i<atIndices.length;i++) 
{
var foundPostProcess = this._postProcesses[atIndices[i]];
if (foundPostProcess!=postProcess) 
{
result.push(i);
continue;
}
this._postProcesses[atIndices[i]] = null;
index=this._postProcessesTakenIndices.indexOf(atIndices[i]);
this._postProcessesTakenIndices.splice(index, 1);
}
}
return result;
}
public virtual Matrix getWorldMatrix() {
if (!this._worldMatrix) 
{
this._worldMatrix=BABYLON.Matrix.Identity();
}
var viewMatrix = this.getViewMatrix();
viewMatrix.invertToRef(this._worldMatrix);
return this._worldMatrix;
}
public virtual Matrix _getViewMatrix() {
return BABYLON.Matrix.Identity();
}
public virtual Matrix getViewMatrix() {
this._computedViewMatrix=this._computeViewMatrix();
if (!this.parent||!this.parent.getWorldMatrix||this.isSynchronized()) 
{
return this._computedViewMatrix;
}
if (!this._worldMatrix) 
{
this._worldMatrix=BABYLON.Matrix.Identity();
}
this._computedViewMatrix.invertToRef(this._worldMatrix);
this._worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._computedViewMatrix);
this._computedViewMatrix.invert();
this._currentRenderId=this.getScene().getRenderId();
return this._computedViewMatrix;
}
public virtual Matrix _computeViewMatrix(bool force) {
if (!force&&this._isSynchronizedViewMatrix()) 
{
return this._computedViewMatrix;
}
this._computedViewMatrix=this._getViewMatrix();
if (!this.parent||!this.parent.getWorldMatrix) 
{
this._currentRenderId=this.getScene().getRenderId();
}
return this._computedViewMatrix;
}
public virtual Matrix getProjectionMatrix(bool force) {
if (!force&&this._isSynchronizedProjectionMatrix()) 
{
return this._projectionMatrix;
}
var engine = this.getEngine();
if (this.mode==BABYLON.Camera.PERSPECTIVE_CAMERA) 
{
if (this.minZ<=0) 
{
this.minZ=0.1;
}
BABYLON.Matrix.PerspectiveFovLHToRef(this.fov, engine.getAspectRatio(this), this.minZ, this.maxZ, this._projectionMatrix);
return this._projectionMatrix;
}
var halfWidth = engine.getRenderWidth()/2.0;
var halfHeight = engine.getRenderHeight()/2.0;
BABYLON.Matrix.OrthoOffCenterLHToRef(this.orthoLeft||-halfWidth, this.orthoRight||halfWidth, this.orthoBottom||-halfHeight, this.orthoTop||halfHeight, this.minZ, this.maxZ, this._projectionMatrix);
return this._projectionMatrix;
}
public virtual void dispose() {
var index = this.getScene().cameras.indexOf(this);
this.getScene().cameras.splice(index, 1);
for (var i = 0;i<this._postProcessesTakenIndices.length;++i) 
{
this._postProcesses[this._postProcessesTakenIndices[i]].dispose(this);
}
}
}
}
