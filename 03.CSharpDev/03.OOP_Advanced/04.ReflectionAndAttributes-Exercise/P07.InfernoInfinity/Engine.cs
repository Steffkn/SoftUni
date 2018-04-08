using P07.InfernoInfinity.Factories;

namespace P07.InfernoInfinity
{
    using System;

    public class Engine
    {
        public Engine(WeaponsFactory weaponFactory, GemsFactory gemFactory)
        {
            this.WeaponFactory = weaponFactory;
            this.GemFactory = gemFactory;
        }

        public WeaponsFactory WeaponFactory { get; }

        public GemsFactory GemFactory { get; }

        public void Run()
        {
            while (true)
            {

            }
        }
    }
}
