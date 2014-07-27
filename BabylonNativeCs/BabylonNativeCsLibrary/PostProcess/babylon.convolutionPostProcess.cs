using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class ConvolutionPostProcess: PostProcess {
public float[] kernel;
public ConvolutionPostProcess(string name, float[] kernel, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "convolutio", new Array<object>(), null, ratio, camera, samplingMode, engine, reusable);
this.onApply=(Effect effect) => {
effect.setFloat2("screenSiz", this.width, this.height);
effect.setArray("kerne", this.kernel);
}
;
}
dynamic EdgeDetect0Kernel=new Array<object>();
dynamic EdgeDetect1Kernel=new Array<object>();
dynamic EdgeDetect2Kernel=new Array<object>();
dynamic SharpenKernel=new Array<object>();
dynamic EmbossKernel=new Array<object>();
dynamic GaussianKernel=new Array<object>();
}
}
