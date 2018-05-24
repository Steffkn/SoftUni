namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Items;
    using System;

    public abstract class Character
    {
        private string _name;
        private double _health;
        private double _armor;
        private double restHealMultiplier;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = 0.2;
            this.IsAlive = true;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.InvalidName);
                }

                this._name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => _health;
            private set
            {
                if (value >= this.BaseHealth)
                {
                    this._health = this.BaseHealth;
                }
                else if (value <= 0)
                {
                    this._health = 0;
                }
                else
                {
                    _health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => _armor;
            private set
            {
                if (value >= this.BaseArmor)
                {
                    this._armor = this.BaseArmor;
                }
                else if (value <= 0)
                {
                    this._armor = 0;
                }
                else
                {
                    _armor = value;
                }
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; protected set; }

        public bool IsAlive { get; protected set; }

        public virtual double RestHealMultiplier
        {
            get { return this.restHealMultiplier; }
            protected set { this.restHealMultiplier = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            this.ChechIfIsAlive();

            if (this.Armor - hitPoints < 0)
            {
                hitPoints -= this.Armor;
                this.Armor = 0.0;
                this.Health -= hitPoints;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void TakeTrueDamage(double hitPoints)
        {
            this.ChechIfIsAlive();

            this.Health -= hitPoints;

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void AddHealth(double amount)
        {
            this.ChechIfIsAlive();
            this.Health += amount;
        }

        public void RestoreArmor()
        {
            this.ChechIfIsAlive();
            this.Armor = this.BaseArmor;
        }

        public void Rest()
        {
            this.ChechIfIsAlive();
            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.ChechIfIsAlive();

            var foundItem = this.Bag.GetItem(item.Name);
            foundItem.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.ChechIfIsAlive();
            character.ChechIfIsAlive();

            var foundItem = this.Bag.GetItem(item.Name);
            foundItem.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.ChechIfIsAlive();
            character.ChechIfIsAlive();

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.ChechIfIsAlive();

            this.Bag.AddItem(item);
        }

        public void ChechIfIsAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(OutputMessages.DeadCharacter);
            }
        }
    }
}