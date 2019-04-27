using System;
using System.Linq;

namespace CustomComparator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
            Predicate<int> isEven = x => x % 2 == 0;

            Func<int, int, int> compareNumbers = (x, y) =>
            {
                if (isEven(x) && isEven(y))
                {
                    if (x > y)
                    {
                        return 1;
                    }

                    return -1;
                }

                if (isEven(x))
                {
                    return -1;
                }
                else if (isEven(y))
                {
                    return 1;
                }

                if (x > y)
                {
                    return 1;
                }

                return -1;
            };

            var numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            Array.Sort(
                numbers,
                new Comparison<int>(compareNumbers));

            print(numbers);
        }
    }
}
