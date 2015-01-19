#include "blurPostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::BlurPostProcess::BlurPostProcess(string name, Vector2::Ptr direction, float blurWidth, vector_t<string> parameters, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "blur", parameters, vector_t<string>(), ratio, camera, samplingMode, engine, reusable)
{
	this->direction = direction;
	this->blurWidth = blurWidth;
	this->onApply = [&] (Effect::Ptr effect) {
		effect->setFloat2("screenSize", this->width, this->height);
		effect->setVector2("direction", this->direction);
		effect->setFloat("blurWidth", this->blurWidth);
	};
}

BlurPostProcess::Ptr Babylon::BlurPostProcess::New(string name, Vector2::Ptr direction, float blurWidth, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	vector_t<string> parameters;
	parameters.push_back("screenSize");
	parameters.push_back("direction");
	parameters.push_back("blurWidth");

	auto blurPostProcess = make_shared<BlurPostProcess>(BlurPostProcess(name, direction, blurWidth, parameters, ratio, camera, samplingMode, engine, reusable));
	if (camera) {
		camera->attachPostProcess(blurPostProcess);
	}

	return blurPostProcess;
}