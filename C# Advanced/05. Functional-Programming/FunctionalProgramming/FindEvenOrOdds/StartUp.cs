using System;
using System.Collections.Generic;

namespace FindEvenOrOdds
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Predicate<int> filter = x => true;

            Func<int, int, List<int>> getRange = (x, y) =>
            {
                List<int> list = new List<int>(y - x + 1);

                for (int i = x; i <= y; i++)
                {
                    list.Add(i);
                }

                return list;
            };

            var input = Console.ReadLine().Split();
            int firstNumber = int.Parse(input[0]);
            int lastNumber = int.Parse(input[1]);

            string command = Console.ReadLine();

            switch (command)
            {
                case "odd":
                    filter = x => x % 2 != 0;
                    break;
                case "even":
                    filter = x => x % 2 == 0;
                    break;
                default:
                    break;
            }

            Console.WriteLine(
                string.Join(
                    " ", 
                    getRange(firstNumber, lastNumber)
                    .FindAll(filter)));
        }
    }
}
