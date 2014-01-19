#include "engine.h"

using namespace Babylon;

const char* Babylon::Engine::ShadersRepository = "Babylon/Shaders/";

Babylon::Engine::Engine(ICanvas::Ptr canvas, bool antialias)
{
	epsilon = 0.001f;
	collisionsEpsilon = 0.001f;
};

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

BaseTexture::Array& Babylon::Engine::getLoadedTexturesCache() {
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
		auto that = this;
		BABYLON->Tools->QueueNewFrame(function () {
		that->_renderLoop();
		});
		*/
	}
};

void Babylon::Engine::runRenderLoop(RenderFunction renderFunction) {
	this->_runningLoop = true;

	this->_renderFunction = renderFunction;
	// TODO: finish with lambda
	/*
	auto that = this;
	BABYLON->Tools->QueueNewFrame(function () {
	that->_renderLoop();
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
		mode |= this->_gl->COLOR_BUFFER_BIT;

	if (depthStencil)
		mode |= this->_gl->DEPTH_BUFFER_BIT;

	this->_gl->clear(mode);
};

void Babylon::Engine::setViewport(Viewport::Ptr viewport, int requiredWidth = 0, int requiredHeight = 0) {
	auto width = requiredWidth != 0 ? requiredWidth : this->_renderingCanvas->getWidth();
	auto height = requiredHeight != 0 ? requiredHeight : this->_renderingCanvas->getHeight();
	auto x = viewport->x;
	auto y = viewport->y;

	this->_cachedViewport = viewport;

	this->_gl->viewport(x * width, y * height, width * viewport->width, height * viewport->height);
	this->_aspectRatio = (width * viewport->width) / (height * viewport->height);
};

void Babylon::Engine::setDirectViewport(int x, int y, int width, int height) {
	this->_cachedViewport = nullptr;

	this->_gl->viewport(x, y, width, height);
	this->_aspectRatio = width / height;
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

void Babylon::Engine::bindFramebuffer(BaseTexture::Ptr texture) {
	auto gl = this->_gl;
	gl->bindFramebuffer(gl->FRAMEBUFFER, texture->_framebuffer);
	this->_gl->viewport(0, 0, texture->_width, texture->_height);
	this->_aspectRatio = (float)texture->_width / (float)texture->_height;

	this->wipeCaches();
};

void Babylon::Engine::unBindFramebuffer(BaseTexture::Ptr texture) {
	if (texture->generateMipMaps) {
		auto gl = this->_gl;
		gl->bindTexture(gl->TEXTURE_2D, texture->_texture);
		gl->generateMipmap(gl->TEXTURE_2D);
		gl->bindTexture(gl->TEXTURE_2D, nullptr);
	}
};

void Babylon::Engine::flushFramebuffer() {
	this->_gl->flush();
};

void Babylon::Engine::restoreDefaultFramebuffer() {
	this->_gl->bindFramebuffer(this->_gl->FRAMEBUFFER, nullptr);

	this->setViewport(this->_cachedViewport);

	this->wipeCaches();
};

// VBOs
IGLBuffer::Ptr Babylon::Engine::createVertexBuffer(Float32Array vertices) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, vbo);
	this->_gl->bufferData(this->_gl->ARRAY_BUFFER, vertices, this->_gl->STATIC_DRAW);
	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

IGLBuffer::Ptr Babylon::Engine::createDynamicVertexBuffer(GLsizeiptr capacity) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, vbo);
	this->_gl->bufferData(this->_gl->ARRAY_BUFFER, capacity, this->_gl->DYNAMIC_DRAW);
	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

void Babylon::Engine::updateDynamicVertexBuffer(IGLBuffer::Ptr vertexBuffer, Float32Array vertices, size_t length = 0) {
	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, vertexBuffer);
	if (length) {
		this->_gl->bufferSubData(this->_gl->ARRAY_BUFFER, 0, Float32Array(vertices.begin(), vertices.begin() + length));
	} else {
		this->_gl->bufferSubData(this->_gl->ARRAY_BUFFER, 0, vertices);
	}

	this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, nullptr);
};

IGLBuffer::Ptr Babylon::Engine::createIndexBuffer(Uint16Array indices) {
	auto vbo = this->_gl->createBuffer();
	this->_gl->bindBuffer(this->_gl->ELEMENT_ARRAY_BUFFER, vbo);
	this->_gl->bufferData(this->_gl->ELEMENT_ARRAY_BUFFER, indices, this->_gl->STATIC_DRAW);
	this->_gl->bindBuffer(this->_gl->ELEMENT_ARRAY_BUFFER, nullptr);
	vbo->references = 1;
	return vbo;
};

/*
void Babylon::Engine::bindBuffers(VertexBuffer::Ptr vertexBuffer, IGLBuffer::Ptr indexBuffer, Int32Array vertexDeclaration, int vertexStrideSize, Effect::Ptr effect) {
	if (this->_cachedVertexBuffer != vertexBuffer || this->_cachedEffectForVertexBuffer != effect) {
		this->_cachedVertexBuffer = vertexBuffer;
		this->_cachedEffectForVertexBuffer = effect;

		this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, vertexBuffer);

		auto offset = 0;
		for (auto index = 0; index < vertexDeclaration.size(); index++) {
			auto order = effect->getAttribute(index);

			if (order >= 0) {
				this->_gl->vertexAttribPointer(order, vertexDeclaration[index], this->_gl->FLOAT, false, vertexStrideSize, offset);
			}
			offset += vertexDeclaration[index] * 4;
		}
	}

	if (this->_cachedIndexBuffer != indexBuffer) {
		this->_cachedIndexBuffer = indexBuffer;
		this->_gl->bindBuffer(this->_gl->ELEMENT_ARRAY_BUFFER, indexBuffer);
	}
};

void Babylon::Engine::bindMultiBuffers(VertexBuffer::Array vertexBuffers, IGLBuffer::Ptr indexBuffer, Effect::Ptr effect) {
	if (this->_cachedVertexBuffers != vertexBuffers || this->_cachedEffectForVertexBuffers != effect) {
		this->_cachedVertexBuffers = vertexBuffers;
		this->_cachedEffectForVertexBuffers = effect;

		auto attributes = effect->getAttributesNames();

		for (auto index = 0; index < attributes.size(); index++) {
			auto order = effect->getAttribute(index);

			if (order >= 0) {
				// TODO: double check if vertexBuffers[attributes[index]] can be replaced with vertexBuffers[order]
				auto vertexBuffer = vertexBuffers.at(order);
				auto stride = vertexBuffer->getStrideSize();
				this->_gl->bindBuffer(this->_gl->ARRAY_BUFFER, vertexBuffer->_buffer);
				this->_gl->vertexAttribPointer(order, stride, this->_gl->FLOAT, false, stride * 4, 0);
			}
		}
	}

	if (this->_cachedIndexBuffer != indexBuffer) {
		this->_cachedIndexBuffer = indexBuffer;
		this->_gl->bindBuffer(this->_gl->ELEMENT_ARRAY_BUFFER, indexBuffer);
	}
};
*/

void Babylon::Engine::_releaseBuffer(IGLBuffer::Ptr buffer) {
	buffer->references--;

	if (buffer->references == 0) {
		this->_gl->deleteBuffer(buffer);
	}
};

/*
void Babylon::Engine::draw(useTriangles, indexStart, indexCount) {
	this->_gl->drawElements(useTriangles ? this->_gl->TRIANGLES : this->_gl->LINES, indexCount, this->_gl->UNSIGNED_SHORT, indexStart * 2);
};

// Shaders
void Babylon::Engine::createEffect(baseName, attributesNames, uniformsNames, samplers, defines, optionalDefines) {
	auto vertex = baseName->vertex || baseName;
	auto fragment = baseName->fragment || baseName;

	auto name = vertex + "+" + fragment + "@" + defines;
	if (this->_compiledEffects[name]) {
		return this->_compiledEffects[name];
	}

	auto effect = new BABYLON->Effect(baseName, attributesNames, uniformsNames, samplers, this, defines, optionalDefines);
	this->_compiledEffects[name] = effect;

	return effect;
};

void Babylon::Engine::compileShader(gl, source, type, defines) {
	auto shader = gl->createShader(type === "vertex" ? gl->VERTEX_SHADER : gl->FRAGMENT_SHADER);

	gl->shaderSource(shader, (defines ? defines + "\n" : "") + source);
	gl->compileShader(shader);

	if (!gl->getShaderParameter(shader, gl->COMPILE_STATUS)) {
		throw new Error(gl->getShaderInfoLog(shader));
	}
	return shader;
};

void Babylon::Engine::createShaderProgram(vertexCode, fragmentCode, defines) {
	auto vertexShader = compileShader(this->_gl, vertexCode, "vertex", defines);
	auto fragmentShader = compileShader(this->_gl, fragmentCode, "fragment", defines);

	auto shaderProgram = this->_gl->createProgram();
	this->_gl->attachShader(shaderProgram, vertexShader);
	this->_gl->attachShader(shaderProgram, fragmentShader);

	this->_gl->linkProgram(shaderProgram);

	auto error = this->_gl->getProgramInfoLog(shaderProgram);
	if (error) {
		throw new Error(error);
	}

	this->_gl->deleteShader(vertexShader);
	this->_gl->deleteShader(fragmentShader);

	return shaderProgram;
};

void Babylon::Engine::getUniforms(shaderProgram, uniformsNames) {
	auto results = [];

	for (auto index = 0; index < uniformsNames->length; index++) {
		results->push(this->_gl->getUniformLocation(shaderProgram, uniformsNames[index]));
	}

	return results;
};

void Babylon::Engine::getAttributes(shaderProgram, attributesNames) {
	auto results = [];

	for (auto index = 0; index < attributesNames->length; index++) {
		try {
			results->push(this->_gl->getAttribLocation(shaderProgram, attributesNames[index]));
		} catch (e) {
			results->push(-1);
		}
	}

	return results;
};

void Babylon::Engine::enableEffect(effect) {
	if (!effect || !effect->getAttributesCount() || this->_currentEffect === effect) {
		return;
	}
	// Use program
	this->_gl->useProgram(effect->getProgram());

	for (auto index = 0; index < effect->getAttributesCount() ; index++) {
		// Attributes
		auto order = effect->getAttribute(index);

		if (order >= 0) {
			this->_gl->enableVertexAttribArray(effect->getAttribute(index));
		}
	}

	this->_currentEffect = effect;
};

void Babylon::Engine::setMatrices(uniform, matrices) {
	if (!uniform)
		return;

	this->_gl->uniformMatrix4fv(uniform, false, matrices);
};

void Babylon::Engine::setMatrix(uniform, matrix) {
	if (!uniform)
		return;

	this->_gl->uniformMatrix4fv(uniform, false, matrix->toArray());
};

void Babylon::Engine::setFloat(uniform, value) {
	if (!uniform)
		return;

	this->_gl->uniform1f(uniform, value);
};

void Babylon::Engine::setFloat2(uniform, x, y) {
	if (!uniform)
		return;

	this->_gl->uniform2f(uniform, x, y);
};

void Babylon::Engine::setFloat3(uniform, x, y, z) {
	if (!uniform)
		return;

	this->_gl->uniform3f(uniform, x, y, z);
};

void Babylon::Engine::setBool(uniform, bool) {
	if (!uniform)
		return;

	this->_gl->uniform1i(uniform, bool);
};

void Babylon::Engine::setFloat4(uniform, x, y, z, w) {
	if (!uniform)
		return;

	this->_gl->uniform4f(uniform, x, y, z, w);
};

void Babylon::Engine::setColor3(uniform, color3) {
	if (!uniform)
		return;

	this->_gl->uniform3f(uniform, color3->r, color3->g, color3->b);
};

void Babylon::Engine::setColor4(uniform, color3, alpha) {
	if (!uniform)
		return;

	this->_gl->uniform4f(uniform, color3->r, color3->g, color3->b, alpha);
};

// States
void Babylon::Engine::setState(culling) {
	// Culling        
	if (this->_currentState->culling !== culling) {
		if (culling) {
			this->_gl->cullFace(this->cullBackFaces ? this->_gl->BACK : this->_gl->FRONT);
			this->_gl->enable(this->_gl->CULL_FACE);
		} else {
			this->_gl->disable(this->_gl->CULL_FACE);
		}

		this->_currentState->culling = culling;
	}
};

void Babylon::Engine::setDepthBuffer(enable) {
	if (enable) {
		this->_gl->enable(this->_gl->DEPTH_TEST);
	} else {
		this->_gl->disable(this->_gl->DEPTH_TEST);
	}
};

void Babylon::Engine::setDepthWrite(enable) {
	this->_gl->depthMask(enable);
};

void Babylon::Engine::setColorWrite(enable) {
	this->_gl->colorMask(enable, enable, enable, enable);
};

void Babylon::Engine::setAlphaMode(mode) {

	switch (mode) {
	case BABYLON->Engine->ALPHA_DISABLE:
		this->setDepthWrite(true);
		this->_gl->disable(this->_gl->BLEND);
		break;
	case BABYLON->Engine->ALPHA_COMBINE:
		this->setDepthWrite(false);
		this->_gl->blendFuncSeparate(this->_gl->SRC_ALPHA, this->_gl->ONE_MINUS_SRC_ALPHA, this->_gl->ZERO, this->_gl->ONE);
		this->_gl->enable(this->_gl->BLEND);
		break;
	case BABYLON->Engine->ALPHA_ADD:
		this->setDepthWrite(false);
		this->_gl->blendFuncSeparate(this->_gl->ONE, this->_gl->ONE, this->_gl->ZERO, this->_gl->ONE);
		this->_gl->enable(this->_gl->BLEND);
		break;
	}
};
*/

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

/*
void Babylon::Engine::getExponantOfTwo(value, max) {
	auto count = 1;

	do {
		count *= 2;
	} while (count < value);

	if (count > max)
		count = max;

	return count;
};

void Babylon::Engine::createTexture(url, noMipmap, invertY, scene) {
	auto texture = this->_gl->createTexture();
	auto that = this;

	auto onload(img) {
		auto potWidth = getExponantOfTwo(img->width, that->_caps->maxTextureSize);
		auto potHeight = getExponantOfTwo(img->height, that->_caps->maxTextureSize);
		auto isPot = (img->width == potWidth && img->height == potHeight);

		if (!isPot) {
			that->_workingCanvas->width = potWidth;
			that->_workingCanvas->height = potHeight;

			that->_workingContext->drawImage(img, 0, 0, img->width, img->height, 0, 0, potWidth, potHeight);
		};

		that->_gl->bindTexture(that->_gl->TEXTURE_2D, texture);
		that->_gl->pixelStorei(that->_gl->UNPACK_FLIP_Y_WEBGL, invertY === undefined ? true : invertY);
		that->_gl->texImage2D(that->_gl->TEXTURE_2D, 0, that->_gl->RGBA, that->_gl->RGBA, that->_gl->UNSIGNED_BYTE, isPot ? img : that->_workingCanvas);
		that->_gl->texParameteri(that->_gl->TEXTURE_2D, that->_gl->TEXTURE_MAG_FILTER, that->_gl->LINEAR);

		if (noMipmap) {
			that->_gl->texParameteri(that->_gl->TEXTURE_2D, that->_gl->TEXTURE_MIN_FILTER, that->_gl->LINEAR);
		} else {
			that->_gl->texParameteri(that->_gl->TEXTURE_2D, that->_gl->TEXTURE_MIN_FILTER, that->_gl->LINEAR_MIPMAP_LINEAR);
			that->_gl->generateMipmap(that->_gl->TEXTURE_2D);
		}
		that->_gl->bindTexture(that->_gl->TEXTURE_2D, nullptr);

		that->_activeTexturesCache = [];
		texture->_baseWidth = img->width;
		texture->_baseHeight = img->height;
		texture->_width = potWidth;
		texture->_height = potHeight;
		texture->isReady = true;
		scene->_removePendingData(texture);
	};

	auto onerror() {
		scene->_removePendingData(texture);
	};

	scene->_addPendingData(texture);
	BABYLON->Tools->LoadImage(url, onload, onerror, scene->database);

	texture->url = url;
	texture->noMipmap = noMipmap;
	texture->references = 1;
	this->_loadedTexturesCache->push(texture);

	return texture;
};

void Babylon::Engine::createDynamicTexture(width, height, generateMipMaps) {
	auto texture = this->_gl->createTexture();

	width = getExponantOfTwo(width, this->_caps->maxTextureSize);
	height = getExponantOfTwo(height, this->_caps->maxTextureSize);

	this->_gl->bindTexture(this->_gl->TEXTURE_2D, texture);
	this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_MAG_FILTER, this->_gl->LINEAR);

	if (!generateMipMaps) {
		this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_MIN_FILTER, this->_gl->LINEAR);
	} else {
		this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_MIN_FILTER, this->_gl->LINEAR_MIPMAP_LINEAR);
	}
	this->_gl->bindTexture(this->_gl->TEXTURE_2D, nullptr);

	this->_activeTexturesCache = [];
	texture->_baseWidth = width;
	texture->_baseHeight = height;
	texture->_width = width;
	texture->_height = height;
	texture->isReady = false;
	texture->generateMipMaps = generateMipMaps;
	texture->references = 1;

	this->_loadedTexturesCache->push(texture);

	return texture;
};

void Babylon::Engine::updateDynamicTexture(texture, canvas, invertY) {
	this->_gl->bindTexture(this->_gl->TEXTURE_2D, texture);
	this->_gl->pixelStorei(this->_gl->UNPACK_FLIP_Y_WEBGL, invertY);
	this->_gl->texImage2D(this->_gl->TEXTURE_2D, 0, this->_gl->RGBA, this->_gl->RGBA, this->_gl->UNSIGNED_BYTE, canvas);
	if (texture->generateMipMaps) {
		this->_gl->generateMipmap(this->_gl->TEXTURE_2D);
	}
	this->_gl->bindTexture(this->_gl->TEXTURE_2D, nullptr);
	this->_activeTexturesCache = [];
	texture->isReady = true;
};

void Babylon::Engine::updateVideoTexture(texture, video) {
	this->_gl->bindTexture(this->_gl->TEXTURE_2D, texture);
	this->_gl->pixelStorei(this->_gl->UNPACK_FLIP_Y_WEBGL, false);

	// Scale the video if it is a NPOT
	if (video->videoWidth !== texture->_width || video->videoHeight !== texture->_height) {
		if (!texture->_workingCanvas) {
			texture->_workingCanvas = document->createElement("canvas");
			texture->_workingContext = texture->_workingCanvas->getContext("2d");
			texture->_workingCanvas->width = texture->_width;
			texture->_workingCanvas->height = texture->_height;
		}

		texture->_workingContext->drawImage(video, 0, 0, video->videoWidth, video->videoHeight, 0, 0, texture->_width, texture->_height);

		this->_gl->texImage2D(this->_gl->TEXTURE_2D, 0, this->_gl->RGBA, this->_gl->RGBA, this->_gl->UNSIGNED_BYTE, texture->_workingCanvas);
	} else {
		this->_gl->texImage2D(this->_gl->TEXTURE_2D, 0, this->_gl->RGBA, this->_gl->RGBA, this->_gl->UNSIGNED_BYTE, video);
	}

	if (texture->generateMipMaps) {
		this->_gl->generateMipmap(this->_gl->TEXTURE_2D);
	}

	this->_gl->bindTexture(this->_gl->TEXTURE_2D, nullptr);
	this->_activeTexturesCache = [];
	texture->isReady = true;
};

void Babylon::Engine::createRenderTargetTexture(size, options) {
	// old version had a "generateMipMaps" arg instead of options->
	// if options->generateMipMaps is undefined, consider that options itself if the generateMipmaps value
	// in the same way, generateDepthBuffer is defaulted to true
	auto generateMipMaps = false;
	auto generateDepthBuffer = true;
	auto samplingMode = BABYLON->Texture->TRILINEAR_SAMPLINGMODE;
	if (options !== undefined) {
		generateMipMaps = options->generateMipMaps === undefined ? options : options->generateMipmaps;
		generateDepthBuffer = options->generateDepthBuffer === undefined ? true : options->generateDepthBuffer;
		if (options->samplingMode !== undefined) {
			samplingMode = options->samplingMode;
		}
	}
	auto gl = this->_gl;

	auto texture = gl->createTexture();
	gl->bindTexture(gl->TEXTURE_2D, texture);

	auto width = size->width || size;
	auto height = size->height || size;
	auto magFilter = gl->NEAREST;
	auto minFilter = gl->NEAREST;
	if (samplingMode === BABYLON->Texture->BILINEAR_SAMPLINGMODE) {
		magFilter = gl->LINEAR;
		if (generateMipMaps) {
			minFilter = gl->LINEAR_MIPMAP_NEAREST;
		} else {
			minFilter = gl->LINEAR;
		}
	} else if (samplingMode === BABYLON->Texture->TRILINEAR_SAMPLINGMODE) {
		magFilter = gl->LINEAR;
		if (generateMipMaps) {
			minFilter = gl->LINEAR_MIPMAP_LINEAR;
		} else {
			minFilter = gl->LINEAR;
		}
	}
	gl->texParameteri(gl->TEXTURE_2D, gl->TEXTURE_MAG_FILTER, magFilter);
	gl->texParameteri(gl->TEXTURE_2D, gl->TEXTURE_MIN_FILTER, minFilter);
	gl->texParameteri(gl->TEXTURE_2D, gl->TEXTURE_WRAP_S, gl->CLAMP_TO_EDGE);
	gl->texParameteri(gl->TEXTURE_2D, gl->TEXTURE_WRAP_T, gl->CLAMP_TO_EDGE);
	gl->texImage2D(gl->TEXTURE_2D, 0, gl->RGBA, width, height, 0, gl->RGBA, gl->UNSIGNED_BYTE, nullptr);

	auto depthBuffer;
	// Create the depth buffer
	if (generateDepthBuffer) {
		depthBuffer = gl->createRenderbuffer();
		gl->bindRenderbuffer(gl->RENDERBUFFER, depthBuffer);
		gl->renderbufferStorage(gl->RENDERBUFFER, gl->DEPTH_COMPONENT16, width, height);
	}
	// Create the framebuffer
	auto framebuffer = gl->createFramebuffer();
	gl->bindFramebuffer(gl->FRAMEBUFFER, framebuffer);
	gl->framebufferTexture2D(gl->FRAMEBUFFER, gl->COLOR_ATTACHMENT0, gl->TEXTURE_2D, texture, 0);
	if (generateDepthBuffer) {
		gl->framebufferRenderbuffer(gl->FRAMEBUFFER, gl->DEPTH_ATTACHMENT, gl->RENDERBUFFER, depthBuffer);
	}

	// Unbind
	gl->bindTexture(gl->TEXTURE_2D, nullptr);
	gl->bindRenderbuffer(gl->RENDERBUFFER, nullptr);
	gl->bindFramebuffer(gl->FRAMEBUFFER, nullptr);

	texture->_framebuffer = framebuffer;
	if (generateDepthBuffer) {
		texture->_depthBuffer = depthBuffer;
	}
	texture->_width = width;
	texture->_height = height;
	texture->isReady = true;
	texture->generateMipMaps = generateMipMaps;
	texture->references = 1;
	this->_activeTexturesCache = [];

	this->_loadedTexturesCache->push(texture);

	return texture;
};

//TODO: finish
//auto extensions = ["_px->jpg", "_py->jpg", "_pz->jpg", "_nx->jpg", "_ny->jpg", "_nz->jpg"];

void Babylon::Engine::cascadeLoad(rootUrl, index, loadedImages, scene, onfinish) {
	auto img;

	auto onload() {
		loadedImages->push(img);

		scene->_removePendingData(img);

		if (index != extensions->length - 1) {
			cascadeLoad(rootUrl, index + 1, loadedImages, scene, onfinish);
		} else {
			onfinish(loadedImages);
		}
	};

	auto onerror() {
		scene->_removePendingData(img);
	};

	img = BABYLON->Tools->LoadImage(rootUrl + extensions[index], onload, onerror, scene->database);
	scene->_addPendingData(img);
};

void Babylon::Engine::createCubeTexture(rootUrl, scene) {
	auto gl = this->_gl;

	auto texture = gl->createTexture();
	texture->isCube = true;
	texture->url = rootUrl;
	texture->references = 1;
	this->_loadedTexturesCache->push(texture);

	auto that = this;
	cascadeLoad(rootUrl, 0, [], scene, function (imgs) {
		auto width = getExponantOfTwo(imgs[0]->width, that->_caps->maxCubemapTextureSize);
		auto height = width;

		that->_workingCanvas->width = width;
		that->_workingCanvas->height = height;

		auto faces = [
			gl->TEXTURE_CUBE_MAP_POSITIVE_X, gl->TEXTURE_CUBE_MAP_POSITIVE_Y, gl->TEXTURE_CUBE_MAP_POSITIVE_Z,
				gl->TEXTURE_CUBE_MAP_NEGATIVE_X, gl->TEXTURE_CUBE_MAP_NEGATIVE_Y, gl->TEXTURE_CUBE_MAP_NEGATIVE_Z
		];

		gl->bindTexture(gl->TEXTURE_CUBE_MAP, texture);
		gl->pixelStorei(gl->UNPACK_FLIP_Y_WEBGL, false);

		for (auto index = 0; index < faces->length; index++) {
			that->_workingContext->drawImage(imgs[index], 0, 0, imgs[index]->width, imgs[index]->height, 0, 0, width, height);
			gl->texImage2D(faces[index], 0, gl->RGBA, gl->RGBA, gl->UNSIGNED_BYTE, that->_workingCanvas);
		}

		gl->generateMipmap(gl->TEXTURE_CUBE_MAP);
		gl->texParameteri(gl->TEXTURE_CUBE_MAP, gl->TEXTURE_MAG_FILTER, gl->LINEAR);
		gl->texParameteri(gl->TEXTURE_CUBE_MAP, gl->TEXTURE_MIN_FILTER, gl->LINEAR_MIPMAP_LINEAR);
		gl->texParameteri(gl->TEXTURE_CUBE_MAP, gl->TEXTURE_WRAP_S, gl->CLAMP_TO_EDGE);
		gl->texParameteri(gl->TEXTURE_CUBE_MAP, gl->TEXTURE_WRAP_T, gl->CLAMP_TO_EDGE);

		gl->bindTexture(gl->TEXTURE_CUBE_MAP, nullptr);

		that->_activeTexturesCache = [];

		texture->_width = width;
		texture->_height = height;
		texture->isReady = true;
	});

	return texture;
};

void Babylon::Engine::_releaseTexture(texture) {
	auto gl = this->_gl;

	if (texture->_framebuffer) {
		gl->deleteFramebuffer(texture->_framebuffer);
	}

	if (texture->_depthBuffer) {
		gl->deleteRenderbuffer(texture->_depthBuffer);
	}

	gl->deleteTexture(texture);

	// Unbind channels
	for (auto channel = 0; channel < this->_caps->maxTexturesImageUnits; channel++) {
		this->_gl->activeTexture(this->_gl["TEXTURE" + channel]);
		this->_gl->bindTexture(this->_gl->TEXTURE_2D, nullptr);
		this->_gl->bindTexture(this->_gl->TEXTURE_CUBE_MAP, nullptr);
		this->_activeTexturesCache[channel] = nullptr;
	}

	auto index = this->_loadedTexturesCache->indexOf(texture);
	if (index !== -1) {
		this->_loadedTexturesCache->splice(index, 1);
	}
};

void Babylon::Engine::bindSamplers(effect) {
	this->_gl->useProgram(effect->getProgram());
	auto samplers = effect->getSamplers();
	for (auto index = 0; index < samplers->length; index++) {
		auto uniform = effect->getUniform(samplers[index]);
		this->_gl->uniform1i(uniform, index);
	}
	this->_currentEffect = nullptr;
};


void Babylon::Engine::_bindTexture(channel, texture) {
	this->_gl->activeTexture(this->_gl["TEXTURE" + channel]);
	this->_gl->bindTexture(this->_gl->TEXTURE_2D, texture);

	this->_activeTexturesCache[channel] = nullptr;
};

void Babylon::Engine::setTextureFromPostProcess(channel, postProcess) {
	this->_bindTexture(channel, postProcess->_texture);
};

void Babylon::Engine::setTexture(channel, texture) {
	if (channel < 0) {
		return;
	}
	// Not ready?
	if (!texture || !texture->isReady()) {
		if (this->_activeTexturesCache[channel] != nullptr) {
			this->_gl->activeTexture(this->_gl["TEXTURE" + channel]);
			this->_gl->bindTexture(this->_gl->TEXTURE_2D, nullptr);
			this->_gl->bindTexture(this->_gl->TEXTURE_CUBE_MAP, nullptr);
			this->_activeTexturesCache[channel] = nullptr;
		}
		return;
	}

	// Video
	if (texture instanceof BABYLON->VideoTexture) {
		if (texture->_update()) {
			this->_activeTexturesCache[channel] = nullptr;
		}
	} else if (texture->delayLoadState == BABYLON->Engine->DELAYLOADSTATE_NOTLOADED) { // Delay loading
		texture->delayLoad();
		return;
	}

	if (this->_activeTexturesCache[channel] == texture) {
		return;
	}
	this->_activeTexturesCache[channel] = texture;

	auto internalTexture = texture->getInternalTexture();
	this->_gl->activeTexture(this->_gl["TEXTURE" + channel]);

	if (internalTexture->isCube) {
		this->_gl->bindTexture(this->_gl->TEXTURE_CUBE_MAP, internalTexture);

		if (internalTexture->_cachedCoordinatesMode !== texture->coordinatesMode) {
			internalTexture->_cachedCoordinatesMode = texture->coordinatesMode;
			this->_gl->texParameteri(this->_gl->TEXTURE_CUBE_MAP, this->_gl->TEXTURE_WRAP_S, texture->coordinatesMode !== BABYLON->CubeTexture->CUBIC_MODE ? this->_gl->REPEAT : this->_gl->CLAMP_TO_EDGE);
			this->_gl->texParameteri(this->_gl->TEXTURE_CUBE_MAP, this->_gl->TEXTURE_WRAP_T, texture->coordinatesMode !== BABYLON->CubeTexture->CUBIC_MODE ? this->_gl->REPEAT : this->_gl->CLAMP_TO_EDGE);
		}

		this->_setAnisotropicLevel(this->_gl->TEXTURE_CUBE_MAP, texture);
	} else {
		this->_gl->bindTexture(this->_gl->TEXTURE_2D, internalTexture);

		if (internalTexture->_cachedWrapU !== texture->wrapU) {
			internalTexture->_cachedWrapU = texture->wrapU;

			switch (texture->wrapU) {
			case BABYLON->Texture->WRAP_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_S, this->_gl->REPEAT);
				break;
			case BABYLON->Texture->CLAMP_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_S, this->_gl->CLAMP_TO_EDGE);
				break;
			case BABYLON->Texture->MIRROR_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_S, this->_gl->MIRRORED_REPEAT);
				break;
			}
		}

		if (internalTexture->_cachedWrapV !== texture->wrapV) {
			internalTexture->_cachedWrapV = texture->wrapV;
			switch (texture->wrapV) {
			case BABYLON->Texture->WRAP_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_T, this->_gl->REPEAT);
				break;
			case BABYLON->Texture->CLAMP_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_T, this->_gl->CLAMP_TO_EDGE);
				break;
			case BABYLON->Texture->MIRROR_ADDRESSMODE:
				this->_gl->texParameteri(this->_gl->TEXTURE_2D, this->_gl->TEXTURE_WRAP_T, this->_gl->MIRRORED_REPEAT);
				break;
			}
		}

		this->_setAnisotropicLevel(this->_gl->TEXTURE_2D, texture);
	}
};

void Babylon::Engine::_setAnisotropicLevel(key, Texture texture) {
	auto anisotropicFilterExtension = this->_caps->textureAnisotropicFilterExtension;

	if (anisotropicFilterExtension && texture->_cachedAnisotropicFilteringLevel !== texture->anisotropicFilteringLevel) {
		this->_gl->texParameterf(key, anisotropicFilterExtension->TEXTURE_MAX_ANISOTROPY_EXT, Math->min(texture->anisotropicFilteringLevel, this->_caps->maxAnisotropy));
		texture->_cachedAnisotropicFilteringLevel = texture->anisotropicFilteringLevel;
	}
};

// Dispose
void Babylon::Engine::dispose() {
	// Release scenes
	while (this->scenes->length) {
		this->scenes[0]->dispose();
	}

	// Release effects
	for (auto name in this->_compiledEffects->length) {
		this->_gl->deleteProgram(this->_compiledEffects[name]->_program);
	}
};
*/

bool Babylon::Engine::isSupported() {
	return true;
};
