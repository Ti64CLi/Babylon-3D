using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using Web;

    class ImageDataAdapter : Web.ImageData
    {
        private int _width;
        private int _height;
        private byte[] _data;

        public ImageDataAdapter(Image bmp)
        {
            this.Bitmap = bmp;

            _width = this.Bitmap.Width;
            _height = this.Bitmap.Height;

            var data = ((Bitmap)bmp).LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);
            try
            {
                var ptr = (IntPtr)(long)data.Scan0;
                _data = new byte[bmp.Width * bmp.Height * sizeof(int)];
                System.Runtime.InteropServices.Marshal.Copy(ptr, _data, 0, _data.Length);
            }
            finally
            {
                ((Bitmap)bmp).UnlockBits(data);
            }
        }

        public Image Bitmap { get; private set; }

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

        public IntPtr dataBytesPointer
        {
            get { throw new NotImplementedException(); }
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
