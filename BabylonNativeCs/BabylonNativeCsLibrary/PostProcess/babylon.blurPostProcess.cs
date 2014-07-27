using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class BlurPostProcess: PostProcess {
public Vector2 direction;
public float blurWidth;
public BlurPostProcess(string name, Vector2 direction, float blurWidth, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "blu", new Array<object>(), null, ratio, camera, samplingMode, engine, reusable);
this.onApply=(Effect effect) => {
effect.setFloat2("screenSiz", this.width, this.height);
effect.setVector2("directio", this.direction);
effect.setFloat("blurWidt", this.blurWidth);
}
;
}
}
}
