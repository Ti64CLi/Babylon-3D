using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class IntersectionInfo {
public dynamic faceId=0;
public float bu;
public float bv;
public float distance;
public IntersectionInfo(float bu, float bv, float distance) {
}
}
public class PickingInfo {
public dynamic hit=false;
public dynamic distance=0;
public Vector3 pickedPoint=null;
public AbstractMesh pickedMesh=null;
public dynamic bu=0;
public dynamic bv=0;
public dynamic faceId=-1;
public virtual Vector3 getNormal() {
if (!this.pickedMesh||!this.pickedMesh.isVerticesDataPresent(BABYLON.VertexBuffer.NormalKind)) 
{
return null;
}
var indices = this.pickedMesh.getIndices();
var normals = this.pickedMesh.getVerticesData(BABYLON.VertexBuffer.NormalKind);
var normal0 = BABYLON.Vector3.FromArray(normals, indices[this.faceId*3]*3);
var normal1 = BABYLON.Vector3.FromArray(normals, indices[this.faceId*3+1]*3);
var normal2 = BABYLON.Vector3.FromArray(normals, indices[this.faceId*3+2]*3);
normal0=normal0.scale(this.bu);
normal1=normal1.scale(this.bv);
normal2=normal2.scale(1.0-this.bu-this.bv);
return new BABYLON.Vector3(normal0.x+normal1.x+normal2.x, normal0.y+normal1.y+normal2.y, normal0.z+normal1.z+normal2.z);
}
public virtual Vector2 getTextureCoordinates() {
if (!this.pickedMesh||!this.pickedMesh.isVerticesDataPresent(BABYLON.VertexBuffer.UVKind)) 
{
return null;
}
var indices = this.pickedMesh.getIndices();
var uvs = this.pickedMesh.getVerticesData(BABYLON.VertexBuffer.UVKind);
var uv0 = BABYLON.Vector2.FromArray(uvs, indices[this.faceId*3]*2);
var uv1 = BABYLON.Vector2.FromArray(uvs, indices[this.faceId*3+1]*2);
var uv2 = BABYLON.Vector2.FromArray(uvs, indices[this.faceId*3+2]*2);
uv0=uv0.scale(this.bu);
uv1=uv1.scale(this.bv);
uv2=uv2.scale(1.0-this.bu-this.bv);
return new BABYLON.Vector2(uv0.x+uv1.x+uv2.x, uv0.y+uv1.y+uv2.y);
}
}
}
