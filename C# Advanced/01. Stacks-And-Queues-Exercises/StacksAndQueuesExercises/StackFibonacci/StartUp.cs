using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int fibonacciCount = int.Parse(Console.ReadLine());
            fibonacciCount += 1;

            Stack<long> fibonacciStack = new Stack<long>();

            if (fibonacciCount != fibonacciStack.Count)
            {
                fibonacciStack.Push(0);
            }

            if (fibonacciCount != fibonacciStack.Count)
            {
                fibonacciStack.Push(1);
            }

            while (fibonacciCount != fibonacciStack.Count)
            {
                long biggerNumber = fibonacciStack.Pop();
                long smallerNumber = fibonacciStack.Peek();
                long nextFibonacci = biggerNumber + smallerNumber;

                fibonacciStack.Push(biggerNumber);
                fibonacciStack.Push(nextFibonacci);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
