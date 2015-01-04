namespace BabylonAndroid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using Babylon;
    using BABYLON;

    public class GlRenderingContextAdapter : Web.WebGLRenderingContext
    {
        private IDictionary<string, uint> _constMap = new Dictionary<string, uint>();

        public GlRenderingContextAdapter()
        {
            _constMap["TEXTURE"] = Gl.GL_TEXTURE;
            _constMap["TEXTURE0"] = Gl.GL_TEXTURE0;
            _constMap["TEXTURE1"] = Gl.GL_TEXTURE1;
            _constMap["TEXTURE2"] = Gl.GL_TEXTURE2;
            _constMap["TEXTURE3"] = Gl.GL_TEXTURE3;
            _constMap["TEXTURE4"] = Gl.GL_TEXTURE4;
            _constMap["TEXTURE5"] = Gl.GL_TEXTURE5;
            _constMap["TEXTURE6"] = Gl.GL_TEXTURE6;
            _constMap["TEXTURE7"] = Gl.GL_TEXTURE7;
            _constMap["TEXTURE8"] = Gl.GL_TEXTURE8;
            _constMap["TEXTURE9"] = Gl.GL_TEXTURE9;
            _constMap["TEXTURE10"] = Gl.GL_TEXTURE10;
            _constMap["TEXTURE11"] = Gl.GL_TEXTURE11;
            _constMap["TEXTURE12"] = Gl.GL_TEXTURE12;
            _constMap["TEXTURE13"] = Gl.GL_TEXTURE13;
            _constMap["TEXTURE14"] = Gl.GL_TEXTURE14;
            _constMap["TEXTURE15"] = Gl.GL_TEXTURE15;
            _constMap["TEXTURE16"] = Gl.GL_TEXTURE16;
            _constMap["TEXTURE17"] = Gl.GL_TEXTURE17;
            _constMap["TEXTURE18"] = Gl.GL_TEXTURE18;
            _constMap["TEXTURE19"] = Gl.GL_TEXTURE19;
            _constMap["TEXTURE20"] = Gl.GL_TEXTURE20;
            _constMap["TEXTURE21"] = Gl.GL_TEXTURE21;
            _constMap["TEXTURE22"] = Gl.GL_TEXTURE22;
            _constMap["TEXTURE23"] = Gl.GL_TEXTURE23;
            _constMap["TEXTURE24"] = Gl.GL_TEXTURE24;
            _constMap["TEXTURE25"] = Gl.GL_TEXTURE25;
            _constMap["TEXTURE26"] = Gl.GL_TEXTURE26;
            _constMap["TEXTURE27"] = Gl.GL_TEXTURE27;
            _constMap["TEXTURE28"] = Gl.GL_TEXTURE28;
            _constMap["TEXTURE29"] = Gl.GL_TEXTURE29;
            _constMap["TEXTURE30"] = Gl.GL_TEXTURE30;
            _constMap["TEXTURE31"] = Gl.GL_TEXTURE31;
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

        public Web.HTMLCanvasElement canvas
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public Web.WebGLUniformLocation getUniformLocation(Web.WebGLProgram program, string name)
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
                    glUniformLocation = new GlUniformLocation(Gl.glGetUniformLocation(program.Value, b));
                }
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", glUniformLocation.Value));
#endif
            return glUniformLocation;
        }

        public void bindTexture(int target, Web.WebGLTexture texture)
        {
#if _DEBUG
            Log.Info(string.Format("bindTexture {0} {1}", target, texture.Value));
#endif

            Gl.glBindTexture(target, (int)(texture != null ? texture.Value : 0));
            ErrorTest();
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
                    Gl.glBufferData(target, data.Length * sizeof(float), pdata, usage);
                }
            }

            ErrorTest();
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
                    Gl.glBufferData(target, data.Length * sizeof(ushort), pdata, usage);
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
#if _DEBUG
            Log.Info(string.Format("depthMask {0}", flag));
#endif

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
#if _DEBUG
            Log.Info(string.Format("linkProgram {0}", program.Value));
#endif

            Gl.glLinkProgram(program.Value);
            ErrorTest();
        }

        public BABYLON.Array<string> getSupportedExtensions()
        {
            throw new NotImplementedException();
        }

        public void bufferSubData(int target, int offset, int size, IntPtr data)
        {
#if _DEBUG
            Log.Info(string.Format("bufferSubData {0} {1} {2}", target, offset, size));
#endif

            unsafe
            {
                Gl.glBufferSubData(target, offset, size, data.ToPointer());
            }

            ErrorTest();
        }

        public void bufferSubData(int target, int offset, float[] data)
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
                Gl.glVertexAttribPointer(
                    (uint)indx,
                    size,
                    type,
                    (byte)(normalized ? 1 : 0),
                    stride,
                    new IntPtr(offset).ToPointer());
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
#if _DEBUG
            Log.Info("createTexture");
#endif

            uint textureId;
            unsafe
            {
                Gl.glGenTextures(1, &textureId);
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)textureId));
#endif

            return new WebGLTextureAdapter(textureId);
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
#if _DEBUG
            Log.Info(string.Format("enableVertexAttribArray {0}", index));
#endif

            Gl.glEnableVertexAttribArray((uint)index);
            ErrorTest();
        }

        public void depthRange(double zNear, double zFar)
        {
            throw new NotImplementedException();
        }

        public void cullFace(int mode)
        {
#if _DEBUG
            Log.Info(string.Format("cullFace {0}", mode));
#endif

            Gl.glCullFace(mode);

            ErrorTest();
        }

        public Web.WebGLFramebuffer createFramebuffer()
        {
            throw new NotImplementedException();
        }

        public void uniformMatrix4fv(Web.WebGLUniformLocation location, bool transpose, float[] value)
        {
#if _DEBUG
            Log.Info(string.Format("uniformMatrix4fv {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}", location.Value, transpose
                , value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11], value[12], value[13], value[14], value[15]));
#endif

            unsafe
            {
                fixed (float* pvalue = value)
                {
                    Gl.glUniformMatrix4fv((int)location.Value, value.Length / 16, (byte)(transpose ? 1 : 0), pvalue);
                }
            }

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
#if _DEBUG
            Log.Info("createProgram");
#endif

            var glProgramAdapter = new GlProgramAdapter(Gl.glCreateProgram());
            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", glProgramAdapter.Value));
#endif

            return glProgramAdapter;
        }

        public void deleteShader(Web.WebGLShader shader)
        {
#if _DEBUG
            Log.Info(string.Format("deleteShader", shader.Value));
#endif

            Gl.glDeleteShader(shader.Value);
            ErrorTest();
        }

        public BABYLON.Array<Web.WebGLShader> getAttachedShaders(Web.WebGLProgram program)
        {
            throw new NotImplementedException();
        }

        public void enable(int cap)
        {
#if _DEBUG
            Log.Info(string.Format("enable {0}", cap));
#endif
            Gl.glEnable(cap);
            ErrorTest();
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
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            Web.HTMLImageElement image)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            Web.HTMLCanvasElement canvas)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(
            int target,
            int level,
            int internalformat,
            int format,
            int type,
            Web.HTMLVideoElement video)
        {
            throw new NotImplementedException();
        }

        public void texImage2D(int target, int level, int internalformat, int format, int type, Web.ImageData pixels)
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
                if (dataBytes != null)
                {
                    fixed (byte* pData = dataBytes)
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
                else
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
                        (byte*)pixels.dataBytesPointer.ToPointer());
                }
            }

            ErrorTest();
        }

        public Web.WebGLBuffer createBuffer()
        {
#if _DEBUG
            Log.Info("createBuffer");
#endif

            uint bufferId;
            unsafe
            {
                Gl.glGenBuffers(1, &bufferId);
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", (int)bufferId));
#endif

            return new GlBufferAdapter(bufferId);
        }

        public void deleteTexture(Web.WebGLTexture texture)
        {
            throw new NotImplementedException();
        }

        public void useProgram(Web.WebGLProgram program)
        {
#if _DEBUG
            Log.Info(string.Format("useProgram {0}", program.Value));
#endif
            Gl.glUseProgram(program.Value);
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

        public void texSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int width,
            int height,
            int format,
            int type,
            Web.ArrayBufferView pixels)
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
            Web.HTMLImageElement image)
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
            Web.HTMLCanvasElement canvas)
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
            Web.HTMLVideoElement video)
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
            Web.ImageData pixels)
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
            Gl.glDisableVertexAttribArray(index);
        }

        public void blendFunc(int sfactor, int dfactor)
        {
            throw new NotImplementedException();
        }

        public void drawElements(int mode, int count, int type, int offset)
        {
#if _DEBUG
            Log.Info(string.Format("drawElements {0} {1} {2} {3}", mode, count, type, offset));
#endif

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
#if _DEBUG
            Log.Info("getShaderInfoLog");
#endif

            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
                Gl.glGetShaderiv(shader.Value, GL_INFO_LOG_LENGTH, &k);
            }
            if (k <= 0)
            {
                return string.Empty;
            }

            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = result)
                {
                    Gl.glGetShaderInfoLog(shader.Value, k, &k, presult);
                }
            }

            ////var version = glGetString(GL_SHADING_LANGUAGE_VERSION);

            return new string(Encoding.ASCII.GetChars(result));
        }

        public object getTexParameter(int target, int pname)
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

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif

            return i;
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

        public void compressedTexSubImage2D(
            int target,
            int level,
            double xoffset,
            double yoffset,
            int width,
            int height,
            int format,
            Web.ArrayBufferView data)
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
#if _DEBUG
            Log.Info(string.Format("shaderSource {0}, source length {1}", shader.Value, source.Length));
#endif

            var bytes = Encoding.ASCII.GetBytes(source);
            var len = bytes.Length;

            unsafe
            {
                fixed (byte* b = bytes)
                {
                    byte*[] barray = new byte*[] { b };
                    fixed (byte** pb = barray)
                    {
                        Gl.glShaderSource(shader.Value, 1, pb, &len);
                    }
                }
            }

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
            var bufferId = (int)(buffer != null ? buffer.Value : 0);

#if _DEBUG
            Log.Info(string.Format("bindBuffer {0} {1}", target, bufferId));
#endif

            Gl.glBindBuffer(target, bufferId);
            ErrorTest();
        }

        public int getAttribLocation(Web.WebGLProgram program, string name)
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
                fixed (byte* b = bytes)
                {
                    attribLocation = Gl.glGetAttribLocation(program.Value, b);
                }
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", attribLocation));
#endif

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
#if _DEBUG
            Log.Info(string.Format("clear {0}", mask));
#endif

            Gl.glClear(mask);
            ErrorTest();
        }

        public void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha)
        {
            Gl.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);
            ErrorTest();
        }

        public void stencilFuncSeparate(int face, int func, int _ref, int mask)
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
                fixed (byte* ppixels = pixels)
                {
                    Gl.glReadPixels(x, y, width, height, format, type, ppixels);
                }
            }

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
#if _DEBUG
            Log.Info(string.Format("generateMipmap {0}", target));
#endif

            Gl.glGenerateMipmap(target);
            ErrorTest();
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
#if _DEBUG
            Log.Info(string.Format("uniform4f {0} {1} {2} {3} {4}", location.Value, x, y, z, w));
#endif

            Gl.glUniform4f((int)location.Value, (float)x, (float)y, (float)z, (float)w);
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
#if _DEBUG
            Log.Info(string.Format("uniform1i {0} {1}", location.Value, x));
#endif

            Gl.glUniform1i(location.Value, x);
            ErrorTest();
        }

        public object getProgramParameter(Web.WebGLProgram program, int pname)
        {
#if _DEBUG
            Log.Info(string.Format("getProgramParameter {0} {1}", program.Value, pname));
#endif

            int i;
            unsafe
            {
                Gl.glGetProgramiv(program.Value, pname, &i);
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif

            return i;
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
#if _DEBUG
            Log.Info(string.Format("pixelStorei {0} {1}", pname, param));
#endif

            Gl.glPixelStorei(pname, param);
            ErrorTest();
        }

        public void disable(int cap)
        {
#if _DEBUG
            Log.Info(string.Format("disable {0}", cap));
#endif

            Gl.glDisable(cap);
            ErrorTest();
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
#if _DEBUG
            Log.Info(string.Format("depthFunc {0}", func));
#endif

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
#if _DEBUG
            Log.Info(string.Format("texParameteri {0} {1} {2}", target, pname, param));
#endif

            Gl.glTexParameteri(target, pname, param);
            ErrorTest();
        }

        public void vertexAttrib4f(int indx, double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public object getShaderParameter(Web.WebGLShader shader, int pname)
        {
#if _DEBUG
            Log.Info(string.Format("getShaderParameter {0} {1}", shader.Value, pname));
#endif

            int i;
            unsafe
            {
                Gl.glGetShaderiv(shader.Value, pname, &i);
            }

            ErrorTest();

#if _DEBUG
            Log.Info(string.Format("value {0}", i));
#endif

            return i;
        }

        public void clearDepth(double depth)
        {
#if _DEBUG
            Log.Info(string.Format("clearDepth {0}", depth));
#endif

            Gl.glClearDepthf((float)depth);
            ErrorTest();
        }

        public void activeTexture(int texture)
        {
            throw new NotImplementedException();
        }

        public void viewport(int x, int y, int width, int height)
        {
#if _DEBUG
            Log.Info(string.Format("viewport {0} {1} {2} {3}", x, y, width, height));
#endif

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
#if _DEBUG
            Log.Info(string.Format("deleteBuffer {0}", buffer.Value));
#endif
            var value = buffer.Value;
            unsafe
            {
                Gl.glDeleteBuffers(1, &value);
            }

            ErrorTest();
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
#if _DEBUG
            Log.Info(string.Format("attachShader {0} {1}", program.Value, shader.Value));
#endif
            Gl.glAttachShader(program.Value, shader.Value);
            ErrorTest();
        }

        public void compileShader(Web.WebGLShader shader)
        {
#if _DEBUG
            Log.Info(string.Format("compileShader {0}", shader.Value));
#endif

            Gl.glCompileShader(shader.Value);
            ErrorTest();
        }

        public void clearColor(double red, double green, double blue, double alpha)
        {
#if _DEBUG
            Log.Info(string.Format("clearColor {0} {1} {2} {3}", red, green, blue, alpha));
#endif

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

        public void framebufferRenderbuffer(
            int target,
            int attachment,
            int renderbuffertarget,
            Web.WebGLRenderbuffer renderbuffer)
        {
            throw new NotImplementedException();
        }

        public void finish()
        {
            throw new NotImplementedException();
        }

        public void uniform2f(Web.WebGLUniformLocation location, double x, double y)
        {
            Gl.glUniform2f(location.Value, (float)x, (float)y);
        }

        public void renderbufferStorage(int target, int internalformat, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void uniform3f(Web.WebGLUniformLocation location, double x, double y, double z)
        {
#if _DEBUG
            Log.Info(string.Format("uniform3f {0} {1} {2} {3}", location.Value, x, y, z));
#endif

            Gl.glUniform3f((int)location.Value, (float)x, (float)y, (float)z);
            ErrorTest();
        }

        public string getProgramInfoLog(Web.WebGLProgram program)
        {
#if _DEBUG
            Log.Info(string.Format("getProgramInfoLog {0}", program.Value));
#endif

            var GL_INFO_LOG_LENGTH = 35716;
            //var GL_SHADING_LANGUAGE_VERSION = 35724;
            int k;
            unsafe
            {
                Gl.glGetProgramiv(program.Value, GL_INFO_LOG_LENGTH, &k);
            }

            if (k <= 0)
            {
                return string.Empty;
            }

            var result = new byte[k];
            unsafe
            {
                fixed (byte* presult = result)
                {
                    Gl.glGetProgramInfoLog(program.Value, k, &k, presult);
                }
            }

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
#if _DEBUG
            Log.Info(string.Format("createShader {0}", type));
#endif

            var shader = (uint)Gl.glCreateShader(type);
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
            get { return (int)this._constMap[enumName]; }
        }

        private void ErrorTest()
        {
#if _DEBUG
            var error = Gl.glGetError();
            if (error != Gl.GL_NO_ERROR)
            {
                var msg = string.Format("GL Error {0}", error);
                Log.Error(msg);
                //throw new Exception(msg);
            }
#endif
        }
    }
}