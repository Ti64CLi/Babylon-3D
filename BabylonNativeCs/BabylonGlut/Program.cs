namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;

    class Program
    {
        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutInit(ref int argCount, byte[][] args);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutInitWindowSize(int width, int height);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutInitDisplayMode(int mode);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutCreateWindow(byte[] title);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutMainLoop();

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutDisplayFunc(void* display);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutPassiveMotionFunc(void* passiveMotion);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutMouseFunc(void* mouse);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutMotionFunc(void* motion);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutIdleFunc(void* idle);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutReshapeFunc(void* reshape);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static unsafe extern void glutKeyboardFunc(void* key);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutPostRedisplay();

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
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

        private static void display()
        {
            ////_main.render();
            glutSwapBuffers();
        }

        private static void passiveMotion(int x, int y)
        {
            glutPostRedisplay();
        }

        private static void key(byte k, int x, int y)
        {
            glutPostRedisplay();
            throw new NotSupportedException();
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

            var count = 0;
            var argsBytes = new byte[0][];
            glutInit(ref count, argsBytes);

            glutInitWindowSize(400, 640);
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

            //_main.init();
            //_main.loadSceneTutorial4();

            // main loop
            glutMainLoop();
        }
    }
}
