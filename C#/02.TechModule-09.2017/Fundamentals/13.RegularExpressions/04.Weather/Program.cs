namespace _04.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Weather
    {
        static void Main()
        {
            string patter = @"([A-Z]{2})([-+]?[0-9]*\.?[0-9]+)([a-zA-Z]+)\|";
            var cities = new Dictionary<string, CityWeather>();
            Regex reg = new Regex(patter);

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine.Equals("end"))
                {
                    break;
                }

                if (reg.IsMatch(inputLine))
                {
                    var match = reg.Match(inputLine);

                    string city = match.Groups[1].Value;
                    string avgTemp = match.Groups[2].Value;
                    string weather = match.Groups[3].Value;

                    if (!cities.ContainsKey(city))
                    {
                        cities.Add(city, new CityWeather { AvgTemp = float.Parse(avgTemp), CurrentWeather = weather });
                    }
                    else
                    {
                        cities[city] = new CityWeather { AvgTemp = float.Parse(avgTemp), CurrentWeather = weather };
                    }
                }
            }

            foreach (var city in cities.OrderBy(x=>x.Value.AvgTemp))
            {
                Console.WriteLine($"{city.Key} => {city.Value.AvgTemp} => {city.Value.CurrentWeather}");
            }
        }

        struct CityWeather
        {
            public float AvgTemp { get; set; }
            public string CurrentWeather { get; set; }
        }
    }
}