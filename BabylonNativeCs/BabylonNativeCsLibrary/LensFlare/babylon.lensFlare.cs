// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.lensFlare.cs" company="">
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
    public partial class LensFlare
    {
        /// <summary>
        /// </summary>
        public Color3 color;

        /// <summary>
        /// </summary>
        public double position;

        /// <summary>
        /// </summary>
        public double size;

        /// <summary>
        /// </summary>
        public Texture texture;

        /// <summary>
        /// </summary>
        private readonly LensFlareSystem _system;

        /// <summary>
        /// </summary>
        /// <param name="size">
        /// </param>
        /// <param name="position">
        /// </param>
        /// <param name="color">
        /// </param>
        /// <param name="imgUrl">
        /// </param>
        /// <param name="system">
        /// </param>
        public LensFlare(double size, double position, Color3 color, string imgUrl, LensFlareSystem system)
        {
            this.size = size;
            this.position = position;
            this.color = color ?? new Color3(1, 1, 1);
            this.texture = (imgUrl != null) ? new Texture(imgUrl, system.getScene(), true) : null;
            this._system = system;
            system.lensFlares.Add(this);
        }

        /// <summary>
        /// </summary>
        public void dispose()
        {
            if (this.texture != null)
            {
                this.texture.dispose();
            }

            var index = this._system.lensFlares.IndexOf(this);
            this._system.lensFlares.RemoveAt(index);
        }
    }
}