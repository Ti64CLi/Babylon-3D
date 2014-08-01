using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class BoundingInfo
    {
        public BoundingBox boundingBox;
        public BoundingSphere boundingSphere;
        public Vector3 minimum;
        public Vector3 maximum;
        public BoundingInfo(Vector3 minimum, Vector3 maximum)
        {
            this.boundingBox = new BABYLON.BoundingBox(minimum, maximum);
            this.boundingSphere = new BABYLON.BoundingSphere(minimum, maximum);
        }
        Extents computeBoxExtents(Vector3 axis, BoundingBox box)
        {
            var p = Vector3.Dot(box.center, axis);
            var r0 = Math.Abs(Vector3.Dot(box.directions[0], axis)) * box.extends.x;
            var r1 = Math.Abs(Vector3.Dot(box.directions[1], axis)) * box.extends.y;
            var r2 = Math.Abs(Vector3.Dot(box.directions[2], axis)) * box.extends.z;
            var r = r0 + r1 + r2;
            return new Extents
            {
                min = p - r,
                max = p + r
            };
        }
        bool extentsOverlap(double min0, double max0, double min1, double max1) { return !(min0 > max1 || min1 > max0); }
        bool axisOverlap(Vector3 axis, BoundingBox box0, BoundingBox box1)
        {
            var result0 = computeBoxExtents(axis, box0);
            var result1 = computeBoxExtents(axis, box1);
            return extentsOverlap(result0.min, result0.max, result1.min, result1.max);
        }
        public virtual void _update(Matrix world)
        {
            this.boundingBox._update(world);
            this.boundingSphere._update(world);
        }
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            if (!this.boundingSphere.isInFrustum(frustumPlanes))
                return false;
            return this.boundingBox.isInFrustum(frustumPlanes);
        }
        public virtual bool _checkCollision(Collider collider)
        {
            return collider._canDoCollision(this.boundingSphere.centerWorld, this.boundingSphere.radiusWorld, this.boundingBox.minimumWorld, this.boundingBox.maximumWorld);
        }
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
        public virtual bool intersects(BoundingInfo boundingInfo, bool precise)
        {
            if (this.boundingSphere.centerWorld == null || boundingInfo.boundingSphere.centerWorld == null)
            {
                return false;
            }
            if (!BABYLON.BoundingSphere.Intersects(this.boundingSphere, boundingInfo.boundingSphere))
            {
                return false;
            }
            if (!BABYLON.BoundingBox.Intersects(this.boundingBox, boundingInfo.boundingBox))
            {
                return false;
            }
            if (!precise)
            {
                return true;
            }
            var box0 = this.boundingBox;
            var box1 = boundingInfo.boundingBox;
            if (!axisOverlap(box0.directions[0], box0, box1))
                return false;
            if (!axisOverlap(box0.directions[1], box0, box1))
                return false;
            if (!axisOverlap(box0.directions[2], box0, box1))
                return false;
            if (!axisOverlap(box1.directions[0], box0, box1))
                return false;
            if (!axisOverlap(box1.directions[1], box0, box1))
                return false;
            if (!axisOverlap(box1.directions[2], box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[0], box1.directions[0]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[0], box1.directions[1]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[0], box1.directions[2]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[1], box1.directions[0]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[1], box1.directions[1]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[1], box1.directions[2]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[2], box1.directions[0]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[2], box1.directions[1]), box0, box1))
                return false;
            if (!axisOverlap(BABYLON.Vector3.Cross(box0.directions[2], box1.directions[2]), box0, box1))
                return false;
            return true;
        }
    }
}