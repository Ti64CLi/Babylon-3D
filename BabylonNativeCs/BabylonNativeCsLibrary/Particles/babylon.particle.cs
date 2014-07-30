using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Particle {
        public BABYLON.Vector3 position = BABYLON.Vector3.Zero();
        public BABYLON.Vector3 direction = BABYLON.Vector3.Zero();
        public BABYLON.Color4 color = new BABYLON.Color4(0, 0, 0, 0);
        public BABYLON.Color4 colorStep = new BABYLON.Color4(0, 0, 0, 0);
        public double lifeTime = 1.0;
        public double age = 0;
        public double size = 0;
        public double angle = 0;
        public double angularSpeed = 0;
    }
}