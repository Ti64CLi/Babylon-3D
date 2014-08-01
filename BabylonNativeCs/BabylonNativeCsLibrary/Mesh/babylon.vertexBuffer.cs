using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON {
    public partial class VertexBuffer {
        private Mesh _mesh;
        private Engine _engine;
        private WebGLBuffer _buffer;
        private Array < double > _data;
        private bool _updatable;
        private string _kind;
        private VertexBufferKind _strideSize;
        public VertexBuffer(object engine, Array < double > data, string kind, bool updatable, bool postponeInternalCreation = false) {
            if (engine is Mesh) {
                this._engine = engine.getScene().getEngine();
            } else {
                this._engine = engine;
            }
            this._updatable = updatable;
            this._data = data;
            if (!postponeInternalCreation) {
                this.create();
            }
            this._kind = kind;
            switch (kind) {
                case VertexBuffer.PositionKind:
                    this._strideSize = 3;
                    break;
                case VertexBuffer.NormalKind:
                    this._strideSize = 3;
                    break;
                case VertexBuffer.UVKind:
                    this._strideSize = 2;
                    break;
                case VertexBuffer.UV2Kind:
                    this._strideSize = 2;
                    break;
                case VertexBuffer.ColorKind:
                    this._strideSize = 3;
                    break;
                case VertexBuffer.MatricesIndicesKind:
                    this._strideSize = 4;
                    break;
                case VertexBuffer.MatricesWeightsKind:
                    this._strideSize = 4;
                    break;
            }
        }
        public virtual bool isUpdatable() {
            return this._updatable;
        }
        public virtual Array < double > getData() {
            return this._data;
        }
        public virtual WebGLBuffer getBuffer() {
            return this._buffer;
        }
        public virtual VertexBufferKind getStrideSize()
        {
            return this._strideSize;
        }
        public virtual void create(Array < double > data = null) {
            if (!data && this._buffer) {
                return;
            }
            data = data || this._data;
            if (!this._buffer) {
                if (this._updatable) {
                    this._buffer = this._engine.createDynamicVertexBuffer(data.Length * 4);
                } else {
                    this._buffer = this._engine.createVertexBuffer(data);
                }
            }
            if (this._updatable) {
                this._engine.updateDynamicVertexBuffer(this._buffer, data);
                this._data = data;
            }
        }
        public virtual void update(Array < double > data) {
            this.create(data);
        }
        public virtual void dispose() {
            if (!this._buffer) {
                return;
            }
            if (this._engine._releaseBuffer(this._buffer)) {
                this._buffer = null;
            }
        }
        private static string _PositionKind = "position";
        private static string _NormalKind = "normal";
        private static string _UVKind = "uv";
        private static string _UV2Kind = "uv2";
        private static string _ColorKind = "color";
        private static string _MatricesIndicesKind = "matricesIndices";
        private static string _MatricesWeightsKind = "matricesWeights";
        public static string PositionKind {
            get {
                return VertexBuffer._PositionKind;
            }
        }
        public static string NormalKind {
            get {
                return VertexBuffer._NormalKind;
            }
        }
        public static string UVKind {
            get {
                return VertexBuffer._UVKind;
            }
        }
        public static string UV2Kind {
            get {
                return VertexBuffer._UV2Kind;
            }
        }
        public static string ColorKind {
            get {
                return VertexBuffer._ColorKind;
            }
        }
        public static string MatricesIndicesKind {
            get {
                return VertexBuffer._MatricesIndicesKind;
            }
        }
        public static string MatricesWeightsKind {
            get {
                return VertexBuffer._MatricesWeightsKind;
            }
        }
    }
}