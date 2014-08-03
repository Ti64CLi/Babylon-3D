using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class InstancedMesh : AbstractMesh
    {
        private Mesh _sourceMesh;
        public InstancedMesh(string name, Mesh source)
            : base(name, source.getScene())
        {
            source.instances.push(this);
            this._sourceMesh = source;
            this.position.copyFrom(source.position);
            this.rotation.copyFrom(source.rotation);
            this.scaling.copyFrom(source.scaling);
            if (source.rotationQuaternion != null)
            {
                this.rotationQuaternion = source.rotationQuaternion.clone();
            }
            this.infiniteDistance = source.infiniteDistance;
            this.setPivotMatrix(source.getPivotMatrix());
            this.refreshBoundingInfo();
            this._syncSubMeshes();
        }
        public virtual bool receiveShadows
        {
            get
            {
                return this._sourceMesh.receiveShadows;
            }
        }
        public virtual Material material
        {
            get
            {
                return this._sourceMesh.material;
            }
        }
        public virtual double visibility
        {
            get
            {
                return this._sourceMesh.visibility;
            }
        }
        public virtual Skeleton skeleton
        {
            get
            {
                return this._sourceMesh.skeleton;
            }
        }
        public virtual double getTotalVertices()
        {
            return this._sourceMesh.getTotalVertices();
        }
        public virtual Mesh sourceMesh
        {
            get
            {
                return this._sourceMesh;
            }
        }
        public virtual Array<double> getVerticesData(VertexBufferKind kind)
        {
            return this._sourceMesh.getVerticesData(kind);
        }
        public virtual bool isVerticesDataPresent(VertexBufferKind kind)
        {
            return this._sourceMesh.isVerticesDataPresent(kind);
        }
        public virtual Array<int> getIndices()
        {
            return this._sourceMesh.getIndices();
        }
        public virtual Array<Vector3> _positions
        {
            get
            {
                return this._sourceMesh._positions;
            }
        }
        public virtual void refreshBoundingInfo()
        {
            var data = this._sourceMesh.getVerticesData(BABYLON.VertexBufferKind.PositionKind);
            if (data != null)
            {
                var extend = BABYLON.Tools.ExtractMinAndMax(data, 0, this._sourceMesh.getTotalVertices());
                this._boundingInfo = new BABYLON.BoundingInfo(extend.minimum, extend.maximum);
            }
            this._updateBoundingInfo();
        }
        public virtual void _activate(int renderId)
        {
            this.sourceMesh._registerInstanceForRenderId(this, renderId);
        }
        public virtual void _syncSubMeshes()
        {
            this.releaseSubMeshes();
            for (var index = 0; index < this._sourceMesh.subMeshes.Length; index++)
            {
                this._sourceMesh.subMeshes[index].clone(this, this._sourceMesh);
            }
        }
        public virtual bool _generatePointsArray()
        {
            return this._sourceMesh._generatePointsArray();
        }
        public virtual InstancedMesh clone(string name, Node newParent, bool doNotCloneChildren = false)
        {
            var result = this._sourceMesh.createInstance(name);
            BABYLON.Tools.DeepCopy(this, result, new Array<string>("name"), new Array<string>());
            this.refreshBoundingInfo();
            if (newParent != null)
            {
                result.parent = newParent;
            }
            if (!doNotCloneChildren)
            {
                for (var index = 0; index < this.getScene().meshes.Length; index++)
                {
                    var mesh = this.getScene().meshes[index];
                    if (mesh.parent == this)
                    {
                        mesh.clone(mesh.name, result);
                    }
                }
            }
            result.computeWorldMatrix(true);
            return result;
        }
        public override void dispose(bool doNotRecurse = false)
        {
            var index = this._sourceMesh.instances.indexOf(this);
            this._sourceMesh.instances.RemoveAt(index);
            base.dispose(doNotRecurse);
        }
    }
}