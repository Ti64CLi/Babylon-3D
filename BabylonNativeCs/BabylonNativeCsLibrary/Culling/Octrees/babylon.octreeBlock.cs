using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class OctreeBlock {
public dynamic entries=new Array();
public Array<OctreeBlock<T>> blocks;
private float _depth;
private float _maxDepth;
private float _capacity;
private Vector3 _minPoint;
private Vector3 _maxPoint;
private dynamic _boundingVectors=new Array();
private Func<T, OctreeBlock<T>, object> _creationFunc;
public OctreeBlock(Vector3 minPoint, Vector3 maxPoint, float capacity, float depth, float maxDepth, Func<T, OctreeBlock<T>, object> creationFunc) {
this._capacity=capacity;
this._depth=depth;
this._maxDepth=maxDepth;
this._creationFunc=creationFunc;
this._minPoint=minPoint;
this._maxPoint=maxPoint;
this._boundingVectors.push(minPoint.clone());
this._boundingVectors.push(maxPoint.clone());
this._boundingVectors.push(minPoint.clone());
this._boundingVectors[2].x=maxPoint.x;
this._boundingVectors.push(minPoint.clone());
this._boundingVectors[3].y=maxPoint.y;
this._boundingVectors.push(minPoint.clone());
this._boundingVectors[4].z=maxPoint.z;
this._boundingVectors.push(maxPoint.clone());
this._boundingVectors[5].z=minPoint.z;
this._boundingVectors.push(maxPoint.clone());
this._boundingVectors[6].x=minPoint.x;
this._boundingVectors.push(maxPoint.clone());
this._boundingVectors[7].y=minPoint.y;
}
public virtual void addEntry(T entry) {
if (this.blocks) 
{
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.addEntry(entry);
}
return;
}
this._creationFunc(entry, this);
if (this.entries.length>this.capacity&&this._depth<this._maxDepth) 
{
this.createInnerBlocks();
}
}
public virtual void addEntries(T[] entries) {
for (var index = 0;index<entries.length;index++) 
{
var mesh = entries[index];
this.addEntry(mesh);
}
}
public virtual void select(Plane[] frustumPlanes, SmartArray<T> selection, bool allowDuplicate) {
if (BABYLON.BoundingBox.IsInFrustum(this._boundingVectors, frustumPlanes)) 
{
if (this.blocks) 
{
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.select(frustumPlanes, selection, allowDuplicate);
}
return;
}
if (allowDuplicate) 
{
selection.concat(this.entries);
}
else 
{
selection.concatWithNoDuplicate(this.entries);
}
}
}
public virtual void intersects(Vector3 sphereCenter, float sphereRadius, SmartArray<T> selection, bool allowDuplicate) {
if (BABYLON.BoundingBox.IntersectsSphere(this._minPoint, this._maxPoint, sphereCenter, sphereRadius)) 
{
if (this.blocks) 
{
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.intersects(sphereCenter, sphereRadius, selection, allowDuplicate);
}
return;
}
if (allowDuplicate) 
{
selection.concat(this.entries);
}
else 
{
selection.concatWithNoDuplicate(this.entries);
}
}
}
public virtual void intersectsRay(Ray ray, SmartArray<T> selection) {
if (ray.intersectsBoxMinMax(this._minPoint, this._maxPoint)) 
{
if (this.blocks) 
{
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.intersectsRay(ray, selection);
}
return;
}
selection.concatWithNoDuplicate(this.entries);
}
}
public virtual void createInnerBlocks() {
Octree._CreateBlocks(this._minPoint, this._maxPoint, this.entries, this._capacity, this._depth, this._maxDepth, this, this._creationFunc);
}
}
}
