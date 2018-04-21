
namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100.0, 50.0, 40, new Satchel(), faction)
        { }

        public void Attack(Character character)
        {
            this.ChechIfIsAlive();
            character.ChechIfIsAlive();

            if (this.Equals(character))
            {
                throw new InvalidOperationException(OutputMessages.InvalidTarget);
            }

            if (this.Faction.Equals(character.Faction))
            {
                throw new ArgumentException(string.Format(OutputMessages.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
