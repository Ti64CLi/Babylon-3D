// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BabylonAndroid
{
    using BABYLON;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// </summary>
    internal class Program
    {
        public const int AMOTION_EVENT_ACTION_DOWN = 0;

        public const int AMOTION_EVENT_ACTION_UP = 1;

        /// <summary>
        /// </summary>
        /// <param name="display">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void DisplayFunc(void* display);

        /// <summary>
        /// </summary>
        /// <param name="init">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void InitFunc(void* init);

        /// <summary>
        /// </summary>
        /// <param name="mouse">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void MouseFunc(void* mouse);

        /// <summary>
        /// </summary>
        /// <param name="motion">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void MotionFunc(void* motion);

        /// <summary>
        /// </summary>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void* GetAssetManagerFunc();

        /// <summary>
        /// </summary>
        private static Main main;

        /// <summary>
        /// </summary>
        private static IntPtr assetManager;

        /// <summary>
        /// </summary>
        private static void Init()
        {
            main.OnInitialize(assetManager);
        }

        /// <summary>
        /// </summary>
        private static void Display()
        {
            main.OnDraw();
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
        private static void Mouse(int buttonOrPointerId, int state, int x, int y)
        {
            switch (state)
            {
                case AMOTION_EVENT_ACTION_DOWN:
                    var onmousedown = main.canvas.onmousedown;
                    if (onmousedown != null)
                    {
#if DEBUG
                        Log.Info("Mouse down.");
#endif
                        onmousedown(new MouseEventAdapter(buttonOrPointerId, x, y));
                    }

                    var onpointerdown = main.canvas.onpointerdown;
                    if (onpointerdown != null)
                    {
#if DEBUG
                        Log.Info("Pointer down.");
#endif
                        onpointerdown(new PointerEventAdapter(buttonOrPointerId, x, y));
                    }

                    break;
                case AMOTION_EVENT_ACTION_UP:
                    var onmouseup = main.canvas.onmouseup;
                    if (onmouseup != null)
                    {
#if DEBUG
                        Log.Info("Mouse up.");
#endif
                        onmouseup(new MouseEventAdapter(buttonOrPointerId, x, y));
                    }

                    var onpointerup = main.canvas.onpointerup;
                    if (onpointerup != null)
                    {
#if DEBUG
                        Log.Info("Pointer up.");
#endif
                        onpointerup(new PointerEventAdapter(buttonOrPointerId, x, y));
                    }

                    break;
            }
        }

        /// <summary>
        /// </summary>
        private static void Motion(int pointerId, int x, int y)
        {
            var onmousemove = main.canvas.onmousemove;
            if (onmousemove != null)
            {
#if DEBUG
                Log.Info("Mouse move.");
#endif
                onmousemove(new MouseEventAdapter(-1, x, y));
            }

            var onpointermove = main.canvas.onpointermove;
            if (onpointermove != null)
            {
#if DEBUG
                Log.Info("Pointer move.");
#endif
                onpointermove(new PointerEventAdapter(pointerId, x, y));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="args">
        /// </param>
        private static void Main(string[] args)
        {
            main = new Main();
            main.MaxWidth = main.Width = 480;
            main.MaxHeight = main.Height = 800;

            unsafe
            {
                InitFunc(new System.Action(Init).ToPointer());
                DisplayFunc(new System.Action(Display).ToPointer());
                MouseFunc(new Action<int, int, int, int>(Mouse).ToPointer());
                MotionFunc(new Action<int, int, int>(Motion).ToPointer());
                assetManager = new IntPtr(GetAssetManagerFunc());
            }
        }
    }
}