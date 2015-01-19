#include "renderTargetTexture.h"
#include "engine.h"

using namespace Babylon;

Babylon::RenderTargetTexture::RenderTargetTexture(string name, Size size, Scene::Ptr scene, bool generateMipMaps)
	: Texture(nullptr, scene, false, false)
{
	this->_scene = scene;
	// moved to new
	////this->_scene->textures.push_back(enable_shared_from_this<RenderTargetTexture>::shared_from_this());

	this->name = name;
	this->_generateMipMaps = generateMipMaps;

	this->wrapU = WRAP_ADDRESSMODE;
	this->wrapV = WRAP_ADDRESSMODE;

	this->_texture = scene->getEngine()->createDynamicTexture(size.width, size.height, generateMipMaps);

	this->renderList.clear();

	// Rendering groups
	this->_renderingManager = make_shared<RenderingManager>(scene);

	// Members        
	this->renderParticles = true;
	this->renderSprites = false;
	this->isRenderTarget = true;
	this->coordinatesMode = PROJECTION_MODE;

	// Methods  
	this->onBeforeRender = nullptr;
	this->onAfterRender = nullptr;

};

RenderTargetTexture::Ptr Babylon::RenderTargetTexture::New(string name, Size size, Scene::Ptr scene, bool generateMipMaps) {
	auto renderTargetTexture = make_shared<RenderTargetTexture>(RenderTargetTexture(name, size, scene, generateMipMaps));
	renderTargetTexture->_scene->textures.push_back(renderTargetTexture);
	return renderTargetTexture;
}

// Methods  
void Babylon::RenderTargetTexture::resize(Size size, bool generateMipMaps) {
	this->releaseInternalTexture();
	this->_texture = this->_scene->getEngine()->createRenderTargetTexture(size, generateMipMaps);
};

void Babylon::RenderTargetTexture::render() {

	if (this->onBeforeRender) {
		this->onBeforeRender();
	}

	auto scene = this->_scene;
	auto engine = scene->getEngine();

	if (this->_waitingRenderList.size() > 0) {
		this->renderList.clear();
		for (auto id : this->_waitingRenderList) {
			this->renderList.push_back(this->_scene->getMeshByID(id));
		}

		////delete this->_waitingRenderList;
		this->_waitingRenderList.clear();
	}

	if (this->renderList.size() == 0) {
		if (this->onAfterRender) {
			this->onAfterRender();
		}
		return;
	}

	// Bind
	engine->bindFramebuffer(this->_texture);

	// Clear
	engine->clear(scene->clearColor, true, true);

	this->_renderingManager.reset();

	for (auto mesh : this->renderList) {
		if (mesh && mesh->isEnabled() && mesh->isVisible) {
			for (auto subMesh : mesh->subMeshes) {
				scene->_activeVertices += subMesh->verticesCount;
				this->_renderingManager->dispatch(subMesh);
			}
		}
	}

	// Render
	this->_renderingManager->render(this->customRenderFunction, this->renderList, this->renderParticles, this->renderSprites);

	// Unbind
	engine->unBindFramebuffer(this->_texture);

	if (this->onAfterRender) {
		this->onAfterRender();
	}
};

Texture::Ptr Babylon::RenderTargetTexture::clone() {
	auto textureSize = this->getSize();
	auto newTexture = RenderTargetTexture::New(this->name, textureSize, this->_scene, this->_generateMipMaps);

	// Base texture
	newTexture->hasAlpha = this->hasAlpha;
	newTexture->level = this->level;

	// RenderTarget Texture
	newTexture->coordinatesMode = this->coordinatesMode;
	newTexture->renderList.clear();
	newTexture->renderList.insert(end(newTexture->renderList), begin(this->renderList), end(this->renderList));
	this->renderList.clear();

	return newTexture;
};
