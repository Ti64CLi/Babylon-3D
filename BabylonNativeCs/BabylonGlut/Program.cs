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

        static void Main(string[] args)
        {
            Console.WriteLine("Starting.");

            var count = 0;
            var argsBytes = new byte[0][];
            glutInit(ref count, argsBytes);

            glutInitWindowSize(400, 640);
            glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGB);
            glutCreateWindow(string.Empty/*"Babylon Native"*/);

            /*
            glutDisplayFunc(display);
            glutPassiveMotionFunc(passiveMotion);
            glutMouseFunc(mouse);
            glutMotionFunc(motion);
            glutIdleFunc(idle);
            glutKeyboardFunc(key);
            glutReshapeFunc(resize);
            */

            //_main.init();
            //_main.loadSceneTutorial4();

            // main loop
            glutMainLoop();
        }
    }
}
