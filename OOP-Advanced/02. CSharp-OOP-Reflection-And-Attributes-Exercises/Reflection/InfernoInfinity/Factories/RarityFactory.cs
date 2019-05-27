using InfernoInfinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace InfernoInfinity.Factories
{
    public class RarityFactory : IRarityFactory
    {
        public RarityFactory()
        {

        }

        public IRarity CreateRarity(string rarity)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name == rarity)
                .First();

            var instance = (IRarity)Activator.CreateInstance(type);

            return instance;
        }
    }
}
