using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class BaseTexture : IAnimatable
    {
        public string name;
        public int delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NONE;
        public bool hasAlpha = false;
        public bool getAlphaFromRGB = false;
        public int level = 1;
        public bool isCube = false;
        public bool isRenderTarget = false;
        public System.Action onDispose;
        public int coordinatesIndex = 0;
        public int coordinatesMode = BABYLON.Texture.EXPLICIT_MODE;
        public int wrapU = BABYLON.Texture.WRAP_ADDRESSMODE;
        public int wrapV = BABYLON.Texture.WRAP_ADDRESSMODE;
        public int anisotropicFilteringLevel = 4;
        public int _cachedAnisotropicFilteringLevel;
        private Scene _scene;
        public WebGLTexture _texture;
        public BaseTexture(Scene scene)
        {
            this._scene = scene;
            this._scene.textures.push(this);
        }
        public virtual Scene getScene()
        {
            return this._scene;
        }
        public virtual Matrix getTextureMatrix()
        {
            return null;
        }
        public virtual Matrix getReflectionTextureMatrix()
        {
            return null;
        }
        public virtual WebGLTexture getInternalTexture()
        {
            return this._texture;
        }
        public virtual bool isReady()
        {
            if (this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_NOTLOADED)
            {
                return true;
            }
            if (this._texture != null)
            {
                return this._texture.isReady;
            }
            return false;
        }
        public virtual ISize getSize()
        {
            if (this._texture._width > 0)
            {
                return new Size { width = this._texture._width, height = this._texture._height };
            }
            if (this._texture._size > 0)
            {
                return new Size { width = this._texture._size, height = this._texture._size };
            }
            return new Size { width = 0, height = 0 };
        }
        public virtual ISize getBaseSize()
        {
            if (!this.isReady())
                return new Size { width = 0, height = 0 };
            if (this._texture._size > 0)
            {
                return new Size { width = this._texture._size, height = this._texture._size };
            }
            return new Size { width = this._texture._baseWidth, height = this._texture._baseHeight };
        }
        public virtual WebGLTexture _getFromCache(string url, bool noMipmap)
        {
            var texturesCache = this._scene.getEngine().getLoadedTexturesCache();
            for (var index = 0; index < texturesCache.Length; index++)
            {
                var texturesCacheEntry = texturesCache[index];
                if (texturesCacheEntry.url == url && texturesCacheEntry.noMipmap == noMipmap)
                {
                    texturesCacheEntry.references++;
                    return texturesCacheEntry;
                }
            }
            return null;
        }
        public virtual void delayLoad() { }
        public virtual void releaseInternalTexture()
        {
            if (this._texture == null)
            {
                return;
            }
            var texturesCache = this._scene.getEngine().getLoadedTexturesCache();
            this._texture.references--;
            if (this._texture.references == 0)
            {
                var index = texturesCache.indexOf(this._texture);
                texturesCache.splice(index, 1);
                this._scene.getEngine()._releaseTexture(this._texture);
                this._texture = null;
            }
        }
        public virtual BaseTexture clone()
        {
            return null
        }
        public virtual void dispose()
        {
            var index = this._scene.textures.indexOf(this);
            if (index >= 0)
            {
                this._scene.textures.splice(index, 1);
            }
            if (this._texture == null)
            {
                return;
            }
            this.releaseInternalTexture();
            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }

        public Array<Animation> animations { get; private set; }
    }
}