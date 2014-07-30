using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class LensFlare {
        public Color3 color;
        public Texture texture;
        private LensFlareSystem _system;
        public double size;
        public double position;
        public LensFlare(double size, double position, object color, string imgUrl, LensFlareSystem system) {
            this.color = color || new BABYLON.Color3(1, 1, 1);
            this.texture = (imgUrl) ? new BABYLON.Texture(imgUrl, system.getScene(), true) : null;
            this._system = system;
            system.lensFlares.push(this);
        }
        public void dispose() {
            if (this.texture) {
                this.texture.dispose();
            }
            var index = this._system.lensFlares.indexOf(this);
            this._system.lensFlares.splice(index, 1);
        }

    }
}