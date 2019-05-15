using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubsequence
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var length = new int[numbers.Length];
            var prev = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentMaxLength = 1;
                int prevIndex = -1;

                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] < numbers[i] && currentMaxLength < length[j] + 1)
                    {
                        currentMaxLength = length[j] + 1;
                        prevIndex = j;
                    }
                }

                length[i] = currentMaxLength;
                prev[i] = prevIndex;
            }


            var result = new Stack<int>();

            int index = length
                .ToList()
                .IndexOf(length.Max());

            while (index != -1)
            {
                result.Push(numbers[index]);
                index = prev[index];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
