namespace BabylonWpf
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;

    public class GlRenderingContextAdapter : Web.WebGLRenderingContext
    {
        public const int GL_NO_ERROR = 0;

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern int glGetUniformLocation(uint program, char[] name);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glBufferData(int target, int size, void* data, int usage);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthMask(byte flag);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glLinkProgram(uint program);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glBufferSubData(int target, int offset, int size, void* data);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glVertexAttribPointer(uint index, int size, int type, byte normalized, int stride, void* pointer);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glEnableVertexAttribArray(uint index);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glCullFace(int mode);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glUniformMatrix4fv(int location, int count, byte transpose, float[] value);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern uint glCreateProgram();

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDeleteShader(uint shader);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glEnable(int cap);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGenBuffers(int n, uint[] buffers);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glUseProgram(uint program);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glDrawElements(int mode, int count, int type, void* indices);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGetShaderiv(uint shader, int pname, int[] @params);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] glGetString(int name);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGetShaderInfoLog(uint shader, int maxLength, int[] length, char[] infoLog);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGetIntegerv(int pname, int[] @params);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glShaderSource(uint shader, int count, char[] @string, int[] length);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glBindBuffer(int target, int buffer);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern int glGetAttribLocation(uint program, char[] name);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glReadPixels(int x, int y, int width, int height, int format, int type, byte[] data);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glClear(int mode);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glUniform4f(int location, float x, float y, float z, float w);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glUniform1i(int location, int x);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGetProgramiv(uint program, int pname, int[] @params);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthFunc(int func);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glClearDepthf(float depth);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glViewport(int x, int y, int width, int height);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDeleteBuffers(int n, uint[] buffers);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glAttachShader(uint program, uint shader);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glCompileShader(uint shader);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glClearColor(float red, float green, float blue, float alpha);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glUniform3f(int location, float x, float y, float z);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern uint glCreateShader(int shaderType);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern int glGetError();

        public GlRenderingContextAdapter()
        {
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
            var glUniformLocation = new GlUniformLocation(glGetUniformLocation(program.Value, name.ToCharArray()));
            ErrorTest();
            return glUniformLocation;
        }

        public void bindTexture(int target, Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void bufferData(int target, float[] data, int usage)
        {
            unsafe
            {
                fixed (void* pdata = data)
                {
                    glBufferData(target, data.Length * sizeof(float), pdata, usage);
                }
            }

            ErrorTest();
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
            unsafe
            {
                fixed (void* pdata = data)
                {
                    glBufferData(target, data.Length * sizeof(ushort), pdata, usage);
                }
            }

            ErrorTest();
        }

        public void bufferData(int target, int size, int usage)
        {
            throw new NotImplementedException();
        }

        public void depthMask(bool flag)
        {
            glDepthMask((byte)(flag ? 1 : 0));
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
            glLinkProgram(program.Value);
            ErrorTest();
        }

        public BABYLON.Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
            unsafe
            {
                glBufferSubData(target, offset, size, data.ToPointer());
            }
        }

        public void bufferSubData(int target, int offset, float[] data)
        {
            throw new NotImplementedException();
        }

        public void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset)
        {
            unsafe
            {
                glVertexAttribPointer((uint)indx, size, type, (byte)(normalized ? 1 : 0), stride, new IntPtr(offset).ToPointer());
            }

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
            glEnableVertexAttribArray((uint)index);
            ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
            glCullFace(mode);
            ErrorTest();
        }

        public Web.WebGLFramebuffer createFramebuffer()
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
            glUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), value);
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
            var glProgramAdapter = new GlProgramAdapter((uint)glCreateProgram());
            ErrorTest();
            return glProgramAdapter;
        }

        public void deleteShader(Web.WebGLShader shader)
        {
            glDeleteShader(shader.Value);
            ErrorTest();
        }

        public BABYLON.Array<Web.WebGLShader> getAttachedShaders(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
            glEnable(cap);
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
            throw new NotImplementedException();
        }

        public Web.WebGLBuffer createBuffer()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            ErrorTest();
            return new GlBufferAdapter(buffers[0]);
        }

        public void deleteTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(Web.WebGLProgram program)
        {
            glUseProgram(program.Value);
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
            throw new NotImplementedException();
        }

        public void blendFunc(int sfactor, int dfactor)
        {
            throw new NotImplementedException();
        }

        public void drawElements(int mode, int count, int type, int offset)
        {
            unsafe
            {
                glDrawElements(mode, count, type, new IntPtr(offset).ToPointer());
            }

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
            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            var k = new int[1];
            glGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, k);
            if (k[0] == -1)
            {
                return string.Empty;
            }

            if (k[0] == 0)
            {
                return string.Empty;
            }

            var result = new char[k[0]];
            glGetShaderInfoLog(shader.Value, k[0], k, result);

            ////var version = glGetString(GL_SHADING_LANGUAGE_VERSION);

            return result.ToString();
        }

        public object getTexParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public object getParameter(int pname)
        {
            var i = new int[1];
            glGetIntegerv(pname, i);
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
            var chars = source.ToCharArray();
            var len = new int[1];
            len[0] = chars.Length;
            glShaderSource(shader.Value, 1, chars, len);
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
            glBindBuffer(target, (int)(buffer != null ? buffer.Value : 0));
            ErrorTest();
        }

        public int getAttribLocation(Web.WebGLProgram program, string name)
        {
            var attribLocation = glGetAttribLocation(program.Value, name.ToCharArray());
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
            glClear(mask);
            ErrorTest();
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
            glReadPixels(x, y, width, height, format, type, pixels);
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
            glUniform4f((int)location.Value, (float)x, (float)y, (float)z, (float)w);
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
            glUniform1i(location.Value, x);
            ErrorTest();
        }

        public object getProgramParameter(Web.WebGLProgram program, int pname)
        {
            var i = new int[1];
            glGetProgramiv(program.Value, pname, i);
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
            glDepthFunc(func);
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
            throw new NotImplementedException();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public object getShaderParameter(Web.WebGLShader shader, int pname)
        {
            var i = new int[1];
            glGetShaderiv(shader.Value, pname, i);
            ErrorTest();
            return i[0] == 0 ? (object)null : i[0];
        }

        public void clearDepth(double depth)
        {
            glClearDepthf((float)depth);
            ErrorTest();
        }

        public void activeTexture(int texture)
        {
            throw new NotImplementedException();
        }

        public void viewport(int x, int y, int width, int height)
        {
            glViewport(x, y, width, height);
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
            glDeleteBuffers(1, new uint[] { buffer.Value });
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
            glAttachShader(program.Value, shader.Value);
            ErrorTest();
        }

        public void compileShader(Web.WebGLShader shader)
        {
            glCompileShader(shader.Value);
            ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
            glClearColor((float)red, (float)green, (float)blue, (float)alpha);
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
            throw new NotImplementedException();
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform3f(Web.WebGLUniformLocation location, double x, double y, double z)
        {
            glUniform3f((int)location.Value, (float)x, (float)y, (float)z);
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
            var shader = (uint)glCreateShader(type);
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
            get { throw new NotImplementedException(); }
        }

        private void ErrorTest()
        {
#if DEBUG
            var error = glGetError();
            if (error != GL_NO_ERROR)
            {
                Console.WriteLine("GL Error {0}", error);
            }
#endif
        }
    }
}
