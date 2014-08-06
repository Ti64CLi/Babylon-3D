// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.BoundingBox.cs" company="">
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
    public partial class BoundingBox
    {
        /// <summary>
        /// </summary>
        public Vector3 center;

        /// <summary>
        /// </summary>
        public Array<Vector3> directions;

        /// <summary>
        /// </summary>
        public Vector3 extends;

        /// <summary>
        /// </summary>
        public Vector3 maximum;

        /// <summary>
        /// </summary>
        public Vector3 maximumWorld;

        /// <summary>
        /// </summary>
        public Vector3 minimum;

        /// <summary>
        /// </summary>
        public Vector3 minimumWorld;

        /// <summary>
        /// </summary>
        public Array<Vector3> vectors = new Array<Vector3>();

        /// <summary>
        /// </summary>
        public Array<Vector3> vectorsWorld = new Array<Vector3>();

        /// <summary>
        /// </summary>
        private Matrix _worldMatrix;

        /// <summary>
        /// </summary>
        /// <param name="minimum">
        /// </param>
        /// <param name="maximum">
        /// </param>
        public BoundingBox(Vector3 minimum, Vector3 maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;

            this.vectors.Add(this.minimum.clone());
            this.vectors.Add(this.maximum.clone());
            this.vectors.Add(this.minimum.clone());
            this.vectors[2].x = this.maximum.x;
            this.vectors.Add(this.minimum.clone());
            this.vectors[3].y = this.maximum.y;
            this.vectors.Add(this.minimum.clone());
            this.vectors[4].z = this.maximum.z;
            this.vectors.Add(this.maximum.clone());
            this.vectors[5].z = this.minimum.z;
            this.vectors.Add(this.maximum.clone());
            this.vectors[6].x = this.minimum.x;
            this.vectors.Add(this.maximum.clone());
            this.vectors[7].y = this.minimum.y;
            this.center = this.maximum.add(this.minimum).scale(0.5);
            this.extends = this.maximum.subtract(this.minimum).scale(0.5);
            this.directions = new Array<Vector3>(Vector3.Zero(), Vector3.Zero(), Vector3.Zero());

            this.vectorsWorld.Capacity = this.vectors.Length;
            for (var index = 0; index < this.vectors.Length; index++)
            {
                this.vectorsWorld.Add(Vector3.Zero());
            }

            this.minimumWorld = Vector3.Zero();
            this.maximumWorld = Vector3.Zero();
            this._update(Matrix.Identity());
        }

        /// <summary>
        /// </summary>
        /// <param name="box0">
        /// </param>
        /// <param name="box1">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool Intersects(BoundingBox box0, BoundingBox box1)
        {
            if (box0.maximumWorld.x < box1.minimumWorld.x || box0.minimumWorld.x > box1.maximumWorld.x)
            {
                return false;
            }

            if (box0.maximumWorld.y < box1.minimumWorld.y || box0.minimumWorld.y > box1.maximumWorld.y)
            {
                return false;
            }

            if (box0.maximumWorld.z < box1.minimumWorld.z || box0.minimumWorld.z > box1.maximumWorld.z)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="minPoint">
        /// </param>
        /// <param name="maxPoint">
        /// </param>
        /// <param name="sphereCenter">
        /// </param>
        /// <param name="sphereRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IntersectsSphere(Vector3 minPoint, Vector3 maxPoint, Vector3 sphereCenter, double sphereRadius)
        {
            var vector = Vector3.Clamp(sphereCenter, minPoint, maxPoint);
            var num = Vector3.DistanceSquared(sphereCenter, vector);
            return num <= (sphereRadius * sphereRadius);
        }

        /// <summary>
        /// </summary>
        /// <param name="boundingVectors">
        /// </param>
        /// <param name="frustumPlanes">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsInFrustum(Array<Vector3> boundingVectors, Array<Plane> frustumPlanes)
        {
            for (var p = 0; p < 6; p++)
            {
                var inCount = 8;
                for (var i = 0; i < 8; i++)
                {
                    if (frustumPlanes[p].dotCoordinate(boundingVectors[i]) < 0)
                    {
                        --inCount;
                    }
                    else
                    {
                        break;
                    }
                }

                if (inCount == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="world">
        /// </param>
        public virtual void _update(Matrix world)
        {
            Vector3.FromFloatsToRef(double.MaxValue, double.MaxValue, double.MaxValue, this.minimumWorld);
            Vector3.FromFloatsToRef(-double.MaxValue, -double.MaxValue, -double.MaxValue, this.maximumWorld);
            for (var index = 0; index < this.vectors.Length; index++)
            {
                var v = this.vectorsWorld[index];
                Vector3.TransformCoordinatesToRef(this.vectors[index], world, v);
                if (v.x < this.minimumWorld.x)
                {
                    this.minimumWorld.x = v.x;
                }

                if (v.y < this.minimumWorld.y)
                {
                    this.minimumWorld.y = v.y;
                }

                if (v.z < this.minimumWorld.z)
                {
                    this.minimumWorld.z = v.z;
                }

                if (v.x > this.maximumWorld.x)
                {
                    this.maximumWorld.x = v.x;
                }

                if (v.y > this.maximumWorld.y)
                {
                    this.maximumWorld.y = v.y;
                }

                if (v.z > this.maximumWorld.z)
                {
                    this.maximumWorld.z = v.z;
                }
            }

            this.maximumWorld.addToRef(this.minimumWorld, this.center);
            this.center.scaleInPlace(0.5);
            Vector3.FromFloatArrayToRef(world.m, 0, this.directions[0]);
            Vector3.FromFloatArrayToRef(world.m, 4, this.directions[1]);
            Vector3.FromFloatArrayToRef(world.m, 8, this.directions[2]);
            this._worldMatrix = world;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Matrix getWorldMatrix()
        {
            return this._worldMatrix;
        }

        /// <summary>
        /// </summary>
        /// <param name="min">
        /// </param>
        /// <param name="Max">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsMinMax(Vector3 min, Vector3 Max)
        {
            if (this.maximumWorld.x < min.x || this.minimumWorld.x > Max.x)
            {
                return false;
            }

            if (this.maximumWorld.y < min.y || this.minimumWorld.y > Max.y)
            {
                return false;
            }

            if (this.maximumWorld.z < min.z || this.minimumWorld.z > Max.z)
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
            var delta = Engine.Epsilon;
            if (this.maximumWorld.x - point.x < delta || delta > point.x - this.minimumWorld.x)
            {
                return false;
            }

            if (this.maximumWorld.y - point.y < delta || delta > point.y - this.minimumWorld.y)
            {
                return false;
            }

            if (this.maximumWorld.z - point.z < delta || delta > point.z - this.minimumWorld.z)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="sphere">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool intersectsSphere(BoundingSphere sphere)
        {
            return IntersectsSphere(this.minimumWorld, this.maximumWorld, sphere.centerWorld, sphere.radiusWorld);
        }

        /// <summary>
        /// </summary>
        /// <param name="frustumPlanes">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isInFrustum(Array<Plane> frustumPlanes)
        {
            return IsInFrustum(this.vectorsWorld, frustumPlanes);
        }
    }
}