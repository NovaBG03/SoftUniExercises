using InfernoInfinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace InfernoInfinity.Factories
{
    public class ClarityFactory : IClarityFactory
    {
        public ClarityFactory()
        {

        }
        public IClarity CreateClarity(string typeAsString)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name == typeAsString)
                .First();

            var instance = (IClarity)Activator.CreateInstance(type);

            return instance;
        }
    }
}
