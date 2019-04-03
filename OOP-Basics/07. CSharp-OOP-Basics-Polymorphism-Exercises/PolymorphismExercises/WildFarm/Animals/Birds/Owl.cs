using System;
using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightIncrease = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            if (food is Meat meat)
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
