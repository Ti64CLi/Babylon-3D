using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Light: Node {
public dynamic diffuse=new Color3(1.0, 1.0, 1.0);
public dynamic specular=new Color3(1.0, 1.0, 1.0);
public dynamic intensity=1.0;
public dynamic range=Number.MAX_VALUE;
public dynamic excludedMeshes=new Array();
public ShadowGenerator _shadowGenerator;
private Matrix _parentedWorldMatrix;
public dynamic _excludedMeshesIds=new Array();
public Light(string name, Scene scene) {
base(name, scene);
scene.lights.push(this);
}
public virtual ShadowGenerator getShadowGenerator() {
return this._shadowGenerator;
}
public virtual void transferToEffect(Effect effect, string uniformName0, string uniformName1) {
}
public virtual Matrix _getWorldMatrix() {
return Matrix.Identity();
}
public virtual Matrix getWorldMatrix() {
this._currentRenderId=this.getScene().getRenderId();
var worldMatrix = this._getWorldMatrix();
if (this.parent&&this.parent.getWorldMatrix) 
{
if (!this._parentedWorldMatrix) 
{
this._parentedWorldMatrix=BABYLON.Matrix.Identity();
}
worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._parentedWorldMatrix);
return this._parentedWorldMatrix;
}
return worldMatrix;
}
public virtual void dispose() {
if (this._shadowGenerator) 
{
this._shadowGenerator.dispose();
this._shadowGenerator=null;
}
var index = this.getScene().lights.indexOf(this);
this.getScene().lights.splice(index, 1);
}
}
}
