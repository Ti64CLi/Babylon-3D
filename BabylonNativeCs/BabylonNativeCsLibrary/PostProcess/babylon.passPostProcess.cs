using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class PassPostProcess: PostProcess {
        public PassPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false): base(name, "pass", null, null, ratio, camera, samplingMode, engine, reusable) {}
    }
}