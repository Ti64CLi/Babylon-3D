// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.geometry.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using Web;

    /// <summary>
    /// </summary>
    public partial class Geometry : IGetSetVerticesData
    {
        /// <summary>
        /// </summary>
        public BoundingInfo _boundingInfo;

        /// <summary>
        /// </summary>
        public Array<VertexBufferKind> _delayInfo;

        /// <summary>
        /// </summary>
        public Action<object, object> _delayLoadingFunction;

        /// <summary>
        /// </summary>
        public double delayLoadState = Engine.DELAYLOADSTATE_NONE;

        /// <summary>
        /// </summary>
        public string delayLoadingFile;

        /// <summary>
        /// </summary>
        public int id;

        /// <summary>
        /// </summary>
        private static int nextId;

        /// <summary>
        /// </summary>
        private readonly Engine _engine;

        /// <summary>
        /// </summary>
        private WebGLBuffer _indexBuffer;

        /// <summary>
        /// </summary>
        private Array<int> _indices = new Array<int>();

        /// <summary>
        /// </summary>
        private Array<Mesh> _meshes;

        /// <summary>
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        /// </summary>
        private int _totalVertices;

        /// <summary>
        /// </summary>
        private Map<VertexBufferKind, VertexBuffer> _vertexBuffers;

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="vertexData">
        /// </param>
        /// <param name="updatable">
        /// </param>
        /// <param name="mesh">
        /// </param>
        public Geometry(int id, Scene scene, VertexData vertexData = null, bool updatable = false, Mesh mesh = null)
        {
            this.id = id;
            this._engine = scene.getEngine();
            this._meshes = new Array<Mesh>();
            this._scene = scene;
            if (vertexData != null)
            {
                this.setAllVerticesData(vertexData, updatable);
            }
            else
            {
                this._totalVertices = 0;
                this._indices = new Array<int>();
            }

            if (mesh != null)
            {
                this.applyToMesh(mesh);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public static Geometry ExtractFromMesh(Mesh mesh, int id)
        {
            var geometry = mesh._geometry;
            if (geometry == null)
            {
                return null;
            }

            return geometry.copy(id);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static int RandomId()
        {
            return ++nextId;
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        public virtual void applyToMesh(Mesh mesh)
        {
            if (mesh._geometry == this)
            {
                return;
            }

            var previousGeometry = mesh._geometry;
            if (previousGeometry != null)
            {
                previousGeometry.releaseForMesh(mesh);
            }

            var meshes = this._meshes;
            mesh._geometry = this;
            this._scene.pushGeometry(this);
            meshes.Add(mesh);
            if (this.isReady())
            {
                this._applyToMesh(mesh);
            }
            else
            {
                mesh._boundingInfo = this._boundingInfo;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Geometry copy(int id)
        {
            var vertexData = new VertexData();
            vertexData.indices = new Array<int>();
            var indices = this.getIndices();
            for (var index = 0; index < indices.Length; index++)
            {
                vertexData.indices.Add(indices[index]);
            }

            var updatable = false;
            var stopChecking = false;
            foreach (var kind in this._vertexBuffers.Keys)
            {
                vertexData.set(this.getVerticesData(kind), kind);
                if (!stopChecking)
                {
                    updatable = this.getVertexBuffer(kind).isUpdatable();
                    stopChecking = !updatable;
                }
            }

            var geometry = new Geometry(id, this._scene, vertexData, updatable, null);
            geometry.delayLoadState = this.delayLoadState;
            geometry.delayLoadingFile = this.delayLoadingFile;
            geometry._delayLoadingFunction = this._delayLoadingFunction;
            foreach (var kind in this._delayInfo)
            {
                geometry._delayInfo = geometry._delayInfo ?? new Array<VertexBufferKind>();
                geometry._delayInfo.Add(kind);
            }

            var extend = Tools.ExtractMinAndMax(this.getVerticesData(VertexBufferKind.PositionKind), 0, this.getTotalVertices());
            geometry._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
            return geometry;
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            var meshes = this._meshes;
            var numOfMeshes = meshes.Length;
            for (var index = 0; index < numOfMeshes; index++)
            {
                this.releaseForMesh(meshes[index]);
            }

            this._meshes = new Array<Mesh>();
            foreach (var kind in this._vertexBuffers.Keys)
            {
                this._vertexBuffers[kind].dispose();
            }

            this._vertexBuffers.Clear();
            this._totalVertices = 0;
            if (this._indexBuffer != null)
            {
                this._engine._releaseBuffer(this._indexBuffer);
            }

            this._indexBuffer = null;
            this._indices = new Array<int>();
            this.delayLoadState = Engine.DELAYLOADSTATE_NONE;
            this.delayLoadingFile = null;
            this._delayLoadingFunction = null;
            this._delayInfo = new Array<VertexBufferKind>();
            this._boundingInfo = null;
            var geometries = this._scene.getGeometries();
            var index2 = geometries.IndexOf(this);
            if (index2 > -1)
            {
                geometries.RemoveAt(index2);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Engine getEngine()
        {
            return this._engine;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer getIndexBuffer()
        {
            if (!this.isReady())
            {
                return null;
            }

            return this._indexBuffer;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<int> getIndices()
        {
            if (!this.isReady())
            {
                return null;
            }

            return this._indices;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Scene getScene()
        {
            return this._scene;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getTotalIndices()
        {
            if (!this.isReady())
            {
                return 0;
            }

            return this._indices.Length;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getTotalVertices()
        {
            if (!this.isReady())
            {
                return 0;
            }

            return this._totalVertices;
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual VertexBuffer getVertexBuffer(VertexBufferKind kind)
        {
            if (!this.isReady())
            {
                return null;
            }

            return this._vertexBuffers[kind];
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<VertexBuffer> getVertexBuffers()
        {
            if (!this.isReady())
            {
                return null;
            }

            var array = new Array<VertexBuffer>();
            array.AddRange(this._vertexBuffers.Values);
            return array;
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<double> getVerticesData(VertexBufferKind kind)
        {
            var vertexBuffer = this.getVertexBuffer(kind);
            if (vertexBuffer == null)
            {
                return null;
            }

            return vertexBuffer.getData();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<VertexBufferKind> getVerticesDataKinds()
        {
            var result = new Array<VertexBufferKind>();
            if (this._vertexBuffers == null && this._delayInfo != null)
            {
                foreach (var kind in this._delayInfo)
                {
                    result.Add(kind);
                }
            }
            else
            {
                foreach (var kind in this._vertexBuffers.Keys)
                {
                    result.Add(kind);
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool isReady()
        {
            return this.delayLoadState == Engine.DELAYLOADSTATE_LOADED || this.delayLoadState == Engine.DELAYLOADSTATE_NONE;
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isVerticesDataPresent(VertexBufferKind kind)
        {
            if (this._vertexBuffers == null)
            {
                if (this._delayInfo != null)
                {
                    return this._delayInfo.IndexOf(kind) != -1;
                }

                return false;
            }

            return this._vertexBuffers[kind] != null;
        }

        /// <summary>
        /// </summary>
        /// <param name="scene">
        /// </param>
        /// <param name="onLoaded">
        /// </param>
        public virtual void load(Scene scene, System.Action onLoaded = null)
        {
            if (this.delayLoadState == Engine.DELAYLOADSTATE_LOADING)
            {
                return;
            }

            if (this.isReady())
            {
                if (onLoaded != null)
                {
                    onLoaded();
                }

                return;
            }

            this.delayLoadState = Engine.DELAYLOADSTATE_LOADING;
            scene._addPendingData(this);
            Tools.LoadFile(
                this.delayLoadingFile, 
                (byte[] data) =>
                    {
                        this._delayLoadingFunction(data /*JSON.parse(data)*/, this);
                        this.delayLoadState = Engine.DELAYLOADSTATE_LOADED;
                        this._delayInfo = new Array<VertexBufferKind>();
                        scene._removePendingData(this);
                        var meshes = this._meshes;
                        var numOfMeshes = meshes.Length;
                        for (var index = 0; index < numOfMeshes; index++)
                        {
                            this._applyToMesh(meshes[index]);
                        }

                        if (onLoaded != null)
                        {
                            onLoaded();
                        }
                    }, 
                (o) => { }, 
                scene.database);
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <param name="shouldDispose">
        /// </param>
        public virtual void releaseForMesh(Mesh mesh, bool shouldDispose = false)
        {
            var meshes = this._meshes;
            var index = meshes.IndexOf(mesh);
            if (index == -1)
            {
                return;
            }

            foreach (var kind in this._vertexBuffers.Keys)
            {
                this._vertexBuffers[kind].dispose();
            }

            if (this._indexBuffer != null && this._engine._releaseBuffer(this._indexBuffer))
            {
                this._indexBuffer = null;
            }

            meshes.RemoveAt(index);
            mesh._geometry = null;
            if (meshes.Length == 0 && shouldDispose)
            {
                this.dispose();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexData">
        /// </param>
        /// <param name="updatable">
        /// </param>
        public virtual void setAllVerticesData(VertexData vertexData, bool updatable = false)
        {
            vertexData.applyToGeometry(this, updatable);
        }

        /// <summary>
        /// </summary>
        /// <param name="indices">
        /// </param>
        public virtual void setIndices(Array<int> indices)
        {
            if (this._indexBuffer != null)
            {
                this._engine._releaseBuffer(this._indexBuffer);
            }

            this._indices = indices;
            if (this._meshes.Length != 0 && this._indices != null)
            {
                this._indexBuffer = this._engine.createIndexBuffer(this._indices);
            }

            var meshes = this._meshes;
            var numOfMeshes = meshes.Length;
            for (var index = 0; index < numOfMeshes; index++)
            {
                meshes[index]._createGlobalSubMesh();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updatable">
        /// </param>
        public virtual void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false)
        {
            this._vertexBuffers = this._vertexBuffers ?? new Map<VertexBufferKind, VertexBuffer>();
            if (this._vertexBuffers.ContainsKey(kind))
            {
                this._vertexBuffers[kind].dispose();
            }

            this._vertexBuffers[kind] = new VertexBuffer(this._engine, data, kind, updatable, this._meshes.Length == 0);
            if (kind == VertexBufferKind.PositionKind)
            {
                var stride = this._vertexBuffers[kind].getStrideSize();
                this._totalVertices = data.Length / stride;
                var extend = Tools.ExtractMinAndMax(data, 0, this._totalVertices);
                var meshes = this._meshes;
                var numOfMeshes = meshes.Length;
                for (var index = 0; index < numOfMeshes; index++)
                {
                    var mesh = meshes[index];
                    mesh._resetPointsArrayCache();
                    mesh._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
                    mesh._createGlobalSubMesh();
                    mesh.computeWorldMatrix(true);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="updateExtends">
        /// </param>
        /// <param name="makeItUnique">
        /// </param>
        public virtual void updateVerticesData(VertexBufferKind kind, Array<double> data, bool updateExtends = false, bool makeItUnique = false)
        {
            var vertexBuffer = this.getVertexBuffer(kind);
            if (vertexBuffer == null)
            {
                return;
            }

            vertexBuffer.update(data);
            if (kind == VertexBufferKind.PositionKind)
            {
                MinMax extend = null;
                if (updateExtends)
                {
                    var stride = vertexBuffer.getStrideSize();
                    this._totalVertices = data.Length / stride;
                    extend = Tools.ExtractMinAndMax(data, 0, this._totalVertices);
                }

                var meshes = this._meshes;
                var numOfMeshes = meshes.Length;
                for (var index = 0; index < numOfMeshes; index++)
                {
                    var mesh = meshes[index];
                    mesh._resetPointsArrayCache();
                    if (updateExtends)
                    {
                        mesh._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        private void _applyToMesh(Mesh mesh)
        {
            var numOfMeshes = this._meshes.Length;
            foreach (var kind in this._vertexBuffers.Keys)
            {
                if (numOfMeshes == 1)
                {
                    this._vertexBuffers[kind].create();
                }

                this._vertexBuffers[kind]._buffer.references = numOfMeshes;
                if (kind == VertexBufferKind.PositionKind)
                {
                    mesh._resetPointsArrayCache();
                    var extend = Tools.ExtractMinAndMax(this._vertexBuffers[kind].getData(), 0, this._totalVertices);
                    mesh._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
                    mesh._createGlobalSubMesh();
                }
            }

            if (numOfMeshes == 1 && this._indices != null)
            {
                this._indexBuffer = this._engine.createIndexBuffer(this._indices);
            }

            if (this._indexBuffer != null)
            {
                this._indexBuffer.references = numOfMeshes;
            }
        }
    }
}