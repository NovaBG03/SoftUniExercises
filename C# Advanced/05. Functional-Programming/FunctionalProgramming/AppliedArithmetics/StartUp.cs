using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));
            Func<List<int>, List<int>> addOne = x => x.Select(y => ++y).ToList();
            Func<List<int>, List<int>> multiplyByTwo = x => x.Select(y => y * 2).ToList();
            Func<List<int>, List<int>> subtractOne = x => x.Select(y => --y).ToList();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = addOne(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyByTwo(numbers);
                        break;
                    case "subtract":
                        numbers = subtractOne(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
