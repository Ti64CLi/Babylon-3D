namespace BabylonAndroid
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Log
    {
        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern unsafe int _logi(byte* msg);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern unsafe int _logw(byte* msg);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern unsafe int _loge(byte* msg);

        public static void Info(string msg)
        {
            unsafe
            {
                fixed (byte* b = Encoding.ASCII.GetBytes(msg))
                {
                    _logi(b);
                }
            }
        }

        public static void Warn(string msg)
        {
            unsafe
            {
                fixed (byte* b = Encoding.ASCII.GetBytes(msg))
                {
                    _logw(b);
                }
            }
        }

        public static void Error(string msg)
        {
            unsafe
            {
                fixed (byte* b = Encoding.ASCII.GetBytes(msg))
                {
                    _loge(b);
                }
            }
        }
    }
}