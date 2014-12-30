using System;

namespace BabylonGlut
{
    using Web;

    class ImageDataAdapter : Web.ImageData
    {
        private byte[] _data;

        public ImageDataAdapter()
        {
        }

        public Uint8Array data
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public byte[] dataBytes
        {
            get { return _data; }
            set { throw new NotImplementedException(); }
        }

        public int height
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int width
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
