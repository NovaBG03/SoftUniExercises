using WildFarm.Animals.Birds;
using WildFarm.Animals.Contracts;
using WildFarm.Animals.Mammal;
using WildFarm.Animals.Mammal.Feline;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string[] data)
        {
            //•	Birds - "{Type} {Name} {Weight} {WingSize}";
            //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";
            //•	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";

            string type = data[0];
            
            switch (type)
            {
                case "Owl":
                case "Hen":
                    return this.CreateBird(data);
                case "Mouse":
                case "Dog":
                case "Cat":
                case "Tiger":
                    return this.CreateMammal(data);
                default:
                    return null;
            }
        }

        private IAnimal CreateMammal(string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);
            string livingRegion = data[3];

            switch (type)
            {
                case "Mouse":
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    return new Dog(name, weight, livingRegion);
                case "Cat":
                    string catBreed = data[4];
                    return new Cat(name, weight, livingRegion, catBreed);
                case "Tiger":
                    string tigerBreed = data[4];
                    return new Tiger(name, weight, livingRegion, tigerBreed);
                default:
                    return null;
            }
        }

        private IAnimal CreateBird(string[] data)
        {
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);
            double wingSize = double.Parse(data[3]);

            switch (type)
            {
                case "Owl":
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    return new Hen(name, weight, wingSize);
                default:
                    return null;
            }
        }

    }
}
