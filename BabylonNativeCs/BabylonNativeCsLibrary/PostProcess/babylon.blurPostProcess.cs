// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.blurPostProcess.cs" company="">
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
    public partial class BlurPostProcess : PostProcess
    {
        /// <summary>
        /// </summary>
        public double blurWidth;

        /// <summary>
        /// </summary>
        public Vector2 direction;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="direction">
        /// </param>
        /// <param name="blurWidth">
        /// </param>
        /// <param name="ratio">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <param name="engine">
        /// </param>
        /// <param name="reusable">
        /// </param>
        public BlurPostProcess(
            string name, 
            Vector2 direction, 
            double blurWidth, 
            double ratio, 
            Camera camera, 
            int samplingMode = Texture.BILINEAR_SAMPLINGMODE, 
            Engine engine = null, 
            bool reusable = false)
            : base(name, "blur", new Array<string>("screenSize", "direction", "blurWidth"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onApply = (Effect effect) =>
                {
                    effect.setFloat2("screenSize", this.width, this.height);
                    effect.setVector2("direction", this.direction);
                    effect.setFloat("blurWidth", this.blurWidth);
                };
        }
    }
}