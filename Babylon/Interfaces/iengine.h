#ifndef BABYLON_IENGINE_H
#define BABYLON_IENGINE_H

#include <memory>
#include <vector>

#include "igl.h"

using namespace std;

namespace Babylon {

	const string ShadersRepository = "Babylon/Shaders/";

	class Matrix;
	typedef shared_ptr<Matrix> MatrixPtr;
	struct Vector3;
	typedef shared_ptr<Vector3> Vector3Ptr;
	struct Color3;
	typedef shared_ptr<Color3> Color3Ptr;

	struct Capabilities {
		// Caps
		size_t maxTexturesImageUnits;
		size_t maxTextureSize;
		size_t maxCubemapTextureSize;
		size_t maxRenderTextureSize;

		// Extensions
		bool standardDerivatives;
		bool textureFloat;        
		void* textureAnisotropicFilterExtension;
		int maxAnisotropy;
	};

	struct State {
		bool culling;
	};

	enum ALPHA_MODES {
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
		virtual IGLBuffer::Ptr createVertexBuffer(Float32Array vertices) = 0;
		virtual IGLBuffer::Ptr createDynamicVertexBuffer(GLsizeiptr capacity) = 0;
		virtual void setMatrices(IGLUniformLocation::Ptr uniform, Float32Array matrices) = 0;
		virtual void setMatrix(IGLUniformLocation::Ptr uniform, MatrixPtr matrix) = 0;
		virtual void setFloat(IGLUniformLocation::Ptr uniform, GLfloat value) = 0;
		virtual void setFloat2(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y) = 0;
		virtual void setFloat3(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z) = 0;
		virtual void setBool(IGLUniformLocation::Ptr uniform, GLboolean _bool) = 0;
		virtual void setFloat4(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z, GLfloat w) = 0;
		virtual void setColor3(IGLUniformLocation::Ptr uniform, Color3Ptr color3) = 0;
		virtual void setColor4(IGLUniformLocation::Ptr uniform, Color3Ptr color3, GLfloat alpha) = 0;
	};

};

#endif // BABYLON_IENGINE_H
