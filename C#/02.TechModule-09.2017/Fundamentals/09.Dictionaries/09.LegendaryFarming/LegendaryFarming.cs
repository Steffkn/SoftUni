namespace _09.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        static void Main()
        {
            // item, quantity
            var items = new Dictionary<string, long>();
            items.Add("fragments", 0);
            items.Add("shards", 0);
            items.Add("motes", 0);

            while (true)
            {
                var inputs = Console.ReadLine().Split(' ');

                for (int i = 0; i < inputs.Length; i += 2)
                {
                    var quantity = long.Parse(inputs[i]);
                    var item = inputs[i + 1].ToLower();

                    if (!items.ContainsKey(item))
                    {
                        items.Add(item, quantity);
                    }
                    else
                    {
                        items[item] += quantity;
                    }

                    if (items["fragments"] >= 250)
                    {
                        items["fragments"] = items["fragments"] - 250;
                        Console.WriteLine("Valanyr obtained!");
                        Print(items);
                        return;
                    }
                    else if (items["motes"] >= 250)
                    {
                        items["motes"] = items["motes"] - 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        Print(items);
                        return;
                    }
                    else if (items["shards"] >= 250)
                    {
                        items["shards"] = items["shards"] - 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        Print(items);
                        return;
                    }
                }
            }
        }

        static void Print(Dictionary<string, long> items)
        {
            foreach (var commonItem in items
                .Take(3)
                .OrderByDescending(x => x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, v => v.Value))
            {
                Console.WriteLine($"{commonItem.Key}: {commonItem.Value}");
            }

            foreach (var commonItem in items
                .Skip(3)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, v => v.Value))
            {
                Console.WriteLine($"{commonItem.Key}: {commonItem.Value}");
            }
        }
    }
}