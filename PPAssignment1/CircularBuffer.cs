using System;
using System.Threading;

namespace PPAssignment1
{
    public class CircularBuffer<T>
    {
        private readonly T[] buffer;
        private readonly int maxSize;
        private int first;
        private int last;
        private SemaphoreSlim sAdd;
        private SemaphoreSlim sFetch;

        public T EXIT { get; private set; }
        public int Count { get; private set; }

        public CircularBuffer(int size, T exitValue)
        {
            sAdd = new SemaphoreSlim(size,size);
            sFetch = new SemaphoreSlim(0, size);
            buffer = new T[maxSize = size];
            Count = first = last = 0;
            EXIT = exitValue;
        }

        public void Add(T item)
        {
            if (Count == maxSize)
            {
                throw new InvalidOperationException("Buffer is full");
            }
            buffer[first++] = item;
            first %= maxSize;
            Count++;
        }

        public T Fetch()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Buffer is empty");
            }
            T item = buffer[last++];
            last %= maxSize;
            Count--;
            return item;
        }
    }
}