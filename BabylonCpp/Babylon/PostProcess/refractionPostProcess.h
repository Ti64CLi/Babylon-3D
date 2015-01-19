#ifndef BABYLON_RefractionPostProcess_H
#define BABYLON_RefractionPostProcess_H

#include "decls.h"

#include "iengine.h"
#include "postProcess.h"
#include "color3.h"
#include "texture.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class RefractionPostProcess : public PostProcess {

	public:

		typedef shared_ptr_t<RefractionPostProcess> Ptr;
		typedef vector_t<Ptr> Array;

	protected:
		Color3::Ptr color;
		float depth;
		float colorLevel;
		Texture::Ptr _refRexture;

	protected: 
		RefractionPostProcess(string name, string refractionTextureUrl, Color3::Ptr color, float depth, float colorLevel, vector_t<string> parameters, vector_t<string> samplers, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static RefractionPostProcess::Ptr New(string name, string refractionTextureUrl, Color3::Ptr color, float depth, float colorLevel, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	};

};

#endif // BABYLON_RefractionPostProcess_H