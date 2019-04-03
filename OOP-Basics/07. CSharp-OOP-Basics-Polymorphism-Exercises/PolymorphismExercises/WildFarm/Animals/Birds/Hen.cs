using WildFarm.Foods.Contracts;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightIncrease = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;

            this.UpdateWeight(food.Quantity, weightIncrease);
        }
    }
}
