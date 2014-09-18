// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.anaglyphCamera.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /*
    public partial class AnaglyphArcRotateCamera : ArcRotateCamera
    {
        private double _eyeSpace;
        private ArcRotateCamera _leftCamera;
        private ArcRotateCamera _rightCamera;
        public AnaglyphArcRotateCamera(string name, double alpha, double beta, double radius, object target, double eyeSpace, object scene)
            : base(name, alpha, beta, radius, target, scene)
        {
            this._eyeSpace = BABYLON.Tools.ToRadians(eyeSpace);
            this._leftCamera = new BABYLON.ArcRotateCamera(name + "_left", alpha - this._eyeSpace, beta, radius, target, scene);
            this._rightCamera = new BABYLON.ArcRotateCamera(name + "_right", alpha + this._eyeSpace, beta, radius, target, scene);
            buildCamera(this, name);
        }
        public virtual void _update()
        {
            this._updateCamera(this._leftCamera);
            this._updateCamera(this._rightCamera);
            this._leftCamera.alpha = this.alpha - this._eyeSpace;
            this._rightCamera.alpha = this.alpha + this._eyeSpace;
            base._update();
        }
        public virtual void _updateCamera(ArcRotateCamera camera)
        {
            camera.beta = this.beta;
            camera.radius = this.radius;
            camera.minZ = this.minZ;
            camera.maxZ = this.maxZ;
            camera.fov = this.fov;
            camera.target = this.target;
        }
    }
    public partial class AnaglyphFreeCamera : FreeCamera
    {
        private double _eyeSpace;
        private FreeCamera _leftCamera;
        private FreeCamera _rightCamera;
        private Matrix _transformMatrix;
        public AnaglyphFreeCamera(string name, Vector3 position, double eyeSpace, Scene scene)
            : base(name, position, scene)
        {
            this._eyeSpace = BABYLON.Tools.ToRadians(eyeSpace);
            this._transformMatrix = new BABYLON.Matrix();
            this._leftCamera = new BABYLON.FreeCamera(name + "_left", position.clone(), scene);
            this._rightCamera = new BABYLON.FreeCamera(name + "_right", position.clone(), scene);
            buildCamera(this, name);
        }
        void buildCamera(object that, object name)
        {
            that._leftCamera.isIntermediate = true;
            that.subCameras.Add(that._leftCamera);
            that.subCameras.Add(that._rightCamera);
            that._leftTexture = new BABYLON.PassPostProcess(name + "_leftTexture", 1.0, that._leftCamera);
            that._anaglyphPostProcess = new BABYLON.AnaglyphPostProcess(name + "_anaglyph", 1.0, that._rightCamera);
            that._anaglyphPostProcess.onApply = (effect) =>
            {
                effect.setTextureFromPostProcess("leftSampler", that._leftTexture);
            };
            that._update();
        }
        public virtual void _getSubCameraPosition(object eyeSpace, object result)
        {
            var target = this.getTarget();
            BABYLON.Matrix.Translation(-target.x, -target.y, -target.z).multiplyToRef(BABYLON.Matrix.RotationY(eyeSpace), this._transformMatrix);
            this._transformMatrix = this._transformMatrix.multiply(BABYLON.Matrix.Translation(target.x, target.y, target.z));
            BABYLON.Vector3.TransformCoordinatesToRef(this.position, this._transformMatrix, result);
        }
        public virtual void _update()
        {
            this._getSubCameraPosition(-this._eyeSpace, this._leftCamera.position);
            this._getSubCameraPosition(this._eyeSpace, this._rightCamera.position);
            this._updateCamera(this._leftCamera);
            this._updateCamera(this._rightCamera);
            base._update();
        }
        public virtual void _updateCamera(FreeCamera camera)
        {
            camera.minZ = this.minZ;
            camera.maxZ = this.maxZ;
            camera.fov = this.fov;
            camera.viewport = this.viewport;
            camera.setTarget(this.getTarget());
        }
    }
    */
}