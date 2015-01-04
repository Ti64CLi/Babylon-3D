using System;

namespace Babylon
{
    using Web;

    public class ImageDataAdapter : Web.ImageData
    {
        private IntPtr _data;
        private byte[] _dataBytes;
        private int _width;
        private int _height;

        public unsafe ImageDataAdapter(int width, int height, IntPtr data)
        {
            this._width = width;
            this._height = height;
            this._data = data;
        }

        public unsafe ImageDataAdapter(int width, int height, byte[] dataBytes)
        {
            this._width = width;
            this._height = height;
            this._dataBytes = dataBytes;
        }

        public Uint8Array data
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public byte[] dataBytes
        {
            get { return _dataBytes; }
            set { throw new NotImplementedException(); }
        }

        public unsafe IntPtr dataBytesPointer
        {
            get { return _data; }
            set { throw new NotImplementedException(); }
        }

        public int height
        {
            get { return _height; }
            set { throw new NotImplementedException(); }
        }

        public int width
        {
            get { return _width; }
            set { throw new NotImplementedException(); }
        }
    }
}
