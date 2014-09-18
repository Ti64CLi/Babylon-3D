// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.anaglyphPostProcess.cs" company="">
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
    public partial class AnaglyphPostProcess : PostProcess
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
        public AnaglyphPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "anaglyph", null, new Array<string>("leftSampler"), ratio, camera, samplingMode, engine, reusable)
        {
        }
    }
}