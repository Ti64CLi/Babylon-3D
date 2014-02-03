#include "renderingGroup.h"
#include <algorithm>
#include "engine.h"

using namespace Babylon;

Babylon::RenderingGroup::RenderingGroup(int index, Scene::Ptr scene)
{
	this->index = index;
	this->_scene = scene;

	this->_opaqueSubMeshes.reserve(256);
	this->_transparentSubMeshes.reserve(256);
	this->_alphaTestSubMeshes.reserve(256);
}

// Methods
bool Babylon::RenderingGroup::render (CustomRenderFunctionFunc customRenderFunction, BeforeTransparentsFunc beforeTransparents) {
	if (customRenderFunction) {
		customRenderFunction(this->_opaqueSubMeshes, this->_alphaTestSubMeshes, this->_transparentSubMeshes, beforeTransparents);
		return true;
	}

	if (this->_opaqueSubMeshes.size() == 0 && this->_alphaTestSubMeshes.size() == 0 && this->_transparentSubMeshes.size()) {
		return false;
	}
	auto engine = this->_scene->getEngine();
	// Opaque
	for (auto submesh : this->_opaqueSubMeshes) {
		this->_activeVertices += submesh->verticesCount;

		submesh->render();
	}

	// Alpha test
	engine->setAlphaTesting(true);
	for (auto submesh : this->_alphaTestSubMeshes) {
		this->_activeVertices += submesh->verticesCount;

		submesh->render();
	}
	engine->setAlphaTesting(false);

	if (beforeTransparents) {
		beforeTransparents();
	}

	// Transparent
	if (this->_transparentSubMeshes.size()) {
		// Sorting
		for (auto submesh : this->_opaqueSubMeshes) {
			submesh->_distanceToCamera = submesh->getBoundingInfo()->boundingSphere->centerWorld->subtract(this->_scene->activeCamera->position)->length();
		}

		auto sortedArray = this->_transparentSubMeshes;
		sortedArray.shrink_to_fit();

		sort(begin(sortedArray), end(sortedArray), [] (const SubMesh::Ptr& a, const SubMesh::Ptr& b) {
			if (a->_distanceToCamera < b->_distanceToCamera) {
				return 1;
			}
			if (a->_distanceToCamera > b->_distanceToCamera) {
				return -1;
			}

			return 0;
		});

		// Rendering
		engine->setAlphaMode(ALPHA_COMBINE);
		for (auto submesh : sortedArray) {
			this->_activeVertices += submesh->verticesCount;

			submesh->render();
		}
		engine->setAlphaMode(ALPHA_DISABLE);
	}
	return true;
};

void Babylon::RenderingGroup::prepare () {
	this->_opaqueSubMeshes.clear();
	this->_transparentSubMeshes.clear();
	this->_alphaTestSubMeshes.clear();
};

void Babylon::RenderingGroup::dispatch (SubMesh::Ptr subMesh) {
	auto material = subMesh->getMaterial();
	auto mesh = subMesh->getMesh();

	if (material->needAlphaBlending() || mesh->visibility < 1.0) { // Transparent
		if (material->alpha > 0 || mesh->visibility < 1.0) {
			this->_transparentSubMeshes.push_back(subMesh);
		}
	} else if (material->needAlphaTesting()) { // Alpha test
		this->_alphaTestSubMeshes.push_back(subMesh);
	} else {
		this->_opaqueSubMeshes.push_back(subMesh); // Opaque
	}
};
