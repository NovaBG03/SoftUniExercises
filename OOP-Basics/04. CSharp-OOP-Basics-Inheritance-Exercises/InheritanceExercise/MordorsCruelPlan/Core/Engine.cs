using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MordorsCruelPlan.Foods;
using MordorsCruelPlan.Moods;
using MordorsCruelPlan.Factories;

namespace MordorsCruelPlan.Core
{
    class Engine
    {
        private List<Food> foods;
        private Mood mood;

        public void Run()
        {
            foods = new List<Food>();

            string[] data = Console.ReadLine().ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in data)
            {
                Food food = FoodFactory.CreateFood(name);
                foods.Add(food);
            }

            int happiness = CalculateHappiness();

            mood = MoodFactory.CreateMood(happiness);

            Print();
        }

        private void Print()
        {
            Console.WriteLine(mood.Happiness);
            Console.WriteLine(mood.Name);
        }

        private int CalculateHappiness()
        {
            return foods.Sum(f => f.HappinessPoints);
        }
    }
}
