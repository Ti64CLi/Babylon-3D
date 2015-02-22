// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.cubeTexture.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class CubeTexture : Texture
    {
        /// <summary>
        /// </summary>
        private readonly Array<string> _extensions;

        /// <summary>
        /// </summary>
        private readonly bool _noMipmap;

        /// <summary>
        /// </summary>
        private readonly Matrix _textureMatrix;

        /// <summary>
        /// </summary>
        /// <param name="rootUrl">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="extensions">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        public CubeTexture(string rootUrl, Scene scene, Array<string> extensions = null, bool noMipmap = false)
            : base(null, scene)
        {
            this.name = rootUrl;
            this.url = rootUrl;
            this._noMipmap = noMipmap;
            this.hasAlpha = false;
            this._texture = this._getFromCache(rootUrl, noMipmap);
            if (extensions == null)
            {
                extensions = new Array<string>("_px.jpg", "_py.jpg", "_pz.jpg", "_nx.jpg", "_ny.jpg", "_nz.jpg");
            }

            this._extensions = extensions;
            if (this._texture == null)
            {
                if (!scene.useDelayedTextureLoading)
                {
                    this._texture = scene.getEngine().createCubeTexture(rootUrl, scene, extensions, noMipmap);
                }
                else
                {
                    this.delayLoadState = Engine.DELAYLOADSTATE_NOTLOADED;
                }
            }

            this.isCube = true;
            this._textureMatrix = Matrix.Identity();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture clone()
        {
            var newTexture = new CubeTexture(this.url, this.getScene(), this._extensions, this._noMipmap);
            newTexture.level = this.level;
            newTexture.wrapU = this.wrapU;
            newTexture.wrapV = this.wrapV;
            newTexture.coordinatesIndex = this.coordinatesIndex;
            newTexture.coordinatesMode = this.coordinatesMode;
            return newTexture;
        }

        /// <summary>
        /// </summary>
        public override void delayLoad()
        {
            if (this.delayLoadState != Engine.DELAYLOADSTATE_NOTLOADED)
            {
                return;
            }

            this.delayLoadState = Engine.DELAYLOADSTATE_LOADED;
            this._texture = this._getFromCache(this.url, this._noMipmap);
            if (this._texture == null)
            {
                this._texture = this.getScene().getEngine().createCubeTexture(this.url, this.getScene(), this._extensions);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix getReflectionTextureMatrix()
        {
            return this._textureMatrix;
        }
    }
}