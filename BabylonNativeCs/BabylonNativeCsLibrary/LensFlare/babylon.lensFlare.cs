using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class LensFlare
    {
        public Color3 color;
        public Texture texture;
        private LensFlareSystem _system;
        public double size;
        public double position;
        public LensFlare(double size, double position, Color3 color, string imgUrl, LensFlareSystem system)
        {
            this.size = size;
            this.position = position;
            this.color = color ?? new BABYLON.Color3(1, 1, 1);
            this.texture = (imgUrl != null) ? new BABYLON.Texture(imgUrl, system.getScene(), true) : null;
            this._system = system;
            system.lensFlares.Add(this);
        }
        public void dispose()
        {
            if (this.texture != null)
            {
                this.texture.dispose();
            }
            var index = this._system.lensFlares.IndexOf(this);
            this._system.lensFlares.RemoveAt(index);
        }

    }
}