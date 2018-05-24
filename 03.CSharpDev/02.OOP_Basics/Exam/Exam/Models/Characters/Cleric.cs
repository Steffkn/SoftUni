namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            character.ChechIfIsAlive();
            this.ChechIfIsAlive();

            if (!this.Faction.Equals(character.Faction))
            {
                throw new InvalidOperationException(OutputMessages.InvalidHealingTarget);
            }

            character.AddHealth(this.AbilityPoints);
        }
    }
}
