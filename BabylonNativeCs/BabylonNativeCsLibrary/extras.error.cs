// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.error.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BABYLON
{
    using System;

    /// <summary>
    /// </summary>
    public class Error : Exception
    {
        /// <summary>
        /// </summary>
        /// <param name="msg">
        /// </param>
        public Error(string msg)
            : base(msg)
        {
        }
    }
}