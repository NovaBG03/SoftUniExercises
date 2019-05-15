using System.Collections.Generic;

namespace StrategyPattern
{
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            if (first.Name.Length != second.Name.Length)
            {
                return first.Name.Length - second.Name.Length;
            }

            if (first.Name.ToLower().CompareTo(second.Name.ToLower()) != 0)
            {
                return first.Name.ToLower().CompareTo(second.Name.ToLower());
            }

            return 0;
        }
    }
}
