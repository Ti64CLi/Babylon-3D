using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    using Web;

    public class GlShaderAdapter : Web.WebGLShader
    {
        public GlShaderAdapter(uint value)
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
