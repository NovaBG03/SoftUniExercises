using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> petrolQueue = new Queue<int>(n);

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrol = input[0] - input[1];
                petrolQueue.Enqueue(petrol);
            }

            for (int i = 0; i < petrolQueue.Count; i++)
            {
                int petrolInTank = 0;
                bool IsCompleted = true;

                for (int j = 0; j < petrolQueue.Count; j++)
                {
                    int petrol = petrolQueue.Dequeue();
                    petrolQueue.Enqueue(petrol);
                    petrolInTank += petrol;

                    if (petrolInTank < 0)
                    {
                        IsCompleted = false;
                    }
                }

                if (IsCompleted)
                {
                    Console.WriteLine(i);
                    break;
                }

                
                petrolQueue.Enqueue(petrolQueue.Dequeue());
            }
            
        }   
    }       
}