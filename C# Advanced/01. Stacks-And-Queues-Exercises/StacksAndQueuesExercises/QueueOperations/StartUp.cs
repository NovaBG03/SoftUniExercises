using System;
using System.Collections.Generic;
using System.Linq;

namespace QueueOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int enqueueOperations = input[0];
            int dequeueOperations = input[1];
            int element = input[2];

            Queue<int> numbersQueue = new Queue<int>(enqueueOperations);

            input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < enqueueOperations; i++)
            {
                numbersQueue.Enqueue(input[i]);
            }

            for (int i = 0; i < dequeueOperations; i++)
            {
                if (numbersQueue.Count == 0)
                {
                    break;
                }

                numbersQueue.Dequeue();
            }

            if (numbersQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersQueue.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersQueue.Min());
            }
        }
    }
}
