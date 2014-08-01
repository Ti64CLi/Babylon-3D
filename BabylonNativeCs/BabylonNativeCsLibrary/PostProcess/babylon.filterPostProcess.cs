using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class FilterPostProcess: PostProcess {
        public Matrix kernelMatrix;
        public FilterPostProcess(string name, Matrix kernelMatrix, double ratio, Camera camera = null, double samplingMode = 0.0, Engine engine = null, bool reusable = false): base(name, "filter", new Array < object > ("kernelMatrix"), null, ratio, camera, samplingMode, engine, reusable) {
            this.onApply = (Effect effect) => {
                effect.setMatrix("kernelMatrix", this.kernelMatrix);
            };
        }
    }
}