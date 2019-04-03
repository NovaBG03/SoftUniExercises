using WildFarm.Foods;
using WildFarm.Foods.Contracts;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string[] data)
        {
            string foodType = data[0];
            int quantity = int.Parse(data[1]);

            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    return null;
            }
        }
    }
}
