using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    /*
    public partial class _OculusInnerCamera: FreeCamera {
        private double _aspectRatioAspectRatio;
        private double _aspectRatioFov;
        private Matrix _hMatrix;
        private BABYLON.Matrix _workMatrix = new BABYLON.Matrix();
        private Matrix _preViewMatrix;
        private BABYLON.Vector3 _actualUp = new BABYLON.Vector3(0, 0, 0);
        public _OculusInnerCamera(string name, Vector3 position, Scene scene, bool isLeftEye): base(name, position, scene) {
            this._aspectRatioAspectRatio = OculusRiftDevKit2013_Metric.HResolution / (2 * OculusRiftDevKit2013_Metric.VResolution);
            this._aspectRatioFov = (2 * Math.Atan((OculusRiftDevKit2013_Metric.PostProcessScaleFactor * OculusRiftDevKit2013_Metric.VScreenSize) / (2 * OculusRiftDevKit2013_Metric.EyeToScreenDistance)));
            var hMeters = (OculusRiftDevKit2013_Metric.HScreenSize / 4) - (OculusRiftDevKit2013_Metric.LensSeparationDistance / 2);
            var h = (4 * hMeters) / OculusRiftDevKit2013_Metric.HScreenSize;
            this._hMatrix = BABYLON.Matrix.Translation((isLeftEye) ? h : -h, 0, 0);
            this.viewport = new BABYLON.Viewport((isLeftEye) ? 0 : 0.5, 0, 0.5, 1.0);
            this._preViewMatrix = BABYLON.Matrix.Translation((isLeftEye) ? .5 * OculusRiftDevKit2013_Metric.InterpupillaryDistance : -.5 * OculusRiftDevKit2013_Metric.InterpupillaryDistance, 0, 0);
            var postProcess = new BABYLON.OculusDistortionCorrectionPostProcess("Oculus Distortion", this, !isLeftEye, OculusRiftDevKit2013_Metric);
        }
        public virtual Matrix getProjectionMatrix() {
            BABYLON.Matrix.PerspectiveFovLHToRef(this._aspectRatioFov, this._aspectRatioAspectRatio, this.minZ, this.maxZ, this._workMatrix);
            this._workMatrix.multiplyToRef(this._hMatrix, this._projectionMatrix);
            return this._projectionMatrix;
        }
        public virtual Matrix _getViewMatrix() {
            BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, this.rotation.z, this._cameraRotationMatrix);
            BABYLON.Vector3.TransformCoordinatesToRef(this._referencePoint, this._cameraRotationMatrix, this._transformedReferencePoint);
            BABYLON.Vector3.TransformNormalToRef(this.upVector, this._cameraRotationMatrix, this._actualUp);
            this.position.addToRef(this._transformedReferencePoint, this._currentTarget);
            BABYLON.Matrix.LookAtLHToRef(this.position, this._currentTarget, this._actualUp, this._workMatrix);
            this._workMatrix.multiplyToRef(this._preViewMatrix, this._viewMatrix);
            return this._viewMatrix;
        }
    }
    public partial class OculusCamera: FreeCamera {
        private _OculusInnerCamera _leftCamera;
        private _OculusInnerCamera _rightCamera;
        private new {
            double yaw {
                get;
            }, double pitch {
                get;
            }, double roll {
                get;
            }
        }
        _offsetOrientation;
        private dynamic _deviceOrientationHandler;
        public OculusCamera(string name, Vector3 position, Scene scene): base(name, position, scene) {
            this._leftCamera = new _OculusInnerCamera(name + "_left", position.clone(), scene, true);
            this._rightCamera = new _OculusInnerCamera(name + "_right", position.clone(), scene, false);
            this.subCameras.Add(this._leftCamera);
            this.subCameras.Add(this._rightCamera);
            this._deviceOrientationHandler = this._onOrientationEvent.bind(this);
        }
        void OculusRiftDevKit2013_Metricnew {};
        public virtual void _update() {
            this._leftCamera.position.copyFrom(this.position);
            this._rightCamera.position.copyFrom(this.position);
            this._updateCamera(this._leftCamera);
            this._updateCamera(this._rightCamera);
            base._update();
        }
        public virtual void _updateCamera(FreeCamera camera) {
            camera.minZ = this.minZ;
            camera.maxZ = this.maxZ;
            camera.rotation.x = this.rotation.x;
            camera.rotation.y = this.rotation.y;
            camera.rotation.z = this.rotation.z;
        }
        private void _onOrientationEvent(DeviceOrientationEvent evt) {
            var yaw = evt.alpha / 180 * Math.PI;
            var pitch = evt.beta / 180 * Math.PI;
            var roll = evt.gamma / 180 * Math.PI;
            if (!this._offsetOrientation) {
                this._offsetOrientation = new {};
                return;
            } else {
                this.rotation.y += yaw - this._offsetOrientation.yaw;
                this.rotation.x += pitch - this._offsetOrientation.pitch;
                this.rotation.z += this._offsetOrientation.roll - roll;
                this._offsetOrientation.yaw = yaw;
                this._offsetOrientation.pitch = pitch;
                this._offsetOrientation.roll = roll;
            }
        }
        public virtual void attachControl(HTMLElement element, bool noPreventDefault = false) {
            base.attachControl(element, noPreventDefault);
            window.addEventListener("deviceorientation", this._deviceOrientationHandler);
        }
        public virtual void detachControl(HTMLElement element) {
            base.detachControl(element);
            window.removeEventListener("deviceorientation", this._deviceOrientationHandler);
        }
    }
     */
}