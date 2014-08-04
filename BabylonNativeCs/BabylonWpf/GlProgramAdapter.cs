namespace BabylonWpf
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
