using System;
using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double weightIncrease = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight,livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
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
