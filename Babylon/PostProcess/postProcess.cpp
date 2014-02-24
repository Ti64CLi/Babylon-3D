#include "postProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::PostProcess::PostProcess(string name, string fragmentUrl,  vector_t<string> parameters, vector_t<string> samplers, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	this->name = name;

	if (camera) {
		this->_camera = camera;
		this->_scene = camera->getScene();
		// moved to New
		////camera->postProcesses.push_back(shared_from_this());
		this->_engine = this->_scene->getEngine();
	}
	else
	{
		this->_engine = engine;
	}

	this->_renderRatio = ratio;
	this->width = -1;
	this->height = -1;
	this->renderTargetSamplingMode = samplingMode ? samplingMode : NEAREST_SAMPLINGMODE;
	this->_reusable = reusable || false;

	this->_textures.reserve(2);
	this->_currentRenderTextureInd = 0;

	vector_t<VertexBufferKind> attributes;
	attributes.push_back(VertexBufferKind_PositionKind);

	vector_t<string> _samplers;
	_samplers.insert(end(_samplers), begin(samplers), end(samplers));
	_samplers.push_back("textureSampler");

	vector_t<string> optionalDefines;

	this->_effect = this->_engine->createEffect("postprocess", "postprocess", fragmentUrl,
		attributes,
		parameters,
		_samplers, 
		"", 
		optionalDefines);

	onApply = nullptr;
	_onDispose = nullptr;
	onSizeChanged = nullptr;
	onActivate = nullptr;
}

PostProcess::Ptr Babylon::PostProcess::New(string name, string fragmentUrl,  vector_t<string> parameters, vector_t<string> samplers, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool resuable)
{
	auto postProcess = make_shared<PostProcess>(PostProcess(name, fragmentUrl, parameters, samplers, ratio, camera, samplingMode, engine, resuable));
	if (camera) {
		camera->attachPostProcess(postProcess);
	}

	return postProcess;
}

void Babylon::PostProcess::activate (Camera::Ptr _camera) {
	auto camera = (_camera) ? _camera : this->_camera;

	auto scene = camera->getScene();
	auto desiredWidth = this->_engine->_renderingCanvas->getWidth() * this->_renderRatio;
	auto desiredHeight = this->_engine->_renderingCanvas->getHeight() * this->_renderRatio;
	if (this->width != desiredWidth || this->height != desiredHeight) {
		if (this->_textures.size() > 0) {
			for (auto texture : this->_textures) {
				this->_engine->_releaseTexture(texture);
			}

			this->_textures.clear();
		}

		this->width = desiredWidth;
		this->height = desiredHeight;

		bool found = find(begin(this->_camera->postProcesses), end(this->_camera->postProcesses), shared_from_this()) != end(this->_camera->postProcesses);
		this->_textures.push_back(this->_engine->createRenderTargetTexture(Size(this->width, this->height), false, found, this->renderTargetSamplingMode));

		if (this->_reusable)
		{
			this->_textures.push_back(this->_engine->createRenderTargetTexture(Size(this->width, this->height), false, found, this->renderTargetSamplingMode));
		}

		if (this->onSizeChanged) {
			this->onSizeChanged();
		}
	}

	this->_engine->bindFramebuffer(this->_textures[this->_currentRenderTextureInd]);

	if (this->onActivate) {
		this->onActivate(camera);
	}

	// Clear
	this->_engine->clear(this->_scene->clearColor, this->_scene->autoClear || this->_scene->forceWireframe, true);

	if (this->_reusable) {
		this->_currentRenderTextureInd = (this->_currentRenderTextureInd + 1) % 2;
	}
};

Effect::Ptr Babylon::PostProcess::apply () {
	// Check
	if (!this->_effect->isReady())
		return nullptr;

	// States
	this->_engine->enableEffect(this->_effect);
	this->_engine->setState(false);
	this->_engine->setAlphaMode(ALPHA_DISABLE);
	this->_engine->setDepthBuffer(false);
	this->_engine->setDepthWrite(false);

	// Texture
	this->_effect->_bindTexture("textureSampler", this->_textures[this->_currentRenderTextureInd]);

	// Parameters
	if (this->onApply) {
		this->onApply(this->_effect);
	}

	return this->_effect;
};

void Babylon::PostProcess::dispose (bool doNotRecurse) {
	if (this->_onDispose) {
		this->_onDispose();
	}

	if (this->_textures.size() > 0) {
		for (auto texture : this->_textures) {
			this->_engine->_releaseTexture(texture);
		}

		this->_textures.clear();
	}

	this->_camera->detachPostProcess(shared_from_this());

	auto it = find( begin(this->_camera->postProcesses), end(this->_camera->postProcesses), shared_from_this());
	if (it != end(this->_camera->postProcesses))
	{
		this->_camera->postProcesses.erase(it);
		this->_camera->postProcesses[it - begin(this->_camera->postProcesses)]->width = -1; // invalidate frameBuffer to hint the postprocess to create a depth buffer
	}
};
