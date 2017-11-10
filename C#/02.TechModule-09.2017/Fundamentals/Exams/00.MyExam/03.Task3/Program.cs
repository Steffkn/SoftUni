namespace _03.Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string plaseholder = Console.ReadLine();

            string pattern = @"([a-zA-Z]+)(.+)(\1)";
            Regex reg = new Regex(pattern);
            Regex regValues = new Regex(@"{([.+])}");

            var placeholders = plaseholder.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var matches = reg.Matches(text).Cast<Match>().Select(x => x.Groups[2]).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            if (matches.Count < placeholders.Count)
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    int index = sb.ToString().IndexOf(matches[i].Value);
                    sb.Replace(matches[i].Value, placeholders[i], index, matches[i].Length);
                }
            }
            else
            {
                for (int i = 0; i < placeholders.Count; i++)
                {
                    int index = sb.ToString().IndexOf(matches[i].Value);
                    sb.Replace(matches[i].Value, placeholders[i], index, matches[i].Length);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
