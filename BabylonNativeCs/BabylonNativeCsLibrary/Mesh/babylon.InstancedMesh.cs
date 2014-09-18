// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.InstancedMesh.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class InstancedMesh : AbstractMesh
    {
        /// <summary>
        /// </summary>
        private readonly Mesh _sourceMesh;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="source">
        /// </param>
        public InstancedMesh(string name, Mesh source)
            : base(name, source.getScene())
        {
            source.instances.Add(this);
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

        /// <summary>
        /// </summary>
        public override Array<Vector3> _positions
        {
            get
            {
                return this._sourceMesh._positions;
            }
        }

        /// <summary>
        /// </summary>
        public override Material material
        {
            get
            {
                return this._sourceMesh.material;
            }
        }

        /// <summary>
        /// </summary>
        public override bool receiveShadows
        {
            get
            {
                return this._sourceMesh.receiveShadows;
            }
        }

        /// <summary>
        /// </summary>
        public override Skeleton skeleton
        {
            get
            {
                return this._sourceMesh.skeleton;
            }
        }

        /// <summary>
        /// </summary>
        public virtual Mesh sourceMesh
        {
            get
            {
                return this._sourceMesh;
            }
        }

        /// <summary>
        /// </summary>
        public override double visibility
        {
            get
            {
                return this._sourceMesh.visibility;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="renderId">
        /// </param>
        public override void _activate(int renderId)
        {
            this.sourceMesh._registerInstanceForRenderId(this, renderId);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override bool _generatePointsArray()
        {
            return this._sourceMesh._generatePointsArray();
        }

        /// <summary>
        /// </summary>
        public virtual void _syncSubMeshes()
        {
            this.releaseSubMeshes();
            for (var index = 0; index < this._sourceMesh.subMeshes.Length; index++)
            {
                this._sourceMesh.subMeshes[index].clone(this, this._sourceMesh);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="newParent">
        /// </param>
        /// <param name="doNotCloneChildren">
        /// </param>
        /// <returns>
        /// </returns>
        public override AbstractMesh clone(string name, Node newParent, bool doNotCloneChildren = false)
        {
            var result = this._sourceMesh.createInstance(name);
            Tools.DeepCopy(this, result, new Array<string>("name"), new Array<string>());
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

        /// <summary>
        /// </summary>
        /// <param name="doNotRecurse">
        /// </param>
        public override void dispose(bool doNotRecurse = false)
        {
            var index = this._sourceMesh.instances.IndexOf(this);
            this._sourceMesh.instances.RemoveAt(index);
            base.dispose(doNotRecurse);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override Array<int> getIndices()
        {
            return this._sourceMesh.getIndices();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public override int getTotalVertices()
        {
            return this._sourceMesh.getTotalVertices();
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public override Array<double> getVerticesData(VertexBufferKind kind)
        {
            return this._sourceMesh.getVerticesData(kind);
        }

        /// <summary>
        /// </summary>
        /// <param name="kind">
        /// </param>
        /// <returns>
        /// </returns>
        public override bool isVerticesDataPresent(VertexBufferKind kind)
        {
            return this._sourceMesh.isVerticesDataPresent(kind);
        }

        /// <summary>
        /// </summary>
        public virtual void refreshBoundingInfo()
        {
            var data = this._sourceMesh.getVerticesData(VertexBufferKind.PositionKind);
            if (data != null)
            {
                var extend = Tools.ExtractMinAndMax(data, 0, this._sourceMesh.getTotalVertices());
                this._boundingInfo = new BoundingInfo(extend.minimum, extend.maximum);
            }

            this._updateBoundingInfo();
        }
    }
}