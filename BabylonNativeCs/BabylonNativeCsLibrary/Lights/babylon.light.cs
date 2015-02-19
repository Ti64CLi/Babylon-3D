// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.light.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class Light : Node, IAnimatable
    {
        /// <summary>
        /// </summary>
        public Array<string> _excludedMeshesIds = new Array<string>();

        /// <summary>
        /// </summary>
        public ShadowGenerator _shadowGenerator;

        /// <summary>
        /// </summary>
        public Color3 diffuse = new Color3(1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        public Array<AbstractMesh> excludedMeshes = new Array<AbstractMesh>();

        /// <summary>
        /// </summary>
        public double intensity = 1.0;

        /// <summary>
        /// </summary>
        public double range = double.MaxValue;

        /// <summary>
        /// </summary>
        public Color3 specular = new Color3(1.0, 1.0, 1.0);

        /// <summary>
        /// </summary>
        private Matrix _parentedWorldMatrix;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public Light(string name, Scene scene)
            : base(name, scene)
        {
            scene.lights.Add(this);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix _getWorldMatrix()
        {
            return Matrix.Identity();
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            if (this._shadowGenerator != null)
            {
                this._shadowGenerator.dispose();
                this._shadowGenerator = null;
            }

            var index = this.getScene().lights.IndexOf(this);
            this.getScene().lights.RemoveAt(index);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual ShadowGenerator getShadowGenerator()
        {
            return this._shadowGenerator;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Matrix getWorldMatrix()
        {
            this._currentRenderId = this.getScene().getRenderId();
            var worldMatrix = this._getWorldMatrix();
            if (this.parent != null)
            {
                if (this._parentedWorldMatrix == null)
                {
                    this._parentedWorldMatrix = Matrix.Identity();
                }

                worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._parentedWorldMatrix);
                return this._parentedWorldMatrix;
            }

            return worldMatrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
        /// <param name="uniformName0">
        /// </param>
        /// <param name="uniformName1">
        /// </param>
        public virtual void transferToEffect(Effect effect, string uniformName0 = null, string uniformName1 = null)
        {
        }

        public new Array<Animation> animations
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public Array<IAnimatable> getAnimatables()
        {
            throw new System.NotImplementedException();
        }

        public void markAsDirty(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public IAnimatableProperty this[string subPropertyName]
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public object value
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}