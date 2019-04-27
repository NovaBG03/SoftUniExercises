using System;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        RestaurantController controller;

        public Engine(RestaurantController restaurantController)
        {
            this.controller = restaurantController;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "AddFood":
                        this.AddFood(input);
                        break;
                    case "AddDrink":
                        this.AddDrink(input);
                        break;
                    case "AddTable":
                        this.AddTable(input);
                        break;
                    case "ReserveTable":
                        this.ReserveTable(input);
                        break;
                    case "OrderFood":
                        this.OrderFood(input);
                        break;
                    case "OrderDrink":
                        this.OrderDrink(input);
                        break;
                    case "LeaveTable":
                        this.LeaveTable(input);
                        break;
                    case "GetFreeTablesInfo":
                        Console.WriteLine(this.controller.GetFreeTablesInfo());
                        break;
                    case "GetOccupiedTablesInfo":
                        Console.WriteLine(this.controller.GetOccupiedTablesInfo());
                        break;
                    case "END":
                        Console.WriteLine(this.controller.GetSummary());
                        return;
                    default:
                        break;
                }

            }
        }

        private void LeaveTable(string[] input)
        {
            int tableNumber = int.Parse(input[1]);

            Console.WriteLine(this.controller.LeaveTable(tableNumber));
        }

        private void OrderDrink(string[] input)
        {
            int tableNumber = int.Parse(input[1]);
            string drinkName = input[2];
            string drinkBrand = input[3];

            Console.WriteLine(this.controller.OrderDrink(tableNumber, drinkName, drinkBrand));
        }

        private void OrderFood(string[] input)
        {
            int tableNumber = int.Parse(input[1]);
            string foodName = input[2];

            Console.WriteLine(this.controller.OrderFood(tableNumber, foodName));
        }

        private void ReserveTable(string[] input)
        {
            int numberOfPeople = int.Parse(input[1]);

            Console.WriteLine(this.controller.ReserveTable(numberOfPeople));
        }

        private void AddTable(string[] input)
        {
            string type = input[1];
            int tableNumber = int.Parse(input[2]);
            int capacity = int.Parse(input[3]);

            try
            {
                Console.WriteLine(this.controller.AddTable(type, tableNumber, capacity));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void AddDrink(string[] input)
        {
            string type = input[1];
            string name = input[2];
            int servingSize = int.Parse(input[3]);
            string brand = input[4];

            try
            {
                Console.WriteLine(controller.AddDrink(type, name, servingSize, brand));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void AddFood(string[] input)
        {
            string type = input[1];
            string name = input[2];
            decimal price = decimal.Parse(input[3]);

            try
            {
                Console.WriteLine(controller.AddFood(type, name, price));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
