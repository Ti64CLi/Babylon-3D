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
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// </summary>
        /// <param name="display">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void DisplayFunc(void* display);

        /// <summary>
        /// </summary>
        /// <param name="display">
        /// </param>
        [MethodImpl(MethodImplOptions.Unmanaged)]
        public static extern unsafe void InitFunc(void* init);

        /// <summary>
        /// </summary>
        public delegate void EmptyDelegate();

        /// <summary>
        /// </summary>
        private static Main main;

        /// <summary>
        /// </summary>
        private static void Init()
        {
            main.OnInitialize();
        }

        /// <summary>
        /// </summary>
        private static void Display()
        {
            main.OnDraw();
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

            unsafe
            {
                InitFunc(new EmptyDelegate(Init).ToPointer());
                DisplayFunc(new EmptyDelegate(Display).ToPointer());
            }
        }
    }
}