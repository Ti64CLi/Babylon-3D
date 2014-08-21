namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;

    class Program
    {
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutInit(ref int argCount, byte[][] args);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutInitWindowSize(int width, int height);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutInitDisplayMode(int mode);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutCreateWindow(byte[] title);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutMainLoop();

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutDisplayFunc(void* display);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutPassiveMotionFunc(void* passiveMotion);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutMouseFunc(void* mouse);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutMotionFunc(void* motion);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutIdleFunc(void* idle);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutReshapeFunc(void* reshape);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutKeyboardFunc(void* key);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutPostRedisplay();

        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern void glutSwapBuffers();

        public const int GLUT_RGB = 0x0000;
        public const int GLUT_RGBA = 0x0000;
        public const int GLUT_INDEX = 0x0001;
        public const int GLUT_SINGLE = 0x0000;
        public const int GLUT_DOUBLE = 0x0002;
        public const int GLUT_ACCUM = 0x0004;
        public const int GLUT_ALPHA = 0x0008;
        public const int GLUT_DEPTH = 0x0010;
        public const int GLUT_STENCIL = 0x0020;
        public const int GLUT_MULTISAMPLE = 0x0080;
        public const int GLUT_STEREO = 0x0100;
        public const int GLUT_LUMINANCE = 0x0200;

        public delegate void EmptyDelegate();
        public delegate void TwoDimDelegate(int x, int y);
        public delegate void MouseDelegate(int button, int state, int x, int y);
        public delegate void KeyDelegate(byte key, int x, int y);

        private static Main _main;

        private static void display()
        {
            _main.OnDraw();
            glutSwapBuffers();
        }

        private static void passiveMotion(int x, int y)
        {
            glutPostRedisplay();
        }

        private static void key(byte k, int x, int y)
        {
            glutPostRedisplay();
        }

        private static void mouse(int button, int state, int x, int y)
        {
            glutPostRedisplay();
        }

        private static void idle()
        {
            glutPostRedisplay();
        }

        private static void resize(int w, int h)
        {
        }

        private static void motion(int x, int y)
        {
            //_main.onMotion(x, y);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("start.");

            _main = new Main();
            _main.MaxWidth = _main.Width = 400;
            _main.MaxHeight = _main.Height = 640;

            var count = 0;
            var argsBytes = new byte[0][];
            glutInit(ref count, argsBytes);

            glutInitWindowSize(_main.Width, _main.Height);
            glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
            glutCreateWindow(null /*"Babylon Native"*/);

            unsafe
            {
                glutDisplayFunc(((Delegate)new EmptyDelegate(display)).ToPointer());
                glutPassiveMotionFunc(((Delegate)new TwoDimDelegate(passiveMotion)).ToPointer());
                glutMouseFunc(((Delegate)new MouseDelegate(mouse)).ToPointer());
                glutMotionFunc(((Delegate)new TwoDimDelegate(motion)).ToPointer());
                glutIdleFunc(((Delegate)new EmptyDelegate(idle)).ToPointer());
                glutKeyboardFunc(((Delegate)new KeyDelegate(key)).ToPointer());
                glutReshapeFunc(((Delegate)new TwoDimDelegate(resize)).ToPointer());
            }

            _main.OnInitialize();
            //_main.loadSceneTutorial4();

            // main loop
            glutMainLoop();
        }
    }
}
