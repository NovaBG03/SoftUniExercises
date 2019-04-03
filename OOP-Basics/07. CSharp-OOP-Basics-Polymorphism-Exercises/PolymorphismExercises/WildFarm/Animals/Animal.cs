using WildFarm.Animals.Contracts;
using WildFarm.Foods.Contracts;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }


        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; protected set; }


        public abstract string ProduceSound();

        public abstract void Eat(IFood food);

        protected void UpdateWeight(int foodQuantity, double weightIncrease)
        {
            double weight = foodQuantity * weightIncrease;
            this.Weight += weight;
        }
    }
}
