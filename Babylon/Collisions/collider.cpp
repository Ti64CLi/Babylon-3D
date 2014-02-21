#include "collider.h"

using namespace Babylon;

Babylon::Collider::Collider()
{
    this->radius = make_shared<Vector3>(1, 1, 1);
    this->retry = 0;

    this->basePointWorld = Vector3::Zero();
    this->velocityWorld = Vector3::Zero();
    this->normalizedVelocity = Vector3::Zero();
        
    // Internals
    this->_collisionPoint = Vector3::Zero();
    this->_planeIntersectionPoint = Vector3::Zero();
    this->_tempVector = Vector3::Zero();
    this->_tempVector2 = Vector3::Zero();
    this->_tempVector3 = Vector3::Zero();
    this->_tempVector4 = Vector3::Zero();
    this->_edge = Vector3::Zero();
    this->_baseToVertex = Vector3::Zero();
    this->_destinationPoint = Vector3::Zero();
    this->_slidePlaneNormal = Vector3::Zero();
    this->_displacementVector = Vector3::Zero();
}

// Methods
void Babylon::Collider::_initialize(Vector3::Ptr source, Vector3::Ptr dir, float e) {
	this->velocity = dir;
	Vector3::NormalizeToRef(dir, this->normalizedVelocity);
	this->basePoint = source;

	source->multiplyToRef(this->radius, this->basePointWorld);
	dir->multiplyToRef(this->radius, this->velocityWorld);

	this->velocityWorldLength = this->velocityWorld->length();

	this->epsilon = e;
	this->collisionFound = false;
};

bool Babylon::Collider::_checkPointInTriangle(Vector3::Ptr point, Vector3::Ptr pa, Vector3::Ptr pb, Vector3::Ptr pc, Vector3::Ptr n) {
	pa->subtractToRef(point, this->_tempVector);
	pb->subtractToRef(point, this->_tempVector2);

	Vector3::CrossToRef(this->_tempVector, this->_tempVector2, this->_tempVector4);
	auto d = Vector3::Dot(this->_tempVector4, n);
	if (d < 0)
		return false;

	pc->subtractToRef(point, this->_tempVector3);
	Vector3::CrossToRef(this->_tempVector2, this->_tempVector3, this->_tempVector4);
	d = Vector3::Dot(this->_tempVector4, n);
	if (d < 0)
		return false;

	Vector3::CrossToRef(this->_tempVector3, this->_tempVector, this->_tempVector4);
	d = Vector3::Dot(this->_tempVector4, n);
	return d >= 0;
};

bool intersectBoxAASphere(Vector3::Ptr boxMin, Vector3::Ptr boxMax, Vector3::Ptr sphereCenter, float sphereRadius) {
	if (boxMin->x > sphereCenter->x + sphereRadius)
		return false;

	if (sphereCenter->x - sphereRadius > boxMax->x)
		return false;

	if (boxMin->y > sphereCenter->y + sphereRadius)
		return false;

	if (sphereCenter->y - sphereRadius > boxMax->y)
		return false;

	if (boxMin->z > sphereCenter->z + sphereRadius)
		return false;

	if (sphereCenter->z - sphereRadius > boxMax->z)
		return false;

	return true;
};

struct Result
{
	Result() : root(0), found(false) {
	}

	float root;
	bool found;
};

Result getLowestRoot(float a, float b, float c, float maxR) {
	auto determinant = b * b - 4.0 * a * c;
	Result result;

	if (determinant < 0)
		return result;

	auto sqrtD = sqrt(determinant);
	auto r1 = (-b - sqrtD) / (2.0 * a);
	auto r2 = (-b + sqrtD) / (2.0 * a);

	if (r1 > r2) {
		auto temp = r2;
		r2 = r1;
		r1 = temp;
	}

	if (r1 > 0 && r1 < maxR) {
		result.root = r1;
		result.found = true;
		return result;
	}

	if (r2 > 0 && r2 < maxR) {
		result.root = r2;
		result.found = true;
		return result;
	}

	return result;
};

bool Babylon::Collider::_canDoCollision(Vector3::Ptr sphereCenter, float sphereRadius, Vector3::Ptr vecMin, Vector3::Ptr vecMax) {
	auto distance = Vector3::Distance(this->basePointWorld, sphereCenter);

	auto _max = max(this->radius->x, this->radius->y);
	_max = max(_max, this->radius->z);

	if (distance > this->velocityWorldLength + _max + sphereRadius) {
		return false;
	}

	if (!intersectBoxAASphere(vecMin, vecMax, this->basePointWorld, this->velocityWorldLength + _max))
		return false;

	return true;
};

void Babylon::Collider::_testTriangle(int faceIndex, SubMesh::Ptr subMesh, Vector3::Ptr p1, Vector3::Ptr p2, Vector3::Ptr p3) {
	auto t0 = 0.;
	auto embeddedInPlane = false;

	if (!subMesh->_trianglePlanes[faceIndex]) {
		subMesh->_trianglePlanes[faceIndex] = make_shared<Plane>(0, 0, 0, 0);
		subMesh->_trianglePlanes[faceIndex]->copyFromPoints(p1, p2, p3);
	}

	auto trianglePlane = subMesh->_trianglePlanes[faceIndex];

	if ((!subMesh->getMaterial()) && !trianglePlane->isFrontFacingTo(this->normalizedVelocity, 0))
		return;

	auto signedDistToTrianglePlane = trianglePlane->signedDistanceTo(this->basePoint);
	auto normalDotVelocity = Vector3::Dot(trianglePlane->normal, this->velocity);

	if (normalDotVelocity == 0) {
		if (abs(signedDistToTrianglePlane) >= 1.0)
			return;
		embeddedInPlane = true;
		t0 = 0;
	}
	else {
		t0 = (-1.0 - signedDistToTrianglePlane) / normalDotVelocity;
		auto t1 = (1.0 - signedDistToTrianglePlane) / normalDotVelocity;

		if (t0 > t1) {
			auto temp = t1;
			t1 = t0;
			t0 = temp;
		}

		if (t0 > 1.0 || t1 < 0.0)
			return;

		if (t0 < 0)
			t0 = 0;
		if (t0 > 1.0)
			t0 = 1.0;
	}

	this->_collisionPoint->copyFromFloats(0, 0, 0);

	auto found = false;
	auto t = 1.0;

	if (!embeddedInPlane) {
		this->basePoint->subtractToRef(trianglePlane->normal, this->_planeIntersectionPoint);
		this->velocity->scaleToRef(t0, this->_tempVector);
		this->_planeIntersectionPoint->addInPlace(this->_tempVector);

		if (this->_checkPointInTriangle(this->_planeIntersectionPoint, p1, p2, p3, trianglePlane->normal)) {
			found = true;
			t = t0;
			this->_collisionPoint->copyFrom(this->_planeIntersectionPoint);
		}
	}

	if (!found) {
		auto velocitySquaredLength = this->velocity->lengthSquared();

		auto a = velocitySquaredLength;

		this->basePoint->subtractToRef(p1, this->_tempVector);
		auto b = 2.0 * (Vector3::Dot(this->velocity, this->_tempVector));
		auto c = this->_tempVector->lengthSquared() - 1.0;

		auto lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			t = lowestRoot.root;
			found = true;
			this->_collisionPoint->copyFrom(p1);
		}

		this->basePoint->subtractToRef(p2, this->_tempVector);
		b = 2.0 * (Vector3::Dot(this->velocity, this->_tempVector));
		c = this->_tempVector->lengthSquared() - 1.0;

		lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			t = lowestRoot.root;
			found = true;
			this->_collisionPoint->copyFrom(p2);
		}

		this->basePoint->subtractToRef(p3, this->_tempVector);
		b = 2.0 * (Vector3::Dot(this->velocity, this->_tempVector));
		c = this->_tempVector->lengthSquared() - 1.0;

		lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			t = lowestRoot.root;
			found = true;
			this->_collisionPoint->copyFrom(p3);
		}

		p2->subtractToRef(p1, this->_edge);
		p1->subtractToRef(this->basePoint, this->_baseToVertex);
		auto edgeSquaredLength = this->_edge->lengthSquared();
		auto edgeDotVelocity = Vector3::Dot(this->_edge, this->velocity);
		auto edgeDotBaseToVertex = Vector3::Dot(this->_edge, this->_baseToVertex);

		a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
		b = edgeSquaredLength * (2.0 * Vector3::Dot(this->velocity, this->_baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
		c = edgeSquaredLength * (1.0 - this->_baseToVertex->lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;

		lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			auto f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;

			if (f >= 0.0 && f <= 1.0) {
				t = lowestRoot.root;
				found = true;
				this->_edge->scaleInPlace(f);
				p1->addToRef(this->_edge, this->_collisionPoint);
			}
		}

		p3->subtractToRef(p2, this->_edge);
		p2->subtractToRef(this->basePoint, this->_baseToVertex);
		edgeSquaredLength = this->_edge->lengthSquared();
		edgeDotVelocity = Vector3::Dot(this->_edge, this->velocity);
		edgeDotBaseToVertex = Vector3::Dot(this->_edge, this->_baseToVertex);

		a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
		b = edgeSquaredLength * (2.0 * Vector3::Dot(this->velocity, this->_baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
		c = edgeSquaredLength * (1.0 - this->_baseToVertex->lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;
		lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			auto f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;

			if (f >= 0.0 && f <= 1.0) {
				t = lowestRoot.root;
				found = true;
				this->_edge->scaleInPlace(f);
				p2->addToRef(this->_edge, this->_collisionPoint);
			}
		}

		p1->subtractToRef(p3, this->_edge);
		p3->subtractToRef(this->basePoint, this->_baseToVertex);
		edgeSquaredLength = this->_edge->lengthSquared();
		edgeDotVelocity = Vector3::Dot(this->_edge, this->velocity);
		edgeDotBaseToVertex = Vector3::Dot(this->_edge, this->_baseToVertex);

		a = edgeSquaredLength * (-velocitySquaredLength) + edgeDotVelocity * edgeDotVelocity;
		b = edgeSquaredLength * (2.0 * Vector3::Dot(this->velocity, this->_baseToVertex)) - 2.0 * edgeDotVelocity * edgeDotBaseToVertex;
		c = edgeSquaredLength * (1.0 - this->_baseToVertex->lengthSquared()) + edgeDotBaseToVertex * edgeDotBaseToVertex;

		lowestRoot = getLowestRoot(a, b, c, t);
		if (lowestRoot.found) {
			auto f = (edgeDotVelocity * lowestRoot.root - edgeDotBaseToVertex) / edgeSquaredLength;

			if (f >= 0.0 && f <= 1.0) {
				t = lowestRoot.root;
				found = true;
				this->_edge->scaleInPlace(f);
				p3->addToRef(this->_edge, this->_collisionPoint);
			}
		}
	}

	if (found) {
		auto distToCollision = t * this->velocity->length();

		if (!this->collisionFound || distToCollision < this->nearestDistance) {
			if (!this->intersectionPoint) {
				this->intersectionPoint = this->_collisionPoint->clone();
			} else {
				this->intersectionPoint->copyFrom(this->_collisionPoint);
			}
			this->nearestDistance = distToCollision;                
			this->collisionFound = true;
			this->collidedMesh = subMesh->getMesh();
		}
	}
};

void Babylon::Collider::_collide(SubMesh::Ptr subMesh, Vector3::Array pts, Int32Array indices, int indexStart, int indexEnd, float decal) {
	for (auto i = indexStart; i < indexEnd; i += 3) {
		auto p1 = pts[indices[i] - decal];
		auto p2 = pts[indices[i + 1] - decal];
		auto p3 = pts[indices[i + 2] - decal];

		this->_testTriangle(i, subMesh, p3, p2, p1);
	}
};

void Babylon::Collider::_getResponse (Vector3::Ptr pos, Vector3::Ptr vel) {
	pos->addToRef(vel, this->_destinationPoint);
	vel->scaleInPlace((this->nearestDistance / vel->length()));

	this->basePoint->addToRef(vel, pos);
	pos->subtractToRef(this->intersectionPoint, this->_slidePlaneNormal);
	this->_slidePlaneNormal->normalize();
	this->_slidePlaneNormal->scaleToRef(this->epsilon, this->_displacementVector);

	pos->addInPlace(this->_displacementVector);
	this->intersectionPoint->addInPlace(this->_displacementVector);

	this->_slidePlaneNormal->scaleInPlace(Plane::SignedDistanceToPlaneFromPositionAndNormal(this->intersectionPoint, this->_slidePlaneNormal, this->_destinationPoint));
	this->_destinationPoint->subtractInPlace(this->_slidePlaneNormal);

	this->_destinationPoint->subtractToRef(this->intersectionPoint, vel);
};
