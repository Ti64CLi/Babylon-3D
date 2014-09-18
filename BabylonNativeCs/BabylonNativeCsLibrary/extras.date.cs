// --------------------------------------------------------------------------------------------------------------------
// <copyright file="extras.date.cs" company="">
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
    public class Date
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public int getHours()
        {
            return DateTime.Now.Hour;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public int getMinutes()
        {
            return DateTime.Now.Minute;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public int getSeconds()
        {
            return DateTime.Now.Second;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public int getTime()
        {
            return (int)(DateTime.Now.Ticks / 1000);
        }
    }
}