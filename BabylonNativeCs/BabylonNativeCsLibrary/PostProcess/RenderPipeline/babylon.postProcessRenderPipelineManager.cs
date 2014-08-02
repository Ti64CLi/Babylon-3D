using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PostProcessRenderPipelineManager
    {
        /*
        private Map<string, PostProcessRenderPipeline> _renderPipelines;
        public PostProcessRenderPipelineManager()
        {
            this._renderPipelines = new Map<string, PostProcessRenderPipeline>();
        }
        public virtual void addPipeline(PostProcessRenderPipeline renderPipeline)
        {
            this._renderPipelines[renderPipeline._name] = renderPipeline;
        }
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Camera cameras, bool unique = false) { }
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Array<Camera> cameras, bool unique = false) { }
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, object cameras, bool unique = false)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.attachCameras(cameras, unique);
        }
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Camera cameras) { }
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Array<Camera> cameras) { }
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, object cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.detachCameras(cameras);
        }
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras) { }
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras) { }
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, object cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.enableEffect(renderEffectName, cameras);
        }
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras) { }
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras) { }
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, object cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.disableEffect(renderEffectName, cameras);
        }
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Camera cameras) { }
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Array<Camera> cameras) { }
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, object cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.enableDisplayOnlyPass(passName, cameras);
        }
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Camera cameras) { }
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Array<Camera> cameras) { }
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, object cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline.disableDisplayOnlyPass(cameras);
        }
        public virtual void update()
        {
            foreach (var renderPipelineName in this._renderPipelines)
            {
                this._renderPipelines[renderPipelineName]._update();
            }
        }
        */
    }
}