// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.fxaaPostProcess.cs" company="">
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
    public partial class FxaaPostProcess : PostProcess
    {
        /// <summary>
        /// </summary>
        public double texelHeight;

        /// <summary>
        /// </summary>
        public double texelWidth;

        /// <summary>
        /// </summary>
        /// <param name="name">
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
        public FxaaPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "fxaa", new Array<string>("texelSize"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onSizeChanged = () =>
                {
                    this.texelWidth = 1.0 / this.width;
                    this.texelHeight = 1.0 / this.height;
                };
            this.onApply = (Effect effect) => { effect.setFloat2("texelSize", this.texelWidth, this.texelHeight); };
        }
    }
}