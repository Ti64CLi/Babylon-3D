#ifndef BABYLON_BLACKANDWHITEPOSTPROCESS_H
#define BABYLON_BLACKANDWHITEPOSTPROCESS_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class BlackAndWhitePostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<BlackAndWhitePostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected: 
		BlackAndWhitePostProcess(string name, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static BlackAndWhitePostProcess::Ptr New(string name, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_BLACKANDWHITEPOSTPROCESS_H