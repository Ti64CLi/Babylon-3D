using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class AnaglyphPostProcess: PostProcess {
public AnaglyphPostProcess(string name, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "anaglyp", null, new Array<object>(), ratio, camera, samplingMode, engine, reusable);
}
}
}
