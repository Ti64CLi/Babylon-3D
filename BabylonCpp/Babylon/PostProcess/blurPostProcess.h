#ifndef BABYLON_BLURPOSTPROCESS_H
#define BABYLON_BLURPOSTPROCESS_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"
#include "vector2.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class BlurPostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<BlurPostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected:
		Vector2::Ptr direction;
		float blurWidth;

	protected: 
		BlurPostProcess(string name, Vector2::Ptr direction, float blurWidth, vector_t<string> parameters, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static BlurPostProcess::Ptr New(string name, Vector2::Ptr direction, float blurWidth, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_BLURPOSTPROCESS_H