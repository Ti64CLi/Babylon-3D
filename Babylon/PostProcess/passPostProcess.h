#ifndef BABYLON_PassPostProcess_H
#define BABYLON_PassPostProcess_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class PassPostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<PassPostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected: 
		PassPostProcess(string name, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static PassPostProcess::Ptr New(string name, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_PassPostProcess_H