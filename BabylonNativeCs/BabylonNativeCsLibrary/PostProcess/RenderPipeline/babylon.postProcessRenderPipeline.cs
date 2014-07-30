using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class PostProcessRenderPipeline {
        private Engine _engine;
        private Array < PostProcessRenderEffect > _renderEffects;
        private Array < PostProcessRenderEffect > _renderEffectsForIsolatedPass;
        private Array < Camera > _cameras;
        public string _name;
        private
        const string PASS_EFFECT_NAME = "passEffect";
        private
        const string PASS_SAMPLER_NAME = "passSampler";
        public PostProcessRenderPipeline(Engine engine, string name) {
            this._engine = engine;
            this._name = name;
            this._renderEffects = new Array < object > ();
            this._renderEffectsForIsolatedPass = new Array < object > ();
            this._cameras = new Array < object > ();
        }
        public virtual void addEffect(PostProcessRenderEffect renderEffect) {
            this._renderEffects[renderEffect._name] = renderEffect;
        }
        public virtual void _enableEffect(string renderEffectName, Camera cameras) {}
        public virtual void _enableEffect(string renderEffectName, Array < Camera > cameras) {}
        public virtual void _enableEffect(string renderEffectName, object cameras) {
            var renderEffects = this._renderEffects[renderEffectName];
            if (!renderEffects) {
                return;
            }
            renderEffects.enable(Tools.MakeArray(cameras || this._cameras));
        }
        public virtual void _disableEffect(string renderEffectName, Camera cameras) {}
        public virtual void _disableEffect(string renderEffectName, Array < Camera > cameras) {}
        public virtual void _disableEffect(string renderEffectName, object cameras) {
            var renderEffects = this._renderEffects[renderEffectName];
            if (!renderEffects) {
                return;
            }
            renderEffects.disable(Tools.MakeArray(cameras || this._cameras));
        }
        public virtual void _attachCameras(Camera cameras, bool unique) {}
        public virtual void _attachCameras(Array < Camera > cameras, bool unique) {}
        public virtual void _attachCameras(object cameras, bool unique) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            var indicesToDelete = new Array < object > ();
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                if (this._cameras.indexOf(camera) == -1) {
                    this._cameras[cameraName] = camera;
                } else
                if (unique) {
                    indicesToDelete.push(i);
                }
            }
            for (var i = 0; i < indicesToDelete.Length; i++) {
                cameras.splice(indicesToDelete[i], 1);
            }
            foreach(var renderEffectName in this._renderEffects) {
                this._renderEffects[renderEffectName]._attachCameras(_cam);
            }
        }
        public virtual void _detachCameras(Camera cameras) {}
        public virtual void _detachCameras(Array < Camera > cameras) {}
        public virtual void _detachCameras(object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            foreach(var renderEffectName in this._renderEffects) {
                this._renderEffects[renderEffectName]._detachCameras(_cam);
            }
            for (var i = 0; i < _cam.Length; i++) {
                this._cameras.splice(this._cameras.indexOf(_cam[i]), 1);
            }
        }
        public virtual void _enableDisplayOnlyPass(object passName, Camera cameras) {}
        public virtual void _enableDisplayOnlyPass(object passName, Array < Camera > cameras) {}
        public virtual void _enableDisplayOnlyPass(object passName, object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            var pass = null;
            foreach(var renderEffectName in this._renderEffects) {
                pass = this._renderEffects[renderEffectName].getPass(passName);
                if (pass != null) {
                    break;
                }
            }
            if (pass == null) {
                return;
            }
            foreach(var renderEffectName in this._renderEffects) {
                this._renderEffects[renderEffectName]._disable(_cam);
            }
            pass._name = PostProcessRenderPipeline.PASS_SAMPLER_NAME;
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] = this._renderEffectsForIsolatedPass[cameraName] || new PostProcessRenderEffect(this._engine, PostProcessRenderPipeline.PASS_EFFECT_NAME, "BABYLON.DisplayPassPostProcess", 1.0, null, null);
                this._renderEffectsForIsolatedPass[cameraName].emptyPasses();
                this._renderEffectsForIsolatedPass[cameraName].addPass(pass);
                this._renderEffectsForIsolatedPass[cameraName]._attachCameras(camera);
            }
        }
        public virtual void _disableDisplayOnlyPass(Camera cameras) {}
        public virtual void _disableDisplayOnlyPass(Array < Camera > cameras) {}
        public virtual void _disableDisplayOnlyPass(object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] = this._renderEffectsForIsolatedPass[cameraName] || new PostProcessRenderEffect(this._engine, PostProcessRenderPipeline.PASS_EFFECT_NAME, "BABYLON.DisplayPassPostProcess", 1.0, null, null);
                this._renderEffectsForIsolatedPass[cameraName]._disable(camera);
            }
            foreach(var renderEffectName in this._renderEffects) {
                this._renderEffects[renderEffectName]._enable(_cam);
            }
        }
        public virtual void _update() {
            foreach(var renderEffectName in this._renderEffects) {
                this._renderEffects[renderEffectName]._update();
            }
            for (var i = 0; i < this._cameras.Length; i++) {
                var cameraName = this._cameras[i].name;
                if (this._renderEffectsForIsolatedPass[cameraName]) {
                    this._renderEffectsForIsolatedPass[cameraName]._update();
                }
            }
        }
    }
}