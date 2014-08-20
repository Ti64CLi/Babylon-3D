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
        public static unsafe extern void glutKeyboardFunc(IntPtr func);

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutPostRedisplay();

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

        private static void key(byte k, int x, int y)
        {
            Console.WriteLine("key pressed.");

            glutPostRedisplay();
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

            /*
            glutDisplayFunc(display);
            glutPassiveMotionFunc(passiveMotion);
            glutMouseFunc(mouse);
            glutMotionFunc(motion);
            glutIdleFunc(idle);
            */

            Action<byte, int, int> func = key;
            glutKeyboardFunc((IntPtr)(Delegate)func);

            /*
            glutReshapeFunc(resize);
            */

            //_main.init();
            //_main.loadSceneTutorial4();

            // main loop
            glutMainLoop();
        }
    }
}
