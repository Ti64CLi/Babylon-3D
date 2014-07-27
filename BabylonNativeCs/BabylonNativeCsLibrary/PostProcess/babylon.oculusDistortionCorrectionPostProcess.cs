using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class OculusDistortionCorrectionPostProcess: PostProcess {
public float aspectRatio;
private bool _isRightEye;
private float[] _distortionFactors;
private float _postProcessScaleFactor;
private float _lensCenterOffset;
private Vector2 _scaleIn;
private Vector2 _scaleFactor;
private Vector2 _lensCenter;
public OculusDistortionCorrectionPostProcess(string name, Camera camera, bool isRightEye, object cameraSettings) {
base(name, "oculusDistortionCorrectio", new Array<object>(), null, cameraSettings.PostProcessScaleFactor, camera, BABYLON.Texture.BILINEAR_SAMPLINGMODE, null, null);
this._isRightEye=isRightEye;
this._distortionFactors=cameraSettings.DistortionK;
this._postProcessScaleFactor=cameraSettings.PostProcessScaleFactor;
this._lensCenterOffset=cameraSettings.LensCenterOffset;
this.onSizeChanged=() => {
this.aspectRatio=this.width*.5/this.height;
this._scaleIn=new BABYLON.Vector2(2, 2/this.aspectRatio);
this._scaleFactor=new BABYLON.Vector2(.5*(1/this._postProcessScaleFactor), .5*(1/this._postProcessScaleFactor)*this.aspectRatio);
this._lensCenter=new BABYLON.Vector2((this._isRightEye) ? 0.5-this._lensCenterOffset*0.5 : 0.5+this._lensCenterOffset*0.5, 0.5);
}
;
this.onApply=(Effect effect) => {
effect.setFloat2("LensCente", this._lensCenter.x, this._lensCenter.y);
effect.setFloat2("Scal", this._scaleFactor.x, this._scaleFactor.y);
effect.setFloat2("ScaleI", this._scaleIn.x, this._scaleIn.y);
effect.setFloat4("HmdWarpPara", this._distortionFactors[0], this._distortionFactors[1], this._distortionFactors[2], this._distortionFactors[3]);
}
;
}
}
}
