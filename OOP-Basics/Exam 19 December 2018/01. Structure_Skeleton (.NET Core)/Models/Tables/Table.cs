using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }


        public int TableNumber { get; private set; }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get { return this.CalculatePrice(); }
        }


        private decimal CalculatePrice()
        {
            return this.NumberOfPeople * this.PricePerPerson;
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            if (foodOrders.Count != 0)
            {
                bill += foodOrders.Sum(f => f.Price);
            }

            if (drinkOrders.Count != 0)
            {
                bill += drinkOrders.Sum(d => d.Price);
            }

            return bill;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");

            return builder.ToString().Trim();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                builder.AppendLine($"Food orders: None");
            }
            else
            {
                builder.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (Food food in this.foodOrders)
                {
                    builder.AppendLine(food.ToString());
                }
            }

            if (this.drinkOrders.Count == 0)
            {
                builder.AppendLine($"Drink orders: None");
            }
            else
            {
                builder.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (Drink drink in this.drinkOrders)
                {
                    builder.AppendLine(drink.ToString());
                }
            }

            return builder.ToString().Trim();
        }
    }
}
