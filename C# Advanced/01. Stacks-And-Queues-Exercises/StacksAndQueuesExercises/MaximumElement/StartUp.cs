using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> numbersStack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int operation = input[0];
                switch (operation)
                {
                    case 1:
                        numbersStack.Push(input[1]);
                        break;
                    case 2:
                        numbersStack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(numbersStack.Max());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
