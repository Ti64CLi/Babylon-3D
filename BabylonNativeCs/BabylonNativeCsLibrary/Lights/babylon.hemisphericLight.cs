using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class HemisphericLight: Light {
public dynamic groundColor=new BABYLON.Color3(0.0, 0.0, 0.0);
private Matrix _worldMatrix;
public Vector3 direction;
public HemisphericLight(string name, Vector3 direction, Scene scene) {
base(name, scene);
}
public virtual Vector3 setDirectionToTarget(Vector3 target) {
this.direction=BABYLON.Vector3.Normalize(target.subtract(Vector3.Zero()));
return this.direction;
}
public virtual ShadowGenerator getShadowGenerator() {
return null;
}
public virtual void transferToEffect(Effect effect, string directionUniformName, string groundColorUniformName) {
var normalizeDirection = BABYLON.Vector3.Normalize(this.direction);
effect.setFloat4(directionUniformName, normalizeDirection.x, normalizeDirection.y, normalizeDirection.z, 0);
effect.setColor3(groundColorUniformName, this.groundColor.scale(this.intensity));
}
public virtual Matrix _getWorldMatrix() {
if (!this._worldMatrix) 
{
this._worldMatrix=BABYLON.Matrix.Identity();
}
return this._worldMatrix;
}
}
}
