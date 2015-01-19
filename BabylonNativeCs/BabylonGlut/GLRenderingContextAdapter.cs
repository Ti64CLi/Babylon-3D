<<<<<<< HEAD
﻿namespace BabylonWpf
{
    using BabylonGlut;
=======
﻿namespace BabylonGlut
{
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

<<<<<<< HEAD
=======
    using BABYLON;

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
    public class GlRenderingContextAdapter : Web.WebGLRenderingContext
    {
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
<<<<<<< HEAD
            var glUniformLocation = new GlUniformLocation(Gl.__glewGetUniformLocation(program.Value, Encoding.ASCII.GetBytes(name)));
            ErrorTest();
=======
            Log.Info(string.Format("getUniformLocation {0} {1}", (int)program.Value, name));

            var bytes = Encoding.ASCII.GetBytes(name);
            GlUniformLocation glUniformLocation = null;
            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
                    glUniformLocation = new GlUniformLocation(Gl.__glewGetUniformLocation(program.Value, b));
                }
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", glUniformLocation.Value));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            return glUniformLocation;
        }

        public void bindTexture(int target, Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void bufferData(int target, float[] data, int usage)
        {
<<<<<<< HEAD
            unsafe
            {
                fixed (void* pdata = data)
=======
            Log.Info(string.Format("bufferData float {0} Count:{1} Len:{2} {3}", target, data.Length, data.Length * sizeof(float), usage));

            unsafe
            {
                fixed (void* pdata = &data[0])
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
                {
                    Gl.__glewBufferData(target, data.Length * sizeof(float), pdata, usage);
                }
            }

            ErrorTest();
        }

        public void bufferData(int target, ushort[] data, int usage)
        {
<<<<<<< HEAD
            unsafe
            {
                fixed (void* pdata = data)
=======
            Log.Info(string.Format("bufferData ushort {0} Count:{1} Len:{2} {3}", target, data.Length, data.Length * sizeof(ushort), usage));

            unsafe
            {
                fixed (void* pdata = &data[0])
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
                {
                    Gl.__glewBufferData(target, data.Length * sizeof(ushort), pdata, usage);
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("depthMask {0}", flag));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glDepthMask((byte)(flag ? 1 : 0));
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("linkProgram {0}", program.Value));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewLinkProgram(program.Value);
            ErrorTest();
        }

        public BABYLON.Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("bufferSubData {0} {1} {2}", target, offset, size));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            unsafe
            {
                Gl.__glewBufferSubData(target, offset, size, data.ToPointer());
            }
        }

        public void bufferSubData(int target, int offset, float[] data)
        {
            throw new NotImplementedException();
        }

        public void vertexAttribPointer(int indx, int size, int type, bool normalized, int stride, int offset)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("vertexAttribPointer {0} {1} {2} {3} {4} {5}", indx, size, type, normalized, stride, offset));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            unsafe
            {
                Gl.__glewVertexAttribPointer((uint)indx, size, type, (byte)(normalized ? 1 : 0), stride, new IntPtr(offset).ToPointer());
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("enableVertexAttribArray {0}", index));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewEnableVertexAttribArray((uint)index);
            ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("cullFace {0}", mode));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glCullFace(mode);
            ErrorTest();
        }

        public Web.WebGLFramebuffer createFramebuffer()
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
<<<<<<< HEAD
            Gl.__glewUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), value);
=======
            Log.Info(string.Format("uniformMatrix4fv {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}", location.Value, transpose
                , value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11], value[12], value[13], value[14], value[15]));

            unsafe
            {
                fixed (float* pvalue = &value[0])
                {
                    Gl.__glewUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), pvalue);
                }
            }

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
            var glProgramAdapter = new GlProgramAdapter(Gl.__glewCreateProgram());
            ErrorTest();
=======
            Log.Info("createProgram");

            var glProgramAdapter = new GlProgramAdapter(Gl.__glewCreateProgram());
            ErrorTest();

            Log.Info(string.Format("value {0}", glProgramAdapter.Value));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            return glProgramAdapter;
        }

        public void deleteShader(Web.WebGLShader shader)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("deleteShader", shader.Value));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewDeleteShader(shader.Value);
            ErrorTest();
        }

        public BABYLON.Array<Web.WebGLShader> getAttachedShaders(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("enable {0}", cap));
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glEnable(cap);
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
<<<<<<< HEAD
            uint[] buffers = new uint[1];
            Gl.__glewGenBuffers(1, buffers);
            ErrorTest();
            return new GlBufferAdapter(buffers[0]);
=======
            Log.Info("createBuffer");

            uint bufferId;
            unsafe
            {
                Gl.__glewGenBuffers(1, &bufferId);
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", (int)bufferId));

            return new GlBufferAdapter(bufferId);
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
        }

        public void deleteTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(Web.WebGLProgram program)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("useProgram {0}", program.Value));
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewUseProgram(program.Value);
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("drawElements {0} {1} {2} {3}", mode, count, type, offset));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glDrawElements(mode, count, type, offset);
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
<<<<<<< HEAD
            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            var k = new int[1];
            Gl.__glewGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, k);
            if (k[0] == -1)
            {
                return string.Empty;
            }

            if (k[0] == 0)
=======
            Log.Info("getShaderInfoLog");

            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
                Gl.__glewGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, &k);
            }
            if (k <= 0)
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            {
                return string.Empty;
            }

<<<<<<< HEAD
            var result = new byte[k[0]];
            Gl.__glewGetShaderInfoLog(shader.Value, k[0], k, result);
=======
            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = &result[0])
                {
                    Gl.__glewGetShaderInfoLog(shader.Value, k, &k, presult);
                }
            }
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

            ////var version = glGetString(GL_SHADING_LANGUAGE_VERSION);

            return new string(Encoding.ASCII.GetChars(result));
        }

        public object getTexParameter(int target, int pname)
        {
            throw new NotImplementedException();
        }

        public object getParameter(int pname)
        {
<<<<<<< HEAD
            var i = new int[1];
            Gl.glGetIntegerv(pname, i);
            ErrorTest();
            return i[0];
=======
            Log.Info(string.Format("getParameter {0}", pname));

            int i;
            unsafe
            {
                Gl.glGetIntegerv(pname, &i);
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", i));

            return i;
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
            return Gl.glGetError();
        }

        public void shaderSource(Web.WebGLShader shader, string source)
        {
<<<<<<< HEAD
            var bytes = Encoding.ASCII.GetBytes(source);

            var len = new int[] { bytes.Length };
            var bytesOfBytes = new byte[][] { bytes };

            Gl.__glewShaderSource(shader.Value, 1, bytesOfBytes, len);
=======
            Log.Info(string.Format("shaderSource {0}, source length {1}", shader.Value, source.Length));

            var bytes = Encoding.ASCII.GetBytes(source);
            var len = bytes.Length;

            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
                    byte*[] barray = new byte*[] { b };
                    fixed (byte** pb = &barray[0])
                    {
                        Gl.__glewShaderSource(shader.Value, 1, pb, &len);
                    }
                }
            }
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

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
<<<<<<< HEAD
            Gl.__glewBindBuffer(target, (int)(buffer != null ? buffer.Value : 0));
=======
            var bufferId = (int)(buffer != null ? buffer.Value : 0);

            Log.Info(string.Format("bindBuffer {0} {1}", target, bufferId));

            Gl.__glewBindBuffer(target, bufferId);
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            ErrorTest();
        }

        public int getAttribLocation(Web.WebGLProgram program, string name)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("getAttribLocation {0} {1}", program.Value, name));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            var chars = name.ToCharArray();

            var bytes = new byte[chars.Length];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)chars[i];
            }

<<<<<<< HEAD
            var attribLocation = Gl.__glewGetAttribLocation(program.Value, bytes);
            ErrorTest();
=======
            var attribLocation = -1;
            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
                    attribLocation = Gl.__glewGetAttribLocation(program.Value, b);
                }
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", attribLocation));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("clear {0}", mask));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glClear(mask);
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
<<<<<<< HEAD
            Gl.glReadPixels(x, y, width, height, format, type, pixels);
=======
            Log.Info(string.Format("readPixels {0} {1} {2} {3} {4} {5}", x, y, width, height, format, type));

            unsafe
            {
                fixed (byte* ppixels = &pixels[0])
                {
                    Gl.glReadPixels(x, y, width, height, format, type, ppixels);
                }
            }

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("uniform4f {0} {1} {2} {3} {4}", location.Value, x, y, z, w));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewUniform4f((int)location.Value, (float)x, (float)y, (float)z, (float)w);
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("uniform1i {0} {1}", location.Value, x));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewUniform1i(location.Value, x);
            ErrorTest();
        }

        public object getProgramParameter(Web.WebGLProgram program, int pname)
        {
<<<<<<< HEAD
            var i = new int[1];
            Gl.__glewGetProgramiv(program.Value, pname, i);
            ErrorTest();
            return i[0];
=======
            Log.Info(string.Format("getProgramParameter {0} {1}", program.Value, pname));

            int i;
            unsafe
            {
                Gl.__glewGetProgramiv(program.Value, pname, &i);
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", i));

            return i;
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("depthFunc {0}", func));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glDepthFunc(func);
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
<<<<<<< HEAD
            var i = new int[1];
            Gl.__glewGetShaderiv(shader.Value, pname, i);
            ErrorTest();
            return i[0];
=======
            Log.Info(string.Format("getShaderParameter {0} {1}", shader.Value, pname));

            int i;
            unsafe
            {
                Gl.__glewGetShaderiv(shader.Value, pname, &i);
            }

            ErrorTest();

            Log.Info(string.Format("value {0}", i));

            return i;
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
        }

        public void clearDepth(double depth)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("clearDepth {0}", depth));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glClearDepth(depth);
            ErrorTest();
        }

        public void activeTexture(int texture)
        {
            throw new NotImplementedException();
        }

        public void viewport(int x, int y, int width, int height)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("viewport {0} {1} {2} {3}", x, y, width, height));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glViewport(x, y, width, height);
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
<<<<<<< HEAD
            Gl.__glewDeleteBuffers(1, new uint[] { buffer.Value });
=======
            Log.Info(string.Format("deleteBuffer {0}", buffer.Value));
            var value = buffer.Value;
            unsafe
            {
                Gl.__glewDeleteBuffers(1, &value);
            }

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("attachShader {0} {1}", program.Value, shader.Value));
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewAttachShader(program.Value, shader.Value);
            ErrorTest();
        }

        public void compileShader(Web.WebGLShader shader)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("compileShader {0}", shader.Value));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewCompileShader(shader.Value);
            ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
<<<<<<< HEAD
=======
            Log.Info(string.Format("clearColor {0} {1} {2} {3}", red, green, blue, alpha));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.glClearColor((float)red, (float)green, (float)blue, (float)alpha);
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("uniform3f {0} {1} {2} {3}", location.Value, x, y, z));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            Gl.__glewUniform3f((int)location.Value, (float)x, (float)y, (float)z);
            ErrorTest();
        }

        public string getProgramInfoLog(Web.WebGLProgram program)
        {
<<<<<<< HEAD
            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            var k = new int[1];
            Gl.__glewGetProgramiv(program.Value, GL_INFO_LOG_LENGTH, k);
            if (k[0] == -1)
            {
                return string.Empty;
            }

            if (k[0] == 0)
=======
            Log.Info(string.Format("getProgramInfoLog {0}", program.Value));

            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
                Gl.__glewGetProgramiv(program.Value, GL_INFO_LOG_LENGTH, &k);
            }

            if (k <= 0)
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            {
                return string.Empty;
            }

<<<<<<< HEAD
            var result = new byte[k[0]];
            Gl.__glewGetProgramInfoLog(program.Value, k[0], k, result);
=======
            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = &result[0])
                {
                    Gl.__glewGetProgramInfoLog(program.Value, k, &k, presult);
                }
            }
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

            return new string(Encoding.ASCII.GetChars(result));
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
<<<<<<< HEAD
=======
            Log.Info(string.Format("createShader {0}", type));

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            var shader = (uint)Gl.__glewCreateShader(type);
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
            var error = Gl.glGetError();
            if (error != Gl.GL_NO_ERROR)
            {
<<<<<<< HEAD
                Console.WriteLine("GL Error {0}", error);
                throw new Exception(string.Format("GL Error {0}", error));
=======
                var msg = string.Format("GL Error {0}", error);
                Log.Error(msg);
                throw new Exception(msg);
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            }
#endif
        }
    }
}
