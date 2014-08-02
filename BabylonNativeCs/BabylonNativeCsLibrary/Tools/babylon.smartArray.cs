using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Web;
namespace BABYLON
{
    public partial class SmartArray<T>
    {
        public Array<T> data;
        public int Length = 0;
        private int _id;
        private int _duplicateId = 0;
        public SmartArray(int capacity)
        {
            this.data = new Array<T>(capacity);
            this._id = SmartArray<T>._GlobalId++;
        }
        public virtual void push(T value)
        {
            this.data[this.Length++] = value;
            if (this.Length > this.data.Length)
            {
                this.data.Length *= 2;
            }
        }
        public virtual void pushNoDuplicate(T value)
        {
            // TODO: finish it
            this.push(value);
        }
        public virtual void sort(System.Func<T, T, int> compareFn)
        {
            this.data.sort(compareFn);
        }
        public virtual void reset()
        {
            this.Length = 0;
            this._duplicateId++;
        }
        public virtual void concat(T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > this.data.Length)
            {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                this.data[this.Length++] = array[index];
            }
        }
        public virtual void concat(Array<T> array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > this.data.Length)
            {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                this.data[this.Length++] = array[index];
            }
        }
        public virtual void concat(SmartArray<T> array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > this.data.Length)
            {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                this.data[this.Length++] = array.data[index];
            }
        }
        public virtual void concatWithNoDuplicate(T[] array)
        {
            if (array.Length == 0)
            {
                return;
            }
            if (this.Length + array.Length > this.data.Length)
            {
                this.data.Length = (this.Length + array.Length) * 2;
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
            if (this.Length + array.Length > this.data.Length)
            {
                this.data.Length = (this.Length + array.Length) * 2;
            }
            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                this.pushNoDuplicate(item);
            }
        }
        public virtual double indexOf(T value)
        {
            var position = this.data.indexOf(value);
            if (position >= this.Length)
            {
                return -1;
            }
            return position;
        }

        private static int _GlobalId = 0;
    }
}