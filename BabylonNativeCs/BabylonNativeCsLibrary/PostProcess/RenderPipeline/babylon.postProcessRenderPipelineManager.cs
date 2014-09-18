// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.postProcessRenderPipelineManager.cs" company="">
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
    public partial class PostProcessRenderPipelineManager
    {
        /// <summary>
        /// </summary>
        private readonly Map<string, PostProcessRenderPipeline> _renderPipelines;

        /// <summary>
        /// </summary>
        public PostProcessRenderPipelineManager()
        {
            this._renderPipelines = new Map<string, PostProcessRenderPipeline>();
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipeline">
        /// </param>
        public virtual void addPipeline(PostProcessRenderPipeline renderPipeline)
        {
            this._renderPipelines[renderPipeline._name] = renderPipeline;
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <param name="unique">
        /// </param>
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Camera camera, bool unique = false)
        {
            this.attachCamerasToRenderPipeline(renderPipelineName, new Array<Camera>(camera), unique);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        /// <param name="unique">
        /// </param>
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Array<Camera> cameras, bool unique = false)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._attachCameras(cameras, unique);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Camera cameras)
        {
            this.detachCamerasFromRenderPipeline(renderPipelineName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._detachCameras(cameras);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Camera cameras)
        {
            this.disableDisplayOnlyPassInPipeline(renderPipelineName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._disableDisplayOnlyPass(cameras);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras)
        {
            this.disableEffectInPipeline(renderPipelineName, renderEffectName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._disableEffect(renderEffectName, cameras);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="passName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Camera cameras)
        {
            this.enableDisplayOnlyPassInPipeline(renderPipelineName, passName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="passName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._enableDisplayOnlyPass(passName, cameras);
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras)
        {
            this.enableEffectInPipeline(renderPipelineName, renderEffectName, new Array<Camera>(cameras));
        }

        /// <summary>
        /// </summary>
        /// <param name="renderPipelineName">
        /// </param>
        /// <param name="renderEffectName">
        /// </param>
        /// <param name="cameras">
        /// </param>
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }

            renderPipeline._enableEffect(renderEffectName, cameras);
        }

        /// <summary>
        /// </summary>
        public virtual void update()
        {
            foreach (var renderPipelineName in this._renderPipelines.Keys)
            {
                this._renderPipelines[renderPipelineName]._update();
            }
        }
    }
}