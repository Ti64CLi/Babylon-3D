using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class SubMesh
    {
        public int linesIndexCount;
        private AbstractMesh _mesh;
        private Mesh _renderingMesh;
        private BoundingInfo _boundingInfo;
        private WebGLBuffer _linesIndexBuffer;
        public Array<Vector3> _lastColliderWorldVertices;
        public Array<Plane> _trianglePlanes;
        public Matrix _lastColliderTransformMatrix;
        public double _renderId = 0;
        public double _distanceToCamera;
        public int _id;
        public int materialIndex;
        public int verticesStart;
        public int verticesCount;
        public int indexStart;
        public int indexCount;
        public SubMesh(int materialIndex, int verticesStart, int verticesCount, int indexStart, int indexCount, AbstractMesh mesh, Mesh renderingMesh = null, bool createBoundingBox = true)
        {
            this.materialIndex = materialIndex;
            this.verticesStart = verticesCount;
            this.indexStart = indexStart;
            this.indexCount = indexCount;

            this._mesh = mesh;
            this._renderingMesh = renderingMesh ?? (Mesh)mesh;
            mesh.subMeshes.push(this);
            this._id = mesh.subMeshes.Length - 1;
            if (createBoundingBox)
            {
                this.refreshBoundingInfo();
            }
        }
        public virtual BoundingInfo getBoundingInfo()
        {
            return this._boundingInfo;
        }
        public virtual AbstractMesh getMesh()
        {
            return this._mesh;
        }
        public virtual Mesh getRenderingMesh()
        {
            return this._renderingMesh;
        }
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
                extend = BABYLON.Tools.ExtractMinAndMax(data, this.verticesStart, this.verticesCount);
            }
            else
            {
                extend = BABYLON.Tools.ExtractMinAndMaxIndexed(data, indices, this.indexStart, this.indexCount);
            }
            this._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
        }
        public virtual bool _checkCollision(Collider collider)
        {
            return this._boundingInfo._checkCollision(collider);
        }
        public virtual void updateBoundingInfo(Matrix world)
        {
            if (this._boundingInfo == null)
            {
                this.refreshBoundingInfo();
            }
            this._boundingInfo._update(world);
        }
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            return this._boundingInfo.isInFrustum(frustumPlanes);
        }
        public virtual void render()
        {
            this._renderingMesh.render(this);
        }
        public virtual WebGLBuffer getLinesIndexBuffer(Array<int> indices, Engine engine)
        {
            if (this._linesIndexBuffer == null)
            {
                var linesIndices = new Array<int>();
                for (var index = this.indexStart; index < this.indexStart + this.indexCount; index += 3)
                {
                    linesIndices.push(indices[index], indices[index + 1], indices[index + 1], indices[index + 2], indices[index + 2], indices[index]);
                }
                this._linesIndexBuffer = engine.createIndexBuffer(linesIndices);
                this.linesIndexCount = linesIndices.Length;
            }
            return this._linesIndexBuffer;
        }
        public virtual bool canIntersects(Ray ray)
        {
            return ray.intersectsBox(this._boundingInfo.boundingBox);
        }
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
        public virtual SubMesh clone(AbstractMesh newMesh, Mesh newRenderingMesh = null)
        {
            var result = new SubMesh(this.materialIndex, this.verticesStart, this.verticesCount, this.indexStart, this.indexCount, newMesh, newRenderingMesh, false);
            result._boundingInfo = new BoundingInfo(this._boundingInfo.minimum, this._boundingInfo.maximum);
            return result;
        }
        public virtual void dispose()
        {
            if (this._linesIndexBuffer != null)
            {
                this._mesh.getScene().getEngine()._releaseBuffer(this._linesIndexBuffer);
                this._linesIndexBuffer = null;
            }
            var index = this._mesh.subMeshes.indexOf(this);
            this._mesh.subMeshes.RemoveAt(index);
        }
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
                    minVertexIndex = vertexIndex;
                if (vertexIndex > maxVertexIndex)
                    maxVertexIndex = vertexIndex;
            }
            return new BABYLON.SubMesh(materialIndex, minVertexIndex, maxVertexIndex - minVertexIndex + 1, startIndex, indexCount, mesh, renderingMesh);
        }
    }
}