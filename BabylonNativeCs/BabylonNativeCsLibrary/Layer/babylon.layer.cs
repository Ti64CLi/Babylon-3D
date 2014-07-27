using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Layer {
public Texture texture;
public bool isBackground;
public Color4 color;
public Func<object> onDispose;
private Scene _scene;
private dynamic _vertexDeclaration=new Array<object>();
private dynamic _vertexStrideSize=2*4;
private WebGLBuffer _vertexBuffer;
private WebGLBuffer _indexBuffer;
private Effect _effect;
public string name;
public Layer(string name, string imgUrl, Scene scene, bool isBackground, Color4 color) {
this.texture=(imgUrl) ? new BABYLON.Texture(imgUrl, scene, true) : null;
this.isBackground=(isBackground==undefined) ? true : isBackground;
this.color=(color==undefined) ? new BABYLON.Color4(1, 1, 1, 1) : color;
this._scene=scene;
this._scene.layers.push(this);
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
this._effect=this._scene.getEngine().createEffect("laye", new Array<object>(), new Array<object>(), new Array<object>(), "\"");
}
public virtual void render() {
if (!this._effect.isReady()||!this.texture||!this.texture.isReady()) 
return;
var engine = this._scene.getEngine();
engine.enableEffect(this._effect);
engine.setState(false);
this._effect.setTexture("textureSample", this.texture);
this._effect.setMatrix("textureMatri", this.texture.getTextureMatrix());
this._effect.setFloat4("colo", this.color.r, this.color.g, this.color.b, this.color.a);
engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, this._effect);
engine.setAlphaMode(BABYLON.Engine.ALPHA_COMBINE);
engine.draw(true, 0, 6);
engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
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
if (this.texture) 
{
this.texture.dispose();
this.texture=null;
}
var index = this._scene.layers.indexOf(this);
this._scene.layers.splice(index, 1);
if (this.onDispose) 
{
this.onDispose();
}
}
}
}
