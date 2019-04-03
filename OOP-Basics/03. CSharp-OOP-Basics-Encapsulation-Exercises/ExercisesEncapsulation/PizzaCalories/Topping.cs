using System;

namespace PizzaCalories
{
    class Topping
    {
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }


        private string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value != "Meat" && value != "Veggies" 
                    && value != "Cheese" && value != "Sauce")
                {
                    ToppingTypeException(value);
                }
                toppingType = value;
            }
        }

        private int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    ToppingWeightException();
                }
                weight = value;
            }
        }

        public double Calories
        {
            get { return this.CalculateCalories(); }
        }


        private double CalculateCalories()
        {
            double calories = this.Weight * 2;

            switch (this.ToppingType)
            {
                case "Meat":
                    return calories * 1.2;

                case "Veggies":
                    return calories * 0.8;

                case "Cheese":
                    return calories * 1.1;

                case "Sauce":
                    return calories * 0.9;
            }

            return 0;
        }

        private void ToppingWeightException()
        {
            throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
        }

        private static void ToppingTypeException(string value)
        {
            throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        }

    }
}
