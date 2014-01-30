#ifndef BABYLON_SubMesh_H
#define BABYLON_SubMesh_H

#include <memory>
#include <vector>

#include "iengine.h"
#include "boundingInfo.h"
#include "matrix.h"
#include "plane.h"
#include "ray.h"
#include "material.h"

using namespace std;

namespace Babylon {

	class Mesh;
	typedef shared_ptr<Mesh> MeshPtr;

	class SubMesh: public enable_shared_from_this<SubMesh> {

	public:
		typedef shared_ptr<SubMesh> Ptr;
		typedef vector<Ptr> Array;

		IGLBuffer::Ptr _linesIndexBuffer;
		size_t linesIndexCount;

		int _renderId;

		MeshPtr _mesh;
		int materialIndex;
		size_t verticesStart;
		int verticesCount;
		int indexStart;
		size_t indexCount;

		BoundingInfo::Ptr _boundingInfo;
		float _distanceToCamera;

	protected: 
		SubMesh(int materialIndex, int verticesStart, size_t verticesCount, int indexStart, size_t indexCount, MeshPtr mesh);		
	public: 
		static SubMesh::Ptr New(int materialIndex, int verticesStart, size_t verticesCount, int indexStart, size_t indexCount, MeshPtr mesh);		

		virtual BoundingInfo::Ptr getBoundingInfo();
		virtual MeshPtr getMesh();
		virtual Material::Ptr getMaterial();
		virtual void refreshBoundingInfo();
		virtual void updateBoundingInfo(Matrix::Ptr world, float scale);
		virtual bool isInFrustum(Plane::Array frustumPlanes);
		virtual void render();
		virtual IGLBuffer::Ptr getLinesIndexBuffer(Uint16Array indices, EnginePtr engine);
		virtual bool canIntersects(Ray::Ptr ray);
		virtual float intersects(Ray::Ptr ray, Vector3::Array positions, Uint16Array indices, bool fastCheck);
		virtual SubMesh::Ptr clone(MeshPtr newMesh);
		static SubMesh::Ptr CreateFromIndices(int materialIndex, int startIndex, size_t indexCount, MeshPtr mesh);
	};

};

#endif // BABYLON_SubMesh_H