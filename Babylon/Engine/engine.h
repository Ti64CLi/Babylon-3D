#ifndef BABYLON_ENGINE_H
#define BABYLON_ENGINE_H

#include <memory>
#include <vector>

#include "canvas.h"
#include "tools.h"

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

	class Engine: public enable_shared_from_this<Engine> {

	public:
		typedef shared_ptr<Engine> Ptr;
		// TODO: Texture should go to Texture files
		typedef shared_ptr<void> TexturePtr;
		typedef vector<TexturePtr> Textures;
		typedef void (*RenderFunction)();

	public:
		// Statics
		const static char* ShadersRepository;

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

		float epsilon;
		float collisionsEpsilon;

	private: 
		float _aspectRatio;
		Canvas::Ptr _renderingCanvas;
		float _hardwareScalingLevel;
		Textures _loadedTexturesCache;
		Capabilities _caps;
		RenderFunction _renderFunction;
		bool _runningLoop;
		bool isFullscreen;
		bool _pointerLockRequested;
		Viewport::Ptr _cachedViewport;

	public: 
		Engine(Canvas::Ptr canvas, bool antialias);

		virtual float getAspectRatio();
		virtual int getRenderWidth();
		virtual int getRenderHeight();
		virtual Canvas::Ptr getRenderingCanvas();
		virtual void setHardwareScalingLevel(float level);
		virtual float getHardwareScalingLevel();
		virtual Textures getLoadedTexturesCache();
		virtual Capabilities getCaps();
		virtual void stopRenderLoop();
		virtual void _renderLoop();
		virtual void runRenderLoop(RenderFunction renderFunction);
		virtual void switchFullscreen(bool requestPointerLock);
		virtual void clear(Color3::Ptr color, bool backBuffer, bool depthStencil);
		virtual void setViewport(Viewport::Ptr viewport, int requiredWidth, int requiredHeight);
		virtual void setDirectViewport(int x, int y, int width, int height);
		virtual void beginFrame();
		virtual void endFrame();
		virtual void resize();
		/*
		virtual void bindFramebuffer(TexturePtr texture);
		virtual void unBindFramebuffer(TexturePtr texture);
		virtual void flushFramebuffer();
		virtual void restoreDefaultFramebuffer();
		virtual void createVertexBuffer(vertices);
		virtual void createDynamicVertexBuffer(capacity);
		virtual void updateDynamicVertexBuffer(vertexBuffer, vertices, length);
		virtual void createIndexBuffer(indices);
		virtual void bindBuffers(vertexBuffer, indexBuffer, vertexDeclaration, vertexStrideSize, effect);
		virtual void bindMultiBuffers(vertexBuffers, indexBuffer, effect);
		virtual void _releaseBuffer(buffer);
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
		virtual void setAlphaTesting(enable);
		virtual void getAlphaTesting();
		// Textures
		virtual void wipeCaches();
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
