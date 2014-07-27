using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class GroundMesh: Mesh {
dynamic generateOctree=false;
dynamic _worldInverse=new BABYLON.Matrix();
public float _subdivisions;
public GroundMesh(string name, Scene scene) {
base(name, scene);
}
public virtual void optimize(float chunksCount) {
this.subdivide(this._subdivisions);
this.createOrUpdateSubmeshesOctree(32);
}
public virtual float getHeightAtCoordinates(float x, float z) {
var ray = new BABYLON.Ray(new BABYLON.Vector3(x, this.getBoundingInfo().boundingBox.maximumWorld.y+1, z), new BABYLON.Vector3(0, -1, 0));
this.getWorldMatrix().invertToRef(this._worldInverse);
ray=BABYLON.Ray.Transform(ray, this._worldInverse);
var pickInfo = this.intersects(ray);
if (pickInfo.hit) 
{
return pickInfo.pickedPoint.y;
}
return 0;
}
}
}
