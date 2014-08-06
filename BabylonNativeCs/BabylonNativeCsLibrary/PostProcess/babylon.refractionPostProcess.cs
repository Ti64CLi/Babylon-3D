// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.refractionPostProcess.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    /// <summary>
    /// </summary>
    public partial class RefractionPostProcess : PostProcess
    {
        /// <summary>
        /// </summary>
        public Color3 color;

        /// <summary>
        /// </summary>
        public double colorLevel;

        /// <summary>
        /// </summary>
        public double depth;

        /// <summary>
        /// </summary>
        private Texture _refRexture;

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="refractionTextureUrl">
        /// </param>
        /// <param name="color">
        /// </param>
        /// <param name="depth">
        /// </param>
        /// <param name="colorLevel">
        /// </param>
        /// <param name="ratio">
        /// </param>
        /// <param name="camera">
        /// </param>
        /// <param name="samplingMode">
        /// </param>
        /// <param name="engine">
        /// </param>
        /// <param name="reusable">
        /// </param>
        public RefractionPostProcess(
            string name, 
            string refractionTextureUrl, 
            Color3 color, 
            double depth, 
            double colorLevel, 
            double ratio, 
            Camera camera, 
            int samplingMode = 0, 
            Engine engine = null, 
            bool reusable = false)
            : base(
                name, 
                "refraction", 
                new Array<string>("baseColor", "depth", "colorLevel"), 
                new Array<string>("refractionSampler"), 
                ratio, 
                camera, 
                samplingMode, 
                engine, 
                reusable)
        {
            this.color = color;
            this.depth = depth;
            this.colorLevel = colorLevel;

            this.onActivate = (Camera cam) => { this._refRexture = this._refRexture ?? new Texture(refractionTextureUrl, cam.getScene()); };
            this.onApply = (Effect effect) =>
                {
                    effect.setColor3("baseColor", this.color);
                    effect.setFloat("depth", this.depth);
                    effect.setFloat("colorLevel", this.colorLevel);
                    effect.setTexture("refractionSampler", this._refRexture);
                };
        }

        /// <summary>
        /// </summary>
        /// <param name="camera">
        /// </param>
        public override void dispose(Camera camera)
        {
            if (this._refRexture != null)
            {
                this._refRexture.dispose();
            }

            base.dispose(camera);
        }
    }
}