namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;

    class Program
    {
        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        public static extern void glutInit(ref int argCount, byte[][] args);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World.");

            var count = 0;
            var argsBytes = new byte[0][];
            glutInit(ref count, argsBytes);
        }
    }
}
