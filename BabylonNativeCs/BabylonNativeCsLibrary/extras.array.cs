namespace BABYLON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Web;

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

        public Array<T> splice(int index, int size)
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

        public int Length { get; set; }

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

    public class Float32Array : Array<float>, Web.Float32Array
    {
        public Float32Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public Float32Array(Array<float> array)
        {
            throw new NotImplementedException();
        }

        public Float32Array(Array<double> array)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Float32Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Float32Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }

        public double this[int subIndex]
        {
            get
            {
                return (double)base[subIndex];
            }
            set
            {
                base[subIndex] = (float)value;
            }
        }
    }

    public class Int32Array : Array<int>, Web.Int32Array
    {
        public Int32Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public Int32Array(ArrayBuffer arrayBuffer, int start, int count)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Int32Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Int32Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }
    }

    public class Uint8Array : Array<byte>, Web.Uint8Array
    {
        public Uint8Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public Uint8Array(ArrayBuffer arrayBuffer)
        {
            throw new NotImplementedException();
        }

        public Uint8Array(ArrayBuffer arrayBuffer, int start, int count)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Uint8Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Uint8Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }
    }

    public class Int8Array : Array<sbyte>, Web.Int8Array
    {
        public Int8Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Int8Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Int8Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }
    }

    public class Int16Array : Array<short>, Web.Int16Array
    {
        public Int16Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Int16Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Int16Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }
    }

    public class Uint16Array : Array<ushort>, Web.Uint16Array
    {
        public Uint16Array(int reserveSize)
        {
            throw new NotImplementedException();
        }

        public Uint16Array(Array<int> array)
        {
            throw new NotImplementedException();
        }

        public void set(Web.Uint16Array array, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Web.Uint16Array subarray(int begin, int end = 0)
        {
            throw new NotImplementedException();
        }
    }
}
