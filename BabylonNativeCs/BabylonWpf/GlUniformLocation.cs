namespace BabylonWpf
{
    using System.Diagnostics;

    [DebuggerDisplay("{Name}({Value})")]
    public class GlUniformLocation : Web.WebGLUniformLocation
    {
        public GlUniformLocation(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public int Value
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
