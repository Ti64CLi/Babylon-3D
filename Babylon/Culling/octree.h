#ifndef BABYLON_Octree_H
#define BABYLON_Octree_H

#include <memory>
#include <vector>
#include <map>

#include "octreeBlock.h"
#include "mesh.h"

using namespace std;

namespace Babylon {

	class Octree : public enable_shared_from_this<Octree> {

	public:

		typedef shared_ptr<Octree> Ptr;
		typedef vector<Ptr> Array;

		OctreeBlock::Array blocks;
		int _maxBlockCapacity;
		OctreeBlock::Array _selection;

	public: 
		Octree(size_t maxBlockCapacity = 64);

		// Methods
		virtual void update(Vector3::Ptr worldMin, Vector3::Ptr worldMax, Mesh::Array meshes);
		virtual void addMesh(Mesh::Ptr mesh);
		virtual OctreeBlock::Array select(Plane::Array frustumPlanes);
		// Statics
		static void _CreateBlocks(Vector3::Ptr worldMin, Vector3::Ptr worldMax, Mesh::Array meshes, size_t maxBlockCapacity, OctreeBlock::Array blocks);
	};

};

#endif // BABYLON_Octree_H