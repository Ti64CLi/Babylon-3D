#include "octree.h"
#include <limits>

using namespace Babylon;

Babylon::Octree::Octree(size_t maxBlockCapacity) 
{
	this->blocks.clear();
	this->_maxBlockCapacity = maxBlockCapacity;
	this->_selection.resize(256);
}

// Methods
void Babylon::Octree::update(Vector3::Ptr worldMin, Vector3::Ptr worldMax, Mesh::Array meshes) {
	_CreateBlocks(worldMin, worldMax, meshes, this->_maxBlockCapacity, this->blocks);
};

void Babylon::Octree::addMesh (Mesh::Ptr mesh) {
	for (auto block : this->blocks) {
		block->addMesh(mesh);
	}
};

OctreeBlock::Array Babylon::Octree::select(Plane::Array frustumPlanes) {
	this->_selection.clear();

	for (auto block : this->blocks) {
		block->select(frustumPlanes, this->_selection);
	}

	return this->_selection;
};

// Statics
void Babylon::Octree::_CreateBlocks (Vector3::Ptr worldMin, Vector3::Ptr worldMax, Mesh::Array meshes, size_t maxBlockCapacity, OctreeBlock::Array blocks) {
	blocks.clear();
	auto blockSize = make_shared<Vector3>((worldMax->x - worldMin->x) / 2, (worldMax->y - worldMin->y) / 2, (worldMax->z - worldMin->z) / 2);

	// Segmenting space
	for (auto x = 0; x < 2; x++) {
		for (auto y = 0; y < 2; y++) {
			for (auto z = 0; z < 2; z++) {
				auto localMin = worldMin->add(blockSize->multiplyByFloats(x, y, z));
				auto localMax = worldMin->add(blockSize->multiplyByFloats(x + 1, y + 1, z + 1));

				auto block = make_shared<OctreeBlock>(localMin, localMax, maxBlockCapacity);
				block->addEntries(meshes);
				blocks.push_back(block);
			}
		}
	}
};
