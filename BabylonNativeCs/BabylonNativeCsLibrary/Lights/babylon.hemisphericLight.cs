// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.hemisphericLight.cs" company="">
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
    public partial class HemisphericLight : Light
    {
        /// <summary>
        /// </summary>
        public Vector3 direction;

        /// <summary>
        /// </summary>
        public Color3 groundColor = new Color3(0.0, 0.0, 0.0);

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
        public HemisphericLight(string name, Vector3 direction, Scene scene)
            : base(name, scene)
        {
            this.direction = direction;
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
        /// <param name="target">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Vector3 setDirectionToTarget(Vector3 target)
        {
            this.direction = Vector3.Normalize(target.subtract(Vector3.Zero()));
            return this.direction;
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
        /// <param name="directionUniformName">
        /// </param>
        /// <param name="groundColorUniformName">
        /// </param>
        public override void transferToEffect(Effect effect, string directionUniformName, string groundColorUniformName)
        {
            var normalizeDirection = Vector3.Normalize(this.direction);
            effect.setFloat4(directionUniformName, normalizeDirection.x, normalizeDirection.y, normalizeDirection.z, 0);
            effect.setColor3(groundColorUniformName, this.groundColor.scale(this.intensity));
        }
    }
}