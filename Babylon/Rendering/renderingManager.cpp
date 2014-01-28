#include "renderingManager.h"
#include <time.h>
#include "engine.h"

using namespace Babylon;

// Statics
int Babylon::RenderingManager::MAX_RENDERINGGROUPS = 4;

Babylon::RenderingManager::RenderingManager(Scene::Ptr scene)
{
	this->_scene = scene;
	this->_renderingGroups.clear();
	
	_depthBufferAlreadyCleaned = false;
}

// Methods
void Babylon::RenderingManager::_renderParticles(int index, Mesh::Array activeMeshes) {
	if (this->_scene->_activeParticleSystems.size() == 0) {
		return;
	}

	// Particles
	time_t beforeParticlesDate;
	localtime(&beforeParticlesDate);
	for (auto particleSystem : this->_scene->_activeParticleSystems) {
		if (particleSystem->renderingGroupId != index) {
			continue;
		}

		this->_clearDepthBuffer();

		if (!particleSystem->emitter->position || find(begin(activeMeshes), end(activeMeshes), particleSystem->emitter) != end(activeMeshes)) {
			this->_scene->_activeParticles += particleSystem->render();
		}
	}

	time_t now;
	localtime(&now);
	this->_scene->_particlesDuration += now - beforeParticlesDate;
};

void Babylon::RenderingManager::_renderSprites(int index) {
	if (this->_scene->spriteManagers.size() == 0) {
		return;
	}

	// Sprites       
	time_t beforeSpritessDate;
	localtime(&beforeSpritessDate);
	for (auto spriteManager : this->_scene->spriteManagers) {
		if (spriteManager->renderingGroupId == index) {
			this->_clearDepthBuffer();
			spriteManager->render();
		}
	}

	time_t now;
	localtime(&now);
	this->_scene->_spritesDuration += now - beforeSpritessDate;
};

void Babylon::RenderingManager::_clearDepthBuffer() {
	if (this->_depthBufferAlreadyCleaned) {
		return;
	}

	this->_scene->getEngine()->clear(0, false, true);
	this->_depthBufferAlreadyCleaned = true;
};

void Babylon::RenderingManager::render(CustomRenderFunctionFunc customRenderFunction, Mesh::Array activeMeshes, bool renderParticles, bool renderSprites) {
	auto that = this;

	for (auto index = 0 ; index < MAX_RENDERINGGROUPS; index++) {
		this->_depthBufferAlreadyCleaned = index == 0;
		auto renderingGroup = this->_renderingGroups[index];

		if (renderingGroup) {
			this->_clearDepthBuffer();
			if (!renderingGroup->render(customRenderFunction, [&] () {
				if (renderSprites) {
					that->_renderSprites(index);
				}
			})) {
				this->_renderingGroups.erase(begin(this->_renderingGroups) + index, begin(this->_renderingGroups) + index);
			}
		} else if (renderSprites) {
			this->_renderSprites(index);
		}

		if (renderParticles) {
			this->_renderParticles(index, activeMeshes);
		}
	}
};

void Babylon::RenderingManager::reset() {
	for (auto renderingGroup : this->_renderingGroups) {
		renderingGroup->prepare();
	}
};

void Babylon::RenderingManager::dispatch(SubMesh::Ptr subMesh) {
	auto mesh = subMesh->getMesh();
	auto renderingGroupId = mesh->renderingGroupId;

	if (!this->_renderingGroups[renderingGroupId]) {
		this->_renderingGroups[renderingGroupId] = make_shared<RenderingGroup>(renderingGroupId, this->_scene);
	}

	this->_renderingGroups[renderingGroupId]->dispatch(subMesh);
};
