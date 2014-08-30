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
        private static Main main;

        /// <summary>
        /// </summary>
        private static void Display()
        {
            main.OnDraw();
            Gl.glutSwapBuffers();
        }

        /// <summary>
        /// </summary>
        /// <param name="x">
        /// </param>
        /// <param name="y">
        /// </param>
        private static void PassiveMotion(int x, int y)
        {
            Gl.glutPostRedisplay();
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
            Gl.glutPostRedisplay();
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
            Gl.glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        private static void Idle()
        {
            Gl.glutPostRedisplay();
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

            var count = 0;
            var argsBytes = new byte[0][];
            Gl.glutInit(ref count, argsBytes);

            Gl.glutInitWindowSize(main.Width, main.Height);
            Gl.glutInitDisplayMode(Gl.GLUT_DOUBLE | Gl.GLUT_DEPTH | Gl.GLUT_RGB);
            Gl.glutCreateWindow(null /*"Babylon Native"*/);

            unsafe
            {
                Gl.glutDisplayFunc(((Delegate)new EmptyDelegate(Display)).ToPointer());
                Gl.glutPassiveMotionFunc(((Delegate)new TwoDimDelegate(PassiveMotion)).ToPointer());
                Gl.glutMouseFunc(((Delegate)new MouseDelegate(Mouse)).ToPointer());
                Gl.glutMotionFunc(((Delegate)new TwoDimDelegate(Motion)).ToPointer());
                Gl.glutIdleFunc(((Delegate)new EmptyDelegate(Idle)).ToPointer());
                Gl.glutKeyboardFunc(((Delegate)new KeyDelegate(Key)).ToPointer());
                Gl.glutReshapeFunc(((Delegate)new TwoDimDelegate(Resize)).ToPointer());
            }

            main.OnInitialize();
            // _main.loadSceneTutorial4();

            // main loop
            Gl.glutMainLoop();

            Console.WriteLine("stop.");
        }
    }
}