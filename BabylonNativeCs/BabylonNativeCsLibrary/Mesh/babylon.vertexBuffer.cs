// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.vertexBuffer.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using Web;

    /// <summary>
    /// </summary>
    public partial class VertexBuffer
    {
        /// <summary>
        /// </summary>
        public static string ColorKind = "color";

        /// <summary>
        /// </summary>
        public static string MatricesIndicesKind = "matricesIndices";

        /// <summary>
        /// </summary>
        public static string MatricesWeightsKind = "matricesWeights";

        /// <summary>
        /// </summary>
        public static string NormalKind = "normal";

        /// <summary>
        /// </summary>
        public static string PositionKind = "position";

        /// <summary>
        /// </summary>
        public static string UV2Kind = "uv2";

        /// <summary>
        /// </summary>
        public static string UVKind = "uv";

        /// <summary>
        /// </summary>
        public WebGLBuffer _buffer;

        /// <summary>
        /// </summary>
        private Array<double> _data;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private readonly VertexBufferKind _kind;

        /// <summary>
        /// </summary>
        private readonly int _strideSize;

        /// <summary>
        /// </summary>
        private readonly bool _updatable;

        /// <summary>
        /// </summary>
        /// <param name="engine">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="kind">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <param name="postponeInternalCreation">
        /// </param>
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

        /// <summary>
        /// </summary>
        public VertexBufferKind Kind
        {
            get
            {
                return this._kind;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
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

        /// <summary>
        /// </summary>
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

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer getBuffer()
        {
            return this._buffer;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<double> getData()
        {
            return this._data;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getStrideSize()
        {
            return this._strideSize;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isUpdatable()
        {
            return this._updatable;
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        public virtual void update(Array<double> data)
        {
            this.create(data);
        }
    }
}