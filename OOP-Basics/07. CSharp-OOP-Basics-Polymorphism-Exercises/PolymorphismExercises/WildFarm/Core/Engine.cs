using System;
using System.Collections.Generic;
using WildFarm.Animals.Contracts;
using WildFarm.Factories;
using WildFarm.Foods.Contracts;

namespace WildFarm.Core
{
    public class Engine
    {
        List<IAnimal> animals;
        List<IFood> foods;
        AnimalFactory animalFactory;
        FoodFactory foodFactory;

        public Engine()
        {
            animals = new List<IAnimal>();
            foods = new List<IFood>();
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }

        public void Run()
        {
            int line = 0;
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (line % 2 == 0)
                {
                    IAnimal animal = animalFactory.CreateAnimal(input.Split());
                    if (animal == null)
                    {
                        continue;
                    }
                    animals.Add(animal);
                }
                else
	            {
                    IFood food = foodFactory.CreateFood(input.Split());
                    if (food == null)
                    {
                        continue;
                    }
                    foods.Add(food);
                }

                line++;
                input = Console.ReadLine();
            }

            for (int i = 0; i < foods.Count; i++)
            {
                IAnimal animal = animals[i];
                IFood food = foods[i];
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
