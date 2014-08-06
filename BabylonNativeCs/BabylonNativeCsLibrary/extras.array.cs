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
        public new V this[K k]
        {
            get
            {
                if (!this.ContainsKey(k))
                {
                    return default(V);
                }

                return base[k];
            }

            set
            {
                base[k] = value;
            }
        }
    }

    public class Array<T> : IEnumerable<T>
    {
        public Array()
        {
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

        public new T this[int i]
        {
            get
            {
                if (i >= Count)
                {
                    return default(T);
                }

                //return base[i];
                return default(T);
            }

            set
            {
                while (i >= Count)
                {
                    this.Add(default(T));
                }

                //base[i] = value;
            }
        }

        public void Add(T v1, T v2)
        {
            this.Add(v1);
            this.Add(v2);
        }

        public void Add(T v1, T v2, T v3)
        {
            this.Add(v1);
            this.Add(v2);
            this.Add(v3);
        }

        public void Add(params T[] items)
        {
            this.AddRange(items);
        }

        public Array<T> slice(int index, int length = 0)
        {
            throw new NotImplementedException();
        }

        public string Concat(string joinSubstring)
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

        public void splice(int index, int size, Array<T> newKeys)
        {
            throw new NotImplementedException();
        }

        public Array<T> Append(Array<T> other)
        {
            foreach (var item in other)
            {
                this.Add(item);
            }

            return this;
        }

        public void Sort(Func<T, T, int> compareFn)
        {
            this.Sort(new ComparerAdapter(compareFn));
        }

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

        public T Pop()
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

        #region implementation

        public int Capacity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int i)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T t)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Sort(ComparerAdapter comparerAdapter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
