using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    public class GlBufferAdapter : Web.WebGLBuffer
    {
        public GlBufferAdapter(uint value)
        {
            this.Value = value;
        }

        public uint Value
        {
            get;
            private set;
        }

        public int references
        {
            get;
            set;
        }

        public int capacity
        {
            get;
            set;
        }
    }
}
