using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Material : IAnimatable
    {
        public string id;
        public bool checkReadyOnEveryCall = true;
        public bool checkReadyOnlyOnce = false;
        public string state = "";
        public double alpha = 1.0;
        public bool wireframe = false;
        public bool backFaceCulling = true;
        public System.Action<Effect> onCompiled;
        public System.Action<Effect, string> onError;
        public System.Action onDispose;
        public System.Func<SmartArray<RenderTargetTexture>> getRenderTargetTextures;
        public Effect _effect;
        public bool _wasPreviouslyReady = false;
        private Scene _scene;
        public string name;
        public Material(string name, Scene scene, bool doNotAdd = false)
        {
            this.id = name;
            this._scene = scene;
            if (!doNotAdd)
            {
                scene.materials.push(this);
            }
        }
        public virtual Array<Animation> animations
        {
            get
            {
                return null;
            }
        }
        public virtual bool isReady(AbstractMesh mesh = null, bool useInstances = false)
        {
            return true;
        }
        public virtual Effect getEffect()
        {
            return this._effect;
        }
        public virtual Scene getScene()
        {
            return this._scene;
        }
        public virtual bool needAlphaBlending()
        {
            return (this.alpha < 1.0);
        }
        public virtual bool needAlphaTesting()
        {
            return false;
        }
        public virtual BaseTexture getAlphaTestTexture()
        {
            return null;
        }
        public virtual void trackCreation(System.Action<Effect> onCompiled, System.Action<Effect, string> onError) { }
        public virtual void _preBind()
        {
            var engine = this._scene.getEngine();
            engine.enableEffect(this._effect);
            engine.setState(this.backFaceCulling);
        }
        public virtual void bind(Matrix world, Mesh mesh) { }
        public virtual void bindOnlyWorldMatrix(Matrix world) { }
        public virtual void unbind() { }
        public virtual void dispose(bool forceDisposeEffect = false)
        {
            var index = this._scene.materials.indexOf(this);
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

        public IAnimatableProperty this[string subPropertyName]
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
    }
}