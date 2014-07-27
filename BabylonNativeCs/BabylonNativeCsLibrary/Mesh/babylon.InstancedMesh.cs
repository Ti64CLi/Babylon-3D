using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class InstancedMesh: AbstractMesh {
private Mesh _sourceMesh;
public InstancedMesh(string name, Mesh source) {
base(name, source.getScene());
source.instances.push(this);
this._sourceMesh=source;
this.position.copyFrom(source.position);
this.rotation.copyFrom(source.rotation);
this.scaling.copyFrom(source.scaling);
if (source.rotationQuaternion) 
{
this.rotationQuaternion=source.rotationQuaternion.clone();
}
this.infiniteDistance=source.infiniteDistance;
this.setPivotMatrix(source.getPivotMatrix());
this.refreshBoundingInfo();
this._syncSubMeshes();
}
public virtual float getTotalVertices() {
return this._sourceMesh.getTotalVertices();
}
public virtual float[] getVerticesData(string kind) {
return this._sourceMesh.getVerticesData(kind);
}
public virtual bool isVerticesDataPresent(string kind) {
return this._sourceMesh.isVerticesDataPresent(kind);
}
public virtual float[] getIndices() {
return this._sourceMesh.getIndices();
}
public virtual void refreshBoundingInfo() {
var data = this._sourceMesh.getVerticesData(BABYLON.VertexBuffer.PositionKind);
if (data) 
{
var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this._sourceMesh.getTotalVertices());
this._boundingInfo=new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
}
this._updateBoundingInfo();
}
public virtual void _activate(float renderId) {
this.sourceMesh._registerInstanceForRenderId(this, renderId);
}
public virtual void _syncSubMeshes() {
this.releaseSubMeshes();
for (var index = 0;index<this._sourceMesh.subMeshes.length;index++) 
{
this._sourceMesh.subMeshes[index].clone(this, this._sourceMesh);
}
}
public virtual bool _generatePointsArray() {
return this._sourceMesh._generatePointsArray();
}
public virtual InstancedMesh clone(string name, Node newParent, bool doNotCloneChildren) {
var result = this._sourceMesh.createInstance(name);
BABYLON.Tools.DeepCopy(this, result, new Array<object>(), new Array<object>());
this.refreshBoundingInfo();
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
result.computeWorldMatrix(true);
return result;
}
public virtual void dispose(bool doNotRecurse) {
var index = this._sourceMesh.instances.indexOf(this);
this._sourceMesh.instances.splice(index, 1);
base.dispose(doNotRecurse);
}
}
}
