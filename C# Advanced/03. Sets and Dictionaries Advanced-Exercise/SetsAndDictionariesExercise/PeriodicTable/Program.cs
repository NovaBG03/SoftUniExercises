using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();

            int elementsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < elementsCount; i++)
            {
                string[] inputElements = Console.ReadLine().Split();

                foreach (var element in inputElements)
                {
                    chemicalElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
