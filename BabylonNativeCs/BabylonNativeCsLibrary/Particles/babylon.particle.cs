// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.particle.cs" company="">
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
    public partial class Particle
    {
        /// <summary>
        /// </summary>
        public double age = 0;

        /// <summary>
        /// </summary>
        public double angle = 0;

        /// <summary>
        /// </summary>
        public double angularSpeed = 0;

        /// <summary>
        /// </summary>
        public Color4 color = new Color4(0, 0, 0, 0);

        /// <summary>
        /// </summary>
        public Color4 colorStep = new Color4(0, 0, 0, 0);

        /// <summary>
        /// </summary>
        public Vector3 direction = Vector3.Zero();

        /// <summary>
        /// </summary>
        public double lifeTime = 1.0;

        /// <summary>
        /// </summary>
        public Vector3 position = Vector3.Zero();

        /// <summary>
        /// </summary>
        public double size = 0;
    }
}