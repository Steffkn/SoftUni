using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task1
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            var pattern = @"((\{[^\]\[]*?[0-9]{3}[^\]\[]*?\})|(\[[^\}\{]*?[0-9]{3}[^\}\{]*?\]))";
            var reg = new Regex(pattern);
            var digitsReg = new Regex(@"([\d]+)");
            var matches = reg.Matches(sb.ToString());
            var digs = new List<int>();

            foreach (Match item in matches)
            {
                var block = item.Groups[0].Value;
                var digitsMatch = digitsReg.Matches(block).Cast<Match>().First();
                var digits = digitsMatch.Groups[0].Value;

                if (digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int i = 0; i < digits.Length; i += 3)
                {
                    digs.Add(int.Parse(digits.Substring(i, 3)) - block.Length);
                }
            }

            foreach (var number in digs)
            {
                Console.Write((char)number);
            }
            Console.WriteLine();
        }
    }
}
