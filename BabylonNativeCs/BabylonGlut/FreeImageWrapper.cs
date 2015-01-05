namespace Babylon
{
    using System;
    using System.Runtime.CompilerServices;
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
        public unsafe static extern byte* FreeImage_Load(int fileFormat, byte* fileName, int flags = 0);

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

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern byte* FreeImage_OpenMemory(byte* buffer, int size);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern int FreeImage_GetFileTypeFromMemory(byte* memory, int flags);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern byte* FreeImage_LoadFromMemory(int fileFormat, byte* memory, int flags);

#if FREEIMAGE_STATIC
        [MethodImpl(MethodImplOptions.Unmanaged)]
#else
        [DllImport(" ", CallingConvention = CallingConvention.StdCall)]
#endif
        public unsafe static extern void FreeImage_CloseMemory(byte* memory);

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

            var len = width * height * 4;
            var bytes = new byte[len];

            Memcpy(bytes, 0, bits, 0, len);

            FreeImage_Unload(dib32bit);

            return new ImageDataAdapter(width, height, bytes);
        }

        public static unsafe ImageDataAdapter LoadFromMemory(IntPtr buffer, int size)
        {
            int fif = FIF_UNKNOWN;
            byte* dib = null;
            byte* memory = null;

            memory = FreeImage_OpenMemory((byte*)buffer.ToPointer(), size);

            fif = FreeImage_GetFileTypeFromMemory(memory, 0);
            if (fif == FIF_UNKNOWN)
            {
                return null;
            }

            if (FreeImage_FIFSupportsReading(fif) > 0)
            {
                dib = FreeImage_LoadFromMemory(fif, memory, 0);
            }

            if (dib == null)
            {
                return null;
            }

            var dib32bit = FreeImage_ConvertTo32Bits(dib);

            FreeImage_Unload(dib);
            FreeImage_CloseMemory(memory);

            var width = FreeImage_GetWidth(dib32bit);
            var height = FreeImage_GetHeight(dib32bit);

            var bits = FreeImage_GetBits(dib32bit);

            var len = width * height * 4;
            var bytes = new byte[len];

            Memcpy(bytes, 0, bits, 0, len);

            FreeImage_Unload(dib32bit);

            return new ImageDataAdapter(width, height, bytes);
        }

        internal unsafe static void Memcpy(byte[] dest, int destIndex, byte* src, int srcIndex, int len)
        {
            // If dest has 0 elements, the fixed statement will throw an 
            // IndexOutOfRangeException.  Special-case 0-byte copies.
            if (len == 0)
                return;

            fixed (byte* pDest = dest)
            {
                Memcpy(pDest + destIndex, src + srcIndex, len);
            }
        }

        [MethodImplAttribute(MethodImplOptions.Unmanaged)]
        internal extern unsafe static void llvm_memcpy_p0i8_p0i8_i32(byte* dst, byte* src, int len, int align, bool isVolotile);

        internal unsafe static void Memcpy(byte* dest, byte* src, int len)
        {
            llvm_memcpy_p0i8_p0i8_i32(dest, src, len, 4, false);
        }
    }
}
