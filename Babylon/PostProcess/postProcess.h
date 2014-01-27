#ifndef BABYLON_PostProcess_H
#define BABYLON_PostProcess_H

#include <memory>
#include <vector>
#include <map>

#include "iengine.h"
#include "effect.h"

using namespace std;

namespace Babylon {

	class Camera;
	typedef shared_ptr<Camera> CameraPtr;

	class PostProcess : public enable_shared_from_this<PostProcess> {

	public:

		typedef shared_ptr<PostProcess> Ptr;
		typedef vector<Ptr> Array;

		typedef void (*OnApplyFunc)(Effect::Ptr);
		typedef void (*OnDisposeFunc)();
		typedef void (*OnSizeChangedFunc)();

		string name;
		CameraPtr _camera;

		IGLBuffer::Ptr _vertexBuffer;
		Int32Array _vertexDeclaration;
		size_t _vertexStrideSize;
		IGLBuffer::Ptr _indexBuffer;

		Effect::Ptr _effect;
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
		virtual Effect::Ptr apply();
		virtual void dispose();
	};

};

#endif // BABYLON_PostProcess_H