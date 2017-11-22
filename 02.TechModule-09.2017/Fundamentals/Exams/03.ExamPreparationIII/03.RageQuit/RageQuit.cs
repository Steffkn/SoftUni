using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.RageQuit
{
    class RageQuit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string patter = @"([^0-9]+)([0-9]+)";
            Regex reg = new Regex(patter);
            StringBuilder sb = new StringBuilder();
            var strings = reg.Matches(input).Cast<Match>().Select(x => x.Groups[1]).ToList();
            var counts = reg.Matches(input).Cast<Match>().Select(x => x.Groups[2]).ToList();

            for (int i = 0; i < strings.Count; i++)
            {
                int count = int.Parse(counts[i].ToString());
                string str = strings[i].ToString().ToUpper();
                for (int c = 0; c < count; c++)
                {
                    sb.Append(str);
                }
            }

            string result = sb.ToString();
            int uniqueChars = result.ToCharArray().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueChars}");
            Console.WriteLine(result.ToString());
        }
    }
}
