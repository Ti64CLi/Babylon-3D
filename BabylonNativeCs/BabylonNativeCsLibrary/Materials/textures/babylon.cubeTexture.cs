using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class CubeTexture: BaseTexture {
public string url;
public dynamic coordinatesMode=BABYLON.Texture.CUBIC_MODE;
private bool _noMipmap;
private string[] _extensions;
private Matrix _textureMatrix;
public CubeTexture(string rootUrl, Scene scene, string[] extensions, bool noMipmap) {
base(scene);
this.name=rootUrl;
this.url=rootUrl;
this._noMipmap=noMipmap;
this.hasAlpha=false;
this._texture=this._getFromCache(rootUrl, noMipmap);
if (!extensions) 
{
extensions=new Array<object>();
}
this._extensions=extensions;
if (!this._texture) 
{
if (!scene.useDelayedTextureLoading) 
{
this._texture=scene.getEngine().createCubeTexture(rootUrl, scene, extensions, noMipmap);
}
else 
{
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_NOTLOADED;
}
}
this.isCube=true;
this._textureMatrix=BABYLON.Matrix.Identity();
}
public virtual CubeTexture clone() {
var newTexture = new BABYLON.CubeTexture(this.url, this.getScene(), this._extensions, this._noMipmap);
newTexture.level=this.level;
newTexture.wrapU=this.wrapU;
newTexture.wrapV=this.wrapV;
newTexture.coordinatesIndex=this.coordinatesIndex;
newTexture.coordinatesMode=this.coordinatesMode;
return newTexture;
}
public virtual void delayLoad() {
if (this.delayLoadState!=BABYLON.Engine.DELAYLOADSTATE_NOTLOADED) 
{
return;
}
this.delayLoadState=BABYLON.Engine.DELAYLOADSTATE_LOADED;
this._texture=this._getFromCache(this.url, this._noMipmap);
if (!this._texture) 
{
this._texture=this.getScene().getEngine().createCubeTexture(this.url, this.getScene(), this._extensions);
}
}
public virtual Matrix getReflectionTextureMatrix() {
return this._textureMatrix;
}
}
}
