#ifndef BABYLON_COLLIDER_H
#define BABYLON_COLLIDER_H

#include "decls.h"

#include "vector3.h"
#include "subMesh.h"
#include "mesh.h"

namespace Babylon {

	class Mesh;
	typedef shared_ptr_t<Mesh> MeshPtr;

	class Collider : public enable_shared_from_this<Collider> {

	public:

		typedef shared_ptr_t<Collider> Ptr;
		typedef vector_t<Ptr> Array;

	protected:
		Vector3::Ptr velocity;
		Vector3::Ptr basePoint;
		float velocityWorldLength;
		float epsilon;
		bool collisionFound;
		float nearestDistance;
		Vector3::Ptr intersectionPoint;
		Mesh::Ptr collidedMesh;

	public:
		Vector3::Ptr radius;
		int retry;

		Vector3::Ptr basePointWorld;
		Vector3::Ptr velocityWorld;
		Vector3::Ptr normalizedVelocity;

		// Internals
		Vector3::Ptr _collisionPoint;
		Vector3::Ptr _planeIntersectionPoint;
		Vector3::Ptr _tempVector;
		Vector3::Ptr _tempVector2;
		Vector3::Ptr _tempVector3;
		Vector3::Ptr _tempVector4;
		Vector3::Ptr _edge;
		Vector3::Ptr _baseToVertex;
		Vector3::Ptr _destinationPoint;
		Vector3::Ptr _slidePlaneNormal;
		Vector3::Ptr _displacementVector;		

		Collider();

		// Methods
		virtual void _initialize (Vector3::Ptr source, Vector3::Ptr dir, float e);
		virtual bool _checkPointInTriangle (Vector3::Ptr point, Vector3::Ptr pa, Vector3::Ptr pb, Vector3::Ptr pc, Vector3::Ptr n);
		virtual bool _canDoCollision (Vector3::Ptr sphereCenter, float sphereRadius, Vector3::Ptr vecMin, Vector3::Ptr vecMax);
		virtual void _testTriangle (int faceIndex, SubMesh::Ptr subMesh, Vector3::Ptr p1, Vector3::Ptr p2, Vector3::Ptr p3);
		virtual void _collide (SubMesh::Ptr subMesh, Vector3::Array pts, Int32Array indices, int indexStart, int indexEnd, float decal);
		virtual void _getResponse(Vector3::Ptr pos, Vector3::Ptr vel);
	};

};

#endif // BABYLON_COLLIDER_H