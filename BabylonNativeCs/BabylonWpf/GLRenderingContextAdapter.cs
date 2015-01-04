namespace BabylonWpf
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using Babylon;
    using BABYLON;
    using SharpGL;
    using SharpGL.Enumerations;
    using Web;

    public class GlRenderingContextAdapter : Web.WebGLRenderingContext
    {
        private SharpGL.OpenGL openGl;
        private IDictionary<string, uint> _constMap = new Dictionary<string, uint>();

        public GlRenderingContextAdapter(SharpGL.OpenGL openGl)
        {
            this.openGl = openGl;

            _constMap["TEXTURE"] = OpenGL.GL_TEXTURE;
            _constMap["TEXTURE0"] = OpenGL.GL_TEXTURE0;
            _constMap["TEXTURE1"] = OpenGL.GL_TEXTURE1;
            _constMap["TEXTURE2"] = OpenGL.GL_TEXTURE2;
            _constMap["TEXTURE3"] = OpenGL.GL_TEXTURE3;
            _constMap["TEXTURE4"] = OpenGL.GL_TEXTURE4;
            _constMap["TEXTURE5"] = OpenGL.GL_TEXTURE5;
            _constMap["TEXTURE6"] = OpenGL.GL_TEXTURE6;
            _constMap["TEXTURE7"] = OpenGL.GL_TEXTURE7;
            _constMap["TEXTURE8"] = OpenGL.GL_TEXTURE8;
            _constMap["TEXTURE9"] = OpenGL.GL_TEXTURE9;
            _constMap["TEXTURE10"] = OpenGL.GL_TEXTURE10;
            _constMap["TEXTURE11"] = OpenGL.GL_TEXTURE11;
            _constMap["TEXTURE12"] = OpenGL.GL_TEXTURE12;
            _constMap["TEXTURE13"] = OpenGL.GL_TEXTURE13;
            _constMap["TEXTURE14"] = OpenGL.GL_TEXTURE14;
            _constMap["TEXTURE15"] = OpenGL.GL_TEXTURE15;
            _constMap["TEXTURE16"] = OpenGL.GL_TEXTURE16;
            _constMap["TEXTURE17"] = OpenGL.GL_TEXTURE17;
            _constMap["TEXTURE18"] = OpenGL.GL_TEXTURE18;
            _constMap["TEXTURE19"] = OpenGL.GL_TEXTURE19;
            _constMap["TEXTURE20"] = OpenGL.GL_TEXTURE20;
            _constMap["TEXTURE21"] = OpenGL.GL_TEXTURE21;
            _constMap["TEXTURE22"] = OpenGL.GL_TEXTURE22;
            _constMap["TEXTURE23"] = OpenGL.GL_TEXTURE23;
            _constMap["TEXTURE24"] = OpenGL.GL_TEXTURE24;
            _constMap["TEXTURE25"] = OpenGL.GL_TEXTURE25;
            _constMap["TEXTURE26"] = OpenGL.GL_TEXTURE26;
            _constMap["TEXTURE27"] = OpenGL.GL_TEXTURE27;
            _constMap["TEXTURE28"] = OpenGL.GL_TEXTURE28;
            _constMap["TEXTURE29"] = OpenGL.GL_TEXTURE29;
            _constMap["TEXTURE30"] = OpenGL.GL_TEXTURE30;
            _constMap["TEXTURE31"] = OpenGL.GL_TEXTURE31;
        }

        public int drawingBufferWidth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int drawingBufferHeight
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLCanvasElement canvas
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.WebGLUniformLocation getUniformLocation(Web.WebGLProgram program, string name)
        {
            var glUniformLocation = new GlUniformLocation(this.openGl.GetUniformLocation(program.Value, name));
            ErrorTest();
            return glUniformLocation;
        }

        public void bindTexture(int target, Web.WebGLTexture texture)
        {
            this.openGl.BindTexture((uint)target, texture != null ? texture.Value : 0);
            ErrorTest();
        }

        public void bufferData(int target, float[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
            ErrorTest();
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
            ErrorTest();
        }

        public void bufferData(int target, int size, int usage)
        {
            throw new NotImplementedException();
        }

        public void depthMask(bool flag)
        {
            this.openGl.DepthMask((byte)(flag ? 1 : 0));
            ErrorTest();
        }

        public object getUniform(Web.WebGLProgram program, Web.WebGLUniformLocation location)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3fv(int indx, Web.Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void linkProgram(Web.WebGLProgram program)
        {
            this.openGl.LinkProgram(program.Value);
            ErrorTest();
        }

        public BABYLON.Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
            this.openGl.BufferSubData((uint)target, offset, size, data);
        }

        public void bufferSubData(int target, int offset, float[] data)
        {
            throw new NotImplementedException();
        }

        public void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset)
        {
            this.openGl.VertexAttribPointer((uint)indx, size, (uint)type, normalized, stride, new IntPtr(offset));
            ErrorTest();
        }

        public void polygonOffset(int factor, int units)
        {
            throw new NotImplementedException();
        }

        public void blendColor(int red, int green, int blue, int alpha)
        {
            throw new NotImplementedException();
        }

        public Web.WebGLTexture createTexture()
        {
            var val = new uint[1];
            this.openGl.GenTextures(1, val);
            return new WebGLTextureAdapter(val[0]);

        }

        public void hint(int target, int mode)
        {
            throw new NotImplementedException();
        }

        public object getVertexAttrib(int index, int pname)
        {
            throw new NotImplementedException();
        }

        public void enableVertexAttribArray(int index)
        {
            this.openGl.EnableVertexAttribArray((uint)index);
            ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
            this.openGl.CullFace((uint)mode);
            ErrorTest();
        }

        public Web.WebGLFramebuffer createFramebuffer()
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
            this.openGl.UniformMatrix4(location.Value, value.Length / 16, transpose, value);
            ErrorTest();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, Web.Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void framebufferTexture2D(int target, int attachment, int textarget, Web.WebGLTexture texture, int level)
        {
            throw new NotImplementedException();
        }

        public void deleteFramebuffer(Web.WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public void colorMask(bool red, bool green, bool blue, bool alpha)
        {
            throw new NotImplementedException();
        }

        public void compressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, byte[] data)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix2fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix2fv(Web.WebGLUniformLocation location, bool transpose, Web.Float32Array value)
        {
            throw new NotImplementedException();
        }

        public object getExtension(string name)
        {
            return null;
        }

        public Web.WebGLProgram createProgram()
        {
            var glProgramAdapter = new GlProgramAdapter(this.openGl.CreateProgram());
            ErrorTest();
            return glProgramAdapter;
        }

        public void deleteShader(Web.WebGLShader shader)
        {
            this.openGl.DeleteShader(shader.Value);
            ErrorTest();
        }

        public BABYLON.Array<Web.WebGLShader> getAttachedShaders(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
            this.openGl.Enable((uint)cap);
            ErrorTest();
        }

        public void blendEquation(int mode)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, Web.HTMLImageElement image)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, Web.HTMLCanvasElement canvas)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, Web.HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, Web.ImageData pixels)
        {
            if (format == OpenGL.GL_RGBA)
            {
                format = (int)OpenGL.GL_BGRA;
            }

            this.openGl.TexImage2D((uint)target, level, (uint)internalformat, pixels.width, pixels.height, 0, (uint)format, (uint)type, pixels.dataBytes);
        }

        public Web.WebGLBuffer createBuffer()
        {
            uint[] buffers = new uint[1];
            this.openGl.GenBuffers(1, buffers);
            ErrorTest();
            return new GlBufferAdapter(buffers[0]);
        }

        public void deleteTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(Web.WebGLProgram program)
        {
            this.openGl.UseProgram(program.Value);
            ErrorTest();
        }

        public void vertexAttrib2fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2fv(int indx, Web.Float32Array values)
        {
            throw new NotImplementedException();
        }

        public int checkFramebufferStatus(int target)
        {
            throw new NotImplementedException();
        }

        public void frontFace(int mode)
        {
            throw new NotImplementedException();
        }

        public object getBufferParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(int target, int level, double xoffset, double yoffset, int width, int height, int format, int type, Web.ArrayBufferView pixels)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, Web.HTMLImageElement image)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, Web.HTMLCanvasElement canvas)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, Web.HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texSubImage2D(int target, int level, double xoffset, double yoffset, int format, int type, Web.ImageData pixels)
        {
            throw new NotImplementedException();
        }

        public void copyTexImage2D(int target, int level, int internalformat, double x, double y, int width, int height, int border)
        {
            throw new NotImplementedException();
        }

        public int getVertexAttribOffset(int index, int pname)
        {
            throw new NotImplementedException();
        }

        public void disableVertexAttribArray(int index)
        {
            this.openGl.DisableVertexAttribArray((uint)index);
        }

        public void blendFunc(int sfactor, int dfactor)
        {
            throw new NotImplementedException();
        }

        public void drawElements(int mode, int count, int type, int offset)
        {
            this.openGl.DrawElements((uint)mode, count, (uint)type, new IntPtr(offset));
            ErrorTest();
        }

        public bool isFramebuffer(Web.WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(Web.WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(Web.WebGLUniformLocation location, Web.Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void lineWidth(int width)
        {
            throw new NotImplementedException();
        }

        public string getShaderInfoLog(Web.WebGLShader shader)
        {
            var GL_INFO_LOG_LENGTH = 35716U;
            var GL_SHADING_LANGUAGE_VERSION = 35724U;
            var k = new int[1];
            this.openGl.GetShader(shader.Value, GL_INFO_LOG_LENGTH, k);
            if (k[0] == -1)
            {
                return string.Empty;
            }

            if (k[0] == 0)
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            result.Capacity = k[0];
            unsafe
            {
                fixed (void* p = k)
                {
                    this.openGl.GetShaderInfoLog(shader.Value, k[0], new IntPtr(p), result);
                }
            }

            var version = this.openGl.GetString(GL_SHADING_LANGUAGE_VERSION);

            result.AppendFormat("GL VERSION: {0}", version);

            return result.ToString();
        }

        public object getTexParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public object getParameter(int pname)
        {
            var i = new int[1];
            this.openGl.GetInteger((uint)pname, i);
            ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public Web.WebGLShaderPrecisionFormat getShaderPrecisionFormat(int shadertype, int precisiontype)
        {
            throw new NotImplementedException();
        }

        public Web.WebGLContextAttributes getContextAttributes()
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1f(int indx, double x)
        {
            throw new NotImplementedException();
        }

        public void bindFramebuffer(int target, Web.WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public void compressedTexSubImage2D(int target, int level, double xoffset, double yoffset, int width, int height, int format, Web.ArrayBufferView data)
        {
            throw new NotImplementedException();
        }

        public bool isContextLost()
        {
            throw new NotImplementedException();
        }

        public void uniform1iv(Web.WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform1iv(Web.WebGLUniformLocation location, Web.Int32Array v)
        {
            throw new NotImplementedException();
        }

        public object getRenderbufferParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public void uniform2fv(Web.WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2fv(Web.WebGLUniformLocation location, Web.Float32Array v)
        {
            throw new NotImplementedException();
        }

        public bool isTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public int getError()
        {
            throw new NotImplementedException();
        }

        public void shaderSource(Web.WebGLShader shader, string source)
        {
            this.openGl.ShaderSource(shader.Value, source);
            ErrorTest();
        }

        public void deleteRenderbuffer(Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void stencilMask(int mask)
        {
            throw new NotImplementedException();
        }

        public void bindBuffer(int target, Web.WebGLBuffer buffer)
        {
            this.openGl.BindBuffer((uint)target, buffer != null ? buffer.Value : 0);
            ErrorTest();
        }

        public int getAttribLocation(Web.WebGLProgram program, string name)
        {
            var attribLocation = this.openGl.GetAttribLocation(program.Value, name);
            ErrorTest();
            return attribLocation;
        }

        public void uniform3i(Web.WebGLUniformLocation location, int x, int y, int z)
        {
            throw new NotImplementedException();
        }

        public void blendEquationSeparate(int modeRGB, int modeAlpha)
        {
            throw new NotImplementedException();
        }

        public void clear(int mask)
        {
            this.openGl.Clear((uint)mask);
            ErrorTest();
        }

        public void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
        {
            this.openGl.BlendFuncSeparate((uint)srcRGB, (uint)dstRGB, (uint)srcAlpha, (uint)dstAlpha);
        }

        public void stencilFuncSeparate(int face, int func, int _ref, int mask)
        {
            throw new NotImplementedException();
        }

        public void readPixels(int x, int y, int width, int height, int format, int type, byte[] pixels)
        {
            this.openGl.ReadPixels(x, y, width, height, (uint)format, (uint)type, pixels);
            ErrorTest();
        }

        public void scissor(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform2i(Web.WebGLUniformLocation location, int x, int y)
        {
            throw new NotImplementedException();
        }

        public Web.WebGLActiveInfo getActiveAttrib(Web.WebGLProgram program, int index)
        {
            throw new NotImplementedException();
        }

        public string getShaderSource(Web.WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void generateMipmap(int target)
        {
            this.openGl.GenerateMipmapEXT((uint)target);
        }

        public void bindAttribLocation(Web.WebGLProgram program, int index, string name)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(Web.WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(Web.WebGLUniformLocation location, Web.Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(Web.WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(Web.WebGLUniformLocation location, Web.Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void stencilOp(int fail, double zfail, double zpass)
        {
            throw new NotImplementedException();
        }

        public void uniform4fv(Web.WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4fv(Web.WebGLUniformLocation location, Web.Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1fv(int indx, Web.Float32Array values)
        {
            throw new NotImplementedException();
        }

        public void flush()
        {
            throw new NotImplementedException();
        }

        public void uniform4f(Web.WebGLUniformLocation location, double x, double y, double z, double w)
        {
            this.openGl.Uniform4(location.Value, (float)x, (float)y, (float)z, (float)w);
            ErrorTest();
        }

        public void deleteProgram(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public bool isRenderbuffer(Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform1i(Web.WebGLUniformLocation location, int x)
        {
            this.openGl.Uniform1(location.Value, x);
            ErrorTest();
        }

        public object getProgramParameter(Web.WebGLProgram program, int pname)
        {
            var i = new int[1];
            this.openGl.GetProgram(program.Value, (uint)pname, i);
            ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public Web.WebGLActiveInfo getActiveUniform(Web.WebGLProgram program, int index)
        {
            throw new NotImplementedException();
        }

        public void stencilFunc(int func, int _ref, int mask)
        {
            throw new NotImplementedException();
        }

        public void pixelStorei(int pname, int param)
        {
            this.openGl.PixelStore((uint)pname, param);
            ErrorTest();
        }

        public void disable(int cap)
        {
            this.openGl.Disable((uint)cap);
        }

        public void vertexAttrib4fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib4fv(int indx, Web.Float32Array values)
        {
            throw new NotImplementedException();
        }

        public Web.WebGLRenderbuffer createRenderbuffer()
        {
            throw new NotImplementedException();
        }

        public bool isBuffer(Web.WebGLBuffer buffer)
        {
            throw new NotImplementedException();
        }

        public void stencilOpSeparate(int face, int fail, double zfail, double zpass)
        {
            throw new NotImplementedException();
        }

        public object getFramebufferAttachmentParameter(int target, int attachment, int pname)
        {
            throw new NotImplementedException();
        }

        public void uniform4i(Web.WebGLUniformLocation location, int x, int y, int z, int w)
        {
            throw new NotImplementedException();
        }

        public void sampleCoverage(int value, bool invert)
        {
            throw new NotImplementedException();
        }

        public void depthFunc(int func)
        {
            this.openGl.DepthFunc((uint)func);
            ErrorTest();
        }

        public void texParameterf(int target, int pname, float param)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib3f(int indx, double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public void drawArrays(int mode, int first, int count)
        {
            throw new NotImplementedException();
        }

        public void texParameteri(int target, int pname, int param)
        {
            this.openGl.TexParameter((uint)target, (uint)pname, param);
            ErrorTest();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public object getShaderParameter(Web.WebGLShader shader, int pname)
        {
            var i = new int[1];
            this.openGl.GetShader(shader.Value, (uint)pname, i);
            ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public void clearDepth(double depth)
        {
            this.openGl.ClearDepth(depth);
            ErrorTest();
        }

        public void activeTexture(int texture)
        {
            this.openGl.ActiveTexture((uint)texture);
        }

        public void viewport(int x, int y, int width, int height)
        {
            this.openGl.Viewport(x, y, width, height);
            ErrorTest();
        }

        public void detachShader(Web.WebGLProgram program, Web.WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void uniform1f(Web.WebGLUniformLocation location, double x)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix3fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix3fv(Web.WebGLUniformLocation location, bool transpose, Web.Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void deleteBuffer(Web.WebGLBuffer buffer)
        {
            this.openGl.DeleteBuffers(1, new uint[] { buffer.Value });
            ErrorTest();
        }

        public void copyTexSubImage2D(int target, int level, double xoffset, double yoffset, double x, double y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform3fv(Web.WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3fv(Web.WebGLUniformLocation location, Web.Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void stencilMaskSeparate(int face, int mask)
        {
            throw new NotImplementedException();
        }

        public void attachShader(Web.WebGLProgram program, Web.WebGLShader shader)
        {
            this.openGl.AttachShader(program.Value, shader.Value);
            ErrorTest();
        }

        public void compileShader(Web.WebGLShader shader)
        {
            this.openGl.CompileShader(shader.Value);
            ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
            this.openGl.ClearColor((float)red, (float)green, (float)blue, (float)alpha);
            ErrorTest();
        }

        public bool isShader(Web.WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void clearStencil(int s)
        {
            throw new NotImplementedException();
        }

        public void framebufferRenderbuffer(int target, int attachment, int renderbuffertarget, Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void finish()
        {
            throw new NotImplementedException();
        }

        public void uniform2f(Web.WebGLUniformLocation location, double x, double y)
        {
            this.openGl.Uniform2(location.Value, (float)x, (float)y);
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform3f(Web.WebGLUniformLocation location, double x, double y, double z)
        {
            this.openGl.Uniform3(location.Value, (float)x, (float)y, (float)z);
            ErrorTest();
        }

        public string getProgramInfoLog(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void validateProgram(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public bool isEnabled(int cap)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2f(int indx, double x, double y)
        {
            throw new NotImplementedException();
        }

        public bool isProgram(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public Web.WebGLShader createShader(int type)
        {
            var shader = this.openGl.CreateShader((uint)type);
            ErrorTest();
            return new GlShaderAdapter(shader);
        }

        public void bindRenderbuffer(int target, Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(Web.WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(Web.WebGLUniformLocation location, Web.Int32Array v)
        {
            throw new NotImplementedException();
        }

        public int this[string enumName]
        {
            get
            {
                return (int)this._constMap[enumName];
            }
        }

        [Conditional("DEBUG")]
        private void ErrorTest()
        {
            var error = this.openGl.GetErrorCode();
            if (error != ErrorCode.NoError)
            {
                var message = string.Format("Error : {0}, {1}", error, this.openGl.GetErrorDescription((uint)error));
                Debug.Fail(message);
            }
        }
    }
}
