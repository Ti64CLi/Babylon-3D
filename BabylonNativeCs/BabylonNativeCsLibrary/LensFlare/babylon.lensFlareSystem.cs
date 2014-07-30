using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class LensFlareSystem {
        public Array < LensFlare > lensFlares = new Array < LensFlare > ();
        public double borderLimit = 300;
        public System.Func < Mesh, bool > meshesSelectionPredicate;
        private Scene _scene;
        private object _emitter;
        private Array < object > _vertexDeclaration = new Array < object > (2);
        private double _vertexStrideSize = 2 * 4;
        private WebGLBuffer _vertexBuffer;
        private WebGLBuffer _indexBuffer;
        private Effect _effect;
        private double _positionX;
        private double _positionY;
        private bool _isEnabled = true;
        public string name;
        public LensFlareSystem(string name, object emitter, Scene scene) {
            this._scene = scene;
            this._emitter = emitter;
            scene.lensFlareSystems.push(this);
            this.meshesSelectionPredicate = (m) => m.material && m.isVisible && m.isEnabled() && m.checkCollisions && ((m.layerMask & scene.activeCamera.layerMask) != 0);
            var vertices = new Array < object > ();
            vertices.push(1, 1);
            vertices.push(-1, 1);
            vertices.push(-1, -1);
            vertices.push(1, -1);
            this._vertexBuffer = scene.getEngine().createVertexBuffer(vertices);
            var indices = new Array < object > ();
            indices.push(0);
            indices.push(1);
            indices.push(2);
            indices.push(0);
            indices.push(2);
            indices.push(3);
            this._indexBuffer = scene.getEngine().createIndexBuffer(indices);
            this._effect = this._scene.getEngine().createEffect("lensFlare", new Array < object > ("position"), new Array < object > ("color", "viewportMatrix"), new Array < object > ("textureSampler"), "");
        }
        public virtual bool isEnabled {
            get {
                return this._isEnabled;
            }
            set {
                this._isEnabled = value;
            }
        }
        public virtual Scene getScene() {
            return this._scene;
        }
        public virtual object getEmitter() {
            return this._emitter;
        }
        public virtual Vector3 getEmitterPosition() {
            return (this._emitter.getAbsolutePosition) ? this._emitter.getAbsolutePosition() : this._emitter.position;
        }
        public virtual bool computeEffectivePosition(Viewport globalViewport) {
            var position = this.getEmitterPosition();
            position = BABYLON.Vector3.Project(position, BABYLON.Matrix.Identity(), this._scene.getTransformMatrix(), globalViewport);
            this._positionX = position.x;
            this._positionY = position.y;
            position = BABYLON.Vector3.TransformCoordinates(this.getEmitterPosition(), this._scene.getViewMatrix());
            if (position.z > 0) {
                if ((this._positionX > globalViewport.x) && (this._positionX < globalViewport.x + globalViewport.width)) {
                    if ((this._positionY > globalViewport.y) && (this._positionY < globalViewport.y + globalViewport.height))
                        return true;
                }
            }
            return false;
        }
        public virtual bool _isVisible() {
            if (!this._isEnabled) {
                return false;
            }
            var emitterPosition = this.getEmitterPosition();
            var direction = emitterPosition.subtract(this._scene.activeCamera.position);
            var distance = direction.Length();
            direction.normalize();
            var ray = new BABYLON.Ray(this._scene.activeCamera.position, direction);
            var pickInfo = this._scene.pickWithRay(ray, this.meshesSelectionPredicate, true);
            return !pickInfo.hit || pickInfo.distance > distance;
        }
        public virtual bool render() {
            if (!this._effect.isReady())
                return false;
            var engine = this._scene.getEngine();
            var viewport = this._scene.activeCamera.viewport;
            var globalViewport = viewport.toGlobal(engine);
            if (!this.computeEffectivePosition(globalViewport)) {
                return false;
            }
            if (!this._isVisible()) {
                return false;
            }
            var awayX;
            var awayY;
            if (this._positionX < this.borderLimit + globalViewport.x) {
                awayX = this.borderLimit + globalViewport.x - this._positionX;
            } else
            if (this._positionX > globalViewport.x + globalViewport.width - this.borderLimit) {
                awayX = this._positionX - globalViewport.x - globalViewport.width + this.borderLimit;
            } else {
                awayX = 0;
            }
            if (this._positionY < this.borderLimit + globalViewport.y) {
                awayY = this.borderLimit + globalViewport.y - this._positionY;
            } else
            if (this._positionY > globalViewport.y + globalViewport.height - this.borderLimit) {
                awayY = this._positionY - globalViewport.y - globalViewport.height + this.borderLimit;
            } else {
                awayY = 0;
            }
            var away = ((awayX > awayY)) ? awayX : awayY;
            if (away > this.borderLimit) {
                away = this.borderLimit;
            }
            var intensity = 1.0 - (away / this.borderLimit);
            if (intensity < 0) {
                return false;
            }
            if (intensity > 1.0) {
                intensity = 1.0;
            }
            var centerX = globalViewport.x + globalViewport.width / 2;
            var centerY = globalViewport.y + globalViewport.height / 2;
            var distX = centerX - this._positionX;
            var distY = centerY - this._positionY;
            engine.enableEffect(this._effect);
            engine.setState(false);
            engine.setDepthBuffer(false);
            engine.setAlphaMode(BABYLON.Engine.ALPHA_ADD);
            engine.bindBuffers(this._vertexBuffer, this._indexBuffer, this._vertexDeclaration, this._vertexStrideSize, this._effect);
            for (var index = 0; index < this.lensFlares.Length; index++) {
                var flare = this.lensFlares[index];
                var x = centerX - (distX * flare.position);
                var y = centerY - (distY * flare.position);
                var cw = flare.size;
                var ch = flare.size * engine.getAspectRatio(this._scene.activeCamera);
                var cx = 2 * (x / globalViewport.width) - 1.0;
                var cy = 1.0 - 2 * (y / globalViewport.height);
                var viewportMatrix = BABYLON.Matrix.FromValues(cw / 2, 0, 0, 0, 0, ch / 2, 0, 0, 0, 0, 1, 0, cx, cy, 0, 1);
                this._effect.setMatrix("viewportMatrix", viewportMatrix);
                this._effect.setTexture("textureSampler", flare.texture);
                this._effect.setFloat4("color", flare.color.r * intensity, flare.color.g * intensity, flare.color.b * intensity, 1.0);
                engine.draw(true, 0, 6);
            }
            engine.setDepthBuffer(true);
            engine.setAlphaMode(BABYLON.Engine.ALPHA_DISABLE);
            return true;
        }
        public virtual void dispose() {
            if (this._vertexBuffer) {
                this._scene.getEngine()._releaseBuffer(this._vertexBuffer);
                this._vertexBuffer = null;
            }
            if (this._indexBuffer) {
                this._scene.getEngine()._releaseBuffer(this._indexBuffer);
                this._indexBuffer = null;
            }
            while (this.lensFlares.Length) {
                this.lensFlares[0].dispose();
            }
            var index = this._scene.lensFlareSystems.indexOf(this);
            this._scene.lensFlareSystems.splice(index, 1);
        }
    }
}