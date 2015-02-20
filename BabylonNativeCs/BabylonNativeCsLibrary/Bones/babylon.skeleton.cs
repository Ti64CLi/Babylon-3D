// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.skeleton.cs" company="">
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
    public partial class Skeleton : IAnimatable
    {
        /// <summary>
        /// </summary>
        public Array<Bone> bones = new Array<Bone>();

        /// <summary>
        /// </summary>
        public string id;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        private Array<IAnimatable> _animatables;

        /// <summary>
        /// </summary>
        private readonly Matrix _identity = Matrix.Identity();

        /// <summary>
        /// </summary>
        private bool _isDirty = true;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private double[] _transformMatrices;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="id">
        /// </param>
        /// <param name="scene">
        /// </param>
        public Skeleton(string name, string id, Scene scene)
        {
            this.name = name;
            this.id = id;
            this.bones = new Array<Bone>();
            this._scene = scene;
            scene.skeletons.Add(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="subPropertyName">
        /// </param>
        /// <returns>
        /// </returns>
        public object this[string subPropertyName]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// </summary>
        public object value { get; set; }

        /// <summary>
        /// </summary>
        public Array<Animation> animations { get; set; }

        /// <summary>
        /// </summary>
        public void markAsDirty(string propertyName)
        {
            this._isDirty = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Skeleton clone(string name, string id)
        {
            var result = new Skeleton(name, id ?? name, this._scene);
            for (var index = 0; index < this.bones.Length; index++)
            {
                var source = this.bones[index];
                Bone parentBone = null;
                if (source.getParent() != null)
                {
                    var parentIndex = this.bones.IndexOf(source.getParent());
                    parentBone = result.bones[parentIndex];
                }

                var bone = new Bone(source.name, result, parentBone, source.getBaseMatrix());
                Tools.DeepCopy(source.animations, bone.animations);
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<IAnimatable> getAnimatables()
        {
            if (this._animatables == null || this._animatables.Length != this.bones.Length)
            {
                this._animatables = new Array<IAnimatable>();
                for (var index = 0; index < this.bones.Length; index++)
                {
                    this._animatables.Add(this.bones[index]);
                }
            }

            return this._animatables;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double[] getTransformMatrices()
        {
            return this._transformMatrices;
        }

        /// <summary>
        /// </summary>
        public virtual void prepare()
        {
            if (!this._isDirty)
            {
                return;
            }

            if (this._transformMatrices == null || this._transformMatrices.Length != 16 * (this.bones.Length + 1))
            {
                this._transformMatrices = new double[16 * (this.bones.Length + 1)];
            }

            for (var index = 0; index < this.bones.Length; index++)
            {
                var bone = this.bones[index];
                var parentBone = bone.getParent();
                if (parentBone != null)
                {
                    bone.getLocalMatrix().multiplyToRef(parentBone.getWorldMatrix(), bone.getWorldMatrix());
                }
                else
                {
                    bone.getWorldMatrix().copyFrom(bone.getLocalMatrix());
                }

                bone.getInvertedAbsoluteTransform().multiplyToArray(bone.getWorldMatrix(), this._transformMatrices, index * 16);
            }

            this._identity.copyToArray(this._transformMatrices, this.bones.Length * 16);
            this._isDirty = false;
        }
    }
}