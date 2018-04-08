namespace P07.InfernoInfinity.Interfaces
{
    using System.Collections.Generic;
    using P07.InfernoInfinity.Models.Gems;
    using P07.InfernoInfinity.Models;

    public interface IWeapon
    {
        IReadOnlyCollection<Gem> Gems { get; }

        int MaxDamage { get; }

        int MinDamage { get; }

        string Name { get; }

        Rarity Rarity { get; }

        void AddGem(int index, Gem newGem);

        void RemoveGem(int index);
    }
}