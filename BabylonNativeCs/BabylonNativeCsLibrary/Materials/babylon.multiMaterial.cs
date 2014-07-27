using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class MultiMaterial: Material {
public dynamic subMaterials=new Array();
public MultiMaterial(string name, Scene scene) {
base(name, scene, true);
scene.multiMaterials.push(this);
}
public virtual void getSubMaterial(dynamic index) {
if (index<0||index>=this.subMaterials.length) 
{
return this.getScene().defaultMaterial;
}
return this.subMaterials[index];
}
public virtual bool isReady(AbstractMesh mesh) {
for (var index = 0;index<this.subMaterials.length;index++) 
{
var subMaterial = this.subMaterials[index];
if (subMaterial) 
{
if (!this.subMaterials[index].isReady(mesh)) 
{
return false;
}
}
}
return true;
}
}
}
