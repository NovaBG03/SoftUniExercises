using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> nNumbers = new HashSet<int>();
            HashSet<int> mNumbers = new HashSet<int>();
            HashSet<int> repeatingElements = new HashSet<int>();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int m = input[1];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                nNumbers.Add(number);
            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());

                mNumbers.Add(number);
            }

            foreach (var number in nNumbers)
            {
                if (mNumbers.Contains(number))
                {
                    repeatingElements.Add(number);
                }
            }


            Console.WriteLine(string.Join(" ", repeatingElements));
        }
    }
}
