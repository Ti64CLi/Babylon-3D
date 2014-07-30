using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class AnaglyphPostProcess: PostProcess {
        public AnaglyphPostProcess(string name, double ratio, Camera camera, double samplingMode = 0.0, Engine engine = null, bool reusable = false): base(name, "anaglyph", null, new Array < object > ("leftSampler"), ratio, camera, samplingMode, engine, reusable) {}
        void CANNON;
        void window;
    }
}