using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class LensFlare {
public Color3 color;
public Texture texture;
private LensFlareSystem _system;
public float size;
public float position;
public LensFlare(float size, float position, dynamic color, string imgUrl, LensFlareSystem system) {
this.color=color||new BABYLON.Color3(1, 1, 1);
this.texture=(imgUrl) ? new BABYLON.Texture(imgUrl, system.getScene(), true) : null;
this._system=system;
system.lensFlares.push(this);
}
public dynamic dispose=() {
if (this.texture) 
{
this.texture.dispose();
}
var index = this._system.lensFlares.indexOf(this);
this._system.lensFlares.splice(index, 1);
}
;
}
}
