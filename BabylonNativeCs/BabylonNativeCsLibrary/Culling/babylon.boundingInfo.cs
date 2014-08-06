// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.boundingInfo.cs" company="">
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
    public partial class BoundingInfo
    {
        /// <summary>
        /// </summary>
        public BoundingBox boundingBox;

        /// <summary>
        /// </summary>
        public BoundingSphere boundingSphere;

        /// <summary>
        /// </summary>
        public Vector3 maximum;

        /// <summary>
        /// </summary>
        public Vector3 minimum;

        /// <summary>
        /// </summary>
        /// <param name="minimum">
        /// </param>
        /// <param name="maximum">
        /// </param>
        public BoundingInfo(Vector3 minimum, Vector3 maximum)
        {
            this.boundingBox = new BoundingBox(minimum, maximum);
            this.boundingSphere = new BoundingSphere(minimum, maximum);
        }

        /// <summary>
        /// </summary>
        /// <param name="collider">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _checkCollision(Collider collider)
        {
            return collider._canDoCollision(
                this.boundingSphere.centerWorld, this.boundingSphere.radiusWorld, this.boundingBox.minimumWorld, this.boundingBox.maximumWorld);
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public virtual void _update(Matrix world)
        {
            this.boundingBox._update(world);
            this.boundingSphere._update(world);
        }

        /// <summary>
        /// </summary>
        /// <param name="boundingInfo">
        /// </param>
        /// <param name="precise">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersects(BoundingInfo boundingInfo, bool precise)
        {
            if (this.boundingSphere.centerWorld == null || boundingInfo.boundingSphere.centerWorld == null)
            {
                return false;
            }

            if (!BoundingSphere.Intersects(this.boundingSphere, boundingInfo.boundingSphere))
            {
                return false;
            }

            if (!BoundingBox.Intersects(this.boundingBox, boundingInfo.boundingBox))
            {
                return false;
            }

            if (!precise)
            {
                return true;
            }

            var box0 = this.boundingBox;
            var box1 = boundingInfo.boundingBox;
            if (!this.axisOverlap(box0.directions[0], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(box0.directions[1], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(box0.directions[2], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(box1.directions[0], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(box1.directions[1], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(box1.directions[2], box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[0], box1.directions[0]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[0], box1.directions[1]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[0], box1.directions[2]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[1], box1.directions[0]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[1], box1.directions[1]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[1], box1.directions[2]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[2], box1.directions[0]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[2], box1.directions[1]), box0, box1))
            {
                return false;
            }

            if (!this.axisOverlap(Vector3.Cross(box0.directions[2], box1.directions[2]), box0, box1))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsPoint(Vector3 point)
        {
            if (this.boundingSphere.centerWorld == null)
            {
                return false;
            }

            if (!this.boundingSphere.intersectsPoint(point))
            {
                return false;
            }

            if (!this.boundingBox.intersectsPoint(point))
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
            if (!this.boundingSphere.isInFrustum(frustumPlanes))
            {
                return false;
            }

            return this.boundingBox.isInFrustum(frustumPlanes);
        }

        /// <summary>
        /// </summary>
        /// <param name="axis">
        /// </param>
        /// <param name="box0">
        /// </param>
        /// <param name="box1">
        /// </param>
        /// <returns>
        /// </returns>
        private bool axisOverlap(Vector3 axis, BoundingBox box0, BoundingBox box1)
        {
            var result0 = this.computeBoxExtents(axis, box0);
            var result1 = this.computeBoxExtents(axis, box1);
            return this.extentsOverlap(result0.min, result0.max, result1.min, result1.max);
        }

        /// <summary>
        /// </summary>
        /// <param name="axis">
        /// </param>
        /// <param name="box">
        /// </param>
        /// <returns>
        /// </returns>
        private Extents computeBoxExtents(Vector3 axis, BoundingBox box)
        {
            var p = Vector3.Dot(box.center, axis);
            var r0 = Math.Abs(Vector3.Dot(box.directions[0], axis)) * box.extends.x;
            var r1 = Math.Abs(Vector3.Dot(box.directions[1], axis)) * box.extends.y;
            var r2 = Math.Abs(Vector3.Dot(box.directions[2], axis)) * box.extends.z;
            var r = r0 + r1 + r2;
            return new Extents { min = p - r, max = p + r };
        }

        /// <summary>
        /// </summary>
        /// <param name="min0">
        /// </param>
        /// <param name="max0">
        /// </param>
        /// <param name="min1">
        /// </param>
        /// <param name="max1">
        /// </param>
        /// <returns>
        /// </returns>
        private bool extentsOverlap(double min0, double max0, double min1, double max1)
        {
            return !(min0 > max1 || min1 > max0);
        }
    }
}