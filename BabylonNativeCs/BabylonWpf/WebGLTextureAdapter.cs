namespace BabylonWpf
{
    using System;
    using Web;

    public class WebGLTextureAdapter : Web.WebGLTexture
    {
        public WebGLTextureAdapter(uint value)
        {
            this.Value = value;
        }

        public uint Value
        {
            get;
            private set;
        }

        public int _baseHeight
        {
            get;
            set;
        }

        public int _baseWidth
        {
            get;
            set;
        }

        public int _cachedCoordinatesMode
        {
            get;
            set;
        }

        public int _cachedWrapU
        {
            get;
            set;
        }

        public int _cachedWrapV
        {
            get;
            set;
        }

        public WebGLRenderbuffer _depthBuffer
        {
            get;
            set;
        }

        public WebGLFramebuffer _framebuffer
        {
            get;
            set;
        }

        public int _height
        {
            get;
            set;
        }

        public int _size
        {
            get;
            set;
        }

        public int _width
        {
            get;
            set;
        }

        public HTMLCanvasElement _workingCanvas
        {
            get;
            set;
        }

        public CanvasRenderingContext2D _workingContext
        {
            get;
            set;
        }

        public bool generateMipMaps
        {
            get;
            set;
        }

        public bool isCube
        {
            get;
            set;
        }

        public bool isReady
        {
            get;
            set;
        }

        public bool noMipmap
        {
            get;
            set;
        }

        public int references
        {
            get;
            set;
        }

        public string url
        {
            get;
            set;
        }
    }
}
