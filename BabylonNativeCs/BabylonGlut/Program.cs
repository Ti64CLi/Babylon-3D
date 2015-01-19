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
<<<<<<< HEAD
    using System;
    using System.Runtime.InteropServices;
=======
    using BABYLON;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

    /// <summary>
    /// </summary>
    internal class Program
<<<<<<< HEAD
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
=======
    { 
        /// <summary>
        /// </summary>
        private static Main main;

        /// <summary>
        /// </summary>
        private static int pointerId;
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

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
<<<<<<< HEAD
        private static void Mouse(int button, int state, int x, int y)
        {
=======
        private static void Mouse(int buttonOrPointerId, int state, int x, int y)
        {
            switch (state)
            {
                case Gl.GLUT_DOWN:
                    var onmousedown = main.canvas.onmousedown;
                    if (onmousedown != null)
                    {
                        Log.Info("Mouse down.");
                        onmousedown(new MouseEventAdapter(buttonOrPointerId, x, y));
                    }

                    var onpointerdown = main.canvas.onpointerdown;
                    if (onpointerdown != null)
                    {
                        Log.Info("Pointer down.");
                        pointerId = buttonOrPointerId;
                        onpointerdown(new PointerEventAdapter(buttonOrPointerId, x, y));
                    }

                    break;
                case Gl.GLUT_UP:
                    var onmouseup = main.canvas.onmouseup;
                    if (onmouseup != null)
                    {
                        Log.Info("Mouse up.");
                        onmouseup(new MouseEventAdapter(buttonOrPointerId, x, y));
                    }

                    var onpointerup = main.canvas.onpointerup;
                    if (onpointerup != null)
                    {
                        Log.Info("Pointer up.");
                        onpointerup(new PointerEventAdapter(buttonOrPointerId, x, y));
                    }

                    break;
            }

>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
            // _main.onMotion(x, y);
=======
            var onmousemove = main.canvas.onmousemove;
            if (onmousemove != null)
            {
                Log.Info("Mouse move.");
                onmousemove(new MouseEventAdapter(-1, x, y));
            }

            var onpointermove = main.canvas.onpointermove;
            if (onpointermove != null)
            {
                Log.Info("Pointer move.");
                onpointermove(new PointerEventAdapter(pointerId, x, y));
            }

            Gl.glutPostRedisplay();
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
<<<<<<< HEAD
            var argsBytes = new byte[0][];
            Gl.glutInit(ref count, argsBytes);

            Gl.glutInitWindowSize(main.Width, main.Height);
            Gl.glutInitDisplayMode(Gl.GLUT_DOUBLE | Gl.GLUT_DEPTH | Gl.GLUT_RGB);
            Gl.glutCreateWindow(null /*"Babylon Native"*/);
=======
            unsafe
            {
                Gl.glutInit(ref count, null);
            }

            Gl.glutInitWindowSize(main.Width, main.Height);
            Gl.glutInitDisplayMode(Gl.GLUT_DOUBLE | Gl.GLUT_DEPTH | Gl.GLUT_RGB);

            var bytes = Encoding.ASCII.GetBytes("Babylon Native");
            unsafe
            {
                fixed (byte* b = &bytes[0])
                {
                    Gl.glutCreateWindow(b);
                }
            }
>>>>>>> f265f07661031677698c527dcba26356bdf55cab

            Gl.glewInit();

            unsafe
            {
<<<<<<< HEAD
                Gl.glutDisplayFunc(((Delegate)new EmptyDelegate(Display)).ToPointer());
                Gl.glutPassiveMotionFunc(((Delegate)new TwoDimDelegate(PassiveMotion)).ToPointer());
                Gl.glutMouseFunc(((Delegate)new MouseDelegate(Mouse)).ToPointer());
                Gl.glutMotionFunc(((Delegate)new TwoDimDelegate(Motion)).ToPointer());
                Gl.glutIdleFunc(((Delegate)new EmptyDelegate(Idle)).ToPointer());
                Gl.glutKeyboardFunc(((Delegate)new KeyDelegate(Key)).ToPointer());
                Gl.glutReshapeFunc(((Delegate)new TwoDimDelegate(Resize)).ToPointer());
=======
                Gl.glutDisplayFunc(new System.Action(Display).ToPointer());
                Gl.glutPassiveMotionFunc(new Action<int, int>(PassiveMotion).ToPointer());
                Gl.glutMouseFunc(new Action<int, int, int, int>(Mouse).ToPointer());
                Gl.glutMotionFunc(new Action<int, int>(Motion).ToPointer());
                Gl.glutIdleFunc(new System.Action(Idle).ToPointer());
                Gl.glutKeyboardFunc(new Action<byte, int, int>(Key).ToPointer());
                Gl.glutReshapeFunc(new Action<int, int>(Resize).ToPointer());
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
            }

            main.OnInitialize();

            // main loop
            Gl.glutMainLoop();
        }
    }
}