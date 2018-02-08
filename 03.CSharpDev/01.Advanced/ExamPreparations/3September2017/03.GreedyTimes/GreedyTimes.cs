using System;
using System.Collections.Generic;
using System.Linq;

public class GreedyTimes
{
    static void Main()
    {
        var bagCapacity = long.Parse(Console.ReadLine());
        var goodies = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var bagContent = new Dictionary<string, Dictionary<string, long>>();

        long goldAmount = 0;
        long gemsAmount = 0;
        long cashAmount = 0;
        long currentBagCapacity = 0;

        for (int i = 0; i < goodies.Length; i = i + 2)
        {
            var goodieName = goodies[i];
            long goodieValue = long.Parse(goodies[i + 1]);

            if ((currentBagCapacity + goodieValue) <= bagCapacity)
            {
                if (goodieName.Equals("Gold", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!bagContent.ContainsKey("Gold"))
                    {
                        var dictionary = new Dictionary<string, long>();
                        dictionary.Add("Gold", 0);
                        bagContent.Add("Gold", dictionary);
                    }

                    bagContent["Gold"]["Gold"] += goodieValue;
                    goldAmount += goodieValue;
                    currentBagCapacity += goodieValue;
                }
                else if (goodieName.EndsWith("gem", StringComparison.CurrentCultureIgnoreCase) && goodieName.Length >= 4)
                {
                    if (goldAmount >= (gemsAmount + goodieValue))
                    {
                        if (!bagContent.ContainsKey("Gem"))
                        {
                            var dictionary = new Dictionary<string, long>();
                            dictionary.Add(goodieName, 0);
                            bagContent.Add("Gem", dictionary);
                        }

                        if (!bagContent["Gem"].ContainsKey(goodieName))
                        {
                            bagContent["Gem"].Add(goodieName, 0);
                        }

                        bagContent["Gem"][goodieName] += goodieValue;
                        gemsAmount += goodieValue;
                        currentBagCapacity += goodieValue;
                    }
                }
                else if (goodieName.Length == 3)
                {
                    if (gemsAmount >= (cashAmount + goodieValue))
                    {
                        if (!bagContent.ContainsKey("Cash"))
                        {
                            var dictionary = new Dictionary<string, long>();
                            dictionary.Add(goodieName, 0);
                            bagContent.Add("Cash", dictionary);
                        }

                        if (!bagContent["Cash"].ContainsKey(goodieName))
                        {
                            bagContent["Cash"].Add(goodieName, 0);
                        }

                        bagContent["Cash"][goodieName] += goodieValue;
                        cashAmount += goodieValue;
                        currentBagCapacity += goodieValue;
                    }
                }
            }
        }

        foreach (var goodie in bagContent.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine("<{0}> ${1}", goodie.Key, goodie.Value.Values.Sum());
            foreach (var item in goodie.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
            {
                Console.WriteLine("##{0} - {1}", item.Key, item.Value);
            }
        }
    }
}