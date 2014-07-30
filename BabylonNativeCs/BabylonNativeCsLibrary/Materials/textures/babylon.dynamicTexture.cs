using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class DynamicTexture: Texture {
        private bool _generateMipMaps;
        private HTMLCanvasElement _canvas;
        private CanvasRenderingContext2D _context;
        public DynamicTexture(string name, object options, Scene scene, bool generateMipMaps, float samplingMode = Texture.TRILINEAR_SAMPLINGMODE): base(null, scene, !generateMipMaps) {
            this.name = name;
            this.wrapU = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this.wrapV = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this._generateMipMaps = generateMipMaps;
            if (options.getContext) {
                this._canvas = options;
                this._texture = scene.getEngine().createDynamicTexture(options.width, options.height, generateMipMaps, samplingMode);
            } else {
                this._canvas = document.createElement("canva");
                if (options.width) {
                    this._texture = scene.getEngine().createDynamicTexture(options.width, options.height, generateMipMaps, samplingMode);
                } else {
                    this._texture = scene.getEngine().createDynamicTexture(options, options, generateMipMaps, samplingMode);
                }
            }
            var textureSize = this.getSize();
            this._canvas.width = textureSize.width;
            this._canvas.height = textureSize.height;
            this._context = this._canvas.getContext("2");
        }
        public virtual CanvasRenderingContext2D getContext() {
            return this._context;
        }
        public virtual void update(bool invertY = false) {
            this.getScene().getEngine().updateDynamicTexture(this._texture, this._canvas, (invertY == undefined) ? true : invertY);
        }
        public virtual void drawText(string text, float x, float y, string font, string color, string clearColor, bool invertY = false) {
            var size = this.getSize();
            if (clearColor) {
                this._context.fillStyle = clearColor;
                this._context.fillRect(0, 0, size.width, size.height);
            }
            this._context.font = font;
            if (x == null) {
                var textSize = this._context.measureText(text);
                x = (size.width - textSize.width) / 2;
            }
            this._context.fillStyle = color;
            this._context.fillText(text, x, y);
            this.update(invertY);
        }
        public virtual DynamicTexture clone() {
            var textureSize = this.getSize();
            var newTexture = new BABYLON.DynamicTexture(this.name, textureSize.width, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.wrapU = this.wrapU;
            newTexture.wrapV = this.wrapV;
            return newTexture;
        }
    }
}