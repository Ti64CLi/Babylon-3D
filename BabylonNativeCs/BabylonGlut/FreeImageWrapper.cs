namespace BabylonGlut
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using Web;

    public class FreeImageWrapper
    {
        internal const int FIF_UNKNOWN = -1;

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern int FreeImage_GetFileType(byte* fileName, int options);

        public static unsafe ImageDataAdapter Load(string url)
        {
            int fif = FIF_UNKNOWN;
            byte* bitmap = null;

            fixed (byte* cstr = &Encoding.ASCII.GetBytes(url)[0])
            {
                fif = FreeImage_GetFileType(cstr, 0);
            }

            return new ImageDataAdapter();
        }
    }
}
