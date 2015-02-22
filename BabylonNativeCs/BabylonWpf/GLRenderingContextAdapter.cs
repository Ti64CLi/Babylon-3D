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

    public class GlRenderingContextAdapter : WebGLRenderingContext
    {
        private readonly IDictionary<string, uint> _constMap = new Dictionary<string, uint>();
        private readonly OpenGL openGl;

        public GlRenderingContextAdapter(OpenGL openGl)
        {
            this.openGl = openGl;

            this._constMap["TEXTURE"] = OpenGL.GL_TEXTURE;
            this._constMap["TEXTURE0"] = OpenGL.GL_TEXTURE0;
            this._constMap["TEXTURE1"] = OpenGL.GL_TEXTURE1;
            this._constMap["TEXTURE2"] = OpenGL.GL_TEXTURE2;
            this._constMap["TEXTURE3"] = OpenGL.GL_TEXTURE3;
            this._constMap["TEXTURE4"] = OpenGL.GL_TEXTURE4;
            this._constMap["TEXTURE5"] = OpenGL.GL_TEXTURE5;
            this._constMap["TEXTURE6"] = OpenGL.GL_TEXTURE6;
            this._constMap["TEXTURE7"] = OpenGL.GL_TEXTURE7;
            this._constMap["TEXTURE8"] = OpenGL.GL_TEXTURE8;
            this._constMap["TEXTURE9"] = OpenGL.GL_TEXTURE9;
            this._constMap["TEXTURE10"] = OpenGL.GL_TEXTURE10;
            this._constMap["TEXTURE11"] = OpenGL.GL_TEXTURE11;
            this._constMap["TEXTURE12"] = OpenGL.GL_TEXTURE12;
            this._constMap["TEXTURE13"] = OpenGL.GL_TEXTURE13;
            this._constMap["TEXTURE14"] = OpenGL.GL_TEXTURE14;
            this._constMap["TEXTURE15"] = OpenGL.GL_TEXTURE15;
            this._constMap["TEXTURE16"] = OpenGL.GL_TEXTURE16;
            this._constMap["TEXTURE17"] = OpenGL.GL_TEXTURE17;
            this._constMap["TEXTURE18"] = OpenGL.GL_TEXTURE18;
            this._constMap["TEXTURE19"] = OpenGL.GL_TEXTURE19;
            this._constMap["TEXTURE20"] = OpenGL.GL_TEXTURE20;
            this._constMap["TEXTURE21"] = OpenGL.GL_TEXTURE21;
            this._constMap["TEXTURE22"] = OpenGL.GL_TEXTURE22;
            this._constMap["TEXTURE23"] = OpenGL.GL_TEXTURE23;
            this._constMap["TEXTURE24"] = OpenGL.GL_TEXTURE24;
            this._constMap["TEXTURE25"] = OpenGL.GL_TEXTURE25;
            this._constMap["TEXTURE26"] = OpenGL.GL_TEXTURE26;
            this._constMap["TEXTURE27"] = OpenGL.GL_TEXTURE27;
            this._constMap["TEXTURE28"] = OpenGL.GL_TEXTURE28;
            this._constMap["TEXTURE29"] = OpenGL.GL_TEXTURE29;
            this._constMap["TEXTURE30"] = OpenGL.GL_TEXTURE30;
            this._constMap["TEXTURE31"] = OpenGL.GL_TEXTURE31;
        }

        public int drawingBufferWidth
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public int drawingBufferHeight
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public HTMLCanvasElement canvas
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public WebGLUniformLocation getUniformLocation(WebGLProgram program, string name)
        {
            var glUniformLocation = new GlUniformLocation(this.openGl.GetUniformLocation(program.Value, name));
            this.ErrorTest();
            return glUniformLocation;
        }

        public void bindTexture(int target, WebGLTexture texture)
        {
            this.openGl.BindTexture((uint)target, texture != null ? texture.Value : 0);
            this.ErrorTest();
        }

        public void bufferData(int target, float[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
            this.ErrorTest();
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
            this.ErrorTest();
        }

        public void bufferData(int target, int size, int usage)
        {
            this.openGl.BufferData((uint)target, size, new IntPtr(0), (uint)usage);
            this.ErrorTest();
        }

        public void depthMask(bool flag)
        {
            this.openGl.DepthMask((byte)(flag ? 1 : 0));
            this.ErrorTest();
        }

        public object getUniform(WebGLProgram program, WebGLUniformLocation location)
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

        public void linkProgram(WebGLProgram program)
        {
            this.openGl.LinkProgram(program.Value);
            this.ErrorTest();
        }

        public Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
            this.openGl.BufferSubData((uint)target, offset, size, data);
            this.ErrorTest();
        }

        public void bufferSubData(int target, int offset, float[] data)
        {
            unsafe
            {
                fixed (void* p = data)
                {
                    this.openGl.BufferSubData((uint)target, offset, data.Length * sizeof (float), new IntPtr(p));
                }
            }

            this.ErrorTest();
        }

        public void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset)
        {
            this.openGl.VertexAttribPointer((uint)indx, size, (uint)type, normalized, stride, new IntPtr(offset));
            this.ErrorTest();
        }

        public void polygonOffset(int factor, int units)
        {
            throw new NotImplementedException();
        }

        public void blendColor(int red, int green, int blue, int alpha)
        {
            throw new NotImplementedException();
        }

        public WebGLTexture createTexture()
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
            this.ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
            this.openGl.CullFace((uint)mode);
            this.ErrorTest();
        }

        public WebGLFramebuffer createFramebuffer()
        {
            var buffers = new uint[1];
            this.openGl.GenFramebuffersEXT(1, buffers);
            this.ErrorTest();
            return new GlFramebufferAdapter(buffers[0]);
        }

        public void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
            this.openGl.UniformMatrix4(location.Value, value.Length / 16, transpose, value);
            this.ErrorTest();
        }

        public void framebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level)
        {
            this.openGl.FramebufferTexture2DEXT(
                (uint)target,
                (uint)attachment,
                (uint)textarget,
                texture != null ? texture.Value : 0,
                level);
            this.ErrorTest();
        }

        public void deleteFramebuffer(WebGLFramebuffer framebuffer)
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

        public void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix2fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
        }

        public object getExtension(string name)
        {
            if (name == "OES_standard_derivatives")
            {
                var ext = this.openGl.GetExtensionsStringARB();
                //return ext.Contains(name) ? new object() : null;
                return new object();
            }

            // return interfase of extention (TODO: implement)
            return null;
        }

        public WebGLProgram createProgram()
        {
            var glProgramAdapter = new GlProgramAdapter(this.openGl.CreateProgram());
            this.ErrorTest();
            return glProgramAdapter;
        }

        public void deleteShader(WebGLShader shader)
        {
            this.openGl.DeleteShader(shader.Value);
            this.ErrorTest();
        }

        public Array<WebGLShader> getAttachedShaders(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
            this.openGl.Enable((uint)cap);
            this.ErrorTest();
        }

        public void blendEquation(int mode)
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
            this.openGl.TexImage2D(
                (uint)target,
                level,
                (uint)internalformat,
                width,
                height,
                border,
                (uint)format,
                (uint)type,
                pixels);
            this.ErrorTest();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement image)
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

        public void texImage2D(int target, int level, int internalformat, int format, int type, HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, ImageData pixels)
        {
            if (format == OpenGL.GL_RGBA)
            {
                format = (int)OpenGL.GL_BGRA;
            }

            this.openGl.TexImage2D(
                (uint)target,
                level,
                (uint)internalformat,
                pixels.width,
                pixels.height,
                0,
                (uint)format,
                (uint)type,
                pixels.dataBytes);
        }

        public WebGLBuffer createBuffer()
        {
            var buffers = new uint[1];
            this.openGl.GenBuffers(1, buffers);
            this.ErrorTest();
            return new GlBufferAdapter(buffers[0]);
        }

        public void deleteTexture(WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(WebGLProgram program)
        {
            this.openGl.UseProgram(program.Value);
            this.ErrorTest();
        }

        public void vertexAttrib2fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib2fv(int indx, Float32Array values)
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
            this.ErrorTest();
        }

        public bool isFramebuffer(WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void lineWidth(int width)
        {
            throw new NotImplementedException();
        }

        public string getShaderInfoLog(WebGLShader shader)
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
            this.ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public WebGLShaderPrecisionFormat getShaderPrecisionFormat(int shadertype, int precisiontype)
        {
            throw new NotImplementedException();
        }

        public WebGLContextAttributes getContextAttributes()
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib1f(int indx, double x)
        {
            throw new NotImplementedException();
        }

        public void bindFramebuffer(int target, WebGLFramebuffer framebuffer)
        {
            this.openGl.BindFramebufferEXT((uint)target, framebuffer != null ? framebuffer.Value : 0);
            this.ErrorTest();
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

        public bool isContextLost()
        {
            throw new NotImplementedException();
        }

        public void uniform1iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform1iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public object getRenderbufferParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public void uniform2fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public bool isTexture(WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public int getError()
        {
            throw new NotImplementedException();
        }

        public void shaderSource(WebGLShader shader, string source)
        {
            this.openGl.ShaderSource(shader.Value, source);
            this.ErrorTest();
        }

        public void deleteRenderbuffer(WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void stencilMask(int mask)
        {
            throw new NotImplementedException();
        }

        public void bindBuffer(int target, WebGLBuffer buffer)
        {
            this.openGl.BindBuffer((uint)target, buffer != null ? buffer.Value : 0);
            this.ErrorTest();
        }

        public int getAttribLocation(WebGLProgram program, string name)
        {
            var attribLocation = this.openGl.GetAttribLocation(program.Value, name);
            this.ErrorTest();
            return attribLocation;
        }

        public void uniform3i(WebGLUniformLocation location, int x, int y, int z)
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
            this.ErrorTest();
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
            this.ErrorTest();
        }

        public void scissor(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform2i(WebGLUniformLocation location, int x, int y)
        {
            throw new NotImplementedException();
        }

        public WebGLActiveInfo getActiveAttrib(WebGLProgram program, int index)
        {
            throw new NotImplementedException();
        }

        public string getShaderSource(WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void generateMipmap(int target)
        {
            this.openGl.GenerateMipmapEXT((uint)target);
        }

        public void bindAttribLocation(WebGLProgram program, int index, string name)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform1fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform2iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public void stencilOp(int fail, double zfail, double zpass)
        {
            throw new NotImplementedException();
        }

        public void uniform4fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4fv(WebGLUniformLocation location, Float32Array v)
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

        public void flush()
        {
            throw new NotImplementedException();
        }

        public void uniform4f(WebGLUniformLocation location, double x, double y, double z, double w)
        {
            this.openGl.Uniform4(location.Value, (float)x, (float)y, (float)z, (float)w);
            this.ErrorTest();
        }

        public void deleteProgram(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public bool isRenderbuffer(WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform1i(WebGLUniformLocation location, int x)
        {
            this.openGl.Uniform1(location.Value, x);
            this.ErrorTest();
        }

        public object getProgramParameter(WebGLProgram program, int pname)
        {
            var i = new int[1];
            this.openGl.GetProgram(program.Value, (uint)pname, i);
            this.ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public WebGLActiveInfo getActiveUniform(WebGLProgram program, int index)
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
            this.ErrorTest();
        }

        public void disable(int cap)
        {
            this.openGl.Disable((uint)cap);
        }

        public void vertexAttrib4fv(int indx, float[] values)
        {
            throw new NotImplementedException();
        }

        public void vertexAttrib4fv(int indx, Float32Array values)
        {
            throw new NotImplementedException();
        }

        public WebGLRenderbuffer createRenderbuffer()
        {
            var buffers = new uint[1];
            this.openGl.GenRenderbuffersEXT(1, buffers);
            this.ErrorTest();
            return new GlRenderbufferAdapter(buffers[0]);
        }

        public bool isBuffer(WebGLBuffer buffer)
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

        public void uniform4i(WebGLUniformLocation location, int x, int y, int z, int w)
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
            this.ErrorTest();
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
            this.ErrorTest();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public object getShaderParameter(WebGLShader shader, int pname)
        {
            var i = new int[1];
            this.openGl.GetShader(shader.Value, (uint)pname, i);
            this.ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public void clearDepth(double depth)
        {
            this.openGl.ClearDepth(depth);
            this.ErrorTest();
        }

        public void activeTexture(int texture)
        {
            this.openGl.ActiveTexture((uint)texture);
        }

        public void viewport(int x, int y, int width, int height)
        {
            this.openGl.Viewport(x, y, width, height);
            this.ErrorTest();
        }

        public void detachShader(WebGLProgram program, WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void uniform1f(WebGLUniformLocation location, double x)
        {
            this.openGl.Uniform1(location.Value, (float)x);
        }

        public void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix3fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
        }

        public void deleteBuffer(WebGLBuffer buffer)
        {
            this.openGl.DeleteBuffers(1, new[] { buffer.Value });
            this.ErrorTest();
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

        public void uniform3fv(WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform3fv(WebGLUniformLocation location, Float32Array v)
        {
            throw new NotImplementedException();
        }

        public void stencilMaskSeparate(int face, int mask)
        {
            throw new NotImplementedException();
        }

        public void attachShader(WebGLProgram program, WebGLShader shader)
        {
            this.openGl.AttachShader(program.Value, shader.Value);
            this.ErrorTest();
        }

        public void compileShader(WebGLShader shader)
        {
            this.openGl.CompileShader(shader.Value);
            this.ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
            this.openGl.ClearColor((float)red, (float)green, (float)blue, (float)alpha);
            this.ErrorTest();
        }

        public bool isShader(WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void clearStencil(int s)
        {
            throw new NotImplementedException();
        }

        public void framebufferRenderbuffer(
            int target,
            int attachment,
            int renderbuffertarget,
            WebGLRenderbuffer renderbuffer)
        {
            this.openGl.FramebufferRenderbufferEXT((uint)target, (uint)attachment, (uint)renderbuffertarget, renderbuffer.Value);
        }

        public void finish()
        {
            throw new NotImplementedException();
        }

        public void uniform2f(WebGLUniformLocation location, double x, double y)
        {
            this.openGl.Uniform2(location.Value, (float)x, (float)y);
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            this.openGl.RenderbufferStorageEXT((uint)target, (uint)internalformat, width, height);
        }

        public void uniform3f(WebGLUniformLocation location, double x, double y, double z)
        {
            this.openGl.Uniform3(location.Value, (float)x, (float)y, (float)z);
            this.ErrorTest();
        }

        public string getProgramInfoLog(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void validateProgram(WebGLProgram program)
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

        public bool isProgram(WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public WebGLShader createShader(int type)
        {
            var shader = this.openGl.CreateShader((uint)type);
            this.ErrorTest();
            return new GlShaderAdapter(shader);
        }

        public void bindRenderbuffer(int target, WebGLRenderbuffer renderbuffer)
        {
            this.openGl.BindRenderbufferEXT((uint)target, renderbuffer != null ? renderbuffer.Value : 0);
            this.ErrorTest();
        }

        public void uniform4iv(WebGLUniformLocation location, int[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(WebGLUniformLocation location, Int32Array v)
        {
            throw new NotImplementedException();
        }

        public int this[string enumName]
        {
            get { return (int)this._constMap[enumName]; }
        }

        public void uniformMatrix4fv(WebGLUniformLocation location, bool transpose, Float32Array value)
        {
            throw new NotImplementedException();
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