using System;
using System.Collections.Generic;
using System.Numerics;

namespace QueueSequence
{
    class StartUp
    {
        private static int membersCount = 50;

        static void Main(string[] args)
        {
            Queue<BigInteger> numbersQueue = new Queue<BigInteger>();

            BigInteger n = BigInteger.Parse(Console.ReadLine());
            numbersQueue.Enqueue(n);

            int counter = 0;
            while (true)
            {  
                n = numbersQueue.Dequeue();
                Console.Write(n + " ");
                counter++;

                if (counter == membersCount)
                {
                    break;
                }

                numbersQueue.Enqueue(n + 1);
                numbersQueue.Enqueue(2 * n + 1);
                numbersQueue.Enqueue(n + 2);

            }

        }
    }
}
