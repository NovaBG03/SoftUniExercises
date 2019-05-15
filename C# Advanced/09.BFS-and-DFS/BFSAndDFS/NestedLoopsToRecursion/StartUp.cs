using System;
using System.Collections.Generic;

namespace NestedLoopsToRecursion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var loopsCount = int.Parse(Console.ReadLine());

            Print(loopsCount, new List<int>());
        }

        private static void Print(int lastNumber, List<int> numbers, int counter = 1)
        {
            if (lastNumber < counter)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int i = 1; i <= lastNumber; i++)
            {
                numbers.Add(i);
                Print(lastNumber, numbers, counter + 1);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
    }
}
