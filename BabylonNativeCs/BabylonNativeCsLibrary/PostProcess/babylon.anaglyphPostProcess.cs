using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class AnaglyphPostProcess : PostProcess
    {
        public AnaglyphPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "anaglyph", null, new Array<string>("leftSampler"), ratio, camera, samplingMode, engine, reusable)
        {
        }
    }
}