namespace P07.InfernoInfinity.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using P07.InfernoInfinity.Interfaces;
    using P07.InfernoInfinity.Models.Gems;

    public abstract class Weapon : IHaveStats, IWeapon
    {
        private Gem[] _gems;
        private int _minDamage;
        private int _maxDamage;

        protected Weapon(string name, Rarity rarity, int minDamage, int maxDamage, int numberOfsockets)
        {
            this.Name = name;
            this.Rarity = rarity;
            this._minDamage = minDamage;
            this._maxDamage = maxDamage;
            this._gems = new Gem[numberOfsockets];
        }

        public IReadOnlyCollection<Gem> Gems => Array.AsReadOnly(this._gems);

        public string Name { get; }

        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public int MinDamage => this._minDamage + (int)this.Rarity + 2 * this.Strength + this.Agility;

        public int MaxDamage => this._maxDamage + (int)this.Rarity + 3 * this.Strength + 4 * this.Agility;

        public Rarity Rarity { get; }

        public void AddGem(int index, Gem newGem)
        {
            if (IsInRange(index))
            {
                this._gems[index] = newGem;
                this.CalculateStats();
            }
        }

        private void CalculateStats()
        {
            this.Strength = 0;
            this.Agility = 0;
            this.Vitality = 0;
            foreach (var gem in Gems)
            {
                this.Strength += gem.Strength;
                this.Agility += gem.Strength;
                this.Vitality += gem.Strength;
            }
        }

        public void RemoveGem(int index)
        {
            if (IsInRange(index))
            {
                this._gems[index] = default(Gem);
                this.CalculateStats();
            }
        }

        private bool IsInRange(int index)
        {
            return index > -1 && index < this.Gems.Count;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage}, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
