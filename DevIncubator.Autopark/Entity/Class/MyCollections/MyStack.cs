using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubator.Autopark.Entity.Class.MyCollections
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size;

        private const int DefaultCapacity = 10;

        public MyStack()
        {
            _array = new T [DefaultCapacity];
        }

        // Create a stack with a specific initial count.  The initial count
        // must be a non-negative number.
        public MyStack(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Error, Index out of range");

            _array = new T[count];
        }

        // Fills a MyStack with the contents of a particular collection.  The items are
        // pushed onto the stack in the same order they are read by the enumerator.
        public MyStack(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            _array = collection.ToArray();
        }
        public int Count => _size;
        
        // Removes all Objects from the MyStack.
        public void Clear()
        {
            Array.Clear(_array, 0, _size);
            _size = 0;
        }
        public T Pop()
        {
            var size = _size - 1;

            if ((uint)size >= (uint)_array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "size can`t be >= length");
            }
            
            return _array[size];
        }

        // Pushes an item to the top of the stack.
        public void Push(T item)
        {
            var size = _size;
            var array = _array;

            if ((uint)size < (uint)array.Length)
            {
                array[size] = item;
                _size = size + 1;
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
