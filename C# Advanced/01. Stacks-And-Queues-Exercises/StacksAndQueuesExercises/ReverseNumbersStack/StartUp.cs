using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbersStack = new Stack<int>(input);

            Console.WriteLine(string.Join(" ", numbersStack));
        }
    }
}
