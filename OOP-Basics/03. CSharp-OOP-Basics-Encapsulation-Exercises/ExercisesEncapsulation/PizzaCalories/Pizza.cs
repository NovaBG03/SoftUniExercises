using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
            this.Dough = null;
        }


        private string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 15 || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    InvalidNameException();
                }
                name = value;
            }
        }

        private List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public int NumberOfToppings
        {
            get
            {
                return Toppings.Count;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public double Calories
        {
            get
            {
                return this.CalculateCalories();
            }
        }


        private double CalculateCalories()
        {
            double calories = this.Dough.Calories;

            foreach (Topping topping in this.Toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings >= 10)
            {
                ToppingsOutOfRangeException();
            }

            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories";
        }

        private static void ToppingsOutOfRangeException()
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        private static void InvalidNameException()
        {
            throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
        }
    }
}
