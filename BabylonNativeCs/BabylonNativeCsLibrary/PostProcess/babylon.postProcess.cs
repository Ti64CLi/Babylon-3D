using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PostProcess
    {
        public System.Action<object> onApply;
        public System.Action onSizeChanged;
        public System.Action<object> onActivate;
        public int width = -1;
        public int height = -1;
        public int renderTargetSamplingMode;
        private Camera _camera;
        private Scene _scene;
        private Engine _engine;
        private double _renderRatio;
        private bool _reusable = false;
        public BABYLON.SmartArray<WebGLTexture> _textures = new BABYLON.SmartArray<WebGLTexture>(2);
        public int _currentRenderTextureInd = 0;
        private Effect _effect;
        public string name;
        public PostProcess(string name, string fragmentUrl, Array<string> parameters, Array<string> samplers, double ratio, Camera camera, double samplingMode, Engine engine = null, bool reusable = false)
        {
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
            this.renderTargetSamplingMode = (samplingMode) ? samplingMode : BABYLON.Texture.NEAREST_SAMPLINGMODE;
            this._reusable = reusable || false;
            samplers = samplers || new Array<object>();
            samplers.push("textureSampler");
            this._effect = this._engine.createEffect(new { }, new Array<object>("position"), parameters || new Array<object>(), samplers, "");
        }
        public virtual bool isReusable()
        {
            return this._reusable;
        }
        public virtual void activate(Camera camera, WebGLTexture sourceTexture = null)
        {
            camera = camera || this._camera;
            var scene = camera.getScene();
            var desiredWidth = ((sourceTexture) ? sourceTexture._width : this._engine.getRenderingCanvas().width) * this._renderRatio;
            var desiredHeight = ((sourceTexture) ? sourceTexture._height : this._engine.getRenderingCanvas().height) * this._renderRatio;
            if (this.width != desiredWidth || this.height != desiredHeight)
            {
                if (this._textures.Length > 0)
                {
                    for (var i = 0; i < this._textures.Length; i++)
                    {
                        this._engine._releaseTexture(this._textures.data[i]);
                    }
                    this._textures.reset();
                }
                this.width = desiredWidth;
                this.height = desiredHeight;
                this._textures.push(this._engine.createRenderTargetTexture(new { }, new { }));
                if (this._reusable)
                {
                    this._textures.push(this._engine.createRenderTargetTexture(new { }, new { }));
                }
                if (this.onSizeChanged)
                {
                    this.onSizeChanged();
                }
            }
            this._engine.bindFramebuffer(this._textures.data[this._currentRenderTextureInd]);
            if (this.onActivate)
            {
                this.onActivate(camera);
            }
            this._engine.clear(scene.clearColor, scene.autoClear || scene.forceWireframe, true);
            if (this._reusable)
            {
                this._currentRenderTextureInd = (this._currentRenderTextureInd + 1) % 2;
            }
        }
        public virtual Effect apply()
        {
            if (!this._effect.isReady())
                return null;
            this._engine.enableEffect(this._effect);
            this._engine.setState(false);
            this._engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
            this._engine.setDepthBuffer(false);
            this._engine.setDepthWrite(false);
            this._effect._bindTexture("textureSampler", this._textures.data[this._currentRenderTextureInd]);
            if (this.onApply)
            {
                this.onApply(this._effect);
            }
            return this._effect;
        }
        public virtual void dispose(Camera camera)
        {
            camera = camera || this._camera;
            if (this._textures.Length > 0)
            {
                for (var i = 0; i < this._textures.Length; i++)
                {
                    this._engine._releaseTexture(this._textures.data[i]);
                }
                this._textures.reset();
            }
            camera.detachPostProcess(this);
            var index = camera._postProcesses.indexOf(this);
            if (index == camera._postProcessesTakenIndices[0] && camera._postProcessesTakenIndices.Length > 0)
            {
                this._camera._postProcesses[camera._postProcessesTakenIndices[0]].width = -1;
            }
        }
    }
}