// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.postProcessRenderPipeline.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class PostProcessRenderPipeline
    {
        /// <summary>
        /// </summary>
        public string _name;

        /// <summary>
        /// </summary>
        private readonly Map<string, Camera> _cameras;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private readonly Map<string, PostProcessRenderEffect> _renderEffects;

        /// <summary>
        /// </summary>
        private readonly Map<string, PostProcessRenderEffect> _renderEffectsForIsolatedPass;

        /// <summary>
        /// </summary>
        /// <param name="engine">
        /// </param>
        /// <param name="name">
        /// </param>
        public PostProcessRenderPipeline(Engine engine, string name)
        {
            this._engine = engine;
            this._name = name;
            this._renderEffects = new Map<string, PostProcessRenderEffect>();
            this._renderEffectsForIsolatedPass = new Map<string, PostProcessRenderEffect>();
            this._cameras = new Map<string, Camera>();
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        /// <param name="unique">
        /// </param>
        public virtual void _attachCameras(Camera camera, bool unique)
        {
            this._attachCameras(new Array<Camera>(camera), unique);
        }

        /// <summary>
        /// </summary>
        /// <param name="cameras">
        /// </param>
        /// <param name="unique">
        /// </param>
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
                else if (unique)
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

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        public virtual void _detachCameras(Camera camera)
        {
            this._detachCameras(new Array<Camera>(camera));
        }

        /// <summary>
        /// </summary>
        /// <param name="cameras">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        public virtual void _disableDisplayOnlyPass(Camera camera)
        {
            this._disableDisplayOnlyPass(new Array<Camera>(camera));
        }

        /// <summary>
        /// </summary>
        /// <param name="cameras">
        /// </param>
        public virtual void _disableDisplayOnlyPass(Array<Camera> cameras)
        {
            var _cam = cameras;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] = this._renderEffectsForIsolatedPass[cameraName]
                                                                 ?? new PostProcessRenderEffect(
                                                                        this._engine, 
                                                                        PASS_EFFECT_NAME, 
                                                                        new DisplayPassPostProcess(PASS_EFFECT_NAME, 1.0, null, 0), 
                                                                        1.0, 
                                                                        0);
                this._renderEffectsForIsolatedPass[cameraName]._disable(camera);
            }

            foreach (var renderEffectName in this._renderEffects.Keys)
            {
                this._renderEffects[renderEffectName]._enable(_cam);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="camera">
        /// </param>
        public virtual void _disableEffect(string renderEffectName, Camera camera)
        {
            this._disableEffect(renderEffectName, new Array<Camera>(camera));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void _disableEffect(string renderEffectName, Array<Camera> cameras)
        {
            var renderEffects = this._renderEffects[renderEffectName];
            if (renderEffects == null)
            {
                return;
            }

            renderEffects._disable(cameras);
        }

        /// <summary>
        /// </summary>
        /// <param name="passName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void _enableDisplayOnlyPass(string passName, Camera cameras)
        {
            this._enableDisplayOnlyPass(passName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="passName">
        /// </param>
        /// <param name="cameras">
        /// </param>
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

            pass._name = PASS_SAMPLER_NAME;
            for (var i = 0; i < _cam.Length; i++)
            {
                var camera = _cam[i];
                var cameraName = camera.name;
                this._renderEffectsForIsolatedPass[cameraName] = this._renderEffectsForIsolatedPass[cameraName]
                                                                 ?? new PostProcessRenderEffect(
                                                                        this._engine, 
                                                                        PASS_EFFECT_NAME, 
                                                                        new DisplayPassPostProcess(PASS_EFFECT_NAME, 1.0, null, 0), 
                                                                        1.0, 
                                                                        0);
                this._renderEffectsForIsolatedPass[cameraName].emptyPasses();
                this._renderEffectsForIsolatedPass[cameraName].addPass(pass);
                this._renderEffectsForIsolatedPass[cameraName]._attachCameras(camera);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="camera">
        /// </param>
        public virtual void _enableEffect(string renderEffectName, Camera camera)
        {
            this._enableEffect(renderEffectName, new Array<Camera>(camera));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void _enableEffect(string renderEffectName, Array<Camera> cameras)
        {
            var renderEffects = this._renderEffects[renderEffectName];
            if (renderEffects == null)
            {
                return;
            }

            renderEffects._enable(cameras);
        }

        /// <summary>
        /// </summary>
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

        /// <summary>
        /// </summary>
        /// <param name="renderEffect">
        /// </param>
        public virtual void addEffect(PostProcessRenderEffect renderEffect)
        {
            this._renderEffects[renderEffect._name] = renderEffect;
        }

        /// <summary>
        /// </summary>
        private const string PASS_EFFECT_NAME = "passEffect";

        /// <summary>
        /// </summary>
        private const string PASS_SAMPLER_NAME = "passSampler";
    }
}