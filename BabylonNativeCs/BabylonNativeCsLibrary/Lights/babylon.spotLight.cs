// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.spotLight.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public partial class SpotLight : Light
    {
        /// <summary>
        /// </summary>
        public double angle;

        /// <summary>
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// </summary>
        public double exponent;

        /// <summary>
        /// </summary>
        private Vector3 _transformedDirection;

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
        /// <param name="direction">
        /// </param>
        /// <param name="angle">
        /// </param>
        /// <param name="exponent">
        /// </param>
        /// <param name="scene">
        /// </param>
        public SpotLight(string name, Vector3 position, Vector3 direction, double angle, double exponent, Scene scene)
            : base(name, scene)
        {
            this.position = position;
            this.direction = direction;
            this.angle = angle;
            this.exponent = exponent;
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
        /// <param name="positionUniformName">
        /// </param>
        /// <param name="directionUniformName">
        /// </param>
        public override void transferToEffect(Effect effect, string positionUniformName, string directionUniformName)
        {
            Vector3 normalizeDirection = null;
            if (this.parent != null)
            {
                if (this._transformedDirection == null)
                {
                    this._transformedDirection = Vector3.Zero();
                }

                if (this._transformedPosition == null)
                {
                    this._transformedPosition = Vector3.Zero();
                }

                var parentWorldMatrix = this.parent.getWorldMatrix();
                Vector3.TransformCoordinatesToRef(this.position, parentWorldMatrix, this._transformedPosition);
                Vector3.TransformNormalToRef(this.direction, parentWorldMatrix, this._transformedDirection);
                effect.setFloat4(positionUniformName, this._transformedPosition.x, this._transformedPosition.y, this._transformedPosition.z, this.exponent);
                normalizeDirection = Vector3.Normalize(this._transformedDirection);
            }
            else
            {
                effect.setFloat4(positionUniformName, this.position.x, this.position.y, this.position.z, this.exponent);
                normalizeDirection = Vector3.Normalize(this.direction);
            }

            effect.setFloat4(directionUniformName, normalizeDirection.x, normalizeDirection.y, normalizeDirection.z, Math.Cos(this.angle * 0.5));
        }
    }
}