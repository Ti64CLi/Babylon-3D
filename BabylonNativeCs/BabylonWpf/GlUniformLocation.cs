namespace BabylonWpf
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
