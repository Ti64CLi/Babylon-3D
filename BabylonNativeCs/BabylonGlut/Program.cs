// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BabylonGlut
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// </summary>
    internal class Program
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
        private static Main main;

        /// <summary>
        /// </summary>
        public delegate void EmptyDelegate();

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public delegate void TwoDimDelegate(int x, int y);

        /// <summary>
        /// </summary>
        /// <param name="button">
        /// </param>
        /// <param name="state">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public delegate void MouseDelegate(int button, int state, int x, int y);

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        public delegate void KeyDelegate(byte key, int x, int y);

        /// <summary>
        /// </summary>
        /// <param name="argCount">
        /// </param>
        /// <param name="args">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutInit(ref int argCount, byte[][] args);

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutInitWindowSize(int width, int height);

        /// <summary>
        /// </summary>
        /// <param name="mode">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutInitDisplayMode(int mode);

        /// <summary>
        /// </summary>
        /// <param name="title">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutCreateWindow(byte[] title);

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutMainLoop();

        /// <summary>
        /// </summary>
        /// <param name="display">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutDisplayFunc(void* display);

        /// <summary>
        /// </summary>
        /// <param name="passiveMotion">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutPassiveMotionFunc(void* passiveMotion);

        /// <summary>
        /// </summary>
        /// <param name="mouse">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutMouseFunc(void* mouse);

        /// <summary>
        /// </summary>
        /// <param name="motion">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutMotionFunc(void* motion);

        /// <summary>
        /// </summary>
        /// <param name="idle">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutIdleFunc(void* idle);

        /// <summary>
        /// </summary>
        /// <param name="reshape">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutReshapeFunc(void* reshape);

        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern unsafe void glutKeyboardFunc(void* key);

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutPostRedisplay();

        /// <summary>
        /// </summary>
#if GLUT_STATIC
                [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport("glut", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern void glutSwapBuffers();

        /// <summary>
        /// </summary>
        private static void Display()
        {
            main.OnDraw();
            glutSwapBuffers();
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private static void PassiveMotion(int x, int y)
        {
            glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        /// <param name="k">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private static void Key(byte k, int x, int y)
        {
            glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        /// <param name="button">
        /// </param>
        /// <param name="state">
        /// </param>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private static void Mouse(int button, int state, int x, int y)
        {
            glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        private static void Idle()
        {
            glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        /// <param name="w">
        /// </param>
        /// <param name="h">
        /// </param>
        private static void Resize(int w, int h)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private static void Motion(int x, int y)
        {
            // _main.onMotion(x, y);
        }

        /// <summary>
        /// </summary>
        /// <param name="args">
        /// </param>
        private static void Main(string[] args)
        {
            Console.WriteLine("start.");

            main = new Main();
            main.MaxWidth = main.Width = 400;
            main.MaxHeight = main.Height = 640;

            ////var count = 0;
            ////var argsBytes = new byte[0][];
            ////glutInit(ref count, argsBytes);

            ////glutInitWindowSize(main.Width, main.Height);
            ////glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
            ////glutCreateWindow(null /*"Babylon Native"*/);

            ////unsafe
            ////{
            ////    glutDisplayFunc(((Delegate)new EmptyDelegate(Display)).ToPointer());
            ////    glutPassiveMotionFunc(((Delegate)new TwoDimDelegate(PassiveMotion)).ToPointer());
            ////    glutMouseFunc(((Delegate)new MouseDelegate(Mouse)).ToPointer());
            ////    glutMotionFunc(((Delegate)new TwoDimDelegate(Motion)).ToPointer());
            ////    glutIdleFunc(((Delegate)new EmptyDelegate(Idle)).ToPointer());
            ////    glutKeyboardFunc(((Delegate)new KeyDelegate(Key)).ToPointer());
            ////    glutReshapeFunc(((Delegate)new TwoDimDelegate(Resize)).ToPointer());
            ////}

            main.OnInitialize();
            // _main.loadSceneTutorial4();

            // main loop
            ////glutMainLoop();

            Console.WriteLine("stop.");
        }
    }
}