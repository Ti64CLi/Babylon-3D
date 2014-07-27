using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class PostProcessRenderPass {
private bool _enabled=true;
private Mesh[] _renderList;
private RenderTargetTexture _renderTexture;
private Scene _scene;
private float _refCount=0;
public string _name;
public PostProcessRenderPass(Scene scene, string name, float size, Mesh[] renderList, Func<object> beforeRender, Func<object> afterRender) {
this._name=name;
this._renderTexture=new RenderTargetTexture(name, size, scene);
this.setRenderList(renderList);
this._renderTexture.onBeforeRender=beforeRender;
this._renderTexture.onAfterRender=afterRender;
this._scene=scene;
}
public virtual float _incRefCount() {
if (this._refCount==0) 
{
this._scene.customRenderTargets.push(this._renderTexture);
}
return ++this._refCount;
}
public virtual float _decRefCount() {
this._refCount--;
if (this._refCount<=0) 
{
this._scene.customRenderTargets.splice(this._scene.customRenderTargets.indexOf(this._renderTexture), 1);
}
return this._refCount;
}
public virtual void _update() {
this.setRenderList(this._renderList);
}
public virtual void setRenderList(Mesh[] renderList) {
this._renderTexture.renderList=renderList;
}
public virtual RenderTargetTexture getRenderTexture() {
return this._renderTexture;
}
}
}
