namespace _04.Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var sets = new Dictionary<string, Dictionary<string, long>>();
            var chace = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {

                var input = Console.ReadLine();

                if (input.Equals("thetinggoesskrra"))
                {
                    var max = sets.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x, y => y);

                    long sum = 0;
                    foreach (var item in sets.OrderByDescending(x => x.Value.Values.Sum()))
                    {
                        Console.Write($"Data Set: {item.Key}, ");
                        foreach (var ch in item.Value)
                        {
                            sum += ch.Value;
                        }

                        Console.WriteLine($"Total Size: {sum}");
                        foreach (var ch in item.Value)
                        {
                            Console.WriteLine($"$.{ch.Key}");
                        }
                        break;
                    }

                    break;
                }

                var tockens = input.Split(new char[] { ' ', '-', '>', '|', }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (tockens.Length == 1)
                {
                    if (!sets.ContainsKey(tockens[0]))
                    {
                        sets.Add(tockens[0], new Dictionary<string, long>());
                        if (chace.ContainsKey(tockens[0]))
                        {
                            sets[tockens[0]] = chace[tockens[0]];
                        }
                    }
                }
                else
                {
                    if (sets.ContainsKey(tockens[2]))
                    {
                        if (!sets[tockens[2]].ContainsKey(tockens[0]))
                        {
                            sets[tockens[2]].Add(tockens[0], long.Parse(tockens[1]));
                        }
                        else
                        {
                            sets[tockens[2]][tockens[0]] = long.Parse(tockens[1]);
                        }
                    }
                    else
                    {
                        if (!chace.ContainsKey(tockens[2]))
                        {
                            chace.Add(tockens[2], new Dictionary<string, long>());
                        }

                        if (!chace[tockens[2]].ContainsKey(tockens[0]))
                        {
                            chace[tockens[2]].Add(tockens[0], long.Parse(tockens[1]));
                        }
                        else
                        {
                            chace[tockens[2]][tockens[0]] = long.Parse(tockens[1]);
                        }
                    }
                }
            }
        }
    }
}
