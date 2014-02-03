#include "postProcess.h"
#include <algorithm>
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::PostProcess::PostProcess(string name, string fragmentUrl,  vector<string> parameters, vector<string> samplers, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode)
{
	this->name = name;
	this->_camera = camera;
	this->_scene = camera->getScene();
	camera->postProcesses.push_back(shared_from_this());
	this->_engine = this->_scene->getEngine();
	this->_renderRatio = ratio;
	this->width = -1;
	this->height = -1;
	this->renderTargetSamplingMode = samplingMode ? samplingMode : NEAREST_SAMPLINGMODE;

	vector<VertexBufferKind> attributes;
	attributes.push_back(VertexBufferKind_PositionKind);

	vector<string> _samplers;
	_samplers.insert(end(_samplers), begin(samplers), end(samplers));
	samplers.push_back("textureSampler");

	vector<string> optionalDefines;

	this->_effect = this->_engine->createEffect("postprocess", "postprocess", fragmentUrl,
		attributes,
		parameters,
		_samplers, 
		"", 
		optionalDefines);

	onApply = nullptr;
	_onDispose = nullptr;
	onSizeChanged = nullptr;
}

void Babylon::PostProcess::activate () {
	auto desiredWidth = this->_engine->_renderingCanvas->getWidth() * this->_renderRatio;
	auto desiredHeight = this->_engine->_renderingCanvas->getHeight() * this->_renderRatio;
	if (this->width != desiredWidth || this->height != desiredHeight) {
		if (this->_texture) {
			this->_engine->_releaseTexture(this->_texture);
			this->_texture = nullptr;
		}
		this->width = desiredWidth;
		this->height = desiredHeight;
		
		bool found = find(begin(this->_camera->postProcesses), end(this->_camera->postProcesses), shared_from_this()) != end(this->_camera->postProcesses);
		this->_texture = this->_engine->createRenderTargetTexture(Size(this->width, this->height), false, found, this->renderTargetSamplingMode);
		if (this->onSizeChanged) {
			this->onSizeChanged();
		}
	}
	this->_engine->bindFramebuffer(this->_texture);

	// Clear
	this->_engine->clear(this->_scene->clearColor, this->_scene->autoClear || this->_scene->forceWireframe, true);
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
	this->_effect->_bindTexture("textureSampler", this->_texture);

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
	if (this->_texture) {
		this->_engine->_releaseTexture(this->_texture);
		this->_texture = nullptr;
	}

	auto it = find( begin(this->_camera->postProcesses), end(this->_camera->postProcesses), shared_from_this());
	if (it != end(this->_camera->postProcesses))
	{
		this->_camera->postProcesses.erase(it);
		this->_camera->postProcesses[it - begin(this->_camera->postProcesses)]->width = -1; // invalidate frameBuffer to hint the postprocess to create a depth buffer
	}
};
