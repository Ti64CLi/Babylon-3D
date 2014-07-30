using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class DisplayPassPostProcess: PostProcess {
        public DisplayPassPostProcess(string name, double ratio, Camera camera, double samplingMode = 0.0, Engine engine = null, bool reusable = false): base(name, "displayPass", new Array < object > ("passSampler"), new Array < object > ("passSampler"), ratio, camera, samplingMode, engine, reusable) {}
    }
}