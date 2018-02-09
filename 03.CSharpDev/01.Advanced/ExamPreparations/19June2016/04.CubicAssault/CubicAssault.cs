namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicAssault
    {
        static void Main()
        {
            string input = string.Empty;
            var dict = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "Count em all")
            {
                var tockens = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                string name = tockens[0].Trim();
                string type = tockens[1].Trim().ToLower();
                long count = long.Parse(tockens[2]);

                if (!dict.ContainsKey(name))
                {
                    var meteors = new Dictionary<string, long>
                    {
                        { "Black", 0 },
                        { "Red", 0 },
                        { "Green", 0 }
                    };

                    dict.Add(name, meteors);
                }

                if (type == "green")
                {
                    dict[name]["Green"] += count;
                }
                else if (type == "red")
                {
                    dict[name]["Red"] += count;
                }
                else if (type == "black")
                {
                    dict[name]["Black"] += count;
                }

                if (dict[name]["Green"] >= 1000000)
                {
                    dict[name]["Red"] += (dict[name]["Green"] / 1000000);
                    dict[name]["Green"] = (dict[name]["Green"] % 1000000);
                }

                if (dict[name]["Red"] >= 1000000)
                {
                    dict[name]["Black"] += (dict[name]["Red"] / 1000000);
                    dict[name]["Red"] = (dict[name]["Red"] % 1000000);
                }
            }


            foreach (var location in dict
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(location.Key);

                foreach (var meteorType in location.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }
    }
}
