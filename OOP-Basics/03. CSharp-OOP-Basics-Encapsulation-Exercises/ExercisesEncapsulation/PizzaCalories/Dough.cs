using System;

namespace PizzaCalories
{
    class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }


        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    InvalidDoughTypeException();
                }
                flourType = value;
            }
        }


        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value != "Chewy" && value != "Crispy" && value != "Homemade")
                {
                    InvalidDoughTypeException();
                }
                bakingTechnique = value;
            }
        }

        private int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    InvalidDoughWeightException();
                }
                weight = value;
            }
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
            double calories = this.Weight * 2;

            switch (this.FlourType)
            {
                case "White":
                    calories *= 1.5;
                    break;

                case "Wholegrain":
                    calories *= 1.0;
                    break;
            }

            switch (this.BakingTechnique)
            {
                case "Crispy":
                    return calories * 0.9;

                case "Chewy":
                    return calories * 1.1;

                case "Homemade":
                    return calories * 1.0;
            }

            return 0;
        }

        private static void InvalidDoughWeightException()
        {
            throw new ArgumentException("Dough weight should be in the range [1..200].");
        }

        private static void InvalidDoughTypeException()
        {
            throw new ArgumentException("Invalid type of dough.");
        }

    }

    //enum FlourType
    //{
    //    White = 15,
    //    Wholegrain = 10
    //}

    //enum BakingTechnique
    //{
    //    Crispy = 9,
    //    Chewy = 11,
    //    Homemade = 10
    //}
}
