using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PostProcessRenderPipeline
    {
        private Engine _engine;
        private Map<string, PostProcessRenderEffect> _renderEffects;
        private Map<string, PostProcessRenderEffect> _renderEffectsForIsolatedPass;
        private Map<string, Camera> _cameras;
        public string _name;
        private const string PASS_EFFECT_NAME = "passEffect";
        private const string PASS_SAMPLER_NAME = "passSampler";
        public PostProcessRenderPipeline(Engine engine, string name)
        {
            this._engine = engine;
            this._name = name;
            this._renderEffects = new Map<string, PostProcessRenderEffect>();
            this._renderEffectsForIsolatedPass = new Map<string, PostProcessRenderEffect>();
            this._cameras = new Map<string, Camera>();
        }
        public virtual void addEffect(PostProcessRenderEffect renderEffect)
        {
            this._renderEffects[renderEffect._name] = renderEffect;
        }
        public virtual void _enableEffect(string renderEffectName, Camera camera)
        {
            _enableEffect(renderEffectName, new Array<Camera>(camera));
        }
        public virtual void _enableEffect(string renderEffectName, Array<Camera> cameras)
        {
            var renderEffects = this._renderEffects[renderEffectName];
            if (renderEffects == null)
            {
                return;
            }
            renderEffects._enable(cameras);
        }
        public virtual void _disableEffect(string renderEffectName, Camera camera)
        {
            _disableEffect(renderEffectName, new Array<Camera>(camera));
        }
        public virtual void _disableEffect(string renderEffectName, Array<Camera> cameras)
        {
            var renderEffects = this._renderEffects[renderEffectName];
            if (renderEffects == null)
            {
                return;
            }
            renderEffects._disable(cameras);
        }
        public virtual void _attachCameras(Camera camera, bool unique)
        {
            _attachCameras(new Array<Camera>(camera), unique);
        }
        public virtual void _attachCameras(Array<Camera> cameras, bool unique)
        {
            var _cam = cameras;
            var indicesToDelete = new Array<int>();
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                if (!this._cameras.ContainsKey(cameraName))
                {
                    this._cameras[cameraName] = camera;
                }
                else
                    if (unique)
                    {
                        indicesToDelete.Add(i);
                    }
            }
            for (var i = 0; i < indicesToDelete.Length; i++)
            {
                cameras.RemoveAt(indicesToDelete[i]);
            }
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._attachCameras(_cam);
            }
        }
        public virtual void _detachCameras(Camera camera)
        {
            _detachCameras(new Array<Camera>(camera));
        }
        public virtual void _detachCameras(Array<Camera> cameras)
        {
            var _cam = cameras;
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._detachCameras(_cam);
            }
            for (var i = 0; i < _cam.Length; i++)
            {
                this._cameras.Remove(_cam[i].name);
            }
        }
        public virtual void _enableDisplayOnlyPass(string passName, Camera cameras)
        {
            _enableDisplayOnlyPass(passName, new Array<Camera>(cameras));
        }
        public virtual void _enableDisplayOnlyPass(string passName, Array<Camera> cameras)
        {
            var _cam = cameras;
            PostProcessRenderPass pass = null;
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                pass = this._renderEffects[renderEffectName].getPass(passName);
                if (pass != null)
                {
                    break;
                }
            }
            if (pass == null)
            {
                return;
            }
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._disable(_cam);
            }
            pass._name = PostProcessRenderPipeline.PASS_SAMPLER_NAME;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] =
                    this._renderEffectsForIsolatedPass[cameraName]
                    ?? new PostProcessRenderEffect(this._engine, PostProcessRenderPipeline.PASS_EFFECT_NAME, new BABYLON.DisplayPassPostProcess(PostProcessRenderPipeline.PASS_EFFECT_NAME, 1.0, null, 0), 1.0, 0);
                this._renderEffectsForIsolatedPass[cameraName].emptyPasses();
                this._renderEffectsForIsolatedPass[cameraName].addPass(pass);
                this._renderEffectsForIsolatedPass[cameraName]._attachCameras(camera);
            }
        }
        public virtual void _disableDisplayOnlyPass(Camera camera)
        {
            _disableDisplayOnlyPass(new Array<Camera>(camera));
        }
        public virtual void _disableDisplayOnlyPass(Array<Camera> cameras)
        {
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] =
                    this._renderEffectsForIsolatedPass[cameraName]
                    ?? new PostProcessRenderEffect(this._engine, PostProcessRenderPipeline.PASS_EFFECT_NAME, new BABYLON.DisplayPassPostProcess(PostProcessRenderPipeline.PASS_EFFECT_NAME, 1.0, null, 0), 1.0, 0);
                this._renderEffectsForIsolatedPass[cameraName]._disable(camera);
            }
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._enable(_cam);
            }
        }
        public virtual void _update()
        {
            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._update();
            }
            foreach (var cameraName in this._cameras.Keys)
            {
                if (this._renderEffectsForIsolatedPass[cameraName] != null)
                {
                    this._renderEffectsForIsolatedPass[cameraName]._update();
                }
            }
        }
    }
}