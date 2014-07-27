using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
public class Particle {
dynamic position=BABYLON.Vector3.Zero();
dynamic direction=BABYLON.Vector3.Zero();
dynamic color=new BABYLON.Color4(0, 0, 0, 0);
dynamic colorStep=new BABYLON.Color4(0, 0, 0, 0);
dynamic lifeTime=1.0;
dynamic age=0;
dynamic size=0;
dynamic angle=0;
dynamic angularSpeed=0;
}
}
