using System;
using System.Text;
using System.Text.RegularExpressions;

public class Regeh
{
    public static void Main()
    {
        var pattern = @"\[[^\r\n\t\f\v \[]+?[<]([0-9]+)REGEH([0-9]+)[>][^\r\n\t\f\v \]]+?\]";
        Regex reg = new Regex(pattern);
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        var matches = reg.Matches(input);
        int index = 0;

        foreach (Match match in matches)
        {
            index += int.Parse(match.Groups[1].ToString());

            if (index > input.Length - 1)
            {
                index = index % (input.Length - 1);
            }

            sb.Append(input[index]);

            index += int.Parse(match.Groups[2].ToString());

            if (index > input.Length - 1)
            {
                index = index % (input.Length - 1);
            }

            sb.Append(input[index]);
        }

        Console.WriteLine(sb.ToString());
    }
}
