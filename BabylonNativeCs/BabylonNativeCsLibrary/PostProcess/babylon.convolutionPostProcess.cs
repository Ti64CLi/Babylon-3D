using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class ConvolutionPostProcess: PostProcess {
        public Array < double > kernel;
        public ConvolutionPostProcess(string name, Array < double > kernel, double ratio, Camera camera, double samplingMode = 0.0, Engine engine = null, bool reusable = false): base(name, "convolution", new Array < object > ("kernel", "screenSize"), null, ratio, camera, samplingMode, engine, reusable) {
            this.onApply = (Effect effect) => {
                effect.setFloat2("screenSize", this.width, this.height);
                effect.setArray("kernel", this.kernel);
            };
        }
        public static Array < object > EdgeDetect0Kernel = new Array < object > (1, 0, -1, 0, 0, 0, -1, 0, 1);
        public static Array < object > EdgeDetect1Kernel = new Array < object > (0, 1, 0, 1, -4, 1, 0, 1, 0);
        public static Array < object > EdgeDetect2Kernel = new Array < object > (-1, -1, -1, -1, 8, -1, -1, -1, -1);
        public static Array < object > SharpenKernel = new Array < object > (0, -1, 0, -1, 5, -1, 0, -1, 0);
        public static Array < object > EmbossKernel = new Array < object > (-2, -1, 0, -1, 1, 1, 0, 1, 2);
        public static Array < object > GaussianKernel = new Array < object > (0, 1, 0, 1, 1, 1, 0, 1, 0);
    }
}