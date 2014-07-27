using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class BaseTexture {
public string name;
public dynamic delayLoadState=BABYLON.Engine.DELAYLOADSTATE_NONE;
public dynamic hasAlpha=false;
public dynamic getAlphaFromRGB=false;
public dynamic level=1;
public dynamic isCube=false;
public dynamic isRenderTarget=false;
public dynamic animations=new Array();
public Func<object> onDispose;
public dynamic coordinatesIndex=0;
public dynamic coordinatesMode=BABYLON.Texture.EXPLICIT_MODE;
public dynamic wrapU=BABYLON.Texture.WRAP_ADDRESSMODE;
public dynamic wrapV=BABYLON.Texture.WRAP_ADDRESSMODE;
public dynamic anisotropicFilteringLevel=4;
public float _cachedAnisotropicFilteringLevel;
private Scene _scene;
public WebGLTexture _texture;
public BaseTexture(Scene scene) {
this._scene=scene;
this._scene.textures.push(this);
}
public virtual Scene getScene() {
return this._scene;
}
public virtual Matrix getTextureMatrix() {
return null;
}
public virtual Matrix getReflectionTextureMatrix() {
return null;
}
public virtual WebGLTexture getInternalTexture() {
return this._texture;
}
public virtual bool isReady() {
if (this.delayLoadState==BABYLON.Engine.DELAYLOADSTATE_NOTLOADED) 
{
return true;
}
if (this._texture) 
{
return this._texture.isReady;
}
return false;
}
public virtual ISize getSize() {
if (this._texture._width) 
{
return new dynamic();
}
if (this._texture._size) 
{
return new dynamic();
}
return new dynamic();
}
public virtual ISize getBaseSize() {
if (!this.isReady()) 
return new dynamic();
if (this._texture._size) 
{
return new dynamic();
}
return new dynamic();
}
public virtual WebGLTexture _getFromCache(string url, bool noMipmap) {
var texturesCache = this._scene.getEngine().getLoadedTexturesCache();
for (var index = 0;index<texturesCache.length;index++) 
{
var texturesCacheEntry = texturesCache[index];
if (texturesCacheEntry.url==url&&texturesCacheEntry.noMipmap==noMipmap) 
{
texturesCacheEntry.references++;
return texturesCacheEntry;
}
}
return null;
}
public virtual void delayLoad() {
}
public virtual void releaseInternalTexture() {
if (!this._texture) 
{
return;
}
var texturesCache = this._scene.getEngine().getLoadedTexturesCache();
this._texture.references--;
if (this._texture.references==0) 
{
var index = texturesCache.indexOf(this._texture);
texturesCache.splice(index, 1);
this._scene.getEngine()._releaseTexture(this._texture);
this._texture = null;
}
}
public virtual BaseTexture clone() {
return null;
}
public virtual void dispose() {
var index = this._scene.textures.indexOf(this);
if (index>=0) 
{
this._scene.textures.splice(index, 1);
}
if (this._texture==undefined) 
{
return;
}
this.releaseInternalTexture();
if (this.onDispose) 
{
this.onDispose();
}
}
}
}
