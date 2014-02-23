#include "engine.h"
#include "defs.h"
#include "videoTexture.h"

using namespace Babylon;

float Babylon::Engine::epsilon = 0.001f;
float Babylon::Engine::collisionsEpsilon = 0.001f;
Plane::Ptr Babylon::Engine::clipPlane = nullptr;

Babylon::Engine::Engine(ICanvas::Ptr canvas, bool antialias) 
	: _alphaTest(false)
{
	this->_renderingCanvas = canvas;

	this->_gl = canvas->getContext3d(antialias);

	if (!this->_gl) {
		throw "GL not supported";
	}

	// Options
	this->forceWireframe = false;
	this->cullBackFaces = true;

	// Scenes
	this->scenes.clear();

	// Textures
	this->_workingCanvas = canvas;//document.createElement("canvas");
	// TODO: finish it
	this->_workingContext = this->_workingCanvas->getContext2d();

	// Viewport
	this->_hardwareScalingLevel = 1.0;
	this->resize();

	// Caps
	this->_caps.maxTexturesImageUnits = (size_t) this->_gl->getParameter(MAX_TEXTURE_IMAGE_UNITS);
	this->_caps.maxTextureSize = (size_t) this->_gl->getParameter(MAX_TEXTURE_SIZE);
	this->_caps.maxCubemapTextureSize = (size_t) this->_gl->getParameter(MAX_CUBE_MAP_TEXTURE_SIZE);
	this->_caps.maxRenderTextureSize = (size_t) this->_gl->getParameter(MAX_RENDERBUFFER_SIZE);

	// Extensions
	this->_caps.standardDerivatives = this->_gl->getExtension("OES_standard_derivatives") != nullptr;
	this->_caps.textureFloat = this->_gl->getExtension("OES_texture_float") != nullptr;    
	this->_caps.textureAnisotropicFilterExtension = this->_gl->getExtension("EXT_texture_filter_anisotropic") != nullptr || this->_gl->getExtension("WEBKIT_EXT_texture_filter_anisotropic") != nullptr || this->_gl->getExtension("MOZ_EXT_texture_filter_anisotropic") != nullptr;
	this->_caps.maxAnisotropy = this->_caps.textureAnisotropicFilterExtension ? (intptr_t)this->_gl->getParameter(MAX_TEXTURE_MAX_ANISOTROPY_EXT) : 0;

	// Cache
	this->_loadedTexturesCache.clear();
	this->_activeTexturesCache.clear();
	this->_currentEffect = nullptr;
	this->_currentState.culling = false;

	this->_compiledEffects.clear();

	this->_gl->enable(DEPTH_TEST);
	this->_gl->depthFunc(LEQUAL);

	// Fullscreen
	this->isFullscreen = false;

	this->_renderFunction = nullptr;
	this->_runningLoop = false;

	////

	////auto onFullscreenChange = []() {
	////	if (document.fullscreen != nullptr) {
	////		this->isFullscreen = document.fullscreen;
	////	} else if (document.mozFullScreen != undefined) {
	////		this->isFullscreen = document.mozFullScreen;
	////	} else if (document.webkitIsFullScreen != undefined) {
	////		this->isFullscreen = document.webkitIsFullScreen;
	////	} else if (document.msIsFullScreen != undefined) {
	////		this->isFullscreen = document.msIsFullScreen;
	////	}

	////	// Pointer lock
	////	if (this->isFullscreen && this->_pointerLockRequested) {
	////		canvas->requestPointerLock = canvas->requestPointerLock ||
	////			canvas->msRequestPointerLock ||
	////			canvas->mozRequestPointerLock ||
	////			canvas->webkitRequestPointerLock;

	////		if (canvas->requestPointerLock) {
	////			canvas->requestPointerLock();
	////		}
	////	}
	////};

	////document.addEventListener("fullscreenchange", onFullscreenChange, false);
	////document.addEventListener("mozfullscreenchange", onFullscreenChange, false);
	////document.addEventListener("webkitfullscreenchange", onFullscreenChange, false);
	////document.addEventListener("msfullscreenchange", onFullscreenChange, false);

	// Pointer lock
	this->isPointerLock = false;

	////auto onPointerLockChange = []() {
	////	this->isPointerLock = (document.mozPointerLockElement == canvas ||
	////		document.webkitPointerLockElement == canvas ||
	////		document.msPointerLockElement == canvas ||
	////		document.pointerLockElement == canvas
	////		);
	////};

	////document.addEventListener("pointerlockchange", onPointerLockChange, false);
	////document.addEventListener("mspointerlockchange", onPointerLockChange, false);
	////document.addEventListener("mozpointerlockchange", onPointerLockChange, false);
	////document.addEventListener("webkitpointerlockchange", onPointerLockChange, false);	
};

Engine::Ptr Babylon::Engine::New(ICanvas::Ptr canvas, bool antialias)
{
	auto engine = make_shared<Engine>(Engine(canvas, antialias));
	return engine;
}

// Properties
float Babylon::Engine::getAspectRatio() {
	return this->_aspectRatio;
};

int Babylon::Engine::getRenderWidth() {
	return this->_renderingCanvas->getWidth();
};

int Babylon::Engine::getRenderHeight() {
	return this->_renderingCanvas->getHeight();
};

ICanvas::Ptr Babylon::Engine::getRenderingCanvas() {
	return this->_renderingCanvas;
};

void Babylon::Engine::setHardwareScalingLevel(float level) {
	this->_hardwareScalingLevel = level;
	this->resize();
};

float Babylon::Engine::getHardwareScalingLevel() {
	return this->_hardwareScalingLevel;
};

IGLTexture::Array& Babylon::Engine::getLoadedTexturesCache() {
	return this->_loadedTexturesCache;
};

Capabilities Babylon::Engine::getCaps() {
	return this->_caps;
};

// Methods
void Babylon::Engine::stopRenderLoop() {
	this->_renderFunction = nullptr;
	this->_runningLoop = false;
};

void Babylon::Engine::_renderLoop() {
	// Start new frame
	this->beginFrame();

	if (this->_renderFunction) {
		this->_renderFunction();
	}

	// Present
	this->endFrame();

	if (this->_runningLoop) {
		// Register new frame
		// TODO: finish with lambda
		/*

		BABYLON->Tools->QueueNewFrame(function () {
		this->_renderLoop();
		});
		*/
	}
};

void Babylon::Engine::runRenderLoop(RenderFunction renderFunction) {
	this->_runningLoop = true;

	this->_renderFunction = renderFunction;
	// TODO: finish with lambda
	/*

	BABYLON->Tools->QueueNewFrame(function () {
	this->_renderLoop();
	});
	*/
};

void Babylon::Engine::switchFullscreen(bool requestPointerLock) {
	if (this->isFullscreen) {
		// TODO: finish
		//BABYLON->Tools->ExitFullscreen();
	} else {
		this->_pointerLockRequested = requestPointerLock;
		// TODO: finish
		//BABYLON->Tools->RequestFullscreen(this->_renderingCanvas);
	}
};

void Babylon::Engine::clear(Color4::Ptr color, bool backBuffer, bool depthStencil) {
	this->_gl->clearColor(color->r, color->g, color->b, color->a != 0 ? color->a : 1);
	this->_gl->clearDepth(1.);
	auto mode = 0;

	if (backBuffer)
		mode |= COLOR_BUFFER_BIT;

	if (depthStencil)
		mode |= DEPTH_BUFFER_BIT;

	this->_gl->clear(mode);
};

void Babylon::Engine::setViewport(Viewport::Ptr viewport, int requiredWidth, int requiredHeight) {
	auto width = requiredWidth != 0 ? requiredWidth : this->_renderingCanvas->getWidth();
	auto height = requiredHeight != 0 ? requiredHeight : this->_renderingCanvas->getHeight();
	auto x = viewport->x;
	auto y = viewport->y;

	this->_cachedViewport = viewport;

	this->_gl->viewport(x * width, y * height, width * viewport->width, height * viewport->height);
	this->_aspectRatio = (float)(width * viewport->width) / (float)(height * viewport->height);
};

void Babylon::Engine::setDirectViewport(int x, int y, int width, int height) {
	this->_cachedViewport = nullptr;

	this->_gl->viewport(x, y, width, height);
	this->_aspectRatio = (float)width / (float)height;
};

void Babylon::Engine::beginFrame() {
	//TODO:
	//BABYLON->Tools->_MeasureFps();
};

void Babylon::Engine::endFrame() {
	this->flushFramebuffer();
};

void Babylon::Engine::resize() {
	this->_renderingCanvas->setWidth(this->_renderingCanvas->getClientWidth() / this->_hardwareScalingLevel);
	this->_renderingCanvas->setHeight(this->_renderingCanvas->getClientHeight() / this->_hardwareScalingLevel);        
};

void Babylon::Engine::bindFramebuffer(IGLTexture::Ptr texture) {
	auto gl = this->_gl;
	gl->bindFramebuffer(FRAMEBUFFER, texture->_framebuffer);
	this->_gl->viewport(0, 0, texture->_width, texture->_height);
	this->_aspectRatio = (float)texture->_width / (float)texture->_height;

	this->wipeCaches();
};

void Babylon::Engine::unBindFramebuffer(IGLTexture::Ptr texture) {
	if (texture->generateMipMaps) {
		auto gl = this->_gl;
		gl->bindTexture(TEXTURE_2D, texture);
		gl->generateMipmap(TEXTURE_2D);
		gl->bindTexture(TEXTURE_2D, nullptr);
	}
};

void Babylon::Engine::flushFramebuffer() {
	this->_gl->flush();
};

void Babylon::Engine::restoreDefaultFramebuffer() {
	this->_gl->bindFramebuffer(FRAMEBUFFER, nullptr);

	this->setViewport(this->_cachedViewport);

	this->wipeCaches();
};

// VBOs
IGLBuffer::Ptr Babylon::Engine::createVertexBuffer(Float32Array& vertices) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(ARRAY_BUFFER, vbo);
	this->_gl->bufferData(ARRAY_BUFFER, vertices, STATIC_DRAW);
	this->_gl->bindBuffer(ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

IGLBuffer::Ptr Babylon::Engine::createDynamicVertexBuffer(GLsizeiptr capacity) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(ARRAY_BUFFER, vbo);
	this->_gl->bufferData(ARRAY_BUFFER, capacity, DYNAMIC_DRAW);
	this->_gl->bindBuffer(ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

void Babylon::Engine::updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array& vertices, size_t length) {
	this->_gl->bindBuffer(ARRAY_BUFFER, vertexBuffer);
	if (length) {
		// TODO: May have issue with array constucot destructor
		Float32Array subArray(vertices.begin(), vertices.begin() + length);
		this->_gl->bufferSubData(ARRAY_BUFFER, 0, subArray);
	} else {
		this->_gl->bufferSubData(ARRAY_BUFFER, 0, vertices);
	}

	this->_gl->bindBuffer(ARRAY_BUFFER, nullptr);
};

IGLBuffer::Ptr Babylon::Engine::createIndexBuffer(Uint16Array& indices) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(ELEMENT_ARRAY_BUFFER, vbo);
	this->_gl->bufferData(ELEMENT_ARRAY_BUFFER, indices, STATIC_DRAW);
	this->_gl->bindBuffer(ELEMENT_ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

void Babylon::Engine::bindBuffers(IGLBuffer::Ptr vertexBuffer, IGLBuffer::Ptr indexBuffer, vector_t<VertexBufferKind> vertexDeclarations, int vertexStrideSize, Effect::Ptr effect) {
	if (this->_cachedVertexBuffer != vertexBuffer || this->_cachedEffectForVertexBuffer != effect) {
		this->_cachedVertexBuffer = vertexBuffer;
		this->_cachedEffectForVertexBuffer = effect;

		this->_gl->bindBuffer(ARRAY_BUFFER, vertexBuffer);

		auto offset = 0;

		for (auto vertexDeclaration : vertexDeclarations) {
			auto order = effect->getAttributeLocation(vertexDeclaration);
			if (order >= 0) {
				this->_gl->vertexAttribPointer(order, vertexDeclaration, FLOAT, false, vertexStrideSize, offset);
			}
			offset += vertexDeclaration * 4;
		}
	}

	if (this->_cachedIndexBuffer != indexBuffer) {
		this->_cachedIndexBuffer = indexBuffer;
		this->_gl->bindBuffer(ELEMENT_ARRAY_BUFFER, indexBuffer);
	}
};

void Babylon::Engine::bindMultiBuffers(VertexBuffer::Map vertexBuffers, IGLBuffer::Ptr indexBuffer, Effect::Ptr effect) {
	if (this->_cachedVertexBuffers != vertexBuffers || this->_cachedEffectForVertexBuffers != effect) {
		this->_cachedVertexBuffers = vertexBuffers;
		this->_cachedEffectForVertexBuffers = effect;

		auto attributes = effect->getAttributes();

		for (auto attribute : attributes) {
			auto order = effect->getAttributeLocation(attribute);
			if (order >= 0) {
				auto vertexBuffer = vertexBuffers[attribute];
				auto stride = vertexBuffer->getStrideSize();
				this->_gl->bindBuffer(ARRAY_BUFFER, vertexBuffer->_buffer);
				this->_gl->vertexAttribPointer(order, stride, FLOAT, false, stride * 4, 0);
			}
		}
	}

	if (this->_cachedIndexBuffer != indexBuffer) {
		this->_cachedIndexBuffer = indexBuffer;
		this->_gl->bindBuffer(ELEMENT_ARRAY_BUFFER, indexBuffer);
	}
};

void Babylon::Engine::_releaseBuffer(IGLBuffer::Ptr buffer) {
	buffer->references--;

	if (buffer->references == 0) {
		this->_gl->deleteBuffer(buffer);
	}
};

void Babylon::Engine::draw(bool useTriangles, int indexStart, int indexCount) {
	this->_gl->drawElements(useTriangles ? TRIANGLES : LINES, indexCount, UNSIGNED_SHORT, indexStart * 2);
};

// Shaders
Effect::Ptr Babylon::Engine::createEffect(string baseName, vector_t<VertexBufferKind> attributesNames, vector_t<string> uniformsNames, vector_t<string> samplers, string defines, vector_t<string> optionalDefines) {
	return createEffect(baseName, baseName, baseName, attributesNames, uniformsNames, samplers, defines, optionalDefines);
}

Effect::Ptr Babylon::Engine::createEffect(string baseName, string vertex, string fragment, vector_t<VertexBufferKind> attributesNames, vector_t<string> uniformsNames, vector_t<string> samplers, string defines, vector_t<string> optionalDefines) {
	string name; 
	name.append(vertex).append("+").append(fragment).append("@").append(defines);
	if (this->_compiledEffects[name]) {
		return this->_compiledEffects[name];
	}

	auto effect = Effect::New(baseName, vertex, fragment, attributesNames, uniformsNames, samplers, shared_from_this(), defines, optionalDefines);
	this->_compiledEffects[name] = effect;

	return effect;
};

IGLShader::Ptr Babylon::Engine::compileShader(IGL::Ptr gl, string source, string type, string defines) {
	auto shader = gl->createShader(type == "vertex" ? VERTEX_SHADER : FRAGMENT_SHADER);

	gl->shaderSource(shader, (!defines.empty() ? defines + "\n" : "") + source);
	gl->compileShader(shader);

	if (!gl->getShaderParameter(shader, COMPILE_STATUS)) {
		string result = gl->getShaderInfoLog(shader);
		throw runtime_error(result);
	}

	return shader;
};

IGLProgram::Ptr Babylon::Engine::createShaderProgram(string vertexCode, string fragmentCode, string defines) {
	auto vertexShader = compileShader(this->_gl, vertexCode, "vertex", defines);
	auto fragmentShader = compileShader(this->_gl, fragmentCode, "fragment", defines);

	auto shaderProgram = this->_gl->createProgram();
	this->_gl->attachShader(shaderProgram, vertexShader);
	this->_gl->attachShader(shaderProgram, fragmentShader);

	auto result = this->_gl->linkProgram(shaderProgram);

	auto error = this->_gl->getProgramInfoLog(shaderProgram);
	if (!error.empty()) {
		throw runtime_error(error);
	}

	if (!result)
	{
		throw runtime_error(string("link failed."));
	}

	this->_gl->deleteShader(vertexShader);
	this->_gl->deleteShader(fragmentShader);

	return shaderProgram;
};

vector_t<IGLUniformLocation::Ptr> Babylon::Engine::getUniforms(IGLProgram::Ptr shaderProgram, vector_t<string> uniformsNames) {
	vector_t<IGLUniformLocation::Ptr> results;

	for (auto uniformsName : uniformsNames) {
		results.push_back(this->_gl->getUniformLocation(shaderProgram, uniformsName));
	}

	return results;
};

map_t<VertexBufferKind, int> Babylon::Engine::getAttributeLocations(IGLProgram::Ptr shaderProgram, vector_t<VertexBufferKind> attributesNames) {
	map_t<VertexBufferKind, int> results;

	for (auto attributesName : attributesNames) {
		try {
			results[attributesName] = this->_gl->getAttribLocation(shaderProgram, VertexBuffer::toString(attributesName));
		} catch (...) {
			results[attributesName] = -1;
		}
	}

	return results;
};

void Babylon::Engine::enableEffect(Effect::Ptr effect) {
	if (!effect || !effect->getAttributes().size() || this->_currentEffect == effect) {
		return;
	}
	// Use program
	this->_gl->useProgram(effect->getProgram());

	for (auto attribute : effect->getAttributes()) {
		// Attributes
		auto order = effect->getAttributeLocation(attribute);
		if (order >= 0) {
			this->_gl->enableVertexAttribArray(order);
		}
	}

	this->_currentEffect = effect;
};

void Babylon::Engine::setMatrices(IGLUniformLocation::Ptr uniform, Float32Array& matrices) {
	if (!uniform)
		return;

	this->_gl->uniformMatrix4fv(uniform, false, matrices);
};

void Babylon::Engine::setMatrix(IGLUniformLocation::Ptr uniform, Matrix::Ptr matrix) {
	if (!uniform)
		return;

	this->_gl->uniformMatrix4fv(uniform, false, matrix->m);
};

void Babylon::Engine::setFloat(IGLUniformLocation::Ptr uniform, GLfloat value) {
	if (!uniform)
		return;

	this->_gl->uniform1f(uniform, value);
};

void Babylon::Engine::setFloat2(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y) {
	if (!uniform)
		return;

	this->_gl->uniform2f(uniform, x, y);
};

void Babylon::Engine::setFloat3(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z) {
	if (!uniform)
		return;

	this->_gl->uniform3f(uniform, x, y, z);
};

void Babylon::Engine::setBool(IGLUniformLocation::Ptr uniform, GLboolean _bool) {
	if (!uniform)
		return;

	this->_gl->uniform1i(uniform, _bool);
};

void Babylon::Engine::setFloat4(IGLUniformLocation::Ptr uniform, GLfloat x, GLfloat y, GLfloat z, GLfloat w) {
	if (!uniform)
		return;

	this->_gl->uniform4f(uniform, x, y, z, w);
};

void Babylon::Engine::setColor3(IGLUniformLocation::Ptr uniform, Color3::Ptr color3) {
	if (!uniform)
		return;

	this->_gl->uniform3f(uniform, color3->r, color3->g, color3->b);
};

void Babylon::Engine::setColor4(IGLUniformLocation::Ptr uniform, Color3::Ptr color3, GLfloat alpha) {
	if (!uniform)
		return;

	this->_gl->uniform4f(uniform, color3->r, color3->g, color3->b, alpha);
};

// States
void Babylon::Engine::setState(bool culling) {
	// Culling        
	if (this->_currentState.culling != culling) {
		if (culling) {
			this->_gl->cullFace(this->cullBackFaces ? BACK : FRONT);
			this->_gl->enable(CULL_FACE);
		} else {
			this->_gl->disable(CULL_FACE);
		}

		this->_currentState.culling = culling;
	}
};

void Babylon::Engine::setDepthBuffer(bool enable) {
	if (enable) {
		this->_gl->enable(DEPTH_TEST);
	} else {
		this->_gl->disable(DEPTH_TEST);
	}
};

void Babylon::Engine::setDepthWrite(bool enable) {
	this->_gl->depthMask(enable);
};

void Babylon::Engine::setColorWrite(bool enable) {
	this->_gl->colorMask(enable, enable, enable, enable);
};

void Babylon::Engine::setAlphaMode(ALPHA_MODES mode) {

	switch (mode) {
	case ALPHA_DISABLE:
		this->setDepthWrite(true);
		this->_gl->disable(BLEND);
		break;
	case ALPHA_COMBINE:
		this->setDepthWrite(false);
		this->_gl->blendFuncSeparate(SRC_ALPHA, ONE_MINUS_SRC_ALPHA, ZERO, ONE);
		this->_gl->enable(BLEND);
		break;
	case ALPHA_ADD:
		this->setDepthWrite(false);
		this->_gl->blendFuncSeparate(ONE, ONE, ZERO, ONE);
		this->_gl->enable(BLEND);
		break;
	}
};

void Babylon::Engine::setAlphaTesting(bool enable) {
	this->_alphaTest = enable;
};

bool Babylon::Engine::getAlphaTesting() {
	return this->_alphaTest;
};

// Textures
void Babylon::Engine::wipeCaches() {
	this->_activeTexturesCache;
	this->_currentEffect = nullptr;
	this->_currentState.culling = nullptr;
	this->_cachedVertexBuffers.clear();
	this->_cachedEffectForVertexBuffers = nullptr;
	this->_cachedVertexBuffer = nullptr;
	this->_cachedEffectForVertexBuffer = nullptr;
};

int Babylon::Engine::getExponantOfTwo(int value, int max) {
	auto count = 1;

	do {
		count *= 2;
	} while (count < value);

	if (count > max)
		count = max;

	return count;
};

IGLTexture::Ptr Babylon::Engine::createTexture(string url, bool noMipmap, bool invertY, Scene::Ptr scene) {
	auto texture = this->_gl->createTexture();

	auto onload = [=](IImage::Ptr img) {
		auto potWidth = getExponantOfTwo(img->getWidth(), this->_caps.maxTextureSize);
		auto potHeight = getExponantOfTwo(img->getHeight(), this->_caps.maxTextureSize);
		auto isPot = (img->getWidth() == potWidth && img->getHeight() == potHeight);

		// TODO: my fix. why we need to use canvas to draw image?
		isPot = true;

		if (!isPot) {
			this->_workingCanvas->setWidth(potWidth);
			this->_workingCanvas->setHeight(potHeight);

			this->_workingContext->drawImage(img, 0, 0, img->getWidth(), img->getHeight(), 0, 0, potWidth, potHeight);
		};

		this->_gl->bindTexture(TEXTURE_2D, texture);
		// TODO: next line is commented. You need to turn your image upside-down if invertY is true
		//this->_gl->pixelStorei(UNPACK_FLIP_Y_WEBGL, invertY);
		if (isPot)
		{
			this->_gl->texImage2D(TEXTURE_2D, 0, RGBA, RGBA, UNSIGNED_BYTE, img);
		}
		else
		{
			this->_gl->texImage2D(TEXTURE_2D, 0, RGBA, RGBA, UNSIGNED_BYTE, this->_workingCanvas);
		}

		this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MAG_FILTER, LINEAR);

		if (noMipmap) {
			this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MIN_FILTER, LINEAR);
		} else {
			this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MIN_FILTER, LINEAR_MIPMAP_LINEAR);
			this->_gl->generateMipmap(TEXTURE_2D);
		}
		this->_gl->bindTexture(TEXTURE_2D, nullptr);

		this->_activeTexturesCache.clear();
		texture->_baseWidth = img->getWidth();
		texture->_baseHeight = img->getHeight();
		texture->_width = potWidth;
		texture->_height = potHeight;
		texture->isReady = true;
		scene->_removePendingData(texture);
	};

	auto onerror = [=]() {
		scene->_removePendingData(texture);
	};

	scene->_addPendingData(texture);

	// Tools.LoadImage
	this->_gl->getCanvas()->loadImage(url, onload, onerror);

	texture->url = url;
	texture->noMipmap = noMipmap;
	texture->references = 1;
	this->_loadedTexturesCache.push_back(texture);

	return texture;
};

IGLTexture::Ptr Babylon::Engine::createDynamicTexture(int width, int height, bool generateMipMaps) {
	auto texture = this->_gl->createTexture();

	width = getExponantOfTwo(width, this->_caps.maxTextureSize);
	height = getExponantOfTwo(height, this->_caps.maxTextureSize);

	this->_gl->bindTexture(TEXTURE_2D, texture);
	this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MAG_FILTER, LINEAR);

	if (!generateMipMaps) {
		this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MIN_FILTER, LINEAR);
	} else {
		this->_gl->texParameteri(TEXTURE_2D, TEXTURE_MIN_FILTER, LINEAR_MIPMAP_LINEAR);
	}
	this->_gl->bindTexture(TEXTURE_2D, nullptr);

	this->_activeTexturesCache.clear();
	texture->_baseWidth = width;
	texture->_baseHeight = height;
	texture->_width  = width;
	texture->_height = height;
	texture->isReady = false;
	texture->generateMipMaps = generateMipMaps;
	texture->references = 1;

	this->_loadedTexturesCache.push_back(texture);

	return texture;
};

void Babylon::Engine::updateDynamicTexture(IGLTexture::Ptr texture, ICanvas::Ptr canvas, bool invertY) {
	this->_gl->bindTexture(TEXTURE_2D, texture);
	this->_gl->pixelStorei(UNPACK_FLIP_Y_WEBGL, invertY);
	this->_gl->texImage2D(TEXTURE_2D, 0, RGBA, RGBA, UNSIGNED_BYTE, canvas);
	if (texture->generateMipMaps) {
		this->_gl->generateMipmap(TEXTURE_2D);
	}
	this->_gl->bindTexture(TEXTURE_2D, nullptr);
	this->_activeTexturesCache.clear();
	texture->isReady = true;
};

// TODO: you need to use custom isolated canvas for updateing image
void Babylon::Engine::updateVideoTexture(IGLTexture::Ptr texture, IVideo::Ptr video) {
	this->_gl->bindTexture(TEXTURE_2D, texture);
	this->_gl->pixelStorei(UNPACK_FLIP_Y_WEBGL, false);

	// Scale the video if it is a NPOT
	if (video->getVideoWidth() != texture->_width || video->getVideoHeight() != texture->_height) {
		if (!texture->_workingCanvas) {
			texture->_workingCanvas = this->_workingCanvas;
			texture->_workingContext = this->_workingCanvas->getContext2d();
			texture->_workingCanvas->setWidth(texture->_width);
			texture->_workingCanvas->setHeight(texture->_height);
		}

		texture->_workingContext->drawImage(video, 0, 0, video->getVideoWidth(), video->getVideoHeight(), 0, 0, texture->_width, texture->_height);

		this->_gl->texImage2D(TEXTURE_2D, 0, RGBA, RGBA, UNSIGNED_BYTE, texture->_workingCanvas);
	} else {
		this->_gl->texImage2D(TEXTURE_2D, 0, RGBA, RGBA, UNSIGNED_BYTE, video);
	}

	if (texture->generateMipMaps) {
		this->_gl->generateMipmap(TEXTURE_2D);
	}

	this->_gl->bindTexture(TEXTURE_2D, nullptr);
	this->_activeTexturesCache.clear();
	texture->isReady = true;
};

IGLTexture::Ptr Babylon::Engine::createRenderTargetTexture(Size size, bool generateMipMaps, bool generateDepthBuffer, SAMPLINGMODES samplingMode) {
	// old version had a "generateMipMaps" arg instead of options->
	// if options->generateMipMaps is undefined, consider that options itself if the generateMipmaps value
	// in the same way, generateDepthBuffer is defaulted to true
	auto gl = this->_gl;

	auto texture = gl->createTexture();
	gl->bindTexture(TEXTURE_2D, texture);

	auto magFilter = NEAREST;
	auto minFilter = NEAREST;
	if (samplingMode == BILINEAR_SAMPLINGMODE) {
		magFilter = LINEAR;
		if (generateMipMaps) {
			minFilter = LINEAR_MIPMAP_NEAREST;
		} else {
			minFilter = LINEAR;
		}
	} else if (samplingMode == TRILINEAR_SAMPLINGMODE) {
		magFilter = LINEAR;
		if (generateMipMaps) {
			minFilter = LINEAR_MIPMAP_LINEAR;
		} else {
			minFilter = LINEAR;
		}
	}
	gl->texParameteri(TEXTURE_2D, TEXTURE_MAG_FILTER, magFilter);
	gl->texParameteri(TEXTURE_2D, TEXTURE_MIN_FILTER, minFilter);
	gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_S, CLAMP_TO_EDGE);
	gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_T, CLAMP_TO_EDGE);
	gl->texImage2D(TEXTURE_2D, 0, RGBA, size.width, size.height, 0, RGBA, UNSIGNED_BYTE, nullptr);

	IGLRenderbuffer::Ptr depthBuffer;
	// Create the depth buffer
	if (generateDepthBuffer) {
		depthBuffer = gl->createRenderbuffer();
		gl->bindRenderbuffer(RENDERBUFFER, depthBuffer);
		gl->renderbufferStorage(RENDERBUFFER, DEPTH_COMPONENT16, size.width, size.height);
	}

	// Create the framebuffer
	auto framebuffer = gl->createFramebuffer();
	gl->bindFramebuffer(FRAMEBUFFER, framebuffer);
	gl->framebufferTexture2D(FRAMEBUFFER, COLOR_ATTACHMENT0, TEXTURE_2D, texture, 0);
	if (generateDepthBuffer) {
		gl->framebufferRenderbuffer(FRAMEBUFFER, DEPTH_ATTACHMENT, RENDERBUFFER, depthBuffer);
	}

	// Unbind
	gl->bindTexture(TEXTURE_2D, nullptr);
	gl->bindRenderbuffer(RENDERBUFFER, nullptr);
	gl->bindFramebuffer(FRAMEBUFFER, nullptr);

	texture->_framebuffer = framebuffer;
	if (generateDepthBuffer) {
		texture->_depthBuffer = depthBuffer;
	}

	texture->_width = size.width;
	texture->_height = size.height;
	texture->isReady = true;
	texture->generateMipMaps = generateMipMaps;
	texture->references = 1;
	this->_activeTexturesCache.clear();

	this->_loadedTexturesCache.push_back(texture);

	return texture;
};

//TODO: finish it
//auto extensions = ["_px.jpg", "_py.jpg", "_pz.jpg", "_nx.jpg", "_ny.jpg", "_nz.jpg"];
vector_t<string> Babylon::Engine::extensions;

void Babylon::Engine::cascadeLoad(string rootUrl, int index, IImage::Array loadedImages, Scene::Ptr scene) {
	IImage::Ptr img;
	auto onload = [&]() {
		loadedImages.push_back(img);

		scene->_removePendingData(img);

		if (index != extensions.size() - 1) {
			cascadeLoad(rootUrl, index + 1, loadedImages, scene);
		} else {
			this->onFinish(loadedImages);
		}
	};

	auto onerror = [&]() {
		scene->_removePendingData(img);
	};

	// TODO: finish it
	////img = BABYLON->Tools->LoadImage(rootUrl + extensions[index], onload, onerror, scene->database);
	scene->_addPendingData(img);
};

void Babylon::Engine::onFinish(IImage::Array imgs)
{
	IGLTexture::Ptr texture;

	auto gl = this->_gl;

	auto width = getExponantOfTwo(imgs[0]->getWidth(), this->_caps.maxCubemapTextureSize);
	auto height = width;

	this->_workingCanvas->setWidth(width);
	this->_workingCanvas->setHeight(height);

	vector_t<GLenum> faces;
	faces.push_back(TEXTURE_CUBE_MAP_POSITIVE_X);
	faces.push_back(TEXTURE_CUBE_MAP_POSITIVE_Y);
	faces.push_back(TEXTURE_CUBE_MAP_POSITIVE_Z);
	faces.push_back(TEXTURE_CUBE_MAP_NEGATIVE_X);
	faces.push_back(TEXTURE_CUBE_MAP_NEGATIVE_Y);
	faces.push_back(TEXTURE_CUBE_MAP_NEGATIVE_Z);

	gl->bindTexture(TEXTURE_CUBE_MAP, texture);
	gl->pixelStorei(UNPACK_FLIP_Y_WEBGL, false);

	for (size_t index = 0; index < faces.size(); index++) {
		this->_workingContext->drawImage(imgs[index], 0, 0, imgs[index]->getWidth(), imgs[index]->getHeight(), 0, 0, width, height);
		gl->texImage2D(faces[index], 0, RGBA, RGBA, UNSIGNED_BYTE, this->_workingCanvas);
	}

	gl->generateMipmap(TEXTURE_CUBE_MAP);
	gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_MAG_FILTER, LINEAR);
	gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_MIN_FILTER, LINEAR_MIPMAP_LINEAR);
	gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_WRAP_S, CLAMP_TO_EDGE);
	gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_WRAP_T, CLAMP_TO_EDGE);

	gl->bindTexture(TEXTURE_CUBE_MAP, nullptr);

	this->_activeTexturesCache.clear();

	texture->_width = width;
	texture->_height = height;
	texture->isReady = true;
}

IGLTexture::Ptr Babylon::Engine::createCubeTexture(string rootUrl, Scene::Ptr scene) {
	auto gl = this->_gl;

	auto texture = gl->createTexture();
	texture->isCube = true;
	texture->url = rootUrl;
	texture->references = 1;
	this->_loadedTexturesCache.push_back(texture);


	IImage::Array loadedImages;
	cascadeLoad(rootUrl, 0, loadedImages, scene);

	return texture;
};

void Babylon::Engine::_releaseTexture(IGLTexture::Ptr texture) {
	auto gl = this->_gl;

	if (texture->_framebuffer) {
		gl->deleteFramebuffer(texture->_framebuffer);
	}

	if (texture->_depthBuffer) {
		gl->deleteRenderbuffer(texture->_depthBuffer);
	}

	gl->deleteTexture(texture);

	// Unbind channels
	for (size_t channel = 0; channel < this->_caps.maxTexturesImageUnits; channel++) {
		this->_gl->activeTexture((*this->_gl)["TEXTURE" + to_string(channel)]);
		this->_gl->bindTexture(TEXTURE_2D, nullptr);
		this->_gl->bindTexture(TEXTURE_CUBE_MAP, nullptr);
		this->_activeTexturesCache[channel] = nullptr;
	}

	auto it = find(begin( this->_loadedTexturesCache ), end ( this->_loadedTexturesCache ), texture);
	if (it != end ( this->_loadedTexturesCache )) {
		this->_loadedTexturesCache.erase(it);
	}
};

void Babylon::Engine::bindSamplers(Effect::Ptr effect) {
	this->_gl->useProgram(effect->getProgram());
	auto samplers = effect->getSamplers();
	for (size_t index = 0; index < samplers.size(); index++) {
		auto uniform = effect->getUniform(samplers[index]);
		this->_gl->uniform1i(uniform, index);
	}
	this->_currentEffect = nullptr;
};


void Babylon::Engine::_bindTexture(int channel, IGLTexture::Ptr texture) {
	this->_gl->activeTexture((*this->_gl)["TEXTURE" + to_string(channel)]);
	this->_gl->bindTexture(TEXTURE_2D, texture);

	this->_activeTexturesCache[channel] = nullptr;
};

void Babylon::Engine::setTextureFromPostProcess(int channel, PostProcess::Ptr postProcess) {
	this->_bindTexture(channel, postProcess->_texture);
};

void Babylon::Engine::setTexture(int channel, Texture::Ptr texture) {
	if (channel < 0) {
		return;
	}
	// Not ready?
	if (!texture || !texture->isReady()) {
		if (this->_activeTexturesCache[channel] != nullptr) {
			this->_gl->activeTexture((*this->_gl)["TEXTURE" + to_string(channel)]);
			this->_gl->bindTexture(TEXTURE_2D, nullptr);
			this->_gl->bindTexture(TEXTURE_CUBE_MAP, nullptr);
			this->_activeTexturesCache[channel] = nullptr;
		}
		return;
	}

	// Video
	auto videoTexturePointer = dynamic_pointer_cast<VideoTexture>( texture );
	if (videoTexturePointer != nullptr) {
		if (videoTexturePointer->_update()) {
			this->_activeTexturesCache[channel] = nullptr;
		}
	} else if (texture->delayLoadState == DELAYLOADSTATE_NOTLOADED) { // Delay loading
		texture->delayLoad();
		return;
	}

	if (this->_activeTexturesCache[channel] == texture) {
		return;
	}
	this->_activeTexturesCache[channel] = texture;

	auto internalTexture = texture->getInternalTexture();
	this->_gl->activeTexture((*this->_gl)["TEXTURE" + to_string(channel)]);

	if (internalTexture->isCube) {
		this->_gl->bindTexture(TEXTURE_CUBE_MAP, internalTexture);

		if (internalTexture->_cachedCoordinatesMode != texture->coordinatesMode) {
			internalTexture->_cachedCoordinatesMode = texture->coordinatesMode;
			this->_gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_WRAP_S, texture->coordinatesMode != CUBIC_MODE ? REPEAT : CLAMP_TO_EDGE);
			this->_gl->texParameteri(TEXTURE_CUBE_MAP, TEXTURE_WRAP_T, texture->coordinatesMode != CUBIC_MODE ? REPEAT : CLAMP_TO_EDGE);
		}

		this->_setAnisotropicLevel(TEXTURE_CUBE_MAP, texture);
	} else {
		this->_gl->bindTexture(TEXTURE_2D, internalTexture);

		if (internalTexture->_cachedWrapU != texture->wrapU) {
			internalTexture->_cachedWrapU = texture->wrapU;

			switch (texture->wrapU) {
			case WRAP_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_S, REPEAT);
				break;
			case CLAMP_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_S, CLAMP_TO_EDGE);
				break;
			case MIRROR_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_S, MIRRORED_REPEAT);
				break;
			}
		}

		if (internalTexture->_cachedWrapV != texture->wrapV) {
			internalTexture->_cachedWrapV = texture->wrapV;
			switch (texture->wrapV) {
			case WRAP_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_T, REPEAT);
				break;
			case CLAMP_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_T, CLAMP_TO_EDGE);
				break;
			case MIRROR_ADDRESSMODE:
				this->_gl->texParameteri(TEXTURE_2D, TEXTURE_WRAP_T, MIRRORED_REPEAT);
				break;
			}
		}

		this->_setAnisotropicLevel(TEXTURE_2D, texture);
	}
};


void Babylon::Engine::_setAnisotropicLevel(GLenum key, Texture::Ptr texture) {
	auto anisotropicFilterExtension = this->_caps.textureAnisotropicFilterExtension;

	if (anisotropicFilterExtension && texture->_cachedAnisotropicFilteringLevel != texture->anisotropicFilteringLevel) {
		this->_gl->texParameterf(key, TEXTURE_MAX_ANISOTROPY_EXT, min(texture->anisotropicFilteringLevel, this->_caps.maxAnisotropy));
		texture->_cachedAnisotropicFilteringLevel = texture->anisotropicFilteringLevel;
	}
};

// Dispose
void Babylon::Engine::dispose(bool doNotRecurse) {
	// Release scenes
	for (auto scene : this->scenes) {
		scene->dispose();
	}

	this->scenes.clear();

	// Release effects
	for (auto pair : this->_compiledEffects) {
		this->_gl->deleteProgram(pair.second->_program);
	}
};

bool Babylon::Engine::isSupported() {
	return true;
};
