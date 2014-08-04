using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    class GLRenderingContextAdapter : Web.WebGLRenderingContext
    {
        private SharpGL.OpenGL openGl;

        public GLRenderingContextAdapter(SharpGL.OpenGL openGl)
        {
            this.openGl = openGl;
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
            throw new NotImplementedException();
        }

        public void bindTexture(int target, Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void bufferData(int target, float[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
            this.openGl.BufferData((uint)target, data, (uint)usage);
        }

        public void bufferData(int target, int size, int usage)
        {
            throw new NotImplementedException();
        }

        public void depthMask(bool flag)
        {
            this.openGl.DepthMask((byte)(flag ? 1 : 0));
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
            this.openGl.CullFace((uint)mode);
        }

        public Web.WebGLFramebuffer createFramebuffer()
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void deleteShader(Web.WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public BABYLON.Array<Web.WebGLShader> getAttachedShaders(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
            this.openGl.Enable((uint)cap);
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
            throw new NotImplementedException();
        }

        public Web.WebGLBuffer createBuffer()
        {
            uint[] buffers = new uint[1];
            this.openGl.GenBuffers(1, buffers);
            return new WebGLBufferAdapter(buffers[0]);
        }

        public void deleteTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void blendFunc(int sfactor, int dfactor)
        {
            throw new NotImplementedException();
        }

        public void drawElements(int mode, int count, int type, int offset)
        {
            throw new NotImplementedException();
        }

        public bool isFramebuffer(Web.WebGLFramebuffer framebuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform3iv(Web.WebGLUniformLocation location, float[] v)
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
            throw new NotImplementedException();
        }

        public object getTexParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public object getParameter(int pname)
        {
            var ints = new int[1];
            this.openGl.GetInteger((uint)pname, ints);
            return ints[0];
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

        public void uniform1iv(Web.WebGLUniformLocation location, float[] v)
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
            throw new NotImplementedException();
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
        }

        public int getAttribLocation(Web.WebGLProgram program, string name)
        {
            throw new NotImplementedException();
        }

        public void uniform3i(Web.WebGLUniformLocation location, double x, double y, double z)
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
        }

        public void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
        {
            throw new NotImplementedException();
        }

        public void stencilFuncSeparate(int face, int func, int _ref, int mask)
        {
            throw new NotImplementedException();
        }

        public void readPixels(int x, int y, int width, int height, int format, int type, byte[] pixels)
        {
            this.openGl.ReadPixels(x, y, width, height, (uint)format, (uint)type, pixels);
        }

        public void scissor(int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform2i(Web.WebGLUniformLocation location, double x, double y)
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
            throw new NotImplementedException();
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

        public void uniform2iv(Web.WebGLUniformLocation location, float[] v)
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
            throw new NotImplementedException();
        }

        public void deleteProgram(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public bool isRenderbuffer(Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform1i(Web.WebGLUniformLocation location, double x)
        {
            throw new NotImplementedException();
        }

        public object getProgramParameter(Web.WebGLProgram program, int pname)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void disable(int cap)
        {
            throw new NotImplementedException();
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

        public void uniform4i(Web.WebGLUniformLocation location, double x, double y, double z, double w)
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
            throw new NotImplementedException();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public object getShaderParameter(Web.WebGLShader shader, int pname)
        {
            throw new NotImplementedException();
        }

        public void clearDepth(double depth)
        {
            this.openGl.ClearDepth(depth);
        }

        public void activeTexture(int texture)
        {
            throw new NotImplementedException();
        }

        public void viewport(int x, int y, int width, int height)
        {
            this.openGl.Viewport(x, y, width, height);
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
            throw new NotImplementedException();
        }

        public void compileShader(Web.WebGLShader shader)
        {
            throw new NotImplementedException();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
            this.openGl.ClearColor((float)red, (float)green, (float)blue, (float)alpha);
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
            throw new NotImplementedException();
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform3f(Web.WebGLUniformLocation location, double x, double y, double z)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void bindRenderbuffer(int target, Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(Web.WebGLUniformLocation location, float[] v)
        {
            throw new NotImplementedException();
        }

        public void uniform4iv(Web.WebGLUniformLocation location, Web.Int32Array v)
        {
            throw new NotImplementedException();
        }

        public int this[string enumName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
