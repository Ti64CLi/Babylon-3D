// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.displayPassPostProcess.cs" company="">
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
    public partial class DisplayPassPostProcess : PostProcess
    {
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
        public DisplayPassPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "displayPass", new Array<string>("passSampler"), new Array<string>("passSampler"), ratio, camera, samplingMode, engine, reusable)
        {
        }
    }
}