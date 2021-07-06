using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubator.Autopark.Entity.Class.MyCollections
{
    internal class MyQueue<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 10;
        private T[] _queue;
        private int _length;
        private int _endIndex;
        private int _startIndex;

        public MyQueue()
        {
            _queue = new T[DefaultCapacity];
        }

        public MyQueue(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("Queue length can`t be lower than 0", nameof(length));
            }
            _queue = new T[length];
            _length = length;
            _endIndex = 0;
            _startIndex = 0;
        }

        public MyQueue(T[] queue)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue), "Source data can`t be null!");
            _length = _queue.Length;
            _endIndex = _queue.Length - 1;
            _startIndex = 0;
        }
        
        public int Count => _endIndex - _startIndex;

        public void Resize()
        {
            var newQueue = new T[_length * 2];

            for (int i = 0; i < _queue.Length; i++)
            {
                newQueue[i] = _queue[i];
            }

            _queue = newQueue;
            _length *= 2;
        }

        public void Enqueue(T element)
        {
            if (_length - 1 == _endIndex)
            {
                Resize();
            }

            _queue.SetValue(element, _endIndex);
            _endIndex++;
        }

        public T Dequeue()
        {
            if (_startIndex != _endIndex)
            {
                var elementToDequeue = _queue[_startIndex];
                _startIndex++;

                return elementToDequeue;
            }

            return default;
        }

        public void Clear()
        {
            Array.Clear(_queue, 0, _queue.Length);
        }

        public bool Contains(T element)
        {
            for (int i = _startIndex; i < _endIndex; i++)
            {
                if (_queue[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var start = _startIndex;
            var end = _endIndex;
            while (start != end)
            {
                yield return _queue[end++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
