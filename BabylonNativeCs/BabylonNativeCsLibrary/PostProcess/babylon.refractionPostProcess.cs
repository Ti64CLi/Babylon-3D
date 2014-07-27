using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class RefractionPostProcess: PostProcess {
private Texture _refRexture;
public Color3 color;
public float depth;
public float colorLevel;
public RefractionPostProcess(string name, string refractionTextureUrl, Color3 color, float depth, float colorLevel, float ratio, Camera camera, float samplingMode, Engine engine, bool reusable) {
base(name, "refractio", new Array<object>(), new Array<object>(), ratio, camera, samplingMode, engine, reusable);
this.onActivate=(Camera cam) => {
this._refRexture=this._refRexture||new BABYLON.Texture(refractionTextureUrl, cam.getScene());
}
;
this.onApply=(Effect effect) => {
effect.setColor3("baseColo", this.color);
effect.setFloat("dept", this.depth);
effect.setFloat("colorLeve", this.colorLevel);
effect.setTexture("refractionSample", this._refRexture);
}
;
}
public virtual void dispose(Camera camera) {
if (this._refRexture) 
{
this._refRexture.dispose();
}
base.dispose(camera);
}
}
}
