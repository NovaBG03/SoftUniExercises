using InfernoInfinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public GemFactory()
        {

        }

        public IGem CreateGem(string typeAsString, IClarity clarity)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name == typeAsString)
                .First();

            var instance = (IGem)Activator.CreateInstance(type, new object[] { clarity });

            return instance;
        }
    }
}
