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
