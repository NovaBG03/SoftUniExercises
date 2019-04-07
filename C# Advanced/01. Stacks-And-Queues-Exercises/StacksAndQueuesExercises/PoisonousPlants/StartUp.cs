using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();

            int day = -1;
            do
            {
                day++;
                plantsCount = plants.Count;

                for (int i = plants.Count - 1; i > 0; i--)
                {
                    if (plants[i - 1] < plants[i])
                    {
                        plants.RemoveAt(i);
                    }
                }
            }
            while (plantsCount != plants.Count);

            Console.WriteLine(day);
        }
    }
}
