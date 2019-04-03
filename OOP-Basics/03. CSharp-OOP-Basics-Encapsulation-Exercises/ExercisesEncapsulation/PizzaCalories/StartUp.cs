using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = input[1];

            Pizza pizza = new Pizza("No name");

            try
            {
                pizza = new Pizza(pizzaName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string flourType = input[1];
            string bakingTechnique = input[2];
            int doughWeight = int.Parse(input[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                pizza.Dough = dough;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                string toppingType = input[1];
                int toppingWeight = int.Parse(input[2]);

                try
                {
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }


            Console.WriteLine(pizza);
        }
    }
}
