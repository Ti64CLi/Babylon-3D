namespace BabylonAndroid
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Log
    {
        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern int _logi(byte[] msg);

        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern int _logw(byte[] msg);
        
        [MethodImpl(MethodImplOptions.Unmanaged)]
        private static extern int _loge(byte[] msg);

        public static void Info(string msg)
        {
            _logi(Encoding.ASCII.GetBytes(msg));
        }

        public static void Warn(string msg)
        {
            _logw(Encoding.ASCII.GetBytes(msg));
        }
        
        public static void Error(string msg)
        {
            _loge(Encoding.ASCII.GetBytes(msg));
        }
    }
}
