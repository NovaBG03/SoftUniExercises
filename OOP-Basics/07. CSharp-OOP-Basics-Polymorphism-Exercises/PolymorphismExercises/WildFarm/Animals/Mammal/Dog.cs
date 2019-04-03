using System;
using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double weightIncrease = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
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
