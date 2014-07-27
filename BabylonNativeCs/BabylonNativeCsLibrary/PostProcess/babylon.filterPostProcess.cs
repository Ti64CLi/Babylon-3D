using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class FilterPostProcess: PostProcess {
public Matrix kernelMatrix;
public FilterPostProcess(string name, Matrix kernelMatrix, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "filte", new Array<object>(), null, ratio, camera, samplingMode, engine, reusable);
this.onApply=(Effect effect) => {
effect.setMatrix("kernelMatri", this.kernelMatrix);
}
;
}
}
}
