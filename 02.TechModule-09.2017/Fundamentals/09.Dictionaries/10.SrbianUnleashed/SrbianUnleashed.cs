namespace _10.SrbianUnleashed
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class SrbianUnleashed
    {
        static void Main()
        {
            // venue, {singer, concerRevenue}
            var venues = new Dictionary<string, Dictionary<string, long>>();
            Regex regexValidator = new Regex(@"^([A-z]+[A-z ]*[A-z]*)( @){1}([A-z]+[A-z ]*[A-z ]* )([\d]+ [\d]+)$");
            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower().Equals("end"))
                {
                    Print(venues);
                    break;
                }

                if (regexValidator.Match(input).Success)
                {
                    var dataCollection = regexValidator.Matches(input)[0].Groups;

                    var venue = dataCollection[3]
                        .ToString()
                        .Trim();
                    var singer = dataCollection[1]
                        .ToString()
                        .Trim();

                    var tigetPrice = dataCollection[4]
                        .ToString()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();

                    if (!venues.ContainsKey(venue))
                    {
                        venues.Add(venue, new Dictionary<string, long>());
                    }

                    if (!venues[venue].ContainsKey(singer))
                    {
                        venues[venue].Add(singer, tigetPrice[0] * tigetPrice[1]);
                    }
                    else
                    {
                        venues[venue][singer] += tigetPrice[0] * tigetPrice[1];
                    }
                }
            }
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> venues)
        {
            foreach (var venue in venues.Keys)
            {
                Console.WriteLine(venue);

                foreach (var singer in venues[venue].OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
