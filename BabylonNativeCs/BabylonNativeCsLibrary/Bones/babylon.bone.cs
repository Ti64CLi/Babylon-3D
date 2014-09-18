// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.bone.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public partial class Bone : IAnimatable
    {
        /// <summary>
        /// </summary>
        public Array<Animation> animations = new Array<Animation>();

        /// <summary>
        /// </summary>
        public Array<Bone> children = new Array<Bone>();

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        private readonly Matrix _absoluteTransform = new Matrix();

        /// <summary>
        /// </summary>
        private readonly Matrix _baseMatrix;

        /// <summary>
        /// </summary>
        private readonly Matrix _invertedAbsoluteTransform = new Matrix();

        /// <summary>
        /// </summary>
        private Matrix _matrix;

        /// <summary>
        /// </summary>
        private readonly Bone _parent;

        /// <summary>
        /// </summary>
        private readonly Skeleton _skeleton;

        /// <summary>
        /// </summary>
        private readonly Matrix _worldTransform = new Matrix();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="skeleton">
        /// </param>
        /// <param name="parentBone">
        /// </param>
        /// <param name="matrix">
        /// </param>
        public Bone(string name, Skeleton skeleton, Bone parentBone, Matrix matrix)
        {
            this.name = name;
            this._skeleton = skeleton;
            this._matrix = matrix;
            this._baseMatrix = matrix;
            skeleton.bones.Add(this);
            if (parentBone != null)
            {
                this._parent = parentBone;
                parentBone.children.Add(this);
            }
            else
            {
                this._parent = null;
            }

            this._updateDifferenceMatrix();
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
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

        /// <summary>
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Array<IAnimatable> getAnimatables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getBaseMatrix()
        {
            return this._baseMatrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getInvertedAbsoluteTransform()
        {
            return this._invertedAbsoluteTransform;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getLocalMatrix()
        {
            return this._matrix;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Bone getParent()
        {
            return this._parent;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getWorldMatrix()
        {
            return this._worldTransform;
        }

        /// <summary>
        /// </summary>
        public virtual void markAsDirty()
        {
            this._skeleton._markAsDirty();
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void markAsDirty(string propertyName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="matrix">
        /// </param>
        public virtual void updateMatrix(Matrix matrix)
        {
            this._matrix = matrix;
            this._skeleton._markAsDirty();
            this._updateDifferenceMatrix();
        }

        /// <summary>
        /// </summary>
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
    }
}