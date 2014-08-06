using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PostProcessRenderEffect
    {
        private Engine _engine;
        private Map<string, PostProcess> _postProcesses;
        private PostProcess _postProcessType;
        private double _ratio;
        private int _samplingMode;
        private Map<string, Camera> _cameras;
        private Map<string, Array<int>> _indicesForCamera;
        private Map<string, PostProcessRenderPass> _renderPasses;
        private Map<string, PostProcessRenderEffect> _renderEffectAsPasses;
        public string _name;
        public System.Action<Effect> parameters;
        public PostProcessRenderEffect(Engine engine, string name, PostProcess postProcessType, double ratio = 1.0, int samplingMode = 0)
        {
            this._engine = engine;
            this._name = name;
            this._postProcessType = postProcessType;
            this._ratio = ratio;
            this._samplingMode = samplingMode;
            this._cameras = new Map<string, Camera>();
            this._postProcesses = new Map<string, PostProcess>();
            this._indicesForCamera = new Map<string, Array<int>>();
            this._renderPasses = new Map<string, PostProcessRenderPass>();
            this._renderEffectAsPasses = new Map<string, PostProcessRenderEffect>();
            this.parameters = (Effect effect) => { };
        }

        private static PostProcess _GetInstance(Engine engine, PostProcess postProcessType, double ratio = 1.0, int samplingMode = 0)
        {
            // TODO: finish it
            return null;
        }

        public virtual void _update()
        {
            foreach (var renderPassName in this._renderPasses.Keys)
            {
                this._renderPasses[renderPassName]._update();
            }
        }
        public virtual void addPass(PostProcessRenderPass renderPass)
        {
            this._renderPasses[renderPass._name] = renderPass;
            this._linkParameters();
        }
        public virtual void removePass(PostProcessRenderPass renderPass)
        {
            this._renderPasses[renderPass._name] = null;
            this._linkParameters();
        }
        public virtual void addRenderEffectAsPass(PostProcessRenderEffect renderEffect)
        {
            this._renderEffectAsPasses[renderEffect._name] = renderEffect;
            this._linkParameters();
        }
        public virtual PostProcessRenderPass getPass(string passName)
        {
            foreach (var renderPassName in this._renderPasses.Keys)
            {
                if (renderPassName == passName)
                {
                    return this._renderPasses[passName];
                }
            }

            return null;
        }
        public virtual void emptyPasses()
        {
            this._renderPasses.Clear();
            this._linkParameters();
        }
        public virtual void _attachCameras(Camera camera)
        {
            _attachCameras(new Array<Camera>(camera));
        }
        public virtual void _attachCameras(Array<Camera> cameras)
        {
            string cameraKey;
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                cameraKey = cameraName;
                this._postProcesses[cameraKey] = this._postProcesses[cameraKey]
                    ?? PostProcessRenderEffect._GetInstance(this._engine, this._postProcessType, this._ratio, this._samplingMode);
                var index = camera.attachPostProcess(this._postProcesses[cameraKey]);
                if (this._indicesForCamera[cameraName] == null)
                {
                    this._indicesForCamera[cameraName] = new Array<int>();
                }
                this._indicesForCamera[cameraName].Add(index);
                this._cameras[cameraName] = camera;
                foreach (var passName in this._renderPasses.Keys)
                {
                    this._renderPasses[passName]._incRefCount();
                }
            }
            this._linkParameters();
        }
        public virtual void _detachCameras(Camera camera)
        {
            _detachCameras(new Array<Camera>(camera));
        }
        public virtual void _detachCameras(Array<Camera> cameras)
        {
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                camera.detachPostProcess(this._postProcesses[cameraName], this._indicesForCamera[cameraName]);
                this._indicesForCamera.Remove(cameraName);
                this._cameras.Remove(cameraName);
                foreach (var passName in this._renderPasses.Keys)
                {
                    this._renderPasses[passName]._decRefCount();
                }
            }
        }
        public virtual void _enable(Camera cameras)
        {
            _enable(new Array<Camera>(cameras));
        }
        public virtual void _enable(Array<Camera> cameras)
        {
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                for (var j = 0; j < this._indicesForCamera[cameraName].Length; j++)
                {
                    if (camera._postProcesses[this._indicesForCamera[cameraName][j]] == null)
                    {
                        cameras[i].attachPostProcess(this._postProcesses[cameraName], this._indicesForCamera[cameraName][j]);
                    }
                }
                foreach (var passName in this._renderPasses.Keys)
                {
                    this._renderPasses[passName]._incRefCount();
                }
            }
        }
        public virtual void _disable(Camera cameras)
        {
            _disable(new Array<Camera>(cameras));
        }
        public virtual void _disable(Array<Camera> cameras)
        {
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                camera.detachPostProcess(this._postProcesses[cameraName], this._indicesForCamera[cameraName]);
                foreach (var passName in this._renderPasses.Keys)
                {
                    this._renderPasses[passName]._decRefCount();
                }
            }
        }
        public virtual PostProcess getPostProcess(Camera camera = null)
        {
            return this._postProcesses[camera.name];
        }
        private void _linkParameters()
        {
            foreach (var index in this._postProcesses.Keys)
            {
                this._postProcesses[index].onApply = (Effect effect) =>
                {
                    this.parameters(effect);
                    this._linkTextures(effect);
                };
            }
        }
        private void _linkTextures(Effect effect)
        {
            foreach (var renderPassName in this._renderPasses.Keys)
            {
                effect.setTexture(renderPassName, this._renderPasses[renderPassName].getRenderTexture());
            }
            foreach (var renderEffectName in this._renderEffectAsPasses.Keys)
            {
                effect.setTextureFromPostProcess(renderEffectName + "Sampler", this._renderEffectAsPasses[renderEffectName].getPostProcess());
            }
        }
    }
}