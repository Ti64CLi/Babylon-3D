#ifndef BABYLON_FXAAPOSTPROCESS_H
#define BABYLON_FXAAPOSTPROCESS_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class FxaaPostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<FxaaPostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected:
		float texelWidth;
		float texelHeight;

	protected: 
		FxaaPostProcess(string name, vector_t<string> parameters, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static FxaaPostProcess::Ptr New(string name, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_FXAAPOSTPROCESS_H