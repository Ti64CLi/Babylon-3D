// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.baseTexture.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class BaseTexture : IAnimatable
    {
        /// <summary>
        /// </summary>
        public int _cachedAnisotropicFilteringLevel;

        /// <summary>
        /// </summary>
        public WebGLTexture _texture;

        /// <summary>
        /// </summary>
        public int anisotropicFilteringLevel = 4;

        /// <summary>
        /// </summary>
        public int coordinatesIndex = 0;

        /// <summary>
        /// </summary>
        public int coordinatesMode = Texture.EXPLICIT_MODE;

        /// <summary>
        /// </summary>
        public int delayLoadState = Engine.DELAYLOADSTATE_NONE;

        /// <summary>
        /// </summary>
        public bool getAlphaFromRGB = false;

        /// <summary>
        /// </summary>
        public bool hasAlpha = false;

        /// <summary>
        /// </summary>
        public bool isCube = false;

        /// <summary>
        /// </summary>
        public bool isRenderTarget = false;

        /// <summary>
        /// </summary>
        public double level = 1.0;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public int wrapU = Texture.WRAP_ADDRESSMODE;

        /// <summary>
        /// </summary>
        public int wrapV = Texture.WRAP_ADDRESSMODE;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        public BaseTexture(Scene scene)
        {
            this._scene = scene;
            this._scene.textures.Add(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="subPropertyName">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <returns>
        /// </returns>
        public object this[string subPropertyName]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// </summary>
        public Array<Animation> animations { get; set; }

        /// <summary>
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object value
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="url">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual BaseTexture clone()
        {
            return null;
        }

        /// <summary>
        /// </summary>
        public virtual void delayLoad()
        {
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            var index = this._scene.textures.IndexOf(this);
            if (index >= 0)
            {
                this._scene.textures.RemoveAt(index);
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Array<IAnimatable> getAnimatables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Size getBaseSize()
        {
            if (!this.isReady())
            {
                return new Size { width = 0, height = 0 };
            }

            if (this._texture._size > 0)
            {
                return new Size { width = this._texture._size, height = this._texture._size };
            }

            return new Size { width = this._texture._baseWidth, height = this._texture._baseHeight };
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual WebGLTexture getInternalTexture()
        {
            return this._texture;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getReflectionTextureMatrix()
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Scene getScene()
        {
            return this._scene;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Size getSize()
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getTextureMatrix()
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReady()
        {
            if (this.delayLoadState == Engine.DELAYLOADSTATE_NOTLOADED)
            {
                return true;
            }

            if (this._texture != null)
            {
                return this._texture.isReady;
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void markAsDirty(string propertyName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
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
                var index = texturesCache.IndexOf(this._texture);
                texturesCache.RemoveAt(index);
                this._scene.getEngine()._releaseTexture(this._texture);
                this._texture = null;
            }
        }
    }
}