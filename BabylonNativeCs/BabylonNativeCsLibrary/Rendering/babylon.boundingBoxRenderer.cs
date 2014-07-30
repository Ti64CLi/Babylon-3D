using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class BoundingBoxRenderer {
        public BABYLON.Color3 frontColor = new BABYLON.Color3(1, 1, 1);
        public BABYLON.Color3 backColor = new BABYLON.Color3(0.1, 0.1, 0.1);
        public bool showBackLines = true;
        public BABYLON.SmartArray < BoundingBox > renderList = new BABYLON.SmartArray < BoundingBox > (32);
        private Scene _scene;
        private ShaderMaterial _colorShader;
        private VertexBuffer _vb;
        private WebGLBuffer _ib;
        public BoundingBoxRenderer(Scene scene) {
            this._scene = scene;
            this._colorShader = new ShaderMaterial("colorShader", scene, "color", new {});
            var engine = this._scene.getEngine();
            var boxdata = BABYLON.VertexData.CreateBox(1.0);
            this._vb = new BABYLON.VertexBuffer(engine, boxdata.positions, BABYLON.VertexBuffer.PositionKind, false);
            this._ib = engine.createIndexBuffer(new Array < object > (0, 1, 1, 2, 2, 3, 3, 0, 4, 5, 5, 6, 6, 7, 7, 4, 0, 7, 1, 6, 2, 5, 3, 4));
        }
        public virtual void reset() {
            this.renderList.reset();
        }
        public virtual void render() {
            if (this.renderList.Length == 0 || !this._colorShader.isReady()) {
                return;
            }
            var engine = this._scene.getEngine();
            engine.setDepthWrite(false);
            this._colorShader._preBind();
            for (var boundingBoxIndex = 0; boundingBoxIndex < this.renderList.Length; boundingBoxIndex++) {
                var boundingBox = this.renderList.data[boundingBoxIndex];
                var min = boundingBox.minimum;
                var Max = boundingBox.maximum;
                var diff = Max.subtract(min);
                var median = min.add(diff.scale(0.5));
                var worldMatrix = BABYLON.Matrix.Scaling(diff.x, diff.y, diff.z).multiply(BABYLON.Matrix.Translation(median.x, median.y, median.z)).multiply(boundingBox.getWorldMatrix());
                engine.bindBuffers(this._vb.getBuffer(), this._ib, new Array < object > (3), 3 * 4, this._colorShader.getEffect());
                if (this.showBackLines) {
                    engine.setDepthFunctionToGreaterOrEqual();
                    this._colorShader.setColor3("color", this.backColor);
                    this._colorShader.bind(worldMatrix);
                    engine.draw(false, 0, 24);
                }
                engine.setDepthFunctionToLess();
                this._colorShader.setColor3("color", this.frontColor);
                this._colorShader.bind(worldMatrix);
                engine.draw(false, 0, 24);
            }
            this._colorShader.unbind();
            engine.setDepthFunctionToLessOrEqual();
            engine.setDepthWrite(true);
        }
        public virtual void dispose() {
            this._colorShader.dispose();
            this._vb.dispose();
            this._scene.getEngine()._releaseBuffer(this._ib);
        }
    }
}