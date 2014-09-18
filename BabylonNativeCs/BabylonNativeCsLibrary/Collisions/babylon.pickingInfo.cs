// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.pickingInfo.cs" company="">
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
    public partial class IntersectionInfo
    {
        /// <summary>
        /// </summary>
        public double bu;

        /// <summary>
        /// </summary>
        public double bv;

        /// <summary>
        /// </summary>
        public double distance;

        /// <summary>
        /// </summary>
        public int faceId = 0;

        /// <summary>
        /// </summary>
        /// <param name="bu">
        /// </param>
        /// <param name="bv">
        /// </param>
        /// <param name="distance">
        /// </param>
        public IntersectionInfo(double bu, double bv, double distance)
        {
            this.bu = bu;
            this.bv = bv;
            this.distance = distance;
        }
    }

    /// <summary>
    /// </summary>
    public partial class PickingInfo
    {
        /// <summary>
        /// </summary>
        public double bu = 0;

        /// <summary>
        /// </summary>
        public double bv = 0;

        /// <summary>
        /// </summary>
        public double distance = 0;

        /// <summary>
        /// </summary>
        public int faceId = -1;

        /// <summary>
        /// </summary>
        public bool hit = false;

        /// <summary>
        /// </summary>
        public AbstractMesh pickedMesh = null;

        /// <summary>
        /// </summary>
        public Vector3 pickedPoint = null;

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector3 getNormal()
        {
            if (this.pickedMesh == null || !this.pickedMesh.isVerticesDataPresent(VertexBufferKind.NormalKind))
            {
                return null;
            }

            var indices = this.pickedMesh.getIndices();
            var normals = this.pickedMesh.getVerticesData(VertexBufferKind.NormalKind);
            var normal0 = Vector3.FromArray(normals, indices[this.faceId * 3] * 3);
            var normal1 = Vector3.FromArray(normals, indices[this.faceId * 3 + 1] * 3);
            var normal2 = Vector3.FromArray(normals, indices[this.faceId * 3 + 2] * 3);
            normal0 = normal0.scale(this.bu);
            normal1 = normal1.scale(this.bv);
            normal2 = normal2.scale(1.0 - this.bu - this.bv);
            return new Vector3(normal0.x + normal1.x + normal2.x, normal0.y + normal1.y + normal2.y, normal0.z + normal1.z + normal2.z);
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Vector2 getTextureCoordinates()
        {
            if (this.pickedMesh == null || !this.pickedMesh.isVerticesDataPresent(VertexBufferKind.UVKind))
            {
                return null;
            }

            var indices = this.pickedMesh.getIndices();
            var uvs = this.pickedMesh.getVerticesData(VertexBufferKind.UVKind);
            var uv0 = Vector2.FromArray(uvs, indices[this.faceId * 3] * 2);
            var uv1 = Vector2.FromArray(uvs, indices[this.faceId * 3 + 1] * 2);
            var uv2 = Vector2.FromArray(uvs, indices[this.faceId * 3 + 2] * 2);
            uv0 = uv0.scale(this.bu);
            uv1 = uv1.scale(this.bv);
            uv2 = uv2.scale(1.0 - this.bu - this.bv);
            return new Vector2(uv0.x + uv1.x + uv2.x, uv0.y + uv1.y + uv2.y);
        }
    }
}