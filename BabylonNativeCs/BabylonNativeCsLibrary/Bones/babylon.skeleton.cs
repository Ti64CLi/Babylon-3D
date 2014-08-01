using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Skeleton {
        public Array < Bone > bones = new Array < Bone > ();
        private Scene _scene;
        private bool _isDirty = true;
        private Float32Array _transformMatrices;
        private Array < IAnimatable > _animatables;
        private BABYLON.Matrix _identity = Matrix.Identity();
        public string name;
        public string id;
        public Skeleton(string name, string id, Scene scene) {
            this.bones = new Array < object > ();
            this._scene = scene;
            scene.skeletons.push(this);
        }
        public virtual Float32Array getTransformMatrices() {
            return this._transformMatrices;
        }
        public virtual void _markAsDirty() {
            this._isDirty = true;
        }
        public virtual void prepare() {
            if (!this._isDirty) {
                return;
            }
            if (!this._transformMatrices || this._transformMatrices.Length != 16 * (this.bones.Length + 1)) {
                this._transformMatrices = new Float32Array(16 * (this.bones.Length + 1));
            }
            for (var index = 0; index < this.bones.Length; index++) {
                var bone = this.bones[index];
                var parentBone = bone.getParent();
                if (parentBone) {
                    bone.getLocalMatrix().multiplyToRef(parentBone.getWorldMatrix(), bone.getWorldMatrix());
                } else {
                    bone.getWorldMatrix().copyFrom(bone.getLocalMatrix());
                }
                bone.getInvertedAbsoluteTransform().multiplyToArray(bone.getWorldMatrix(), this._transformMatrices, index * 16);
            }
            this._identity.copyToArray(this._transformMatrices, this.bones.Length * 16);
            this._isDirty = false;
        }
        public virtual Array < IAnimatable > getAnimatables() {
            if (!this._animatables || this._animatables.Length != this.bones.Length) {
                this._animatables = new Array < object > ();
                for (var index = 0; index < this.bones.Length; index++) {
                    this._animatables.push(this.bones[index]);
                }
            }
            return this._animatables;
        }
        public virtual Skeleton clone(string name, string id) {
            var result = new BABYLON.Skeleton(name, id || name, this._scene);
            for (var index = 0; index < this.bones.Length; index++) {
                var source = this.bones[index];
                var parentBone = null;
                if (source.getParent()) {
                    var parentIndex = this.bones.indexOf(source.getParent());
                    parentBone = result.bones[parentIndex];
                }
                var bone = new BABYLON.Bone(source.name, result, parentBone, source.getBaseMatrix());
                BABYLON.Tools.DeepCopy(source.animations, bone.animations);
            }
            return result;
        }
    }
}