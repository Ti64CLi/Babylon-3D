using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class SubMesh {
public float linesIndexCount;
private AbstractMesh _mesh;
private Mesh _renderingMesh;
private BoundingInfo _boundingInfo;
private WebGLBuffer _linesIndexBuffer;
public Vector3[] _lastColliderWorldVertices;
public Plane[] _trianglePlanes;
public Matrix _lastColliderTransformMatrix;
dynamic _renderId=0;
public float _distanceToCamera;
public float _id;
public float materialIndex;
public float verticesStart;
public float verticesCount;
public dynamic indexStart;
public float indexCount;
public SubMesh(float materialIndex, float verticesStart, float verticesCount, dynamic indexStart, float indexCount, AbstractMesh mesh, Mesh renderingMesh, bool createBoundingBox) {
this._mesh=mesh;
this._renderingMesh=renderingMesh||(Mesh)mesh;
mesh.subMeshes.push(this);
this._id=mesh.subMeshes.length-1;
if (createBoundingBox) 
{
this.refreshBoundingInfo();
}
}
public virtual BoundingInfo getBoundingInfo() {
return this._boundingInfo;
}
public virtual AbstractMesh getMesh() {
return this._mesh;
}
public virtual Mesh getRenderingMesh() {
return this._renderingMesh;
}
public virtual Material getMaterial() {
var rootMaterial = this._renderingMesh.material;
if (rootMaterial&&rootMaterialisMultiMaterial) 
{
var multiMaterial = (MultiMaterial)rootMaterial;
return multiMaterial.getSubMaterial(this.materialIndex);
}
if (!rootMaterial) 
{
return this._mesh.getScene().defaultMaterial;
}
return rootMaterial;
}
public virtual void refreshBoundingInfo() {
var data = this._renderingMesh.getVerticesData(VertexBuffer.PositionKind);
if (!data) 
{
this._boundingInfo=this._mesh._boundingInfo;
return;
}
var indices = this._renderingMesh.getIndices();
var extend;
if (this.indexStart==0&&this.indexCount==indices.length) 
{
extend=BABYLON.Tools.ExtractMinAndMax(data, this.verticesStart, this.verticesCount);
}
else 
{
extend=BABYLON.Tools.ExtractMinAndMaxIndexed(data, indices, this.indexStart, this.indexCount);
}
this._boundingInfo=new BoundingInfo(extend.minimum, extend.maximum);
}
public virtual bool _checkCollision(Collider collider) {
return this._boundingInfo._checkCollision(collider);
}
public virtual void updateBoundingInfo(Matrix world) {
if (!this._boundingInfo) 
{
this.refreshBoundingInfo();
}
this._boundingInfo._update(world);
}
public virtual bool isInFrustum(Plane[] frustumPlanes) {
return this._boundingInfo.isInFrustum(frustumPlanes);
}
public virtual void render() {
this._renderingMesh.render(this);
}
public virtual WebGLBuffer getLinesIndexBuffer(float[] indices, dynamic engine) {
if (!this._linesIndexBuffer) 
{
var linesIndices = new Array<object>();
for (var index = this.indexStart;index<this.indexStart+this.indexCount;index+=3) 
{
linesIndices.push(indices[index], indices[index+1], indices[index+1], indices[index+2], indices[index+2], indices[index]);
}
this._linesIndexBuffer=engine.createIndexBuffer(linesIndices);
this.linesIndexCount=linesIndices.length;
}
return this._linesIndexBuffer;
}
public virtual bool canIntersects(Ray ray) {
return ray.intersectsBox(this._boundingInfo.boundingBox);
}
public virtual IntersectionInfo intersects(Ray ray, Vector3[] positions, float[] indices, bool fastCheck) {
var intersectInfo = null;
for (var index = this.indexStart;index<this.indexStart+this.indexCount;index+=3) 
{
var p0 = positions[indices[index]];
var p1 = positions[indices[index+1]];
var p2 = positions[indices[index+2]];
var currentIntersectInfo = ray.intersectsTriangle(p0, p1, p2);
if (currentIntersectInfo) 
{
if (fastCheck||!intersectInfo||currentIntersectInfo.distance<intersectInfo.distance) 
{
intersectInfo=currentIntersectInfo;
intersectInfo.faceId=index/3;
if (fastCheck) 
{
break;
}
}
}
}
return intersectInfo;
}
public virtual SubMesh clone(AbstractMesh newMesh, Mesh newRenderingMesh) {
var result = new SubMesh(this.materialIndex, this.verticesStart, this.verticesCount, this.indexStart, this.indexCount, newMesh, newRenderingMesh, false);
result._boundingInfo=new BoundingInfo(this._boundingInfo.minimum, this._boundingInfo.maximum);
return result;
}
public virtual void dispose() {
if (this._linesIndexBuffer) 
{
this._mesh.getScene().getEngine()._releaseBuffer(this._linesIndexBuffer);
this._linesIndexBuffer=null;
}
var index = this._mesh.subMeshes.indexOf(this);
this._mesh.subMeshes.splice(index, 1);
}
public static virtual SubMesh CreateFromIndices(float materialIndex, float startIndex, float indexCount, AbstractMesh mesh, Mesh renderingMesh) {
var minVertexIndex = Number.MAX_VALUE;
var maxVertexIndex = -Number.MAX_VALUE;
renderingMesh=renderingMesh||(Mesh)mesh;
var indices = renderingMesh.getIndices();
for (var index = startIndex;index<startIndex+indexCount;index++) 
{
var vertexIndex = indices[index];
if (vertexIndex<minVertexIndex) 
minVertexIndex=vertexIndex;
if (vertexIndex>maxVertexIndex) 
maxVertexIndex=vertexIndex;
}
return new BABYLON.SubMesh(materialIndex, minVertexIndex, maxVertexIndex-minVertexIndex+1, startIndex, indexCount, mesh, renderingMesh);
}
}
}
