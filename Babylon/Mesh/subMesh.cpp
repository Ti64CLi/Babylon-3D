#include "subMesh.h"
#include <limits>
#include "engine.h"
#include "tools.h"
#include "mesh.h"
#include "material.h"

using namespace Babylon;

Babylon::SubMesh::SubMesh(int materialIndex, int verticesStart, size_t verticesCount, int indexStart, size_t indexCount, Mesh::Ptr mesh) {
	this->_mesh = mesh;
	// moved to new
	////mesh->subMeshes.push_back(shared_from_this());
	this->materialIndex = materialIndex;
	this->verticesStart = verticesStart;
	this->verticesCount = verticesCount;
	this->indexStart = indexStart;
	this->indexCount = indexCount;

	this->refreshBoundingInfo();
};

SubMesh::Ptr SubMesh::New(int materialIndex, int verticesStart, size_t verticesCount, int indexStart, size_t indexCount, Mesh::Ptr mesh)
{
	auto subMesh = make_shared<SubMesh>(SubMesh(materialIndex, verticesStart, verticesCount, indexStart, indexCount, mesh));
	mesh->subMeshes.push_back(subMesh);
	return subMesh;
}

//Properties
BoundingInfo::Ptr Babylon::SubMesh::getBoundingInfo() {
	return this->_boundingInfo;
};

Mesh::Ptr Babylon::SubMesh::getMesh() {
	return this->_mesh;
};

Material::Ptr Babylon::SubMesh::getMaterial() {
	auto rootMaterial = this->_mesh->material;

	MultiMaterial::Ptr multiMaterial = dynamic_pointer_cast<MultiMaterial>(rootMaterial);
	if (multiMaterial) {
		return multiMaterial->getSubMaterial(this->materialIndex);
	}

	if (!rootMaterial) {
		return this->_mesh->_scene->defaultMaterial;
	}

	return rootMaterial;
};

// Methods
void Babylon::SubMesh::refreshBoundingInfo() {
	auto data = this->_mesh->getVerticesData(VertexBufferKind_PositionKind);

	if (data.size() == 0) {
		return;
	}

	auto extend = Tools::ExtractMinAndMax(data, this->verticesStart, this->verticesCount);
	this->_boundingInfo = make_shared<BoundingInfo>(extend.minimum, extend.maximum);
};

// TODO: finish collider
/*
Babylon::SubMesh::_checkCollision(collider) {
	return this->_boundingInfo->_checkCollision(collider);
};
*/

void Babylon::SubMesh::updateBoundingInfo(Matrix::Ptr world, float scale) {
	this->_boundingInfo->_update(world, scale);
};

bool Babylon::SubMesh::isInFrustum(Plane::Array frustumPlanes) {
	return this->_boundingInfo->isInFrustum(frustumPlanes);
};

void Babylon::SubMesh::render() {
	this->_mesh->render(shared_from_this());
};

IGLBuffer::Ptr Babylon::SubMesh::getLinesIndexBuffer(Uint16Array indices, Engine::Ptr engine) {
	if (!this->_linesIndexBuffer) {
		Uint16Array linesIndices;

		for (auto index = this->indexStart; index < this->indexStart + this->indexCount; index += 3) {
			linesIndices.push_back(indices[index]);
			linesIndices.push_back(indices[index + 1]);
			linesIndices.push_back(indices[index + 1]);
			linesIndices.push_back(indices[index + 2]);
			linesIndices.push_back(indices[index + 2]);
			linesIndices.push_back(indices[index]);
		}

		this->_linesIndexBuffer = engine->createIndexBuffer(linesIndices);
		this->linesIndexCount = linesIndices.size();
	}
	return this->_linesIndexBuffer;
};

bool Babylon::SubMesh::canIntersects(Ray::Ptr ray) {
	return ray->intersectsBox(this->_boundingInfo->boundingBox);
};

float Babylon::SubMesh::intersects(Ray::Ptr ray, Vector3::Array positions, Uint16Array indices, bool fastCheck) {
	auto distance = numeric_limits<float>::max();

	// Triangles test
	for (auto index = this->indexStart; index < this->indexStart + this->indexCount; index += 3) {
		auto p0 = positions[indices[index]];
		auto p1 = positions[indices[index + 1]];
		auto p2 = positions[indices[index + 2]];

		auto currentDistance = ray->intersectsTriangle(p0, p1, p2);

		if (currentDistance > 0) {
			if (fastCheck || currentDistance < distance) {
				distance = currentDistance;

				if (fastCheck) {
					break;
				}
			}
		}
	}

	if (distance > 0 && distance < numeric_limits<float>::max())
		return distance;

	return 0;
};

// Clone    
SubMesh::Ptr Babylon::SubMesh::clone(Mesh::Ptr newMesh) {
	return make_shared<SubMesh>(SubMesh(this->materialIndex, this->verticesStart, this->verticesCount, this->indexStart, this->indexCount, newMesh));
};

// Statics
SubMesh::Ptr Babylon::SubMesh::CreateFromIndices(int materialIndex, int startIndex, size_t indexCount, Mesh::Ptr mesh) {
	auto minVertexIndex = numeric_limits<float>::max();
	auto maxVertexIndex = -numeric_limits<float>::max();

	auto indices = mesh->getIndices();

	for (auto index = startIndex; index < startIndex + indexCount; index++) {
		auto vertexIndex = indices[index];

		if (vertexIndex < minVertexIndex)
			minVertexIndex = vertexIndex;
		else if (vertexIndex > maxVertexIndex)
			maxVertexIndex = vertexIndex;
	}

	return make_shared<SubMesh>(SubMesh(materialIndex, minVertexIndex, maxVertexIndex - minVertexIndex, startIndex, indexCount, mesh));
};

