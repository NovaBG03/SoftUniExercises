using InfernoInfinity.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace InfernoInfinity.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public WeaponFactory()
        {

        }

        public IWeapon CreateWeapon(string typeAsString, string name, IRarity raritiy)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name == typeAsString)
                .First();

            var instance = (IWeapon)Activator.CreateInstance(type, new object[] { name, raritiy });

            return instance;
        }
    }
}
