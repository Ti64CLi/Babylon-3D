#include "convolutionPostProcess.h"
#include "defs.h"
#include "engine.h"
#include "camera.h"

using namespace Babylon;

Babylon::ConvolutionPostProcess::ConvolutionPostProcess(string name, Matrix::Ptr kernelMatrix, vector_t<string> parameters, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
	: PostProcess(name, "convolution", parameters, vector_t<string>(), ratio, camera, samplingMode, engine, reusable)
{
	this->kernelMatrix = kernelMatrix;
	this->onApply = [&] (Effect::Ptr effect) {
		effect->setMatrix("kernelMatrix", this->kernelMatrix);
	};
}

ConvolutionPostProcess::Ptr Babylon::ConvolutionPostProcess::New(string name, Matrix::Ptr kernelMatrix, float ratio, Camera::Ptr camera, SAMPLINGMODES samplingMode, Engine::Ptr engine, bool reusable)
{
	vector_t<string> parameters;
	parameters.push_back("kernelMatrix");

	auto convolutionPostProcess = make_shared<ConvolutionPostProcess>(ConvolutionPostProcess(name, kernelMatrix, parameters, ratio, camera, samplingMode, engine, reusable));
	if (camera) {
		camera->attachPostProcess(convolutionPostProcess);
	}

	return convolutionPostProcess;
}