namespace _11.DragonArmy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class DragonArmy
    {
        private const int DEFAULT_DAMAGE = 45;
        private const int DEFAULT_HEALTH = 250;
        private const int DEFAULT_ARMOR = 10;

        static void Main()
        {
            // type, {singer, concerRevenue}
            Dictionary<string, SortedDictionary<string, Stats>> types = new Dictionary<string, SortedDictionary<string, Stats>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string type = input[0];
                string name = input[1];

                // stat = input or defaul (if input is == null)
                int damage = int.TryParse(input[2], out damage) == false ? DEFAULT_DAMAGE : damage;
                int health = int.TryParse(input[3], out health) == false ? DEFAULT_HEALTH : health;
                int armor = int.TryParse(input[4], out armor) == false ? DEFAULT_ARMOR : armor;

                if (!types.ContainsKey(type))
                {
                    types.Add(type, new SortedDictionary<string, Stats>());
                }

                if (!types[type].ContainsKey(name))
                {
                    types[type].Add(name, new Stats(damage, health, armor));
                }
                else
                {
                    types[type][name] = new Stats(damage, health, armor);
                }
            }

            Print(types);
        }

        private static void Print(Dictionary<string, SortedDictionary<string, Stats>> types)
        {
            foreach (var type in types)
            {
                double avgDamage = type.Value.Values.Average(s => s.Damage);
                double avgHealth = type.Value.Values.Average(s => s.Health);
                double avgArmor = type.Value.Values.Average(s => s.Armor);

                Console.WriteLine($"{type.Key}::({avgDamage:F2}/{avgHealth:F2}/{avgArmor:F2})");

                foreach (var dragon in types[type.Key])
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }

    public class Stats
    {
        private int damage;
        private int health;
        private int armor;

        public Stats(int damage = 45, int health = 250, int armor = 10)
        {
            this.Health = health;
            this.Damage = damage;
            this.Armor = armor;
        }

        public int Damage { get => damage; set => damage = value; }
        public int Health { get => health; set => health = value; }
        public int Armor { get => armor; set => armor = value; }
    }
}
