﻿using System;
using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double weightIncrease = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable vegetable)
            {
                this.FoodEaten += vegetable.Quantity;

                this.UpdateWeight(food.Quantity, weightIncrease);
            }
            else if (food is Meat meat)
            {
                this.FoodEaten += meat.Quantity;

                this.UpdateWeight(food.Quantity, weightIncrease);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
