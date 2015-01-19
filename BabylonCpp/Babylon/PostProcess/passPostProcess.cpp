#include "passPostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::PassPostProcess::PassPostProcess(string name, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "pass", vector_t<string>(), vector_t<string>(), ratio, camera, samplingMode, engine, reusable)
{
}

PassPostProcess::Ptr Babylon::PassPostProcess::New(string name, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	auto passPostProcess = make_shared<PassPostProcess>(PassPostProcess(name, ratio, camera, samplingMode, engine, reusable));
	if (camera) {
		camera->attachPostProcess(passPostProcess);
	}

	return passPostProcess;
}