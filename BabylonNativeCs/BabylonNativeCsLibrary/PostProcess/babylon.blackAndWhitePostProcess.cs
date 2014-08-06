// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.blackAndWhitePostProcess.cs" company="">
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
    public partial class BlackAndWhitePostProcess : PostProcess
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
        public BlackAndWhitePostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "blackAndWhite", null, null, ratio, camera, samplingMode, engine, reusable)
        {
        }
    }
}