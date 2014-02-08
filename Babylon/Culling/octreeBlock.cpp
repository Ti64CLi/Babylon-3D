#include "octreeBlock.h"
#include "defs.h"
#include "octree.h"

using namespace Babylon;

Babylon::OctreeBlock::OctreeBlock(Vector3::Ptr minPoint, Vector3::Ptr maxPoint, size_t capacity) 
{
	this->subMeshes.clear();
	this->meshes.clear();
	this->_capacity = capacity;

	this->_minPoint = minPoint;
	this->_maxPoint = maxPoint;

	this->_boundingVectors.clear();

	this->_boundingVectors.push_back(minPoint->clone());
	this->_boundingVectors.push_back(maxPoint->clone());

	this->_boundingVectors.push_back(minPoint->clone());
	this->_boundingVectors[2]->x = maxPoint->x;

	this->_boundingVectors.push_back(minPoint->clone());
	this->_boundingVectors[3]->y = maxPoint->y;

	this->_boundingVectors.push_back(minPoint->clone());
	this->_boundingVectors[4]->z = maxPoint->z;

	this->_boundingVectors.push_back(maxPoint->clone());
	this->_boundingVectors[5]->z = minPoint->z;

	this->_boundingVectors.push_back(maxPoint->clone());
	this->_boundingVectors[6]->x = minPoint->x;

	this->_boundingVectors.push_back(maxPoint->clone());
	this->_boundingVectors[7]->y = minPoint->y;

}

// Methods
void Babylon::OctreeBlock::addMesh(Mesh::Ptr mesh) {
	if (this->blocks.size() > 0) {
		for (auto block : this->blocks) {
			block->addMesh(mesh);
		}
		return;
	}

	if (mesh->getBoundingInfo()->boundingBox->intersectsMinMax(this->_minPoint, this->_maxPoint)) {
		auto localMeshIndex = this->meshes.size();
		this->meshes.push_back(mesh);

		this->subMeshes[localMeshIndex].clear();
		for (auto subMesh : mesh->subMeshes) {
			if (mesh->subMeshes.size() == 1 || subMesh->getBoundingInfo()->boundingBox->intersectsMinMax(this->_minPoint, this->_maxPoint)) {
				this->subMeshes[localMeshIndex].push_back(subMesh);
			}
		}
	}

	if (this->subMeshes.size() > this->_capacity) {
		Octree::_CreateBlocks(this->_minPoint, this->_maxPoint, this->meshes, this->_capacity, this->blocks);
	}
};

void Babylon::OctreeBlock::addEntries(Mesh::Array meshes) {
	for (auto mesh : meshes) {
		this->addMesh(mesh);
	}       
};

void Babylon::OctreeBlock::select(Plane::Array frustumPlanes, OctreeBlock::Array selection) {
	if (this->blocks.size() != 0) {
		for (auto block : this->blocks) {
			block->select(frustumPlanes, selection);
		}
		return;
	}
	if (BoundingBox::IsInFrustum(this->_boundingVectors, frustumPlanes)) {
		selection.push_back(shared_from_this());
	}
};
