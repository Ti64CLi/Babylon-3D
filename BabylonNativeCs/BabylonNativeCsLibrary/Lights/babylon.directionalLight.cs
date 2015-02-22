// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.directionalLight.cs" company="">
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
    public partial class DirectionalLight : Light
    {
        /// <summary>
        /// </summary>
        public Vector3 _transformedPosition;

        /// <summary>
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// </summary>
        private Vector3 _transformedDirection;

        /// <summary>
        /// </summary>
        private Matrix _worldMatrix;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="direction">
        /// </param>
        /// <param name="scene">
        /// </param>
        public DirectionalLight(string name, Vector3 direction, Scene scene)
            : base(name, scene)
        {
            this.position = direction.scale(-1);
            this.direction = direction;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool _computeTransformedPosition()
        {
            if (this.parent != null)
            {
                if (this._transformedPosition == null)
                {
                    this._transformedPosition = Vector3.Zero();
                }

                Vector3.TransformCoordinatesToRef(this.position, this.parent.getWorldMatrix(), this._transformedPosition);
                return true;
            }

            return false;
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
        /// <param name="target">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 setDirectionToTarget(Vector3 target)
        {
            this.direction = Vector3.Normalize(target.subtract(this.position));
            return this.direction;
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
        /// <param name="directionUniformName">
        /// </param>
        /// <param name="directionUniformName2">
        /// </param>
        public override void transferToEffect(Effect effect, string directionUniformName, string directionUniformName2 = null)
        {
            if (this.parent != null)
            {
                if (this._transformedDirection == null)
                {
                    this._transformedDirection = Vector3.Zero();
                }

                Vector3.TransformNormalToRef(this.direction, this.parent.getWorldMatrix(), this._transformedDirection);
                effect.setFloat4(directionUniformName, this._transformedDirection.x, this._transformedDirection.y, this._transformedDirection.z, 1);
                return;
            }

            effect.setFloat4(directionUniformName, this.direction.x, this.direction.y, this.direction.z, 1);
        }
    }
}