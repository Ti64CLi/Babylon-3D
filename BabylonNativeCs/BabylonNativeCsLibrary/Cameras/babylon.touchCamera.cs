// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.touchCamera.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /*
    public partial class TouchCamera : FreeCamera
    {
        private double _offsetX = null;
        private double _offsetY = null;
        private double _pointerCount = 0;
        private Array<object> _pointerPressed = new Array<object>();
        private HTMLCanvasElement _attachedCanvas;
        private System.Func<PointerEvent, object> _onPointerDown;
        private System.Func<PointerEvent, object> _onPointerUp;
        private System.Func<PointerEvent, object> _onPointerMove;
        public double angularSensibility = 200000.0;
        public double moveSensibility = 500.0;
        public TouchCamera(string name, Vector3 position, Scene scene) : base(name, position, scene) { }
        public virtual void attachControl(HTMLCanvasElement canvas, bool noPreventDefault)
        {
            var previousPosition;
            if (this._attachedCanvas)
            {
                return;
            }
            this._attachedCanvas = canvas;
            if (this._onPointerDown == null)
            {
                this._onPointerDown = (object evt) =>
                {
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                    this._pointerPressed.Add(evt.pointerId);
                    if (this._pointerPressed.Length != 1)
                    {
                        return;
                    }
                    previousPosition = new { };
                };
                this._onPointerUp = (object evt) =>
                {
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                    var index = this._pointerPressed.IndexOf(evt.pointerId);
                    if (index == -1)
                    {
                        return;
                    }
                    this._pointerPressed.splice(index, 1);
                    if (index != 0)
                    {
                        return;
                    }
                    previousPosition = null;
                    this._offsetX = null;
                    this._offsetY = null;
                };
                this._onPointerMove = (object evt) =>
                {
                    if (!noPreventDefault)
                    {
                        evt.preventDefault();
                    }
                    if (!previousPosition)
                    {
                        return;
                    }
                    var index = this._pointerPressed.IndexOf(evt.pointerId);
                    if (index != 0)
                    {
                        return;
                    }
                    this._offsetX = evt.clientX - previousPosition.x;
                    this._offsetY = -(evt.clientY - previousPosition.y);
                };
                this._onLostFocus = () =>
                {
                    this._offsetX = null;
                    this._offsetY = null;
                };
            }
            canvas.addEventListener("pointerdown", this._onPointerDown);
            canvas.addEventListener("pointerup", this._onPointerUp);
            canvas.addEventListener("pointerout", this._onPointerUp);
            canvas.addEventListener("pointermove", this._onPointerMove);
            BABYLON.Tools.RegisterTopRootEvents(new Array<object>(new { }));
        }
        public virtual void detachControl(HTMLCanvasElement canvas)
        {
            if (this._attachedCanvas != canvas)
            {
                return;
            }
            canvas.removeEventListener("pointerdown", this._onPointerDown);
            canvas.removeEventListener("pointerup", this._onPointerUp);
            canvas.removeEventListener("pointerout", this._onPointerUp);
            canvas.removeEventListener("pointermove", this._onPointerMove);
            BABYLON.Tools.UnregisterTopRootEvents(new Array<object>(new { }));
            this._attachedCanvas = null;
        }
        public virtual void _checkInputs()
        {
            if (!this._offsetX)
            {
                return;
            }
            this.cameraRotation.y += this._offsetX / this.angularSensibility;
            if (this._pointerPressed.Length > 1)
            {
                this.cameraRotation.x += -this._offsetY / this.angularSensibility;
            }
            else
            {
                var speed = this._computeLocalCameraSpeed();
                var direction = new BABYLON.Vector3(0, 0, speed * this._offsetY / this.moveSensibility);
                BABYLON.Matrix.RotationYawPitchRollToRef(this.rotation.y, this.rotation.x, 0, this._cameraRotationMatrix);
                this.cameraDirection.addInPlace(BABYLON.Vector3.TransformCoordinates(direction, this._cameraRotationMatrix));
            }
        }
    }
     */
}