// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.collider.cs" company="">
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
    public partial class Collider
    {
        /// <summary>
        /// </summary>
        public Vector3 basePoint;

        /// <summary>
        /// </summary>
        public Vector3 basePointWorld = Vector3.Zero();

        /// <summary>
        /// </summary>
        public AbstractMesh collidedMesh;

        /// <summary>
        /// </summary>
        public bool collisionFound;

        /// <summary>
        /// </summary>
        public double epsilon;

        /// <summary>
        /// </summary>
        public Vector3 initialPosition;

        /// <summary>
        /// </summary>
        public Vector3 initialVelocity;

        /// <summary>
        /// </summary>
        public Vector3 intersectionPoint;

        /// <summary>
        /// </summary>
        public double nearestDistance;

        /// <summary>
        /// </summary>
        public Vector3 normalizedVelocity = Vector3.Zero();

        /// <summary>
        /// </summary>
        public Vector3 radius = new Vector3(1, 1, 1);

        /// <summary>
        /// </summary>
        public double retry = 0;

        /// <summary>
        /// </summary>
        public Vector3 velocity;

        /// <summary>
        /// </summary>
        public Vector3 velocityWorld = Vector3.Zero();

        /// <summary>
        /// </summary>
        public double velocityWorldLength;

        /// <summary>
        /// </summary>
        private readonly Vector3 _baseToVertex = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _collisionPoint = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _destinationPoint = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _displacementVector = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _edge = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _planeIntersectionPoint = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _slidePlaneNormal = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _tempVector = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _tempVector2 = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _tempVector3 = Vector3.Zero();

        /// <summary>
        /// </summary>
        private readonly Vector3 _tempVector4 = Vector3.Zero();

        /// <summary>
        /// </summary>
        /// <param name="sphereCenter">
        /// </param>
        /// <param name="sphereRadius">
        /// </param>
        /// <param name="vecMin">
        /// </param>
        /// <param name="vecMax">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _canDoCollision(Vector3 sphereCenter, double sphereRadius, Vector3 vecMin, Vector3 vecMax)
        {
            var distance = Vector3.Distance(this.basePointWorld, sphereCenter);
            var max = Math.Max(Math.Max(this.radius.x, this.radius.y), this.radius.z);
            if (distance > this.velocityWorldLength + max + sphereRadius)
            {
                return false;
            }

            if (!this.intersectBoxAASphere(vecMin, vecMax, this.basePointWorld, this.velocityWorldLength + max))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="point">
        /// </param>
        /// <param name="pa">
        /// </param>
        /// <param name="pb">
        /// </param>
        /// <param name="pc">
        /// </param>
        /// <param name="n">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool _checkPointInTriangle(Vector3 point, Vector3 pa, Vector3 pb, Vector3 pc, Vector3 n)
        {
            pa.subtractToRef(point, this._tempVector);
            pb.subtractToRef(point, this._tempVector2);
            Vector3.CrossToRef(this._tempVector, this._tempVector2, this._tempVector4);
            var d = Vector3.Dot(this._tempVector4, n);
            if (d < 0)
            {
                return false;
            }

            pc.subtractToRef(point, this._tempVector3);
            Vector3.CrossToRef(this._tempVector2, this._tempVector3, this._tempVector4);
            d = Vector3.Dot(this._tempVector4, n);
            if (d < 0)
            {
                return false;
            }

            Vector3.CrossToRef(this._tempVector3, this._tempVector, this._tempVector4);
            d = Vector3.Dot(this._tempVector4, n);
            return d >= 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="subMesh">
        /// </param>
        /// <param name="pts">
        /// </param>
        /// <param name="indices">
        /// </param>
        /// <param name="indexStart">
        /// </param>
        /// <param name="indexEnd">
        /// </param>
        /// <param name="decal">
        /// </param>
        public virtual void _collide(SubMesh subMesh, Array<Vector3> pts, Array<int> indices, int indexStart, int indexEnd, int decal)
        {
            for (var i = indexStart; i < indexEnd; i += 3)
            {
                var p1 = pts[indices[i] - decal];
                var p2 = pts[indices[i + 1] - decal];
                var p3 = pts[indices[i + 2] - decal];
                this._testTriangle(i, subMesh, p3, p2, p1);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="pos">
        /// </param>
        /// <param name="vel">
        /// </param>
        public virtual void _getResponse(Vector3 pos, Vector3 vel)
        {
            pos.addToRef(vel, this._destinationPoint);
            vel.scaleInPlace(this.nearestDistance / vel.Length());
            this.basePoint.addToRef(vel, pos);
            pos.subtractToRef(this.intersectionPoint, this._slidePlaneNormal);
            this._slidePlaneNormal.normalize();
            this._slidePlaneNormal.scaleToRef(this.epsilon, this._displacementVector);
            pos.addInPlace(this._displacementVector);
            this.intersectionPoint.addInPlace(this._displacementVector);
            this._slidePlaneNormal.scaleInPlace(
                Plane.SignedDistanceToPlaneFromPositionAndNormal(this.intersectionPoint, this._slidePlaneNormal, this._destinationPoint));
            this._destinationPoint.subtractInPlace(this._slidePlaneNormal);
            this._destinationPoint.subtractToRef(this.intersectionPoint, vel);
        }

        /// <summary>
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <param name="dir">
        /// </param>
        /// <param name="e">
        /// </param>
        public virtual void _initialize(Vector3 source, Vector3 dir, double e)
        {
            this.velocity = dir;
            Vector3.NormalizeToRef(dir, this.normalizedVelocity);
            this.basePoint = source;
            source.multiplyToRef(this.radius, this.basePointWorld);
            dir.multiplyToRef(this.radius, this.velocityWorld);
            this.velocityWorldLength = this.velocityWorld.Length();
            this.epsilon = e;
            this.collisionFound = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="faceIndex">
        /// </param>
        /// <param name="subMesh">
        /// </param>
        /// <param name="p1">
        /// </param>
        /// <param name="p2">
        /// </param>
        /// <param name="p3">
        /// </param>
        public virtual void _testTriangle(int faceIndex, SubMesh subMesh, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            double t0;
            var embeddedInPlane = false;
            if (subMesh._trianglePlanes == null)
            {
                subMesh._trianglePlanes = new Array<Plane>();
            }

            if (subMesh._trianglePlanes[faceIndex] == null)
            {
                subMesh._trianglePlanes[faceIndex] = new Plane(0, 0, 0, 0);
                subMesh._trianglePlanes[faceIndex].copyFromPoints(p1, p2, p3);
            }

            var trianglePlane = subMesh._trianglePlanes[faceIndex];
            if ((subMesh.getMaterial() == null) && !trianglePlane.isFrontFacingTo(this.normalizedVelocity, 0))
            {
                return;
            }

            var signedDistToTrianglePlane = trianglePlane.signedDistanceTo(this.basePoint);
            var normalDotVelocity = Vector3.Dot(trianglePlane.normal, this.velocity);
            if (normalDotVelocity == 0)
            {
                if (Math.Abs(signedDistToTrianglePlane) >= 1.0)
                {
                    return;
                }

                embeddedInPlane = true;
                t0 = 0;
            }
            else
            {
                t0 = (-1.0 - signedDistToTrianglePlane) / normalDotVelocity;
                var t1 = (1.0 - signedDistToTrianglePlane) / normalDotVelocity;
                if (t0 > t1)
                {
                    var temp = t1;
                    t1 = t0;
                    t0 = temp;
                }

                if (t0 > 1.0 || t1 < 0.0)
                {
                    return;
                }

                if (t0 < 0)
                {
                    t0 = 0;
                }

                if (t0 > 1.0)
                {
                    t0 = 1.0;
                }
            }

            this._collisionPoint.copyFromFloats(0, 0, 0);
            var found = false;
            var t = 1.0;
            if (!embeddedInPlane)
            {
                this.basePoint.subtractToRef(trianglePlane.normal, this._planeIntersectionPoint);
                this.velocity.scaleToRef(t0, this._tempVector);
                this._planeIntersectionPoint.addInPlace(this._tempVector);
                if (this._checkPointInTriangle(this._planeIntersectionPoint, p1, p2, p3, trianglePlane.normal))
                {
                    found = true;
                    t = t0;
                    this._collisionPoint.copyFrom(this._planeIntersectionPoint);
                }
            }

            if (!found)
            {
                var velocitySquaredLength = this.velocity.lengthSquared();
                var a = velocitySquaredLength;
                this.basePoint.subtractToRef(p1, this._tempVector);
                var b = 2.0 * Vector3.Dot(this.velocity, this._tempVector);
                var c = this._tempVector.lengthSquared() - 1.0;
                var lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    t = lowestRoot.root;
                    found = true;
                    this._collisionPoint.copyFrom(p1);
                }

                this.basePoint.subtractToRef(p2, this._tempVector);
                b = 2.0 * Vector3.Dot(this.velocity, this._tempVector);
                c = this._tempVector.lengthSquared() - 1.0;
                lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    t = lowestRoot.root;
                    found = true;
                    this._collisionPoint.copyFrom(p2);
                }

                this.basePoint.subtractToRef(p3, this._tempVector);
                b = 2.0 * Vector3.Dot(this.velocity, this._tempVector);
                c = this._tempVector.lengthSquared() - 1.0;
                lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    t = lowestRoot.root;
                    found = true;
                    this._collisionPoint.copyFrom(p3);
                }

                p2.subtractToRef(p1, this._edge);
                p1.subtractToRef(this.basePoint, this._baseToVertex);
                var edgeSquaredLength = this._edge.lengthSquared();
                var edgeDotVelocity = Vector3.Dot(this._edge, this.velocity);
                var edgeDotBaseToVertex = Vector3.Dot(this._edge, this._baseToVertex);
                a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
                b = edgeSquaredLength * (2.0 * Vector3.Dot(this.velocity, this._baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
                c = edgeSquaredLength * (1.0 - this._baseToVertex.lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;
                lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    var f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;
                    if (f >= 0.0 && f <= 1.0)
                    {
                        t = lowestRoot.root;
                        found = true;
                        this._edge.scaleInPlace(f);
                        p1.addToRef(this._edge, this._collisionPoint);
                    }
                }

                p3.subtractToRef(p2, this._edge);
                p2.subtractToRef(this.basePoint, this._baseToVertex);
                edgeSquaredLength = this._edge.lengthSquared();
                edgeDotVelocity = Vector3.Dot(this._edge, this.velocity);
                edgeDotBaseToVertex = Vector3.Dot(this._edge, this._baseToVertex);
                a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
                b = edgeSquaredLength * (2.0 * Vector3.Dot(this.velocity, this._baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
                c = edgeSquaredLength * (1.0 - this._baseToVertex.lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;
                lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    var f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;
                    if (f >= 0.0 && f <= 1.0)
                    {
                        t = lowestRoot.root;
                        found = true;
                        this._edge.scaleInPlace(f);
                        p2.addToRef(this._edge, this._collisionPoint);
                    }
                }

                p1.subtractToRef(p3, this._edge);
                p3.subtractToRef(this.basePoint, this._baseToVertex);
                edgeSquaredLength = this._edge.lengthSquared();
                edgeDotVelocity = Vector3.Dot(this._edge, this.velocity);
                edgeDotBaseToVertex = Vector3.Dot(this._edge, this._baseToVertex);
                a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
                b = edgeSquaredLength * (2.0 * Vector3.Dot(this.velocity, this._baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
                c = edgeSquaredLength * (1.0 - this._baseToVertex.lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;
                lowestRoot = this.getLowestRoot(a, b, c, t);
                if (lowestRoot.found)
                {
                    var f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;
                    if (f >= 0.0 && f <= 1.0)
                    {
                        t = lowestRoot.root;
                        found = true;
                        this._edge.scaleInPlace(f);
                        p3.addToRef(this._edge, this._collisionPoint);
                    }
                }
            }

            if (found)
            {
                var distToCollision = t * this.velocity.Length();
                if (!this.collisionFound || distToCollision < this.nearestDistance)
                {
                    if (this.intersectionPoint == null)
                    {
                        this.intersectionPoint = this._collisionPoint.clone();
                    }
                    else
                    {
                        this.intersectionPoint.copyFrom(this._collisionPoint);
                    }

                    this.nearestDistance = distToCollision;
                    this.collisionFound = true;
                    this.collidedMesh = subMesh.getMesh();
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="a">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <param name="c">
        /// </param>
        /// <param name="maxR">
        /// </param>
        /// <returns>
        /// </returns>
        public RootResult getLowestRoot(double a, double b, double c, double maxR)
        {
            var determinant = b * b - 4.0 * a * c;
            var result = new RootResult { root = 0, found = false };
            if (determinant < 0)
            {
                return result;
            }

            var sqrtD = Math.Sqrt(determinant);
            var r1 = (-b - sqrtD) / (2.0 * a);
            var r2 = (-b + sqrtD) / (2.0 * a);
            if (r1 > r2)
            {
                var temp = r2;
                r2 = r1;
                r1 = temp;
            }

            if (r1 > 0 && r1 < maxR)
            {
                result.root = r1;
                result.found = true;
                return result;
            }

            if (r2 > 0 && r2 < maxR)
            {
                result.root = r2;
                result.found = true;
                return result;
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="boxMin">
        /// </param>
        /// <param name="boxMax">
        /// </param>
        /// <param name="sphereCenter">
        /// </param>
        /// <param name="sphereRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public bool intersectBoxAASphere(Vector3 boxMin, Vector3 boxMax, Vector3 sphereCenter, double sphereRadius)
        {
            if (boxMin.x > sphereCenter.x + sphereRadius)
            {
                return false;
            }

            if (sphereCenter.x - sphereRadius > boxMax.x)
            {
                return false;
            }

            if (boxMin.y > sphereCenter.y + sphereRadius)
            {
                return false;
            }

            if (sphereCenter.y - sphereRadius > boxMax.y)
            {
                return false;
            }

            if (boxMin.z > sphereCenter.z + sphereRadius)
            {
                return false;
            }

            if (sphereCenter.z - sphereRadius > boxMax.z)
            {
                return false;
            }

            return true;
        }
    }
}