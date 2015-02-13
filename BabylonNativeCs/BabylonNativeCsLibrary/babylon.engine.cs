// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.engine.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    using BABYLON.Internals;

    using BabylonNativeCsLibrary;

    using Web;

    /// <summary>
    /// </summary>
    public partial class EngineCapabilities
    {
        /// <summary>
        /// </summary>
        public ANGLE_instanced_arrays instancedArrays;

        /// <summary>
        /// </summary>
        public int maxAnisotropy;

        /// <summary>
        /// </summary>
        public int maxCubemapTextureSize;

        /// <summary>
        /// </summary>
        public int maxRenderTextureSize;

        /// <summary>
        /// </summary>
        public int maxTextureSize;

        /// <summary>
        /// </summary>
        public int maxTexturesImageUnits;

        /// <summary>
        /// </summary>
        public WEBGL_compressed_texture_s3tc s3tc;

        /// <summary>
        /// </summary>
        public bool standardDerivatives;

        /// <summary>
        /// </summary>
        public EXT_texture_filter_anisotropic textureAnisotropicFilterExtension;

        /// <summary>
        /// </summary>
        public bool textureFloat;
    }

    /// <summary>
    /// </summary>
    public partial class Engine
    {
        /// <summary>
        /// </summary>
        public static double CollisionsEpsilon = 0.001;

        /// <summary>
        /// </summary>
        public static double Epsilon = 0.001;

        /// <summary>
        /// </summary>
        public static string ShadersRepository = "Babylon/Shaders/";

        /// <summary>
        /// </summary>
        public static Web.Console console;

        /// <summary>
        /// </summary>
        public static HTMLDocument document;

        /// <summary>
        /// </summary>
        public static Window window;

        /// <summary>
        /// </summary>
        public Array<BaseTexture> _activeTexturesCache = new Array<BaseTexture>();

        /// <summary>
        /// </summary>
        public bool cullBackFaces = true;

        /// <summary>
        /// </summary>
        public bool forceWireframe = false;

        /// <summary>
        /// </summary>
        public bool isFullscreen = false;

        /// <summary>
        /// </summary>
        public bool isPointerLock = false;

        /// <summary>
        /// </summary>
        public bool renderEvenInBackground = true;

        /// <summary>
        /// </summary>
        public Array<Scene> scenes = new Array<Scene>();

        /// <summary>
        /// </summary>
        internal readonly WebGLRenderingContext _gl;

        /// <summary>
        /// </summary>
        internal HTMLCanvasElement _canvas;

        /// <summary>
        /// </summary>
        private bool _alphaTest;

        /// <summary>
        /// </summary>
        private Effect _cachedEffectForVertexBuffers;

        /// <summary>
        /// </summary>
        private WebGLBuffer _cachedIndexBuffer;

        /// <summary>
        /// </summary>
        private object _cachedVertexBuffers;

        /// <summary>
        /// </summary>
        private Viewport _cachedViewport;

        /// <summary>
        /// </summary>
        private ClientRect _canvasClientRect;

        /// <summary>
        /// </summary>
        private readonly EngineCapabilities _caps;

        /// <summary>
        /// </summary>
        private readonly Map<string, Effect> _compiledEffects = new Map<string, Effect>();

        /// <summary>
        /// </summary>
        private bool _cullingState;

        /// <summary>
        /// </summary>
        private Effect _currentEffect;

        /// <summary>
        /// </summary>
        private WebGLTexture _currentRenderTarget;

        /// <summary>
        /// </summary>
        private bool _depthMask;

        /// <summary>
        /// </summary>
        private double _hardwareScalingLevel;

        /// <summary>
        /// </summary>
        private readonly Array<WebGLTexture> _loadedTexturesCache = new Array<WebGLTexture>();

        /// <summary>
        /// </summary>
        private readonly EventListener _onBlur;

        /// <summary>
        /// </summary>
        private readonly EventListener _onFocus;

        /// <summary>
        /// </summary>
        private readonly EventListener _onFullscreenChange;

        /// <summary>
        /// </summary>
        private readonly EventListener _onPointerLockChange;

        /// <summary>
        /// </summary>
        private bool _pointerLockRequested;

        /// <summary>
        /// </summary>
        private System.Action _renderFunction;

        /// <summary>
        /// </summary>
        private readonly HTMLCanvasElement _renderingCanvas;

        /// <summary>
        /// </summary>
        private bool _runningLoop;

        /// <summary>
        /// </summary>
        private Array<bool> _vertexAttribArrays;

        /// <summary>
        /// </summary>
        private bool _windowIsBackground;

        /// <summary>
        /// </summary>
        private readonly HTMLCanvasElement _workingCanvas;

        /// <summary>
        /// </summary>
        private readonly CanvasRenderingContext2D _workingContext;

        /// <summary>
        /// </summary>
        /// <param name="canvas">
        /// </param>
        /// <param name="antialias">
        /// </param>
        /// <param name="engineOptions">
        /// </param>
        /// <exception cref="Error">
        /// </exception>
        public Engine(HTMLCanvasElement canvas, bool antialias = false, EngineOptions engineOptions = null)
        {
            document = canvas.document as HTMLDocument;
            window = document.parentWindow;
            console = window.console;
            Tools.navigator = window.navigator;
            _canvas = canvas;

            Tools.Log("Engine ctor()");

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

            this._onBlur = (e) => { this._windowIsBackground = true; };
            this._onFocus = (e) => { this._windowIsBackground = false; };
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
            this._caps.standardDerivatives = this._gl.getExtension("OES_standard_derivatives") != null;
            this._caps.s3tc = (WEBGL_compressed_texture_s3tc)this._gl.getExtension("WEBGL_compressed_texture_s3tc");
            this._caps.textureFloat = this._gl.getExtension("OES_texture_float") != null;
            this._caps.textureAnisotropicFilterExtension = (EXT_texture_filter_anisotropic)this._gl.getExtension("EXT_texture_filter_anisotropic");
            this._caps.maxAnisotropy =
                (int)((this._caps.textureAnisotropicFilterExtension != null) ? this._gl.getParameter(Gl.MAX_TEXTURE_MAX_ANISOTROPY_EXT) : 0);
            this._caps.instancedArrays = (ANGLE_instanced_arrays)this._gl.getExtension("ANGLE_instanced_arrays");
            this.setDepthBuffer(true);
            this.setDepthFunctionToLessOrEqual();
            this.setDepthWrite(true);
            this._onFullscreenChange = (e) =>
                {
                    ////if (document.fullscreen != null)
                    ////{
                    ////    this.isFullscreen = document.fullscreen;
                    ////}
                    ////if (this.isFullscreen && this._pointerLockRequested)
                    ////{
                    ////    canvas.requestPointerLock = canvas.requestPointerLock;
                    ////    if (canvas.requestPointerLock)
                    ////    {
                    ////        canvas.requestPointerLock();
                    ////    }
                    ////}
                };
            document.addEventListener("fullscreenchange", this._onFullscreenChange, false);
            this._onPointerLockChange = (e) =>
                {
                    ////this.isPointerLock = document.pointerLockElement == canvas;
                };
            document.addEventListener("pointerlockchange", this._onPointerLockChange, false);
        }

        /// <summary>
        /// </summary>
        public static string Version
        {
            get
            {
                return "1.13.0";
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static bool isSupported()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="texture">
        /// </param>
        public virtual void _bindTexture(int channel, WebGLTexture texture)
        {
            this._gl.activeTexture(this._gl["TEXTURE" + channel]);
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._activeTexturesCache[channel] = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="buffer">
        /// </param>
        /// <returns>
        /// </returns>
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

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
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

            var index = this._loadedTexturesCache.IndexOf(texture);
            if (index != -1)
            {
                this._loadedTexturesCache.RemoveAt(index);
            }
        }

        /// <summary>
        /// </summary>
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
                Tools.QueueNewFrame((time) => { this._renderLoop(); });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="texture">
        /// </param>
        public virtual void _setAnisotropicLevel(int key, BaseTexture texture)
        {
            var anisotropicFilterExtension = this._caps.textureAnisotropicFilterExtension;
            if (anisotropicFilterExtension != null && texture._cachedAnisotropicFilteringLevel != texture.anisotropicFilteringLevel)
            {
                this._gl.texParameterf(key, Gl.TEXTURE_MAX_ANISOTROPY_EXT, Math.Min(texture.anisotropicFilteringLevel, this._caps.maxAnisotropy));
                texture._cachedAnisotropicFilteringLevel = texture.anisotropicFilteringLevel;
            }
        }

        /// <summary>
        /// </summary>
        public virtual void beginFrame()
        {
            Tools._MeasureFps();
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexBuffer">
        /// </param>
        /// <param name="indexBuffer">
        /// </param>
        /// <param name="vertexDeclaration">
        /// </param>
        /// <param name="vertexStrideSize">
        /// </param>
        /// <param name="effect">
        /// </param>
        public virtual void bindBuffers(
            WebGLBuffer vertexBuffer, WebGLBuffer indexBuffer, Array<VertexBufferKind> vertexDeclaration, int vertexStrideSize, Effect effect)
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

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
        public virtual void bindFramebuffer(WebGLTexture texture)
        {
            this._currentRenderTarget = texture;
            var gl = this._gl;
            gl.bindFramebuffer(Gl.FRAMEBUFFER, texture._framebuffer);
            this._gl.viewport(0, 0, texture._width, texture._height);
            this.wipeCaches();
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexBuffers">
        /// </param>
        /// <param name="indexBuffer">
        /// </param>
        /// <param name="effect">
        /// </param>
        public virtual void bindMultiBuffers(Array<VertexBuffer> vertexBuffers, WebGLBuffer indexBuffer, Effect effect)
        {
            if (this._cachedVertexBuffers != vertexBuffers || this._cachedEffectForVertexBuffers != effect)
            {
                this._cachedVertexBuffers = vertexBuffers;
                this._cachedEffectForVertexBuffers = effect;
                var attributeLocations = effect.getAttributeLocations();
                for (var index = 0; index < attributeLocations.Length; index++)
                {
                    var order = attributeLocations[index];
                    if (order >= 0)
                    {
                        var vertexBuffer = vertexBuffers[order];
                        if (vertexBuffer == null)
                        {
                            continue;
                        }

                        var stride = vertexBuffer.getStrideSize();
                        this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer.getBuffer());
                        this._gl.vertexAttribPointer(order, stride, Gl.FLOAT, false, stride * 4, 0);
                    }
                }
            }

            if (this._cachedIndexBuffer != indexBuffer)
            {
                this._cachedIndexBuffer = indexBuffer;
                this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="color">
        /// </param>
        /// <param name="backBuffer">
        /// </param>
        /// <param name="depthStencil">
        /// </param>
        public virtual void clear(Color3 color, bool backBuffer, bool depthStencil)
        {
            this._gl.clearColor(color.r, color.g, color.b, 1.0);
            if (this._depthMask)
            {
                this._gl.clearDepth(1.0);
            }

            var mode = 0;
            if (backBuffer)
            {
                mode |= Gl.COLOR_BUFFER_BIT;
            }

            if (depthStencil && this._depthMask)
            {
                mode |= Gl.DEPTH_BUFFER_BIT;
            }

            this._gl.clear(mode);
        }

        /// <summary>
        /// </summary>
        /// <param name="color">
        /// </param>
        /// <param name="backBuffer">
        /// </param>
        /// <param name="depthStencil">
        /// </param>
        public virtual void clear(Color4 color, bool backBuffer, bool depthStencil)
        {
            this._gl.clearColor(color.r, color.g, color.b, color.a);
            if (this._depthMask)
            {
                this._gl.clearDepth(1.0);
            }

            var mode = 0;
            if (backBuffer)
            {
                mode |= Gl.COLOR_BUFFER_BIT;
            }

            if (depthStencil && this._depthMask)
            {
                mode |= Gl.DEPTH_BUFFER_BIT;
            }

            this._gl.clear(mode);
        }

        /// <summary>
        /// </summary>
        /// <param name="rootUrl">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="extensions">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLTexture createCubeTexture(string rootUrl, Scene scene, Array<string> extensions, bool noMipmap = false)
        {
            var gl = this._gl;
            var texture = gl.createTexture();
            texture.isCube = true;
            texture.url = rootUrl;
            texture.references = 1;
            this._loadedTexturesCache.Add(texture);
            var extension = rootUrl.Substring(rootUrl.Length - 4, 4).ToLower();
            var isDDS = this.getCaps().s3tc != null && (extension == ".dds");
            if (isDDS)
            {
                Tools.LoadFile(
                    rootUrl,
                    (data) =>
                    {
                        var info = DDSTools.GetDDSInfo(data);
                        var loadMipmap = (info.isRGB || info.isLuminance || info.mipmapCount > 1) && !noMipmap;
                        gl.bindTexture(Gl.TEXTURE_CUBE_MAP, texture);
                        gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, 1);
                        DDSTools.UploadDDSLevels(this._gl, this.getCaps().s3tc, data, info, loadMipmap, 6);
                        if (!noMipmap && !info.isFourCC && info.mipmapCount == 1)
                        {
                            gl.generateMipmap(Gl.TEXTURE_CUBE_MAP);
                        }

                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MAG_FILTER, Gl.LINEAR);
                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MIN_FILTER, loadMipmap ? Gl.LINEAR_MIPMAP_LINEAR : Gl.LINEAR);
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
                this.cascadeLoad(
                    rootUrl,
                    0,
                    new Array<Web.ImageData>(),
                    scene,
                    (imgs) =>
                    {
                        var width = this.getExponantOfTwo(imgs[0].width, this._caps.maxCubemapTextureSize);
                        var height = width;
                        this._workingCanvas.width = width;
                        this._workingCanvas.height = height;
                        var faces = new Array<int>(
                            Gl.TEXTURE_CUBE_MAP_POSITIVE_X,
                            Gl.TEXTURE_CUBE_MAP_POSITIVE_Y,
                            Gl.TEXTURE_CUBE_MAP_POSITIVE_Z,
                            Gl.TEXTURE_CUBE_MAP_NEGATIVE_X,
                            Gl.TEXTURE_CUBE_MAP_NEGATIVE_Y,
                            Gl.TEXTURE_CUBE_MAP_NEGATIVE_Z);
                        gl.bindTexture(Gl.TEXTURE_CUBE_MAP, texture);
                        //gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, 0);
                        for (var index = 0; index < faces.Length; index++)
                        {
                            //this._workingContext.drawImage(imgs[index], 0, 0, imgs[index].width, imgs[index].height, 0, 0, width, height);
                            //gl.texImage2D(faces[index], 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, this._workingCanvas);
                            gl.texImage2D(faces[index], 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, imgs[index]);
                        }

                        if (!noMipmap)
                        {
                            gl.generateMipmap(Gl.TEXTURE_CUBE_MAP);
                        }

                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MAG_FILTER, Gl.LINEAR);
                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_MIN_FILTER, noMipmap ? Gl.LINEAR : Gl.LINEAR_MIPMAP_LINEAR);
                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
                        gl.texParameteri(Gl.TEXTURE_CUBE_MAP, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
                        gl.bindTexture(Gl.TEXTURE_CUBE_MAP, null);
                        this._activeTexturesCache = new Array<BaseTexture>();
                        texture._width = width;
                        texture._height = height;
                        texture.isReady = true;
                    },
                    extensions);
            }

            return texture;
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLTexture createDynamicTexture(int width, int height, bool generateMipMaps, int samplingMode)
        {
            var texture = this._gl.createTexture();
            width = this.getExponantOfTwo(width, this._caps.maxTextureSize);
            height = this.getExponantOfTwo(height, this._caps.maxTextureSize);
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            var filters = this.getSamplingParameters(samplingMode, generateMipMaps, this._gl);
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
            this._loadedTexturesCache.Add(texture);
            return texture;
        }

        /// <summary>
        /// </summary>
        /// <param name="capacity">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer createDynamicVertexBuffer(int capacity)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ARRAY_BUFFER, capacity, Gl.DYNAMIC_DRAW);
            this._resetVertexBufferBinding();
            vbo.references = 1;
            return vbo;
        }

        /// <summary>
        /// </summary>
        /// <param name="baseName">
        /// </param>
        /// <param name="attributesNames">
        /// </param>
        /// <param name="uniformsNames">
        /// </param>
        /// <param name="samplers">
        /// </param>
        /// <param name="defines">
        /// </param>
        /// <param name="optionalDefines">
        /// </param>
        /// <param name="onCompiled">
        /// </param>
        /// <param name="onError">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Effect createEffect(
            EffectBaseName baseName,
            Array<string> attributesNames,
            Array<string> uniformsNames,
            Array<string> samplers,
            string defines,
            Array<string> optionalDefines = null,
            Action<Effect> onCompiled = null,
            Action<Effect, string> onError = null)
        {
            var vertex = baseName.vertexElement ?? baseName.vertex ?? baseName.baseName;
            var fragment = baseName.fragmentElement ?? baseName.fragment ?? baseName.baseName;
            var name = vertex + "+" + fragment + "@" + defines;
            if (this._compiledEffects[name] != null)
            {
                return this._compiledEffects[name];
            }

            var effect = new Effect(baseName, attributesNames, uniformsNames, samplers, this, defines, optionalDefines, onCompiled, onError);
            effect._key = name;
            this._compiledEffects[name] = effect;
            return effect;
        }

        /// <summary>
        /// </summary>
        /// <param name="indices">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer createIndexBuffer(Array<int> indices)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ELEMENT_ARRAY_BUFFER, ArrayConvert.AsUshort(indices), Gl.STATIC_DRAW);
            this._resetIndexBufferBinding();
            vbo.references = 1;
            return vbo;
        }

        /// <summary>
        /// </summary>
        /// <param name="capacity">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer createInstancesBuffer(int capacity)
        {
            var buffer = this._gl.createBuffer();
            buffer.capacity = capacity;
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, buffer);
            this._gl.bufferData(Gl.ARRAY_BUFFER, capacity, Gl.DYNAMIC_DRAW);
            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="size">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="generateDepthBuffer">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLTexture createRenderTargetTexture(
            Size size, bool generateMipMaps = false, bool generateDepthBuffer = false, int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
        {
            var gl = this._gl;
            var texture = gl.createTexture();
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            var width = size.width;
            var height = size.height;
            var filters = this.getSamplingParameters(samplingMode, generateMipMaps, gl);
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
            this._loadedTexturesCache.Add(texture);
            return texture;
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexCode">
        /// </param>
        /// <param name="fragmentCode">
        /// </param>
        /// <param name="defines">
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Error">
        /// </exception>
        public virtual WebGLProgram createShaderProgram(string vertexCode, string fragmentCode, string defines)
        {
            var vertexShader = this.compileShader(this._gl, vertexCode, "vertex", defines);
            var fragmentShader = this.compileShader(this._gl, fragmentCode, "fragment", defines);
            var shaderProgram = this._gl.createProgram();
            this._gl.attachShader(shaderProgram, vertexShader);
            this._gl.attachShader(shaderProgram, fragmentShader);
            this._gl.linkProgram(shaderProgram);
            var linked = this._gl.getProgramParameter(shaderProgram, Gl.LINK_STATUS);
            if ((int)linked != Gl.TRUE)
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

        /// <summary>
        /// </summary>
        /// <param name="url">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        /// <param name="invertY">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLTexture createTexture(string url, bool noMipmap, bool invertY, Scene scene, int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
        {
            var texture = this._gl.createTexture();
            var extension = url.Substring(url.Length - 4, 4).ToLower();
            var isDDS = this.getCaps().s3tc != null && (extension == ".dds");
            var isTGA = extension == ".tga";
            scene._addPendingData(texture);
            texture.url = url;
            texture.noMipmap = noMipmap;
            texture.references = 1;
            this._loadedTexturesCache.Add(texture);
            if (isTGA)
            {
                Tools.LoadFile(
                    url,
                    (arrayBuffer) =>
                    {
                        var data = arrayBuffer;
                        var header = TGATools.GetTGAHeader(data);
                        this.prepareWebGLTexture(
                            texture,
                            this._gl,
                            scene,
                            header.width,
                            header.height,
                            invertY,
                            noMipmap,
                            false,
                            (pos, max) => { TGATools.UploadContent(this._gl, data); },
                            samplingMode);
                    },
                    null,
                    scene.database,
                    true);
            }
            else if (isDDS)
            {
                Tools.LoadFile(
                    url,
                    (data) =>
                    {
                        var info = DDSTools.GetDDSInfo(data);
                        var loadMipmap = (info.isRGB || info.isLuminance || info.mipmapCount > 1) && !noMipmap
                                         && ((info.width << (info.mipmapCount - 1)) == 1);
                        this.prepareWebGLTexture(
                            texture,
                            this._gl,
                            scene,
                            info.width,
                            info.height,
                            invertY,
                            !loadMipmap,
                            info.isFourCC,
                            (pos, max) =>
                            {
                                Tools.Log("loading " + url);
                                DDSTools.UploadDDSLevels(this._gl, this.getCaps().s3tc, data, info, loadMipmap, 1);
                            },
                            samplingMode);
                    },
                    null,
                    scene.database,
                    true);
            }
            else
            {
                Action<Web.ImageData> onload = (img) =>
                    {
                        this.prepareWebGLTexture(
                            texture,
                            this._gl,
                            scene,
                            img.width,
                            img.height,
                            invertY,
                            noMipmap,
                            false,
                            (int potWidth, int potHeight) =>
                            {
                                var isPot = img.width == potWidth && img.height == potHeight;

                                // TODO: my fix. why we need to use canvas to draw image?
                                isPot = true;

                                if (!isPot)
                                {
                                    this._workingCanvas.width = potWidth;
                                    this._workingCanvas.height = potHeight;
                                    this._workingContext.drawImage(img, 0, 0, img.width, img.height, 0, 0, potWidth, potHeight);
                                }

                                if (isPot)
                                {
                                    this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, img);
                                }
                                else
                                {
                                    this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, this._workingCanvas);
                                }
                            },
                            samplingMode);
                    };
                Action<Web.ImageData, object> onerror = (img, err) => { scene._removePendingData(texture); };
                Tools.LoadImage(this._canvas, url, onload, onerror, scene.database);
            }

            return texture;
        }

        /// <summary>
        /// </summary>
        /// <param name="vertices">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual WebGLBuffer createVertexBuffer(Array<double> vertices)
        {
            var vbo = this._gl.createBuffer();
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vbo);
            this._gl.bufferData(Gl.ARRAY_BUFFER, ArrayConvert.AsFloat(vertices), Gl.STATIC_DRAW);
            this._resetVertexBufferBinding();
            vbo.references = 1;
            return vbo;
        }

        /// <summary>
        /// </summary>
        /// <param name="buffer">
        /// </param>
        public virtual void deleteInstancesBuffer(WebGLBuffer buffer)
        {
            this._gl.deleteBuffer(buffer);
        }

        /// <summary>
        /// </summary>
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

        /// <summary>
        /// </summary>
        /// <param name="useTriangles">
        /// </param>
        /// <param name="indexStart">
        /// </param>
        /// <param name="indexCount">
        /// </param>
        /// <param name="instancesCount">
        /// </param>
        public virtual void draw(bool useTriangles, int indexStart, int indexCount, int instancesCount = 0)
        {
            if (instancesCount > 0)
            {
                this._caps.instancedArrays.drawElementsInstancedANGLE(
                    useTriangles ? Gl.TRIANGLES : Gl.LINES, indexCount, Gl.UNSIGNED_SHORT, indexStart * 2, instancesCount);
                return;
            }

            this._gl.drawElements(useTriangles ? Gl.TRIANGLES : Gl.LINES, indexCount, Gl.UNSIGNED_SHORT, indexStart * 2);
        }

        /// <summary>
        /// </summary>
        /// <param name="effect">
        /// </param>
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

        /// <summary>
        /// </summary>
        public virtual void endFrame()
        {
            this.flushFramebuffer();
        }

        /// <summary>
        /// </summary>
        public virtual void flushFramebuffer()
        {
            this._gl.flush();
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual bool getAlphaTesting()
        {
            return this._alphaTest;
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual double getAspectRatio(Camera camera)
        {
            var viewport = camera.viewport;
            return (this.getRenderWidth() * viewport.width) / (this.getRenderHeight() * viewport.height);
        }

        /// <summary>
        /// </summary>
        /// <param name="shaderProgram">
        /// </param>
        /// <param name="attributesNames">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<int> getAttributes(WebGLProgram shaderProgram, Array<string> attributesNames)
        {
            var results = new Array<int>();
            for (var index = 0; index < attributesNames.Length; index++)
            {
                try
                {
                    results.Add(this._gl.getAttribLocation(shaderProgram, attributesNames[index]));
                }
                catch (Exception)
                {
                    results.Add(-1);
                }
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual EngineCapabilities getCaps()
        {
            return this._caps;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual double getHardwareScalingLevel()
        {
            return this._hardwareScalingLevel;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual Array<WebGLTexture> getLoadedTexturesCache()
        {
            return this._loadedTexturesCache;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getRenderHeight()
        {
            if (this._currentRenderTarget != null)
            {
                return this._currentRenderTarget._height;
            }

            return this._renderingCanvas.height;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual int getRenderWidth()
        {
            if (this._currentRenderTarget != null)
            {
                return this._currentRenderTarget._width;
            }

            return this._renderingCanvas.width;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual HTMLCanvasElement getRenderingCanvas()
        {
            return this._renderingCanvas;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual ClientRect getRenderingCanvasClientRect()
        {
            return this._renderingCanvas.getBoundingClientRect();
        }

        /// <summary>
        /// </summary>
        /// <param name="shaderProgram">
        /// </param>
        /// <param name="uniformsNames">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Array<WebGLUniformLocation> getUniforms(WebGLProgram shaderProgram, Array<string> uniformsNames)
        {
            var results = new Array<WebGLUniformLocation>();
            for (var index = 0; index < uniformsNames.Length; index++)
            {
                results.Add(this._gl.getUniformLocation(shaderProgram, uniformsNames[index]));
            }

            return results;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual byte[] readPixels(int x, int y, int width, int height)
        {
            var data = new byte[height * width * 4];
            this._gl.readPixels(0, 0, width, height, Gl.RGBA, Gl.UNSIGNED_BYTE, data);
            return data;
        }

        /// <summary>
        /// </summary>
        public virtual void resize()
        {
            this._renderingCanvas.width = (int)(this._renderingCanvas.clientWidth / this._hardwareScalingLevel);
            this._renderingCanvas.height = (int)(this._renderingCanvas.clientHeight / this._hardwareScalingLevel);
            this._canvasClientRect = this._renderingCanvas.getBoundingClientRect();
        }

        /// <summary>
        /// </summary>
        public virtual void restoreDefaultFramebuffer()
        {
            this._gl.bindFramebuffer(Gl.FRAMEBUFFER, null);
            this.setViewport(this._cachedViewport);
            this.wipeCaches();
        }

        /// <summary>
        /// </summary>
        /// <param name="renderFunction">
        /// </param>
        public virtual void runRenderLoop(System.Action renderFunction)
        {
            this._runningLoop = true;
            this._renderFunction = renderFunction;
            Tools.QueueNewFrame((time) => { this._renderLoop(); });
        }

        /// <summary>
        /// </summary>
        /// <param name="mode">
        /// </param>
        public virtual void setAlphaMode(int mode)
        {
            switch (mode)
            {
                case ALPHA_DISABLE:
                    this.setDepthWrite(true);
                    this._gl.disable(Gl.BLEND);
                    break;
                case ALPHA_COMBINE:
                    this.setDepthWrite(false);
                    this._gl.blendFuncSeparate(Gl.SRC_ALPHA, Gl.ONE_MINUS_SRC_ALPHA, Gl.ONE, Gl.ONE);
                    this._gl.enable(Gl.BLEND);
                    break;
                case ALPHA_ADD:
                    this.setDepthWrite(false);
                    this._gl.blendFuncSeparate(Gl.ONE, Gl.ONE, Gl.ZERO, Gl.ONE);
                    this._gl.enable(Gl.BLEND);
                    break;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="enable">
        /// </param>
        public virtual void setAlphaTesting(bool enable)
        {
            this._alphaTest = enable;
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="array">
        /// </param>
        public virtual void setArray(WebGLUniformLocation uniform, Array<double> array)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform1fv(uniform, ArrayConvert.AsFloat(array));
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="_bool">
        /// </param>
        public virtual void setBool(WebGLUniformLocation uniform, int _bool)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform1i(uniform, _bool);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="color3">
        /// </param>
        public virtual void setColor3(WebGLUniformLocation uniform, Color3 color3)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform3f(uniform, color3.r, color3.g, color3.b);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="color3">
        /// </param>
        /// <param name="alpha">
        /// </param>
        public virtual void setColor4(WebGLUniformLocation uniform, Color3 color3, double alpha)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform4f(uniform, color3.r, color3.g, color3.b, alpha);
        }

        /// <summary>
        /// </summary>
        /// <param name="enable">
        /// </param>
        public virtual void setColorWrite(bool enable)
        {
            this._gl.colorMask(enable, enable, enable, enable);
        }

        /// <summary>
        /// </summary>
        /// <param name="enable">
        /// </param>
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

        /// <summary>
        /// </summary>
        public virtual void setDepthFunctionToGreater()
        {
            this._gl.depthFunc(Gl.GREATER);
        }

        /// <summary>
        /// </summary>
        public virtual void setDepthFunctionToGreaterOrEqual()
        {
            this._gl.depthFunc(Gl.GEQUAL);
        }

        /// <summary>
        /// </summary>
        public virtual void setDepthFunctionToLess()
        {
            this._gl.depthFunc(Gl.LESS);
        }

        /// <summary>
        /// </summary>
        public virtual void setDepthFunctionToLessOrEqual()
        {
            this._gl.depthFunc(Gl.LEQUAL);
        }

        /// <summary>
        /// </summary>
        /// <param name="enable">
        /// </param>
        public virtual void setDepthWrite(bool enable)
        {
            this._gl.depthMask(enable);
            this._depthMask = enable;
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        public virtual void setDirectViewport(int x, int y, int width, int height)
        {
            this._cachedViewport = null;
            this._gl.viewport(x, y, width, height);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="value">
        /// </param>
        public virtual void setFloat(WebGLUniformLocation uniform, double value)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform1f(uniform, value);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public virtual void setFloat2(WebGLUniformLocation uniform, double x, double y)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform2f(uniform, x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        public virtual void setFloat3(WebGLUniformLocation uniform, double x, double y, double z)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform3f(uniform, x, y, z);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        /// <param name="z">
        /// </param>
        /// <param name="w">
        /// </param>
        public virtual void setFloat4(WebGLUniformLocation uniform, double x, double y, double z, double w)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniform4f(uniform, x, y, z, w);
        }

        /// <summary>
        /// </summary>
        /// <param name="level">
        /// </param>
        public virtual void setHardwareScalingLevel(double level)
        {
            this._hardwareScalingLevel = level;
            this.resize();
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="matrices">
        /// </param>
        public virtual void setMatrices(WebGLUniformLocation uniform, float[] matrices)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniformMatrix4fv(uniform, false, matrices);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniform">
        /// </param>
        /// <param name="matrix">
        /// </param>
        public virtual void setMatrix(WebGLUniformLocation uniform, Matrix matrix)
        {
            if (uniform == null)
            {
                return;
            }

            this._gl.uniformMatrix4fv(uniform, false, ArrayConvert.AsFloat(matrix.toArray()));
        }

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        public virtual void setSamplingMode(WebGLTexture texture, double samplingMode)
        {
            var gl = this._gl;
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            var magFilter = Gl.NEAREST;
            var minFilter = Gl.NEAREST;
            if (samplingMode == Texture.BILINEAR_SAMPLINGMODE)
            {
                magFilter = Gl.LINEAR;
                minFilter = Gl.LINEAR;
            }
            else if (samplingMode == Texture.TRILINEAR_SAMPLINGMODE)
            {
                magFilter = Gl.LINEAR;
                minFilter = Gl.LINEAR_MIPMAP_LINEAR;
            }

            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MAG_FILTER, magFilter);
            gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_MIN_FILTER, minFilter);
            gl.bindTexture(Gl.TEXTURE_2D, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="culling">
        /// </param>
        public virtual void setState(bool culling)
        {
            if (this._cullingState != culling)
            {
                if (culling)
                {
                    this._gl.cullFace(this.cullBackFaces ? Gl.BACK : Gl.FRONT);
                    this._gl.enable(Gl.CULL_FACE);
                }
                else
                {
                    this._gl.disable(Gl.CULL_FACE);
                }

                this._cullingState = culling;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="texture">
        /// </param>
        public virtual void setTexture(int channel, BaseTexture texture)
        {
            Tools.Log("setTexture (BaseTexture)");

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

            if (texture is VideoTexture)
            {
                if (((VideoTexture)texture).update())
                {
                    this._activeTexturesCache[channel] = null;
                }
            }
            else if (texture.delayLoadState == DELAYLOADSTATE_NOTLOADED)
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
                    var textureWrapMode = (texture.coordinatesMode != Texture.CUBIC_MODE && texture.coordinatesMode != Texture.SKYBOX_MODE)
                                              ? Gl.REPEAT
                                              : Gl.CLAMP_TO_EDGE;
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
                        case Texture.WRAP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.REPEAT);
                            break;
                        case Texture.CLAMP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.CLAMP_TO_EDGE);
                            break;
                        case Texture.MIRROR_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_S, Gl.MIRRORED_REPEAT);
                            break;
                    }
                }

                if (internalTexture._cachedWrapV != texture.wrapV)
                {
                    internalTexture._cachedWrapV = texture.wrapV;
                    switch (texture.wrapV)
                    {
                        case Texture.WRAP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.REPEAT);
                            break;
                        case Texture.CLAMP_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.CLAMP_TO_EDGE);
                            break;
                        case Texture.MIRROR_ADDRESSMODE:
                            this._gl.texParameteri(Gl.TEXTURE_2D, Gl.TEXTURE_WRAP_T, Gl.MIRRORED_REPEAT);
                            break;
                    }
                }

                this._setAnisotropicLevel(Gl.TEXTURE_2D, texture);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="channel">
        /// </param>
        /// <param name="postProcess">
        /// </param>
        public virtual void setTextureFromPostProcess(int channel, PostProcess postProcess)
        {
            this._bindTexture(channel, postProcess._textures[postProcess._currentRenderTextureInd]);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewport">
        /// </param>
        /// <param name="requiredWidth">
        /// </param>
        /// <param name="requiredHeight">
        /// </param>
        public virtual void setViewport(Viewport viewport, int requiredWidth = 0, int requiredHeight = 0)
        {
            var width = requiredWidth == 0 ? this._renderingCanvas.width : requiredWidth;
            var height = requiredHeight == 0 ? this._renderingCanvas.height : requiredHeight;
            var x = viewport.x;
            var y = viewport.y;
            this._cachedViewport = viewport;
            this._gl.viewport((int)(x * width), (int)(y * height), (int)(width * viewport.width), (int)(height * viewport.height));
        }

        /// <summary>
        /// </summary>
        public virtual void stopRenderLoop()
        {
            this._renderFunction = null;
            this._runningLoop = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="requestPointerLock">
        /// </param>
        public virtual void switchFullscreen(bool requestPointerLock)
        {
            if (this.isFullscreen)
            {
                Tools.ExitFullscreen();
            }
            else
            {
                this._pointerLockRequested = requestPointerLock;
                Tools.RequestFullscreen(this._renderingCanvas);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
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

        /// <summary>
        /// </summary>
        /// <param name="instancesBuffer">
        /// </param>
        /// <param name="offsetLocations">
        /// </param>
        public virtual void unBindInstancesBuffer(WebGLBuffer instancesBuffer, Array<int> offsetLocations)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, instancesBuffer);
            for (var index = 0; index < 4; index++)
            {
                var offsetLocation = offsetLocations[index];
                this._gl.disableVertexAttribArray(offsetLocation);
                this._caps.instancedArrays.vertexAttribDivisorANGLE((uint)offsetLocation, 0);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="instancesBuffer">
        /// </param>
        /// <param name="data">
        /// </param>
        /// <param name="offsetLocations">
        /// </param>
        public virtual void updateAndBindInstancesBuffer(WebGLBuffer instancesBuffer, double[] data, Array<int> offsetLocations)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, instancesBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(data));
            for (var index = 0; index < 4; index++)
            {
                var offsetLocation = offsetLocations[index];
                this._gl.enableVertexAttribArray(offsetLocation);
                this._gl.vertexAttribPointer(offsetLocation, (int)VertexBufferKind.UV2Kind, Gl.FLOAT, false, 64, index * 16);
                this._caps.instancedArrays.vertexAttribDivisorANGLE((uint)offsetLocation, 1);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
        /// <param name="canvas">
        /// </param>
        /// <param name="invertY">
        /// </param>
        public virtual void updateDynamicTexture(WebGLTexture texture, HTMLCanvasElement canvas, bool invertY)
        {
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, invertY ? 1 : 0);
            this._gl.texImage2D(Gl.TEXTURE_2D, 0, Gl.RGBA, Gl.RGBA, Gl.UNSIGNED_BYTE, canvas);
            if (texture.generateMipMaps)
            {
                this._gl.generateMipmap(Gl.TEXTURE_2D);
            }

            this._gl.bindTexture(Gl.TEXTURE_2D, null);
            this._activeTexturesCache = new Array<BaseTexture>();
            texture.isReady = true;
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexBuffer">
        /// </param>
        /// <param name="vertices">
        /// </param>
        /// <param name="length">
        /// </param>
        public virtual void updateDynamicVertexBuffer(WebGLBuffer vertexBuffer, Array<double> vertices, int length = 0)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(vertices));
            this._resetVertexBufferBinding();
        }

        /// <summary>
        /// </summary>
        /// <param name="vertexBuffer">
        /// </param>
        /// <param name="vertices">
        /// </param>
        /// <param name="length">
        /// </param>
        public virtual void updateDynamicVertexBuffer(WebGLBuffer vertexBuffer, double[] vertices, int length = 0)
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, vertexBuffer);
            this._gl.bufferSubData(Gl.ARRAY_BUFFER, 0, ArrayConvert.AsFloat(vertices));
            this._resetVertexBufferBinding();
        }

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
        /// <param name="video">
        /// </param>
        /// <param name="invertY">
        /// </param>
        public virtual void updateVideoTexture(WebGLTexture texture, HTMLVideoElement video, bool invertY)
        {
            this._gl.bindTexture(Gl.TEXTURE_2D, texture);
            this._gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, invertY ? 0 : 1);
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

        /// <summary>
        /// </summary>
        public virtual void wipeCaches()
        {
            this._activeTexturesCache = new Array<BaseTexture>();
            this._currentEffect = null;
            this._cullingState = false;
            this._cachedVertexBuffers = null;
            this._cachedIndexBuffer = null;
            this._cachedEffectForVertexBuffers = null;
        }

        /// <summary>
        /// </summary>
        private void _resetIndexBufferBinding()
        {
            this._gl.bindBuffer(Gl.ELEMENT_ARRAY_BUFFER, null);
            this._cachedIndexBuffer = null;
        }

        /// <summary>
        /// </summary>
        private void _resetVertexBufferBinding()
        {
            this._gl.bindBuffer(Gl.ARRAY_BUFFER, null);
            this._cachedVertexBuffers = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="rootUrl">
        /// </param>
        /// <param name="index">
        /// </param>
        /// <param name="loadedImages">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="onfinish">
        /// </param>
        /// <param name="extensions">
        /// </param>
        private void cascadeLoad(
            string rootUrl, int index, Array<Web.ImageData> loadedImages, Scene scene, Action<Array<Web.ImageData>> onfinish, Array<string> extensions)
        {
            HTMLImageElement img = null;
            Action<Web.ImageData> onload = (imageElement) =>
                {
                    loadedImages.Add(imageElement);
                    scene._removePendingData(imageElement);
                    if (index != extensions.Length - 1)
                    {
                        this.cascadeLoad(rootUrl, index + 1, loadedImages, scene, onfinish, extensions);
                    }
                    else
                    {
                        onfinish(loadedImages);
                    }
                };
            Action<Web.ImageData, object> onerror = (imageElement, err) => { scene._removePendingData(imageElement); };
            img = Tools.LoadImage(this._canvas, rootUrl + extensions[index], onload, onerror, scene.database);
            scene._addPendingData(img);
        }

        /// <summary>
        /// </summary>
        /// <param name="gl">
        /// </param>
        /// <param name="source">
        /// </param>
        /// <param name="type">
        /// </param>
        /// <param name="defines">
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Error">
        /// </exception>
        private WebGLShader compileShader(WebGLRenderingContext gl, string source, string type, string defines)
        {
            var shader = gl.createShader((type == "vertex") ? Gl.VERTEX_SHADER : Gl.FRAGMENT_SHADER);
            gl.shaderSource(shader, ((!string.IsNullOrEmpty(defines)) ? defines + "\n" : string.Empty) + source);
            gl.compileShader(shader);
            if ((int)gl.getShaderParameter(shader, Gl.COMPILE_STATUS) != Gl.TRUE)
            {
                throw new Error(gl.getShaderInfoLog(shader));
            }

            return shader;
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        /// <param name="max">
        /// </param>
        /// <returns>
        /// </returns>
        private int getExponantOfTwo(int value, int max)
        {
            var count = 1;
            do
            {
                count *= 2;
            }
            while (count < value);
            if (count > max)
            {
                count = max;
            }

            return count;
        }

        /// <summary>
        /// </summary>
        /// <param name="samplingMode">
        /// </param>
        /// <param name="generateMipMaps">
        /// </param>
        /// <param name="gl">
        /// </param>
        /// <returns>
        /// </returns>
        private MinMagFilter getSamplingParameters(int samplingMode, bool generateMipMaps, WebGLRenderingContext gl)
        {
            var magFilter = Gl.NEAREST;
            var minFilter = Gl.NEAREST;
            if (samplingMode == Texture.BILINEAR_SAMPLINGMODE)
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
            else if (samplingMode == Texture.TRILINEAR_SAMPLINGMODE)
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
            else if (samplingMode == Texture.NEAREST_SAMPLINGMODE)
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

        /// <summary>
        /// </summary>
        /// <param name="texture">
        /// </param>
        /// <param name="gl">
        /// </param>
        /// <param name="scene">
        /// </param>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="invertY">
        /// </param>
        /// <param name="noMipmap">
        /// </param>
        /// <param name="isCompressed">
        /// </param>
        /// <param name="processFunction">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        private void prepareWebGLTexture(
            WebGLTexture texture,
            WebGLRenderingContext gl,
            Scene scene,
            int width,
            int height,
            bool invertY,
            bool noMipmap,
            bool isCompressed,
            Action<int, int> processFunction,
            int samplingMode = Texture.TRILINEAR_SAMPLINGMODE)
        {
            var engine = scene.getEngine();
            var potWidth = this.getExponantOfTwo(width, engine.getCaps().maxTextureSize);
            var potHeight = this.getExponantOfTwo(height, engine.getCaps().maxTextureSize);
            gl.bindTexture(Gl.TEXTURE_2D, texture);
            //gl.pixelStorei(Gl.UNPACK_FLIP_Y_WEBGL, invertY ? 1 : 0);
            processFunction(potWidth, potHeight);
            var filters = this.getSamplingParameters(samplingMode, !noMipmap, gl);
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

        /// <summary>
        /// </summary>
        public const int ALPHA_DISABLE = 0;

        /// <summary>
        /// </summary>
        public const int ALPHA_ADD = 1;

        /// <summary>
        /// </summary>
        public const int ALPHA_COMBINE = 2;

        /// <summary>
        /// </summary>
        public const int DELAYLOADSTATE_NONE = 0;

        /// <summary>
        /// </summary>
        public const int DELAYLOADSTATE_LOADED = 1;

        /// <summary>
        /// </summary>
        public const int DELAYLOADSTATE_LOADING = 2;

        /// <summary>
        /// </summary>
        public const int DELAYLOADSTATE_NOTLOADED = 4;
    }
}