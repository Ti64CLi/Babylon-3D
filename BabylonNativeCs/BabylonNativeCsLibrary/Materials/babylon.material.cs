// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.material.cs" company="">
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
    public partial class Material : IAnimatable
    {
        /// <summary>
        /// </summary>
        public Effect _effect;

        /// <summary>
        /// </summary>
        public bool _wasPreviouslyReady = false;

        /// <summary>
        /// </summary>
        public double alpha = 1.0;

        /// <summary>
        /// </summary>
        public bool backFaceCulling = true;

        /// <summary>
        /// </summary>
        public bool checkReadyOnEveryCall = true;

        /// <summary>
        /// </summary>
        public bool checkReadyOnlyOnce = false;

        /// <summary>
        /// </summary>
        public Func<SmartArray<RenderTargetTexture>> getRenderTargetTextures;

        /// <summary>
        /// </summary>
        public string id;

        /// <summary>
        /// </summary>
        public string name;

        /// <summary>
        /// </summary>
        public Action<Effect> onCompiled;

        /// <summary>
        /// </summary>
        public System.Action onDispose;

        /// <summary>
        /// </summary>
        public Action<Effect, string> onError;

        /// <summary>
        /// </summary>
        public string state = string.Empty;

        /// <summary>
        /// </summary>
        public bool wireframe = false;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="doNotAdd">
        /// </param>
        public Material(string name, Scene scene, bool doNotAdd = false)
        {
            this.id = name;
            this.name = name;
            this._scene = scene;
            if (!doNotAdd)
            {
                scene.materials.Add(this);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="subPropertyName">
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <returns>
        /// </returns>
        public object this[string subPropertyName]
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
        public virtual Array<Animation> animations
        {
            get
            {
                return null;
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
        public virtual void _preBind()
        {
            var engine = this._scene.getEngine();
            engine.enableEffect(this._effect);
            engine.setState(this.backFaceCulling);
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        /// <param name="mesh">
        /// </param>
        public virtual void bind(Matrix world, Mesh mesh)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public virtual void bindOnlyWorldMatrix(Matrix world)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="forceDisposeEffect">
        /// </param>
        public virtual void dispose(bool forceDisposeEffect = false)
        {
            var index = this._scene.materials.IndexOf(this);
            this._scene.materials.RemoveAt(index);
            if (forceDisposeEffect && this._effect != null)
            {
                this._scene.getEngine()._releaseEffect(this._effect);
                this._effect = null;
            }

            if (this.onDispose != null)
            {
                this.onDispose();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual BaseTexture getAlphaTestTexture()
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public virtual Array<IAnimatable> getAnimatables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Effect getEffect()
        {
            return this._effect;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Scene getScene()
        {
            return this._scene;
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="useInstances">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isReady(AbstractMesh mesh = null, bool useInstances = false)
        {
            return true;
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
        /// <returns>
        /// </returns>
        public virtual bool needAlphaBlending()
        {
            return this.alpha < 1.0;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool needAlphaTesting()
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="onCompiled">
        /// </param>
        /// <param name="onError">
        /// </param>
        public virtual void trackCreation(Action<Effect> onCompiled, Action<Effect, string> onError)
        {
        }

        /// <summary>
        /// </summary>
        public virtual void unbind()
        {
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var material = obj as Material;
            if (material != null)
            {
                return material.name.Equals(name);
            }

            return base.Equals(obj);
        }
    }
}