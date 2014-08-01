using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class ShadowGenerator {
        private
        const int _FILTER_NONE = 0;
        private
        const int _FILTER_VARIANCESHADOWMAP = 1;
        private
        const int _FILTER_POISSONSAMPLING = 2;
        public static int FILTER_NONE {
            get {
                return ShadowGenerator._FILTER_NONE;
            }
        }
        public static int FILTER_VARIANCESHADOWMAP {
            get {
                return ShadowGenerator._FILTER_VARIANCESHADOWMAP;
            }
        }
        public static int FILTER_POISSONSAMPLING {
            get {
                return ShadowGenerator._FILTER_POISSONSAMPLING;
            }
        }
        public double filter = ShadowGenerator.FILTER_VARIANCESHADOWMAP;
        public virtual bool useVarianceShadowMap {
            get {
                return this.filter == ShadowGenerator.FILTER_VARIANCESHADOWMAP;
            }
            set {
                this.filter = ((value) ? ShadowGenerator.FILTER_VARIANCESHADOWMAP : ShadowGenerator.FILTER_NONE);
            }
        }
        public virtual bool usePoissonSampling {
            get {
                return this.filter == ShadowGenerator.FILTER_POISSONSAMPLING;
            }
            set {
                this.filter = ((value) ? ShadowGenerator.FILTER_POISSONSAMPLING : ShadowGenerator.FILTER_NONE);
            }
        }
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
        public ShadowGenerator(double mapSize, DirectionalLight light) {
            this._light = light;
            this._scene = light.getScene();
            light._shadowGenerator = this;
            this._shadowMap = new BABYLON.RenderTargetTexture(light.name + "_shadowMap", mapSize, this._scene, false);
            this._shadowMap.wrapU = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this._shadowMap.wrapV = BABYLON.Texture.CLAMP_ADDRESSMODE;
            this._shadowMap.renderParticles = false;
            var renderSubMesh = (SubMesh subMesh) => {
                var mesh = subMesh.getRenderingMesh();
                var scene = this._scene;
                var engine = scene.getEngine();
                engine.setState(subMesh.getMaterial().backFaceCulling);
                var batch = mesh._getInstancesRenderList(subMesh._id);
                if (batch.mustReturn) {
                    return;
                }
                var hardwareInstancedRendering = (engine.getCaps().instancedArrays != null) && (batch.visibleInstances != null);
                if (this.isReady(subMesh, hardwareInstancedRendering)) {
                    engine.enableEffect(this._effect);
                    mesh._bind(subMesh, this._effect, false);
                    var material = subMesh.getMaterial();
                    this._effect.setMatrix("viewProjection", this.getTransformMatrix());
                    if (material && material.needAlphaTesting()) {
                        var alphaTexture = material.getAlphaTestTexture();
                        this._effect.setTexture("diffuseSampler", alphaTexture);
                        this._effect.setMatrix("diffuseMatrix", alphaTexture.getTextureMatrix());
                    }
                    var useBones = mesh.skeleton && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesWeightsKind);
                    if (useBones) {
                        this._effect.setMatrices("mBones", mesh.skeleton.getTransformMatrices());
                    }
                    if (hardwareInstancedRendering) {
                        mesh._renderWithInstances(subMesh, false, batch, this._effect, engine);
                    } else {
                        if (batch.renderSelf[subMesh._id]) {
                            this._effect.setMatrix("world", mesh.getWorldMatrix());
                            mesh._draw(subMesh, true);
                        }
                        if (batch.visibleInstances[subMesh._id]) {
                            for (var instanceIndex = 0; instanceIndex < batch.visibleInstances[subMesh._id].Length; instanceIndex++) {
                                var instance = batch.visibleInstances[subMesh._id][instanceIndex];
                                this._effect.setMatrix("world", instance.getWorldMatrix());
                                mesh._draw(subMesh, true);
                            }
                        }
                    }
                } else {
                    this._shadowMap.resetRefreshCounter();
                }
            };
            this._shadowMap.customRenderFunction = (SmartArray < SubMesh > opaqueSubMeshes, SmartArray < SubMesh > alphaTestSubMeshes, SmartArray < SubMesh > transparentSubMeshes) => {
                var index;
                for (index = 0; index < opaqueSubMeshes.Length; index++) {
                    renderSubMesh(opaqueSubMeshes.data[index]);
                }
                for (index = 0; index < alphaTestSubMeshes.Length; index++) {
                    renderSubMesh(alphaTestSubMeshes.data[index]);
                }
                if (this._transparencyShadow) {
                    for (index = 0; index < transparentSubMeshes.Length; index++) {
                        renderSubMesh(transparentSubMeshes.data[index]);
                    }
                }
            };
        }
        public virtual bool isReady(SubMesh subMesh, bool useInstances) {
            var defines = new Array < object > ();
            if (this.useVarianceShadowMap) {
                defines.push("#define VSM");
            }
            var attribs = new Array < object > (BABYLON.VertexBufferKind.PositionKind);
            var mesh = subMesh.getMesh();
            var material = subMesh.getMaterial();
            if (material && material.needAlphaTesting()) {
                defines.push("#define ALPHATEST");
                if (mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.UVKind)) {
                    attribs.push(BABYLON.VertexBufferKind.UVKind);
                    defines.push("#define UV1");
                }
                if (mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.UV2Kind)) {
                    attribs.push(BABYLON.VertexBufferKind.UV2Kind);
                    defines.push("#define UV2");
                }
            }
            if (mesh.skeleton && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesIndicesKind) && mesh.isVerticesDataPresent(BABYLON.VertexBufferKind.MatricesWeightsKind)) {
                attribs.push(BABYLON.VertexBufferKind.MatricesIndicesKind);
                attribs.push(BABYLON.VertexBufferKind.MatricesWeightsKind);
                defines.push("#define BONES");
                defines.push("#define BonesPerMesh " + (mesh.skeleton.bones.Length + 1));
            }
            if (useInstances) {
                defines.push("#define INSTANCES");
                attribs.push("world0");
                attribs.push("world1");
                attribs.push("world2");
                attribs.push("world3");
            }
            var join = defines.join("\\n");
            if (this._cachedDefines != join) {
                this._cachedDefines = join;
                this._effect = this._scene.getEngine().createEffect("shadowMap", attribs, new Array < object > ("world", "mBones", "viewProjection", "diffuseMatrix"), new Array < object > ("diffuseSampler"), join);
            }
            return this._effect.isReady();
        }
        public virtual RenderTargetTexture getShadowMap() {
            return this._shadowMap;
        }
        public virtual DirectionalLight getLight() {
            return this._light;
        }
        public virtual Matrix getTransformMatrix() {
            var lightPosition = this._light.position;
            var lightDirection = this._light.direction;
            if (this._light._computeTransformedPosition()) {
                lightPosition = this._light._transformedPosition;
            }
            if (!this._cachedPosition || !this._cachedDirection || !lightPosition.equals(this._cachedPosition) || !lightDirection.equals(this._cachedDirection)) {
                this._cachedPosition = lightPosition.clone();
                this._cachedDirection = lightDirection.clone();
                var activeCamera = this._scene.activeCamera;
                BABYLON.Matrix.LookAtLHToRef(lightPosition, this._light.position.add(lightDirection), BABYLON.Vector3.Up(), this._viewMatrix);
                BABYLON.Matrix.PerspectiveFovLHToRef(Math.PI / 2.0, 1.0, activeCamera.minZ, activeCamera.maxZ, this._projectionMatrix);
                this._viewMatrix.multiplyToRef(this._projectionMatrix, this._transformMatrix);
            }
            return this._transformMatrix;
        }
        public virtual double getDarkness() {
            return this._darkness;
        }
        public virtual void setDarkness(double darkness) {
            if (darkness >= 1.0)
                this._darkness = 1.0;
            else
            if (darkness <= 0.0)
                this._darkness = 0.0;
            else
                this._darkness = darkness;
        }
        public virtual void setTransparencyShadow(bool hasShadow) {
            this._transparencyShadow = hasShadow;
        }
        public virtual void dispose() {
            this._shadowMap.dispose();
        }
    }
}