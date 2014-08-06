// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.effect.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class Effect
    {
        /// <summary>
        /// </summary>
        public static Map<string, string> ShadersStore = new Map<string, string>();

        /// <summary>
        /// </summary>
        public string _key;

        /// <summary>
        /// </summary>
        public WebGLProgram _program;

        /// <summary>
        /// </summary>
        public string defines;

        /// <summary>
        /// </summary>
        public EffectBaseName name;

        /// <summary>
        /// </summary>
        public Action<Effect> onCompiled;

        /// <summary>
        /// </summary>
        public Action<Effect, string> onError;

        /// <summary>
        /// </summary>
        private Array<int> _attributeLocations;

        /// <summary>
        /// </summary>
        private readonly Array<string> _attributesNames;

        /// <summary>
        /// </summary>
        private string _compilationError = string.Empty;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private bool _isReady;

        /// <summary>
        /// </summary>
        private readonly Array<string> _samplers;

        /// <summary>
        /// </summary>
        private Array<WebGLUniformLocation> _uniforms;

        /// <summary>
        /// </summary>
        private readonly Array<string> _uniformsNames;

        /// <summary>
        /// </summary>
        private readonly Map<string, Array<double>> _valueCache = new Map<string, Array<double>>();

        /// <summary>
        /// </summary>
        private readonly Map<string, bool> _valueCacheBool = new Map<string, bool>();

        /// <summary>
        /// </summary>
        private readonly Map<string, double> _valueCacheDouble = new Map<string, double>();

        /// <summary>
        /// </summary>
        /// <param name="baseName">
        /// </param>
        /// <param name="attributesNames">
        /// </param>
        /// <param name="uniformsNames">
        /// </param>
        /// <param name="samplers">
        /// </param>
        /// <param name="engine">
        /// </param>
        /// <param name="defines">
        /// </param>
        /// <param name="optionalDefines">
        /// </param>
        /// <param name="onCompiled">
        /// </param>
        /// <param name="onError">
        /// </param>
        public Effect(
            EffectBaseName baseName, 
            Array<string> attributesNames, 
            Array<string> uniformsNames, 
            Array<string> samplers, 
            Engine engine, 
            string defines = null, 
            Array<string> optionalDefines = null, 
            Action<Effect> onCompiled = null, 
            Action<Effect, string> onError = null)
        {
            this._engine = engine;
            this.name = baseName;
            this.defines = defines;
            this._uniformsNames = uniformsNames.Append(samplers);
            this._samplers = samplers;
            this._attributesNames = attributesNames;
            this.onError = onError;
            this.onCompiled = onCompiled;
            string vertexSource;
            string fragmentSource;
            if (!string.IsNullOrEmpty(baseName.vertexElement))
            {
                vertexSource = Engine.document.getElementById(baseName.vertexElement).innerText;
                fragmentSource = Engine.document.getElementById(baseName.fragmentElement).innerText;
            }
            else
            {
                vertexSource = baseName.vertexElement ?? baseName.vertex ?? baseName.baseName;
                fragmentSource = baseName.fragmentElement ?? baseName.fragment ?? baseName.baseName;
            }

            this._loadVertexShader(
                vertexSource, 
                (vertexCode) =>
                    {
                        this._loadFragmentShader(
                            fragmentSource, (fragmentCode) => { this._prepareEffect(vertexCode, fragmentCode, attributesNames, defines, optionalDefines); });
                    });
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="texture">
        /// </param>
        public virtual void _bindTexture(string channel, WebGLTexture texture)
        {
            this._engine._bindTexture(this._samplers.IndexOf(channel), texture);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public virtual void _cacheFloat2(string uniformName, double x, double y)
        {
            if (this._valueCache[uniformName] == null)
            {
                this._valueCache[uniformName] = new Array<double>(x, y);
                return;
            }

            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        public virtual void _cacheFloat3(string uniformName, double x, double y, double z)
        {
            if (this._valueCache[uniformName] == null)
            {
                this._valueCache[uniformName] = new Array<double>(x, y, z);
                return;
            }

            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
            this._valueCache[uniformName][2] = z;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="w">
        /// </param>
        public virtual void _cacheFloat4(string uniformName, double x, double y, double z, double w)
        {
            if (this._valueCache[uniformName] == null)
            {
                this._valueCache[uniformName] = new Array<double>(x, y, z, w);
                return;
            }

            this._valueCache[uniformName][0] = x;
            this._valueCache[uniformName][1] = y;
            this._valueCache[uniformName][2] = z;
            this._valueCache[uniformName][3] = w;
        }

        /// <summary>
        /// </summary>
        /// <param name="fragment">
        /// </param>
        /// <param name="callback">
        /// </param>
        public virtual void _loadFragmentShader(HTMLElement fragment, Action<string> callback)
        {
            var fragmentCode = Tools.GetDOMTextContent(fragment);
            callback(fragmentCode);
        }

        /// <summary>
        /// </summary>
        /// <param name="fragment">
        /// </param>
        /// <param name="callback">
        /// </param>
        public virtual void _loadFragmentShader(object fragment, Action<string> callback)
        {
            var key = fragment + "PixelShader";
            if (ShadersStore[key] != null)
            {
                callback(ShadersStore[key]);
                return;
            }

            string fragmentShaderUrl;
            var fragmentString = fragment.ToString();
            if (fragmentString[0] == '.')
            {
                fragmentShaderUrl = fragmentString;
            }
            else
            {
                fragmentShaderUrl = Engine.ShadersRepository + fragment;
            }

            Tools.LoadFile(fragmentShaderUrl + ".fragment.fx", callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="vertex">
        /// </param>
        /// <param name="callback">
        /// </param>
        public virtual void _loadVertexShader(HTMLElement vertex, Action<string> callback)
        {
            var vertexCode = Tools.GetDOMTextContent(vertex);
            callback(vertexCode);
        }

        /// <summary>
        /// </summary>
        /// <param name="vertex">
        /// </param>
        /// <param name="callback">
        /// </param>
        public virtual void _loadVertexShader(object vertex, Action<string> callback)
        {
            var key = vertex + "VertexShader";
            if (ShadersStore[key] != null)
            {
                callback(ShadersStore[key]);
                return;
            }

            string vertexShaderUrl;
            var vertexString = vertex.ToString();
            if (vertexString[0] == '.')
            {
                vertexShaderUrl = vertexString;
            }
            else
            {
                vertexShaderUrl = Engine.ShadersRepository + vertex;
            }

            Tools.LoadFile(vertexShaderUrl + ".vertex.fx", callback);
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexSourceCode">
        /// </param>
        /// <param name="fragmentSourceCode">
        /// </param>
        /// <param name="attributesNames">
        /// </param>
        /// <param name="defines">
        /// </param>
        /// <param name="optionalDefines">
        /// </param>
        /// <param name="useFallback">
        /// </param>
        public virtual void _prepareEffect(
            string vertexSourceCode, 
            string fragmentSourceCode, 
            Array<string> attributesNames, 
            string defines, 
            Array<string> optionalDefines = null, 
            bool useFallback = false)
        {
            try
            {
                var engine = this._engine;
                this._program = engine.createShaderProgram(vertexSourceCode, fragmentSourceCode, defines);
                this._uniforms = engine.getUniforms(this._program, this._uniformsNames);
                this._attributeLocations = engine.getAttributes(this._program, attributesNames);
                for (var index = 0; index < this._samplers.Length; index++)
                {
                    var sampler = this.getUniform(this._samplers[index]);
                    if (sampler == null || sampler.Value == -1)
                    {
                        this._samplers.RemoveAt(index);
                        index--;
                    }
                }

                engine.bindSamplers(this);
                this._isReady = true;
                if (this.onCompiled != null)
                {
                    this.onCompiled(this);
                }
            }
            catch (Exception e)
            {
                if (!useFallback && optionalDefines != null)
                {
                    for (var index = 0; index < optionalDefines.Length; index++)
                    {
                        defines = defines.Replace(optionalDefines[index], string.Empty);
                    }

                    this._prepareEffect(vertexSourceCode, fragmentSourceCode, attributesNames, defines, optionalDefines, true);
                }
                else
                {
                    Tools.Error("Unable to compile effect: " + this.name);
                    Tools.Error("Defines: " + defines);
                    Tools.Error("Optional defines: " + optionalDefines);
                    Tools.Error("Error: " + e.Message);
                    this._compilationError = e.Message;
                    if (this.onError != null)
                    {
                        this.onError(this, this._compilationError);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual int getAttributeLocationByName(string name)
        {
            var index = this._attributesNames.IndexOf(name);
            return this._attributeLocations[index];
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<int> getAttributeLocations()
        {
            return this._attributeLocations;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getAttributesCount()
        {
            return this._attributeLocations.Length;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<string> getAttributesNames()
        {
            return this._attributesNames;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual string getCompilationError()
        {
            return this._compilationError;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual WebGLProgram getProgram()
        {
            return this._program;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<string> getSamplers()
        {
            return this._samplers;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLUniformLocation getUniform(string uniformName)
        {
            return this._uniforms[this._uniformsNames.IndexOf(uniformName)];
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual int getUniformIndex(string uniformName)
        {
            return this._uniformsNames.IndexOf(uniformName);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReady()
        {
            return this._isReady;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="array">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setArray(string uniformName, Array<double> array)
        {
            this._engine.setArray(this.getUniform(uniformName), array);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="_bool">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setBool(string uniformName, bool _bool)
        {
            if (this._valueCacheBool.ContainsKey(uniformName) && this._valueCacheBool[uniformName] == _bool)
            {
                return this;
            }

            this._valueCacheBool[uniformName] = _bool;
            this._engine.setBool(this.getUniform(uniformName), _bool ? 1 : 0);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="color3">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setColor3(string uniformName, Color3 color3)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == color3.r && this._valueCache[uniformName][1] == color3.g
                && this._valueCache[uniformName][2] == color3.b)
            {
                return this;
            }

            this._cacheFloat3(uniformName, color3.r, color3.g, color3.b);
            this._engine.setColor3(this.getUniform(uniformName), color3);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="color3">
        /// </param>
        /// <param name="alpha">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setColor4(string uniformName, Color3 color3, double alpha)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == color3.r && this._valueCache[uniformName][1] == color3.g
                && this._valueCache[uniformName][2] == color3.b && this._valueCache[uniformName][3] == alpha)
            {
                return this;
            }

            this._cacheFloat4(uniformName, color3.r, color3.g, color3.b, alpha);
            this._engine.setColor4(this.getUniform(uniformName), color3, alpha);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setFloat(string uniformName, double value)
        {
            if (this._valueCacheDouble.ContainsKey(uniformName) && this._valueCacheDouble[uniformName] == value)
            {
                return this;
            }

            this._valueCacheDouble[uniformName] = value;
            this._engine.setFloat(this.getUniform(uniformName), value);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setFloat2(string uniformName, double x, double y)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y)
            {
                return this;
            }

            this._cacheFloat2(uniformName, x, y);
            this._engine.setFloat2(this.getUniform(uniformName), x, y);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setFloat3(string uniformName, double x, double y, double z)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y
                && this._valueCache[uniformName][2] == z)
            {
                return this;
            }

            this._cacheFloat3(uniformName, x, y, z);
            this._engine.setFloat3(this.getUniform(uniformName), x, y, z);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="w">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setFloat4(string uniformName, double x, double y, double z, double w)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == x && this._valueCache[uniformName][1] == y
                && this._valueCache[uniformName][2] == z && this._valueCache[uniformName][3] == w)
            {
                return this;
            }

            this._cacheFloat4(uniformName, x, y, z, w);
            this._engine.setFloat4(this.getUniform(uniformName), x, y, z, w);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="matrices">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setMatrices(string uniformName, double[] matrices)
        {
            this._engine.setMatrices(this.getUniform(uniformName), ArrayConvert.AsFloat(matrices));
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="matrix">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setMatrix(string uniformName, Matrix matrix)
        {
            this._engine.setMatrix(this.getUniform(uniformName), matrix);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="texture">
        /// </param>
        public virtual void setTexture(string channel, BaseTexture texture)
        {
            this._engine.setTexture(this._samplers.IndexOf(channel), texture);
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="postProcess">
        /// </param>
        public virtual void setTextureFromPostProcess(string channel, PostProcess postProcess)
        {
            this._engine.setTextureFromPostProcess(this._samplers.IndexOf(channel), postProcess);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="vector2">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setVector2(string uniformName, Vector2 vector2)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == vector2.x && this._valueCache[uniformName][1] == vector2.y)
            {
                return this;
            }

            this._cacheFloat2(uniformName, vector2.x, vector2.y);
            this._engine.setFloat2(this.getUniform(uniformName), vector2.x, vector2.y);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniformName">
        /// </param>
        /// <param name="vector3">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect setVector3(string uniformName, Vector3 vector3)
        {
            if (this._valueCache[uniformName] != null && this._valueCache[uniformName][0] == vector3.x && this._valueCache[uniformName][1] == vector3.y
                && this._valueCache[uniformName][2] == vector3.z)
            {
                return this;
            }

            this._cacheFloat3(uniformName, vector3.x, vector3.y, vector3.z);
            this._engine.setFloat3(this.getUniform(uniformName), vector3.x, vector3.y, vector3.z);
            return this;
        }
    }
}