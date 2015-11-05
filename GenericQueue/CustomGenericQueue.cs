using System;
using System.Collections.Generic;
using System.Linq;


namespace CustomGenericQueue
{
    public class CustomGenericQueue<T>
    {
        private const int Minlength=10;
        private T[] _queue;
        private int _head = -1;
        private int _tail = -1;
        public int Count { get; set; } = 0;

        public CustomGenericQueue(int size)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            _queue=new T[size];
        }

        public CustomGenericQueue()
        {
            _queue=new T[Minlength];
        }

        public CustomGenericQueue(IEnumerable<T> collection)
        {
            if (collection==null)
                throw new ArgumentNullException(nameof(collection));
            _queue=new T[Math.Max(collection.Count(),Minlength)];
            foreach (var item in collection)
            {
                EnQueue(item);
            }
        } 

        public void EnQueue(T item)
        {
            if(Count==_queue.Length-1)
                Array.Resize(ref _queue,_queue.Length*2);
            if (Count==0)
            {
                _head++;
                _tail++;
                _queue[_tail] = item;
            }
            else
            {
                _tail = (_tail + 1)%_queue.Length;
                _queue[_tail] = item;
            }
            Count++;
        }

        public T DeQueue()
        {
            if (Count==0)
                throw new InvalidOperationException("Queue is empty!");
            T output = _queue[_head];
            _queue[_head] = default(T);
            _head = (_head + 1)%_queue.Length;
            return output;
        }

        public T Peek()
        {
            if (Count==0)
                throw new InvalidOperationException("Queue is empty!");
            return _queue[_head];
        }

        private T GetElement(int index)
        {
            if ((index<0)||(index>=_queue.Length))
                throw new ArgumentOutOfRangeException(nameof(index));
            return _queue[index];
        }

        public CustomQueueIterator Iterator => new CustomQueueIterator(this);

        public struct CustomQueueIterator
        {
            private readonly CustomGenericQueue<T> _queue;
            private int _currentIndex;
            private int _iteratedThrough;

            internal CustomQueueIterator(CustomGenericQueue<T> queue)
            {
                _currentIndex = -1;
                _queue = queue;
                _iteratedThrough = 0;
            }

            public T Current
            {
                get
                {
                    if (_currentIndex == -1 || _currentIndex == _queue.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return _queue.GetElement(_currentIndex);
                }
            }

            public void Reset()
            {
                _currentIndex = -1;
                _iteratedThrough = 0;
            }

            public bool MoveNext()
            {
                if (_currentIndex == -1)
                    _currentIndex = _queue._head;
                else
                {
                    _currentIndex = (_currentIndex + 1)%_queue.Count;
                }
                return ++_iteratedThrough < _queue.Count;
            }
        }
    }
}
 
