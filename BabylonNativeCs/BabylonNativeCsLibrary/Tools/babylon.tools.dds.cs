// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.tools.dds.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON.Internals
{
    using System;

    using BabylonNativeCsLibrary;

    using Web;

    /// <summary>
    /// </summary>
    public partial interface DDSInfo
    {
        /// <summary>
        /// </summary>
        int height { get; }

        /// <summary>
        /// </summary>
        bool isCube { get; }

        /// <summary>
        /// </summary>
        bool isFourCC { get; }

        /// <summary>
        /// </summary>
        bool isLuminance { get; }

        /// <summary>
        /// </summary>
        bool isRGB { get; }

        /// <summary>
        /// </summary>
        int mipmapCount { get; }

        /// <summary>
        /// </summary>
        int width { get; }
    }

    /// <summary>
    /// </summary>
    public partial class DDSTools
    {
        /// <summary>
        /// </summary>
        /// <param name="arrayBuffer">
        /// </param>
        /// <returns>
        /// </returns>
        public static DDSInfo GetDDSInfo(byte[] arrayBuffer)
        {
            var header = ArrayConvert.AsInt(arrayBuffer, 0, headerLengthInt);
            var mipmapCount = 1;
            if ((header[off_flags] & DDSD_MIPMAPCOUNT) > 0)
            {
                mipmapCount = Math.Max(1, header[off_mipmapCount]);
            }

            return new DDSInfoDts
                       {
                           width = header[off_width], 
                           height = header[off_height], 
                           mipmapCount = mipmapCount, 
                           isFourCC = (header[off_pfFlags] & DDPF_FOURCC) == DDPF_FOURCC, 
                           isRGB = (header[off_pfFlags] & DDPF_RGB) == DDPF_RGB, 
                           isLuminance = (header[off_pfFlags] & DDPF_LUMINANCE) == DDPF_LUMINANCE, 
                           isCube = (header[off_caps2] & DDSCAPS2_CUBEMAP) == DDSCAPS2_CUBEMAP
                       };
        }

        /// <summary>
        /// </summary>
        /// <param name="gl">
        /// </param>
        /// <param name="ext">
        /// </param>
        /// <param name="arrayBuffer">
        /// </param>
        /// <param name="info">
        /// </param>
        /// <param name="loadMipmaps">
        /// </param>
        /// <param name="faces">
        /// </param>
        public static void UploadDDSLevels(
            WebGLRenderingContext gl, WEBGL_compressed_texture_s3tc ext, byte[] arrayBuffer, DDSInfo info, bool loadMipmaps, int faces)
        {
            var header = ArrayConvert.AsInt(arrayBuffer, 0, headerLengthInt);
            int fourCC;
            var blockBytes = 0;
            var internalFormat = 0;
            int width;
            int height;
            int dataLength;
            int dataOffset;
            byte[] byteArray;
            int mipmapCount;
            int i;
            if (header[off_magic] != DDS_MAGIC)
            {
                Tools.Error("Invalid magic number in DDS header");
                return;
            }

            if (!info.isFourCC && !info.isRGB && !info.isLuminance)
            {
                Tools.Error("Unsupported format, must contain a FourCC, RGB or LUMINANCE code");
                return;
            }

            if (info.isFourCC)
            {
                fourCC = header[off_pfFourCC];
                switch (fourCC)
                {
                    case FOURCC_DXT1:
                        blockBytes = 8;
                        internalFormat = ext.COMPRESSED_RGBA_S3TC_DXT1_EXT;
                        break;
                    case FOURCC_DXT3:
                        blockBytes = 16;
                        internalFormat = ext.COMPRESSED_RGBA_S3TC_DXT3_EXT;
                        break;
                    case FOURCC_DXT5:
                        blockBytes = 16;
                        internalFormat = ext.COMPRESSED_RGBA_S3TC_DXT5_EXT;
                        break;
                    default:
                        Engine.console.error("Unsupported FourCC code:", fourCC);
                        return;
                }
            }

            mipmapCount = 1;
            if ((header[off_flags] & DDSD_MIPMAPCOUNT) > 0 && loadMipmaps)
            {
                mipmapCount = Math.Max(1, header[off_mipmapCount]);
            }

            var bpp = header[off_RGBbpp];
            for (var face = 0; face < faces; face++)
            {
                var sampler = (faces == 1) ? Gl.TEXTURE_2D : (Gl.TEXTURE_CUBE_MAP_POSITIVE_X + face);
                width = header[off_width];
                height = header[off_height];
                dataOffset = header[off_size] + 4;
                for (i = 0; i < mipmapCount; ++i)
                {
                    if (info.isRGB)
                    {
                        if (bpp == 24)
                        {
                            dataLength = width * height * 3;
                            byteArray = GetRGBArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                            gl.texImage2D(sampler, i, Gl.RGB, width, height, 0, Gl.RGB, Gl.UNSIGNED_BYTE, byteArray);
                        }
                        else
                        {
                            dataLength = width * height * 4;
                            byteArray = GetRGBAArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                            gl.texImage2D(sampler, i, Gl.RGBA, width, height, 0, Gl.RGBA, Gl.UNSIGNED_BYTE, byteArray);
                        }
                    }
                    else if (info.isLuminance)
                    {
                        var unpackAlignment = (int)gl.getParameter(Gl.UNPACK_ALIGNMENT);
                        var unpaddedRowSize = width;
                        var paddedRowSize = (int)Math.Floor((width + unpackAlignment - 1) / unpackAlignment) * unpackAlignment;
                        dataLength = paddedRowSize * (height - 1) + unpaddedRowSize;
                        byteArray = GetLuminanceArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                        gl.texImage2D(sampler, i, Gl.LUMINANCE, width, height, 0, Gl.LUMINANCE, Gl.UNSIGNED_BYTE, byteArray);
                    }
                    else
                    {
                        dataLength = Math.Max(4, width) / 4 * Math.Max(4, height) / 4 * blockBytes;
                        byteArray = ArrayConvert.AsByte(arrayBuffer, dataOffset, dataLength);
                        gl.compressedTexImage2D(sampler, i, internalFormat, width, height, 0, byteArray);
                    }

                    dataOffset += dataLength;
                    width /= 2;
                    height /= 2;
                    width = Math.Max(1, width);
                    height = Math.Max(1, height);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="dataOffset">
        /// </param>
        /// <param name="dataLength">
        /// </param>
        /// <param name="arrayBuffer">
        /// </param>
        /// <returns>
        /// </returns>
        private static byte[] GetLuminanceArrayBuffer(int width, int height, int dataOffset, int dataLength, byte[] arrayBuffer)
        {
            var byteArray = new byte[dataLength];
            var srcData = arrayBuffer;
            var index = 0;
            for (var y = height - 1; y >= 0; y--)
            {
                for (var x = 0; x < width; x++)
                {
                    var srcPos = dataOffset + (x + y * width);
                    byteArray[index] = srcData[srcPos];
                    index++;
                }
            }

            return byteArray;
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="dataOffset">
        /// </param>
        /// <param name="dataLength">
        /// </param>
        /// <param name="arrayBuffer">
        /// </param>
        /// <returns>
        /// </returns>
        private static byte[] GetRGBAArrayBuffer(int width, int height, int dataOffset, int dataLength, byte[] arrayBuffer)
        {
            var byteArray = new byte[dataLength];
            var srcData = arrayBuffer;
            var index = 0;
            for (var y = height - 1; y >= 0; y--)
            {
                for (var x = 0; x < width; x++)
                {
                    var srcPos = dataOffset + (x + y * width) * 4;
                    byteArray[index + 2] = srcData[srcPos];
                    byteArray[index + 1] = srcData[srcPos + 1];
                    byteArray[index] = srcData[srcPos + 2];
                    byteArray[index + 3] = srcData[srcPos + 3];
                    index += 4;
                }
            }

            return byteArray;
        }

        /// <summary>
        /// </summary>
        /// <param name="width">
        /// </param>
        /// <param name="height">
        /// </param>
        /// <param name="dataOffset">
        /// </param>
        /// <param name="dataLength">
        /// </param>
        /// <param name="arrayBuffer">
        /// </param>
        /// <returns>
        /// </returns>
        private static byte[] GetRGBArrayBuffer(int width, int height, int dataOffset, int dataLength, byte[] arrayBuffer)
        {
            var byteArray = new byte[dataLength];
            var srcData = arrayBuffer;
            var index = 0;
            for (var y = height - 1; y >= 0; y--)
            {
                for (var x = 0; x < width; x++)
                {
                    var srcPos = dataOffset + (x + y * width) * 3;
                    byteArray[index + 2] = srcData[srcPos];
                    byteArray[index + 1] = srcData[srcPos + 1];
                    byteArray[index] = srcData[srcPos + 2];
                    index += 3;
                }
            }

            return byteArray;
        }

        /// <summary>
        /// </summary>
        public const int DDS_MAGIC = 0x20534444;

        /// <summary>
        /// </summary>
        public const int DDSD_CAPS = 0x1;

        /// <summary>
        /// </summary>
        public const int DDSD_HEIGHT = 0x2;

        /// <summary>
        /// </summary>
        public const int DDSD_WIDTH = 0x4;

        /// <summary>
        /// </summary>
        public const int DDSD_PITCH = 0x8;

        /// <summary>
        /// </summary>
        public const int DDSD_PIXELFORMAT = 0x1000;

        /// <summary>
        /// </summary>
        public const int DDSD_MIPMAPCOUNT = 0x20000;

        /// <summary>
        /// </summary>
        public const int DDSD_LINEARSIZE = 0x80000;

        /// <summary>
        /// </summary>
        public const int DDSD_DEPTH = 0x800000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS_COMPLEX = 0x8;

        /// <summary>
        /// </summary>
        public const int DDSCAPS_MIPMAP = 0x400000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS_TEXTURE = 0x1000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP = 0x200;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_POSITIVEX = 0x400;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_NEGATIVEX = 0x800;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_POSITIVEY = 0x1000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_NEGATIVEY = 0x2000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_POSITIVEZ = 0x4000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_CUBEMAP_NEGATIVEZ = 0x8000;

        /// <summary>
        /// </summary>
        public const int DDSCAPS2_VOLUME = 0x200000;

        /// <summary>
        /// </summary>
        public const int DDPF_ALPHAPIXELS = 0x1;

        /// <summary>
        /// </summary>
        public const int DDPF_ALPHA = 0x2;

        /// <summary>
        /// </summary>
        public const int DDPF_FOURCC = 0x4;

        /// <summary>
        /// </summary>
        public const int DDPF_RGB = 0x40;

        /// <summary>
        /// </summary>
        public const int DDPF_YUV = 0x200;

        /// <summary>
        /// </summary>
        public const int DDPF_LUMINANCE = 0x20000;

        /// <summary>
        /// </summary>
        public const int headerLengthInt = 31; // The header length in 32 bit ints

        // Offsets into the header array
        /// <summary>
        /// </summary>
        public const int off_magic = 0;

        /// <summary>
        /// </summary>
        public const int off_size = 1;

        /// <summary>
        /// </summary>
        public const int off_flags = 2;

        /// <summary>
        /// </summary>
        public const int off_height = 3;

        /// <summary>
        /// </summary>
        public const int off_width = 4;

        /// <summary>
        /// </summary>
        public const int off_mipmapCount = 7;

        /// <summary>
        /// </summary>
        public const int off_pfFlags = 20;

        /// <summary>
        /// </summary>
        public const int off_pfFourCC = 21;

        /// <summary>
        /// </summary>
        public const int off_RGBbpp = 22;

        /// <summary>
        /// </summary>
        public const int off_RMask = 23;

        /// <summary>
        /// </summary>
        public const int off_GMask = 24;

        /// <summary>
        /// </summary>
        public const int off_BMask = 25;

        /// <summary>
        /// </summary>
        public const int off_AMask = 26;

        /// <summary>
        /// </summary>
        public const int off_caps1 = 27;

        /// <summary>
        /// </summary>
        public const int off_caps2 = 28;

        /// <summary>
        /// </summary>
        public const int FOURCC_DXT1 = 'D' + ('X' << 8) + ('T' << 16) + ('1' << 24);

        /// <summary>
        /// </summary>
        public const int FOURCC_DXT3 = 'D' + ('X' << 8) + ('T' << 16) + ('3' << 24);

        /// <summary>
        /// </summary>
        public const int FOURCC_DXT5 = 'D' + ('X' << 8) + ('T' << 16) + ('5' << 24);
    }
}