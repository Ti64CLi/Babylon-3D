namespace BabylonGlut
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Log
    {
        public static void Info(string msg)
        {
            System.Console.WriteLine(msg);
        }

        public static void Warn(string msg)
        {
            System.Console.WriteLine(msg);
        }
        
        public static void Error(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}
