using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class VideoTexture : Texture
    {
        public HTMLVideoElement video;
        private bool _autoLaunch = true;
        private double _lastUpdate;

        Web.Window window;
        Web.Document document;

        public VideoTexture(string name, Array<string> urls, Size size, Scene scene, bool generateMipMaps, bool invertY, int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
            : base(null, scene, !generateMipMaps, invertY)
        {
            this.name = name;
            this.wrapU = BABYLON.Texture.WRAP_ADDRESSMODE;
            this.wrapV = BABYLON.Texture.WRAP_ADDRESSMODE;
            var requiredWidth = size.width;
            var requiredHeight = size.height;
            this._texture = scene.getEngine().createDynamicTexture(requiredWidth, requiredHeight, generateMipMaps, samplingMode);
            var textureSize = this.getSize();
            this.video = (HTMLVideoElement)document.createElement("video");
            this.video.width = textureSize.width;
            this.video.height = textureSize.height;
            this.video.autoplay = false;
            this.video.loop = true;
            this.video.addEventListener("canplaythrough", (e) =>
            {
                if (this._texture != null)
                {
                    this._texture.isReady = true;
                }
            });
            urls.forEach((url) =>
            {
                var source = (HTMLSourceElement) document.createElement("source");
                source.src = url;
                this.video.appendChild(source);
            });
            this._lastUpdate = new Date().getTime();
        }
        public virtual bool update()
        {
            if (this._autoLaunch)
            {
                this._autoLaunch = false;
                this.video.play();
            }
            var now = new Date().getTime();
            if (now - this._lastUpdate < 15)
            {
                return false;
            }
            this._lastUpdate = now;
            this.getScene().getEngine().updateVideoTexture(this._texture, this.video, this._invertY);
            return true;
        }
    }
}