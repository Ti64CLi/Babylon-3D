// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.postProcess.cs" company="">
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
    public partial class PostProcess
    {
        /// <summary>
        /// </summary>
        public int _currentRenderTextureInd = 0;

        /// <summary>
        /// </summary>
        public SmartArray<WebGLTexture> _textures = new SmartArray<WebGLTexture>(2);

        /// <summary>
        /// </summary>
        public int height = -1;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public Action<Camera> onActivate;

        /// <summary>
        /// </summary>
        public Action<Effect> onApply;

        /// <summary>
        /// </summary>
        public System.Action onSizeChanged;

        /// <summary>
        /// </summary>
        public int renderTargetSamplingMode;

        /// <summary>
        /// </summary>
        public int width = -1;

        /// <summary>
        /// </summary>
        private readonly Camera _camera;

        /// <summary>
        /// </summary>
        private readonly Effect _effect;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private readonly double _renderRatio;

        /// <summary>
        /// </summary>
        private readonly bool _reusable;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="fragmentUrl">
        /// </param>
        /// <param name="parameters">
        /// </param>
        /// <param name="samplers">
        /// </param>
        /// <param name="ratio">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <param name="engine">
        /// </param>
        /// <param name="reusable">
        /// </param>
        public PostProcess(
            string name, 
            string fragmentUrl, 
            Array<string> parameters, 
            Array<string> samplers, 
            double ratio, 
            Camera camera, 
            int samplingMode, 
            Engine engine = null, 
            bool reusable = false)
        {
            this.name = name;
            if (camera != null)
            {
                this._camera = camera;
                this._scene = camera.getScene();
                camera.attachPostProcess(this);
                this._engine = this._scene.getEngine();
            }
            else
            {
                this._engine = engine;
            }

            this._renderRatio = ratio;
            this.renderTargetSamplingMode = (samplingMode > 0) ? samplingMode : Texture.NEAREST_SAMPLINGMODE;
            this._reusable = reusable || false;
            samplers = samplers ?? new Array<string>();
            samplers.Add("textureSampler");
            this._effect = this._engine.createEffect(
                new EffectBaseName { vertex = "postprocess", fragment = fragmentUrl }, 
                new Array<string>("position"), 
                parameters ?? new Array<string>(), 
                samplers, 
                string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        /// <param name="sourceTexture">
        /// </param>
        public virtual void activate(Camera camera, WebGLTexture sourceTexture = null)
        {
            camera = camera ?? this._camera;
            var scene = camera.getScene();
            var desiredWidth = ((sourceTexture != null) ? sourceTexture._width : this._engine.getRenderingCanvas().width) * this._renderRatio;
            var desiredHeight = ((sourceTexture != null) ? sourceTexture._height : this._engine.getRenderingCanvas().height) * this._renderRatio;
            if (this.width != desiredWidth || this.height != desiredHeight)
            {
                if (this._textures.Length > 0)
                {
                    for (var i = 0; i < this._textures.Length; i++)
                    {
                        this._engine._releaseTexture(this._textures[i]);
                    }

                    this._textures.reset();
                }

                this.width = (int)desiredWidth;
                this.height = (int)desiredHeight;
                this._textures.Add(
                    this._engine.createRenderTargetTexture(
                        new Size { width = this.width, height = this.height }, 
                        generateMipMaps: false, 
                        generateDepthBuffer: camera._postProcesses.IndexOf(this) == camera._postProcessesTakenIndices[0], 
                        samplingMode: this.renderTargetSamplingMode));
                if (this._reusable)
                {
                    this._textures.Add(
                        this._engine.createRenderTargetTexture(
                            new Size { width = this.width, height = this.height }, 
                            generateMipMaps: false, 
                            generateDepthBuffer: camera._postProcesses.IndexOf(this) == camera._postProcessesTakenIndices[0], 
                            samplingMode: this.renderTargetSamplingMode));
                }

                if (this.onSizeChanged != null)
                {
                    this.onSizeChanged();
                }
            }

            this._engine.bindFramebuffer(this._textures[this._currentRenderTextureInd]);
            if (this.onActivate != null)
            {
                this.onActivate(camera);
            }

            this._engine.clear(scene.clearColor, scene.autoClear || scene.forceWireframe, true);
            if (this._reusable)
            {
                this._currentRenderTextureInd = (this._currentRenderTextureInd + 1) % 2;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Effect apply()
        {
            if (!this._effect.isReady())
            {
                return null;
            }

            this._engine.enableEffect(this._effect);
            this._engine.setState(false);
            this._engine.setAlphaMode(Engine.ALPHA_DISABLE);
            this._engine.setDepthBuffer(false);
            this._engine.setDepthWrite(false);
            this._effect._bindTexture("textureSampler", this._textures[this._currentRenderTextureInd]);
            if (this.onApply != null)
            {
                this.onApply(this._effect);
            }

            return this._effect;
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        public virtual void dispose(Camera camera)
        {
            camera = camera ?? this._camera;
            if (this._textures.Length > 0)
            {
                for (var i = 0; i < this._textures.Length; i++)
                {
                    this._engine._releaseTexture(this._textures[i]);
                }

                this._textures.reset();
            }

            camera.detachPostProcess(this);
            var index = camera._postProcesses.IndexOf(this);
            if (index == camera._postProcessesTakenIndices[0] && camera._postProcessesTakenIndices.Length > 0)
            {
                this._camera._postProcesses[camera._postProcessesTakenIndices[0]].width = -1;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReusable()
        {
            return this._reusable;
        }
    }
}