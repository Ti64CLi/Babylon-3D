using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class BoundingBox {
public Vector3[] vectors=new Array();
public Vector3 center;
public Vector3 extends;
public Vector3[] directions;
public Vector3[] vectorsWorld=new Array();
public Vector3 minimumWorld;
public Vector3 maximumWorld;
private Matrix _worldMatrix;
public Vector3 minimum;
public Vector3 maximum;
public BoundingBox(Vector3 minimum, Vector3 maximum) {
this.vectors.push(this.minimum.clone());
this.vectors.push(this.maximum.clone());
this.vectors.push(this.minimum.clone());
this.vectors[2].x=this.maximum.x;
this.vectors.push(this.minimum.clone());
this.vectors[3].y=this.maximum.y;
this.vectors.push(this.minimum.clone());
this.vectors[4].z=this.maximum.z;
this.vectors.push(this.maximum.clone());
this.vectors[5].z=this.minimum.z;
this.vectors.push(this.maximum.clone());
this.vectors[6].x=this.minimum.x;
this.vectors.push(this.maximum.clone());
this.vectors[7].y=this.minimum.y;
this.center=this.maximum.add(this.minimum).scale(0.5);
this.extends=this.maximum.subtract(this.minimum).scale(0.5);
this.directions=new Array<object>();
for (var index = 0;index<this.vectors.length;index++) 
{
this.vectorsWorld[index]=BABYLON.Vector3.Zero();
}
this.minimumWorld=BABYLON.Vector3.Zero();
this.maximumWorld=BABYLON.Vector3.Zero();
this._update(BABYLON.Matrix.Identity());
}
var intersectBoxAASphere = (Vector3 boxMin, Vector3 boxMax, Vector3 sphereCenter, float sphereRadius) => {
if (boxMin.x>sphereCenter.x+sphereRadius) 
return false;
if (sphereCenter.x-sphereRadius>boxMax.x) 
return false;
if (boxMin.y>sphereCenter.y+sphereRadius) 
return false;
if (sphereCenter.y-sphereRadius>boxMax.y) 
return false;
if (boxMin.z>sphereCenter.z+sphereRadius) 
return false;
if (sphereCenter.z-sphereRadius>boxMax.z) 
return false;
return true;
}
;
var getLowestRoot = (float a, float b, float c, float maxR) => {
var determinant = b*b-4.0*a*c;
var result = new dynamic();
if (determinant<0) 
return result;
var sqrtD = Math.sqrt(determinant);
var r1 = (-b-sqrtD)/(2.0*a);
var r2 = (-b+sqrtD)/(2.0*a);
if (r1>r2) 
{
var temp = r2;
r2=r1;
r1=temp;
}
if (r1>0&&r1<maxR) 
{
result.root=r1;
result.found=true;
return result;
}
if (r2>0&&r2<maxR) 
{
result.root=r2;
result.found=true;
return result;
}
return result;
}
;
public virtual Matrix getWorldMatrix() {
return this._worldMatrix;
}
public virtual void _update(Matrix world) {
Vector3.FromFloatsToRef(Number.MAX_VALUE, Number.MAX_VALUE, Number.MAX_VALUE, this.minimumWorld);
Vector3.FromFloatsToRef(-Number.MAX_VALUE, -Number.MAX_VALUE, -Number.MAX_VALUE, this.maximumWorld);
for (var index = 0;index<this.vectors.length;index++) 
{
var v = this.vectorsWorld[index];
BABYLON.Vector3.TransformCoordinatesToRef(this.vectors[index], world, v);
if (v.x<this.minimumWorld.x) 
this.minimumWorld.x=v.x;
if (v.y<this.minimumWorld.y) 
this.minimumWorld.y=v.y;
if (v.z<this.minimumWorld.z) 
this.minimumWorld.z=v.z;
if (v.x>this.maximumWorld.x) 
this.maximumWorld.x=v.x;
if (v.y>this.maximumWorld.y) 
this.maximumWorld.y=v.y;
if (v.z>this.maximumWorld.z) 
this.maximumWorld.z=v.z;
}
this.maximumWorld.addToRef(this.minimumWorld, this.center);
this.center.scaleInPlace(0.5);
Vector3.FromFloatArrayToRef(world.m, 0, this.directions[0]);
Vector3.FromFloatArrayToRef(world.m, 4, this.directions[1]);
Vector3.FromFloatArrayToRef(world.m, 8, this.directions[2]);
this._worldMatrix=world;
}
public virtual bool isInFrustum(Plane[] frustumPlanes) {
return BoundingBox.IsInFrustum(this.vectorsWorld, frustumPlanes);
}
public virtual bool intersectsPoint(Vector3 point) {
var delta = Engine.Epsilon;
if (this.maximumWorld.x-point.x<delta||delta>point.x-this.minimumWorld.x) 
return false;
if (this.maximumWorld.y-point.y<delta||delta>point.y-this.minimumWorld.y) 
return false;
if (this.maximumWorld.z-point.z<delta||delta>point.z-this.minimumWorld.z) 
return false;
return true;
}
public virtual bool intersectsSphere(BoundingSphere sphere) {
return BoundingBox.IntersectsSphere(this.minimumWorld, this.maximumWorld, sphere.centerWorld, sphere.radiusWorld);
}
public virtual bool intersectsMinMax(Vector3 min, Vector3 max) {
if (this.maximumWorld.x<min.x||this.minimumWorld.x>max.x) 
return false;
if (this.maximumWorld.y<min.y||this.minimumWorld.y>max.y) 
return false;
if (this.maximumWorld.z<min.z||this.minimumWorld.z>max.z) 
return false;
return true;
}
public static virtual bool Intersects(BoundingBox box0, BoundingBox box1) {
if (box0.maximumWorld.x<box1.minimumWorld.x||box0.minimumWorld.x>box1.maximumWorld.x) 
return false;
if (box0.maximumWorld.y<box1.minimumWorld.y||box0.minimumWorld.y>box1.maximumWorld.y) 
return false;
if (box0.maximumWorld.z<box1.minimumWorld.z||box0.minimumWorld.z>box1.maximumWorld.z) 
return false;
return true;
}
public static virtual bool IntersectsSphere(Vector3 minPoint, Vector3 maxPoint, Vector3 sphereCenter, float sphereRadius) {
var vector = BABYLON.Vector3.Clamp(sphereCenter, minPoint, maxPoint);
var num = BABYLON.Vector3.DistanceSquared(sphereCenter, vector);
return (num<=(sphereRadius*sphereRadius));
}
public static virtual bool IsInFrustum(Vector3[] boundingVectors, Plane[] frustumPlanes) {
for (var p = 0;p<6;p++) 
{
var inCount = 8;
for (var i = 0;i<8;i++) 
{
if (frustumPlanes[p].dotCoordinate(boundingVectors[i])<0) 
{
--inCount;
}
else 
{
break;
}
}
if (inCount==0) 
return false;
}
return true;
}
}
}
