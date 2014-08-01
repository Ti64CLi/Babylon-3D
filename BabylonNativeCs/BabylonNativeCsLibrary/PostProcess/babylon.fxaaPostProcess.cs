using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class FxaaPostProcess : PostProcess
    {
        public double texelWidth;
        public double texelHeight;
        public FxaaPostProcess(string name, double ratio, Camera camera, int samplingMode = 0, Engine engine = null, bool reusable = false)
            : base(name, "fxaa", new Array<string>("texelSize"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onSizeChanged = () =>
            {
                this.texelWidth = 1.0 / this.width;
                this.texelHeight = 1.0 / this.height;
            };
            this.onApply = (Effect effect) =>
            {
                effect.setFloat2("texelSize", this.texelWidth, this.texelHeight);
            };
        }
    }
}