using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class BlurPostProcess : PostProcess
    {
        public Vector2 direction;
        public double blurWidth;
        public BlurPostProcess(string name, Vector2 direction, double blurWidth, double ratio, Camera camera, int samplingMode = BABYLON.Texture.BILINEAR_SAMPLINGMODE, Engine engine = null, bool reusable = false)
            : base(name, "blur", new Array<string>("screenSize", "direction", "blurWidth"), null, ratio, camera, samplingMode, engine, reusable)
        {
            this.onApply = (Effect effect) =>
            {
                effect.setFloat2("screenSize", this.width, this.height);
                effect.setVector2("direction", this.direction);
                effect.setFloat("blurWidth", this.blurWidth);
            };
        }
    }
}