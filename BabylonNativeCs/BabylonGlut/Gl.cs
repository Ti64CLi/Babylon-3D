namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Gl
    {
        /// <summary>
        /// </summary>
        public const int GLUT_RGB = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_RGBA = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_INDEX = 0x0001;

        /// <summary>
        /// </summary>
        public const int GLUT_SINGLE = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_DOUBLE = 0x0002;

        /// <summary>
        /// </summary>
        public const int GLUT_ACCUM = 0x0004;

        /// <summary>
        /// </summary>
        public const int GLUT_ALPHA = 0x0008;

        /// <summary>
        /// </summary>
        public const int GLUT_DEPTH = 0x0010;

        /// <summary>
        /// </summary>
        public const int GLUT_STENCIL = 0x0020;

        /// <summary>
        /// </summary>
        public const int GLUT_MULTISAMPLE = 0x0080;

        /// <summary>
        /// </summary>
        public const int GLUT_STEREO = 0x0100;

        /// <summary>
        /// </summary>
        public const int GLUT_LUMINANCE = 0x0200;

        /// <summary>
        /// </summary>
        public const int GLUT_LEFT_BUTTON = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_MIDDLE_BUTTON = 0x0001;

        /// <summary>
        /// </summary>
        public const int GLUT_RIGHT_BUTTON = 0x0002;

        /// <summary>
        /// </summary>
        public const int GLUT_DOWN = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_UP = 0x0001;

        /// <summary>
        /// </summary>
        public const int GLUT_LEFT = 0x0000;

        /// <summary>
        /// </summary>
        public const int GLUT_ENTERED = 0x0001;

        /// <summary>
        /// </summary>
        public const int GL_NO_ERROR = 0;

        /// <summary>
        /// </summary>
        /// <param name="argCount">
        /// </param>
        /// <param name="args">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern void glutInit(ref int argCount, byte** args);

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutInitWindowSize(int width, int height);

        /// <summary>
        /// </summary>
        /// <param name="mode">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutInitDisplayMode(int mode);

        /// <summary>
        /// </summary>
        /// <param name="title">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern void glutCreateWindow(byte* title);

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutMainLoop();

        /// <summary>
        /// </summary>
        /// <param name="display">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutDisplayFunc(void* display);

        /// <summary>
        /// </summary>
        /// <param name="passiveMotion">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutPassiveMotionFunc(void* passiveMotion);

        /// <summary>
        /// </summary>
        /// <param name="mouse">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutMouseFunc(void* mouse);

        /// <summary>
        /// </summary>
        /// <param name="motion">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutMotionFunc(void* motion);

        /// <summary>
        /// </summary>
        /// <param name="idle">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutIdleFunc(void* idle);

        /// <summary>
        /// </summary>
        /// <param name="reshape">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutReshapeFunc(void* reshape);

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutKeyboardFunc(void* key);

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutPostRedisplay();

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutSwapBuffers();


        /// <summary>
        /// </summary>
        /// <param name="mask">
        /// </param>
        /// <returns>
        /// </returns>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
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
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glClearColor(float r, float g, float b, float alpha);

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glewInit();

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern int glGetUniformLocation(uint program, byte* name);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern int __glewGetUniformLocation(uint program, byte* name);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glBufferData(int target, int size, void* data, int usage);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewBufferData(int target, int size, void* data, int usage);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthMask(byte flag);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glLinkProgram(uint program);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewLinkProgram(uint program);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glBufferSubData(int target, int offset, int size, void* data);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewBufferSubData(int target, int offset, int size, void* data);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glVertexAttribPointer(uint index, int size, int type, byte normalized, int stride, void* pointer);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewVertexAttribPointer(uint index, int size, int type, byte normalized, int stride, void* pointer);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glEnableVertexAttribArray(uint index);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewEnableVertexAttribArray(uint index);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glCullFace(int mode);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glUniformMatrix4fv(int location, int count, byte transpose, float* value);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewUniformMatrix4fv(int location, int count, byte transpose, float* value);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern uint glCreateProgram();
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern uint __glewCreateProgram();
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glDeleteShader(uint shader);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewDeleteShader(uint shader);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glEnable(int cap);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGenBuffers(int n, uint* buffers);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewGenBuffers(int n, uint* buffers);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUseProgram(uint program);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUseProgram(uint program);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glDrawElements(int mode, int count, int type, int indices);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetShaderiv(uint shader, int pname, int* @params);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewGetShaderiv(uint shader, int pname, int* @params);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern byte* glGetString(int name);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetShaderInfoLog(uint shader, int maxLength, int* length, byte* infoLog);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewGetShaderInfoLog(uint shader, int maxLength, int* length, byte* infoLog);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetProgramInfoLog(uint program, int maxLength, int* length, byte* infoLog);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewGetProgramInfoLog(uint program, int maxLength, int* length, byte* infoLog);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glGetIntegerv(int pname, int* @params);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glShaderSource(uint shader, int count, byte** @string, int* length);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewShaderSource(uint shader, int count, byte** @string, int* length);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glBindBuffer(int target, int buffer);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewBindBuffer(int target, int buffer);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern int glGetAttribLocation(uint program, byte* name);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern int __glewGetAttribLocation(uint program, byte* name);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern void glReadPixels(int x, int y, int width, int height, int format, int type, byte* data);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform4f(int location, float x, float y, float z, float w);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform4f(int location, float x, float y, float z, float w);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform1i(int location, int x);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform1i(int location, int x);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glGetProgramiv(uint program, int pname, int* @params);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewGetProgramiv(uint program, int pname, int* @params);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glDepthFunc(int func);

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glClearDepth(double depth);

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern void glViewport(int x, int y, int width, int height);

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public unsafe static extern void glDeleteBuffers(int n, uint* buffers);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public unsafe static extern void __glewDeleteBuffers(int n, uint* buffers);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glAttachShader(uint program, uint shader);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewAttachShader(uint program, uint shader);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glCompileShader(uint shader);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewCompileShader(uint shader);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glUniform3f(int location, float x, float y, float z);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern void __glewUniform3f(int location, float x, float y, float z);
#endif

#if GLEW_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern uint glCreateShader(int shaderType);
#else
        [DllImport("glew", CallingConvention = CallingConvention.StdCall)]
        [MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef)]
        public static extern uint __glewCreateShader(int shaderType);
#endif

        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
        public static extern int glGetError();
    }
}
