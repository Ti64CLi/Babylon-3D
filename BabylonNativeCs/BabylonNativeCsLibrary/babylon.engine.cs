using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    using BabylonNativeCsLibrary;

    public partial class EngineCapabilities
    {
        public int maxTexturesImageUnits;
        public int maxTextureSize;
        public int maxCubemapTextureSize;
        public int maxRenderTextureSize;
        public bool standardDerivatives;
        public WEBGL_compressed_texture_s3tc s3tc;
        public bool textureFloat;
        public EXT_texture_filter_anisotropic textureAnisotropicFilterExtension;
        public int maxAnisotropy;
        public ANGLE_instanced_arrays instancedArrays;
    }
    public partial class Engine
    {
        public const int ALPHA_DISABLE = 0;
        public const int ALPHA_ADD = 1;
        public const int ALPHA_COMBINE = 2;
        public const int DELAYLOADSTATE_NONE = 0;
        public const int DELAYLOADSTATE_LOADED = 1;
        public const int DELAYLOADSTATE_LOADING = 2;
        public const int DELAYLOADSTATE_NOTLOADED = 4;
        public static string Version
        {
            get
            {
                return "1.13.0";
            }
        }
        public static double Epsilon = 0.001;
        public static double CollisionsEpsilon = 0.001;
        public static string ShadersRepository = "Babylon/Shaders/";
        public bool isFullscreen = false;
        public bool isPointerLock = false;
        public bool forceWireframe = false;
        public bool cullBackFaces = true;
        public bool renderEvenInBackground = true;
        public Array<Scene> scenes = new Array<Scene>();
        private WebGLRenderingContext _gl;
        private HTMLCanvasElement _renderingCanvas;
        private bool _windowIsBackground = false;
        private EventListener _onBlur;
        private EventListener _onFocus;
        private EventListener _onFullscreenChange;
        private EventListener _onPointerLockChange;
        private double _hardwareScalingLevel;
        private EngineCapabilities _caps;
        private bool _pointerLockRequested;
        private bool _alphaTest;
        private bool _runningLoop = false;
        private System.Action _renderFunction;
        private Array<WebGLTexture> _loadedTexturesCache = new Array<WebGLTexture>();
        public Array<BaseTexture> _activeTexturesCache = new Array<BaseTexture>();
        private Effect _currentEffect;
        private bool _cullingState;
        private Map<string, Effect> _compiledEffects = new Map<string, Effect>();
        private Array<bool> _vertexAttribArrays;
        private bool _depthMask = false;
        private Viewport _cachedViewport;
        private object _cachedVertexBuffers;
        private WebGLBuffer _cachedIndexBuffer;
        private Effect _cachedEffectForVertexBuffers;
        private WebGLTexture _currentRenderTarget;
        private ClientRect _canvasClientRect;
        private HTMLCanvasElement _workingCanvas;
        private CanvasRenderingContext2D _workingContext;

        public static Web.Window window;
        public static Web.Document document;
        public static Web.Console console;

        public Engine(HTMLCanvasElement canvas, bool antialias = false, EngineOptions engineOptions = null)
        {
            this._renderingCanvas = canvas;
            this._canvasClientRect = this._renderingCanvas.getBoundingClientRect();
            engineOptions = engineOptions ?? new EngineOptions();
            engineOptions.antialias = antialias;
            try
            {
                this._gl = (WebGLRenderingContext)(canvas.getContext("webgl", engineOptions) ?? canvas.getContext("experimental-webgl", engineOptions));
            }
            catch (Exception)
            {
                throw new Error("WebGL not supported");
            }
            if (this._gl == null)
            {
                throw new Error("WebGL not supported");
            }

            document = canvas.document;
            window = document.parentWindow;
            console = window.console;

            this._onBlur = (e) =>
            {
                this._windowIsBackground = true;
            };
            this._onFocus = (e) =>
            {
                this._windowIsBackground = false;
            };
            window.addEventListener("blur", this._onBlur);
            window.addEventListener("focus", this._onFocus);
            this._workingCanvas = (HTMLCanvasElement)document.createElement("canvas");
            this._workingContext = (CanvasRenderingContext2D)this._workingCanvas.getContext("2d");
            this._hardwareScalingLevel = 1.0 / (window.devicePixelRatio == 0.0 ? 1.0 : window.devicePixelRatio);
            this.resize();
            this._caps = new EngineCapabilities();
            this._caps.maxTexturesImageUnits = (int)this._gl.getParameter(Gl.MAX_TEXTURE_IMAGE_UNITS);
            this._caps.maxTextureSize = (int)this._gl.getParameter(Gl.MAX_TEXTURE_SIZE);
            this._caps.maxCubemapTextureSize = (int)this._gl.getParameter(Gl.MAX_CUBE_MAP_TEXTURE_SIZE);
            this._caps.maxRenderTextureSize = (int)this._gl.getParameter(Gl.MAX_RENDERBUFFER_SIZE);
            this._caps.standardDerivatives = (this._gl.getExtension("OES_standard_derivatives") != null);
            this._caps.s3tc = (WEBGL_compressed_texture_s3tc)this._gl.getExtension("WEBGL_compressed_texture_s3tc");
            this._caps.textureFloat = (this._gl.getExtension("OES_texture_float") != null);
            this._caps.textureAnisotropicFilterExtension = (EXT_texture_filter_anisotropic)(this._gl.getExtension("EXT_texture_filter_anisotropic"));
            this._caps.maxAnisotropy = (int)((this._caps.textureAnisotropicFilterExtension != null) ? this._gl.getParameter(Gl.MAX_TEXTURE_MAX_ANISOTROPY_EXT) : 0);
            this._caps.instancedArrays = (ANGLE_instanced_arrays)this._gl.getExtension("ANGLE_instanced_arrays");
            this.setDepthBuffer(true);
            this.setDepthFunctionToLessOrEqual();
            this.setDepthWrite(true);
            this._onFullscreenChange = (e) =>
            {
                /*
                if (document.fullscreen != null) {
                    this.isFullscreen = document.fullscreen;
                } else
                if (document.mozFullScreen != null) {
                    this.isFullscreen = document.mozFullScreen;
                } else
                if (document.webkitIsFullScreen != null) {
                    this.isFullscreen = document.webkitIsFullScreen;
                } else
                if (document.msIsFullScreen != null) {
                    this.isFullscreen = document.msIsFullScreen;
                }
                if (this.isFullscreen && this._pointerLockRequested) {
                    canvas.requestPointerLock = canvas.requestPointerLock || canvas.msRequestPointerLock || canvas.mozRequestPointerLock || canvas.webkitRequestPointerLock;
                    if (canvas.requestPointerLock) {
                        canvas.requestPointerLock();
                    }
                }
                */
            };
            document.addEventListener("fullscreenchange", this._onFullscreenChange, false);
            document.addEventListener("mozfullscreenchange", this._onFullscreenChange, false);
            document.addEventListener("webkitfullscreenchange", this._onFullscreenChange, false);
            document.addEventListener("msfullscreenchange", this._onFullscreenChange, false);
            this._onPointerLockChange = (e) =>
            {
                ////this.isPointerLock = document.pointerLockElement == canvas;
            };
            document.addEventListener("pointerlockchange", this._onPointerLockChange, false);
            document.addEventListener("mspointerlockchange", this._onPointerLockChange, false);
            document.addEventListener("mozpointerlockchange", this._onPointerLockChange, false);
            document.addEventListener("webkitpointerlockchange", this._onPointerLockChange, false);
        }
        private WebGLShader compileShader(WebGLRenderingContext gl, string source, string type, string defines)
        {
            var shader = gl.createShader((type == "vertex") ? Gl.VERTEX_SHADER : Gl.FRAGMENT_SHADER);
            gl.shaderSource(shader, ((!string.IsNullOrEmpty(defines)) ? defines + "\\n" : string.Empty) + source);
            gl.compileShader(shader);
            if (gl.getShaderParameter(shader, Gl.COMPILE_STATUS) == null)
            {
                throw new Error(gl.getShaderInfoLog(shader));
            }
            return shader;
        }
        private MinMagFilter getSamplingParameters(int samplingMode, bool generateMipMaps, WebGLRenderingContext gl)
        {
            var magFilter = Gl.NEAREST;
            var minFilter = Gl.NEAREST;
            if (samplingMode == BABYLON.Texture.BILINEAR_SAMPLINGMODE)
            {
                magFilter = Gl.LINEAR;
                if (generateMipMaps)
                {
                    minFilter = Gl.LINEAR_MIPMAP_NEAREST;
                }
                else
                {
                    minFilter = Gl.LINEAR;
                }
            }
            else
                if (samplingMode == BABYLON.Texture.TRILINEAR_SAMPLINGMODE)
                {
                    magFilter = Gl.LINEAR;
                    if (generateMipMaps)
                    {
                        minFilter = Gl.LINEAR_MIPMAP_LINEAR;
                    }
                    else
                    {
                        minFilter = Gl.LINEAR;
                    }
                }
                else
                    if (samplingMode == BABYLON.Texture.NEAREST_SAMPLINGMODE)
                    {
                        magFilter = Gl.NEAREST;
                        if (generateMipMaps)
                        {
                            minFilter = Gl.NEAREST_MIPMAP_LINEAR;
                        }
                        else
                        {
                            minFilter = Gl.NEAREST;
                        }
                    }

            return new MinMagFilter { min = minFilter, mag = magFilter };
        }
        private int getExponantOfTwo(int value, int max)
        {
            var count = 1;
            do
            {
                count *= 2;
            }
            while (count < value);
            if (count > max)
                count = max;
            return count;
        }
        private void prepareWebGLTexture(WebGLTexture texture, WebGLRenderingContext gl, Scene scene, int width, int height, bool invertY, bool noMipmap, bool isCompressed, System.Action<int, int> processFunction, int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
        {
            var engine = scene.getEngine();
            var potWidth = getExponantOfTwo(width, engine.getCaps().maxTextureSize);
            var potHeight = getExponantOfTwo(height, engine.getCaps().maxTextureSize);
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, invertY ? 1 : 0);
            processFunction(potWidth, potHeight);
            var filters = getSamplingParameters(samplingMode, !noMipmap, gl);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MAG_FILTER, filters.mag);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MIN_FILTER, filters.min);
            if (!noMipmap && !isCompressed)
            {
                gl.generateMipmap(Gl.TEXTURE_2D);
            }
            gl.bindTexture(Gl.TEXTURE_2D, null);
            engine._activeTexturesCache = new Array<BaseTexture>();
            texture._baseWidth = width;
            texture._baseHeight = height;
            texture._width = potWidth;
            texture._height = potHeight;
            texture.isReady = true;
            scene._removePendingData(texture);
        }
        private void cascadeLoad(string rootUrl, int index, Array<HTMLImageElement> loadedImages, Scene scene, System.Action<Array<HTMLImageElement>> onfinish, Array<string> extensions)
        {
            HTMLImageElement img = null;
            Action<HTMLImageElement> onload = (HTMLImageElement imageElement) =>
            {
                loadedImages.push(imageElement);
                scene._removePendingData(imageElement);
                if (index != extensions.Length - 1)
                {
                    cascadeLoad(rootUrl, index + 1, loadedImages, scene, onfinish, extensions);
                }
                else
                {
                    onfinish(loadedImages);
                }
            };
            Action<HTMLImageElement, object> onerror = (HTMLImageElement imageElement, object err) =>
            {
                scene._removePendingData(imageElement);
            };
            img = BABYLON.Tools.LoadImage(rootUrl + extensions[index], onload, onerror, scene.database);
            scene._addPendingData(img);
        }
        public virtual double getAspectRatio(Camera camera)
        {
            var viewport = camera.viewport;
            return (this.getRenderWidth() * viewport.width) / (this.getRenderHeight() * viewport.height);
        }
        public virtual int getRenderWidth()
        {
            if (this._currentRenderTarget != null)
            {
                return this._currentRenderTarget._width;
            }
            return this._renderingCanvas.width;
        }
        public virtual int getRenderHeight()
        {
            if (this._currentRenderTarget != null)
            {
                return this._currentRenderTarget._height;
            }
            return this._renderingCanvas.height;
        }
        public virtual HTMLCanvasElement getRenderingCanvas()
        {
            return this._renderingCanvas;
        }
        public virtual ClientRect getRenderingCanvasClientRect()
        {
            return this._renderingCanvas.getBoundingClientRect();
        }
        public virtual void setHardwareScalingLevel(double level)
        {
            this._hardwareScalingLevel = level;
            this.resize();
        }
        public virtual double getHardwareScalingLevel()
        {
            return this._hardwareScalingLevel;
        }
        public virtual Array<WebGLTexture> getLoadedTexturesCache()
        {
            return this._loadedTexturesCache;
        }
        public virtual EngineCapabilities getCaps()
        {
            return this._caps;
        }
        public virtual void setDepthFunctionToGreater()
        {
            this._gl.depthFunc(Gl.GREATER);
        }
        public virtual void setDepthFunctionToGreaterOrEqual()
        {
            this._gl.depthFunc(Gl.GEQUAL);
        }
        public virtual void setDepthFunctionToLess()
        {
            this._gl.depthFunc(Gl.LESS);
        }
        public virtual void setDepthFunctionToLessOrEqual()
        {
            this._gl.depthFunc(Gl.LEQUAL);
        }
        public virtual void stopRenderLoop()
        {
            this._renderFunction = null;
            this._runningLoop = false;
        }
        public virtual void _renderLoop()
        {
            var shouldRender = true;
            if (!this.renderEvenInBackground && this._windowIsBackground)
            {
                shouldRender = false;
            }
            if (shouldRender)
            {
                this.beginFrame();
                if (this._renderFunction != null)
                {
                    this._renderFunction();
                }
                this.endFrame();
            }
            if (this._runningLoop)
            {
                BABYLON.Tools.QueueNewFrame((time) =>
                {
                    this._renderLoop();
                });
            }
        }
        public virtual void runRenderLoop(System.Action renderFunction)
        {
            this._runningLoop = true;
            this._renderFunction = renderFunction;
            BABYLON.Tools.QueueNewFrame((time) =>
            {
                this._renderLoop();
            });
        }
        public virtual void switchFullscreen(bool requestPointerLock)
        {
            if (this.isFullscreen)
            {
                BABYLON.Tools.ExitFullscreen();
            }
            else
            {
                this._pointerLockRequested = requestPointerLock;
                BABYLON.Tools.RequestFullscreen(this._renderingCanvas);
            }
        }
        public virtual void clear(Color3 color, bool backBuffer, bool depthStencil)
        {
            this._gl.clearColor(color.r, color.g, color.b, 1.0);
            if (this._depthMask)
            {
                this._gl.clearDepth(1.0);
            }
            var mode = 0;
            if (backBuffer)
                mode |= Gl.COLOR_BUFFER_BIT;
            if (depthStencil && this._depthMask)
                mode |= Gl.DEPTH_BUFFER_BIT;
            this._gl.clear(mode);
        }
        public virtual void clear(Color4 color, bool backBuffer, bool depthStencil)
        {
            this._gl.clearColor(color.r, color.g, color.b, color.a);
            if (this._depthMask)
            {
                this._gl.clearDepth(1.0);
            }
            var mode = 0;
            if (backBuffer)
                mode |= Gl.COLOR_BUFFER_BIT;
            if (depthStencil && this._depthMask)
                mode |= Gl.DEPTH_BUFFER_BIT;
            this._gl.clear(mode);
        }
        public virtual void setViewport(Viewport viewport, int requiredWidth = 0, int requiredHeight = 0)
        {
            var width = requiredWidth == 0 ? this._renderingCanvas.width : requiredWidth;
            var height = requiredHeight == 0 ? this._renderingCanvas.height : requiredHeight;
            var x = viewport.x;
            var y = viewport.y;
            this._cachedViewport = viewport;
            this._gl.viewport((int)(x * width), (int)(y * height), (int)(width * viewport.width), (int)(height * viewport.height));
        }
        public virtual void setDirectViewport(int x, int y, int width, int height)
        {
            this._cachedViewport = null;
            this._gl.viewport(x, y, width, height);
        }
        public virtual void beginFrame()
        {
            BABYLON.Tools._MeasureFps();
        }
        public virtual void endFrame()
        {
            this.flushFramebuffer();
        }
        public virtual void resize()
        {
            this._renderingCanvas.width = (int)(this._renderingCanvas.clientWidth / this._hardwareScalingLevel);
            this._renderingCanvas.height = (int)(this._renderingCanvas.clientHeight / this._hardwareScalingLevel);
            this._canvasClientRect = this._renderingCanvas.getBoundingClientRect();
        }
        public virtual void bindFramebuffer(WebGLTexture texture)
        {
            this._currentRenderTarget = texture;
            var gl = this._gl;
            gl.bindFramebuffer(Gl.FRAMEBUFFER, texture._framebuffer);
            this._gl.viewport(0, 0, texture._width, texture._height);
            this.wipeCaches();
        }
        public virtual void unBindFramebuffer(WebGLTexture texture)
        {
            this._currentRenderTarget = null;
            if (texture.generateMipMaps)
            {
                var gl = this._gl;
                gl.bindTexture(Gl.TEXTURE_2D, texture);
                gl.generateMipmap(Gl.TEXTURE_2D);
                gl.bindTexture(Gl.TEXTURE_2D, null);
            }
            this._gl.bindFramebuffer(Gl.FRAMEBUFFER, null);
        }
        public virtual void flushFramebuffer()
        {
            this._gl.flush();
        }
        public virtual void restoreDefaultFramebuffer()
        {
            this._gl.bindFramebuffer(Gl.FRAMEBUFFER, null);
            this.setViewport(this._cachedViewport);
            this.wipeCaches();
        }
        private void _resetVertexBufferBinding()
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, null);
            this._cachedVertexBuffers = null;
        }
        public virtual WebGLBuffer createVertexBuffer(Array<double> vertices)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ARRAY_BUFFER, ArrayConvert.AsFloat(vertices), Gl.STATIC_DRAW);
            this._resetVertexBufferBinding();
            vbo.references = 1;
            return vbo;
        }
        public virtual WebGLBuffer createDynamicVertexBuffer(int capacity)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ARRAY_BUFFER, capacity, Gl.DYNAMIC_DRAW);
            this._resetVertexBufferBinding();
            vbo.references = 1;
            return vbo;
        }
        public virtual void updateDynamicVertexBuffer(WebGLBuffer vertexBuffer, Array<double> vertices, int length = 0)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(vertices));
            this._resetVertexBufferBinding();
        }
        public virtual void updateDynamicVertexBuffer(WebGLBuffer vertexBuffer, double[] vertices, int length = 0)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(vertices));
            this._resetVertexBufferBinding();
        }
        private void _resetIndexBufferBinding()
        {
            this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, null);
            this._cachedIndexBuffer = null;
        }
        public virtual WebGLBuffer createIndexBuffer(Array<int> indices)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ELEMENT_ARRAY_BUFFER, ArrayConvert.AsUshort(indices), Gl.STATIC_DRAW);
            this._resetIndexBufferBinding();
            vbo.references = 1;
            return vbo;
        }
        public virtual void bindBuffers(WebGLBuffer vertexBuffer, WebGLBuffer indexBuffer, Array<VertexBufferKind> vertexDeclaration, int vertexStrideSize, Effect effect)
        {
            if (this._cachedVertexBuffers != vertexBuffer || this._cachedEffectForVertexBuffers != effect)
            {
                this._cachedVertexBuffers = vertexBuffer;
                this._cachedEffectForVertexBuffers = effect;
                this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer);
                var offset = 0;
                for (var index = 0; index < vertexDeclaration.Length; index++)
                {
                    var order = index;
                    if (order >= 0)
                    {
                        this._gl.vertexAttribPointer(order, (int)vertexDeclaration[index], Gl.FLOAT, false, vertexStrideSize, offset);
                    }
                    offset += (int)vertexDeclaration[index] * 4;
                }
            }
            if (this._cachedIndexBuffer != indexBuffer)
            {
                this._cachedIndexBuffer = indexBuffer;
                this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
            }
        }
        public virtual void bindMultiBuffers(Array<VertexBuffer> vertexBuffers, WebGLBuffer indexBuffer, Effect effect)
        {
            if (this._cachedVertexBuffers != vertexBuffers || this._cachedEffectForVertexBuffers != effect)
            {
                this._cachedVertexBuffers = vertexBuffers;
                this._cachedEffectForVertexBuffers = effect;
                var attributes = effect.getAttributes();
                for (var index = 0; index < attributes.Length; index++)
                {
                    var order = index;
                    if (order >= 0)
                    {
                        var vertexBuffer = vertexBuffers[(int)attributes[index]];
                        if (vertexBuffer == null)
                        {
                            continue;
                        }
                        var stride = vertexBuffer.getStrideSize();
                        this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer.getBuffer());
                        this._gl.vertexAttribPointer(order, stride, Gl.FLOAT, false, (int)stride * 4, 0);
                    }
                }
            }
            if (this._cachedIndexBuffer != indexBuffer)
            {
                this._cachedIndexBuffer = indexBuffer;
                this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
            }
        }
        public virtual bool _releaseBuffer(WebGLBuffer buffer)
        {
            buffer.references--;
            if (buffer.references == 0)
            {
                this._gl.deleteBuffer(buffer);
                return true;
            }
            return false;
        }
        public virtual WebGLBuffer createInstancesBuffer(int capacity)
        {
            var buffer = this._gl.createBuffer();
            buffer.capacity = capacity;
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, buffer);
            this._gl.bufferData(Gl.ARRAY_BUFFER, capacity, Gl.DYNAMIC_DRAW);
            return buffer;
        }
        public virtual void deleteInstancesBuffer(WebGLBuffer buffer)
        {
            this._gl.deleteBuffer(buffer);
        }
        public virtual void updateAndBindInstancesBuffer(WebGLBuffer instancesBuffer, double[] data, Array<VertexBufferKind> offsetLocations)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, instancesBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(data));
            for (var index = 0; index < 4; index++)
            {
                var offsetLocation = offsetLocations[index];
                this._gl.enableVertexAttribArray((int)offsetLocation);
                this._gl.vertexAttribPointer((int)offsetLocation, (int)VertexBufferKind.UV2Kind, Gl.FLOAT, false, 64, index * 16);
                this._caps.instancedArrays.vertexAttribDivisorANGLE((uint)offsetLocation, 1);
            }
        }
        public virtual void unBindInstancesBuffer(WebGLBuffer instancesBuffer, Array<VertexBufferKind> offsetLocations)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, instancesBuffer);
            for (var index = 0; index < 4; index++)
            {
                var offsetLocation = offsetLocations[index];
                this._gl.disableVertexAttribArray((int)offsetLocation);
                this._caps.instancedArrays.vertexAttribDivisorANGLE((uint)offsetLocation, 0);
            }
        }
        public virtual void draw(bool useTriangles, int indexStart, int indexCount, int instancesCount = 0)
        {
            if (instancesCount > 0)
            {
                this._caps.instancedArrays.drawElementsInstancedANGLE(
                    (useTriangles) ? Gl.TRIANGLES : Gl.LINES, indexCount, Gl.UNSIGNED_SHORT, new IntPtr(indexStart * 2), instancesCount);
                return;
            }
            this._gl.drawElements((useTriangles) ? Gl.TRIANGLES : Gl.LINES, indexCount, Gl.UNSIGNED_SHORT, indexStart * 2);
        }
        public virtual void _releaseEffect(Effect effect)
        {
            if (this._compiledEffects[effect._key] != null)
            {
                this._compiledEffects[effect._key] = null;
                if (effect.getProgram() != null)
                {
                    this._gl.deleteProgram(effect.getProgram());
                }
            }
        }
        public virtual Effect createEffect(EffectBaseName baseName, Array<string> attributesNames, Array<string> uniformsNames, Array<string> samplers, string defines, Array<string> optionalDefines = null, System.Action<Effect> onCompiled = null, System.Action<Effect, string> onError = null)
        {
            var vertex = baseName.vertexElement ?? baseName.vertex ?? baseName.baseName;
            var fragment = baseName.fragmentElement ?? baseName.fragment ?? baseName.baseName;
            var name = vertex + "+" + fragment + "@" + defines;
            if (this._compiledEffects[name] != null)
            {
                return this._compiledEffects[name];
            }
            var effect = new BABYLON.Effect(baseName, attributesNames, uniformsNames, samplers, this, defines, optionalDefines, onCompiled, onError);
            effect._key = name;
            this._compiledEffects[name] = effect;
            return effect;
        }
        public virtual WebGLProgram createShaderProgram(string vertexCode, string fragmentCode, string defines)
        {
            var vertexShader = compileShader(this._gl, vertexCode, "vertex", defines);
            var fragmentShader = compileShader(this._gl, fragmentCode, "fragment", defines);
            var shaderProgram = this._gl.createProgram();
            this._gl.attachShader(shaderProgram, vertexShader);
            this._gl.attachShader(shaderProgram, fragmentShader);
            this._gl.linkProgram(shaderProgram);
            var linked = this._gl.getProgramParameter(shaderProgram, Gl.LINK_STATUS);
            if (linked == null)
            {
                var error = this._gl.getProgramInfoLog(shaderProgram);
                if (error != null)
                {
                    throw new Error(error);
                }
            }
            this._gl.deleteShader(vertexShader);
            this._gl.deleteShader(fragmentShader);
            return shaderProgram;
        }
        public virtual Array<WebGLUniformLocation> getUniforms(WebGLProgram shaderProgram, Array<string> uniformsNames)
        {
            var results = new Array<WebGLUniformLocation>();
            for (var index = 0; index < uniformsNames.Length; index++)
            {
                results.push(this._gl.getUniformLocation(shaderProgram, uniformsNames[index]));
            }
            return results;
        }
        public virtual Array<VertexBufferKind> getAttributes(WebGLProgram shaderProgram, Array<string> attributesNames)
        {
            var results = new Array<VertexBufferKind>();
            for (var index = 0; index < attributesNames.Length; index++)
            {
                try
                {
                    results.push((VertexBufferKind)this._gl.getAttribLocation(shaderProgram, attributesNames[index]));
                }
                catch (Exception)
                {
                    results.push((VertexBufferKind)(-1));
                }
            }
            return results;
        }
        public virtual void enableEffect(Effect effect)
        {
            if (effect == null || effect.getAttributesCount() == 0 || this._currentEffect == effect)
            {
                return;
            }
            this._vertexAttribArrays = this._vertexAttribArrays ?? new Array<bool>();
            this._gl.useProgram(effect.getProgram());
            for (var i = 0; i < this._vertexAttribArrays.Length; i++)
            {
                if (i > Gl.VERTEX_ATTRIB_ARRAY_ENABLED || !this._vertexAttribArrays[i])
                {
                    continue;
                }
                this._vertexAttribArrays[i] = false;
                this._gl.disableVertexAttribArray(i);
            }
            var attributesCount = effect.getAttributesCount();
            for (var index = 0; index < attributesCount; index++)
            {
                var order = index;
                if (order >= 0)
                {
                    this._vertexAttribArrays[order] = true;
                    this._gl.enableVertexAttribArray(order);
                }
            }
            this._currentEffect = effect;
        }
        public virtual void setArray(WebGLUniformLocation uniform, Array<double> array)
        {
            if (uniform == null)
                return;
            this._gl.uniform1fv(uniform, ArrayConvert.AsFloat(array));
        }
        public virtual void setMatrices(WebGLUniformLocation uniform, float[] matrices)
        {
            if (uniform == null)
                return;
            this._gl.uniformMatrix4fv(uniform, false, matrices);
        }
        public virtual void setMatrix(WebGLUniformLocation uniform, Matrix matrix)
        {
            if (uniform == null)
                return;
            this._gl.uniformMatrix4fv(uniform, false, ArrayConvert.AsFloat(matrix.toArray()));
        }
        public virtual void setFloat(WebGLUniformLocation uniform, double value)
        {
            if (uniform == null)
                return;
            this._gl.uniform1f(uniform, value);
        }
        public virtual void setFloat2(WebGLUniformLocation uniform, double x, double y)
        {
            if (uniform == null)
                return;
            this._gl.uniform2f(uniform, x, y);
        }
        public virtual void setFloat3(WebGLUniformLocation uniform, double x, double y, double z)
        {
            if (uniform == null)
                return;
            this._gl.uniform3f(uniform, x, y, z);
        }
        public virtual void setBool(WebGLUniformLocation uniform, double _bool)
        {
            if (uniform == null)
                return;
            this._gl.uniform1i(uniform, _bool);
        }
        public virtual void setFloat4(WebGLUniformLocation uniform, double x, double y, double z, double w)
        {
            if (uniform == null)
                return;
            this._gl.uniform4f(uniform, x, y, z, w);
        }
        public virtual void setColor3(WebGLUniformLocation uniform, Color3 color3)
        {
            if (uniform == null)
                return;
            this._gl.uniform3f(uniform, color3.r, color3.g, color3.b);
        }
        public virtual void setColor4(WebGLUniformLocation uniform, Color3 color3, double alpha)
        {
            if (uniform == null)
                return;
            this._gl.uniform4f(uniform, color3.r, color3.g, color3.b, alpha);
        }
        public virtual void setState(bool culling)
        {
            if (this._cullingState != culling)
            {
                if (culling)
                {
                    this._gl.cullFace((this.cullBackFaces) ? Gl.BACK : Gl.FRONT);
                    this._gl.enable(Gl.CULL_FACE);
                }
                else
                {
                    this._gl.disable(Gl.CULL_FACE);
                }
                this._cullingState = culling;
            }
        }
        public virtual void setDepthBuffer(bool enable)
        {
            if (enable)
            {
                this._gl.enable(Gl.DEPTH_TEST);
            }
            else
            {
                this._gl.disable(Gl.DEPTH_TEST);
            }
        }
        public virtual void setDepthWrite(bool enable)
        {
            this._gl.depthMask(enable);
            this._depthMask = enable;
        }
        public virtual void setColorWrite(bool enable)
        {
            this._gl.colorMask(enable, enable, enable, enable);
        }
        public virtual void setAlphaMode(int mode)
        {
            switch (mode)
            {
                case BABYLON.Engine.ALPHA_DISABLE:
                    this.setDepthWrite(true);
                    this._gl.disable(Gl.BLEND);
                    break;
                case BABYLON.Engine.ALPHA_COMBINE:
                    this.setDepthWrite(false);
                    this._gl.blendFuncSeparate(Gl.SRC_ALPHA, Gl.ONE_MINUS_SRC_ALPHA, Gl.ONE, Gl.ONE);
                    this._gl.enable(Gl.BLEND);
                    break;
                case BABYLON.Engine.ALPHA_ADD:
                    this.setDepthWrite(false);
                    this._gl.blendFuncSeparate(Gl.ONE, Gl.ONE, Gl.ZERO, Gl.ONE);
                    this._gl.enable(Gl.BLEND);
                    break;
            }
        }
        public virtual void setAlphaTesting(bool enable)
        {
            this._alphaTest = enable;
        }
        public virtual bool getAlphaTesting()
        {
            return this._alphaTest;
        }
        public virtual void wipeCaches()
        {
            this._activeTexturesCache = new Array<BaseTexture>();
            this._currentEffect = null;
            this._cullingState = false;
            this._cachedVertexBuffers = null;
            this._cachedIndexBuffer = null;
            this._cachedEffectForVertexBuffers = null;
        }
        public virtual void setSamplingMode(WebGLTexture texture, double samplingMode)
        {
            var gl = this._gl;
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            var magFilter = Gl.NEAREST;
            var minFilter = Gl.NEAREST;
            if (samplingMode == BABYLON.Texture.BILINEAR_SAMPLINGMODE)
            {
                magFilter = Gl.LINEAR;
                minFilter = Gl.LINEAR;
            }
            else
                if (samplingMode == BABYLON.Texture.TRILINEAR_SAMPLINGMODE)
                {
                    magFilter = Gl.LINEAR;
                    minFilter = Gl.LINEAR_MIPMAP_LINEAR;
                }
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MAG_FILTER, magFilter);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MIN_FILTER, minFilter);
            gl.bindTexture(Gl.TEXTURE_2D, null);
        }
        public virtual WebGLTexture createTexture(string url, bool noMipmap, bool invertY, Scene scene, int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
        {
            var texture = this._gl.createTexture();
            var extension = url.Substring(url.Length - 4, 4).ToLower();
            var isDDS = this.getCaps().s3tc != null && (extension == ".dds");
            var isTGA = (extension == ".tga");
            scene._addPendingData(texture);
            texture.url = url;
            texture.noMipmap = noMipmap;
            texture.references = 1;
            this._loadedTexturesCache.push(texture);
            if (isTGA)
            {
                BABYLON.Tools.LoadFile(url, (arrayBuffer) =>
                {
                    var data = arrayBuffer;
                    var header = BABYLON.Internals.TGATools.GetTGAHeader(data);
                    prepareWebGLTexture(texture, this._gl, scene, header.width, header.height, invertY, noMipmap, false, (pos, max) =>
                    {
                        Internals.TGATools.UploadContent(this._gl, data);
                    }, samplingMode);
                }, null, scene.database, true);
            }
            else
                if (isDDS)
                {
                    BABYLON.Tools.LoadFile(url, (data) =>
                    {
                        var info = BABYLON.Internals.DDSTools.GetDDSInfo(data);
                        var loadMipmap = (info.isRGB || info.isLuminance || info.mipmapCount > 1) && !noMipmap && ((info.width << (info.mipmapCount - 1)) == 1);
                        prepareWebGLTexture(texture, this._gl, scene, info.width, info.height, invertY, !loadMipmap, info.isFourCC, (pos, max) =>
                        {
                            console.log("loading " + url);
                            Internals.DDSTools.UploadDDSLevels(this._gl, this.getCaps().s3tc, data, info, loadMipmap, 1);
                        }, samplingMode);
                    }, null, scene.database, true);
                }
                else
                {
                    Action<HTMLImageElement> onload = (img) =>
                    {
                        prepareWebGLTexture(texture, this._gl, scene, img.width, img.height, invertY, noMipmap, false, (int potWidth, int potHeight) =>
                        {
                            var isPot = (img.width == potWidth && img.height == potHeight);
                            if (!isPot)
                            {
                                this._workingCanvas.width = potWidth;
                                this._workingCanvas.height = potHeight;
                                this._workingContext.drawImage(img, 0, 0, img.width, img.height, 0, 0, potWidth, potHeight);
                            }

                            if (isPot)
                            {
                                this._gl.texImage2D(
                                    Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, img);
                            }
                            else
                            {
                                this._gl.texImage2D(
                                    Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, this._workingCanvas);
                            }
                        }, samplingMode);
                    };
                    Action<HTMLImageElement, object> onerror = (img, err) =>
                    {
                        scene._removePendingData(texture);
                    };
                    BABYLON.Tools.LoadImage(url, onload, onerror, scene.database);
                }
            return texture;
        }
        public virtual WebGLTexture createDynamicTexture(int width, int height, bool generateMipMaps, int samplingMode)
        {
            var texture = this._gl.createTexture();
            width = getExponantOfTwo(width, this._caps.maxTextureSize);
            height = getExponantOfTwo(height, this._caps.maxTextureSize);
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            var filters = getSamplingParameters(samplingMode, generateMipMaps, this._gl);
            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MAG_FILTER, filters.mag);
            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MIN_FILTER, filters.min);
            this._gl.bindTexture(Gl.TEXTURE_2D, null);
            this._activeTexturesCache = new Array<BaseTexture>();
            texture._baseWidth = width;
            texture._baseHeight = height;
            texture._width = width;
            texture._height = height;
            texture.isReady = false;
            texture.generateMipMaps = generateMipMaps;
            texture.references = 1;
            this._loadedTexturesCache.push(texture);
            return texture;
        }
        public virtual void updateDynamicTexture(WebGLTexture texture, HTMLCanvasElement canvas, bool invertY)
        {
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, (invertY) ? 1 : 0);
            this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, canvas);
            if (texture.generateMipMaps)
            {
                this._gl.generateMipmap(Gl.TEXTURE_2D);
            }
            this._gl.bindTexture(Gl.TEXTURE_2D, null);
            this._activeTexturesCache = new Array<BaseTexture>();
            texture.isReady = true;
        }
        public virtual void updateVideoTexture(WebGLTexture texture, HTMLVideoElement video, bool invertY)
        {
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, (invertY) ? 0 : 1);
            if (video.videoWidth != texture._width || video.videoHeight != texture._height)
            {
                if (texture._workingCanvas == null)
                {
                    texture._workingCanvas = (HTMLCanvasElement)document.createElement("canvas");
                    texture._workingContext = (CanvasRenderingContext2D)texture._workingCanvas.getContext("2d");
                    texture._workingCanvas.width = texture._width;
                    texture._workingCanvas.height = texture._height;
                }
                texture._workingContext.drawImage(video, 0, 0, video.videoWidth, video.videoHeight, 0, 0, texture._width, texture._height);
                this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, texture._workingCanvas);
            }
            else
            {
                this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, video);
            }
            if (texture.generateMipMaps)
            {
                this._gl.generateMipmap(Gl.TEXTURE_2D);
            }
            this._gl.bindTexture(Gl.TEXTURE_2D, null);
            this._activeTexturesCache = new Array<BaseTexture>();
            texture.isReady = true;
        }
        public virtual WebGLTexture createRenderTargetTexture(Size size, bool generateMipMaps = false, bool generateDepthBuffer = false, int samplingMode = BABYLON.Texture.TRILINEAR_SAMPLINGMODE)
        {
            var gl = this._gl;
            var texture = gl.createTexture();
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            var width = size.width;
            var height = size.height;
            var filters = getSamplingParameters(samplingMode, generateMipMaps, gl);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MAG_FILTER, filters.mag);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MIN_FILTER, filters.min);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
            gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, width, height, 0, Gl.RGBA, Gl.UNSIGNED_BYTE, null);
            WebGLRenderbuffer depthBuffer = null;
            if (generateDepthBuffer)
            {
                depthBuffer = gl.createRenderbuffer();
                gl.bindRenderbuffer(Gl.RENDERBUFFER, depthBuffer);
                gl.renderbufferStorage(Gl.RENDERBUFFER, Gl.DEPTH_COMPONENT16, width, height);
            }
            var framebuffer = gl.createFramebuffer();
            gl.bindFramebuffer(Gl.FRAMEBUFFER, framebuffer);
            gl.framebufferTexture2D(Gl.FRAMEBUFFER, Gl.COLOR_ATTACHMENT0, Gl.TEXTURE_2D, texture, 0);
            if (generateDepthBuffer)
            {
                gl.framebufferRenderbuffer(Gl.FRAMEBUFFER, Gl.DEPTH_ATTACHMENT, Gl.RENDERBUFFER, depthBuffer);
            }
            gl.bindTexture(Gl.TEXTURE_2D, null);
            gl.bindRenderbuffer(Gl.RENDERBUFFER, null);
            gl.bindFramebuffer(Gl.FRAMEBUFFER, null);
            texture._framebuffer = framebuffer;
            if (generateDepthBuffer)
            {
                texture._depthBuffer = depthBuffer;
            }
            texture._width = width;
            texture._height = height;
            texture.isReady = true;
            texture.generateMipMaps = generateMipMaps;
            texture.references = 1;
            this._activeTexturesCache = new Array<BaseTexture>();
            this._loadedTexturesCache.push(texture);
            return texture;
        }
        public virtual WebGLTexture createCubeTexture(string rootUrl, Scene scene, Array<string> extensions, bool noMipmap = false)
        {
            var gl = this._gl;
            var texture = gl.createTexture();
            texture.isCube = true;
            texture.url = rootUrl;
            texture.references = 1;
            this._loadedTexturesCache.push(texture);
            var extension = rootUrl.Substring(rootUrl.Length - 4, 4).ToLower();
            var isDDS = this.getCaps().s3tc != null && (extension == ".dds");
            if (isDDS)
            {
                BABYLON.Tools.LoadFile(rootUrl, (data) =>
                {
                    var info = BABYLON.Internals.DDSTools.GetDDSInfo(data);
                    var loadMipmap = (info.isRGB || info.isLuminance || info.mipmapCount > 1) && !noMipmap;
                    gl.bindTexture(Gl.TEXTURE_CUBE_MAP, texture);
                    gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, 1);
                    Internals.DDSTools.UploadDDSLevels(this._gl, this.getCaps().s3tc, data, info, loadMipmap, 6);
                    if (!noMipmap && !info.isFourCC && info.mipmapCount == 1)
                    {
                        gl.generateMipmap(Gl.TEXTURE_CUBE_MAP);
                    }
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MAG_FILTER, Gl.LINEAR);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MIN_FILTER, (loadMipmap) ? Gl.LINEAR_MIPMAP_LINEAR : Gl.LINEAR);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
                    gl.bindTexture(Gl.TEXTURE_CUBE_MAP, null);
                    this._activeTexturesCache = new Array<BaseTexture>();
                    texture._width = info.width;
                    texture._height = info.height;
                    texture.isReady = true;
                });
            }
            else
            {
                cascadeLoad(rootUrl, 0, new Array<HTMLImageElement>(), scene, (imgs) =>
                {
                    var width = getExponantOfTwo(imgs[0].width, this._caps.maxCubemapTextureSize);
                    var height = width;
                    this._workingCanvas.width = width;
                    this._workingCanvas.height = height;
                    var faces = new Array<int>(Gl.TEXTURE_CUBE_MAP_POSITIVE_X, Gl.TEXTURE_CUBE_MAP_POSITIVE_Y, Gl.TEXTURE_CUBE_MAP_POSITIVE_Z, Gl.TEXTURE_CUBE_MAP_NEGATIVE_X, Gl.TEXTURE_CUBE_MAP_NEGATIVE_Y, Gl.TEXTURE_CUBE_MAP_NEGATIVE_Z);
                    gl.bindTexture(Gl.TEXTURE_CUBE_MAP, texture);
                    gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, 0);
                    for (var index = 0; index < faces.Length; index++)
                    {
                        this._workingContext.drawImage(imgs[index], 0, 0, imgs[index].width, imgs[index].height, 0, 0, width, height);
                        gl.texImage2D(faces[index], 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, this._workingCanvas);
                    }
                    if (!noMipmap)
                    {
                        gl.generateMipmap(Gl.TEXTURE_CUBE_MAP);
                    }
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MAG_FILTER, Gl.LINEAR);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MIN_FILTER, (noMipmap) ? Gl.LINEAR : Gl.LINEAR_MIPMAP_LINEAR);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
                    gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
                    gl.bindTexture(Gl.TEXTURE_CUBE_MAP, null);
                    this._activeTexturesCache = new Array<BaseTexture>();
                    texture._width = width;
                    texture._height = height;
                    texture.isReady = true;
                }, extensions);
            }
            return texture;
        }
        public virtual void _releaseTexture(WebGLTexture texture)
        {
            var gl = this._gl;
            if (texture._framebuffer != null)
            {
                gl.deleteFramebuffer(texture._framebuffer);
            }
            if (texture._depthBuffer != null)
            {
                gl.deleteRenderbuffer(texture._depthBuffer);
            }
            gl.deleteTexture(texture);
            for (var channel = 0; channel < this._caps.maxTexturesImageUnits; channel++)
            {
                this._gl.activeTexture(this._gl["TEXTURE" + channel]);
                this._gl.bindTexture(Gl.TEXTURE_2D, null);
                this._gl.bindTexture(Gl.TEXTURE_CUBE_MAP, null);
                this._activeTexturesCache[channel] = null;
            }
            var index = this._loadedTexturesCache.indexOf(texture);
            if (index != -1)
            {
                this._loadedTexturesCache.RemoveAt(index);
            }
        }
        public virtual void bindSamplers(Effect effect)
        {
            this._gl.useProgram(effect.getProgram());
            var samplers = effect.getSamplers();
            for (var index = 0; index < samplers.Length; index++)
            {
                var uniform = effect.getUniform(samplers[index]);
                this._gl.uniform1i(uniform, index);
            }
            this._currentEffect = null;
        }
        public virtual void _bindTexture(int channel, WebGLTexture texture)
        {
            this._gl.activeTexture(this._gl["TEXTURE" + channel]);
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._activeTexturesCache[channel] = null;
        }
        public virtual void setTextureFromPostProcess(int channel, PostProcess postProcess)
        {
            this._bindTexture(channel, postProcess._textures[postProcess._currentRenderTextureInd]);
        }
        public virtual void setTexture(int channel, BaseTexture texture)
        {
            if (channel < 0)
            {
                return;
            }
            if (texture == null || !texture.isReady())
            {
                if (this._activeTexturesCache[channel] != null)
                {
                    this._gl.activeTexture(this._gl["TEXTURE" + channel]);
                    this._gl.bindTexture(Gl.TEXTURE_2D, null);
                    this._gl.bindTexture(Gl.TEXTURE_CUBE_MAP, null);
                    this._activeTexturesCache[channel] = null;
                }
                return;
            }
            if (texture is BABYLON.VideoTexture)
            {
                if (((VideoTexture)texture).update())
                {
                    this._activeTexturesCache[channel] = null;
                }
            }
            else
                if (texture.delayLoadState == BABYLON.Engine.DELAYLOADSTATE_NOTLOADED)
                {
                    texture.delayLoad();
                    return;
                }
            if (this._activeTexturesCache[channel] == texture)
            {
                return;
            }
            this._activeTexturesCache[channel] = texture;
            var internalTexture = texture.getInternalTexture();
            this._gl.activeTexture(this._gl["TEXTURE" + channel]);
            if (internalTexture.isCube)
            {
                this._gl.bindTexture(Gl.TEXTURE_CUBE_MAP, internalTexture);
                if (internalTexture._cachedCoordinatesMode != texture.coordinatesMode)
                {
                    internalTexture._cachedCoordinatesMode = texture.coordinatesMode;
                    var textureWrapMode = ((texture.coordinatesMode != BABYLON.Texture.CUBIC_MODE && texture.coordinatesMode != BABYLON.Texture.SKYBOX_MODE)) ? Gl.REPEAT : Gl.CLAMP_TO_EDGE;
                    this._gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_S, textureWrapMode);
                    this._gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_T, textureWrapMode);
                }
                this._setAnisotropicLevel(Gl.TEXTURE_CUBE_MAP, texture);
            }
            else
            {
                this._gl.bindTexture(Gl.TEXTURE_2D, internalTexture);
                if (internalTexture._cachedWrapU != texture.wrapU)
                {
                    internalTexture._cachedWrapU = texture.wrapU;
                    switch (texture.wrapU)
                    {
                        case BABYLON.Texture.WRAP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.REPEAT);
                            break;
                        case BABYLON.Texture.CLAMP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
                            break;
                        case BABYLON.Texture.MIRROR_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.MIRRORED_REPEAT);
                            break;
                    }
                }
                if (internalTexture._cachedWrapV != texture.wrapV)
                {
                    internalTexture._cachedWrapV = texture.wrapV;
                    switch (texture.wrapV)
                    {
                        case BABYLON.Texture.WRAP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.REPEAT);
                            break;
                        case BABYLON.Texture.CLAMP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
                            break;
                        case BABYLON.Texture.MIRROR_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.MIRRORED_REPEAT);
                            break;
                    }
                }
                this._setAnisotropicLevel(Gl.TEXTURE_2D, texture);
            }
        }
        public virtual void _setAnisotropicLevel(int key, BaseTexture texture)
        {
            var anisotropicFilterExtension = this._caps.textureAnisotropicFilterExtension;
            if (anisotropicFilterExtension != null && texture._cachedAnisotropicFilteringLevel != texture.anisotropicFilteringLevel)
            {
                this._gl.texParameterf(key, Gl.TEXTURE_MAX_ANISOTROPY_EXT, Math.Min(texture.anisotropicFilteringLevel, this._caps.maxAnisotropy));
                texture._cachedAnisotropicFilteringLevel = texture.anisotropicFilteringLevel;
            }
        }
        public virtual byte[] readPixels(int x, int y, int width, int height)
        {
            var data = new byte[height * width * 4];
            this._gl.readPixels(0, 0, width, height, Gl.RGBA, Gl.UNSIGNED_BYTE, data);
            return data;
        }
        public virtual void dispose()
        {
            this.stopRenderLoop();
            while (this.scenes.Length > 0)
            {
                this.scenes[0].dispose();
            }
            foreach (var effect in this._compiledEffects.Values)
            {
                this._gl.deleteProgram(effect._program);
            }
            for (var i = 0; i < this._vertexAttribArrays.Length; i++)
            {
                if (i > Gl.VERTEX_ATTRIB_ARRAY_ENABLED || !this._vertexAttribArrays[i])
                {
                    continue;
                }
                this._gl.disableVertexAttribArray(i);
            }
            window.removeEventListener("blur", this._onBlur);
            window.removeEventListener("focus", this._onFocus);
            document.removeEventListener("fullscreenchange", this._onFullscreenChange);
            document.removeEventListener("mozfullscreenchange", this._onFullscreenChange);
            document.removeEventListener("webkitfullscreenchange", this._onFullscreenChange);
            document.removeEventListener("msfullscreenchange", this._onFullscreenChange);
            document.removeEventListener("pointerlockchange", this._onPointerLockChange);
            document.removeEventListener("mspointerlockchange", this._onPointerLockChange);
            document.removeEventListener("mozpointerlockchange", this._onPointerLockChange);
            document.removeEventListener("webkitpointerlockchange", this._onPointerLockChange);
        }
        public static bool isSupported()
        {
            return true;
        }
    }
}