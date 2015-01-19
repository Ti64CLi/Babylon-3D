using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace BabylonWpf
=======
namespace BABYLON
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
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
