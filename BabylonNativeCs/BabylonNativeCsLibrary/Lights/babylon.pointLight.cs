// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.pointLight.cs" company="">
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
    public partial class PointLight : Light
    {
        /// <summary>
        /// </summary>
        private Vector3 _transformedPosition;

        /// <summary>
        /// </summary>
        private Matrix _worldMatrix;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="position">
        /// </param>
        /// <param name="scene">
        /// </param>
        public PointLight(string name, Vector3 position, Scene scene)
            : base(name, scene)
        {
            this.position = position;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix _getWorldMatrix()
        {
            if (this._worldMatrix == null)
            {
                this._worldMatrix = Matrix.Identity();
            }

            Matrix.TranslationToRef(this.position.x, this.position.y, this.position.z, this._worldMatrix);
            return this._worldMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override ShadowGenerator getShadowGenerator()
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
        /// <param name="positionUniformName">
        /// </param>
        /// <param name="positionUniformName2">
        /// </param>
        public override void transferToEffect(Effect effect, string positionUniformName, string positionUniformName2 = null)
        {
            if (this.parent != null)
            {
                if (this._transformedPosition == null)
                {
                    this._transformedPosition = Vector3.Zero();
                }

                Vector3.TransformCoordinatesToRef(this.position, this.parent.getWorldMatrix(), this._transformedPosition);
                effect.setFloat4(positionUniformName, this._transformedPosition.x, this._transformedPosition.y, this._transformedPosition.z, 0);
                return;
            }

            effect.setFloat4(positionUniformName, this.position.x, this.position.y, this.position.z, 0);
        }
    }
}