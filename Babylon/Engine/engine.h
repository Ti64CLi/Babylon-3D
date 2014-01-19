#ifndef BABYLON_ENGINE_H
#define BABYLON_ENGINE_H

#include <memory>
#include <vector>

#include "igl.h"
#include "iengine.h"
#include "baseTexture.h"
#include "effect.h"
#include "tools_math.h"

using namespace std;

namespace Babylon {

	class Engine: public enable_shared_from_this<Engine>, public IEngine {

	public:
		typedef shared_ptr<Engine> Ptr;
		typedef void (*RenderFunction)();

	public:
		// Statics
		const static char* ShadersRepository;

		float epsilon;
		float collisionsEpsilon;

	private: 
		float _aspectRatio;
		ICanvas::Ptr _renderingCanvas;
		float _hardwareScalingLevel;
		BaseTexture::Array _loadedTexturesCache;
		Capabilities _caps;
		RenderFunction _renderFunction;
		bool _runningLoop;
		bool isFullscreen;
		bool _pointerLockRequested;
		Viewport::Ptr _cachedViewport;
		bool _alphaTest;
		IGL::Ptr _gl;
		BaseTexture::Array _activeTexturesCache;
		Effect::Ptr _currentEffect;
		State _currentState;
		IGLBuffer::Ptr _cachedVertexBuffer;
		Effect::Ptr _cachedEffectForVertexBuffer;
		IGLBuffer::Array _cachedVertexBuffers;
		Effect::Ptr _cachedEffectForVertexBuffers;
		IGLBuffer::Ptr _cachedIndexBuffer;

	public: 
		Engine(ICanvas::Ptr canvas, bool antialias);

		virtual float getAspectRatio();
		virtual int getRenderWidth();
		virtual int getRenderHeight();
		virtual ICanvas::Ptr getRenderingCanvas();
		virtual void setHardwareScalingLevel(float level);
		virtual float getHardwareScalingLevel();
		virtual BaseTexture::Array& getLoadedTexturesCache();
		virtual Capabilities getCaps();
		virtual void stopRenderLoop();
		virtual void _renderLoop();
		virtual void runRenderLoop(RenderFunction renderFunction);
		virtual void switchFullscreen(bool requestPointerLock);
		virtual void clear(Color4::Ptr color, bool backBuffer, bool depthStencil);
		virtual void setViewport(Viewport::Ptr viewport, int requiredWidth, int requiredHeight);
		virtual void setDirectViewport(int x, int y, int width, int height);
		virtual void beginFrame();
		virtual void endFrame();
		virtual void resize();
		virtual void bindFramebuffer(BaseTexture::Ptr texture);
		virtual void unBindFramebuffer(BaseTexture::Ptr texture);
		virtual void flushFramebuffer();
		virtual void restoreDefaultFramebuffer();
		virtual IGLBuffer::Ptr createVertexBuffer(vector<float> vertices);
		virtual IGLBuffer::Ptr createDynamicVertexBuffer(GLsizeiptr capacity);
		virtual void updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array vertices, size_t length);
		virtual IGLBuffer::Ptr createIndexBuffer(Uint16Array indices);
		virtual void bindBuffers(IGLBuffer::Ptr vertexBuffer, IGLBuffer::Ptr indexBuffer, Int32Array vertexDeclaration, int vertexStrideSize, Effect::Ptr effect);
		virtual void bindMultiBuffers(IGLBuffer::Array vertexBuffers, IGLBuffer::Ptr indexBuffer, Effect::Ptr effect);
		virtual void _releaseBuffer(IGLBuffer::Ptr buffer);
		/*
		virtual void draw(useTriangles, indexStart, indexCount);
		virtual void createEffect(baseName, attributesNames, uniformsNames, samplers, defines, optionalDefines);
		virtual void compileShader(gl, source, type, defines);
		virtual void createShaderProgram(vertexCode, fragmentCode, defines);
		virtual void getUniforms(shaderProgram, uniformsNames);
		virtual void getAttributes(shaderProgram, attributesNames);
		virtual void enableEffect(effect);
		virtual void setMatrices(uniform, matrices);
		virtual void setMatrix(uniform, matrix);
		virtual void setFloat(uniform, value);
		virtual void setFloat2(uniform, x, y);
		virtual void setFloat3(uniform, x, y, z);
		virtual void setBool(uniform, bool);
		virtual void setFloat4(uniform, x, y, z, w);
		virtual void setColor3(uniform, color3);
		virtual void setColor4(uniform, color3, alpha);
		// States
		virtual void setState(culling);
		virtual void setDepthBuffer(enable);
		virtual void setDepthWrite(enable);
		virtual void setColorWrite(enable);
		virtual void setAlphaMode(mode);
		*/
		virtual void setAlphaTesting(bool enable);
		virtual bool getAlphaTesting();
		// Textures
		virtual void wipeCaches();
		/*
		virtual void createTexture(url, noMipmap, invertY, scene);
		virtual void createDynamicTexture(width, height, generateMipMaps);
		virtual void updateDynamicTexture(texture, canvas, invertY);
		virtual void updateVideoTexture(texture, video);
		virtual void createRenderTargetTexture(size, options);
		virtual void createCubeTexture(rootUrl, scene);
		virtual void _releaseTexture(texture);
		virtual void bindSamplers(effect);
		virtual void _bindTexture(int channel, Texture texture);
		virtual void setTextureFromPostProcess(channel, postProcess);
		virtual void setTexture(iny channel, Texture texture);
		virtual void _setAnisotropicLevel(key, Texture texture);
		*/
		// Dispose
		virtual void dispose();
		static bool isSupported();
	};

};

#endif // BABYLON_ENGINE_H
