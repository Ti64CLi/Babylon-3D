using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    /*
    public partial class GamepadCamera : FreeCamera
    {
        private BABYLON.Gamepad _gamepad;
        private BABYLON.Gamepads _gamepads;
        public double angularSensibility = 200;
        public double moveSensibility = 75;
        public GamepadCamera(string name, Vector3 position, Scene scene)
            : base(name, position, scene)
        {
            this._gamepads = new BABYLON.Gamepads((BABYLON.Gamepad gamepad) =>
            {
                this._onNewGameConnected(gamepad);
            });
        }
        private void _onNewGameConnected(BABYLON.Gamepad gamepad)
        {
            if (gamepad.index == 0)
            {
                this._gamepad = gamepad;
            }
        }
        public virtual void _checkInputs()
        {
            if (!this._gamepad)
            {
                return;
            }
            var LSValues = this._gamepad.leftStick;
            var normalizedLX = LSValues.x / this.moveSensibility;
            var normalizedLY = LSValues.y / this.moveSensibility;
            LSValues.x = (Math.Abs(normalizedLX) > 0.005) ? 0 + normalizedLX : 0;
            LSValues.y = (Math.Abs(normalizedLY) > 0.005) ? 0 + normalizedLY : 0;
            var RSValues = this._gamepad.rightStick;
            var normalizedRX = RSValues.x / this.angularSensibility;
            var normalizedRY = RSValues.y / this.angularSensibility;
            RSValues.x = (Math.Abs(normalizedRX) > 0.001) ? 0 + normalizedRX : 0;
            RSValues.y = (Math.Abs(normalizedRY) > 0.001) ? 0 + normalizedRY : 0; ;
            var cameraTransform = BABYLON.Matrix.RotationYawPitchRoll(this.rotation.y, this.rotation.x, 0);
            var deltaTransform = BABYLON.Vector3.TransformCoordinates(new BABYLON.Vector3(LSValues.x, 0, -LSValues.y), cameraTransform);
            this.cameraDirection = this.cameraDirection.add(deltaTransform);
            this.cameraRotation = this.cameraRotation.add(new BABYLON.Vector3(RSValues.y, RSValues.x, 0));
        }
        public virtual void dispose()
        {
            this._gamepads.dispose();
        }
    }
    */
}