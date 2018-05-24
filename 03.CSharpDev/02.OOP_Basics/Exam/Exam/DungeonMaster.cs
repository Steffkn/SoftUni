namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Factories;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int lastSurvivorRounds = 0;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var character = this.characterFactory.CreateCharacter(args[0], args[1], args[2]);
            this.characters.Add(character);
            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            var item = this.itemFactory.CreateItem(itemName);
            this.items.Push(item);

            return $"{item.Name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var charName = args[0];
            var character = this.characters.FirstOrDefault(c => c.Name.Equals(charName));

            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.items.Pop();
            character.ReceiveItem(item);

            return $"{charName} picked up {item.Name}!";
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];
            var character = this.characters.FirstOrDefault(c => c.Name.Equals(charName));

            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            var giverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(giverName));

            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(receiverName));
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giverCharacter.Bag.GetItem(itemName);
            giverCharacter.UseItemOn(item, receiverCharacter);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];
            var giverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(giverName));

            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(receiverName));
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var item = giverCharacter.Bag.GetItem(itemName);
            giverCharacter.GiveCharacterItem(item, receiverCharacter);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var builder = new StringBuilder();
            foreach (Character ch in this.characters.OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                builder.AppendLine(string.Format("{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}", ch.Name, ch.Health, ch.BaseHealth, ch.Armor, ch.BaseArmor, ch.IsAlive ? "Alive" : "Dead"));
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            var attacker = this.characters.FirstOrDefault(c => c.Name.Equals(attackerName));

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            var receiverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(receiverName));
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var builder = new StringBuilder();

            (attacker as Warrior).Attack(receiverCharacter);

            builder.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            builder.AppendLine($"{receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!");

            if (!receiverCharacter.IsAlive)
            {
                builder.AppendLine($"{receiverCharacter.Name} is dead!");
            }

            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healReceiverName = args[1];
            var healer = this.characters.FirstOrDefault(c => c.Name.Equals(healerName));

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            var receiverCharacter = this.characters.FirstOrDefault(c => c.Name.Equals(healReceiverName));
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {healReceiverName} not found!");
            }

            if (!(healer is IHealable))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            (healer as Cleric).Heal(receiverCharacter);

            string result = $"{healer.Name} heals {receiverCharacter.Name} for {healer.AbilityPoints}! {receiverCharacter.Name} has {receiverCharacter.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            var builder = new StringBuilder();
            var chars = this.characters.Where(x => x.IsAlive);
            foreach (var ch in chars)
            {
                var healthBeforeRest = ch.Health;
                ch.Rest();
                builder.AppendLine($"{ch.Name} rests ({healthBeforeRest} => {ch.Health})");
            }

            if (chars.Count() < 2)
            {
                this.lastSurvivorRounds++;
            }

            return builder.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorRounds > 1;
        }
    }
}
