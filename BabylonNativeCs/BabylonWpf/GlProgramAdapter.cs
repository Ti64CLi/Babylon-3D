<<<<<<< HEAD
﻿namespace BabylonWpf
=======
﻿namespace BABYLON
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
{
    using Web;

    public class GlProgramAdapter : WebGLProgram
    {
        public GlProgramAdapter(uint value)
        {
            this.Value = value;
        }

        public uint Value { get; private set; }
    }
}
