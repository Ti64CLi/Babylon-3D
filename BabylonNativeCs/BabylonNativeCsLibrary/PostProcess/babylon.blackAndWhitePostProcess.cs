using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class BlackAndWhitePostProcess: PostProcess {
public BlackAndWhitePostProcess(string name, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "blackAndWhit", null, null, ratio, camera, samplingMode, engine, reusable);
}
}
}
