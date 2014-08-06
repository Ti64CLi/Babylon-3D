// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.multiMaterial.cs" company="">
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
    public partial class MultiMaterial : Material
    {
        /// <summary>
        /// </summary>
        public Array<Material> subMaterials = new Array<Material>();

        /// <summary>
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="scene">
        /// </param>
        public MultiMaterial(string name, Scene scene)
            : base(name, scene, true)
        {
            scene.multiMaterials.Add(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="index">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual Material getSubMaterial(int index)
        {
            if (index < 0 || index >= this.subMaterials.Length)
            {
                return this.getScene().defaultMaterial;
            }

            return this.subMaterials[index];
        }

        /// <summary>
        /// </summary>
        /// <param name="mesh">
        /// </param>
        /// <returns>
        /// </returns>
        public virtual bool isReady(AbstractMesh mesh = null)
        {
            for (var index = 0; index < this.subMaterials.Length; index++)
            {
                var subMaterial = this.subMaterials[index];
                if (subMaterial != null)
                {
                    if (!this.subMaterials[index].isReady(mesh))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}