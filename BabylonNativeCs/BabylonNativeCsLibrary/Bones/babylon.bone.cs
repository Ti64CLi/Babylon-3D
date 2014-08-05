using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Bone : IAnimatable
    {
        public Array<Bone> children = new Array<Bone>();
        public Array<Animation> animations = new Array<Animation>();
        private Skeleton _skeleton;
        private Matrix _matrix;
        private Matrix _baseMatrix;
        private BABYLON.Matrix _worldTransform = new BABYLON.Matrix();
        private BABYLON.Matrix _absoluteTransform = new BABYLON.Matrix();
        private BABYLON.Matrix _invertedAbsoluteTransform = new BABYLON.Matrix();
        private Bone _parent;
        public string name;
        public Bone(string name, Skeleton skeleton, Bone parentBone, Matrix matrix)
        {
            this.name = name;
            this._skeleton = skeleton;
            this._matrix = matrix;
            this._baseMatrix = matrix;
            skeleton.bones.push(this);
            if (parentBone != null)
            {
                this._parent = parentBone;
                parentBone.children.push(this);
            }
            else
            {
                this._parent = null;
            }
            this._updateDifferenceMatrix();
        }
        public virtual Bone getParent()
        {
            return this._parent;
        }
        public virtual Matrix getLocalMatrix()
        {
            return this._matrix;
        }
        public virtual Matrix getBaseMatrix()
        {
            return this._baseMatrix;
        }
        public virtual Matrix getWorldMatrix()
        {
            return this._worldTransform;
        }
        public virtual Matrix getInvertedAbsoluteTransform()
        {
            return this._invertedAbsoluteTransform;
        }
        public virtual Matrix getAbsoluteMatrix()
        {
            var matrix = this._matrix.clone();
            var parent = this._parent;
            while (parent != null)
            {
                matrix = matrix.multiply(parent.getLocalMatrix());
                parent = parent.getParent();
            }
            return matrix;
        }
        public virtual void updateMatrix(Matrix matrix)
        {
            this._matrix = matrix;
            this._skeleton._markAsDirty();
            this._updateDifferenceMatrix();
        }
        private void _updateDifferenceMatrix()
        {
            if (this._parent != null)
            {
                this._matrix.multiplyToRef(this._parent._absoluteTransform, this._absoluteTransform);
            }
            else
            {
                this._absoluteTransform.copyFrom(this._matrix);
            }
            this._absoluteTransform.invertToRef(this._invertedAbsoluteTransform);
            for (var index = 0; index < this.children.Length; index++)
            {
                this.children[index]._updateDifferenceMatrix();
            }
        }
        public virtual void markAsDirty()
        {
            this._skeleton._markAsDirty();
        }

        public IAnimatableProperty this[string propertyName]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        Array<Animation> IAnimatable.animations
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Array<IAnimatable> getAnimatables()
        {
            throw new NotImplementedException();
        }

        public void markAsDirty(string propertyName)
        {
            throw new NotImplementedException();
        }


        public object value
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}