// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.filterPostProcess.cs" company="">
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
    public partial class FilterPostProcess : PostProcess
    {
        /// <summary>
        /// </summary>
        public Matrix kernelMatrix;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="kernelMatrix">
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
        public FilterPostProcess(
            string name, Matrix kernelMatrix, double ratio, Camera camera = null, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "filter", new Array<string>("kernelMatrix"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onApply = (Effect effect) => { effect.setMatrix("kernelMatrix", this.kernelMatrix); };
        }
    }
}