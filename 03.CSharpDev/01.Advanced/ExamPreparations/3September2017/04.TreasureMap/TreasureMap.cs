using System;
using System.Text.RegularExpressions;

public class TreasureMap
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string pattern = @"[#][^!#]*?([a-zA-Z]{4})[^!#]+([0-9]{3}-[0-9]{4,6}).*?[!]|[!][^!#]*?([a-zA-Z]{4})[^!#]+([0-9]{3}-[0-9]{4,6}).*?[#]";

        for (int i = 0; i < n; i++)
        {
            var reg = new Regex(pattern);
            var matches = reg.Matches(Console.ReadLine());

            string streetName = string.Empty;
            string strNumber = string.Empty;
            string password = string.Empty;
            string[] numbeers;
            int index = 0;
            if (matches.Count < 5)
            {
                index = matches.Count / 2;
            }
            else
            {
                index = (matches.Count / 2) + 1;
            }
            //int index = matches.Count / 2;

            /* foreach (Match item in matches)
             {
                 Console.WriteLine("0 - {0}",item.Groups[0]);
                 Console.WriteLine("1 - {0}",item.Groups[1]);
                 Console.WriteLine("2 - {0}",item.Groups[2]);
                 Console.WriteLine("3 - {0}",item.Groups[3]);
             }*/

            if (matches[index].Groups[0].ToString().StartsWith("!"))
            {
                streetName = matches[index].Groups[3].ToString();
                numbeers = matches[index].Groups[4].ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                streetName = matches[index].Groups[1].ToString();
                numbeers = matches[index].Groups[2].ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            strNumber = numbeers[0];
            password = numbeers[1];

            Console.WriteLine("Go to str. {0} {1}. Secret pass: {2}.", streetName, strNumber, password);
        }
    }
}
