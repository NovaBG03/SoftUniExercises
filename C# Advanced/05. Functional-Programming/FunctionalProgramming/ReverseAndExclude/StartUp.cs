using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            Predicate<int> filter;

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            var number = int.Parse(Console.ReadLine());
            filter = x => x % number != 0;

            print(numbers.FindAll(filter));
        }
    }
}
