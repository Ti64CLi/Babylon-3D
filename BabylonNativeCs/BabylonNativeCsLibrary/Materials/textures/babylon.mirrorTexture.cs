// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.mirrorTexture.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class MirrorTexture : RenderTargetTexture
    {
        /// <summary>
        /// </summary>
        public Plane mirrorPlane = new Plane(0, 1, 0, 1);

        /// <summary>
        /// </summary>
        private readonly Matrix _mirrorMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        private Matrix _savedViewMatrix;

        /// <summary>
        /// </summary>
        private readonly Matrix _transformMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        public MirrorTexture(string name, Size size, Scene scene, bool generateMipMaps = false)
            : base(name, size, scene, generateMipMaps, true)
        {
            this.onBeforeRender = () =>
                {
                    Matrix.ReflectionToRef(this.mirrorPlane, this._mirrorMatrix);
                    this._savedViewMatrix = scene.getViewMatrix();
                    this._mirrorMatrix.multiplyToRef(this._savedViewMatrix, this._transformMatrix);
                    scene.setTransformMatrix(this._transformMatrix, scene.getProjectionMatrix());
                    scene.clipPlane = this.mirrorPlane;
                    scene.getEngine().cullBackFaces = false;
                };
            this.onAfterRender = () =>
                {
                    scene.setTransformMatrix(this._savedViewMatrix, scene.getProjectionMatrix());
                    scene.getEngine().cullBackFaces = true;
                    scene.clipPlane = null;
                };
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture clone()
        {
            var textureSize = this.getSize();
            var newTexture = new MirrorTexture(this.name, textureSize, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.mirrorPlane = this.mirrorPlane.clone();
            newTexture.renderList = this.renderList.slice(0);
            return newTexture;
        }
    }
}