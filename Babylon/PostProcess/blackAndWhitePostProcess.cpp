#include "blackAndWhitePostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::BlackAndWhitePostProcess::BlackAndWhitePostProcess(string name, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "", vector_t<string>(), vector_t<string>(), ratio, camera, samplingMode, engine, reusable)
{
}

BlackAndWhitePostProcess::Ptr Babylon::BlackAndWhitePostProcess::New(string name, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	auto blackAndWhitePostProcess = make_shared<BlackAndWhitePostProcess>(BlackAndWhitePostProcess(name, ratio, camera, samplingMode, engine, reusable));
	camera->postProcesses.push_back(blackAndWhitePostProcess);
	return blackAndWhitePostProcess;
}