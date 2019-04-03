using System;
using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double weightIncrease = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable vegetable)
            {
                this.FoodEaten += vegetable.Quantity;

                this.UpdateWeight(food.Quantity, weightIncrease);
            }
            else if (food is Fruit fruit)
            {
                this.FoodEaten += fruit.Quantity;

                this.UpdateWeight(food.Quantity, weightIncrease);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
