using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BABYLON {
    public class RenderTargetTexture: Texture {
        public Array < AbstractMesh > renderList = new Array < AbstractMesh > ();
        public bool renderParticles = true;
        public bool renderSprites = false;
        public null coordinatesMode = BABYLON.Texture.PROJECTION_MODE;
        public System.Action onBeforeRender;
        public System.Action onAfterRender;
        public System.Action < SmartArray < SubMesh > , SmartArray < SubMesh > , SmartArray < SubMesh > , System.Action > customRenderFunction;
        private float _size;
        public bool _generateMipMaps;
        private RenderingManager _renderingManager;
        public Array < string > _waitingRenderList;
        private bool _doNotChangeAspectRatio;
        private float _currentRefreshId = -1;
        private float _refreshRate = 1;
        public RenderTargetTexture(string name, object size, Scene scene, bool generateMipMaps = false, bool doNotChangeAspectRatio = true): base(null, scene, !generateMipMaps) {
            this.name = name;
            this.isRenderTarget = true;
            this._size = size;
            this._generateMipMaps = generateMipMaps;
            this._doNotChangeAspectRatio = doNotChangeAspectRatio;
            this._texture = scene.getEngine().createRenderTargetTexture(size, generateMipMaps);
            this._renderingManager = new BABYLON.RenderingManager(scene);
        }
        public virtual void resetRefreshCounter() {
            this._currentRefreshId = -1;
        }
        public virtual float refreshRate {
            get {
                return this._refreshRate;
            }
            set {
                this._refreshRate = value;
                this.resetRefreshCounter();
            }
        }
        public virtual bool _shouldRender() {
            if (this._currentRefreshId == -1) {
                this._currentRefreshId = 1;
                return true;
            }
            if (this.refreshRate == this._currentRefreshId) {
                this._currentRefreshId = 1;
                return true;
            }
            this._currentRefreshId++;
            return false;
        }
        public virtual float getRenderSize() {
            return this._size;
        }
        public virtual void resize(object size, object generateMipMaps) {
            this.releaseInternalTexture();
            this._texture = this.getScene().getEngine().createRenderTargetTexture(size, generateMipMaps);
        }
        public virtual void render(bool useCameraPostProcess = false) {
            var scene = this.getScene();
            var engine = scene.getEngine();
            if (this._waitingRenderList) {
                this.renderList = new Array < object > ();
                for (var index = 0; index < this._waitingRenderList.Length; index++) {
                    var id = this._waitingRenderList[index];
                    this.renderList.push(scene.getMeshByID(id));
                }
                this._waitingRenderList = null;
            }
            if (!this.renderList || this.renderList.Length == 0) {
                return;
            }
            if (!useCameraPostProcess || !scene.postProcessManager._prepareFrame(this._texture)) {
                engine.bindFramebuffer(this._texture);
            }
            engine.clear(scene.clearColor, true, true);
            this._renderingManager.reset();
            for (var meshIndex = 0; meshIndex < this.renderList.Length; meshIndex++) {
                var mesh = this.renderList[meshIndex];
                if (mesh) {
                    if (!mesh.isReady() || (mesh.material && !mesh.material.isReady())) {
                        this.resetRefreshCounter();
                        continue;
                    }
                    if (mesh.isEnabled() && mesh.isVisible && mesh.subMeshes && ((mesh.layerMask & scene.activeCamera.layerMask) != 0)) {
                        mesh._activate(scene.getRenderId());
                        for (var subIndex = 0; subIndex < mesh.subMeshes.Length; subIndex++) {
                            var subMesh = mesh.subMeshes[subIndex];
                            scene._activeVertices += subMesh.verticesCount;
                            this._renderingManager.dispatch(subMesh);
                        }
                    }
                }
            }
            if (!this._doNotChangeAspectRatio) {
                scene.updateTransformMatrix(true);
            }
            if (this.onBeforeRender) {
                this.onBeforeRender();
            }
            this._renderingManager.render(this.customRenderFunction, this.renderList, this.renderParticles, this.renderSprites);
            if (useCameraPostProcess) {
                scene.postProcessManager._finalizeFrame(false, this._texture);
            }
            if (this.onAfterRender) {
                this.onAfterRender();
            }
            engine.unBindFramebuffer(this._texture);
            if (!this._doNotChangeAspectRatio) {
                scene.updateTransformMatrix(true);
            }
        }
        public virtual RenderTargetTexture clone() {
            var textureSize = this.getSize();
            var newTexture = new BABYLON.RenderTargetTexture(this.name, textureSize.width, this.getScene(), this._generateMipMaps);
            newTexture.hasAlpha = this.hasAlpha;
            newTexture.level = this.level;
            newTexture.coordinatesMode = this.coordinatesMode;
            newTexture.renderList = this.renderList.slice(0);
            return newTexture;
        }
    }
}