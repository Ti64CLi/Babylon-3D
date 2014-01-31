#include "postProcessManager.h"
#include "engine.h"

using namespace Babylon;

Babylon::PostProcessManager::PostProcessManager(Scene::Ptr scene)
{
	this->_scene = scene;

	// VBO
	Float32Array vertices;
	vertices.push_back(1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);
	vertices.push_back(-1);
	vertices.push_back(1);
	vertices.push_back(-1);

	this->_vertexDeclarations.clear();
	this->_vertexDeclarations.push_back(VertexBufferKind_NormalKind);

	this->_vertexStrideSize = 2 * 4;
	this->_vertexBuffer = scene->getEngine()->createVertexBuffer(vertices);

	// Indices
	Uint16Array indices;
	indices.push_back(0);
	indices.push_back(1);
	indices.push_back(2);

	indices.push_back(0);
	indices.push_back(2);
	indices.push_back(3);

	this->_indexBuffer = scene->getEngine()->createIndexBuffer(indices);
}

// Methods
void Babylon::PostProcessManager::_prepareFrame() {
	auto postProcesses = this->_scene->activeCamera->postProcesses;

	if (postProcesses.size() == 0 || !this->_scene->postProcessesEnabled) {
		return;
	}

	postProcesses[0]->activate();
};

void Babylon::PostProcessManager::_finalizeFrame() {
	auto postProcesses = this->_scene->activeCamera->postProcesses;

	if (postProcesses.size() == 0 || !this->_scene->postProcessesEnabled) {
		return;
	}

	auto engine = this->_scene->getEngine();

	for (auto index = 0; index < postProcesses.size(); index++) {            
		if (index < postProcesses.size() - 1) {
			postProcesses[index + 1]->activate();
		} else {
			engine->restoreDefaultFramebuffer();
		}

		auto effect = postProcesses[index]->apply();

		if (effect) {
			// VBOs
			engine->bindBuffers(this->_vertexBuffer, this->_indexBuffer, this->_vertexDeclarations, this->_vertexStrideSize, effect);

			// Draw order
			engine->draw(true, 0, 6);
		}
	}

	// Restore depth buffer
	engine->setDepthBuffer(true);
	engine->setDepthWrite(true);
};

void Babylon::PostProcessManager::dispose(bool doNotRecurse) {
	if (this->_vertexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_vertexBuffer);
		this->_vertexBuffer = nullptr;
	}

	if (this->_indexBuffer) {
		this->_scene->getEngine()->_releaseBuffer(this->_indexBuffer);
		this->_indexBuffer = nullptr;
	}
};
