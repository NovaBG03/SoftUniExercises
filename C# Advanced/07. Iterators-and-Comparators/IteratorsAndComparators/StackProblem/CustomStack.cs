using System;
using System.Collections;
using System.Collections.Generic;

namespace StackProblem 
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private class CustomStackEnumberator : IEnumerator<T>
        {
            private T[] array;
            private int index;
            private int count;

            public CustomStackEnumberator(T[] array, int count)
            {
                this.array = array;
                this.count = count;
                this.Reset();
            }

            public T Current => this.array[index];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index--;

                if (this.index == -1)
                {
                    this.Reset();
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                this.index = this.count;
            }
        }

        private T[] array;

        public CustomStack()
        {
            this.array = new T[4];
            this.Count = 0;
        }

        public int Capacity => this.array.Length;

        public int Count { get; private set; }

        public bool IsFill => this.Capacity == this.Count;


        public void Push(T item)
        {
            if (this.IsFill)
            {
                this.Resize();
            }

            array[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("No elements");
            }

            this.Count--;
            return this.array[Count];
        }

        private void Resize()
        {
            int newCapacity = this.Capacity * 2;
            T[] resizedArray = new T[newCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                resizedArray[i] = this.array[i];
            }

            this.array = resizedArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomStackEnumberator(this.array, this.Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
         => this.GetEnumerator();
    }
}
