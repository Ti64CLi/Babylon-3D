using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class FxaaPostProcess: PostProcess {
public float texelWidth;
public float texelHeight;
public FxaaPostProcess(string name, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "fxa", new Array<object>(), null, ratio, camera, samplingMode, engine, reusable);
this.onSizeChanged=() => {
this.texelWidth=1.0/this.width;
this.texelHeight=1.0/this.height;
}
;
this.onApply=(Effect effect) => {
effect.setFloat2("texelSiz", this.texelWidth, this.texelHeight);
}
;
}
}
}
