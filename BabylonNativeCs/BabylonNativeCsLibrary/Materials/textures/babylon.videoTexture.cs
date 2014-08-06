// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.videoTexture.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using Web;

    /// <summary>
    /// </summary>
    public partial class VideoTexture : Texture
    {
        /// <summary>
        /// </summary>
        public HTMLVideoElement video;

        /// <summary>
        /// </summary>
        private bool _autoLaunch = true;

        /// <summary>
        /// </summary>
        private double _lastUpdate;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="urls">
        /// </param>
        /// <param name="size">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="invertY">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        public VideoTexture(
            string name, Array<string> urls, Size size, Scene scene, bool generateMipMaps, bool invertY, int samplingMode = TRILINEAR_SAMPLINGMODE)
            : base(null, scene, !generateMipMaps, invertY)
        {
            this.name = name;
            this.wrapU = WRAP_ADDRESSMODE;
            this.wrapV = WRAP_ADDRESSMODE;
            var requiredWidth = size.width;
            var requiredHeight = size.height;
            this._texture = scene.getEngine().createDynamicTexture(requiredWidth, requiredHeight, generateMipMaps, samplingMode);
            var textureSize = this.getSize();
            this.video = (HTMLVideoElement)Engine.document.createElement("video");
            this.video.width = textureSize.width;
            this.video.height = textureSize.height;
            this.video.autoplay = false;
            this.video.loop = true;
            this.video.addEventListener(
                "canplaythrough", 
                (e) =>
                    {
                        if (this._texture != null)
                        {
                            this._texture.isReady = true;
                        }
                    });
            foreach (var url in urls)
            {
                var source = (HTMLSourceElement)Engine.document.createElement("source");
                source.src = url;
                this.video.appendChild(source);
            }

            this._lastUpdate = new Date().getTime();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
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