using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON.Internals {
    public partial interface DDSInfo {
        double width {
            get;
        }
        double height {
            get;
        }
        double mipmapCount {
            get;
        }
        bool isFourCC {
            get;
        }
        bool isRGB {
            get;
        }
        bool isLuminance {
            get;
        }
        bool isCube {
            get;
        }
    }
    public partial class DDSTools {
        public static DDSInfo GetDDSInfo(object arrayBuffer) {
            var header = new Int32Array(arrayBuffer, 0, headerLengthInt);
            var mipmapCount = 1;
            if (header[off_flags] & DDSD_MIPMAPCOUNT) {
                mipmapCount = Math.Max(1, header[off_mipmapCount]);
            }
            return new {};
        }
        private static Uint8Array GetRGBAArrayBuffer(double width, double height, double dataOffset, double dataLength, ArrayBuffer arrayBuffer) {
            var byteArray = new Uint8Array(dataLength);
            var srcData = new Uint8Array(arrayBuffer);
            var index = 0;
            for (var y = height - 1; y >= 0; y--) {
                for (var x = 0; x < width; x++) {
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
        private static Uint8Array GetRGBArrayBuffer(double width, double height, double dataOffset, double dataLength, ArrayBuffer arrayBuffer) {
            var byteArray = new Uint8Array(dataLength);
            var srcData = new Uint8Array(arrayBuffer);
            var index = 0;
            for (var y = height - 1; y >= 0; y--) {
                for (var x = 0; x < width; x++) {
                    var srcPos = dataOffset + (x + y * width) * 3;
                    byteArray[index + 2] = srcData[srcPos];
                    byteArray[index + 1] = srcData[srcPos + 1];
                    byteArray[index] = srcData[srcPos + 2];
                    index += 3;
                }
            }
            return byteArray;
        }
        private static Uint8Array GetLuminanceArrayBuffer(double width, double height, double dataOffset, double dataLength, ArrayBuffer arrayBuffer) {
            var byteArray = new Uint8Array(dataLength);
            var srcData = new Uint8Array(arrayBuffer);
            var index = 0;
            for (var y = height - 1; y >= 0; y--) {
                for (var x = 0; x < width; x++) {
                    var srcPos = dataOffset + (x + y * width);
                    byteArray[index] = srcData[srcPos];
                    index++;
                }
            }
            return byteArray;
        }
        public static void UploadDDSLevels(WebGLRenderingContext gl, object ext, object arrayBuffer, DDSInfo info, bool loadMipmaps, double faces) {
            var header = new Int32Array(arrayBuffer, 0, headerLengthInt);
            var fourCC;
            var blockBytes;
            var internalFormat;
            var width;
            var height;
            var dataLength;
            var dataOffset;
            var byteArray;
            var mipmapCount;
            var i;
            if (header[off_magic] != DDS_MAGIC) {
                Tools.Error("Invalid magic number in DDS header");
                return;
            }
            if (!info.isFourCC && !info.isRGB && !info.isLuminance) {
                Tools.Error("Unsupported format, must contain a FourCC, RGB or LUMINANCE code");
                return;
            }
            if (info.isFourCC) {
                fourCC = header[off_pfFourCC];
                switch (fourCC) {
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
                        console.error("Unsupported FourCC code:", Int32ToFourCC(fourCC));
                        return;
                }
            }
            mipmapCount = 1;
            if (header[off_flags] & DDSD_MIPMAPCOUNT && loadMipmaps != false) {
                mipmapCount = Math.Max(1, header[off_mipmapCount]);
            }
            var bpp = header[off_RGBbpp];
            for (var face = 0; face < faces; face++) {
                var sampler = (faces == 1) ? gl.TEXTURE_2D : (gl.TEXTURE_CUBE_MAP_POSITIVE_X + face);
                width = header[off_width];
                height = header[off_height];
                dataOffset = header[off_size] + 4;
                for (i = 0; i < mipmapCount; ++i) {
                    if (info.isRGB) {
                        if (bpp == 24) {
                            dataLength = width * height * 3;
                            byteArray = DDSTools.GetRGBArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                            gl.texImage2D(sampler, i, gl.RGB, width, height, 0, gl.RGB, gl.UNSIGNED_BYTE, byteArray);
                        } else {
                            dataLength = width * height * 4;
                            byteArray = DDSTools.GetRGBAArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                            gl.texImage2D(sampler, i, gl.RGBA, width, height, 0, gl.RGBA, gl.UNSIGNED_BYTE, byteArray);
                        }
                    } else
                    if (info.isLuminance) {
                        var unpackAlignment = gl.getParameter(gl.UNPACK_ALIGNMENT);
                        var unpaddedRowSize = width;
                        var paddedRowSize = Math.floor((width + unpackAlignment - 1) / unpackAlignment) * unpackAlignment;
                        dataLength = paddedRowSize * (height - 1) + unpaddedRowSize;
                        byteArray = DDSTools.GetLuminanceArrayBuffer(width, height, dataOffset, dataLength, arrayBuffer);
                        gl.texImage2D(sampler, i, gl.LUMINANCE, width, height, 0, gl.LUMINANCE, gl.UNSIGNED_BYTE, byteArray);
                    } else {
                        dataLength = Math.Max(4, width) / 4 * Math.Max(4, height) / 4 * blockBytes;
                        byteArray = new Uint8Array(arrayBuffer, dataOffset, dataLength);
                        gl.compressedTexImage2D(sampler, i, internalFormat, width, height, 0, byteArray);
                    }
                    dataOffset += dataLength;
                    width *= 0.5;
                    height *= 0.5;
                    width = Math.Max(1.0, width);
                    height = Math.Max(1.0, height);
                }
            }
        }
    }
}