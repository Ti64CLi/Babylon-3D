#ifndef BABYLON_ENGINE_H
#define BABYLON_ENGINE_H

#include <memory>
#include <vector>
#include <string>
#include <map>

#include "icanvas.h"
#include "iengine.h"
#include "igl.h"
#include "scene.h"
#include "tools_math.h"
#include "effect.h"
#include "vertexbuffer.h"
#include "texture.h"

using namespace std;

namespace Babylon {

	class Engine : public IDisposable, public enable_shared_from_this<Engine> {

	public:
		typedef shared_ptr<Engine> Ptr;
		typedef void (*RenderFunction)();

		// Statics
		const static char* ShadersRepository;

		static float epsilon;
		static float collisionsEpsilon;

		static vector<string> extensions;
		bool forceWireframe;
		bool isPointerLock;
		ICanvas::Ptr _workingCanvas;
		I2D::Ptr _workingContext;
		float _aspectRatio;
		ICanvas::Ptr _renderingCanvas;
		float _hardwareScalingLevel;
		IGLTexture::Array _loadedTexturesCache;
		Capabilities _caps;
		RenderFunction _renderFunction;
		bool _runningLoop;
		bool isFullscreen;
		bool _pointerLockRequested;
		Viewport::Ptr _cachedViewport;
		bool _alphaTest;
		IGL::Ptr _gl;
		Texture::Array _activeTexturesCache;
		Effect::Ptr _currentEffect;
		State _currentState;
		IGLBuffer::Ptr _cachedVertexBuffer;
		Effect::Ptr _cachedEffectForVertexBuffer;
		VertexBuffer::Array _cachedVertexBuffers;
		Effect::Ptr _cachedEffectForVertexBuffers;
		IGLBuffer::Ptr _cachedIndexBuffer;
		map<string, Effect::Ptr> _compiledEffects;
		bool cullBackFaces;
		vector<ScenePtr> scenes;

	protected:
		Engine(ICanvas::Ptr canvas, bool antialias);
	public: 
		static EnginePtr New(ICanvas::Ptr canvas, bool antialias);

		virtual float getAspectRatio();
		virtual int getRenderWidth();
		virtual int getRenderHeight();
		virtual ICanvas::Ptr getRenderingCanvas();
		virtual void setHardwareScalingLevel(float level);
		virtual float getHardwareScalingLevel();
		virtual IGLTexture::Array& getLoadedTexturesCache();
		virtual Capabilities getCaps();
		virtual void stopRenderLoop();
		virtual void _renderLoop();
		virtual void runRenderLoop(RenderFunction renderFunction);
		virtual void switchFullscreen(bool requestPointerLock);
		virtual void clear(Color4::Ptr color, bool backBuffer, bool depthStencil);
		virtual void setViewport(Viewport::Ptr viewport, int requiredWidth = 0, int requiredHeight = 0);
		virtual void setDirectViewport(int x, int y, int width, int height);
		virtual void beginFrame();
		virtual void endFrame();
		virtual void resize();
		virtual void bindFramebuffer(IGLTexture::Ptr texture);
		virtual void unBindFramebuffer(IGLTexture::Ptr texture);
		virtual void flushFramebuffer();
		virtual void restoreDefaultFramebuffer();
		virtual IGLBuffer::Ptr createVertexBuffer(vector<float> vertices);
		virtual IGLBuffer::Ptr createDynamicVertexBuffer(GLsizeiptr capacity);
		virtual void updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array vertices, size_t length = 0);
		virtual IGLBuffer::Ptr createIndexBuffer(Uint16Array indices);
		virtual void bindBuffers(IGLBuffer::Ptr vertexBuffer, IGLBuffer::Ptr indexBuffer, Int32Array vertexDeclaration, int vertexStrideSize, Effect::Ptr effect);
		virtual void bindMultiBuffers(VertexBuffer::Array vertexBuffers, IGLBuffer::Ptr indexBuffer, Effect::Ptr effect);
		virtual void _releaseBuffer(IGLBuffer::Ptr buffer);
		virtual void draw(bool useTriangles, int indexStart, int indexCount);
		virtual Effect::Ptr createEffect(string baseName, vector<string> attributesNames, vector<string> uniformsNames, vector<string> samplers, string defines, string optionalDefines);
		virtual Effect::Ptr createEffect(string baseName, string vertex, string fragment, vector<string> attributesNames, vector<string> uniformsNames, vector<string> samplers, string defines, string optionalDefines);
		static IGLShader::Ptr compileShader(IGL::Ptr gl, string source, string type, string defines);
		virtual IGLProgram::Ptr createShaderProgram(string vertexCode, string fragmentCode, string defines);
		virtual vector<IGLUniformLocation::Ptr> getUniforms(IGLProgram::Ptr shaderProgram, vector<string> uniformsNames);
		virtual vector<GLint> getAttributes(IGLProgram::Ptr shaderProgram, vector<string> attributesNames);
		virtual void enableEffect(Effect::Ptr effect);
		virtual void setMatrices(IGLUniformLocation::Ptr uniform, Float32Array matrices);
		virtual void setMatrix(IGLUniformLocation::Ptr uniform, Matrix::Ptr matrix);
		virtual void setFloat(IGLUniformLocation::Ptr uniform, GLfloat value);
		virtual void setFloat2(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y);
		virtual void setFloat3(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z);
		virtual void setBool(IGLUniformLocation::Ptr uniform, GLboolean _bool);
		virtual void setFloat4(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
		virtual void setColor3(IGLUniformLocation::Ptr uniform, Color3::Ptr color3);
		virtual void setColor4(IGLUniformLocation::Ptr uniform, Color3::Ptr color3, GLfloat alpha);
		// States
		virtual void setState(bool culling);
		virtual void setDepthBuffer(bool enable);
		virtual void setDepthWrite(bool enable);
		virtual void setColorWrite(bool enable);
		virtual void setAlphaMode(ALPHA_MODES mode);
		virtual void setAlphaTesting(bool enable);
		virtual bool getAlphaTesting();
		// Textures
		virtual void wipeCaches();
		static int getExponantOfTwo(int value, int max);
		virtual IGLTexture::Ptr createTexture(string url, bool noMipmap, bool invertY, ScenePtr scene);
		virtual IGLTexture::Ptr createDynamicTexture(int width, int height, bool generateMipMaps);
		virtual void updateDynamicTexture(IGLTexture::Ptr texture, ICanvas::Ptr canvas, bool invertY);
		virtual void updateVideoTexture(IGLTexture::Ptr texture, IVideo::Ptr video);
		virtual IGLTexture::Ptr createRenderTargetTexture(Size size, bool generateMipMaps = false, bool generateDepthBuffer = true, SAMPLINGMODES samplingMode = TRILINEAR_SAMPLINGMODE);
		virtual void cascadeLoad(string rootUrl, int index, IImage::Array loadedImages, ScenePtr scene);
		virtual void onFinish(IImage::Array imgs);
		virtual IGLTexture::Ptr createCubeTexture(string rootUrl, ScenePtr scene);
		virtual void _releaseTexture(IGLTexture::Ptr texture);
		virtual void bindSamplers(Effect::Ptr effect);
		virtual void _bindTexture(int channel, IGLTexture::Ptr texture);
		virtual void setTextureFromPostProcess(int channel, PostProcess::Ptr postProcess);
		virtual void setTexture(int channel, Texture::Ptr texture);
		virtual void _setAnisotropicLevel(GLenum key, Texture::Ptr texture);
		// Dispose
		virtual void dispose(bool doNotRecurse = false);
		static bool isSupported();
	};

};

#endif // BABYLON_ENGINE_H
