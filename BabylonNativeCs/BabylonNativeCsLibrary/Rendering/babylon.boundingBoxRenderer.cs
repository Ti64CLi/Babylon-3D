using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class BoundingBoxRenderer {
dynamic frontColor=new BABYLON.Color3(1, 1, 1);
dynamic backColor=new BABYLON.Color3(0.1, 0.1, 0.1);
dynamic showBackLines=true;
dynamic renderList=new BABYLON.SmartArray(32);
private Scene _scene;
private ShaderMaterial _colorShader;
private VertexBuffer _vb;
private WebGLBuffer _ib;
public BoundingBoxRenderer(Scene scene) {
this._scene=scene;
this._colorShader=new ShaderMaterial("colorShade", scene, "colo", new dynamic());
var engine = this._scene.getEngine();
var boxdata = BABYLON.VertexData.CreateBox(1.0);
this._vb=new BABYLON.VertexBuffer(engine, boxdata.positions, BABYLON.VertexBuffer.PositionKind, false);
this._ib=engine.createIndexBuffer(new Array<object>());
}
public virtual void reset() {
this.renderList.reset();
}
public virtual void render() {
if (this.renderList.length==0||!this._colorShader.isReady()) 
{
return;
}
var engine = this._scene.getEngine();
engine.setDepthWrite(false);
this._colorShader._preBind();
for (var boundingBoxIndex = 0;boundingBoxIndex<this.renderList.length;boundingBoxIndex++) 
{
var boundingBox = this.renderList.data[boundingBoxIndex];
var min = boundingBox.minimum;
var max = boundingBox.maximum;
var diff = max.subtract(min);
var median = min.add(diff.scale(0.5));
var worldMatrix = BABYLON.Matrix.Scaling(diff.x, diff.y, diff.z).multiply(BABYLON.Matrix.Translation(median.x, median.y, median.z)).multiply(boundingBox.getWorldMatrix());
engine.bindBuffers(this._vb.getBuffer(), this._ib, new Array<object>(), 3*4, this._colorShader.getEffect());
if (this.showBackLines) 
{
engine.setDepthFunctionToGreaterOrEqual();
this._colorShader.setColor3("colo", this.backColor);
this._colorShader.bind(worldMatrix);
engine.draw(false, 0, 24);
}
engine.setDepthFunctionToLess();
this._colorShader.setColor3("colo", this.frontColor);
this._colorShader.bind(worldMatrix);
engine.draw(false, 0, 24);
}
this._colorShader.unbind();
engine.setDepthFunctionToLessOrEqual();
engine.setDepthWrite(true);
}
public virtual void dispose() {
this._colorShader.dispose();
this._vb.dispose();
this._scene.getEngine()._releaseBuffer(this._ib);
}
}
}
