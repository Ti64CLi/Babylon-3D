#ifndef BABYLON_IENGINE_H
#define BABYLON_IENGINE_H

#include <memory>
#include <vector>

#include "igl.h"

using namespace std;

namespace Babylon {

	const string ShadersRepository = "Babylon/Shaders/";

	enum ALPHA_MODES {
		ALPHA_DISABLE = 0,
		ALPHA_ADD =  1,
		ALPHA_COMBINE = 2,
	};

	// TODO: Move to Engine class
	enum DELAYLOADSTATE {
		DELAYLOADSTATE_NONE = 0,
		DELAYLOADSTATE_LOADED = 1,
		DELAYLOADSTATE_LOADING = 2,
		DELAYLOADSTATE_NOTLOADED = 4
	};

	// TODO: Move to Texture class
	enum SAMPLINGMODES {
		NEAREST_SAMPLINGMODE = 1,
		BILINEAR_SAMPLINGMODE = 2,
		TRILINEAR_SAMPLINGMODE = 3
	};

	// TODO: Move to Texture class
	enum MODES {
		EXPLICIT_MODE = 0,
		SPHERICAL_MODE = 1,
		PLANAR_MODE = 2,
		CUBIC_MODE = 3,
		PROJECTION_MODE = 4,
		SKYBOX_MODE = 5
	};

	// TODO: Move to Texture class
	enum ADDRESSMODES {
		CLAMP_ADDRESSMODE = 0,
		WRAP_ADDRESSMODE = 1,
		MIRROR_ADDRESSMODE = 2
	};

	enum FOGMODES {
		FOGMODE_NONE = 0,
		FOGMODE_EXP = 1,
		FOGMODE_EXP2 = 2,
		FOGMODE_LINEAR = 3
	};

	enum CAMERAS {
		PERSPECTIVE_CAMERA = 0,
		ORTHOGRAPHIC_CAMERA = 1,
	};

	class Matrix;
	typedef shared_ptr<Matrix> MatrixPtr;
	struct Vector3;
	typedef shared_ptr<Vector3> Vector3Ptr;
	struct Color3;
	typedef shared_ptr<Color3> Color3Ptr;
	class IScene;
	typedef shared_ptr<IScene> IScenePtr;
	class Effect;
	typedef shared_ptr<Effect> EffectPtr;

	struct Size {
	public:
		GLint width;
		GLint height;

		Size(GLint width_, GLint height_)
			: width(width_), height(height_)
		{
		}
	};

	struct Capabilities {
		// Caps
		size_t maxTexturesImageUnits;
		size_t maxTextureSize;
		size_t maxCubemapTextureSize;
		size_t maxRenderTextureSize;

		// Extensions
		bool standardDerivatives;
		bool textureFloat;        
		bool textureAnisotropicFilterExtension;
		int maxAnisotropy;
	};

	struct State {
		bool culling;
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
		virtual IGLTexture::Array& getLoadedTexturesCache() = 0;
		virtual void updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array vertices, size_t length = 0) = 0;
		virtual void updateVideoTexture(IGLTexture::Ptr texture, IVideo::Ptr video);
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
		virtual IGLTexture::Ptr createTexture(string url, bool noMipmap, bool invertY, IScenePtr scene) = 0;
		virtual IGLTexture::Ptr createDynamicTexture(int width, int height, bool generateMipMaps) = 0;
		virtual void _releaseTexture(IGLTexture::Ptr texture) = 0;
		virtual void enableEffect(EffectPtr effect) = 0;
		virtual void setState(bool culling) = 0;
	};

};

#endif // BABYLON_IENGINE_H
