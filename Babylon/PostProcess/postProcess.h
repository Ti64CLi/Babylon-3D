#ifndef BABYLON_POSTPROCESS_H
#define BABYLON_POSTPROCESS_H

#include "decls.h"

#include "iengine.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr_t<Camera> CameraPtr;

	class Effect;
	typedef shared_ptr_t<Effect> EffectPtr;

	class PostProcess : public IDisposable, public enable_shared_from_this<PostProcess> {

	public:

		typedef shared_ptr_t<PostProcess> Ptr;
		typedef vector_t<Ptr> Array;

		typedef void (*OnApplyFunc)(EffectPtr);
		typedef void (*OnDisposeFunc)();
		typedef void (*OnSizeChangedFunc)();
		typedef void (*OnActivateFunc)(CameraPtr);

		string name;
		CameraPtr _camera;

		IGLBuffer::Ptr _vertexBuffer;
		Int32Array _vertexDeclaration;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		EffectPtr _effect;

		float _renderRatio;
		int width;
		int height;
		SAMPLINGMODES renderTargetSamplingMode;
		bool _reusable;
		IGLTexture::Array _textures;
		int _currentRenderTextureInd;

	protected:
		EnginePtr _engine;
		ScenePtr _scene;
		OnApplyFunc onApply;
		OnDisposeFunc _onDispose;
		OnSizeChangedFunc onSizeChanged;
		OnActivateFunc onActivate;

	protected: 
		PostProcess(string name, string fragmentUrl,  vector_t<string> parameters, vector_t<string> samplers, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);
	public: 
		static PostProcess::Ptr New(string name, string fragmentUrl,  vector_t<string> parameters, vector_t<string> samplers, float ratio, CameraPtr camera, SAMPLINGMODES samplingMode, EnginePtr engine, bool reusable);

		// Methods
		virtual void activate(CameraPtr camera = nullptr);
		virtual EffectPtr apply();
		virtual void dispose(bool doNotRecurse = false);
	};

};

#endif // BABYLON_POSTPROCESS_H