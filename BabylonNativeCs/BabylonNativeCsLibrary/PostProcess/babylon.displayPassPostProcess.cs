using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class DisplayPassPostProcess : PostProcess
    {
        public DisplayPassPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false) 
            : base(name, "displayPass", new Array<string>("passSampler"), new Array<string>("passSampler"), ratio, camera, samplingMode, engine, reusable) { }
    }
}