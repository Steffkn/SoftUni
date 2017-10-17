namespace _05.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        static void Main()
        {
            // name, cards[] 
            var scores = new Dictionary<string, List<string>>();
            var powers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var types = new List<string>() { "0", "C", "D", "H", "S" };

            while (true)
            {
                var input = Console.ReadLine();

                if (input.ToUpper().Equals("JOKER"))
                {
                    foreach (var player in scores.Keys)
                    {
                        var distictCards = scores[player]
                            .Distinct()
                            .ToList();

                        int score = 0;
                        foreach (var card in distictCards)
                        {
                            var type = card[card.Length - 1];
                            var power = card.Remove(card.Length - 1);

                            score += powers.IndexOf(power) * types.IndexOf(type.ToString());

                        }

                        Console.WriteLine($"{player}: {score}");
                    }

                    break;
                }

                var data = input.Split(':');
                var name = data[0];
                var cards = data[1]
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (!scores.ContainsKey(name))
                {
                    scores.Add(name, new List<string>());
                }

                scores[name].AddRange(cards);

            }
        }
    }
}