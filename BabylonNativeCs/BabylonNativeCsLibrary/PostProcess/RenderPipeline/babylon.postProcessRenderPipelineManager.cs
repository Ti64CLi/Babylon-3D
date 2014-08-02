using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class PostProcessRenderPipelineManager
    {
        private Map<string, PostProcessRenderPipeline> _renderPipelines;
        public PostProcessRenderPipelineManager()
        {
            this._renderPipelines = new Map<string, PostProcessRenderPipeline>();
        }
        public virtual void addPipeline(PostProcessRenderPipeline renderPipeline)
        {
            this._renderPipelines[renderPipeline._name] = renderPipeline;
        }
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Camera camera, bool unique = false)
        {
            attachCamerasToRenderPipeline(renderPipelineName, new Array<Camera>(camera), unique);
        }
        public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Array<Camera> cameras, bool unique = false)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._attachCameras(cameras, unique);
        }
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Camera cameras)
        {
            detachCamerasFromRenderPipeline(renderPipelineName, new Array<Camera>(cameras));
        }
        public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._detachCameras(cameras);
        }
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras)
        {
            enableEffectInPipeline(renderPipelineName, renderEffectName, new Array<Camera>(cameras));
        }
        public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._enableEffect(renderEffectName, cameras);
        }
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras)
        {
            disableEffectInPipeline(renderPipelineName, renderEffectName, new Array<Camera>(cameras));
        }
        public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._disableEffect(renderEffectName, cameras);
        }
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Camera cameras)
        {
            enableDisplayOnlyPassInPipeline(renderPipelineName, passName, new Array<Camera>(cameras));
        }
        public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._enableDisplayOnlyPass(passName, cameras);
        }
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Camera cameras) { 
            disableDisplayOnlyPassInPipeline(renderPipelineName, new Array<Camera>(cameras));
        }
        public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Array<Camera> cameras)
        {
            var renderPipeline = this._renderPipelines[renderPipelineName];
            if (renderPipeline == null)
            {
                return;
            }
            renderPipeline._disableDisplayOnlyPass(cameras);
        }
        public virtual void update()
        {
            foreach (var renderPipelineName in this._renderPipelines.Keys)
            {
                this._renderPipelines[renderPipelineName]._update();
            }
        }
    }
}