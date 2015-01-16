using System;

namespace BABYLON
{
    public class GlFramebufferAdapter : Web.WebGLFramebuffer
    {
        public GlFramebufferAdapter(uint value)
        {
            this.Value = value;
        }

        public uint Value
        {
            get;
            private set;
        }
    }
}
