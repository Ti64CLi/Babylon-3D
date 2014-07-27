using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public interface IOctreeContainer {
Array<OctreeBlock<T>> blocks;
}
public class Octree {
public Array<OctreeBlock<T>> blocks;
public dynamic dynamicContent=new Array();
private float _maxBlockCapacity;
private SmartArray<T> _selectionContent;
private Func<T, OctreeBlock<T>, object> _creationFunc;
public dynamic maxDepth;
public Octree(Func<T, OctreeBlock<T>, object> creationFunc, float maxBlockCapacity, dynamic maxDepth) {
this._maxBlockCapacity=maxBlockCapacity||64;
this._selectionContent=new BABYLON.SmartArray(1024);
this._creationFunc=creationFunc;
}
public virtual void update(Vector3 worldMin, Vector3 worldMax, T[] entries) {
Octree._CreateBlocks(worldMin, worldMax, entries, this._maxBlockCapacity, 0, this.maxDepth, this, this._creationFunc);
}
public virtual void addMesh(T entry) {
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.addEntry(entry);
}
}
public virtual SmartArray<T> select(Plane[] frustumPlanes, bool allowDuplicate) {
this._selectionContent.reset();
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.select(frustumPlanes, this._selectionContent, allowDuplicate);
}
if (allowDuplicate) 
{
this._selectionContent.concat(this.dynamicContent);
}
else 
{
this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
}
return this._selectionContent;
}
public virtual SmartArray<T> intersects(Vector3 sphereCenter, float sphereRadius, bool allowDuplicate) {
this._selectionContent.reset();
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.intersects(sphereCenter, sphereRadius, this._selectionContent, allowDuplicate);
}
if (allowDuplicate) 
{
this._selectionContent.concat(this.dynamicContent);
}
else 
{
this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
}
return this._selectionContent;
}
public virtual SmartArray<T> intersectsRay(Ray ray) {
this._selectionContent.reset();
for (var index = 0;index<this.blocks.length;index++) 
{
var block = this.blocks[index];
block.intersectsRay(ray, this._selectionContent);
}
this._selectionContent.concatWithNoDuplicate(this.dynamicContent);
return this._selectionContent;
}
public static virtual void _CreateBlocks(Vector3 worldMin, Vector3 worldMax, T[] entries, float maxBlockCapacity, float currentDepth, float maxDepth, IOctreeContainer<T> target, Func<T, OctreeBlock<T>, object> creationFunc) {
target.blocks=new Array();
var blockSize = new BABYLON.Vector3((worldMax.x-worldMin.x)/2, (worldMax.y-worldMin.y)/2, (worldMax.z-worldMin.z)/2);
for (var x = 0;x<2;x++) 
{
for (var y = 0;y<2;y++) 
{
for (var z = 0;z<2;z++) 
{
var localMin = worldMin.add(blockSize.multiplyByFloats(x, y, z));
var localMax = worldMin.add(blockSize.multiplyByFloats(x+1, y+1, z+1));
var block = new BABYLON.OctreeBlock(localMin, localMax, maxBlockCapacity, currentDepth+1, maxDepth, creationFunc);
block.addEntries(entries);
target.blocks.push(block);
}
}
}
}
public static dynamic CreationFuncForMeshes=(AbstractMesh entry, OctreeBlock<AbstractMesh> block) => {
if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint)) 
{
block.entries.push(entry);
}
}
;
public static dynamic CreationFuncForSubMeshes=(SubMesh entry, OctreeBlock<SubMesh> block) => {
if (entry.getBoundingInfo().boundingBox.intersectsMinMax(block.minPoint, block.maxPoint)) 
{
block.entries.push(entry);
}
}
;
}
}
