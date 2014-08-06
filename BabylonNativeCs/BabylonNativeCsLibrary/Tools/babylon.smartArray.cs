// --------------------------------------------------------------------------------------------------------------------
// <copyright file="babylon.smartArray.cs" company="">
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
    /// <typeparam name="T">
    /// </typeparam>
    public partial class SmartArray<T> : Array<T> where T : class
    {
        /// <summary>
        /// </summary>
        /// <param name="capacity">
        /// </param>
        public SmartArray(int capacity)
        {
            this.Capacity = capacity;
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        public virtual void concatWithNoDuplicate(T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            if (this.Length + array.Length > this.Length)
            {
                this.Length = (this.Length + array.Length) * 2;
            }

            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                this.pushNoDuplicate(item);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="array">
        /// </param>
        public virtual void concatWithNoDuplicate(Array<T> array)
        {
            if (array.Length == 0)
            {
                return;
            }

            if (this.Length + array.Length > this.Length)
            {
                this.Length = (this.Length + array.Length) * 2;
            }

            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                this.pushNoDuplicate(item);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value">
        /// </param>
        public virtual void pushNoDuplicate(T value)
        {
            // TODO: finish it
            this.Add(value);
        }

        /// <summary>
        /// </summary>
        public void reset()
        {
            this.Clear();
        }
    }
}