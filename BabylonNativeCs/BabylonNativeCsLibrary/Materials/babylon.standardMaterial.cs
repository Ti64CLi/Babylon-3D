// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.standardMaterial.cs" company="">
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
    public partial class StandardMaterial : Material
    {
        /// <summary>
        /// </summary>
        public static bool AmbientTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool BumpTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool DiffuseTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool EmissiveTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool OpacityTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool ReflectionTextureEnabled = true;

        /// <summary>
        /// </summary>
        public static bool SpecularTextureEnabled = true;

        /// <summary>
        /// </summary>
        public Color3 ambientColor = new Color3(0, 0, 0);

        /// <summary>
        /// </summary>
        public BaseTexture ambientTexture;

        /// <summary>
        /// </summary>
        public BaseTexture bumpTexture;

        /// <summary>
        /// </summary>
        public Color3 diffuseColor = new Color3(1, 1, 1);

        /// <summary>
        /// </summary>
        public BaseTexture diffuseTexture;

        /// <summary>
        /// </summary>
        public Color3 emissiveColor = new Color3(0, 0, 0);

        /// <summary>
        /// </summary>
        public BaseTexture emissiveTexture;

        /// <summary>
        /// </summary>
        public BaseTexture opacityTexture;

        /// <summary>
        /// </summary>
        public BaseTexture reflectionTexture;

        /// <summary>
        /// </summary>
        public Color3 specularColor = new Color3(1, 1, 1);

        /// <summary>
        /// </summary>
        public double specularPower = 64;

        /// <summary>
        /// </summary>
        public BaseTexture specularTexture;

        /// <summary>
        /// </summary>
        public bool useAlphaFromDiffuseTexture = false;

        /// <summary>
        /// </summary>
        private readonly Color3 _baseColor = new Color3();

        /// <summary>
        /// </summary>
        private string _cachedDefines;

        /// <summary>
        /// </summary>
        private readonly Color3 _globalAmbientColor = new Color3(0, 0, 0);

        /// <summary>
        /// </summary>
        private int _renderId;

        /// <summary>
        /// </summary>
        private readonly SmartArray<RenderTargetTexture> _renderTargets = new SmartArray<RenderTargetTexture>(16);

        /// <summary>
        /// </summary>
        private readonly Color3 _scaledDiffuse = new Color3();

        /// <summary>
        /// </summary>
        private readonly Color3 _scaledSpecular = new Color3();

        /// <summary>
        /// </summary>
        private Matrix _worldViewProjectionMatrix = Matrix.Zero();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public StandardMaterial(string name, Scene scene)
            : base(name, scene)
        {
            this.getRenderTargetTextures = () =>
                {
                    this._renderTargets.reset();
                    if (this.reflectionTexture != null && this.reflectionTexture.isRenderTarget)
                    {
                        this._renderTargets.Add((RenderTargetTexture)this.reflectionTexture);
                    }

                    return this._renderTargets;
                };
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        /// <param name="mesh">
        /// </param>
        public override void bind(Matrix world, Mesh mesh)
        {
            var scene = this.getScene();
            this._baseColor.copyFrom(this.diffuseColor);
            this.bindOnlyWorldMatrix(world);
            this._effect.setMatrix("viewProjection", scene.getTransformMatrix());
            if (mesh.skeleton != null && mesh.isVerticesDataPresent(VertexBufferKind.MatricesIndicesKind)
                && mesh.isVerticesDataPresent(VertexBufferKind.MatricesWeightsKind))
            {
                this._effect.setMatrices("mBones", mesh.skeleton.getTransformMatrices());
            }

            Tools.Log("diffuseTexture - test");
            if (this.diffuseTexture != null && DiffuseTextureEnabled)
            {
                Tools.Log("diffuseTexture - setTexture, diffuseSampler");

                this._effect.setTexture("diffuseSampler", this.diffuseTexture);

                Tools.Log("diffuseTexture - vDiffuseInfos");

                this._effect.setFloat2("vDiffuseInfos", this.diffuseTexture.coordinatesIndex, this.diffuseTexture.level);
                this._effect.setMatrix("diffuseMatrix", this.diffuseTexture.getTextureMatrix());
                this._baseColor.copyFromFloats(1, 1, 1);
            }

            if (this.ambientTexture != null && AmbientTextureEnabled)
            {
                this._effect.setTexture("ambientSampler", this.ambientTexture);
                this._effect.setFloat2("vAmbientInfos", this.ambientTexture.coordinatesIndex, this.ambientTexture.level);
                this._effect.setMatrix("ambientMatrix", this.ambientTexture.getTextureMatrix());
            }

            if (this.opacityTexture != null && OpacityTextureEnabled)
            {
                this._effect.setTexture("opacitySampler", this.opacityTexture);
                this._effect.setFloat2("vOpacityInfos", this.opacityTexture.coordinatesIndex, this.opacityTexture.level);
                this._effect.setMatrix("opacityMatrix", this.opacityTexture.getTextureMatrix());
            }

            if (this.reflectionTexture != null && ReflectionTextureEnabled)
            {
                if (this.reflectionTexture.isCube)
                {
                    this._effect.setTexture("reflectionCubeSampler", this.reflectionTexture);
                }
                else
                {
                    this._effect.setTexture("reflection2DSampler", this.reflectionTexture);
                }

                this._effect.setMatrix("reflectionMatrix", this.reflectionTexture.getReflectionTextureMatrix());
                this._effect.setFloat3(
                    "vReflectionInfos", this.reflectionTexture.coordinatesMode, this.reflectionTexture.level, this.reflectionTexture.isCube ? 1 : 0);
            }

            if (this.emissiveTexture != null && EmissiveTextureEnabled)
            {
                this._effect.setTexture("emissiveSampler", this.emissiveTexture);
                this._effect.setFloat2("vEmissiveInfos", this.emissiveTexture.coordinatesIndex, this.emissiveTexture.level);
                this._effect.setMatrix("emissiveMatrix", this.emissiveTexture.getTextureMatrix());
            }

            if (this.specularTexture != null && SpecularTextureEnabled)
            {
                this._effect.setTexture("specularSampler", this.specularTexture);
                this._effect.setFloat2("vSpecularInfos", this.specularTexture.coordinatesIndex, this.specularTexture.level);
                this._effect.setMatrix("specularMatrix", this.specularTexture.getTextureMatrix());
            }

            if (this.bumpTexture != null && scene.getEngine().getCaps().standardDerivatives && BumpTextureEnabled)
            {
                this._effect.setTexture("bumpSampler", this.bumpTexture);
                this._effect.setFloat2("vBumpInfos", this.bumpTexture.coordinatesIndex, this.bumpTexture.level);
                this._effect.setMatrix("bumpMatrix", this.bumpTexture.getTextureMatrix());
            }

            scene.ambientColor.multiplyToRef(this.ambientColor, this._globalAmbientColor);
            this._effect.setVector3("vEyePosition", scene.activeCamera.position);
            this._effect.setColor3("vAmbientColor", this._globalAmbientColor);
            this._effect.setColor4("vDiffuseColor", this._baseColor, this.alpha * mesh.visibility);
            this._effect.setColor4("vSpecularColor", this.specularColor, this.specularPower);
            this._effect.setColor3("vEmissiveColor", this.emissiveColor);
            if (scene.lightsEnabled)
            {
                var lightIndex = 0;
                for (var index = 0; index < scene.lights.Length; index++)
                {
                    var light = scene.lights[index];
                    if (!light.isEnabled())
                    {
                        continue;
                    }

                    if (mesh != null && light.excludedMeshes.IndexOf(mesh) != -1)
                    {
                        continue;
                    }

                    if (light is PointLight)
                    {
                        light.transferToEffect(this._effect, "vLightData" + lightIndex);
                    }
                    else if (light is DirectionalLight)
                    {
                        light.transferToEffect(this._effect, "vLightData" + lightIndex);
                    }
                    else if (light is SpotLight)
                    {
                        light.transferToEffect(this._effect, "vLightData" + lightIndex, "vLightDirection" + lightIndex);
                    }
                    else if (light is HemisphericLight)
                    {
                        light.transferToEffect(this._effect, "vLightData" + lightIndex, "vLightGround" + lightIndex);
                    }

                    light.diffuse.scaleToRef(light.intensity, this._scaledDiffuse);
                    light.specular.scaleToRef(light.intensity, this._scaledSpecular);
                    this._effect.setColor4("vLightDiffuse" + lightIndex, this._scaledDiffuse, light.range);
                    this._effect.setColor3("vLightSpecular" + lightIndex, this._scaledSpecular);
                    var shadowGenerator = light.getShadowGenerator();
                    if (mesh.receiveShadows && shadowGenerator != null)
                    {
                        this._effect.setMatrix("lightMatrix" + lightIndex, shadowGenerator.getTransformMatrix());
                        this._effect.setTexture("shadowSampler" + lightIndex, shadowGenerator.getShadowMap());
                        this._effect.setFloat("darkness" + lightIndex, shadowGenerator.getDarkness());
                    }

                    lightIndex++;
                    if (lightIndex == maxSimultaneousLights)
                    {
                        break;
                    }
                }
            }

            if (scene.clipPlane != null)
            {
                var clipPlane = scene.clipPlane;
                this._effect.setFloat4("vClipPlane", clipPlane.normal.x, clipPlane.normal.y, clipPlane.normal.z, clipPlane.d);
            }

            if (scene.fogMode != Scene.FOGMODE_NONE || this.reflectionTexture != null)
            {
                this._effect.setMatrix("view", scene.getViewMatrix());
            }

            if (scene.fogMode != Scene.FOGMODE_NONE)
            {
                this._effect.setFloat4("vFogInfos", scene.fogMode, scene.fogStart, scene.fogEnd, scene.fogDensity);
                this._effect.setColor3("vFogColor", scene.fogColor);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public override void bindOnlyWorldMatrix(Matrix world)
        {
            this._effect.setMatrix("world", world);
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual StandardMaterial clone(string name)
        {
            var newStandardMaterial = new StandardMaterial(name, this.getScene());
            newStandardMaterial.checkReadyOnEveryCall = this.checkReadyOnEveryCall;
            newStandardMaterial.alpha = this.alpha;
            newStandardMaterial.wireframe = this.wireframe;
            newStandardMaterial.backFaceCulling = this.backFaceCulling;
            if (this.diffuseTexture != null)
            {
                newStandardMaterial.diffuseTexture = this.diffuseTexture.clone();
            }

            if (this.ambientTexture != null)
            {
                newStandardMaterial.ambientTexture = this.ambientTexture.clone();
            }

            if (this.opacityTexture != null)
            {
                newStandardMaterial.opacityTexture = this.opacityTexture.clone();
            }

            if (this.reflectionTexture != null)
            {
                newStandardMaterial.reflectionTexture = this.reflectionTexture.clone();
            }

            if (this.emissiveTexture != null)
            {
                newStandardMaterial.emissiveTexture = this.emissiveTexture.clone();
            }

            if (this.specularTexture != null)
            {
                newStandardMaterial.specularTexture = this.specularTexture.clone();
            }

            if (this.bumpTexture != null)
            {
                newStandardMaterial.bumpTexture = this.bumpTexture.clone();
            }

            newStandardMaterial.ambientColor = this.ambientColor.clone();
            newStandardMaterial.diffuseColor = this.diffuseColor.clone();
            newStandardMaterial.specularColor = this.specularColor.clone();
            newStandardMaterial.specularPower = this.specularPower;
            newStandardMaterial.emissiveColor = this.emissiveColor.clone();
            return newStandardMaterial;
        }

        /// <summary>
        /// </summary>
        /// <param name="forceDisposeEffect">
        /// </param>
        public override void dispose(bool forceDisposeEffect = false)
        {
            if (this.diffuseTexture != null)
            {
                this.diffuseTexture.dispose();
            }

            if (this.ambientTexture != null)
            {
                this.ambientTexture.dispose();
            }

            if (this.opacityTexture != null)
            {
                this.opacityTexture.dispose();
            }

            if (this.reflectionTexture != null)
            {
                this.reflectionTexture.dispose();
            }

            if (this.emissiveTexture != null)
            {
                this.emissiveTexture.dispose();
            }

            if (this.specularTexture != null)
            {
                this.specularTexture.dispose();
            }

            if (this.bumpTexture != null)
            {
                this.bumpTexture.dispose();
            }

            base.dispose(forceDisposeEffect);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override BaseTexture getAlphaTestTexture()
        {
            return this.diffuseTexture;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Array<IAnimatable> getAnimatables()
        {
            var results = new Array<IAnimatable>();
            if (this.diffuseTexture != null && this.diffuseTexture.animations != null && this.diffuseTexture.animations.Length > 0)
            {
                results.Add(this.diffuseTexture);
            }

            if (this.ambientTexture != null && this.ambientTexture.animations != null && this.ambientTexture.animations.Length > 0)
            {
                results.Add(this.ambientTexture);
            }

            if (this.opacityTexture != null && this.opacityTexture.animations != null && this.opacityTexture.animations.Length > 0)
            {
                results.Add(this.opacityTexture);
            }

            if (this.reflectionTexture != null && this.reflectionTexture.animations != null && this.reflectionTexture.animations.Length > 0)
            {
                results.Add(this.reflectionTexture);
            }

            if (this.emissiveTexture != null && this.emissiveTexture.animations != null && this.emissiveTexture.animations.Length > 0)
            {
                results.Add(this.emissiveTexture);
            }

            if (this.specularTexture != null && this.specularTexture.animations != null && this.specularTexture.animations.Length > 0)
            {
                results.Add(this.specularTexture);
            }

            if (this.bumpTexture != null && this.bumpTexture.animations != null && this.bumpTexture.animations.Length > 0)
            {
                results.Add(this.bumpTexture);
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="useInstances">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool isReady(AbstractMesh mesh = null, bool useInstances = false)
        {
            if (this.checkReadyOnlyOnce)
            {
                if (this._wasPreviouslyReady)
                {
                    return true;
                }
            }

            var scene = this.getScene();
            if (!this.checkReadyOnEveryCall)
            {
                if (this._renderId == scene.getRenderId())
                {
                    return true;
                }
            }

            var engine = scene.getEngine();
            var defines = new Array<string>();
            var optionalDefines = new Array<string>();
            if (scene.texturesEnabled)
            {
                if (this.diffuseTexture != null && DiffuseTextureEnabled)
                {
                    if (!this.diffuseTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define DIFFUSE");
                    }
                }

                if (this.ambientTexture != null && AmbientTextureEnabled)
                {
                    if (!this.ambientTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define AMBIENT");
                    }
                }

                if (this.opacityTexture != null && OpacityTextureEnabled)
                {
                    if (!this.opacityTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define OPACITY");
                        if (this.opacityTexture.getAlphaFromRGB)
                        {
                            defines.Add("#define OPACITYRGB");
                        }
                    }
                }

                if (this.reflectionTexture != null && ReflectionTextureEnabled)
                {
                    if (!this.reflectionTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define REFLECTION");
                    }
                }

                if (this.emissiveTexture != null && EmissiveTextureEnabled)
                {
                    if (!this.emissiveTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define EMISSIVE");
                    }
                }

                if (this.specularTexture != null && SpecularTextureEnabled)
                {
                    if (!this.specularTexture.isReady())
                    {
                        return false;
                    }
                    else
                    {
                        defines.Add("#define SPECULAR");
                        optionalDefines.Add(defines[defines.Length - 1]);
                    }
                }
            }

            if (scene.getEngine().getCaps().standardDerivatives && this.bumpTexture != null && BumpTextureEnabled)
            {
                if (!this.bumpTexture.isReady())
                {
                    return false;
                }
                else
                {
                    defines.Add("#define BUMP");
                    optionalDefines.Add(defines[defines.Length - 1]);
                }
            }

            if (scene.clipPlane != null)
            {
                defines.Add("#define CLIPPLANE");
            }

            if (engine.getAlphaTesting())
            {
                defines.Add("#define ALPHATEST");
            }

            if (this._shouldUseAlphaFromDiffuseTexture())
            {
                defines.Add("#define ALPHAFROMDIFFUSE");
            }

            if (scene.fogMode != Scene.FOGMODE_NONE)
            {
                defines.Add("#define FOG");
                optionalDefines.Add(defines[defines.Length - 1]);
            }

            var shadowsActivated = false;
            var lightIndex = 0;
            if (scene.lightsEnabled)
            {
                for (var index = 0; index < scene.lights.Length; index++)
                {
                    var light = scene.lights[index];
                    if (!light.isEnabled())
                    {
                        continue;
                    }

                    if (light._excludedMeshesIds.Length > 0)
                    {
                        for (var excludedIndex = 0; excludedIndex < light._excludedMeshesIds.Length; excludedIndex++)
                        {
                            var excludedMesh = scene.getMeshByID(light._excludedMeshesIds[excludedIndex]);
                            if (excludedMesh != null)
                            {
                                light.excludedMeshes.Add(excludedMesh);
                            }
                        }

                        light._excludedMeshesIds = new Array<string>();
                    }

                    if (mesh != null && light.excludedMeshes.IndexOf(mesh) != -1)
                    {
                        continue;
                    }

                    defines.Add("#define LIGHT" + lightIndex);
                    if (lightIndex > 0)
                    {
                        optionalDefines.Add(defines[defines.Length - 1]);
                    }

                    string type;
                    if (light is SpotLight)
                    {
                        type = "#define SPOTLIGHT" + lightIndex;
                    }
                    else if (light is HemisphericLight)
                    {
                        type = "#define HEMILIGHT" + lightIndex;
                    }
                    else
                    {
                        type = "#define POINTDIRLIGHT" + lightIndex;
                    }

                    defines.Add(type);
                    if (lightIndex > 0)
                    {
                        optionalDefines.Add(defines[defines.Length - 1]);
                    }

                    var shadowGenerator = light.getShadowGenerator();
                    if (mesh != null && mesh.receiveShadows && shadowGenerator != null)
                    {
                        defines.Add("#define SHADOW" + lightIndex);
                        if (lightIndex > 0)
                        {
                            optionalDefines.Add(defines[defines.Length - 1]);
                        }

                        if (!shadowsActivated)
                        {
                            defines.Add("#define SHADOWS");
                            shadowsActivated = true;
                        }

                        if (shadowGenerator.useVarianceShadowMap)
                        {
                            defines.Add("#define SHADOWVSM" + lightIndex);
                            if (lightIndex > 0)
                            {
                                optionalDefines.Add(defines[defines.Length - 1]);
                            }
                        }

                        if (shadowGenerator.usePoissonSampling)
                        {
                            defines.Add("#define SHADOWPCF" + lightIndex);
                            if (lightIndex > 0)
                            {
                                optionalDefines.Add(defines[defines.Length - 1]);
                            }
                        }
                    }

                    lightIndex++;
                    if (lightIndex == maxSimultaneousLights)
                    {
                        break;
                    }
                }
            }

            var attribs = new Array<string>(VertexBuffer.PositionKind, VertexBuffer.NormalKind);
            if (mesh != null)
            {
                if (mesh.isVerticesDataPresent(VertexBufferKind.UVKind))
                {
                    attribs.Add(VertexBuffer.UVKind);
                    defines.Add("#define UV1");
                }

                if (mesh.isVerticesDataPresent(VertexBufferKind.UV2Kind))
                {
                    attribs.Add(VertexBuffer.UV2Kind);
                    defines.Add("#define UV2");
                }

                if (mesh.isVerticesDataPresent(VertexBufferKind.ColorKind))
                {
                    attribs.Add(VertexBuffer.ColorKind);
                    defines.Add("#define VERTEXCOLOR");
                }

                if (mesh.skeleton != null && mesh.isVerticesDataPresent(VertexBufferKind.MatricesIndicesKind)
                    && mesh.isVerticesDataPresent(VertexBufferKind.MatricesWeightsKind))
                {
                    attribs.Add(VertexBuffer.MatricesIndicesKind);
                    attribs.Add(VertexBuffer.MatricesWeightsKind);
                    defines.Add("#define BONES");
                    defines.Add("#define BonesPerMesh " + (mesh.skeleton.bones.Length + 1));
                    defines.Add("#define BONES4");
                    optionalDefines.Add(defines[defines.Length - 1]);
                }

                if (useInstances)
                {
                    defines.Add("#define INSTANCES");
                    attribs.Add("world0");
                    attribs.Add("world1");
                    attribs.Add("world2");
                    attribs.Add("world3");
                }
            }

            var join = defines.Concat("\n");
            if (this._cachedDefines != join)
            {
                this._cachedDefines = join;
                var shaderName = "default";
                if (!scene.getEngine().getCaps().standardDerivatives)
                {
                    shaderName = "legacydefault";
                }

                this._effect = scene.getEngine()
                                    .createEffect(
                                        new EffectBaseName { baseName = shaderName }, 
                                        attribs, 
                                        new Array<string>(
                                            "world", 
                                            "view", 
                                            "viewProjection", 
                                            "vEyePosition", 
                                            "vLightsType", 
                                            "vAmbientColor", 
                                            "vDiffuseColor", 
                                            "vSpecularColor", 
                                            "vEmissiveColor", 
                                            "vLightData0", 
                                            "vLightDiffuse0", 
                                            "vLightSpecular0", 
                                            "vLightDirection0", 
                                            "vLightGround0", 
                                            "lightMatrix0", 
                                            "vLightData1", 
                                            "vLightDiffuse1", 
                                            "vLightSpecular1", 
                                            "vLightDirection1", 
                                            "vLightGround1", 
                                            "lightMatrix1", 
                                            "vLightData2", 
                                            "vLightDiffuse2", 
                                            "vLightSpecular2", 
                                            "vLightDirection2", 
                                            "vLightGround2", 
                                            "lightMatrix2", 
                                            "vLightData3", 
                                            "vLightDiffuse3", 
                                            "vLightSpecular3", 
                                            "vLightDirection3", 
                                            "vLightGround3", 
                                            "lightMatrix3", 
                                            "vFogInfos", 
                                            "vFogColor", 
                                            "vDiffuseInfos", 
                                            "vAmbientInfos", 
                                            "vOpacityInfos", 
                                            "vReflectionInfos", 
                                            "vEmissiveInfos", 
                                            "vSpecularInfos", 
                                            "vBumpInfos", 
                                            "mBones", 
                                            "vClipPlane", 
                                            "diffuseMatrix", 
                                            "ambientMatrix", 
                                            "opacityMatrix", 
                                            "reflectionMatrix", 
                                            "emissiveMatrix", 
                                            "specularMatrix", 
                                            "bumpMatrix", 
                                            "darkness0", 
                                            "darkness1", 
                                            "darkness2", 
                                            "darkness3"), 
                                        new Array<string>(
                                            "diffuseSampler", 
                                            "ambientSampler", 
                                            "opacitySampler", 
                                            "reflectionCubeSampler", 
                                            "reflection2DSampler", 
                                            "emissiveSampler", 
                                            "specularSampler", 
                                            "bumpSampler", 
                                            "shadowSampler0", 
                                            "shadowSampler1", 
                                            "shadowSampler2", 
                                            "shadowSampler3"), 
                                        join, 
                                        optionalDefines, 
                                        this.onCompiled, 
                                        this.onError);
            }

            if (!this._effect.isReady())
            {
                return false;
            }

            this._renderId = scene.getRenderId();
            this._wasPreviouslyReady = true;
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool needAlphaBlending()
        {
            return (this.alpha < 1.0) || (this.opacityTexture != null) || this._shouldUseAlphaFromDiffuseTexture();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool needAlphaTesting()
        {
            return this.diffuseTexture != null && this.diffuseTexture.hasAlpha && !this.diffuseTexture.getAlphaFromRGB;
        }

        /// <summary>
        /// </summary>
        public override void unbind()
        {
            if (this.reflectionTexture != null && this.reflectionTexture.isRenderTarget)
            {
                this._effect.setTexture("reflection2DSampler", null);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        private bool _shouldUseAlphaFromDiffuseTexture()
        {
            return this.diffuseTexture != null && this.diffuseTexture.hasAlpha && this.useAlphaFromDiffuseTexture;
        }

        /// <summary>
        /// </summary>
        private const int maxSimultaneousLights = 4;
    }
}