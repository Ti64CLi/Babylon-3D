using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class DisplayPassPostProcess: PostProcess {
public DisplayPassPostProcess(string name, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "displayPas", new Array<object>(), new Array<object>(), ratio, camera, samplingMode, engine, reusable);
}
}
}
