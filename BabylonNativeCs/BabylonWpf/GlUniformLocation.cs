<<<<<<< HEAD
﻿namespace BabylonWpf
=======
﻿namespace BABYLON
>>>>>>> f265f07661031677698c527dcba26356bdf55cab
{
    using System.Diagnostics;

    public class GlUniformLocation : Web.WebGLUniformLocation
    {
        public GlUniformLocation(int value)
        {
            this.Value = value;
        }

        public int Value
        {
            get;
            private set;
        }
    }
}
