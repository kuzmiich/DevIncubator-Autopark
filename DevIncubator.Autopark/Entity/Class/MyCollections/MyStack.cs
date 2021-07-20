using System;
using System.Collections;
using System.Collections.Generic;

namespace DevIncubator.Autopark.Entity.Class.MyCollections
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] _array;

        private const int DefaultCapacity = 10;

        public MyStack()
        {
            _array = new T[DefaultCapacity];
        }
        
        public MyStack(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Error, index out of range");

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

        public int Count { get; private set; }

        public void Clear()
        {
            Array.Clear(_array, 0, Count);
            Count = 0;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException( "Error, array is empty");
            
            var item = _array[--Count];
            _array[Count] = default;

            return item;
        }
        
        public void Push(T item)
        {
            if (Count == _array.Length)
            {
                var newArray = new T[_array.Length + 1];
                Array.Copy(_array, newArray, Count);
                _array = newArray;
            }
            _array[Count] = item;
            Count += 1;
        }

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) _array.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
