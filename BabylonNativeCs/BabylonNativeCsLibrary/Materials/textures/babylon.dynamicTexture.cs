// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.dynamicTexture.cs" company="">
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
    public partial class DynamicTexture : Texture
    {
        /// <summary>
        /// </summary>
        private readonly HTMLCanvasElement _canvas;

        /// <summary>
        /// </summary>
        private readonly CanvasRenderingContext2D _context;

        /// <summary>
        /// </summary>
        private readonly bool _generateMipMaps;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        public DynamicTexture(string name, int options, Scene scene, bool generateMipMaps, int samplingMode = TRILINEAR_SAMPLINGMODE)
            : base(null, scene, !generateMipMaps)
        {
            this.name = name;
            this.wrapU = CLAMP_ADDRESSMODE;
            this.wrapV = CLAMP_ADDRESSMODE;
            this._generateMipMaps = generateMipMaps;
            this._canvas = (HTMLCanvasElement)Engine.document.createElement("canvas");
            this._texture = scene.getEngine().createDynamicTexture(options, options, generateMipMaps, samplingMode);
            var textureSize = this.getSize();
            this._canvas.width = textureSize.width;
            this._canvas.height = textureSize.height;
            this._context = (CanvasRenderingContext2D)this._canvas.getContext("2d");
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="options">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        public DynamicTexture(string name, HTMLCanvasElement options, Scene scene, bool generateMipMaps, int samplingMode = TRILINEAR_SAMPLINGMODE)
            : base(null, scene, !generateMipMaps)
        {
            this.name = name;
            this.wrapU = CLAMP_ADDRESSMODE;
            this.wrapV = CLAMP_ADDRESSMODE;
            this._generateMipMaps = generateMipMaps;
            this._canvas = options;
            this._texture = scene.getEngine().createDynamicTexture(options.width, options.height, generateMipMaps, samplingMode);
            var textureSize = this.getSize();
            this._canvas.width = textureSize.width;
            this._canvas.height = textureSize.height;
            this._context = (CanvasRenderingContext2D)this._canvas.getContext("2d");
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture clone()
        {
            var textureSize = this.getSize();
            var newTexture = new DynamicTexture(this.name, textureSize.width, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.wrapU = this.wrapU;
            newTexture.wrapV = this.wrapV;
            return newTexture;
        }

        /// <summary>
        /// </summary>
        /// <param name="text">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="font">
        /// </param>
        /// <param name="color">
        /// </param>
        /// <param name="clearColor">
        /// </param>
        /// <param name="invertY">
        /// </param>
        public virtual void drawText(string text, double x, double y, string font, string color, string clearColor, bool invertY = false)
        {
            var size = this.getSize();
            if (clearColor != null)
            {
                this._context.fillStyle = clearColor;
                this._context.fillRect(0, 0, size.width, size.height);
            }

            this._context.font = font;
            this._context.fillStyle = color;
            this._context.fillText(text, x, y);
            this.update(invertY);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual CanvasRenderingContext2D getContext()
        {
            return this._context;
        }

        /// <summary>
        /// </summary>
        /// <param name="invertY">
        /// </param>
        public virtual void update(bool invertY = false)
        {
            this.getScene().getEngine().updateDynamicTexture(this._texture, this._canvas, invertY);
        }
    }
}