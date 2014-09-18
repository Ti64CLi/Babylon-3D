// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.interfaces.cs" company="">
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
    public interface IAnimatableProperty
    {
        /// <summary>
        /// </summary>
        /// <param name="subPropertyName">
        /// </param>
        /// <returns>
        /// </returns>
        IAnimatableProperty this[string subPropertyName] { get; set; }

        /// <summary>
        /// </summary>
        object value { get; set; }
    }

    /// <summary>
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        object clone();
    }
}