namespace _01.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        static void Main()
        {
            var input = Console.ReadLine();

            Regex reg = new Regex(@"(\s[a-zA-Z0-9]+[\.\-_]{0,1}[a-zA-Z0-9]+)@([a-zA-Z\-]+[\.\-]{1}[a-zA-Z]+[\.\-]{0,1}[a-zA-Z]+)");

            var nq = reg.Matches(input);

            foreach (Match item in nq)
            {
                Console.WriteLine(item.Value.Trim());
            }
        }
    }
}