#include "fxaaPostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::FxaaPostProcess::FxaaPostProcess(string name, vector_t<string> parameters, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "fxaa", parameters, vector_t<string>(), ratio, camera, samplingMode, engine, reusable)
{
	this->onSizeChanged = [&] () {
        this->texelWidth = 1.0 / this->width;
        this->texelHeight = 1.0 / this->height;
	};

	this->onApply = [&] (Effect::Ptr effect) {
        effect->setFloat2("texelSize", this->texelWidth, this->texelHeight);
	};
}

FxaaPostProcess::Ptr Babylon::FxaaPostProcess::New(string name, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	vector_t<string> parameters;
	parameters.push_back("texelSize");

	auto fxaaPostProcess = make_shared<FxaaPostProcess>(FxaaPostProcess(name, parameters, ratio, camera, samplingMode, engine, reusable));
	if (camera) {
		camera->attachPostProcess(fxaaPostProcess);
	}

	return fxaaPostProcess;
}