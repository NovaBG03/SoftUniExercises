using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] array)
        {
            this.index = 0;
            this.list = new List<T>(array);
        }

        public T Current => this.list[index];


        public bool MoveNext()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.index = 0;
        }

        public bool HasNext()
        {
            return this.index + 1 < this.list.Count;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(this.Current);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}
