namespace P07.InfernoInfinity.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using P07.InfernoInfinity.Interfaces;
    using P07.InfernoInfinity.Models;

    public class GemsFactory
    {
        public IGem CreateWeapon(string[] info)
        {
            string gemName = info[0];
            Enum.TryParse(info[1], out Clarity gemClarity);
            var gemType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t == Type.GetType(gemName));
            var newGem = Activator.CreateInstance(gemType, gemClarity);
            return (IGem)newGem;
        }
    }
}
