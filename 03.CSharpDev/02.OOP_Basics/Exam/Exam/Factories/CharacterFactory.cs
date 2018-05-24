namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Models;
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionString, string charType, string charName)
        {
            var validFaction = Enum.TryParse(factionString, out Faction faction);
            if (!validFaction)
            {
                throw new ArgumentException(string.Format("Invalid faction \"{0}\"!", factionString));
            }

            switch (charType)
            {
                case "Warrior":
                    return new Warrior(charName, faction);
                case "Cleric":
                    return new Cleric(charName, faction);
                default:
                    throw new ArgumentException(string.Format("Invalid character type \"{0}\"!", charType));
            }
        }
    }
}
