using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator.Autopark.Entity.Class.MyCollections
{
    public class MyStack<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private const int DefaultCapacity = 10;

        public MyStack()
        {
            _array = new T [DefaultCapacity];
        }
        
        public MyStack(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Error, Index out of range");

            _array = new T[count];
        }
        
        public MyStack(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection), "Error, collection can`t be null");

            var i = 0;
            foreach (var element in collection)
            {
                _array[i] = element;
                i++;
            }

        }

        public int Count => _array.Length;

        public void Clear()
        {
            Array.Clear(_array, 0, Count);
        }

        public T Pop()
        {
            var size = Count - 1;

            if ((uint)size >= (uint)_array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "size can`t be >= length");
            }
            
            return _array[size];
        }
        
        public void Push(T item)
        {
            var size = Count;
            var array = _array;

            if ((uint)size < (uint)array.Length)
            {
                array[size] = item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in _array)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
