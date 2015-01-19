#include "refractionPostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::RefractionPostProcess::RefractionPostProcess(string name, string refractionTextureUrl, Color3::Ptr color, float depth, float colorLevel, vector_t<string> parameters, vector_t<string> samplers, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "refraction", parameters, samplers, ratio, camera, samplingMode, engine, reusable)
{
    this->color = color;
    this->depth = depth;
    this->colorLevel = colorLevel;
    this->_refRexture = nullptr;

	this->onActivate = [&] (Camera::Ptr camera) {
		if (!this->_refRexture)
		{
			this->_refRexture = Texture::New(refractionTextureUrl, camera->getScene());
		}
	};

	this->onApply = [&] (Effect::Ptr effect) {
		effect->setColor3("baseColor", this->color);
		effect->setFloat("depth", this->depth);
		effect->setFloat("colorLevel", this->colorLevel);

		effect->setTexture("refractionSampler", this->_refRexture);
	};
}

RefractionPostProcess::Ptr Babylon::RefractionPostProcess::New(string name, string refractionTextureUrl, Color3::Ptr color, float depth, float colorLevel, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	vector_t<string> parameters;
	parameters.push_back("baseColor");
	parameters.push_back("depth");
	parameters.push_back("colorLevel");

	vector_t<string> samplers;
	samplers.push_back("refractionSampler");

	auto refractionPostProcess = make_shared<RefractionPostProcess>(RefractionPostProcess(name, refractionTextureUrl, color, depth, colorLevel, parameters, samplers, ratio, camera, samplingMode, engine, reusable));
	if (camera) {
		camera->attachPostProcess(refractionPostProcess);
	}

	return refractionPostProcess;
}