namespace BabylonAndroid
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Gl
    {
        /// <summary>
        /// </summary>
        public const int GL_NO_ERROR = 0;

        public const int GL_TEXTURE = 5890;
        public const int GL_TEXTURE0 = 33984;
        public const int GL_TEXTURE1 = 33985;
        public const int GL_TEXTURE2 = 33986;
        public const int GL_TEXTURE3 = 33987;
        public const int GL_TEXTURE4 = 33988;
        public const int GL_TEXTURE5 = 33989;
        public const int GL_TEXTURE6 = 33990;
        public const int GL_TEXTURE7 = 33991;
        public const int GL_TEXTURE8 = 33992;
        public const int GL_TEXTURE9 = 33993;
        public const int GL_TEXTURE10 = 33994;
        public const int GL_TEXTURE11 = 33995;
        public const int GL_TEXTURE12 = 33996;
        public const int GL_TEXTURE13 = 33997;
        public const int GL_TEXTURE14 = 33998;
        public const int GL_TEXTURE15 = 33999;
        public const int GL_TEXTURE16 = 34000;
        public const int GL_TEXTURE17 = 34001;
        public const int GL_TEXTURE18 = 34002;
        public const int GL_TEXTURE19 = 34003;
        public const int GL_TEXTURE20 = 34004;
        public const int GL_TEXTURE21 = 34005;
        public const int GL_TEXTURE22 = 34006;
        public const int GL_TEXTURE23 = 34007;
        public const int GL_TEXTURE24 = 34008;
        public const int GL_TEXTURE25 = 34009;
        public const int GL_TEXTURE26 = 34010;
        public const int GL_TEXTURE27 = 34011;
        public const int GL_TEXTURE28 = 34012;
        public const int GL_TEXTURE29 = 34013;
        public const int GL_TEXTURE30 = 34014;
        public const int GL_TEXTURE31 = 34015;

        public const int GL_RGBA = 6408;
        public const int GL_BGRA = 32993;

        /// <summary>
        /// </summary>
        /// <param name="mask">
        /// </param>
        /// <returns>
        /// </returns>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glClear(int mask);

        /// <summary>
        /// </summary>
        /// <param name="r">
        /// </param>
        /// <param name="g">
        /// </param>
        /// <param name="b">
        /// </param>
        /// <param name="alpha">
        /// </param>
        /// <returns>
        /// </returns>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glClearColor(float r, float g, float b, float alpha);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern int glGetUniformLocation(uint program, byte* name);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glBufferData(int target, int size, void* data, int usage);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDepthMask(byte flag);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glLinkProgram(uint program);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glBufferSubData(int target, int offset, int size, void* data);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glVertexAttribPointer(uint index, int size, int type, byte normalized, int stride, void* pointer);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glEnableVertexAttribArray(uint index);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glCullFace(int mode);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glUniformMatrix4fv(int location, int count, byte transpose, float* value);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern uint glCreateProgram();

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDeleteShader(uint shader);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glEnable(int cap);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGenBuffers(int n, uint* buffers);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUseProgram(uint program);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glDrawElements(int mode, int count, int type, int indices);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetShaderiv(uint shader, int pname, int* @params);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern byte* glGetString(int name);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetShaderInfoLog(uint shader, int maxLength, int* length, byte* infoLog);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetProgramInfoLog(uint program, int maxLength, int* length, byte* infoLog);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetIntegerv(int pname, int* @params);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glShaderSource(uint shader, int count, byte** @string, int* length);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glBindBuffer(int target, int buffer);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern int glGetAttribLocation(uint program, byte* name);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glReadPixels(int x, int y, int width, int height, int format, int type, byte* data);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform4f(int location, float x, float y, float z, float w);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform1i(int location, int x);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetProgramiv(uint program, int pname, int* @params);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDepthFunc(int func);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glClearDepthf(float depth);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glActiveTexture(int textureId);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glViewport(int x, int y, int width, int height);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glDeleteBuffers(int n, uint* buffers);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glAttachShader(uint program, uint shader);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glCompileShader(uint shader);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform3f(int location, float x, float y, float z);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern uint glCreateShader(int shaderType);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern int glGetError();

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glBindTexture(int target, int p);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void glGenTextures(int p1, uint* p2);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void glTexImage2D(
            int target,
            int level,
            int internalformat,
            int width,
            int height,
            int border,
            int format,
            int type,
            byte* pData);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDisableVertexAttribArray(int index);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glBlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glGenerateMipmap(int target);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glPixelStorei(int pname, int param);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDisable(int cap);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glTexParameteri(int target, int pname, int param);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform2f(int p1, float p2, float p3);
    }
}
