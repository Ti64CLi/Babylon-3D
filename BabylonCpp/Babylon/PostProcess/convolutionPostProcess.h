#ifndef BABYLON_CONVOLUTIONPOSTPROCESS_H
#define BABYLON_CONVOLUTIONPOSTPROCESS_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"
#include "matrix.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class ConvolutionPostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<ConvolutionPostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected:
		Matrix::Ptr kernelMatrix;

	protected: 
		ConvolutionPostProcess(string name, Matrix::Ptr kernelMatrix, vector_t<string> parameters, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static ConvolutionPostProcess::Ptr New(string name, Matrix::Ptr kernelMatrix, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_CONVOLUTIONPOSTPROCESS_H