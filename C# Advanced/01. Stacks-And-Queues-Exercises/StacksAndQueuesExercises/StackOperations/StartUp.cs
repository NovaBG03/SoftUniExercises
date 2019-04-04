using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pushOperations = input[0];
            int popOperations = input[1];
            int element = input[2];

            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbersStack = new Stack<int>();

            for (int i = 0; i < pushOperations; i++)
            {
                numbersStack.Push(input[i]);
            }

            for (int i = 0; i < popOperations; i++)
            {
                if (numbersStack.Count == 0)
                {
                    Console.WriteLine(0);
                    break;
                }

                numbersStack.Pop();
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersStack.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersStack.Min());
            }
        }
    }
}
