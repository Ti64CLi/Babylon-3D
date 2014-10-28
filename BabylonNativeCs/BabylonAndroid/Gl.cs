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
    }
}
