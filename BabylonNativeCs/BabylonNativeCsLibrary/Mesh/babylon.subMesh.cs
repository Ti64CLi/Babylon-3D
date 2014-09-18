// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.subMesh.cs" company="">
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
    public partial class SubMesh
    {
        /// <summary>
        /// </summary>
        public double _distanceToCamera;

        /// <summary>
        /// </summary>
        public int _id;

        /// <summary>
        /// </summary>
        public Matrix _lastColliderTransformMatrix;

        /// <summary>
        /// </summary>
        public Array<Vector3> _lastColliderWorldVertices;

        /// <summary>
        /// </summary>
        public int _renderId = 0;

        /// <summary>
        /// </summary>
        public Array<Plane> _trianglePlanes;

        /// <summary>
        /// </summary>
        public int indexCount;

        /// <summary>
        /// </summary>
        public int indexStart;

        /// <summary>
        /// </summary>
        public int linesIndexCount;

        /// <summary>
        /// </summary>
        public int materialIndex;

        /// <summary>
        /// </summary>
        public int verticesCount;

        /// <summary>
        /// </summary>
        public int verticesStart;

        /// <summary>
        /// </summary>
        private BoundingInfo _boundingInfo;

        /// <summary>
        /// </summary>
        private WebGLBuffer _linesIndexBuffer;

        /// <summary>
        /// </summary>
        private readonly AbstractMesh _mesh;

        /// <summary>
        /// </summary>
        private readonly Mesh _renderingMesh;

        /// <summary>
        /// </summary>
        /// <param name="materialIndex">
        /// </param>
        /// <param name="verticesStart">
        /// </param>
        /// <param name="verticesCount">
        /// </param>
        /// <param name="indexStart">
        /// </param>
        /// <param name="indexCount">
        /// </param>
        /// <param name="mesh">
        /// </param>
        /// <param name="renderingMesh">
        /// </param>
        /// <param name="createBoundingBox">
        /// </param>
        public SubMesh(
            int materialIndex, 
            int verticesStart, 
            int verticesCount, 
            int indexStart, 
            int indexCount, 
            AbstractMesh mesh, 
            Mesh renderingMesh = null, 
            bool createBoundingBox = true)
        {
            this.materialIndex = materialIndex;
            this.verticesStart = verticesStart;
            this.verticesCount = verticesCount;
            this.indexStart = indexStart;
            this.indexCount = indexCount;

            this._mesh = mesh;
            this._renderingMesh = renderingMesh ?? (Mesh)mesh;
            mesh.subMeshes.Add(this);
            this._id = mesh.subMeshes.Length - 1;
            if (createBoundingBox)
            {
                this.refreshBoundingInfo();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="materialIndex">
        /// </param>
        /// <param name="startIndex">
        /// </param>
        /// <param name="indexCount">
        /// </param>
        /// <param name="mesh">
        /// </param>
        /// <param name="renderingMesh">
        /// </param>
        /// <returns>
        /// </returns>
        public static SubMesh CreateFromIndices(int materialIndex, int startIndex, int indexCount, AbstractMesh mesh, Mesh renderingMesh = null)
        {
            var minVertexIndex = int.MaxValue;
            var maxVertexIndex = -int.MaxValue;
            renderingMesh = renderingMesh ?? (Mesh)mesh;
            var indices = renderingMesh.getIndices();
            for (var index = startIndex; index < startIndex + indexCount; index++)
            {
                var vertexIndex = indices[index];
                if (vertexIndex < minVertexIndex)
                {
                    minVertexIndex = vertexIndex;
                }

                if (vertexIndex > maxVertexIndex)
                {
                    maxVertexIndex = vertexIndex;
                }
            }

            return new SubMesh(materialIndex, minVertexIndex, maxVertexIndex - minVertexIndex + 1, startIndex, indexCount, mesh, renderingMesh);
        }

        /// <summary>
        /// </summary>
        /// <param name="collider">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _checkCollision(Collider collider)
        {
            return this._boundingInfo._checkCollision(collider);
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool canIntersects(Ray ray)
        {
            return ray.intersectsBox(this._boundingInfo.boundingBox);
        }

        /// <summary>
        /// </summary>
        /// <param name="newMesh">
        /// </param>
        /// <param name="newRenderingMesh">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual SubMesh clone(AbstractMesh newMesh, Mesh newRenderingMesh = null)
        {
            var result = new SubMesh(
                this.materialIndex, this.verticesStart, this.verticesCount, this.indexStart, this.indexCount, newMesh, newRenderingMesh, false);
            result._boundingInfo = new BoundingInfo(this._boundingInfo.minimum, this._boundingInfo.maximum);
            return result;
        }

        /// <summary>
        /// </summary>
        public virtual void dispose()
        {
            if (this._linesIndexBuffer != null)
            {
                this._mesh.getScene().getEngine()._releaseBuffer(this._linesIndexBuffer);
                this._linesIndexBuffer = null;
            }

            var index = this._mesh.subMeshes.IndexOf(this);
            this._mesh.subMeshes.RemoveAt(index);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual BoundingInfo getBoundingInfo()
        {
            return this._boundingInfo;
        }

        /// <summary>
        /// </summary>
        /// <param name="indices">
        /// </param>
        /// <param name="engine">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer getLinesIndexBuffer(Array<int> indices, Engine engine)
        {
            if (this._linesIndexBuffer == null)
            {
                var linesIndices = new Array<int>();
                for (var index = this.indexStart; index < this.indexStart + this.indexCount; index += 3)
                {
                    linesIndices.Add(indices[index], indices[index + 1], indices[index + 1], indices[index + 2], indices[index + 2], indices[index]);
                }

                this._linesIndexBuffer = engine.createIndexBuffer(linesIndices);
                this.linesIndexCount = linesIndices.Length;
            }

            return this._linesIndexBuffer;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Material getMaterial()
        {
            var rootMaterial = this._renderingMesh.material;
            if (rootMaterial != null && rootMaterial is MultiMaterial)
            {
                var multiMaterial = (MultiMaterial)rootMaterial;
                return multiMaterial.getSubMaterial(this.materialIndex);
            }

            if (rootMaterial == null)
            {
                return this._mesh.getScene().defaultMaterial;
            }

            return rootMaterial;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual AbstractMesh getMesh()
        {
            return this._mesh;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Mesh getRenderingMesh()
        {
            return this._renderingMesh;
        }

        /// <summary>
        /// </summary>
        /// <param name="ray">
        /// </param>
        /// <param name="positions">
        /// </param>
        /// <param name="indices">
        /// </param>
        /// <param name="fastCheck">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual IntersectionInfo intersects(Ray ray, Array<Vector3> positions, Array<int> indices, bool fastCheck = false)
        {
            IntersectionInfo intersectInfo = null;
            for (var index = this.indexStart; index < this.indexStart + this.indexCount; index += 3)
            {
                var p0 = positions[indices[index]];
                var p1 = positions[indices[index + 1]];
                var p2 = positions[indices[index + 2]];
                var currentIntersectInfo = ray.intersectsTriangle(p0, p1, p2);
                if (currentIntersectInfo != null)
                {
                    if (fastCheck || intersectInfo == null || currentIntersectInfo.distance < intersectInfo.distance)
                    {
                        intersectInfo = currentIntersectInfo;
                        intersectInfo.faceId = index / 3;
                        if (fastCheck)
                        {
                            break;
                        }
                    }
                }
            }

            return intersectInfo;
        }

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            return this._boundingInfo.isInFrustum(frustumPlanes);
        }

        /// <summary>
        /// </summary>
        public virtual void refreshBoundingInfo()
        {
            var data = this._renderingMesh.getVerticesData(VertexBufferKind.PositionKind);
            if (data == null)
            {
                this._boundingInfo = this._mesh._boundingInfo;
                return;
            }

            var indices = this._renderingMesh.getIndices();
            MinMax extend = null;
            if (this.indexStart == 0 && this.indexCount == indices.Length)
            {
                extend = Tools.ExtractMinAndMax(data, this.verticesStart, this.verticesCount);
            }
            else
            {
                extend = Tools.ExtractMinAndMaxIndexed(data, indices, this.indexStart, this.indexCount);
            }

            this._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
        }

        /// <summary>
        /// </summary>
        public virtual void render()
        {
            this._renderingMesh.render(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public virtual void updateBoundingInfo(Matrix world)
        {
            if (this._boundingInfo == null)
            {
                this.refreshBoundingInfo();
            }

            this._boundingInfo._update(world);
        }

        public override bool Equals(object obj)
        {
            var subMesh = obj as SubMesh;
            if (subMesh != null)
            {
                if (subMesh._id != _id)
                {
                    return false;
                }

                return _mesh.Equals(subMesh._mesh);
            }

            return base.Equals(obj);
        }
    }
}