using System;

namespace BABYLON
{
    public class GlRenderbufferAdapter : Web.WebGLRenderbuffer
    {
        public GlRenderbufferAdapter(uint value)
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
