using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class ShaderMaterial: Material {
        private string _shaderPath;
        private object _options;
        private Array < Texture > _textures = new Array < Texture > ();
        private Array < double > _floats = new Array < double > ();
        private dynamic _floatsArrays = new {};
        private Array < Color3 > _colors3 = new Array < Color3 > ();
        private Array < Color4 > _colors4 = new Array < Color4 > ();
        private Array < Vector2 > _vectors2 = new Array < Vector2 > ();
        private Array < Vector3 > _vectors3 = new Array < Vector3 > ();
        private Array < Matrix > _matrices = new Array < Matrix > ();
        private BABYLON.Matrix _cachedWorldViewMatrix = new BABYLON.Matrix();
        public ShaderMaterial(string name, Scene scene, string shaderPath, object options): base(name, scene) {
            this._shaderPath = shaderPath;
            options.needAlphaBlending = options.needAlphaBlending || false;
            options.needAlphaTesting = options.needAlphaTesting || false;
            options.attributes = options.attributes || new Array < object > ("position", "normal", "uv");
            options.uniforms = options.uniforms || new Array < object > ("worldViewProjection");
            options.samplers = options.samplers || new Array < object > ();
            this._options = options;
        }
        public virtual bool needAlphaBlending() {
            return this._options.needAlphaBlending;
        }
        public virtual bool needAlphaTesting() {
            return this._options.needAlphaTesting;
        }
        private void _checkUniform(object uniformName) {
            if (this._options.uniforms.indexOf(uniformName) == -1) {
                this._options.uniforms.push(uniformName);
            }
        }
        public virtual ShaderMaterial setTexture(string name, Texture texture) {
            if (this._options.samplers.indexOf(name) == -1) {
                this._options.samplers.push(name);
            }
            this._textures[name] = texture;
            return this;
        }
        public virtual ShaderMaterial setFloat(string name, double value) {
            this._checkUniform(name);
            this._floats[name] = value;
            return this;
        }
        public virtual ShaderMaterial setFloats(string name, Array < double > value) {
            this._checkUniform(name);
            this._floatsArrays[name] = value;
            return this;
        }
        public virtual ShaderMaterial setColor3(string name, Color3 value) {
            this._checkUniform(name);
            this._colors3[name] = value;
            return this;
        }
        public virtual ShaderMaterial setColor4(string name, Color4 value) {
            this._checkUniform(name);
            this._colors4[name] = value;
            return this;
        }
        public virtual ShaderMaterial setVector2(string name, Vector2 value) {
            this._checkUniform(name);
            this._vectors2[name] = value;
            return this;
        }
        public virtual ShaderMaterial setVector3(string name, Vector3 value) {
            this._checkUniform(name);
            this._vectors3[name] = value;
            return this;
        }
        public virtual ShaderMaterial setMatrix(string name, Matrix value) {
            this._checkUniform(name);
            this._matrices[name] = value;
            return this;
        }
        public virtual bool isReady() {
            var engine = this.getScene().getEngine();
            this._effect = engine.createEffect(this._shaderPath, this._options.attributes, this._options.uniforms, this._options.samplers, "", null, this.onCompiled, this.onError);
            if (!this._effect.isReady()) {
                return false;
            }
            return true;
        }
        public virtual void bind(Matrix world) {
            if (this._options.uniforms.indexOf("world") != -1) {
                this._effect.setMatrix("world", world);
            }
            if (this._options.uniforms.indexOf("view") != -1) {
                this._effect.setMatrix("view", this.getScene().getViewMatrix());
            }
            if (this._options.uniforms.indexOf("worldView") != -1) {
                world.multiplyToRef(this.getScene().getViewMatrix(), this._cachedWorldViewMatrix);
                this._effect.setMatrix("worldView", this._cachedWorldViewMatrix);
            }
            if (this._options.uniforms.indexOf("projection") != -1) {
                this._effect.setMatrix("projection", this.getScene().getProjectionMatrix());
            }
            if (this._options.uniforms.indexOf("worldViewProjection") != -1) {
                this._effect.setMatrix("worldViewProjection", world.multiply(this.getScene().getTransformMatrix()));
            }
            foreach(var name in this._textures) {
                this._effect.setTexture(name, this._textures[name]);
            }
            foreach(name in this._floats) {
                this._effect.setFloat(name, this._floats[name]);
            }
            foreach(name in this._floatsArrays) {
                this._effect.setArray(name, this._floatsArrays[name]);
            }
            foreach(name in this._colors3) {
                this._effect.setColor3(name, this._colors3[name]);
            }
            foreach(name in this._colors4) {
                var color = this._colors4[name];
                this._effect.setFloat4(name, color.r, color.g, color.b, color.a);
            }
            foreach(name in this._vectors2) {
                this._effect.setVector2(name, this._vectors2[name]);
            }
            foreach(name in this._vectors3) {
                this._effect.setVector3(name, this._vectors3[name]);
            }
            foreach(name in this._matrices) {
                this._effect.setMatrix(name, this._matrices[name]);
            }
        }
        public virtual void dispose(bool forceDisposeEffect = false) {
            foreach(var name in this._textures) {
                this._textures[name].dispose();
            }
            this._textures = new Array < object > ();
            base.dispose(forceDisposeEffect);
        }
    }
}