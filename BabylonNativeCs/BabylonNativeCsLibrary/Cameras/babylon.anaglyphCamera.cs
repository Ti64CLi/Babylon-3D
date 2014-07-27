using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class AnaglyphArcRotateCamera: ArcRotateCamera {
private float _eyeSpace;
private ArcRotateCamera _leftCamera;
private ArcRotateCamera _rightCamera;
public AnaglyphArcRotateCamera(string name, float alpha, float beta, float radius, dynamic target, float eyeSpace, dynamic scene) {
base(name, alpha, beta, radius, target, scene);
this._eyeSpace=BABYLON.Tools.ToRadians(eyeSpace);
this._leftCamera=new BABYLON.ArcRotateCamera(name+"_lef", alpha-this._eyeSpace, beta, radius, target, scene);
this._rightCamera=new BABYLON.ArcRotateCamera(name+"_righ", alpha+this._eyeSpace, beta, radius, target, scene);
buildCamera(this, name);
}
public virtual void _update() {
this._updateCamera(this._leftCamera);
this._updateCamera(this._rightCamera);
this._leftCamera.alpha=this.alpha-this._eyeSpace;
this._rightCamera.alpha=this.alpha+this._eyeSpace;
base._update();
}
public virtual void _updateCamera(ArcRotateCamera camera) {
camera.beta=this.beta;
camera.radius=this.radius;
camera.minZ=this.minZ;
camera.maxZ=this.maxZ;
camera.fov=this.fov;
camera.target=this.target;
}
}
public class AnaglyphFreeCamera: FreeCamera {
private float _eyeSpace;
private FreeCamera _leftCamera;
private FreeCamera _rightCamera;
private Matrix _transformMatrix;
public AnaglyphFreeCamera(string name, Vector3 position, float eyeSpace, Scene scene) {
base(name, position, scene);
this._eyeSpace=BABYLON.Tools.ToRadians(eyeSpace);
this._transformMatrix=new BABYLON.Matrix();
this._leftCamera=new BABYLON.FreeCamera(name+"_lef", position.clone(), scene);
this._rightCamera=new BABYLON.FreeCamera(name+"_righ", position.clone(), scene);
buildCamera(this, name);
}
var buildCamera = (dynamic that, dynamic name) => {
that._leftCamera.isIntermediate=true;
that.subCameras.push(that._leftCamera);
that.subCameras.push(that._rightCamera);
that._leftTexture=new BABYLON.PassPostProcess(name+"_leftTextur", 1.0, that._leftCamera);
that._anaglyphPostProcess=new BABYLON.AnaglyphPostProcess(name+"_anaglyp", 1.0, that._rightCamera);
that._anaglyphPostProcess.onApply=(dynamic effect) => {
effect.setTextureFromPostProcess("leftSample", that._leftTexture);
}
;
that._update();
}
;
public virtual void _getSubCameraPosition(dynamic eyeSpace, dynamic result) {
var target = this.getTarget();
BABYLON.Matrix.Translation(-target.x, -target.y, -target.z).multiplyToRef(BABYLON.Matrix.RotationY(eyeSpace), this._transformMatrix);
this._transformMatrix=this._transformMatrix.multiply(BABYLON.Matrix.Translation(target.x, target.y, target.z));
BABYLON.Vector3.TransformCoordinatesToRef(this.position, this._transformMatrix, result);
}
public virtual void _update() {
this._getSubCameraPosition(-this._eyeSpace, this._leftCamera.position);
this._getSubCameraPosition(this._eyeSpace, this._rightCamera.position);
this._updateCamera(this._leftCamera);
this._updateCamera(this._rightCamera);
base._update();
}
public virtual void _updateCamera(FreeCamera camera) {
camera.minZ=this.minZ;
camera.maxZ=this.maxZ;
camera.fov=this.fov;
camera.viewport=this.viewport;
camera.setTarget(this.getTarget());
}
}
}
