using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class GroundMesh: Mesh {
        public bool generateOctree = false;
        private BABYLON.Matrix _worldInverse = new BABYLON.Matrix();
        public int _subdivisions;
        public GroundMesh(string name, Scene scene): base(name, scene) {}
        public virtual double subdivisions {
            get {
                return this._subdivisions;
            }
        }
        public virtual void optimize(double chunksCount) {
            this.subdivide(this._subdivisions);
            this.createOrUpdateSubmeshesOctree(32);
        }
        public virtual double getHeightAtCoordinates(double x, double z) {
            var ray = new BABYLON.Ray(new BABYLON.Vector3(x, this.getBoundingInfo().boundingBox.maximumWorld.y + 1, z), new BABYLON.Vector3(0, -1, 0));
            this.getWorldMatrix().invertToRef(this._worldInverse);
            ray = BABYLON.Ray.Transform(ray, this._worldInverse);
            var pickInfo = this.intersects(ray);
            if (pickInfo.hit) {
                return pickInfo.pickedPoint.y;
            }
            return 0;
        }
    }
}