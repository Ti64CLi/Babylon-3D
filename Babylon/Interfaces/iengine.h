#ifndef BABYLON_IENGINE_H
#define BABYLON_IENGINE_H

#include <memory>
#include <vector>

#include "igl.h"

using namespace std;

namespace Babylon {

	struct Capabilities {
		// Caps
		int maxTexturesImageUnits;
		int maxTextureSize;
		int maxCubemapTextureSize;
		int maxRenderTextureSize;

		// Extensions
		bool standardDerivatives;
		bool textureFloat;        
		void* textureAnisotropicFilterExtension;
		int maxAnisotropy;
	};

	struct State {
		void* culling;
	};

	enum ALPHA {
		ALPHA_DISABLE = 0,
		ALPHA_ADD =  1,
		ALPHA_COMBINE = 2,
	};

	// Statics
	enum DELAYLOADSTATE {
		DELAYLOADSTATE_NONE = 0,
		DELAYLOADSTATE_LOADED = 1,
		DELAYLOADSTATE_LOADING = 2,
		DELAYLOADSTATE_NOTLOADED = 4
	};

	class IEngine {

	public:
		typedef shared_ptr<IEngine> Ptr;

	public:
		virtual float getAspectRatio() = 0;
		virtual int getRenderWidth() = 0;
		virtual int getRenderHeight() = 0;
		virtual ICanvas::Ptr getRenderingCanvas() = 0;
		virtual float getHardwareScalingLevel() = 0;
		virtual void updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array vertices, size_t length = 0) = 0;
		virtual void _releaseBuffer(IGLBuffer::Ptr vertexBuffer) = 0;
		virtual IGLBuffer::Ptr createVertexBuffer(Float32Array vertices);
		virtual IGLBuffer::Ptr createDynamicVertexBuffer(GLsizeiptr capacity);
	};

};

#endif // BABYLON_IENGINE_H
