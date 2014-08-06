// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.boundingSphere.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public partial class BoundingSphere
    {
        /// <summary>
        /// </summary>
        public Vector3 center;

        /// <summary>
        /// </summary>
        public Vector3 centerWorld;

        /// <summary>
        /// </summary>
        public Vector3 maximum;

        /// <summary>
        /// </summary>
        public Vector3 minimum;

        /// <summary>
        /// </summary>
        public double radius;

        /// <summary>
        /// </summary>
        public double radiusWorld;

        /// <summary>
        /// </summary>
        private readonly Vector3 _tempRadiusVector = Vector3.Zero();

        /// <summary>
        /// </summary>
        /// <param name="minimum">
        /// </param>
        /// <param name="maximum">
        /// </param>
        public BoundingSphere(Vector3 minimum, Vector3 maximum)
        {
            var distance = Vector3.Distance(minimum, maximum);
            this.center = Vector3.Lerp(minimum, maximum, 0.5);
            this.radius = distance * 0.5;
            this.centerWorld = Vector3.Zero();
            this._update(Matrix.Identity());
        }

        /// <summary>
        /// </summary>
        /// <param name="sphere0">
        /// </param>
        /// <param name="sphere1">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool Intersects(BoundingSphere sphere0, BoundingSphere sphere1)
        {
            var x = sphere0.centerWorld.x - sphere1.centerWorld.x;
            var y = sphere0.centerWorld.y - sphere1.centerWorld.y;
            var z = sphere0.centerWorld.z - sphere1.centerWorld.z;
            var distance = Math.Sqrt((x * x) + (y * y) + (z * z));
            if (sphere0.radiusWorld + sphere1.radiusWorld < distance)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public virtual void _update(Matrix world)
        {
            Vector3.TransformCoordinatesToRef(this.center, world, this.centerWorld);
            Vector3.TransformNormalFromFloatsToRef(1.0, 1.0, 1.0, world, this._tempRadiusVector);
            this.radiusWorld = Math.Max(Math.Max(Math.Abs(this._tempRadiusVector.x), Math.Abs(this._tempRadiusVector.y)), Math.Abs(this._tempRadiusVector.z))
                               * this.radius;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsPoint(Vector3 point)
        {
            var x = this.centerWorld.x - point.x;
            var y = this.centerWorld.y - point.y;
            var z = this.centerWorld.z - point.z;
            var distance = Math.Sqrt((x * x) + (y * y) + (z * z));
            if (Math.Abs(this.radiusWorld - distance) < Engine.Epsilon)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            for (var i = 0; i < 6; i++)
            {
                if (frustumPlanes[i].dotCoordinate(this.centerWorld) <= -this.radiusWorld)
                {
                    return false;
                }
            }

            return true;
        }
    }
}