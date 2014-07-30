using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class StandardMaterial: Material {
        public BaseTexture diffuseTexture;
        public BaseTexture ambientTexture;
        public BaseTexture opacityTexture;
        public BaseTexture reflectionTexture;
        public BaseTexture emissiveTexture;
        public BaseTexture specularTexture;
        public BaseTexture bumpTexture;
        public BABYLON.Color3 ambientColor = new BABYLON.Color3(0, 0, 0);
        public BABYLON.Color3 diffuseColor = new BABYLON.Color3(1, 1, 1);
        public BABYLON.Color3 specularColor = new BABYLON.Color3(1, 1, 1);
        public float specularPower = 64;
        public BABYLON.Color3 emissiveColor = new BABYLON.Color3(0, 0, 0);
        public bool useAlphaFromDiffuseTexture = false;
        private null _cachedDefines = null;
        private BABYLON.SmartArray < RenderTargetTexture > _renderTargets = new BABYLON.SmartArray < RenderTargetTexture > (16);
        private null _worldViewProjectionMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Color3 _globalAmbientColor = new BABYLON.Color3(0, 0, 0);
        private BABYLON.Color3 _baseColor = new BABYLON.Color3();
        private BABYLON.Color3 _scaledDiffuse = new BABYLON.Color3();
        private BABYLON.Color3 _scaledSpecular = new BABYLON.Color3();
        private float _renderId;
        public StandardMaterial(string name, Scene scene): base(name, scene) {
            this.getRenderTargetTextures = () => {
                this._renderTargets.reset();
                if (this.reflectionTexture && this.reflectionTexture.isRenderTarget) {
                    this._renderTargets.push(this.reflectionTexture);
                }
                return this._renderTargets;
            };
        }
        void maxSimultaneousLights4;
        public virtual bool needAlphaBlending() {
            return (this.alpha < 1.0) || (this.opacityTexture != null) || this._shouldUseAlphaFromDiffuseTexture();
        }
        public virtual bool needAlphaTesting() {
            return this.diffuseTexture != null && this.diffuseTexture.hasAlpha && !this.diffuseTexture.getAlphaFromRGB;
        }
        private virtual bool _shouldUseAlphaFromDiffuseTexture() {
            return this.diffuseTexture != null && this.diffuseTexture.hasAlpha && this.useAlphaFromDiffuseTexture;
        }
        public virtual BaseTexture getAlphaTestTexture() {
            return this.diffuseTexture;
        }
        public virtual bool isReady(AbstractMesh mesh = null, bool useInstances = false) {
            if (this.checkReadyOnlyOnce) {
                if (this._wasPreviouslyReady) {
                    return true;
                }
            }
            var scene = this.getScene();
            if (!this.checkReadyOnEveryCall) {
                if (this._renderId == scene.getRenderId()) {
                    return true;
                }
            }
            var engine = scene.getEngine();
            var defines = new Array < object > ();
            var optionalDefines = new Array < string > ();
            if (scene.texturesEnabled) {
                if (this.diffuseTexture && BABYLON.StandardMaterial.DiffuseTextureEnabled) {
                    if (!this.diffuseTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define DIFFUS");
                    }
                }
                if (this.ambientTexture && BABYLON.StandardMaterial.AmbientTextureEnabled) {
                    if (!this.ambientTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define AMBIEN");
                    }
                }
                if (this.opacityTexture && BABYLON.StandardMaterial.OpacityTextureEnabled) {
                    if (!this.opacityTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define OPACIT");
                        if (this.opacityTexture.getAlphaFromRGB) {
                            defines.push("#define OPACITYRG");
                        }
                    }
                }
                if (this.reflectionTexture && BABYLON.StandardMaterial.ReflectionTextureEnabled) {
                    if (!this.reflectionTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define REFLECTIO");
                    }
                }
                if (this.emissiveTexture && BABYLON.StandardMaterial.EmissiveTextureEnabled) {
                    if (!this.emissiveTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define EMISSIV");
                    }
                }
                if (this.specularTexture && BABYLON.StandardMaterial.SpecularTextureEnabled) {
                    if (!this.specularTexture.isReady()) {
                        return false;
                    } else {
                        defines.push("#define SPECULA");
                        optionalDefines.push(defines[defines.Length - 1]);
                    }
                }
            }
            if (scene.getEngine().getCaps().standardDerivatives && this.bumpTexture && BABYLON.StandardMaterial.BumpTextureEnabled) {
                if (!this.bumpTexture.isReady()) {
                    return false;
                } else {
                    defines.push("#define BUM");
                    optionalDefines.push(defines[defines.Length - 1]);
                }
            }
            if (scene.clipPlane) {
                defines.push("#define CLIPPLAN");
            }
            if (engine.getAlphaTesting()) {
                defines.push("#define ALPHATES");
            }
            if (this._shouldUseAlphaFromDiffuseTexture()) {
                defines.push("#define ALPHAFROMDIFFUS");
            }
            if (scene.fogMode != BABYLON.Scene.FOGMODE_NONE) {
                defines.push("#define FO");
                optionalDefines.push(defines[defines.Length - 1]);
            }
            var shadowsActivated = false;
            var lightIndex = 0;
            if (scene.lightsEnabled) {
                for (var index = 0; index < scene.lights.Length; index++) {
                    var light = scene.lights[index];
                    if (!light.isEnabled()) {
                        continue;
                    }
                    if (light._excludedMeshesIds.Length > 0) {
                        for (var excludedIndex = 0; excludedIndex < light._excludedMeshesIds.Length; excludedIndex++) {
                            var excludedMesh = scene.getMeshByID(light._excludedMeshesIds[excludedIndex]);
                            if (excludedMesh) {
                                light.excludedMeshes.push(excludedMesh);
                            }
                        }
                        light._excludedMeshesIds = new Array < object > ();
                    }
                    if (mesh && light.excludedMeshes.indexOf(mesh) != -1) {
                        continue;
                    }
                    defines.push("#define LIGH" + lightIndex);
                    if (lightIndex > 0) {
                        optionalDefines.push(defines[defines.Length - 1]);
                    }
                    var type;
                    if (lightisBABYLON.SpotLight) {
                        type = "#define SPOTLIGH" + lightIndex;
                    } else
                    if (lightisBABYLON.HemisphericLight) {
                        type = "#define HEMILIGH" + lightIndex;
                    } else {
                        type = "#define POINTDIRLIGH" + lightIndex;
                    }
                    defines.push(type);
                    if (lightIndex > 0) {
                        optionalDefines.push(defines[defines.Length - 1]);
                    }
                    var shadowGenerator = light.getShadowGenerator();
                    if (mesh && mesh.receiveShadows && shadowGenerator) {
                        defines.push("#define SHADO" + lightIndex);
                        if (lightIndex > 0) {
                            optionalDefines.push(defines[defines.Length - 1]);
                        }
                        if (!shadowsActivated) {
                            defines.push("#define SHADOW");
                            shadowsActivated = true;
                        }
                        if (shadowGenerator.useVarianceShadowMap) {
                            defines.push("#define SHADOWVS" + lightIndex);
                            if (lightIndex > 0) {
                                optionalDefines.push(defines[defines.Length - 1]);
                            }
                        }
                        if (shadowGenerator.usePoissonSampling) {
                            defines.push("#define SHADOWPC" + lightIndex);
                            if (lightIndex > 0) {
                                optionalDefines.push(defines[defines.Length - 1]);
                            }
                        }
                    }
                    lightIndex++;
                    if (lightIndex == maxSimultaneousLights)
                        break;
                }
            }
            var attribs = new Array < object > (BABYLON.VertexBuffer.PositionKind, BABYLON.VertexBuffer.NormalKind);
            if (mesh) {
                if (mesh.isVerticesDataPresent(BABYLON.VertexBuffer.UVKind)) {
                    attribs.push(BABYLON.VertexBuffer.UVKind);
                    defines.push("#define UV");
                }
                if (mesh.isVerticesDataPresent(BABYLON.VertexBuffer.UV2Kind)) {
                    attribs.push(BABYLON.VertexBuffer.UV2Kind);
                    defines.push("#define UV");
                }
                if (mesh.isVerticesDataPresent(BABYLON.VertexBuffer.ColorKind)) {
                    attribs.push(BABYLON.VertexBuffer.ColorKind);
                    defines.push("#define VERTEXCOLO");
                }
                if (mesh.skeleton && mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesWeightsKind)) {
                    attribs.push(BABYLON.VertexBuffer.MatricesIndicesKind);
                    attribs.push(BABYLON.VertexBuffer.MatricesWeightsKind);
                    defines.push("#define BONE");
                    defines.push("#define BonesPerMesh" + (mesh.skeleton.bones.Length + 1));
                    defines.push("#define BONES");
                    optionalDefines.push(defines[defines.Length - 1]);
                }
                if (useInstances) {
                    defines.push("#define INSTANCE");
                    attribs.push("world");
                    attribs.push("world");
                    attribs.push("world");
                    attribs.push("world");
                }
            }
            var join = defines.join("\\");
            if (this._cachedDefines != join) {
                this._cachedDefines = join;
                var shaderName = "defaul";
                if (!scene.getEngine().getCaps().standardDerivatives) {
                    shaderName = "legacydefaul";
                }
                this._effect = scene.getEngine().createEffect(shaderName, attribs, new Array < object > ("worl", "vie", "viewProjectio", "vEyePositio", "vLightsTyp", "vAmbientColo", "vDiffuseColo", "vSpecularColo", "vEmissiveColo", "vLightData", "vLightDiffuse", "vLightSpecular", "vLightDirection", "vLightGround", "lightMatrix", "vLightData", "vLightDiffuse", "vLightSpecular", "vLightDirection", "vLightGround", "lightMatrix", "vLightData", "vLightDiffuse", "vLightSpecular", "vLightDirection", "vLightGround", "lightMatrix", "vLightData", "vLightDiffuse", "vLightSpecular", "vLightDirection", "vLightGround", "lightMatrix", "vFogInfo", "vFogColo", "vDiffuseInfo", "vAmbientInfo", "vOpacityInfo", "vReflectionInfo", "vEmissiveInfo", "vSpecularInfo", "vBumpInfo", "mBone", "vClipPlan", "diffuseMatri", "ambientMatri", "opacityMatri", "reflectionMatri", "emissiveMatri", "specularMatri", "bumpMatri", "darkness", "darkness", "darkness", "darkness"), new Array < object > ("diffuseSample", "ambientSample", "opacitySample", "reflectionCubeSample", "reflection2DSample", "emissiveSample", "specularSample", "bumpSample", "shadowSampler", "shadowSampler", "shadowSampler", "shadowSampler"), join, optionalDefines, this.onCompiled, this.onException);
            }
            if (!this._effect.isReady()) {
                return false;
            }
            this._renderId = scene.getRenderId();
            this._wasPreviouslyReady = true;
            return true;
        }
        public virtual void unbind() {
            if (this.reflectionTexture && this.reflectionTexture.isRenderTarget) {
                this._effect.setTexture("reflection2DSample", null);
            }
        }
        public virtual void bindOnlyWorldMatrix(Matrix world) {
            this._effect.setMatrix("worl", world);
        }
        public virtual void bind(Matrix world, Mesh mesh) {
            var scene = this.getScene();
            this._baseColor.copyFrom(this.diffuseColor);
            this.bindOnlyWorldMatrix(world);
            this._effect.setMatrix("viewProjectio", scene.getTransformMatrix());
            if (mesh.skeleton && mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBuffer.MatricesWeightsKind)) {
                this._effect.setMatrices("mBone", mesh.skeleton.getTransformMatrices());
            }
            if (this.diffuseTexture && BABYLON.StandardMaterial.DiffuseTextureEnabled) {
                this._effect.setTexture("diffuseSample", this.diffuseTexture);
                this._effect.setFloat2("vDiffuseInfo", this.diffuseTexture.coordinatesIndex, this.diffuseTexture.level);
                this._effect.setMatrix("diffuseMatri", this.diffuseTexture.getTextureMatrix());
                this._baseColor.copyFromFloats(1, 1, 1);
            }
            if (this.ambientTexture && BABYLON.StandardMaterial.AmbientTextureEnabled) {
                this._effect.setTexture("ambientSample", this.ambientTexture);
                this._effect.setFloat2("vAmbientInfo", this.ambientTexture.coordinatesIndex, this.ambientTexture.level);
                this._effect.setMatrix("ambientMatri", this.ambientTexture.getTextureMatrix());
            }
            if (this.opacityTexture && BABYLON.StandardMaterial.OpacityTextureEnabled) {
                this._effect.setTexture("opacitySample", this.opacityTexture);
                this._effect.setFloat2("vOpacityInfo", this.opacityTexture.coordinatesIndex, this.opacityTexture.level);
                this._effect.setMatrix("opacityMatri", this.opacityTexture.getTextureMatrix());
            }
            if (this.reflectionTexture && BABYLON.StandardMaterial.ReflectionTextureEnabled) {
                if (this.reflectionTexture.isCube) {
                    this._effect.setTexture("reflectionCubeSample", this.reflectionTexture);
                } else {
                    this._effect.setTexture("reflection2DSample", this.reflectionTexture);
                }
                this._effect.setMatrix("reflectionMatri", this.reflectionTexture.getReflectionTextureMatrix());
                this._effect.setFloat3("vReflectionInfo", this.reflectionTexture.coordinatesMode, this.reflectionTexture.level, (this.reflectionTexture.isCube) ? 1 : 0);
            }
            if (this.emissiveTexture && BABYLON.StandardMaterial.EmissiveTextureEnabled) {
                this._effect.setTexture("emissiveSample", this.emissiveTexture);
                this._effect.setFloat2("vEmissiveInfo", this.emissiveTexture.coordinatesIndex, this.emissiveTexture.level);
                this._effect.setMatrix("emissiveMatri", this.emissiveTexture.getTextureMatrix());
            }
            if (this.specularTexture && BABYLON.StandardMaterial.SpecularTextureEnabled) {
                this._effect.setTexture("specularSample", this.specularTexture);
                this._effect.setFloat2("vSpecularInfo", this.specularTexture.coordinatesIndex, this.specularTexture.level);
                this._effect.setMatrix("specularMatri", this.specularTexture.getTextureMatrix());
            }
            if (this.bumpTexture && scene.getEngine().getCaps().standardDerivatives && BABYLON.StandardMaterial.BumpTextureEnabled) {
                this._effect.setTexture("bumpSample", this.bumpTexture);
                this._effect.setFloat2("vBumpInfo", this.bumpTexture.coordinatesIndex, this.bumpTexture.level);
                this._effect.setMatrix("bumpMatri", this.bumpTexture.getTextureMatrix());
            }
            scene.ambientColor.multiplyToRef(this.ambientColor, this._globalAmbientColor);
            this._effect.setVector3("vEyePositio", scene.activeCamera.position);
            this._effect.setColor3("vAmbientColo", this._globalAmbientColor);
            this._effect.setColor4("vDiffuseColo", this._baseColor, this.alpha * mesh.visibility);
            this._effect.setColor4("vSpecularColo", this.specularColor, this.specularPower);
            this._effect.setColor3("vEmissiveColo", this.emissiveColor);
            if (scene.lightsEnabled) {
                var lightIndex = 0;
                for (var index = 0; index < scene.lights.Length; index++) {
                    var light = scene.lights[index];
                    if (!light.isEnabled()) {
                        continue;
                    }
                    if (mesh && light.excludedMeshes.indexOf(mesh) != -1) {
                        continue;
                    }
                    if (lightisBABYLON.PointLight) {
                        light.transferToEffect(this._effect, "vLightDat" + lightIndex);
                    } else
                    if (lightisBABYLON.DirectionalLight) {
                        light.transferToEffect(this._effect, "vLightDat" + lightIndex);
                    } else
                    if (lightisBABYLON.SpotLight) {
                        light.transferToEffect(this._effect, "vLightDat" + lightIndex, "vLightDirectio" + lightIndex);
                    } else
                    if (lightisBABYLON.HemisphericLight) {
                        light.transferToEffect(this._effect, "vLightDat" + lightIndex, "vLightGroun" + lightIndex);
                    }
                    light.diffuse.scaleToRef(light.intensity, this._scaledDiffuse);
                    light.specular.scaleToRef(light.intensity, this._scaledSpecular);
                    this._effect.setColor4("vLightDiffus" + lightIndex, this._scaledDiffuse, light.range);
                    this._effect.setColor3("vLightSpecula" + lightIndex, this._scaledSpecular);
                    var shadowGenerator = light.getShadowGenerator();
                    if (mesh.receiveShadows && shadowGenerator) {
                        this._effect.setMatrix("lightMatri" + lightIndex, shadowGenerator.getTransformMatrix());
                        this._effect.setTexture("shadowSample" + lightIndex, shadowGenerator.getShadowMap());
                        this._effect.setFloat("darknes" + lightIndex, shadowGenerator.getDarkness());
                    }
                    lightIndex++;
                    if (lightIndex == maxSimultaneousLights)
                        break;
                }
            }
            if (scene.clipPlane) {
                var clipPlane = scene.clipPlane;
                this._effect.setFloat4("vClipPlan", clipPlane.normal.x, clipPlane.normal.y, clipPlane.normal.z, clipPlane.d);
            }
            if (scene.fogMode != BABYLON.Scene.FOGMODE_NONE || this.reflectionTexture) {
                this._effect.setMatrix("vie", scene.getViewMatrix());
            }
            if (scene.fogMode != BABYLON.Scene.FOGMODE_NONE) {
                this._effect.setFloat4("vFogInfo", scene.fogMode, scene.fogStart, scene.fogEnd, scene.fogDensity);
                this._effect.setColor3("vFogColo", scene.fogColor);
            }
        }
        public virtual Array < IAnimatable > getAnimatables() {
            var results = new Array < object > ();
            if (this.diffuseTexture && this.diffuseTexture.animations && this.diffuseTexture.animations.Length > 0) {
                results.push(this.diffuseTexture);
            }
            if (this.ambientTexture && this.ambientTexture.animations && this.ambientTexture.animations.Length > 0) {
                results.push(this.ambientTexture);
            }
            if (this.opacityTexture && this.opacityTexture.animations && this.opacityTexture.animations.Length > 0) {
                results.push(this.opacityTexture);
            }
            if (this.reflectionTexture && this.reflectionTexture.animations && this.reflectionTexture.animations.Length > 0) {
                results.push(this.reflectionTexture);
            }
            if (this.emissiveTexture && this.emissiveTexture.animations && this.emissiveTexture.animations.Length > 0) {
                results.push(this.emissiveTexture);
            }
            if (this.specularTexture && this.specularTexture.animations && this.specularTexture.animations.Length > 0) {
                results.push(this.specularTexture);
            }
            if (this.bumpTexture && this.bumpTexture.animations && this.bumpTexture.animations.Length > 0) {
                results.push(this.bumpTexture);
            }
            return results;
        }
        public virtual void dispose(bool forceDisposeEffect = false) {
            if (this.diffuseTexture) {
                this.diffuseTexture.dispose();
            }
            if (this.ambientTexture) {
                this.ambientTexture.dispose();
            }
            if (this.opacityTexture) {
                this.opacityTexture.dispose();
            }
            if (this.reflectionTexture) {
                this.reflectionTexture.dispose();
            }
            if (this.emissiveTexture) {
                this.emissiveTexture.dispose();
            }
            if (this.specularTexture) {
                this.specularTexture.dispose();
            }
            if (this.bumpTexture) {
                this.bumpTexture.dispose();
            }
            base.dispose(forceDisposeEffect);
        }
        public virtual StandardMaterial clone(string name) {
            var newStandardMaterial = new BABYLON.StandardMaterial(name, this.getScene());
            newStandardMaterial.checkReadyOnEveryCall = this.checkReadyOnEveryCall;
            newStandardMaterial.alpha = this.alpha;
            newStandardMaterial.wireframe = this.wireframe;
            newStandardMaterial.backFaceCulling = this.backFaceCulling;
            if (this.diffuseTexture && this.diffuseTexture.clone) {
                newStandardMaterial.diffuseTexture = this.diffuseTexture.clone();
            }
            if (this.ambientTexture && this.ambientTexture.clone) {
                newStandardMaterial.ambientTexture = this.ambientTexture.clone();
            }
            if (this.opacityTexture && this.opacityTexture.clone) {
                newStandardMaterial.opacityTexture = this.opacityTexture.clone();
            }
            if (this.reflectionTexture && this.reflectionTexture.clone) {
                newStandardMaterial.reflectionTexture = this.reflectionTexture.clone();
            }
            if (this.emissiveTexture && this.emissiveTexture.clone) {
                newStandardMaterial.emissiveTexture = this.emissiveTexture.clone();
            }
            if (this.specularTexture && this.specularTexture.clone) {
                newStandardMaterial.specularTexture = this.specularTexture.clone();
            }
            if (this.bumpTexture && this.bumpTexture.clone) {
                newStandardMaterial.bumpTexture = this.bumpTexture.clone();
            }
            newStandardMaterial.ambientColor = this.ambientColor.clone();
            newStandardMaterial.diffuseColor = this.diffuseColor.clone();
            newStandardMaterial.specularColor = this.specularColor.clone();
            newStandardMaterial.specularPower = this.specularPower;
            newStandardMaterial.emissiveColor = this.emissiveColor.clone();
            return newStandardMaterial;
        }
        public static bool DiffuseTextureEnabled = true;
        public static bool AmbientTextureEnabled = true;
        public static bool OpacityTextureEnabled = true;
        public static bool ReflectionTextureEnabled = true;
        public static bool EmissiveTextureEnabled = true;
        public static bool SpecularTextureEnabled = true;
        public static bool BumpTextureEnabled = true;
    }
}