using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class VertexBuffer
    {
        private Engine _engine;
        public WebGLBuffer _buffer;
        private Array<double> _data;
        private bool _updatable;
        private VertexBufferKind _kind;
        private int _strideSize;
        public VertexBuffer(Engine engine, Array<double> data, VertexBufferKind kind, bool updatable, bool postponeInternalCreation = false)
        {
            this._engine = engine;
            this._updatable = updatable;
            this._data = data;
            if (!postponeInternalCreation)
            {
                this.create();
            }
            this._kind = kind;
            switch (kind)
            {
                case VertexBufferKind.PositionKind:
                    this._strideSize = 3;
                    break;
                case VertexBufferKind.NormalKind:
                    this._strideSize = 3;
                    break;
                case VertexBufferKind.UVKind:
                    this._strideSize = 2;
                    break;
                case VertexBufferKind.UV2Kind:
                    this._strideSize = 2;
                    break;
                case VertexBufferKind.ColorKind:
                    this._strideSize = 3;
                    break;
                case VertexBufferKind.MatricesIndicesKind:
                    this._strideSize = 4;
                    break;
                case VertexBufferKind.MatricesWeightsKind:
                    this._strideSize = 4;
                    break;
            }
        }

        public VertexBufferKind Kind
        {
            get { return _kind; }
        }
        public virtual bool isUpdatable()
        {
            return this._updatable;
        }
        public virtual Array<double> getData()
        {
            return this._data;
        }
        public virtual WebGLBuffer getBuffer()
        {
            return this._buffer;
        }
        public virtual int getStrideSize()
        {
            return this._strideSize;
        }
        public virtual void create(Array<double> data = null)
        {
            if (data == null && this._buffer != null)
            {
                return;
            }
            data = data ?? this._data;
            if (this._buffer == null)
            {
                if (this._updatable)
                {
                    this._buffer = this._engine.createDynamicVertexBuffer(data.Length * 4);
                }
                else
                {
                    this._buffer = this._engine.createVertexBuffer(data);
                }
            }
            if (this._updatable)
            {
                this._engine.updateDynamicVertexBuffer(this._buffer, data);
                this._data = data;
            }
        }
        public virtual void update(Array<double> data)
        {
            this.create(data);
        }
        public virtual void dispose()
        {
            if (this._buffer == null)
            {
                return;
            }
            if (this._engine._releaseBuffer(this._buffer))
            {
                this._buffer = null;
            }
        }

        public static string PositionKind = "position";
        public static string NormalKind = "normal";
        public static string UVKind = "uv";
        public static string UV2Kind = "uv2";
        public static string ColorKind = "color";
        public static string MatricesIndicesKind = "matricesIndices";
        public static string MatricesWeightsKind = "matricesWeights";
    }
}