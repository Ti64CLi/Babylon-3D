using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class Geometry : IGetSetVerticesData
    {
        public int id;
        public double delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NONE;
        public string delayLoadingFile;
        private Scene _scene;
        private Engine _engine;
        private Array<Mesh> _meshes;
        private int _totalVertices = 0;
        private Array<int> _indices = new Array<int>();
        private Map<VertexBufferKind, VertexBuffer> _vertexBuffers;
        public Array<VertexBufferKind> _delayInfo;
        private WebGLBuffer _indexBuffer;
        public BoundingInfo _boundingInfo;
        public System.Action<object, object> _delayLoadingFunction;
        int currentCSGMeshId0;

        private static int nextId = 0;

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
        public virtual Scene getScene()
        {
            return this._scene;
        }
        public virtual Engine getEngine()
        {
            return this._engine;
        }
        public virtual bool isReady()
        {
            return this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADED || this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_NONE;
        }
        public virtual void setAllVerticesData(VertexData vertexData, bool updatable = false)
        {
            vertexData.applyToGeometry(this, updatable);
        }
        public virtual void setVerticesData(VertexBufferKind kind, Array<double> data, bool updatable = false)
        {
            this._vertexBuffers = this._vertexBuffers ?? new Map<VertexBufferKind, VertexBuffer>();
            if (this._vertexBuffers.ContainsKey(kind))
            {
                this._vertexBuffers[kind].dispose();
            }
            this._vertexBuffers[kind] = new VertexBuffer(this._engine, data, kind, updatable, this._meshes.Length == 0);
            if (kind == BABYLON.VertexBufferKind.PositionKind)
            {
                var stride = this._vertexBuffers[kind].getStrideSize();
                this._totalVertices = data.Length / stride;
                var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this._totalVertices);
                var meshes = this._meshes;
                var numOfMeshes = meshes.Length;
                for (var index = 0; index < numOfMeshes; index++)
                {
                    var mesh = meshes[index];
                    mesh._resetPointsArrayCache();
                    mesh._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
                    mesh._createGlobalSubMesh();
                    mesh.computeWorldMatrix(true);
                }
            }
        }

        public virtual void updateVerticesData(VertexBufferKind kind, Array<double> data, bool updateExtends = false, bool makeItUnique = false)
        {
            var vertexBuffer = this.getVertexBuffer(kind);
            if (vertexBuffer == null)
            {
                return;
            }
            vertexBuffer.update(data);
            if (kind == BABYLON.VertexBufferKind.PositionKind)
            {
                MinMax extend = null;
                if (updateExtends)
                {
                    var stride = vertexBuffer.getStrideSize();
                    this._totalVertices = data.Length / stride;
                    extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this._totalVertices);
                }
                var meshes = this._meshes;
                var numOfMeshes = meshes.Length;
                for (var index = 0; index < numOfMeshes; index++)
                {
                    var mesh = meshes[index];
                    mesh._resetPointsArrayCache();
                    if (updateExtends)
                    {
                        mesh._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
                    }
                }
            }
        }
        public virtual int getTotalVertices()
        {
            if (!this.isReady())
            {
                return 0;
            }
            return this._totalVertices;
        }
        public virtual Array<double> getVerticesData(VertexBufferKind kind)
        {
            var vertexBuffer = this.getVertexBuffer(kind);
            if (vertexBuffer == null)
            {
                return null;
            }
            return vertexBuffer.getData();
        }
        public virtual VertexBuffer getVertexBuffer(VertexBufferKind kind)
        {
            if (!this.isReady())
            {
                return null;
            }
            return this._vertexBuffers[kind];
        }
        public virtual Array<VertexBuffer> getVertexBuffers()
        {
            if (!this.isReady())
            {
                return null;
            }

            var array = new Array<VertexBuffer>(this._vertexBuffers.Values.Count);
            array.AddRange(this._vertexBuffers.Values);
            return array;
        }
        public virtual bool isVerticesDataPresent(VertexBufferKind kind)
        {
            if (this._vertexBuffers == null)
            {
                if (this._delayInfo != null)
                {
                    return this._delayInfo.indexOf(kind) != -1;
                }
                return false;
            }
            return this._vertexBuffers[kind] != null;
        }
        public virtual Array<VertexBufferKind> getVerticesDataKinds()
        {
            var result = new Array<VertexBufferKind>();
            if (this._vertexBuffers == null && this._delayInfo != null)
            {
                foreach (var kind in this._delayInfo)
                {
                    result.push(kind);
                }
            }
            else
            {
                foreach (var kind in this._vertexBuffers.Keys)
                {
                    result.push(kind);
                }
            }
            return result;
        }
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
        public virtual int getTotalIndices()
        {
            if (!this.isReady())
            {
                return 0;
            }
            return this._indices.Length;
        }
        public virtual Array<int> getIndices()
        {
            if (!this.isReady())
            {
                return null;
            }
            return this._indices;
        }
        public virtual WebGLBuffer getIndexBuffer()
        {
            if (!this.isReady())
            {
                return null;
            }
            return this._indexBuffer;
        }
        public virtual void releaseForMesh(Mesh mesh, bool shouldDispose = false)
        {
            var meshes = this._meshes;
            var index = meshes.indexOf(mesh);
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
            meshes.push(mesh);
            if (this.isReady())
            {
                this._applyToMesh(mesh);
            }
            else
            {
                mesh._boundingInfo = this._boundingInfo;
            }
        }
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
                if (kind == BABYLON.VertexBufferKind.PositionKind)
                {
                    mesh._resetPointsArrayCache();
                    var extend = BABYLON.Tools.ExtractMinAndMax(this._vertexBuffers[kind].getData(), 0, this._totalVertices);
                    mesh._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
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
        public virtual void load(Scene scene, System.Action onLoaded = null)
        {
            if (this.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_LOADING)
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
            this.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_LOADING;
            scene._addPendingData(this);
            BABYLON.Tools.LoadFile(this.delayLoadingFile, (byte[] data) =>
            {
                this._delayLoadingFunction(data/*JSON.parse(data)*/, this);
                this.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_LOADED;
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
            }, (o) => { }, scene.database);
        }
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
            this.delayLoadState = BABYLON.Engine.DELAYLOADSTATE_NONE;
            this.delayLoadingFile = null;
            this._delayLoadingFunction = null;
            this._delayInfo = new Array<VertexBufferKind>();
            this._boundingInfo = null;
            var geometries = this._scene.getGeometries();
            var index2 = geometries.indexOf(this);
            if (index2 > -1)
            {
                geometries.RemoveAt(index2);
            }
        }
        public virtual Geometry copy(int id)
        {
            var vertexData = new BABYLON.VertexData();
            vertexData.indices = new Array<int>();
            var indices = this.getIndices();
            for (var index = 0; index < indices.Length; index++)
            {
                vertexData.indices.push(indices[index]);
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
            var geometry = new BABYLON.Geometry(id, this._scene, vertexData, updatable, null);
            geometry.delayLoadState = this.delayLoadState;
            geometry.delayLoadingFile = this.delayLoadingFile;
            geometry._delayLoadingFunction = this._delayLoadingFunction;
            foreach (var kind in this._delayInfo)
            {
                geometry._delayInfo = geometry._delayInfo ?? new Array<VertexBufferKind>();
                geometry._delayInfo.push(kind);
            }
            var extend = BABYLON.Tools.ExtractMinAndMax(this.getVerticesData(BABYLON.VertexBufferKind.PositionKind), 0, this.getTotalVertices());
            geometry._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
            return geometry;
        }
        public static Geometry ExtractFromMesh(Mesh mesh, int id)
        {
            var geometry = mesh._geometry;
            if (geometry == null)
            {
                return null;
            }
            return geometry.copy(id);
        }
        public static int RandomId()
        {
            return ++nextId;
        }
    }
}