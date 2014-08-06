using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class ShadowGenerator
    {
        public const int FILTER_NONE = 0;
        public const int FILTER_VARIANCESHADOWMAP = 1;
        public const int FILTER_POISSONSAMPLING = 2;
        private DirectionalLight _light;
        private Scene _scene;
        private RenderTargetTexture _shadowMap;
        private double _darkness = 0;
        private bool _transparencyShadow = false;
        private Effect _effect;
        private BABYLON.Matrix _viewMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _projectionMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _transformMatrix = BABYLON.Matrix.Zero();
        private BABYLON.Matrix _worldViewProjection = BABYLON.Matrix.Zero();
        private Vector3 _cachedPosition;
        private Vector3 _cachedDirection;
        private string _cachedDefines;
        public bool useVarianceShadowMap;
        public bool usePoissonSampling;
        public ShadowGenerator(Size mapSize, DirectionalLight light)
        {
            this._light = light;
            this._scene = light.getScene();
            light._shadowGenerator = this;
            this._shadowMap = new BABYLON.RenderTargetTexture(light.name + "_shadowMap", mapSize, this._scene, false);
            this._shadowMap.wrapU = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this._shadowMap.wrapV = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this._shadowMap.renderParticles = false;
            Action<SubMesh> renderSubMesh = (SubMesh subMesh) =>
            {
                var mesh = subMesh.getRenderingMesh();
                var scene = this._scene;
                var engine = scene.getEngine();
                engine.setState(subMesh.getMaterial().backFaceCulling);
                var batch = mesh._getInstancesRenderList(subMesh._id);
                if (batch.mustReturn)
                {
                    return;
                }
                var hardwareInstancedRendering = (engine.getCaps().instancedArrays != null) && (batch.visibleInstances != null);
                if (this.isReady(subMesh, hardwareInstancedRendering))
                {
                    engine.enableEffect(this._effect);
                    mesh._bind(subMesh, this._effect, false);
                    var material = subMesh.getMaterial();
                    this._effect.setMatrix("viewProjection", this.getTransformMatrix());
                    if (material != null && material.needAlphaTesting())
                    {
                        var alphaTexture = material.getAlphaTestTexture();
                        this._effect.setTexture("diffuseSampler", alphaTexture);
                        this._effect.setMatrix("diffuseMatrix", alphaTexture.getTextureMatrix());
                    }
                    var useBones = mesh.skeleton != null && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesWeightsKind);
                    if (useBones)
                    {
                        this._effect.setMatrices("mBones", mesh.skeleton.getTransformMatrices());
                    }
                    if (hardwareInstancedRendering)
                    {
                        mesh._renderWithInstances(subMesh, false, batch, this._effect, engine);
                    }
                    else
                    {
                        if (batch.renderSelf[subMesh._id])
                        {
                            this._effect.setMatrix("world", mesh.getWorldMatrix());
                            mesh._draw(subMesh, true);
                        }
                        if (batch.visibleInstances[subMesh._id] != null)
                        {
                            for (var instanceIndex = 0; instanceIndex < batch.visibleInstances[subMesh._id].Length; instanceIndex++)
                            {
                                var instance = batch.visibleInstances[subMesh._id][instanceIndex];
                                this._effect.setMatrix("world", instance.getWorldMatrix());
                                mesh._draw(subMesh, true);
                            }
                        }
                    }
                }
                else
                {
                    this._shadowMap.resetRefreshCounter();
                }
            };
            this._shadowMap.customRenderFunction = (SmartArray<SubMesh> opaqueSubMeshes, SmartArray<SubMesh> alphaTestSubMeshes, SmartArray<SubMesh> transparentSubMeshes, System.Action beforeTransform) =>
            {
                for (var index = 0; index < opaqueSubMeshes.Length; index++)
                {
                    renderSubMesh(opaqueSubMeshes[index]);
                }
                for (var index = 0; index < alphaTestSubMeshes.Length; index++)
                {
                    renderSubMesh(alphaTestSubMeshes[index]);
                }
                if (this._transparencyShadow)
                {
                    for (var index = 0; index < transparentSubMeshes.Length; index++)
                    {
                        renderSubMesh(transparentSubMeshes[index]);
                    }
                }
            };
        }
        public virtual bool isReady(SubMesh subMesh, bool useInstances)
        {
            var defines = new Array<string>();
            if (this.useVarianceShadowMap)
            {
                defines.Add("#define VSM");
            }
            var attribs = new Array<string>(BABYLON.VertexBuffer.PositionKind);
            var mesh = subMesh.getMesh();
            var material = subMesh.getMaterial();
            if (material != null && material.needAlphaTesting())
            {
                defines.Add("#define ALPHATEST");
                if (mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.UVKind))
                {
                    attribs.Add(BABYLON.VertexBuffer.UVKind);
                    defines.Add("#define UV1");
                }
                if (mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.UV2Kind))
                {
                    attribs.Add(BABYLON.VertexBuffer.UV2Kind);
                    defines.Add("#define UV2");
                }
            }
            if (mesh.skeleton != null && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesWeightsKind))
            {
                attribs.Add(BABYLON.VertexBuffer.MatricesIndicesKind);
                attribs.Add(BABYLON.VertexBuffer.MatricesWeightsKind);
                defines.Add("#define BONES");
                defines.Add("#define BonesPerMesh " + (mesh.skeleton.bones.Length + 1));
            }
            if (useInstances)
            {
                defines.Add("#define INSTANCES");
                attribs.Add("world0");
                attribs.Add("world1");
                attribs.Add("world2");
                attribs.Add("world3");
            }
            var join = defines.Concat("\n");
            if (this._cachedDefines != join)
            {
                this._cachedDefines = join;
                this._effect = this._scene.getEngine().createEffect(new EffectBaseName { baseName = "shadowMap" }, attribs, new Array<string>("world", "mBones", "viewProjection", "diffuseMatrix"), new Array<string>("diffuseSampler"), join);
            }
            return this._effect.isReady();
        }
        public virtual RenderTargetTexture getShadowMap()
        {
            return this._shadowMap;
        }
        public virtual DirectionalLight getLight()
        {
            return this._light;
        }
        public virtual Matrix getTransformMatrix()
        {
            var lightPosition = this._light.position;
            var lightDirection = this._light.direction;
            if (this._light._computeTransformedPosition())
            {
                lightPosition = this._light._transformedPosition;
            }
            if (this._cachedPosition == null || this._cachedDirection == null || !lightPosition.equals(this._cachedPosition) || !lightDirection.equals(this._cachedDirection))
            {
                this._cachedPosition = lightPosition.clone();
                this._cachedDirection = lightDirection.clone();
                var activeCamera = this._scene.activeCamera;
                BABYLON.Matrix.LookAtLHToRef(lightPosition, this._light.position.add(lightDirection), BABYLON.Vector3.Up(), this._viewMatrix);
                BABYLON.Matrix.PerspectiveFovLHToRef(Math.PI / 2.0, 1.0, activeCamera.minZ, activeCamera.maxZ, this._projectionMatrix);
                this._viewMatrix.multiplyToRef(this._projectionMatrix, this._transformMatrix);
            }
            return this._transformMatrix;
        }
        public virtual double getDarkness()
        {
            return this._darkness;
        }
        public virtual void setDarkness(double darkness)
        {
            if (darkness >= 1.0)
                this._darkness = 1.0;
            else
                if (darkness <= 0.0)
                    this._darkness = 0.0;
                else
                    this._darkness = darkness;
        }
        public virtual void setTransparencyShadow(bool hasShadow)
        {
            this._transparencyShadow = hasShadow;
        }
        public virtual void dispose()
        {
            this._shadowMap.dispose();
        }
    }
}