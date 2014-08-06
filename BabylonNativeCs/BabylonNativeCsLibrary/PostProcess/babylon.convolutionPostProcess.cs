// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.convolutionPostProcess.cs" company="">
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
    public partial class ConvolutionPostProcess : PostProcess
    {
        /// <summary>
        /// </summary>
        public static Array<object> EdgeDetect0Kernel = new Array<object>(1, 0, -1, 0, 0, 0, -1, 0, 1);

        /// <summary>
        /// </summary>
        public static Array<object> EdgeDetect1Kernel = new Array<object>(0, 1, 0, 1, -4, 1, 0, 1, 0);

        /// <summary>
        /// </summary>
        public static Array<object> EdgeDetect2Kernel = new Array<object>(-1, -1, -1, -1, 8, -1, -1, -1, -1);

        /// <summary>
        /// </summary>
        public static Array<object> EmbossKernel = new Array<object>(-2, -1, 0, -1, 1, 1, 0, 1, 2);

        /// <summary>
        /// </summary>
        public static Array<object> GaussianKernel = new Array<object>(0, 1, 0, 1, 1, 1, 0, 1, 0);

        /// <summary>
        /// </summary>
        public static Array<object> SharpenKernel = new Array<object>(0, -1, 0, -1, 5, -1, 0, -1, 0);

        /// <summary>
        /// </summary>
        public Array<double> kernel;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="kernel">
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
        public ConvolutionPostProcess(
            string name, Array<double> kernel, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "convolution", new Array<string>("kernel", "screenSize"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onApply = (Effect effect) =>
                {
                    effect.setFloat2("screenSize", this.width, this.height);
                    effect.setArray("kernel", this.kernel);
                };
        }
    }
}