namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetType($"_03BarracksFactory.Models.Units.{unitType}");

            var instance = (IUnit)type.GetConstructor(new Type[0]).Invoke(new Type[0]);

            return instance;
        }
    }
}
