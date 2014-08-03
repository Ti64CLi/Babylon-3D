namespace BABYLON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Web;

    public class ArrayConvert
    {
        public static ushort[] AsUshort(int[] array)
        {
            var newArray = new ushort[array.Length];
            for (var index = 0; index < array.Length; index++)
            {
                newArray[index] = (ushort)array[index];
            }

            return newArray;
        }

        public static ushort[] AsUshort(Array<int> array)
        {
            var newArray = new ushort[array.Length];
            for (var index = 0; index < array.Length; index++)
            {
                newArray[index] = (ushort)array[index];
            }

            return newArray;
        }

        public static float[] AsFloat(double[] array)
        {
            var newArray = new float[array.Length];
            for (var index = 0; index < array.Length; index++)
            {
                newArray[index] = (float)array[index];
            }

            return newArray;
        }

        public static float[] AsFloat(Array<double> array)
        {
            var newArray = new float[array.Length];
            for (var index = 0; index < array.Length; index++)
            {
                newArray[index] = (float)array[index];
            }

            return newArray;
        }

        public static int[] AsInt(byte[] array, int start, int length)
        {
            var newArray = new int[length];
            for (var index = 0; index < length; index++)
            {
                newArray[index] = (byte)array[start + index];
            }

            return newArray;
        }

        public static byte[] AsByte(byte[] array, int start, int length)
        {
            var newArray = new byte[length];
            for (var index = 0; index < length; index++)
            {
                newArray[index] = (byte)array[start + index];
            }

            return newArray;
        }
    }

    public class Map<K, V> : Dictionary<K, V>
    {
    }

    public class Array<T> : List<T>
    {
        public Array()
        {
        }

        public Array(int capacity)
        {
            this.Capacity = capacity;
        }

        public Array(T item)
        {
            this.Add(item);
        }

        public Array(T item1, T item2)
        {
            this.Add(item1);
            this.Add(item2);
        }

        public Array(T item1, T item2, T item3)
        {
            this.Add(item1);
            this.Add(item2);
            this.Add(item3);
        }

        public Array(params T[] items)
        {
            this.AddRange(items);
        }

        public void push(T v1)
        {
            this.Add(v1);
        }

        public void push(T v1, T v2)
        {
            this.Add(v1);
            this.Add(v2);
        }

        public void push(T v1, T v2, T v3)
        {
            this.Add(v1);
            this.Add(v2);
            this.Add(v3);
        }

        public void push(params T[] items)
        {
            this.AddRange(items);
        }

        public int indexOf(T t)
        {
            return this.IndexOf(t);
        }

        public Array<T> slice(int index, int length = 0)
        {
            throw new NotImplementedException();
        }

        public string join(string joinSubstring)
        {
            var sb = new StringBuilder();
            var first = true;
            foreach (var item in this)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(joinSubstring);
                }

                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        public void splice(int index)
        {
            throw new NotImplementedException();
        }

        public void splice(int index, int size, Array<T> newKeys)
        {
            throw new NotImplementedException();
        }

        public void forEach(System.Action<T> func)
        {
            foreach (var item in this)
            {
                func(item);
            }
        }

        public Array<T> concat(Array<T> other)
        {
            foreach (var item in other)
            {
                this.Add(item);
            }
            return this;
        }

        public void sort(Func<T, T, int> compareFn)
        {
            this.Sort(new ComparerAdapter(compareFn));
        }

        #region Web Array

        public ArrayBuffer buffer { get; set; }

        public int byteOffset { get; set; }

        public int byteLength { get; set; }

        public int BYTES_PER_ELEMENT { get; set; }

        public int Length { 
            get 
            { 
                return this.Count; 
            }

            set
            {
                Capacity = value;
            }
        }

        public T get(int index)
        {
            throw new NotImplementedException();
        }

        public void set(int index, T value)
        {
            throw new NotImplementedException();
        }

        public void set(Array<T> array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        #endregion

        public T pop()
        {
            var t = this[Length - 1];
            this.RemoveAt(Length - 1);
            return t;
        }

        public class ComparerAdapter : IComparer<T>
        {
            private Func<T, T, int> compareFn;
            public ComparerAdapter(Func<T, T, int> compareFn)
            {
                this.compareFn = compareFn;
            }

            public int Compare(T x, T y)
            {
                return compareFn(x, y);
            }
        }
    }
}
