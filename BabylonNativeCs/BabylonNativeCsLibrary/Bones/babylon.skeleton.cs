using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Skeleton {
public dynamic bones=new Array();
private Scene _scene;
private dynamic _isDirty=true;
private Float32Array _transformMatrices;
private IAnimatable[] _animatables;
private dynamic _identity=Matrix.Identity();
public string name;
public string id;
public Skeleton(string name, string id, Scene scene) {
this.bones=new Array<object>();
this._scene=scene;
scene.skeletons.push(this);
}
public virtual void getTransformMatrices() {
return this._transformMatrices;
}
public virtual void _markAsDirty() {
this._isDirty=true;
}
public virtual void prepare() {
if (!this._isDirty) 
{
return;
}
if (!this._transformMatrices||this._transformMatrices.length!=16*(this.bones.length+1)) 
{
this._transformMatrices=new Float32Array(16*(this.bones.length+1));
}
for (var index = 0;index<this.bones.length;index++) 
{
var bone = this.bones[index];
var parentBone = bone.getParent();
if (parentBone) 
{
bone.getLocalMatrix().multiplyToRef(parentBone.getWorldMatrix(), bone.getWorldMatrix());
}
else 
{
bone.getWorldMatrix().copyFrom(bone.getLocalMatrix());
}
bone.getInvertedAbsoluteTransform().multiplyToArray(bone.getWorldMatrix(), this._transformMatrices, index*16);
}
this._identity.copyToArray(this._transformMatrices, this.bones.length*16);
this._isDirty=false;
}
public virtual IAnimatable[] getAnimatables() {
if (!this._animatables||this._animatables.length!=this.bones.length) 
{
this._animatables=new Array<object>();
for (var index = 0;index<this.bones.length;index++) 
{
this._animatables.push(this.bones[index]);
}
}
return this._animatables;
}
public virtual Skeleton clone(string name, string id) {
var result = new BABYLON.Skeleton(name, id||name, this._scene);
for (var index = 0;index<this.bones.length;index++) 
{
var source = this.bones[index];
var parentBone = null;
if (source.getParent()) 
{
var parentIndex = this.bones.indexOf(source.getParent());
parentBone=result.bones[parentIndex];
}
var bone = new BABYLON.Bone(source.name, result, parentBone, source.getBaseMatrix());
BABYLON.Tools.DeepCopy(source.animations, bone.animations);
}
return result;
}
}
}
