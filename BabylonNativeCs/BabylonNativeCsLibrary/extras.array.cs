namespace BABYLON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Web;

    public class Map<K, V> : Dictionary<K, V>
    {        
    }

    public class Array<T> : IEnumerable<T>
    {
        public Array()
        {
            throw new NotImplementedException();
        }

        public Array(T item)
        {
            throw new NotImplementedException();
        }

        public Array(T item1, T item2)
        {
            throw new NotImplementedException();
        }

        public Array(T item1, T item2, T item3)
        {
            throw new NotImplementedException();
        }

        public Array(params T[] items)
        {
            throw new NotImplementedException();
        }

        public void push(T v)
        {
            throw new NotImplementedException();
        }

        public void push(T v1, T v2)
        {
            throw new NotImplementedException();
        }

        public int indexOf(T t)
        {
            throw new NotImplementedException();
        }

        public Array<T> slice(int index)
        {
            throw new NotImplementedException();
        }

        public string join(string joinSubstr)
        {
            throw new NotImplementedException();
        }

        public void splice(int index)
        {
            throw new NotImplementedException();
        }

        public void splice(int index, int size)
        {
            throw new NotImplementedException();
        }

        public void splice(int index, int size, Array<T> newKeys)
        {
            throw new NotImplementedException();
        }

        public void forEach(System.Action<T> func)
        {
            throw new NotImplementedException();
        }

        public T this[int subIndex]
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

        public Array<string> concat(Array<string> samplers)
        {
            throw new NotImplementedException();
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Float32Array : Array<float>, Web.Float32Array
    {
        public Float32Array(int reserveSize)
        {
        }

        public Float32Array(Array<float> array)
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
    }

    public class Int32Array : Array<int>, Web.Int32Array
    {
        public Int32Array(int reserveSize)
        {
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
        }

        public Uint8Array(ArrayBuffer arrayBuffer)
        {
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
