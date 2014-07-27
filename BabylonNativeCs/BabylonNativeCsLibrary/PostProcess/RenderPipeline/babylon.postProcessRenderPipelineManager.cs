using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class PostProcessRenderPipelineManager {
private PostProcessRenderPipeline[] _renderPipelines;
public PostProcessRenderPipelineManager() {
this._renderPipelines=new Array<object>();
}
public virtual void addPipeline(PostProcessRenderPipeline renderPipeline) {
this._renderPipelines[renderPipeline._name]=renderPipeline;
}
public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Camera cameras, bool unique) {
}
public virtual void attachCamerasToRenderPipeline(string renderPipelineName, Camera[] cameras, bool unique) {
}
public virtual void attachCamerasToRenderPipeline(string renderPipelineName, object cameras, bool unique) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.attachCameras(cameras, unique);
}
public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Camera cameras) {
}
public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, Camera[] cameras) {
}
public virtual void detachCamerasFromRenderPipeline(string renderPipelineName, object cameras) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.detachCameras(cameras);
}
public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras) {
}
public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera[] cameras) {
}
public virtual void enableEffectInPipeline(string renderPipelineName, string renderEffectName, object cameras) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.enableEffect(renderEffectName, cameras);
}
public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera cameras) {
}
public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, Camera[] cameras) {
}
public virtual void disableEffectInPipeline(string renderPipelineName, string renderEffectName, object cameras) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.disableEffect(renderEffectName, cameras);
}
public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Camera cameras) {
}
public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, Camera[] cameras) {
}
public virtual void enableDisplayOnlyPassInPipeline(string renderPipelineName, string passName, object cameras) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.enableDisplayOnlyPass(passName, cameras);
}
public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Camera cameras) {
}
public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, Camera[] cameras) {
}
public virtual void disableDisplayOnlyPassInPipeline(string renderPipelineName, object cameras) {
var renderPipeline = this._renderPipelines[renderPipelineName];
if (!renderPipeline) 
{
return;
}
renderPipeline.disableDisplayOnlyPass(cameras);
}
public virtual void update() {
foreach (var renderPipelineName in this._renderPipelines) 
{
this._renderPipelines[renderPipelineName]._update();
}
}
}
}
