using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class PostProcessManager {
private Scene _scene;
private WebGLBuffer _indexBuffer;
dynamic _vertexDeclaration=new Array<object>();
dynamic _vertexStrideSize=2*4;
private WebGLBuffer _vertexBuffer;
public PostProcessManager(Scene scene) {
this._scene=scene;
var vertices = new Array<object>();
vertices.push(1, 1);
vertices.push(-1, 1);
vertices.push(-1, -1);
vertices.push(1, -1);
this._vertexBuffer=scene.getEngine().createVertexBuffer(vertices);
var indices = new Array<object>();
indices.push(0);
indices.push(1);
indices.push(2);
indices.push(0);
indices.push(2);
indices.push(3);
this._indexBuffer=scene.getEngine().createIndexBuffer(indices);
}
public virtual bool _prepareFrame(WebGLTexture sourceTexture) {
var postProcesses = this._scene.activeCamera._postProcesses;
var postProcessesTakenIndices = this._scene.activeCamera._postProcessesTakenIndices;
if (postProcessesTakenIndices.length==0||!this._scene.postProcessesEnabled) 
{
return false;
}
postProcesses[this._scene.activeCamera._postProcessesTakenIndices[0]].activate(this._scene.activeCamera, sourceTexture);
return true;
}
public virtual void _finalizeFrame(bool doNotPresent, WebGLTexture targetTexture) {
var postProcesses = this._scene.activeCamera._postProcesses;
var postProcessesTakenIndices = this._scene.activeCamera._postProcessesTakenIndices;
if (postProcessesTakenIndices.length==0||!this._scene.postProcessesEnabled) 
{
return;
}
var engine = this._scene.getEngine();
for (var index = 0;index<postProcessesTakenIndices.length;index++) 
{
if (index<postProcessesTakenIndices.length-1) 
{
postProcesses[postProcessesTakenIndices[index+1]].activate(this._scene.activeCamera);
}
else 
{
if (targetTexture) 
{
engine.bindFramebuffer(targetTexture);
}
else 
{
engine.restoreDefaultFramebuffer();
}
}
if (doNotPresent) 
{
break;
}
var effect = postProcesses[postProcessesTakenIndices[index]].apply();
if (effect) 
{
engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, effect);
engine.draw(true, 0, 6);
}
}
engine.setDepthBuffer(true);
engine.setDepthWrite(true);
}
public virtual void dispose() {
if (this._vertexBuffer) 
{
this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
this._vertexBuffer=null;
}
if (this._indexBuffer) 
{
this._scene.getEngine()._releaseBuffer(this._indexBuffer);
this._indexBuffer=null;
}
}
}
}
