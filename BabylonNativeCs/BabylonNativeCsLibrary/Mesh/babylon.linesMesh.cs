using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class LinesMesh: Mesh {
        public BABYLON.Color3 color = new BABYLON.Color3(1, 1, 1);
        private ShaderMaterial _colorShader;
        private WebGLBuffer _ib;
        private double _indicesLength;
        private Array < double > _indices = new Array < double > ();
        public LinesMesh(string name, Scene scene, object updatable = false): base(name, scene) {
            this._colorShader = new ShaderMaterial("colorShader", scene, "color", new {});
        }
        public virtual Material material {
            get {
                return this._colorShader;
            }
        }
        public virtual bool isPickable {
            get {
                return false;
            }
        }
        public virtual bool checkCollisions {
            get {
                return false;
            }
        }
        public virtual void _bind(SubMesh subMesh, Effect effect, bool wireframe = false) {
            var engine = this.getScene().getEngine();
            var indexToBind = this._geometry.getIndexBuffer();
            engine.bindBuffers(this._geometry.getVertexBuffer(VertexBuffer.PositionKind).getBuffer(), indexToBind, new Array < object > (3), 3 * 4, this._colorShader.getEffect());
            this._colorShader.setColor3("color", this.color);
        }
        public virtual void _draw(SubMesh subMesh, bool useTriangles, double instancesCount = 0.0) {
            if (!this._geometry || !this._geometry.getVertexBuffers() || !this._geometry.getIndexBuffer()) {
                return;
            }
            var engine = this.getScene().getEngine();
            engine.draw(false, subMesh.indexStart, subMesh.indexCount);
        }
        public virtual void intersects(Ray ray, bool fastCheck = false) {
            return null;
        }
        public virtual void dispose(bool doNotRecurse = false) {
            this._colorShader.dispose();
            base.dispose(doNotRecurse);
        }
    }
}