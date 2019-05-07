using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class LakeEnumerator<T> : IEnumerator<T>
    {
        private List<T> list;
        private int index;

        public LakeEnumerator(List<T> list)
        {
            this.list = list;
            this.Reset();
        }


        private bool isInside => this.index < this.list.Count && this.index >= 0;

        public T Current => list[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index % 2 == 0)
            {
                index += 2;

                if (isInside)
                {
                    return true;
                }

                if (this.list.Count % 2 == 0)
                {
                    index--;
                    if (isInside)
                    {
                        return true;
                    }
                    return false;
                }

                index -= 3;
                if (isInside)
                {
                    return true;
                }
                return false;
            }

            index -= 2;

            if (isInside)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.index = -2;
        }
    }
}
