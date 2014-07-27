using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Material {
public string id;
public dynamic checkReadyOnEveryCall=true;
public dynamic checkReadyOnlyOnce=false;
public dynamic state="\"";
public dynamic alpha=1.0;
public dynamic wireframe=false;
public dynamic backFaceCulling=true;
public Func<Effect, object> onCompiled;
public Func<Effect, string, object> onException;
public Func<object> onDispose;
public Func<SmartArray<RenderTargetTexture>> getRenderTargetTextures;
public Effect _effect;
public dynamic _wasPreviouslyReady=false;
private Scene _scene;
public string name;
public Material(string name, Scene scene, bool doNotAdd) {
this.id=name;
this._scene=scene;
if (!doNotAdd) 
{
scene.materials.push(this);
}
}
public virtual bool isReady(AbstractMesh mesh, bool useInstances) {
return true;
}
public virtual Effect getEffect() {
return this._effect;
}
public virtual Scene getScene() {
return this._scene;
}
public virtual bool needAlphaBlending() {
return (this.alpha<1.0);
}
public virtual bool needAlphaTesting() {
return false;
}
public virtual BaseTexture getAlphaTestTexture() {
return null;
}
public virtual void trackCreation(Func<Effect, object> onCompiled, Func<Effect, string, object> onException) {
}
public virtual void _preBind() {
var engine = this._scene.getEngine();
engine.enableEffect(this._effect);
engine.setState(this.backFaceCulling);
}
public virtual void bind(Matrix world, Mesh mesh) {
}
public virtual void bindOnlyWorldMatrix(Matrix world) {
}
public virtual void unbind() {
}
public virtual void dispose(bool forceDisposeEffect) {
var index = this._scene.materials.indexOf(this);
this._scene.materials.splice(index, 1);
if (forceDisposeEffect&&this._effect) 
{
this._scene.getEngine()._releaseEffect(this._effect);
this._effect=null;
}
if (this.onDispose) 
{
this.onDispose();
}
}
}
}
