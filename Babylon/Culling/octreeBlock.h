#ifndef BABYLON_OCTREEBLOCK_H
#define BABYLON_OCTREEBLOCK_H

#include <memory>
#include <vector>
#include <map>

#include "vector3.h"
#include "plane.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class OctreeBlock : public enable_shared_from_this<OctreeBlock> {

	public:

		typedef shared_ptr<OctreeBlock> Ptr;
		typedef vector<Ptr> Array;

		vector<SubMesh::Array> subMeshes;
		Mesh::Array meshes;
		size_t _capacity;

		Vector3::Ptr _minPoint;
		Vector3::Ptr _maxPoint;

		Vector3::Array _boundingVectors;

		OctreeBlock::Array blocks;

	public: 
		OctreeBlock(Vector3::Ptr minPoint, Vector3::Ptr maxPoint, size_t capacity);

		// Methods
		virtual void addMesh(Mesh::Ptr mesh);
		virtual void addEntries(Mesh::Array meshes);
		virtual void select(Plane::Array frustumPlanes, OctreeBlock::Array selection);
	};

};

#endif // BABYLON_OCTREEBLOCK_H