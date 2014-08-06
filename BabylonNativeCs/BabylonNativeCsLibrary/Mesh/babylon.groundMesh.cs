// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.groundMesh.cs" company="">
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
    public partial class GroundMesh : Mesh
    {
        /// <summary>
        /// </summary>
        public int _subdivisions;

        /// <summary>
        /// </summary>
        public bool generateOctree = false;

        /// <summary>
        /// </summary>
        private readonly Matrix _worldInverse = new Matrix();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public GroundMesh(string name, Scene scene)
            : base(name, scene)
        {
        }

        /// <summary>
        /// </summary>
        public virtual double subdivisions
        {
            get
            {
                return this._subdivisions;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual double getHeightAtCoordinates(double x, double z)
        {
            var ray = new Ray(new Vector3(x, this.getBoundingInfo().boundingBox.maximumWorld.y + 1, z), new Vector3(0, -1, 0));
            this.getWorldMatrix().invertToRef(this._worldInverse);
            ray = Ray.Transform(ray, this._worldInverse);
            var pickInfo = this.intersects(ray);
            if (pickInfo.hit)
            {
                return pickInfo.pickedPoint.y;
            }

            return 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="chunksCount">
        /// </param>
        public virtual void optimize(double chunksCount)
        {
            this.subdivide(this._subdivisions);
            this.createOrUpdateSubmeshesOctree(32);
        }
    }
}