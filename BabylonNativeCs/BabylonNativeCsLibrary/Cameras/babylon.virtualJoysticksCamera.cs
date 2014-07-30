using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class VirtualJoysticksCamera: FreeCamera {
        private BABYLON.VirtualJoystick _leftjoystick;
        private BABYLON.VirtualJoystick _rightjoystick;
        public VirtualJoysticksCamera(string name, Vector3 position, Scene scene): base(name, position, scene) {
            this._leftjoystick = new BABYLON.VirtualJoystick(true);
            this._leftjoystick.setAxisForUpDown(BABYLON.JoystickAxis.Z);
            this._leftjoystick.setAxisForLeftRight(BABYLON.JoystickAxis.X);
            this._leftjoystick.setJoystickSensibility(0.15);
            this._rightjoystick = new BABYLON.VirtualJoystick(false);
            this._rightjoystick.setAxisForUpDown(BABYLON.JoystickAxis.X);
            this._rightjoystick.setAxisForLeftRight(BABYLON.JoystickAxis.Y);
            this._rightjoystick.reverseUpDown = true;
            this._rightjoystick.setJoystickSensibility(0.05);
            this._rightjoystick.setJoystickColor("yellow");
        }
        public virtual void _checkInputs() {
            var cameraTransform = BABYLON.Matrix.RotationYawPitchRoll(this.rotation.y, this.rotation.x, 0);
            var deltaTransform = BABYLON.Vector3.TransformCoordinates(this._leftjoystick.deltaPosition, cameraTransform);
            this.cameraDirection = this.cameraDirection.add(deltaTransform);
            this.cameraRotation = this.cameraRotation.add(this._rightjoystick.deltaPosition);
            if (!this._leftjoystick.pressed) {
                this._leftjoystick.deltaPosition = this._leftjoystick.deltaPosition.scale(0.9);
            }
            if (!this._rightjoystick.pressed) {
                this._rightjoystick.deltaPosition = this._rightjoystick.deltaPosition.scale(0.9);
            }
        }
        public virtual void dispose() {
            this._leftjoystick.releaseCanvas();
        }
    }
}