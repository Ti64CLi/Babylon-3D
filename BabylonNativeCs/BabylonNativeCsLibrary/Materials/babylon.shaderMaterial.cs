using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class ShaderMaterial : Material
    {
        private string _shaderPath;
        private ShaderMaterialOptions _options;
        private Map<string, Texture> _textures = new Map<string, Texture>();
        private Map<string, double> _floats = new Map<string, double>();
        private Map<string, Array<double>> _floatsArrays = new Map<string, Array<double>>();
        private Map<string, Color3> _colors3 = new Map<string, Color3>();
        private Map<string, Color4> _colors4 = new Map<string, Color4>();
        private Map<string, Vector2> _vectors2 = new Map<string, Vector2>();
        private Map<string, Vector3> _vectors3 = new Map<string, Vector3>();
        private Map<string, Matrix> _matrices = new Map<string, Matrix>();
        private BABYLON.Matrix _cachedWorldViewMatrix = new BABYLON.Matrix();
        public ShaderMaterial(string name, Scene scene, string shaderPath, ShaderMaterialOptions options)
            : base(name, scene)
        {
            this._shaderPath = shaderPath;
            options.attributes = options.attributes ?? new Array<string>("position", "normal", "uv");
            options.uniforms = options.uniforms ?? new Array<string>("worldViewProjection");
            options.samplers = options.samplers ?? new Array<string>();
            this._options = options;
        }
        public virtual bool needAlphaBlending()
        {
            return this._options.needAlphaBlending;
        }
        public virtual bool needAlphaTesting()
        {
            return this._options.needAlphaTesting;
        }
        private void _checkUniform(string uniformName)
        {
            if (this._options.uniforms.indexOf(uniformName) == -1)
            {
                this._options.uniforms.push(uniformName);
            }
        }
        public virtual ShaderMaterial setTexture(string name, Texture texture)
        {
            if (this._options.samplers.indexOf(name) == -1)
            {
                this._options.samplers.push(name);
            }
            this._textures[name] = texture;
            return this;
        }
        public virtual ShaderMaterial setFloat(string name, double value)
        {
            this._checkUniform(name);
            this._floats[name] = value;
            return this;
        }
        public virtual ShaderMaterial setFloats(string name, Array<double> value)
        {
            this._checkUniform(name);
            this._floatsArrays[name] = value;
            return this;
        }
        public virtual ShaderMaterial setColor3(string name, Color3 value)
        {
            this._checkUniform(name);
            this._colors3[name] = value;
            return this;
        }
        public virtual ShaderMaterial setColor4(string name, Color4 value)
        {
            this._checkUniform(name);
            this._colors4[name] = value;
            return this;
        }
        public virtual ShaderMaterial setVector2(string name, Vector2 value)
        {
            this._checkUniform(name);
            this._vectors2[name] = value;
            return this;
        }
        public virtual ShaderMaterial setVector3(string name, Vector3 value)
        {
            this._checkUniform(name);
            this._vectors3[name] = value;
            return this;
        }
        public virtual ShaderMaterial setMatrix(string name, Matrix value)
        {
            this._checkUniform(name);
            this._matrices[name] = value;
            return this;
        }
        public virtual bool isReady()
        {
            var engine = this.getScene().getEngine();
            this._effect = engine.createEffect(new EffectBaseName { baseName = this._shaderPath }, this._options.attributes, this._options.uniforms, this._options.samplers, "", null, this.onCompiled, this.onError);
            if (!this._effect.isReady())
            {
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
            foreach(var name in this._textures.Keys) {
                this._effect.setTexture(name, this._textures[name]);
            }
            foreach (var name in this._floats.Keys)
            {
                this._effect.setFloat(name, this._floats[name]);
            }
            foreach (var name in this._floatsArrays.Keys)
            {
                this._effect.setArray(name, this._floatsArrays[name]);
            }
            foreach (var name in this._colors3.Keys)
            {
                this._effect.setColor3(name, this._colors3[name]);
            }
            foreach (var name in this._colors4.Keys)
            {
                var color = this._colors4[name];
                this._effect.setFloat4(name, color.r, color.g, color.b, color.a);
            }
            foreach (var name in this._vectors2.Keys)
            {
                this._effect.setVector2(name, this._vectors2[name]);
            }
            foreach (var name in this._vectors3.Keys)
            {
                this._effect.setVector3(name, this._vectors3[name]);
            }
            foreach (var name in this._matrices.Keys)
            {
                this._effect.setMatrix(name, this._matrices[name]);
            }
        }
        public override void dispose(bool forceDisposeEffect = false)
        {
            foreach (var name in this._textures.Keys)
            {
                this._textures[name].dispose();
            }
            this._textures = new Map<string, Texture>();
            base.dispose(forceDisposeEffect);
        }
    }
}