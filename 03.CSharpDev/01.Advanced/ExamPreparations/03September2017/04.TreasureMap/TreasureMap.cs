using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    public class TreasureMap
    {
        public static void Main()
        {
            string pattern = @"![^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?#|#[^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?!";
            var regex = new Regex(pattern);
            var output = new StringBuilder();

            int n = int.Parse(Console.ReadLine().Trim());
            for (int line = 0; line < n; line++)
            {
                string inputLine = Console.ReadLine();

                if (regex.IsMatch(inputLine))
                {
                    var matches = regex.Matches(inputLine);
                    var mostInnerValidIndex = matches.Count / 2;
                    var validMessage = matches[mostInnerValidIndex];

                    if (validMessage.ToString().StartsWith("!"))
                    {
                        string streetName = validMessage.Groups[1].Value;
                        string streetNumber = validMessage.Groups[2].Value;
                        string pass = validMessage.Groups[3].Value;
                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                    else
                    {
                        string streetName = validMessage.Groups[4].Value;
                        string streetNumber = validMessage.Groups[5].Value;
                        string pass = validMessage.Groups[6].Value;
                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}