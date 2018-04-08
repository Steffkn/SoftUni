namespace P07.InfernoInfinity.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using P07.InfernoInfinity.Interfaces;
    using P07.InfernoInfinity.Models;

    public class WeaponsFactory
    {
        public IWeapon CreateWeapon(string[] info)
        {
            string weaponTypeString = info[0];
            Enum.TryParse(info[1], out Rarity weaponRarity);
            string weaponName = info[2];
            var weaponType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t == Type.GetType(weaponTypeString));
            var weapon = Activator.CreateInstance(weaponType, weaponName, weaponRarity);
            return (IWeapon)weapon;
        }
    }
}
