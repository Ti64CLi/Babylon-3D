using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class PostProcessRenderEffect {
        private Engine _engine;
        private Array < PostProcess > _postProcesses;
        private dynamic _postProcessType;
        private double _ratio;
        private double _samplingMode;
        private bool _singleInstance;
        private Array < Camera > _cameras;
        private Array < Array < double >> _indicesForCamera;
        private Array < PostProcessRenderPass > _renderPasses;
        private Array < PostProcessRenderEffect > _renderEffectAsPasses;
        public string _name;
        public System.Action < Effect > parameters;
        public PostProcessRenderEffect(Engine engine, string name, object postProcessType, double ratio = 0.0, double samplingMode = 0.0, bool singleInstance = false) {
            this._engine = engine;
            this._name = name;
            this._postProcessType = postProcessType;
            this._ratio = ratio || 1.0;
            this._samplingMode = samplingMode || null;
            this._singleInstance = singleInstance || true;
            this._cameras = new Array < object > ();
            this._postProcesses = new Array < object > ();
            this._indicesForCamera = new Array < object > ();
            this._renderPasses = new Array < object > ();
            this._renderEffectAsPasses = new Array < object > ();
            this.parameters = (Effect effect) => {};
        }
        private static PostProcess _GetInstance(Engine engine, object postProcessType, double ratio, double samplingMode) {
            var postProcess;
            var instance;
            var args = new Array < object > ();
            var parameters = PostProcessRenderEffect._GetParametersNames(postProcessType);
            for (var i = 0; i < parameters.Length; i++) {
                switch (parameters[i]) {
                    case "name":
                        args[i] = postProcessType.ToString();
                        break;
                    case "ratio":
                        args[i] = ratio;
                        break;
                    case "camera":
                        args[i] = null;
                        break;
                    case "samplingMode":
                        args[i] = samplingMode;
                        break;
                    case "engine":
                        args[i] = engine;
                        break;
                    case "reusable":
                        args[i] = true;
                        break;
                    default:
                        args[i] = null;
                        break;
                }
            }
            postProcess = () {};
            postProcess.prototype = postProcessType.prototype;
            instance = new postProcess();
            postProcessType.apply(instance, args);
            return instance;
        }
        private static Array < string > _GetParametersNames(object func) {
            var commentsRegex = new Regex("((\/\/.*$)|(\/\*[\s\S]*?\*\/))", RegexOptions.Multiline);
            var functWithoutComments = func.ToString().replace(commentsRegex, "");
            var parameters = functWithoutComments.slice(functWithoutComments.indexOf("(") + 1, functWithoutComments.indexOf(")")).match(new Regex(/([^\s,]+)/g));
            if (parameters == null)
                parameters = new Array < object > ();
            return parameters;
        }
        public virtual void _update() {
            foreach(var renderPassName in this._renderPasses) {
                this._renderPasses[renderPassName]._update();
            }
        }
        public virtual void addPass(PostProcessRenderPass renderPass) {
            this._renderPasses[renderPass._name] = renderPass;
            this._linkParameters();
        }
        public virtual void removePass(PostProcessRenderPass renderPass) {
            this._renderPasses[renderPass._name] = null;
            this._linkParameters();
        }
        public virtual void addRenderEffectAsPass(PostProcessRenderEffect renderEffect) {
            this._renderEffectAsPasses[renderEffect._name] = renderEffect;
            this._linkParameters();
        }
        public virtual void getPass(string passName) {
            foreach(var renderPassName in this._renderPasses) {
                if (renderPassName == passName) {
                    return this._renderPasses[passName];
                }
            }
        }
        public virtual void emptyPasses() {
            this._renderPasses.Length = 0;
            this._linkParameters();
        }
        public virtual void _attachCameras(Camera cameras) {}
        public virtual void _attachCameras(Array < Camera > cameras) {}
        public virtual void _attachCameras(object cameras) {
            var cameraKey;
            var _cam = Tools.MakeArray(cameras || this._cameras);
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                if (this._singleInstance) {
                    cameraKey = 0;
                } else {
                    cameraKey = cameraName;
                }
                this._postProcesses[cameraKey] = this._postProcesses[cameraKey] || PostProcessRenderEffect._GetInstance(this._engine, this._postProcessType, this._ratio, this._samplingMode);
                var index = camera.attachPostProcess(this._postProcesses[cameraKey]);
                if (this._indicesForCamera[cameraName] == null) {
                    this._indicesForCamera[cameraName] = new Array < object > ();
                }
                this._indicesForCamera[cameraName].push(index);
                if (this._cameras.indexOf(camera) == -1) {
                    this._cameras[cameraName] = camera;
                }
                foreach(var passName in this._renderPasses) {
                    this._renderPasses[passName]._incRefCount();
                }
            }
            this._linkParameters();
        }
        public virtual void _detachCameras(Camera cameras) {}
        public virtual void _detachCameras(Array < Camera > cameras) {}
        public virtual void _detachCameras(object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                camera.detachPostProcess(this._postProcesses[(this._singleInstance) ? 0 : cameraName], this._indicesForCamera[cameraName]);
                var index = this._cameras.indexOf(cameraName);
                this._indicesForCamera.splice(index, 1);
                this._cameras.splice(index, 1);
                foreach(var passName in this._renderPasses) {
                    this._renderPasses[passName]._decRefCount();
                }
            }
        }
        public virtual void _enable(Camera cameras) {}
        public virtual void _enable(Array < Camera > cameras) {}
        public virtual void _enable(object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.name;
                for (var j = 0; j < this._indicesForCamera[cameraName].Length; j++) {
                    if (camera._postProcesses[this._indicesForCamera[cameraName][j]] == null) {
                        cameras[i].attachPostProcess(this._postProcesses[(this._singleInstance) ? 0 : cameraName], this._indicesForCamera[cameraName][j]);
                    }
                }
                foreach(var passName in this._renderPasses) {
                    this._renderPasses[passName]._incRefCount();
                }
            }
        }
        public virtual void _disable(Camera cameras) {}
        public virtual void _disable(Array < Camera > cameras) {}
        public virtual void _disable(object cameras) {
            var _cam = Tools.MakeArray(cameras || this._cameras);
            for (var i = 0; i < _cam.Length; i++) {
                var camera = _cam[i];
                var cameraName = camera.Name;
                camera.detachPostProcess(this._postProcesses[(this._singleInstance) ? 0 : cameraName], this._indicesForCamera[cameraName]);
                foreach(var passName in this._renderPasses) {
                    this._renderPasses[passName]._decRefCount();
                }
            }
        }
        public virtual PostProcess getPostProcess(Camera camera = null) {
            if (this._singleInstance) {
                return this._postProcesses[0];
            } else {
                return this._postProcesses[camera.name];
            }
        }
        private void _linkParameters() {
            foreach(var index in this._postProcesses) {
                this._postProcesses[index].onApply = (Effect effect) => {
                    this.parameters(effect);
                    this._linkTextures(effect);
                };
            }
        }
        private void _linkTextures(object effect) {
            foreach(var renderPassName in this._renderPasses) {
                effect.setTexture(renderPassName, this._renderPasses[renderPassName].getRenderTexture());
            }
            foreach(var renderEffectName in this._renderEffectAsPasses) {
                effect.setTextureFromPostProcess(renderEffectName + "Sampler", this._renderEffectAsPasses[renderEffectName].getPostProcess());
            }
        }
    }
}