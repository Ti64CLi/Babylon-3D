using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class BoundingSphere
    {
        public Vector3 center;
        public double radius;
        public Vector3 centerWorld;
        public double radiusWorld;
        private BABYLON.Vector3 _tempRadiusVector = Vector3.Zero();
        public Vector3 minimum;
        public Vector3 maximum;
        public BoundingSphere(Vector3 minimum, Vector3 maximum)
        {
            var distance = BABYLON.Vector3.Distance(minimum, maximum);
            this.center = BABYLON.Vector3.Lerp(minimum, maximum, 0.5);
            this.radius = distance * 0.5;
            this.centerWorld = BABYLON.Vector3.Zero();
            this._update(BABYLON.Matrix.Identity());
        }
        public virtual void _update(Matrix world)
        {
            BABYLON.Vector3.TransformCoordinatesToRef(this.center, world, this.centerWorld);
            BABYLON.Vector3.TransformNormalFromFloatsToRef(1.0, 1.0, 1.0, world, this._tempRadiusVector);
            this.radiusWorld = Math.Max(Math.Max(Math.Abs(this._tempRadiusVector.x), Math.Abs(this._tempRadiusVector.y)), Math.Abs(this._tempRadiusVector.z)) * this.radius;
        }
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            for (var i = 0; i < 6; i++)
            {
                if (frustumPlanes[i].dotCoordinate(this.centerWorld) <= -this.radiusWorld)
                    return false;
            }
            return true;
        }
        public virtual bool intersectsPoint(Vector3 point)
        {
            var x = this.centerWorld.x - point.x;
            var y = this.centerWorld.y - point.y;
            var z = this.centerWorld.z - point.z;
            var distance = Math.Sqrt((x * x) + (y * y) + (z * z));
            if (Math.Abs(this.radiusWorld - distance) < Engine.Epsilon)
                return false;
            return true;
        }
        public static bool Intersects(BoundingSphere sphere0, BoundingSphere sphere1)
        {
            var x = sphere0.centerWorld.x - sphere1.centerWorld.x;
            var y = sphere0.centerWorld.y - sphere1.centerWorld.y;
            var z = sphere0.centerWorld.z - sphere1.centerWorld.z;
            var distance = Math.Sqrt((x * x) + (y * y) + (z * z));
            if (sphere0.radiusWorld + sphere1.radiusWorld < distance)
                return false;
            return true;
        }
    }
}