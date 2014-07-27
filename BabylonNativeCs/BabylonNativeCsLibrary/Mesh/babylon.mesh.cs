using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class _InstancesBatch {
dynamic mustReturn=false;
dynamic visibleInstances=new Array();
dynamic renderSelf=new Array();
}
public class Mesh: AbstractMesh: IGetSetVerticesData {
dynamic delayLoadState=BABYLON.Engine.DELAYLOADSTATE_NONE;
dynamic instances=new Array();
public string delayLoadingFile;
public Geometry _geometry;
dynamic _onBeforeRenderCallbacks=new Array<object>();
dynamic _delayInfo;
public Func<object, object, object> _delayLoadingFunction;
public object _visibleInstances=new dynamic();
dynamic _renderIdForInstances=new Array();
dynamic _batchCache=new _InstancesBatch();
private WebGLBuffer _worldMatricesInstancesBuffer;
private Float32Array _worldMatricesInstancesArray;
dynamic _instancesBufferSize=32*16*4;
public bool _shouldGenerateFlatShading;
public Mesh(string name, Scene scene) {
base(name, scene);
}
public virtual float getTotalVertices() {
if (!this._geometry) 
{
return 0;
}
return this._geometry.getTotalVertices();
}
public virtual float[] getVerticesData(string kind) {
if (!this._geometry) 
{
return null;
}
return this._geometry.getVerticesData(kind);
}
public virtual VertexBuffer getVertexBuffer(dynamic kind) {
if (!this._geometry) 
{
return undefined;
}
return this._geometry.getVertexBuffer(kind);
}
public virtual bool isVerticesDataPresent(string kind) {
if (!this._geometry) 
{
if (this._delayInfo) 
{
return this._delayInfo.indexOf(kind)!=-1;
}
return false;
}
return this._geometry.isVerticesDataPresent(kind);
}
public virtual string[] getVerticesDataKinds() {
if (!this._geometry) 
{
var result = new Array<object>();
if (this._delayInfo) 
{
foreach (var kind in this._delayInfo) 
{
result.push(kind);
}
}
return result;
}
return this._geometry.getVerticesDataKinds();
}
public virtual float getTotalIndices() {
if (!this._geometry) 
{
return 0;
}
return this._geometry.getTotalIndices();
}
public virtual float[] getIndices() {
if (!this._geometry) 
{
return new Array<object>();
}
return this._geometry.getIndices();
}
public virtual bool isReady() {
if (this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_LOADING) 
{
return false;
}
return base.isReady();
}
public virtual bool isDisposed() {
return this._isDisposed;
}
public virtual void _preActivate() {
this._visibleInstances=null;
}
public virtual void _registerInstanceForRenderId(InstancedMesh instance, float renderId) {
if (!this._visibleInstances) 
{
this._visibleInstances=new dynamic();
this._visibleInstances.defaultRenderId=renderId;
this._visibleInstances.selfDefaultRenderId=this._renderId;
}
if (!this._visibleInstances[renderId]) 
{
this._visibleInstances[renderId]=new Array();
}
this._visibleInstances[renderId].push(instance);
}
public virtual void refreshBoundingInfo() {
var data = this.getVerticesData(BABYLON.VertexBuffer.PositionKind);
if (data) 
{
var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this.getTotalVertices());
this._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
}
if (this.subMeshes) 
{
for (var index = 0;index<this.subMeshes.length;index++) 
{
this.subMeshes[index].refreshBoundingInfo();
}
}
this._updateBoundingInfo();
}
public virtual SubMesh _createGlobalSubMesh() {
var totalVertices = this.getTotalVertices();
if (!totalVertices||!this.getIndices()) 
{
return null;
}
this.releaseSubMeshes();
return new BABYLON.SubMesh(0, 0, totalVertices, 0, this.getTotalIndices(), this);
}
public virtual void subdivide(float count) {
if (count<1) 
{
return;
}
var totalIndices = this.getTotalIndices();
var subdivisionSize = (totalIndices/count)|0;
var offset = 0;
while (subdivisionSize%3!=0) {
subdivisionSize++;
}
this.releaseSubMeshes();
for (var index = 0;index<count;index++) 
{
if (offset>=totalIndices) 
{
break;
}
BABYLON.SubMesh.CreateFromIndices(0, offset, Math.min(subdivisionSize, totalIndices-offset), this);
offset+=subdivisionSize;
}
this.synchronizeInstances();
}
public virtual void setVerticesData(object kind, object data, bool updatable) {
if (kindisArray) 
{
var temp = data;
data=kind;
kind=temp;
Tools.Warn("Deprecated usage of setVerticesData detected (since v1.12). Current signature is setVerticesData(kind, data, updatable)");
}
if (!this._geometry) 
{
var vertexData = new BABYLON.VertexData();
vertexData.set(data, kind);
var scene = this.getScene();
new BABYLON.Geometry(Geometry.RandomId(), scene, vertexData, updatable, this);
}
else 
{
this._geometry.setVerticesData(kind, data, updatable);
}
}
public virtual void updateVerticesData(string kind, float[] data, bool updateExtends, bool makeItUnique) {
if (!this._geometry) 
{
return;
}
if (!makeItUnique) 
{
this._geometry.updateVerticesData(kind, data, updateExtends);
}
else 
{
this.makeGeometryUnique();
this.updateVerticesData(kind, data, updateExtends, false);
}
}
public virtual void makeGeometryUnique() {
if (!this._geometry) 
{
return;
}
var geometry = this._geometry.copy(Geometry.RandomId());
geometry.applyToMesh(this);
}
public virtual void setIndices(float[] indices) {
if (!this._geometry) 
{
var vertexData = new BABYLON.VertexData();
vertexData.indices=indices;
var scene = this.getScene();
new BABYLON.Geometry(BABYLON.Geometry.RandomId(), scene, vertexData, false, this);
}
else 
{
this._geometry.setIndices(indices);
}
}
public virtual void _bind(SubMesh subMesh, Effect effect, bool wireframe) {
var engine = this.getScene().getEngine();
var indexToBind = this._geometry.getIndexBuffer();
if (wireframe) 
{
indexToBind=subMesh.getLinesIndexBuffer(this.getIndices(), engine);
}
engine.bindMultiBuffers(this._geometry.getVertexBuffers(), indexToBind, effect);
}
public virtual void _draw(SubMesh subMesh, bool useTriangles, float instancesCount) {
if (!this._geometry||!this._geometry.getVertexBuffers()||!this._geometry.getIndexBuffer()) 
{
return;
}
var engine = this.getScene().getEngine();
engine.draw(useTriangles, (useTriangles) ? subMesh.indexStart : 0, (useTriangles) ? subMesh.indexCount : subMesh.linesIndexCount, instancesCount);
}
public virtual void registerBeforeRender(Func<object> func) {
this._onBeforeRenderCallbacks.push(func);
}
public virtual void unregisterBeforeRender(Func<object> func) {
var index = this._onBeforeRenderCallbacks.indexOf(func);
if (index>-1) 
{
this._onBeforeRenderCallbacks.splice(index, 1);
}
}
public virtual _InstancesBatch _getInstancesRenderList(float subMeshId) {
var scene = this.getScene();
this._batchCache.mustReturn=false;
this._batchCache.renderSelf[subMeshId]=true;
this._batchCache.visibleInstances[subMeshId]=null;
if (this._visibleInstances) 
{
var currentRenderId = scene.getRenderId();
this._batchCache.visibleInstances[subMeshId]=this._visibleInstances[currentRenderId];
var selfRenderId = this._renderId;
if (!this._batchCache.visibleInstances[subMeshId]&&this._visibleInstances.defaultRenderId) 
{
this._batchCache.visibleInstances[subMeshId]=this._visibleInstances[this._visibleInstances.defaultRenderId];
currentRenderId=this._visibleInstances.defaultRenderId;
selfRenderId=this._visibleInstances.selfDefaultRenderId;
}
if (this._batchCache.visibleInstances[subMeshId]&&this._batchCache.visibleInstances[subMeshId].length) 
{
if (this._renderIdForInstances[subMeshId]==currentRenderId) 
{
this._batchCache.mustReturn=true;
return this._batchCache;
}
if (currentRenderId!=selfRenderId) 
{
this._batchCache.renderSelf[subMeshId]=false;
}
}
this._renderIdForInstances[subMeshId]=currentRenderId;
}
return this._batchCache;
}
public virtual void _renderWithInstances(SubMesh subMesh, bool wireFrame, _InstancesBatch batch, Effect effect, Engine engine) {
var matricesCount = this.instances.length+1;
var bufferSize = matricesCount*16*4;
while (this._instancesBufferSize<bufferSize) {
this._instancesBufferSize*=2;
}
if (!this._worldMatricesInstancesBuffer||this._worldMatricesInstancesBuffer.capacity<this._instancesBufferSize) 
{
if (this._worldMatricesInstancesBuffer) 
{
engine.deleteInstancesBuffer(this._worldMatricesInstancesBuffer);
}
this._worldMatricesInstancesBuffer=engine.createInstancesBuffer(this._instancesBufferSize);
this._worldMatricesInstancesArray=new Float32Array(this._instancesBufferSize/4);
}
var offset = 0;
var instancesCount = 0;
var world = this.getWorldMatrix();
if (batch.renderSelf[subMesh._id]) 
{
world.copyToArray(this._worldMatricesInstancesArray, offset);
offset+=16;
instancesCount++;
}
var visibleInstances = batch.visibleInstances[subMesh._id];
if (visibleInstances) 
{
for (var instanceIndex = 0;instanceIndex<visibleInstances.length;instanceIndex++) 
{
var instance = visibleInstances[instanceIndex];
instance.getWorldMatrix().copyToArray(this._worldMatricesInstancesArray, offset);
offset+=16;
instancesCount++;
}
}
var offsetLocation0 = effect.getAttributeLocationByName("world");
var offsetLocation1 = effect.getAttributeLocationByName("world");
var offsetLocation2 = effect.getAttributeLocationByName("world");
var offsetLocation3 = effect.getAttributeLocationByName("world");
var offsetLocations = new Array<object>();
engine.updateAndBindInstancesBuffer(this._worldMatricesInstancesBuffer, this._worldMatricesInstancesArray, offsetLocations);
this._draw(subMesh, !wireFrame, instancesCount);
engine.unBindInstancesBuffer(this._worldMatricesInstancesBuffer, offsetLocations);
}
public virtual void render(SubMesh subMesh) {
var scene = this.getScene();
var batch = this._getInstancesRenderList(subMesh._id);
if (batch.mustReturn) 
{
return;
}
if (!this._geometry||!this._geometry.getVertexBuffers()||!this._geometry.getIndexBuffer()) 
{
return;
}
for (var callbackIndex = 0;callbackIndex<this._onBeforeRenderCallbacks.length;callbackIndex++) 
{
this._onBeforeRenderCallbacks[callbackIndex]();
}
var engine = scene.getEngine();
var hardwareInstancedRendering = (engine.getCaps().instancedArrays!=null)&&(batch.visibleInstances[subMesh._id]!=null);
var effectiveMaterial = subMesh.getMaterial();
if (!effectiveMaterial||!effectiveMaterial.isReady(this, hardwareInstancedRendering)) 
{
return;
}
effectiveMaterial._preBind();
var effect = effectiveMaterial.getEffect();
var wireFrame = engine.forceWireframe||effectiveMaterial.wireframe;
this._bind(subMesh, effect, wireFrame);
var world = this.getWorldMatrix();
effectiveMaterial.bind(world, this);
if (hardwareInstancedRendering) 
{
this._renderWithInstances(subMesh, wireFrame, batch, effect, engine);
}
else 
{
if (batch.renderSelf[subMesh._id]) 
{
this._draw(subMesh, !wireFrame);
}
if (batch.visibleInstances[subMesh._id]) 
{
for (var instanceIndex = 0;instanceIndex<batch.visibleInstances[subMesh._id].length;instanceIndex++) 
{
var instance = batch.visibleInstances[subMesh._id][instanceIndex];
world=instance.getWorldMatrix();
effectiveMaterial.bindOnlyWorldMatrix(world);
this._draw(subMesh, !wireFrame);
}
}
}
effectiveMaterial.unbind();
}
public virtual ParticleSystem[] getEmittedParticleSystems() {
var results = new Array();
for (var index = 0;index<this.getScene().particleSystems.length;index++) 
{
var particleSystem = this.getScene().particleSystems[index];
if (particleSystem.emitter==this) 
{
results.push(particleSystem);
}
}
return results;
}
public virtual ParticleSystem[] getHierarchyEmittedParticleSystems() {
var results = new Array();
var descendants = this.getDescendants();
descendants.push(this);
for (var index = 0;index<this.getScene().particleSystems.length;index++) 
{
var particleSystem = this.getScene().particleSystems[index];
if (descendants.indexOf(particleSystem.emitter)!=-1) 
{
results.push(particleSystem);
}
}
return results;
}
public virtual Node[] getChildren() {
var results = new Array<object>();
for (var index = 0;index<this.getScene().meshes.length;index++) 
{
var mesh = this.getScene().meshes[index];
if (mesh.parent==this) 
{
results.push(mesh);
}
}
return results;
}
public virtual void _checkDelayState() {
var that = this;
var scene = this.getScene();
if (this._geometry) 
{
this._geometry.load(scene);
}
else 
if (that.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_NOTLOADED) 
{
that.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_LOADING;
scene._addPendingData(that);
BABYLON.Tools.LoadFile(this.delayLoadingFile, (dynamic data) => {
this._delayLoadingFunction(JSON.parse(data), this);
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_LOADED;
scene._removePendingData(this);
}
, () => {
}
, scene.database);
}
}
public virtual bool isInFrustum(Plane[] frustumPlanes) {
if (this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_LOADING) 
{
return false;
}
if (!base.isInFrustum(frustumPlanes)) 
{
return false;
}
this._checkDelayState();
return true;
}
public virtual void setMaterialByID(string id) {
var materials = this.getScene().materials;
for (var index = 0;index<materials.length;index++) 
{
if (materials[index].id==id) 
{
this.material=materials[index];
return;
}
}
var multiMaterials = this.getScene().multiMaterials;
for (index=0;index<multiMaterials.length;index++) 
{
if (multiMaterials[index].id==id) 
{
this.material=multiMaterials[index];
return;
}
}
}
public virtual IAnimatable[] getAnimatables() {
var results = new Array<object>();
if (this.material) 
{
results.push(this.material);
}
return results;
}
public virtual void bakeTransformIntoVertices(Matrix transform) {
if (!this.isVerticesDataPresent(BABYLON.VertexBuffer.PositionKind)) 
{
return;
}
this._resetPointsArrayCache();
var data = this.getVerticesData(BABYLON.VertexBuffer.PositionKind);
var temp = new Array<object>();
for (var index = 0;index<data.length;index+=3) 
{
BABYLON.Vector3.TransformCoordinates(BABYLON.Vector3.FromArray(data, index), transform).toArray(temp, index);
}
this.setVerticesData(BABYLON.VertexBuffer.PositionKind, temp, this.getVertexBuffer(BABYLON.VertexBuffer.PositionKind).isUpdatable());
if (!this.isVerticesDataPresent(BABYLON.VertexBuffer.NormalKind)) 
{
return;
}
data=this.getVerticesData(BABYLON.VertexBuffer.NormalKind);
for (index=0;index<data.length;index+=3) 
{
BABYLON.Vector3.TransformNormal(BABYLON.Vector3.FromArray(data, index), transform).toArray(temp, index);
}
this.setVerticesData(BABYLON.VertexBuffer.NormalKind, temp, this.getVertexBuffer(BABYLON.VertexBuffer.NormalKind).isUpdatable());
}
public virtual void _resetPointsArrayCache() {
this._positions=null;
}
public virtual bool _generatePointsArray() {
if (this._positions) 
return true;
this._positions=new Array<object>();
var data = this.getVerticesData(BABYLON.VertexBuffer.PositionKind);
if (!data) 
{
return false;
}
for (var index = 0;index<data.length;index+=3) 
{
this._positions.push(BABYLON.Vector3.FromArray(data, index));
}
return true;
}
public virtual Mesh clone(string name, Node newParent, bool doNotCloneChildren) {
var result = new BABYLON.Mesh(name, this.getScene());
this._geometry.applyToMesh(result);
BABYLON.Tools.DeepCopy(this, result, new Array<object>(), new Array<object>());
result.material=this.material;
if (newParent) 
{
result.parent=newParent;
}
if (!doNotCloneChildren) 
{
for (var index = 0;index<this.getScene().meshes.length;index++) 
{
var mesh = this.getScene().meshes[index];
if (mesh.parent==this) 
{
mesh.clone(mesh.name, result);
}
}
}
for (index=0;index<this.getScene().particleSystems.length;index++) 
{
var system = this.getScene().particleSystems[index];
if (system.emitter==this) 
{
system.clone(system.name, result);
}
}
result.computeWorldMatrix(true);
return result;
}
public virtual void dispose(bool doNotRecurse) {
if (this._geometry) 
{
this._geometry.releaseForMesh(this, true);
}
if (this._worldMatricesInstancesBuffer) 
{
this.getEngine().deleteInstancesBuffer(this._worldMatricesInstancesBuffer);
this._worldMatricesInstancesBuffer=null;
}
while (this.instances.length) {
this.instances[0].dispose();
}
base.dispose(doNotRecurse);
}
public virtual void convertToFlatShadedMesh() {
var kinds = this.getVerticesDataKinds();
var vbs = new Array<object>();
var data = new Array<object>();
var newdata = new Array<object>();
var updatableNormals = false;
for (var kindIndex = 0;kindIndex<kinds.length;kindIndex++) 
{
var kind = kinds[kindIndex];
var vertexBuffer = this.getVertexBuffer(kind);
if (kind==BABYLON.VertexBuffer.NormalKind) 
{
updatableNormals=vertexBuffer.isUpdatable();
kinds.splice(kindIndex, 1);
kindIndex--;
continue;
}
vbs[kind]=vertexBuffer;
data[kind]=vbs[kind].getData();
newdata[kind]=new Array<object>();
}
var previousSubmeshes = this.subMeshes.slice(0);
var indices = this.getIndices();
var totalIndices = this.getTotalIndices();
for (index=0;index<totalIndices;index++) 
{
var vertexIndex = indices[index];
for (kindIndex=0;kindIndex<kinds.length;kindIndex++) 
{
kind=kinds[kindIndex];
var stride = vbs[kind].getStrideSize();
for (var offset = 0;offset<stride;offset++) 
{
newdata[kind].push(data[kind][vertexIndex*stride+offset]);
}
}
}
var normals = new Array<object>();
var positions = newdata[BABYLON.VertexBuffer.PositionKind];
for (var index = 0;index<totalIndices;index+=3) 
{
indices[index]=index;
indices[index+1]=index+1;
indices[index+2]=index+2;
var p1 = BABYLON.Vector3.FromArray(positions, index*3);
var p2 = BABYLON.Vector3.FromArray(positions, (index+1)*3);
var p3 = BABYLON.Vector3.FromArray(positions, (index+2)*3);
var p1p2 = p1.subtract(p2);
var p3p2 = p3.subtract(p2);
var normal = BABYLON.Vector3.Normalize(BABYLON.Vector3.Cross(p1p2, p3p2));
for (var localIndex = 0;localIndex<3;localIndex++) 
{
normals.push(normal.x);
normals.push(normal.y);
normals.push(normal.z);
}
}
this.setIndices(indices);
this.setVerticesData(BABYLON.VertexBuffer.NormalKind, normals, updatableNormals);
for (kindIndex=0;kindIndex<kinds.length;kindIndex++) 
{
kind=kinds[kindIndex];
this.setVerticesData(kind, newdata[kind], vbs[kind].isUpdatable());
}
this.releaseSubMeshes();
for (var submeshIndex = 0;submeshIndex<previousSubmeshes.length;submeshIndex++) 
{
var previousOne = previousSubmeshes[submeshIndex];
var subMesh = new BABYLON.SubMesh(previousOne.materialIndex, previousOne.indexStart, previousOne.indexCount, previousOne.indexStart, previousOne.indexCount, this);
}
this.synchronizeInstances();
}
public virtual InstancedMesh createInstance(string name) {
return new InstancedMesh(name, this);
}
public virtual void synchronizeInstances() {
for (var instanceIndex = 0;instanceIndex<this.instances.length;instanceIndex++) 
{
var instance = this.instances[instanceIndex];
instance._syncSubMeshes();
}
}
public static virtual Mesh CreateBox(string name, float size, Scene scene, bool updatable) {
var box = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateBox(size);
vertexData.applyToMesh(box, updatable);
return box;
}
public static virtual Mesh CreateSphere(string name, float segments, float diameter, Scene scene, bool updatable) {
var sphere = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateSphere(segments, diameter);
vertexData.applyToMesh(sphere, updatable);
return sphere;
}
public static virtual Mesh CreateCylinder(string name, float height, float diameterTop, float diameterBottom, float tessellation, object subdivisions, Scene scene, object updatable) {
if (scene==undefined||!(sceneisScene)) 
{
if (scene!=undefined) 
{
updatable=scene;
}
scene=(Scene)subdivisions;
subdivisions=1;
}
var cylinder = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateCylinder(height, diameterTop, diameterBottom, tessellation, subdivisions);
vertexData.applyToMesh(cylinder, updatable);
return cylinder;
}
public static virtual Mesh CreateTorus(string name, float diameter, float thickness, float tessellation, Scene scene, bool updatable) {
var torus = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateTorus(diameter, thickness, tessellation);
vertexData.applyToMesh(torus, updatable);
return torus;
}
public static virtual Mesh CreateTorusKnot(string name, float radius, float tube, float radialSegments, float tubularSegments, float p, float q, Scene scene, bool updatable) {
var torusKnot = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateTorusKnot(radius, tube, radialSegments, tubularSegments, p, q);
vertexData.applyToMesh(torusKnot, updatable);
return torusKnot;
}
public static virtual LinesMesh CreateLines(string name, Vector3[] points, Scene scene, bool updatable) {
var lines = new LinesMesh(name, scene, updatable);
var vertexData = BABYLON.VertexData.CreateLines(points);
vertexData.applyToMesh(lines, updatable);
return lines;
}
public static virtual Mesh CreatePlane(string name, float size, Scene scene, bool updatable) {
var plane = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreatePlane(size);
vertexData.applyToMesh(plane, updatable);
return plane;
}
public static virtual Mesh CreateGround(string name, float width, float height, float subdivisions, Scene scene, bool updatable) {
var ground = new BABYLON.GroundMesh(name, scene);
ground._setReady(false);
ground._subdivisions=subdivisions;
var vertexData = BABYLON.VertexData.CreateGround(width, height, subdivisions);
vertexData.applyToMesh(ground, updatable);
ground._setReady(true);
return ground;
}
public static virtual Mesh CreateTiledGround(string name, float xmin, float zmin, float xmax, float zmax, new {float w;
, float h;
} subdivisions, new {float w;
, float h;
} precision, Scene scene, bool updatable) {
var tiledGround = new BABYLON.Mesh(name, scene);
var vertexData = BABYLON.VertexData.CreateTiledGround(xmin, zmin, xmax, zmax, subdivisions, precision);
vertexData.applyToMesh(tiledGround, updatable);
return tiledGround;
}
public static virtual GroundMesh CreateGroundFromHeightMap(string name, string url, float width, float height, float subdivisions, float minHeight, float maxHeight, Scene scene, bool updatable) {
var ground = new BABYLON.GroundMesh(name, scene);
ground._subdivisions=subdivisions;
ground._setReady(false);
var onload = (dynamic img) => {
var canvas = document.createElement("canva");
var context = canvas.getContext("2");
var heightMapWidth = img.width;
var heightMapHeight = img.height;
canvas.width=heightMapWidth;
canvas.height=heightMapHeight;
context.drawImage(img, 0, 0);
var buffer = context.getImageData(0, 0, heightMapWidth, heightMapHeight).data;
var vertexData = VertexData.CreateGroundFromHeightMap(width, height, subdivisions, minHeight, maxHeight, buffer, heightMapWidth, heightMapHeight);
vertexData.applyToMesh(ground, updatable);
ground._setReady(true);
}
;
Tools.LoadImage(url, onload, () => {
}
, scene.database);
return ground;
}
public static virtual new {Vector3 min;
, Vector3 max;
} MinMax(AbstractMesh[] meshes) {
var minVector = null;
var maxVector = null;
foreach (var i in meshes) 
{
var mesh = meshes[i];
var boundingBox = mesh.getBoundingInfo().boundingBox;
if (!minVector) 
{
minVector=boundingBox.minimumWorld;
maxVector=boundingBox.maximumWorld;
continue;
}
minVector.MinimizeInPlace(boundingBox.minimumWorld);
maxVector.MaximizeInPlace(boundingBox.maximumWorld);
}
return new dynamic();
}
public static virtual Vector3 Center(dynamic meshesOrMinMaxVector) {
var minMaxVector = (meshesOrMinMaxVector.min!=undefined) ? meshesOrMinMaxVector : BABYLON.Mesh.MinMax(meshesOrMinMaxVector);
return BABYLON.Vector3.Center(minMaxVector.min, minMaxVector.max);
}
}
}
