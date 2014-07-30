using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class MultiMaterial: Material {
        public Array < Material > subMaterials = new Array < Material > ();
        public MultiMaterial(string name, Scene scene): base(name, scene, true) {
            scene.multiMaterials.push(this);
        }
        public virtual void getSubMaterial(object index) {
            if (index < 0 || index >= this.subMaterials.Length) {
                return this.getScene().defaultMaterial;
            }
            return this.subMaterials[index];
        }
        public virtual bool isReady(AbstractMesh mesh = null) {
            for (var index = 0; index < this.subMaterials.Length; index++) {
                var subMaterial = this.subMaterials[index];
                if (subMaterial) {
                    if (!this.subMaterials[index].isReady(mesh)) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}