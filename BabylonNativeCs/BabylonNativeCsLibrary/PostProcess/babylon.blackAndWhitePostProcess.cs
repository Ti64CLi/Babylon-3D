using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class BlackAndWhitePostProcess: PostProcess {
        public BlackAndWhitePostProcess(string name, double ratio, Camera camera, double samplingMode = 0.0, Engine engine = null, bool reusable = false): base(name, "blackAndWhite", null, null, ratio, camera, samplingMode, engine, reusable) {}
    }
}