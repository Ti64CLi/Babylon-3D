namespace BabylonGlut
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Babylon;
    using BABYLON;
    using Web;

    public class GlRenderingContextAdapter : WebGLRenderingContext
    {
        private readonly IDictionary<string, uint> _constMap = new Dictionary<string, uint>();

        public GlRenderingContextAdapter()
        {
            this._constMap["TEXTURE"] = Gl.GL_TEXTURE;
            this._constMap["TEXTURE0"] = Gl.GL_TEXTURE0;
            this._constMap["TEXTURE1"] = Gl.GL_TEXTURE1;
            this._constMap["TEXTURE2"] = Gl.GL_TEXTURE2;
            this._constMap["TEXTURE3"] = Gl.GL_TEXTURE3;
            this._constMap["TEXTURE4"] = Gl.GL_TEXTURE4;
            this._constMap["TEXTURE5"] = Gl.GL_TEXTURE5;
            this._constMap["TEXTURE6"] = Gl.GL_TEXTURE6;
            this._constMap["TEXTURE7"] = Gl.GL_TEXTURE7;
            this._constMap["TEXTURE8"] = Gl.GL_TEXTURE8;
            this._constMap["TEXTURE9"] = Gl.GL_TEXTURE9;
            this._constMap["TEXTURE10"] = Gl.GL_TEXTURE10;
            this._constMap["TEXTURE11"] = Gl.GL_TEXTURE11;
            this._constMap["TEXTURE12"] = Gl.GL_TEXTURE12;
            this._constMap["TEXTURE13"] = Gl.GL_TEXTURE13;
            this._constMap["TEXTURE14"] = Gl.GL_TEXTURE14;
            this._constMap["TEXTURE15"] = Gl.GL_TEXTURE15;
            this._constMap["TEXTURE16"] = Gl.GL_TEXTURE16;
            this._constMap["TEXTURE17"] = Gl.GL_TEXTURE17;
            this._constMap["TEXTURE18"] = Gl.GL_TEXTURE18;
            this._constMap["TEXTURE19"] = Gl.GL_TEXTURE19;
            this._constMap["TEXTURE20"] = Gl.GL_TEXTURE20;
            this._constMap["TEXTURE21"] = Gl.GL_TEXTURE21;
            this._constMap["TEXTURE22"] = Gl.GL_TEXTURE22;
            this._constMap["TEXTURE23"] = Gl.GL_TEXTURE23;
            this._constMap["TEXTURE24"] = Gl.GL_TEXTURE24;
            this._constMap["TEXTURE25"] = Gl.GL_TEXTURE25;
            this._constMap["TEXTURE26"] = Gl.GL_TEXTURE26;
            this._constMap["TEXTURE27"] = Gl.GL_TEXTURE27;
            this._constMap["TEXTURE28"] = Gl.GL_TEXTURE28;
            this._constMap["TEXTURE29"] = Gl.GL_TEXTURE29;
            this._constMap["TEXTURE30"] = Gl.GL_TEXTURE30;
            this._constMap["TEXTURE31"] = Gl.GL_TEXTURE31;
        }

        public int drawingBufferHeight
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public int drawingBufferWidth
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public int this[string enumName]
        {
            get { return (int)this._constMap[enumName]; }
        }

        public HTMLCanvasElement canvas
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public void linkProgram(WebGLProgram program)
        {
#if _DEBUG
            Log.Info(string.Format("linkProgram {0}", program.Value));
#endif

#if GLEW_STATIC
            Gl.glLinkProgram(program.Value);
#else
            Gl.__glewLinkProgram(program.Value);
#endif
            this.ErrorTest();
        }

        public WebGLTexture createTexture()
        {
#if _DEBUG
            Log.Info("createTexture");
#endif

            uint textureId;
            unsafe
            {
                Gl.glGenTextures(1, &textureId);
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)textureId));
#endif

            return new WebGLTextureAdapter(textureId);
        }

        public WebGLFramebuffer createFramebuffer()
        {
#if _DEBUG
            Log.Info("createFramebuffer");
#endif
            uint bufferId;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGenFramebuffers(1, &bufferId);
#else
                Gl.__glewGenFramebuffers(1, &bufferId);
#endif
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)bufferId));
#endif
            return new GlFramebufferAdapter(bufferId);
        }

        public void deleteFramebuffer(WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public WebGLProgram createProgram()
        {
#if _DEBUG
            Log.Info("createProgram");
#endif

#if GLEW_STATIC
            var glProgramAdapter = new GlProgramAdapter(Gl.glCreateProgram());
#else
            var glProgramAdapter = new GlProgramAdapter(Gl.__glewCreateProgram());
#endif
            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", glProgramAdapter.Value));
#endif

            return glProgramAdapter;
        }

        public void deleteShader(WebGLShader shader)
        {
#if _DEBUG
            Log.Info(string.Format("deleteShader", shader.Value));
#endif

#if GLEW_STATIC
            Gl.glDeleteShader(shader.Value);
#else
            Gl.__glewDeleteShader(shader.Value);
#endif
            this.ErrorTest();
        }

        public Array<WebGLShader> getAttachedShaders(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public WebGLBuffer createBuffer()
        {
#if _DEBUG
            Log.Info("createBuffer");
#endif
            uint bufferId;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGenBuffers(1, &bufferId);
#else
                Gl.__glewGenBuffers(1, &bufferId);
#endif
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)bufferId));
#endif
            return new GlBufferAdapter(bufferId);
        }

        public void deleteTexture(WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(WebGLProgram program)
        {
#if _DEBUG
            Log.Info(string.Format("useProgram {0}", program.Value));
#endif

#if GLEW_STATIC
            Gl.glUseProgram(program.Value);
#else
            Gl.__glewUseProgram(program.Value);
#endif
            this.ErrorTest();
        }

        public void uniform3iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public WebGLContextAttributes getContextAttributes()
        {
            throw new NotImplementedException();
        }

        public void uniform1iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void uniform2fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void deleteRenderbuffer(WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void uniform4fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void flush()
        {
            throw new NotImplementedException();
        }

        public void deleteProgram(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public WebGLRenderbuffer createRenderbuffer()
        {
#if _DEBUG
            Log.Info("createRenderbuffer");
#endif
            uint bufferId;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGenRenderbuffers(1, &bufferId);
#else
                Gl.__glewGenRenderbuffers(1, &bufferId);
#endif
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)bufferId));
#endif
            return new GlRenderbufferAdapter(bufferId);
        }

        public void detachShader(WebGLProgram program, WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void deleteBuffer(WebGLBuffer buffer)
        {
#if _DEBUG
            Log.Info(string.Format("deleteBuffer {0}", buffer.Value));
#endif
            var value = buffer.Value;
            unsafe
            {
#if GLEW_STATIC
                Gl.glDeleteBuffers(1, &value);
#else
                Gl.__glewDeleteBuffers(1, &value);
#endif
            }

            this.ErrorTest();
        }

        public void uniform3fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void attachShader(WebGLProgram program, WebGLShader shader)
        {
#if _DEBUG
            Log.Info(string.Format("attachShader {0} {1}", program.Value, shader.Value));
#endif

#if GLEW_STATIC
            Gl.glAttachShader(program.Value, shader.Value);
#else
            Gl.__glewAttachShader(program.Value, shader.Value);
#endif
            this.ErrorTest();
        }

        public void compileShader(WebGLShader shader)
        {
#if _DEBUG
            Log.Info(string.Format("compileShader {0}", shader.Value));
#endif

#if GLEW_STATIC
            Gl.glCompileShader(shader.Value);
#else
            Gl.__glewCompileShader(shader.Value);
#endif
            this.ErrorTest();
        }

        public void finish()
        {
            throw new NotImplementedException();
        }

        public void validateProgram(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void activeTexture(int texture)
        {
#if _DEBUG
            Log.Info(string.Format("activeTexture {0}", texture));
#endif
            Gl.__glewActiveTexture(texture);
        }

        public void bindAttribLocation(WebGLProgram program, int index, string name)
        {
            throw new NotImplementedException();
        }

        public void bindBuffer(int target, WebGLBuffer buffer)
        {
            var bufferId = (int)(buffer != null ? buffer.Value : 0);

#if _DEBUG
            Log.Info(string.Format("bindBuffer {0} {1}", target, bufferId));
#endif

#if GLEW_STATIC
            Gl.glBindBuffer(target, bufferId);
#else
            Gl.__glewBindBuffer(target, bufferId);
#endif
            this.ErrorTest();
        }

        public void bindFramebuffer(int target, WebGLFramebuffer framebuffer)
        {
            var bufferId = (int)(framebuffer != null ? framebuffer.Value : 0);

#if _DEBUG
            Log.Info(string.Format("bindFramebuffer {0} {1}", target, bufferId));
#endif

#if GLEW_STATIC
            Gl.glBindFramebuffer(target, bufferId);
#else
            Gl.__glewBindFramebuffer(target, bufferId);
#endif
            this.ErrorTest();
        }

        public void bindRenderbuffer(int target, WebGLRenderbuffer renderbuffer)
        {
            var bufferId = (int)(renderbuffer != null ? renderbuffer.Value : 0);

#if _DEBUG
            Log.Info(string.Format("bindRenderbuffer {0} {1}", target, bufferId));
#endif

#if GLEW_STATIC
            Gl.glBindRenderbuffer(target, bufferId);
#else
            Gl.__glewBindRenderbuffer(target, bufferId);
#endif
            this.ErrorTest();
        }

        public void bindTexture(int target, WebGLTexture texture)
        {
#if _DEBUG
            Log.Info(string.Format("bindTexture {0}", target, (int)(texture != null ? texture.Value : 0)));
#endif

            Gl.glBindTexture(target, (int)(texture != null ? texture.Value : 0));
            this.ErrorTest();
        }

        public void blendColor(int red, int green, int blue, int alpha)
        {
            throw new NotImplementedException();
        }

        public void blendEquation(int mode)
        {
            throw new NotImplementedException();
        }

        public void blendEquationSeparate(int modeRGB, int modeAlpha)
        {
            throw new NotImplementedException();
        }

        public void blendFunc(int sfactor, int dfactor)
        {
            throw new NotImplementedException();
        }

        public void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
        {
            Gl.__glewBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
            this.ErrorTest();
        }

        public void bufferData(int target, float[] data, int usage)
        {
#if _DEBUG
            Log.Info(string.Format("bufferData float {0} Count:{1} Len:{2} {3}", target, data.Length, data.Length * sizeof(float), usage));
#endif

            unsafe
            {
                fixed (void* pdata = data)
                {
#if GLEW_STATIC
                    Gl.glBufferData(target, data.Length * sizeof(float), pdata, usage);
#else
                    Gl.__glewBufferData(target, data.Length * sizeof(float), pdata, usage);
#endif
                }
            }

            this.ErrorTest();
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
#if _DEBUG
            Log.Info(string.Format("bufferData ushort {0} Count:{1} Len:{2} {3}", target, data.Length, data.Length * sizeof(ushort), usage));
#endif
            unsafe
            {
                fixed (void* pdata = data)
                {
#if GLEW_STATIC
                    Gl.glBufferData(target, data.Length * sizeof(ushort), pdata, usage);
#else
                    Gl.__glewBufferData(target, data.Length * sizeof(ushort), pdata, usage);
#endif
                }
            }

            this.ErrorTest();
        }

        public void bufferData(int target, int size, int usage)
        {
#if _DEBUG
            Log.Info(string.Format("bufferData {0} {1} {2}", target, size, usage));
#endif
            unsafe
            {
#if GLEW_STATIC
                Gl.glBufferData(target, size, null, usage);
#else
                Gl.__glewBufferData(target, size, null, usage);
#endif
            }

            this.ErrorTest();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
#if _DEBUG
            Log.Info(string.Format("bufferSubData {0} {1} {2}", target, offset, size));
#endif
            unsafe
            {
#if GLEW_STATIC
                Gl.glBufferSubData(target, offset, size, data.ToPointer());
#else
                Gl.__glewBufferSubData(target, offset, size, data.ToPointer());
#endif
            }

            this.ErrorTest();
        }

        public void bufferSubData(int target, int offset, float[] data)
        {
            unsafe
            {
                fixed (void* p = data)
                {
#if GLEW_STATIC
                    Gl.glBufferSubData(target, offset, data.Length * sizeof(float), p);
#else
                    Gl.__glewBufferSubData(target, offset, data.Length * sizeof(float), p);
#endif
                }
            }

            this.ErrorTest();
        }

        public int checkFramebufferStatus(int target)
        {
            throw new NotImplementedException();
        }

        public void clear(int mask)
        {
#if _DEBUG
            Log.Info(string.Format("clear {0}", mask));
#endif
            Gl.glClear(mask);
            this.ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
#if _DEBUG
            Log.Info(string.Format("clearColor {0} {1} {2} {3}", red, green, blue, alpha));
#endif
            Gl.glClearColor((float)red, (float)green, (float)blue, (float)alpha);
            this.ErrorTest();
        }

        public void clearDepth(double depth)
        {
#if _DEBUG
            Log.Info(string.Format("clearDepth {0}", depth));
#endif

            Gl.glClearDepth(depth);
            this.ErrorTest();
        }

        public void clearStencil(int s)
        {
            throw new NotImplementedException();
        }

        public void colorMask(bool red, bool green, bool blue, bool alpha)
        {
            throw new NotImplementedException();
        }

        public void compressedTexImage2D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            byte[] data)
        {
            throw new NotImplementedException();
        }

        public void compressedTexSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int width,
            int height,
            int format,
            ArrayBufferView data)
        {
            throw new NotImplementedException();
        }

        public void copyTexImage2D(
            int target,
            int level,
            int internalformat,
            double x,
            double y,
            int width,
            int height,
            int border)
        {
            throw new NotImplementedException();
        }

        public void copyTexSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            double x,
            double y,
            int width,
            int height)
        {
            throw new NotImplementedException();
        }

        public WebGLShader createShader(int type)
        {
#if _DEBUG
            Log.Info(string.Format("createShader {0}", type));
#endif

#if GLEW_STATIC
            var shader = (uint)Gl.glCreateShader(type);
#else
            var shader = (uint)Gl.__glewCreateShader(type);
#endif
            this.ErrorTest();
            return new GlShaderAdapter(shader);
        }

        public void cullFace(int mode)
        {
#if _DEBUG
            Log.Info(string.Format("cullFace {0}", mode));
#endif

            Gl.glCullFace(mode);
            this.ErrorTest();
        }

        public void depthFunc(int func)
        {
#if _DEBUG
            Log.Info(string.Format("depthFunc {0}", func));
#endif

            Gl.glDepthFunc(func);
            this.ErrorTest();
        }

        public void depthMask(bool flag)
        {
#if _DEBUG
            Log.Info(string.Format("depthMask {0}", flag));
#endif
            Gl.glDepthMask((byte)(flag ? 1 : 0));
            this.ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void disable(int cap)
        {
#if _DEBUG
            Log.Info(string.Format("disable {0}", cap));
#endif
            Gl.glDisable(cap);
        }

        public void disableVertexAttribArray(int index)
        {
            Gl.__glewDisableVertexAttribArray(index);
        }

        public void drawArrays(int mode, int first, int count)
        {
            throw new NotImplementedException();
        }

        public void drawElements(int mode, int count, int type, int offset)
        {
#if _DEBUG
            Log.Info(string.Format("drawElements {0} {1} {2} {3}", mode, count, type, offset));
#endif
            unsafe
            {
                Gl.glDrawElements(mode, count, type, (void*)offset);
            }
            this.ErrorTest();
        }

        public void enable(int cap)
        {
#if _DEBUG
            Log.Info(string.Format("enable {0}", cap));
#endif
            Gl.glEnable(cap);
            this.ErrorTest();
        }

        public void enableVertexAttribArray(int index)
        {
#if _DEBUG
            Log.Info(string.Format("enableVertexAttribArray {0}", index));
#endif

#if GLEW_STATIC
            Gl.glEnableVertexAttribArray((uint)index);
#else
            Gl.__glewEnableVertexAttribArray((uint)index);
#endif
            this.ErrorTest();
        }

        public void framebufferRenderbuffer(
            int target,
            int attachment,
            int renderbuffertarget,
            WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void framebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level)
        {
#if _DEBUG
            Log.Info(string.Format("framebufferTexture2D {0} {1} {2} {3} {4}", target, attachment, textarget, texture != null ? texture.Value : 0, level));
#endif

#if GLEW_STATIC
            Gl.glFramebufferTexture2D(target, attachment, textarget, (int)(texture != null ? texture.Value : 0), level);
#else
            Gl.__glewFramebufferTexture2D(target, attachment, textarget, (int)(texture != null ? texture.Value : 0), level);
#endif

            this.ErrorTest();
        }

        public void frontFace(int mode)
        {
            throw new NotImplementedException();
        }

        public void generateMipmap(int target)
        {
            Gl.__glewGenerateMipmap(target);
            this.ErrorTest();
        }

        public WebGLActiveInfo getActiveAttrib(WebGLProgram program, int index)
        {
            throw new NotImplementedException();
        }

        public WebGLActiveInfo getActiveUniform(WebGLProgram program, int index)
        {
            throw new NotImplementedException();
        }

        public int getAttribLocation(WebGLProgram program, string name)
        {
#if _DEBUG
            Log.Info(string.Format("getAttribLocation {0} {1}", program.Value, name));
#endif
            var chars = name.ToCharArray();

            var bytes = new byte[chars.Length];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)chars[i];
            }

            var attribLocation = -1;
            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
#if GLEW_STATIC
                    attribLocation = Gl.glGetAttribLocation(program.Value, b);
#else
                    attribLocation = Gl.__glewGetAttribLocation(program.Value, b);
#endif
                }
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", attribLocation));
#endif

            return attribLocation;
        }

        public object getBufferParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public int getError()
        {
            return Gl.glGetError();
        }

        public object getExtension(string name)
        {
            if (name == "OES_standard_derivatives")
            {
                unsafe
                {
                    var result = Gl.glGetString(Gl.GL_EXTENSIONS);
                    var ext = new string(result);

#if _DEBUG
                    Log.Info(string.Format("Extension: {0}", ext));
#endif

                    //return ext.Contains(name) ? new object() : null;
                    return new object();
                }
            }

            return null;
        }

        public object getFramebufferAttachmentParameter(int target, int attachment, int pname)
        {
            throw new NotImplementedException();
        }

        public object getParameter(int pname)
        {
#if _DEBUG
            Log.Info(string.Format("getParameter {0}", pname));
#endif
            int i;
            unsafe
            {
                Gl.glGetIntegerv(pname, &i);
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif
            return i;
        }

        public string getProgramInfoLog(WebGLProgram program)
        {
#if _DEBUG
            Log.Info(string.Format("getProgramInfoLog {0}", program.Value));
#endif

            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGetProgramiv(program.Value, GL_INFO_LOG_LENGTH, &k);
#else
                Gl.__glewGetProgramiv(program.Value, GL_INFO_LOG_LENGTH, &k);
#endif
            }

            if (k <= 0)
            {
                return string.Empty;
            }

            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = &result[0])
                {
#if GLEW_STATIC
                    Gl.glGetProgramInfoLog(program.Value, k, &k, presult);
#else
                    Gl.__glewGetProgramInfoLog(program.Value, k, &k, presult);
#endif
                }
            }

            return new string(Encoding.ASCII.GetChars(result));
        }

        public object getProgramParameter(WebGLProgram program, int pname)
        {
#if _DEBUG
            Log.Info(string.Format("getProgramParameter {0} {1}", program.Value, pname));
#endif

            int i;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGetProgramiv(program.Value, pname, &i);
#else
                Gl.__glewGetProgramiv(program.Value, pname, &i);
#endif
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif
            return i;
        }

        public object getRenderbufferParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public string getShaderInfoLog(WebGLShader shader)
        {
#if _DEBUG
            Log.Info("getShaderInfoLog");
#endif
            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, &k);
#else
                Gl.__glewGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, &k);
#endif
            }
            if (k <= 0)
            {
                return string.Empty;
            }

            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = &result[0])
                {
#if GLEW_STATIC
                    Gl.glGetShaderInfoLog(shader.Value, k, &k, presult);
#else
                    Gl.__glewGetShaderInfoLog(shader.Value, k, &k, presult);
#endif
                }
            }

            ////var version = glGetString(GL_SHADING_LANGUAGE_VERSION);

            return new string(Encoding.ASCII.GetChars(result));
        }

        public object getShaderParameter(WebGLShader shader, int pname)
        {
#if _DEBUG
            Log.Info(string.Format("getShaderParameter {0} {1}", shader.Value, pname));
#endif
            int i;
            unsafe
            {
#if GLEW_STATIC
                Gl.glGetShaderiv(shader.Value, pname, &i);
#else
                Gl.__glewGetShaderiv(shader.Value, pname, &i);
#endif
            }

            this.ErrorTest();
#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif

            return i;
        }

        public WebGLShaderPrecisionFormat getShaderPrecisionFormat(int shadertype, int precisiontype)
        {
            throw new NotImplementedException();
        }

        public string getShaderSource(WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public object getTexParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public object getUniform(WebGLProgram program, WebGLUniformLocation location)
        {
            throw new NotImplementedException();
        }

        public WebGLUniformLocation getUniformLocation(WebGLProgram program, string name)
        {
#if _DEBUG
            Log.Info(string.Format("getUniformLocation {0} {1}", (int)program.Value, name));
#endif
            var bytes = Encoding.ASCII.GetBytes(name);
            GlUniformLocation glUniformLocation = null;
            unsafe
            {
                fixed (byte* b = bytes)
                {
#if GLEW_STATIC
                    glUniformLocation = new GlUniformLocation(Gl.glGetUniformLocation(program.Value, b));
#else
                    glUniformLocation = new GlUniformLocation(Gl.__glewGetUniformLocation(program.Value, b));
#endif
                }
            }

            this.ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", glUniformLocation.Value));
#endif

            return glUniformLocation;
        }

        public object getVertexAttrib(int index, int pname)
        {
            throw new NotImplementedException();
        }

        public int getVertexAttribOffset(int index, int pname)
        {
            throw new NotImplementedException();
        }

        public void hint(int target, int mode)
        {
            throw new NotImplementedException();
        }

        public bool isBuffer(WebGLBuffer buffer)
        {
            throw new NotImplementedException();
        }

        public bool isContextLost()
        {
            throw new NotImplementedException();
        }

        public bool isEnabled(int cap)
        {
            throw new NotImplementedException();
        }

        public bool isFramebuffer(WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public bool isProgram(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public bool isRenderbuffer(WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public bool isShader(WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public bool isTexture(WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void lineWidth(int width)
        {
            throw new NotImplementedException();
        }

        public void pixelStorei(int pname, int param)
        {
            Gl.glPixelStorei(pname, param);
            this.ErrorTest();
        }

        public void polygonOffset(int factor, int units)
        {
            throw new NotImplementedException();
        }

        public void readPixels(int x, int y, int width, int height, int format, int type, byte[] pixels)
        {
#if _DEBUG
            Log.Info(string.Format("readPixels {0} {1} {2} {3} {4} {5}", x, y, width, height, format, type));
#endif
            unsafe
            {
                fixed (byte* ppixels = &pixels[0])
                {
                    Gl.glReadPixels(x, y, width, height, format, type, ppixels);
                }
            }

            this.ErrorTest();
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void sampleCoverage(int value, bool invert)
        {
            throw new NotImplementedException();
        }

        public void scissor(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void shaderSource(WebGLShader shader, string source)
        {
#if _DEBUG
            Log.Info(string.Format("shaderSource {0}, source length {1}", shader.Value, source.Length));
#endif
            var bytes = Encoding.ASCII.GetBytes(source);
            var len = bytes.Length;

            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
                    byte*[] barray = new byte*[] { b };
                    fixed (byte** pb = &barray[0])
                    {
#if GLEW_STATIC
                        Gl.glShaderSource(shader.Value, 1, pb, &len);
#else
                        Gl.__glewShaderSource(shader.Value, 1, pb, &len);
#endif
                    }
                }
            }

            this.ErrorTest();
        }

        public void stencilFunc(int func, int _ref, int mask)
        {
            throw new NotImplementedException();
        }

        public void stencilFuncSeparate(int face, int func, int _ref, int mask)
        {
            throw new NotImplementedException();
        }

        public void stencilMask(int mask)
        {
            throw new NotImplementedException();
        }

        public void stencilMaskSeparate(int face, int mask)
        {
            throw new NotImplementedException();
        }

        public void stencilOp(int fail, double zfail, double zpass)
        {
            throw new NotImplementedException();
        }

        public void stencilOpSeparate(int face, int fail, double zfail, double zpass)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            int format,
            int type,
            byte[] pixels)
        {
#if _DEBUG
            Log.Info(string.Format("texImage2D {0} {1} {2} {3} {4} {5} {6} {7} Pixels: {8}", target, level, internalformat, width, height, border, format, type, pixels.Length));
#endif

            unsafe
            {
                fixed (byte* pixelsPtr = pixels)
                {
                    Gl.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixelsPtr);
                }
            }

            this.ErrorTest();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            HTMLImageElement image)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            HTMLCanvasElement canvas)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, ImageData pixels)
        {
#if _DEBUG
            Log.Info(string.Format("texImage2D {0} {1} {2} {3} {4}", target, level, internalformat, format, type));
            if (pixels != null)
            {
                Log.Info(string.Format("ImageData {0} {1}", pixels.width, pixels.height));
            }
#endif

            if (format == Gl.GL_RGBA)
            {
                format = Gl.GL_BGRA;
            }

            unsafe
            {
                byte[] dataBytes = pixels.dataBytes;
                fixed (byte* pData = &dataBytes[0])
                {
                    Gl.glTexImage2D(
                        target,
                        level,
                        internalformat,
                        pixels.width,
                        pixels.height,
                        0,
                        format,
                        type,
                        pData);
                }
            }

            this.ErrorTest();
        }

        public void texParameterf(int target, int pname, float param)
        {
            throw new NotImplementedException();
        }

        public void texParameteri(int target, int pname, int param)
        {
            Gl.glTexParameteri(target, pname, param);
            this.ErrorTest();
        }

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int width,
            int height,
            int format,
            int type,
            ArrayBufferView pixels)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int format,
            int type,
            HTMLImageElement image)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int format,
            int type,
            HTMLCanvasElement canvas)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int format,
            int type,
            HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int format,
            int type,
            ImageData pixels)
        {
            throw new NotImplementedException();
        }

        public void uniform1f(WebGLUniformLocation location, double x)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform1i(WebGLUniformLocation location, int x)
        {
#if _DEBUG
            Log.Info(string.Format("uniform1i {0} {1}", location.Value, x));
#endif

#if GLEW_STATIC
            Gl.glUniform1i(location.Value, x);
#else
            Gl.__glewUniform1i(location.Value, x);
#endif
            this.ErrorTest();
        }

        public void uniform1iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2f(WebGLUniformLocation location, double x, double y)
        {
            Gl.__glewUniform2f(location.Value, (float)x, (float)y);
        }

        public void uniform2fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2i(WebGLUniformLocation location, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3f(WebGLUniformLocation location, double x, double y, double z)
        {
#if _DEBUG
            Log.Info(string.Format("uniform3f {0} {1} {2} {3}", location.Value, x, y, z));
#endif
#if GLEW_STATIC
            Gl.glUniform3f((int)location.Value, (float)x, (float)y, (float)z);
#else
            Gl.__glewUniform3f((int)location.Value, (float)x, (float)y, (float)z);
#endif
            this.ErrorTest();
        }

        public void uniform3fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3i(WebGLUniformLocation location, int x, int y, int z)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4f(WebGLUniformLocation location, double x, double y, double z, double w)
        {
#if _DEBUG
            Log.Info(string.Format("uniform4f {0} {1} {2} {3} {4}", location.Value, x, y, z, w));
#endif

#if GLEW_STATIC
            Gl.glUniform4f((int)location.Value, (float)x, (float)y, (float)z, (float)w);
#else
            Gl.__glewUniform4f((int)location.Value, (float)x, (float)y, (float)z, (float)w);
#endif
            this.ErrorTest();
        }

        public void uniform4fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4i(WebGLUniformLocation location, int x, int y, int z, int w)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
#if _DEBUG
            Log.Info(string.Format("uniformMatrix4fv {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}", location.Value, transpose
                , value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11], value[12], value[13], value[14], value[15]));
#endif

            unsafe
            {
                fixed (float* pvalue = &value[0])
                {
#if GLEW_STATIC
                    Gl.glUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), pvalue);
#else
                    Gl.__glewUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), pvalue);
#endif
                }
            }

            this.ErrorTest();
        }

        public void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1f(int indx, double x)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1fv(int indx, Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2f(int indx, double x, double y)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2fv(int indx, Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3f(int indx, double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3fv(int indx, Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib4fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib4fv(int indx, Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset)
        {
#if _DEBUG
            Log.Info(string.Format("vertexAttribPointer {0} {1} {2} {3} {4} {5}", indx, size, type, normalized, stride, offset));
#endif

            unsafe
            {
#if GLEW_STATIC
                Gl.glVertexAttribPointer((uint)indx, size, type, (byte)(normalized ? 1 : 0), stride, new IntPtr(offset).ToPointer());
#else
                Gl.__glewVertexAttribPointer(
                    (uint)indx,
                    size,
                    type,
                    (byte)(normalized ? 1 : 0),
                    stride,
                    new IntPtr(offset).ToPointer());
#endif
            }

            this.ErrorTest();
        }

        public void viewport(int x, int y, int width, int height)
        {
#if _DEBUG
            Log.Info(string.Format("viewport {0} {1} {2} {3}", x, y, width, height));
#endif
            Gl.glViewport(x, y, width, height);
            this.ErrorTest();
        }

        private void ErrorTest()
        {
#if _DEBUG
            var error = Gl.glGetError();
            if (error != Gl.GL_NO_ERROR)
            {
                var msg = string.Format("GL Error {0}", error);
                Log.Error(msg);
                throw new Exception(msg);
            }
#endif
        }
    }
}