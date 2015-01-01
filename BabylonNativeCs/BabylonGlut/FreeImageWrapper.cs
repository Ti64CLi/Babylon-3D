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

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern int FreeImage_GetFIFFromFilename(byte* fileName);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public static extern int FreeImage_FIFSupportsReading(int fileFormat);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern byte* FreeImage_Load(int fileFormat, byte* fileName);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern byte* FreeImage_ConvertTo32Bits(byte* dib);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern void FreeImage_Unload(byte* dib);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern int FreeImage_GetWidth(byte* dib);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern int FreeImage_GetHeight(byte* dib);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern byte* FreeImage_GetBits(byte* dib);

        public static unsafe ImageDataAdapter Load(string url)
        {
            int fif = FIF_UNKNOWN;
            byte* dib = null;

            fixed (byte* cstr = &Encoding.ASCII.GetBytes(url)[0])
            {
                fif = FreeImage_GetFileType(cstr, 0);

                if (fif == FIF_UNKNOWN)
                    fif = FreeImage_GetFIFFromFilename(cstr);

                if (fif == FIF_UNKNOWN)
                {
                    return null;
                }

                if (FreeImage_FIFSupportsReading(fif) > 0)
                {
                    dib = FreeImage_Load(fif, cstr);
                }
            }

            if (dib == null)
            {
                return null;
            }

            var dib32bit = FreeImage_ConvertTo32Bits(dib);

            FreeImage_Unload(dib);

            var width = FreeImage_GetWidth(dib32bit);
            var height = FreeImage_GetHeight(dib32bit);

            var bits = FreeImage_GetBits(dib32bit);

            return new ImageDataAdapter(width, height, new IntPtr(bits));
        }
    }
}
