using System.Collections.Generic;

namespace StrategyPattern
{
    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age - second.Age;
        }
    }
}
