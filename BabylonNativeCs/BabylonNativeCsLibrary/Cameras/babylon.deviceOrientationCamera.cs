using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class DeviceOrientationCamera: FreeCamera {
        private float _offsetX = null;
        private float _offsetY = null;
        private float _orientationGamma = 0;
        private float _orientationBeta = 0;
        private float _initialOrientationGamma = 0;
        private float _initialOrientationBeta = 0;
        private HTMLCanvasElement _attachedCanvas;
        private System.Func < DeviceOrientationEvent, object > _orientationChanged;
        public float angularSensibility = 10000.0;
        public float moveSensibility = 50.0;
        public DeviceOrientationCamera(string name, Vector3 position, Scene scene): base(name, position, scene) {
            window.addEventListener("resiz", () => {
                this._initialOrientationGamma = null;
            }, false);
        }
        public virtual void attachControl(HTMLCanvasElement canvas, bool noPreventDefault) {
            if (this._attachedCanvas) {
                return;
            }
            this._attachedCanvas = canvas;
            if (!this._orientationChanged) {
                this._orientationChanged = (object evt) => {
                    if (!this._initialOrientationGamma) {
                        this._initialOrientationGamma = evt.gamma;
                        this._initialOrientationBeta = evt.beta;
                    }
                    this._orientationGamma = evt.gamma;
                    this._orientationBeta = evt.beta;
                    this._offsetY = (this._initialOrientationBeta - this._orientationBeta);
                    this._offsetX = (this._initialOrientationGamma - this._orientationGamma);
                };
            }
            window.addEventListener("deviceorientatio", this._orientationChanged);
        }
        public virtual void detachControl(HTMLCanvasElement canvas) {
            if (this._attachedCanvas != canvas) {
                return;
            }
            window.removeEventListener("deviceorientatio", this._orientationChanged);
            this._attachedCanvas = null;
            this._orientationGamma = 0;
            this._orientationBeta = 0;
            this._initialOrientationGamma = 0;
            this._initialOrientationBeta = 0;
        }
        public virtual void _checkInputs() {
            if (!this._offsetX) {
                return;
            }
            this.cameraRotation.y -= this._offsetX / this.angularSensibility;
            var speed = this._computeLocalCameraSpeed();
            var direction = new BABYLON.Vector3(0, 0, speed * this._offsetY / this.moveSensibility);
            BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, 0, this._cameraRotationMatrix);
            this.cameraDirection.addInPlace(BABYLON.Vector3.TransformCoordinates(direction, this._cameraRotationMatrix));
        }
    }
}