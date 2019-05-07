using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> list;

        public Lake()
        {
            this.list = new List<T>();
        }

        public Lake(List<T> list)
        {
            this.list = new List<T>(list);
        }


        public void Add(T item)
        {
            this.list.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LakeEnumerator<T>(this.list);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
