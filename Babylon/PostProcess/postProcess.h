#ifndef BABYLON_PostProcess_H
#define BABYLON_PostProcess_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr<Effect> EffectPtr;

	class PostProcess : public IDisposable, public enable_shared_from_this<PostProcess> {

	public:

		typedef shared_ptr<PostProcess> Ptr;
		typedef vector<Ptr> Array;

		typedef void (*OnApplyFunc)(EffectPtr);
		typedef void (*OnDisposeFunc)();
		typedef void (*OnSizeChangedFunc)();

		string name;
		CameraPtr _camera;

		IGLBuffer::Ptr _vertexBuffer;
		Int32Array _vertexDeclaration;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		EffectPtr _effect;
		IGLTexture::Ptr _texture;

		float _renderRatio;
		int width;
		int height;
		SAMPLINGMODES renderTargetSamplingMode;

	protected:
		EnginePtr _engine;
		ScenePtr _scene;
		OnApplyFunc onApply;
		OnDisposeFunc _onDispose;
		OnSizeChangedFunc onSizeChanged;

	public: 
		PostProcess(string name, string fragmentUrl,  vector<string> parameters, vector<string> samplers, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode);

		// Methods
		virtual void activate();
		virtual EffectPtr apply();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_PostProcess_H