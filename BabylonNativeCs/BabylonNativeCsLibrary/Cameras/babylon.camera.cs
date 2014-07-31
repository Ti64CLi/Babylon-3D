using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class Camera: Node {
        public
        const int PERSPECTIVE_CAMERA = 0;
        public
        const int ORTHOGRAPHIC_CAMERA = 1;
        public BABYLON.Vector3 upVector = Vector3.Up();
        public any orthoLeft = null;
        public any orthoRight = null;
        public any orthoBottom = null;
        public any orthoTop = null;
        public double fov = 0.8;
        public double minZ = 0.1;
        public double maxZ = 1000.0;
        public double inertia = 0.9;
        public double mode = Camera.PERSPECTIVE_CAMERA;
        public bool isIntermediate = false;
        public Viewport viewport = new Viewport(0, 0, 1.0, 1.0);
        public Array < object > subCameras = new Array < object > ();
        public double layerMask = 0xFFFFFFFF;
        private BABYLON.Matrix _computedViewMatrix = BABYLON.Matrix.Identity();
        public BABYLON.Matrix _projectionMatrix = new BABYLON.Matrix();
        private Matrix _worldMatrix;
        public Array < PostProcess > _postProcesses = new Array < PostProcess > ();
        public Array < object > _postProcessesTakenIndices = new Array < object > ();
        public string _waitingParentId;
        public Vector3 position;
        public Camera(string name, Vector3 position, Scene scene): base(name, scene) {
            scene.cameras.push(this);
            if (!scene.activeCamera) {
                scene.activeCamera = this;
            }
        }
        public virtual void _initCache() {
            base._initCache();
            this._cache.position = new BABYLON.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.upVector = new BABYLON.Vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            this._cache.mode = null;
            this._cache.minZ = null;
            this._cache.maxZ = null;
            this._cache.fov = null;
            this._cache.aspectRatio = null;
            this._cache.orthoLeft = null;
            this._cache.orthoRight = null;
            this._cache.orthoBottom = null;
            this._cache.orthoTop = null;
            this._cache.renderWidth = null;
            this._cache.renderHeight = null;
        }
        public virtual void _updateCache(bool ignoreParentClass = false) {
            if (!ignoreParentClass) {
                base._updateCache();
            }
            var engine = this.getEngine();
            this._cache.position.copyFrom(this.position);
            this._cache.upVector.copyFrom(this.upVector);
            this._cache.mode = this.mode;
            this._cache.minZ = this.minZ;
            this._cache.maxZ = this.maxZ;
            this._cache.fov = this.fov;
            this._cache.aspectRatio = engine.getAspectRatio(this);
            this._cache.orthoLeft = this.orthoLeft;
            this._cache.orthoRight = this.orthoRight;
            this._cache.orthoBottom = this.orthoBottom;
            this._cache.orthoTop = this.orthoTop;
            this._cache.renderWidth = engine.getRenderWidth();
            this._cache.renderHeight = engine.getRenderHeight();
        }
        public virtual void _updateFromScene() {
            this.updateCache();
            this._update();
        }
        public virtual bool _isSynchronized() {
            return this._isSynchronizedViewMatrix() && this._isSynchronizedProjectionMatrix();
        }
        public virtual bool _isSynchronizedViewMatrix() {
            if (!base._isSynchronized())
                return false;
            return this._cache.position.equals(this.position) && this._cache.upVector.equals(this.upVector) && this.isSynchronizedWithParent();
        }
        public virtual bool _isSynchronizedProjectionMatrix() {
            var check = this._cache.mode == this.mode && this._cache.minZ == this.minZ && this._cache.maxZ == this.maxZ;
            if (!check) {
                return false;
            }
            var engine = this.getEngine();
            if (this.mode == BABYLON.Camera.PERSPECTIVE_CAMERA) {
                check = this._cache.fov == this.fov && this._cache.aspectRatio == engine.getAspectRatio(this);
            } else {
                check = this._cache.orthoLeft == this.orthoLeft && this._cache.orthoRight == this.orthoRight && this._cache.orthoBottom == this.orthoBottom && this._cache.orthoTop == this.orthoTop && this._cache.renderWidth == engine.getRenderWidth() && this._cache.renderHeight == engine.getRenderHeight();
            }
            return check;
        }
        public virtual void attachControl(HTMLElement element) {}
        public virtual void detachControl(HTMLElement element) {}
        public virtual void _update() {}
        public virtual double attachPostProcess(PostProcess postProcess, double insertAt = null) {
            if (!postProcess.isReusable() && this._postProcesses.indexOf(postProcess) > -1) {
                Tools.Error("You're trying to reuse a post process not defined as reusable.");
                return 0;
            }
            if (insertAt == null || insertAt < 0) {
                this._postProcesses.push(postProcess);
                this._postProcessesTakenIndices.push(this._postProcesses.Length - 1);
                return this._postProcesses.Length - 1;
            }
            var add = 0;
            if (this._postProcesses[insertAt]) {
                var start = this._postProcesses.Length - 1;
                for (var i = start; i >= insertAt + 1; --i) {
                    this._postProcesses[i + 1] = this._postProcesses[i];
                }
                add = 1;
            }
            for (i = 0; i < this._postProcessesTakenIndices.Length; ++i) {
                if (this._postProcessesTakenIndices[i] < insertAt) {
                    continue;
                }
                start = this._postProcessesTakenIndices.Length - 1;
                for (var j = start; j >= i; --j) {
                    this._postProcessesTakenIndices[j + 1] = this._postProcessesTakenIndices[j] + add;
                }
                this._postProcessesTakenIndices[i] = insertAt;
                break;
            }
            if (!add && this._postProcessesTakenIndices.indexOf(insertAt) == -1) {
                this._postProcessesTakenIndices.push(insertAt);
            }
            var result = insertAt + add;
            this._postProcesses[result] = postProcess;
            return result;
        }
        public virtual Array < double > detachPostProcess(PostProcess postProcess, object atIndices = null) {
            var result = new Array < object > ();
            if (!atIndices) {
                var Length = this._postProcesses.Length;
                for (var i = 0; i < Length; i++) {
                    if (this._postProcesses[i] != postProcess) {
                        continue;
                    }
                    this._postProcesses[i] = null;
                    var index = this._postProcessesTakenIndices.indexOf(i);
                    this._postProcessesTakenIndices.splice(index, 1);
                }
            } else {
                atIndices = ((atIndices is Array)) ? atIndices : new Array < object > (atIndices);
                for (i = 0; i < atIndices.Length; i++) {
                    var foundPostProcess = this._postProcesses[atIndices[i]];
                    if (foundPostProcess != postProcess) {
                        result.push(i);
                        continue;
                    }
                    this._postProcesses[atIndices[i]] = null;
                    index = this._postProcessesTakenIndices.indexOf(atIndices[i]);
                    this._postProcessesTakenIndices.splice(index, 1);
                }
            }
            return result;
        }
        public virtual Matrix getWorldMatrix() {
            if (!this._worldMatrix) {
                this._worldMatrix = BABYLON.Matrix.Identity();
            }
            var viewMatrix = this.getViewMatrix();
            viewMatrix.invertToRef(this._worldMatrix);
            return this._worldMatrix;
        }
        public virtual Matrix _getViewMatrix() {
            return BABYLON.Matrix.Identity();
        }
        public virtual Matrix getViewMatrix() {
            this._computedViewMatrix = this._computeViewMatrix();
            if (!this.parent || !this.parent.getWorldMatrix || this.isSynchronized()) {
                return this._computedViewMatrix;
            }
            if (!this._worldMatrix) {
                this._worldMatrix = BABYLON.Matrix.Identity();
            }
            this._computedViewMatrix.invertToRef(this._worldMatrix);
            this._worldMatrix.multiplyToRef(this.parent.getWorldMatrix(), this._computedViewMatrix);
            this._computedViewMatrix.invert();
            this._currentRenderId = this.getScene().getRenderId();
            return this._computedViewMatrix;
        }
        public virtual Matrix _computeViewMatrix(bool force = false) {
            if (!force && this._isSynchronizedViewMatrix()) {
                return this._computedViewMatrix;
            }
            this._computedViewMatrix = this._getViewMatrix();
            if (!this.parent || !this.parent.getWorldMatrix) {
                this._currentRenderId = this.getScene().getRenderId();
            }
            return this._computedViewMatrix;
        }
        public virtual Matrix getProjectionMatrix(bool force = false) {
            if (!force && this._isSynchronizedProjectionMatrix()) {
                return this._projectionMatrix;
            }
            var engine = this.getEngine();
            if (this.mode == BABYLON.Camera.PERSPECTIVE_CAMERA) {
                if (this.minZ <= 0) {
                    this.minZ = 0.1;
                }
                BABYLON.Matrix.PerspectiveFovLHToRef(this.fov, engine.getAspectRatio(this), this.minZ, this.maxZ, this._projectionMatrix);
                return this._projectionMatrix;
            }
            var halfWidth = engine.getRenderWidth() / 2.0;
            var halfHeight = engine.getRenderHeight() / 2.0;
            BABYLON.Matrix.OrthoOffCenterLHToRef(this.orthoLeft || -halfWidth, this.orthoRight || halfWidth, this.orthoBottom || -halfHeight, this.orthoTop || halfHeight, this.minZ, this.maxZ, this._projectionMatrix);
            return this._projectionMatrix;
        }
        public virtual void dispose() {
            var index = this.getScene().cameras.indexOf(this);
            this.getScene().cameras.splice(index, 1);
            for (var i = 0; i < this._postProcessesTakenIndices.Length; ++i) {
                this._postProcesses[this._postProcessesTakenIndices[i]].dispose(this);
            }
        }
    }
}