namespace _07.PopulationCounter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PopulationCounter
    {
        static void Main()
        {
            // country, {cities, count}
            var countries = new Dictionary<string, Dictionary<string, long>>();
            
            while (true)
            {
                var input = Console.ReadLine().Split('|');
                
                if (input[0] == "report")
                {
                    foreach (var countryy in countries
                        .OrderByDescending(c => c.Value.Values.Sum())
                        .ToDictionary(x => x.Key, y => y.Value)
                        .Keys)
                    {
                        long sum = countries[countryy].Select(x => x.Value).Sum();

                        Console.WriteLine($"{countryy} (total population: {sum})");

                        string result = string.Empty;

                        foreach (var cityy in countries[countryy]
                            .OrderByDescending(x => x.Value)
                            .ToDictionary(x => x.Key, y => y.Value)
                            .Keys)
                        {
                            result += $"=>{cityy}: {countries[countryy][cityy]}\r\n";
                        }

                        Console.Write(result);
                    }

                    return;
                }

                var city = input[0];
                var country = input[1];
                var population = int.Parse(input[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                }

                if (!countries[country].ContainsKey(city))
                {
                    countries[country].Add(city, 0);
                }

                countries[country][city] += population;
            }
        }
    }
}