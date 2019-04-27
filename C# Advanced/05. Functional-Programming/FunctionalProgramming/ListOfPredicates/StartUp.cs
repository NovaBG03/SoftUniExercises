using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            Func<int, HashSet<int>, List<int>> getNumbers = (ln, ds) =>
            {
                List<int> ls = new List<int>();

                for (int i = 1; i <= ln; i++)
                {
                    if (ds.All(d => i % d == 0))
                    {
                        ls.Add(i);
                    }
                }

                return ls;
            };


            print(getNumbers(
                    int.Parse(Console.ReadLine()),
                    Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToHashSet()));
        }
    }
}
