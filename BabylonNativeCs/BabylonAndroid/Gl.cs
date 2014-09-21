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

        /*
        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glewInit();

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern int __glewGetUniformLocation(uint program, byte[] name);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewBufferData(int target, int size, void* data, int usage);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthMask(byte flag);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewLinkProgram(uint program);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewBufferSubData(int target, int offset, int size, void* data);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewVertexAttribPointer(uint index, int size, int type, byte normalized, int stride, void* pointer);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewEnableVertexAttribArray(uint index);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glCullFace(int mode);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniformMatrix4fv(int location, int count, byte transpose, float[] value);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern uint __glewCreateProgram();

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewDeleteShader(uint shader);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glEnable(int cap);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewGenBuffers(int n, uint[] buffers);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUseProgram(uint program);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glDrawElements(int mode, int count, int type, int indices);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewGetShaderiv(uint shader, int pname, int[] @params);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern byte[] glGetString(int name);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewGetShaderInfoLog(uint shader, int maxLength, int[] length, byte[] infoLog);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewGetProgramInfoLog(uint program, int maxLength, int[] length, byte[] infoLog);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glGetIntegerv(int pname, int[] @params);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewShaderSource(uint shader, int count, byte[][] @string, int[] length);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewBindBuffer(int target, int buffer);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern int __glewGetAttribLocation(uint program, byte[] name);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glReadPixels(int x, int y, int width, int height, int format, int type, byte[] data);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform4f(int location, float x, float y, float z, float w);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform1i(int location, int x);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewGetProgramiv(uint program, int pname, int[] @params);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthFunc(int func);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glClearDepth(double depth);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern void glViewport(int x, int y, int width, int height);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewDeleteBuffers(int n, uint[] buffers);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewAttachShader(uint program, uint shader);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewCompileShader(uint shader);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform3f(int location, float x, float y, float z);

        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern uint __glewCreateShader(int shaderType);

        [DllImport("opengl", CallingConvention = CallingConvention.StdCall)]
        public static extern int glGetError();
        */
    }
}
