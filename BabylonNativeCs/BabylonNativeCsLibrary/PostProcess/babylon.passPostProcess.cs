using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class PassPostProcess: PostProcess {
public PassPostProcess(string name, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "pas", null, null, ratio, camera, samplingMode, engine, reusable);
}
}
}
