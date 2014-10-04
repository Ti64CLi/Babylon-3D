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
    using BABYLON;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// </summary>
    internal class Program
    {
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
            switch (state)
            {
                case Gl.GLUT_UP:
                    var onmouseup = main.canvas.onmouseup;
                    if (onmouseup != null)
                    {
                        onmouseup(new MouseEventAdapter(button, x, y));
                    }

                    break;
                case Gl.GLUT_DOWN:
                    var onmousedown = main.canvas.onmousedown;
                    if (onmousedown != null)
                    {
                        onmousedown(new MouseEventAdapter(button, x, y));
                    }

                    break;
            }

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
            var onmousemove = main.canvas.onmousemove;
            if (onmousemove != null)
            {
                onmousemove(new MouseEventAdapter(-1, x, y));
            }

            Gl.glutPostRedisplay();
        }

        /// <summary>
        /// </summary>
        /// <param name="args">
        /// </param>
        private static void Main(string[] args)
        {
            main = new Main();
            main.MaxWidth = main.Width = 400;
            main.MaxHeight = main.Height = 640;

            var count = 0;
            var argsBytes = new byte[0][];
            Gl.glutInit(ref count, argsBytes);

            Gl.glutInitWindowSize(main.Width, main.Height);
            Gl.glutInitDisplayMode(Gl.GLUT_DOUBLE | Gl.GLUT_DEPTH | Gl.GLUT_RGB);
            Gl.glutCreateWindow(Encoding.ASCII.GetBytes("Babylon Native"));

            Gl.glewInit();

            unsafe
            {
                Gl.glutDisplayFunc(new System.Action(Display).ToPointer());
                Gl.glutPassiveMotionFunc(new Action<int, int>(PassiveMotion).ToPointer());
                Gl.glutMouseFunc(new Action<int, int, int, int>(Mouse).ToPointer());
                Gl.glutMotionFunc(new Action<int, int>(Motion).ToPointer());
                Gl.glutIdleFunc(new System.Action(Idle).ToPointer());
                Gl.glutKeyboardFunc(new Action<byte, int, int>(Key).ToPointer());
                Gl.glutReshapeFunc(new Action<int, int>(Resize).ToPointer());
            }

            main.OnInitialize();

            // main loop
            Gl.glutMainLoop();
        }
    }
}