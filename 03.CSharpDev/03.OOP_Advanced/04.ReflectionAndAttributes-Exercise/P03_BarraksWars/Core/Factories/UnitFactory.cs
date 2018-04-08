using System.Linq;
using System.Reflection;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            // var type = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
            var types = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IUnit))
                        && t.Name.Equals(unitType));

            var result = Activator.CreateInstance(types.FirstOrDefault());
            return (IUnit)result;
        }
    }
}
