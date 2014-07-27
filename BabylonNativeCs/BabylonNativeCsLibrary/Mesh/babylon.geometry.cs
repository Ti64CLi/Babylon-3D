using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Geometry: IGetSetVerticesData {
public string id;
public dynamic delayLoadState=BABYLON.Engine.DELAYLOADSTATE_NONE;
public string delayLoadingFile;
private Scene _scene;
private Engine _engine;
private Mesh[] _meshes;
private dynamic _totalVertices=0;
private dynamic _indices=new Array<object>();
private dynamic _vertexBuffers;
public dynamic _delayInfo;
private dynamic _indexBuffer;
public BoundingInfo _boundingInfo;
public Func<object, object, object> _delayLoadingFunction;
public Geometry(string id, Scene scene, VertexData vertexData, bool updatable, Mesh mesh) {
this.id=id;
this._engine=scene.getEngine();
this._meshes=new Array<object>();
this._scene=scene;
if (vertexData) 
{
this.setAllVerticesData(vertexData, updatable);
}
else 
{
this._totalVertices=0;
this._indices=new Array<object>();
}
if (mesh) 
{
this.applyToMesh(mesh);
}
}
var currentCSGMeshId = 0;
public virtual Scene getScene() {
return this._scene;
}
public virtual Engine getEngine() {
return this._engine;
}
public virtual bool isReady() {
return this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_LOADED||this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_NONE;
}
public virtual void setAllVerticesData(VertexData vertexData, bool updatable) {
vertexData.applyToGeometry(this, updatable);
}
public virtual void setVerticesData(string kind, float[] data, bool updatable) {
this._vertexBuffers=this._vertexBuffers||new dynamic();
if (this._vertexBuffers[kind]) 
{
this._vertexBuffers[kind].dispose();
}
this._vertexBuffers[kind]=new VertexBuffer(this._engine, data, kind, updatable, this._meshes.length==0);
if (kind==BABYLON.VertexBuffer.PositionKind) 
{
var stride = this._vertexBuffers[kind].getStrideSize();
this._totalVertices=data.length/stride;
var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this._totalVertices);
var meshes = this._meshes;
var numOfMeshes = meshes.length;
for (var index = 0;index<numOfMeshes;index++) 
{
var mesh = meshes[index];
mesh._resetPointsArrayCache();
mesh._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
mesh._createGlobalSubMesh();
mesh.computeWorldMatrix(true);
}
}
}
public virtual void updateVerticesData(string kind, float[] data, bool updateExtends) {
var vertexBuffer = this.getVertexBuffer(kind);
if (!vertexBuffer) 
{
return;
}
vertexBuffer.update(data);
if (kind==BABYLON.VertexBuffer.PositionKind) 
{
var extend;
if (updateExtends) 
{
var stride = vertexBuffer.getStrideSize();
this._totalVertices=data.length/stride;
extend=BABYLON.Tools.ExtractMinAndMax(data, 0, this._totalVertices);
}
var meshes = this._meshes;
var numOfMeshes = meshes.length;
for (var index = 0;index<numOfMeshes;index++) 
{
var mesh = meshes[index];
mesh._resetPointsArrayCache();
if (updateExtends) 
{
mesh._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
}
}
}
}
public virtual float getTotalVertices() {
if (!this.isReady()) 
{
return 0;
}
return this._totalVertices;
}
public virtual float[] getVerticesData(string kind) {
var vertexBuffer = this.getVertexBuffer(kind);
if (!vertexBuffer) 
{
return null;
}
return vertexBuffer.getData();
}
public virtual VertexBuffer getVertexBuffer(string kind) {
if (!this.isReady()) 
{
return null;
}
return this._vertexBuffers[kind];
}
public virtual VertexBuffer[] getVertexBuffers() {
if (!this.isReady()) 
{
return null;
}
return this._vertexBuffers;
}
public virtual bool isVerticesDataPresent(string kind) {
if (!this._vertexBuffers) 
{
if (this._delayInfo) 
{
return this._delayInfo.indexOf(kind)!=-1;
}
return false;
}
return this._vertexBuffers[kind]!=undefined;
}
public virtual string[] getVerticesDataKinds() {
var result = new Array<object>();
if (!this._vertexBuffers&&this._delayInfo) 
{
foreach (var kind in this._delayInfo) 
{
result.push(kind);
}
}
else 
{
foreach (kind in this._vertexBuffers) 
{
result.push(kind);
}
}
return result;
}
public virtual void setIndices(float[] indices) {
if (this._indexBuffer) 
{
this._engine._releaseBuffer(this._indexBuffer);
}
this._indices=indices;
if (this._meshes.length!=0&&this._indices) 
{
this._indexBuffer=this._engine.createIndexBuffer(this._indices);
}
var meshes = this._meshes;
var numOfMeshes = meshes.length;
for (var index = 0;index<numOfMeshes;index++) 
{
meshes[index]._createGlobalSubMesh();
}
}
public virtual float getTotalIndices() {
if (!this.isReady()) 
{
return 0;
}
return this._indices.length;
}
public virtual float[] getIndices() {
if (!this.isReady()) 
{
return null;
}
return this._indices;
}
public virtual object getIndexBuffer() {
if (!this.isReady()) 
{
return null;
}
return this._indexBuffer;
}
public virtual void releaseForMesh(Mesh mesh, bool shouldDispose) {
var meshes = this._meshes;
var index = meshes.indexOf(mesh);
if (index==-1) 
{
return;
}
foreach (var kind in this._vertexBuffers) 
{
this._vertexBuffers[kind].dispose();
}
if (this._indexBuffer&&this._engine._releaseBuffer(this._indexBuffer)) 
{
this._indexBuffer=null;
}
meshes.splice(index, 1);
mesh._geometry=null;
if (meshes.length==0&&shouldDispose) 
{
this.dispose();
}
}
public virtual void applyToMesh(Mesh mesh) {
if (mesh._geometry==this) 
{
return;
}
var previousGeometry = mesh._geometry;
if (previousGeometry) 
{
previousGeometry.releaseForMesh(mesh);
}
var meshes = this._meshes;
mesh._geometry=this;
this._scene.pushGeometry(this);
meshes.push(mesh);
if (this.isReady()) 
{
this._applyToMesh(mesh);
}
else 
{
mesh._boundingInfo=this._boundingInfo;
}
}
private virtual void _applyToMesh(Mesh mesh) {
var numOfMeshes = this._meshes.length;
foreach (var kind in this._vertexBuffers) 
{
if (numOfMeshes==1) 
{
this._vertexBuffers[kind].create();
}
this._vertexBuffers[kind]._buffer.references=numOfMeshes;
if (kind==BABYLON.VertexBuffer.PositionKind) 
{
mesh._resetPointsArrayCache();
var extend = BABYLON.Tools.ExtractMinAndMax(this._vertexBuffers[kind].getData(), 0, this._totalVertices);
mesh._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
mesh._createGlobalSubMesh();
}
}
if (numOfMeshes==1&&this._indices) 
{
this._indexBuffer=this._engine.createIndexBuffer(this._indices);
}
if (this._indexBuffer) 
{
this._indexBuffer.references=numOfMeshes;
}
}
public virtual void load(Scene scene, Func<object> onLoaded) {
if (this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_LOADING) 
{
return;
}
if (this.isReady()) 
{
if (onLoaded) 
{
onLoaded();
}
return;
}
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_LOADING;
scene._addPendingData(this);
BABYLON.Tools.LoadFile(this.delayLoadingFile, (dynamic data) => {
this._delayLoadingFunction(JSON.parse(data), this);
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_LOADED;
this._delayInfo=new Array<object>();
scene._removePendingData(this);
var meshes = this._meshes;
var numOfMeshes = meshes.length;
for (var index = 0;index<numOfMeshes;index++) 
{
this._applyToMesh(meshes[index]);
}
if (onLoaded) 
{
onLoaded();
}
}
, () => {
}
, scene.database);
}
public virtual void dispose() {
var meshes = this._meshes;
var numOfMeshes = meshes.length;
for (var index = 0;index<numOfMeshes;index++) 
{
this.releaseForMesh(meshes[index]);
}
this._meshes=new Array<object>();
foreach (var kind in this._vertexBuffers) 
{
this._vertexBuffers[kind].dispose();
}
this._vertexBuffers=new Array<object>();
this._totalVertices=0;
if (this._indexBuffer) 
{
this._engine._releaseBuffer(this._indexBuffer);
}
this._indexBuffer=null;
this._indices=new Array<object>();
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_NONE;
this.delayLoadingFile=null;
this._delayLoadingFunction=null;
this._delayInfo=new Array<object>();
this._boundingInfo=null;
var geometries = this._scene.getGeometries();
index=geometries.indexOf(this);
if (index>-1) 
{
geometries.splice(index, 1);
}
}
public virtual Geometry copy(string id) {
var vertexData = new BABYLON.VertexData();
vertexData.indices=new Array<object>();
var indices = this.getIndices();
for (var index = 0;index<indices.length;index++) 
{
vertexData.indices.push(indices[index]);
}
var updatable = false;
var stopChecking = false;
foreach (var kind in this._vertexBuffers) 
{
vertexData.set(this.getVerticesData(kind), kind);
if (!stopChecking) 
{
updatable=this.getVertexBuffer(kind).isUpdatable();
stopChecking=!updatable;
}
}
var geometry = new BABYLON.Geometry(id, this._scene, vertexData, updatable, null);
geometry.delayLoadState=this.delayLoadState;
geometry.delayLoadingFile=this.delayLoadingFile;
geometry._delayLoadingFunction=this._delayLoadingFunction;
foreach (kind in this._delayInfo) 
{
geometry._delayInfo=geometry._delayInfo||new Array<object>();
geometry._delayInfo.push(kind);
}
var extend = BABYLON.Tools.ExtractMinAndMax(this.getVerticesData(BABYLON.VertexBuffer.PositionKind), 0, this.getTotalVertices());
geometry._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
return geometry;
}
public static virtual Geometry ExtractFromMesh(Mesh mesh, string id) {
var geometry = mesh._geometry;
if (!geometry) 
{
return null;
}
return geometry.copy(id);
}
public static virtual string RandomId() {
return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxx".replace(new Regex(/[xy]/g), (dynamic c) => {
var r = Math.random()*16|0v = (c=="") ? r : (r&0x3|0x8);
return v.toString(16);
}
);
}
}
}
