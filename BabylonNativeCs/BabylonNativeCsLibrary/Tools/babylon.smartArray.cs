using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{

    public partial class SmartArray<T> : Array<T>
    {
        public SmartArray(int capacity)
        {
            Capacity = capacity;
        }
        public void reset()
        {
            this.Clear();
        }

        public virtual void pushNoDuplicate(T value)
        {
            // TODO: finish it
            this.Add(value);
        }
        public virtual void concatWithNoDuplicate(T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > Length)
            {
                Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                this.pushNoDuplicate(item);
            }
        }
        public virtual void concatWithNoDuplicate(Array<T> array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > Length)
            {
                Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                this.pushNoDuplicate(item);
            }
        }
    }
}