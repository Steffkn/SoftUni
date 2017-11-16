namespace _02.ExtractSentencesByKeyword
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractSentencesByKeyword
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var text = Console.ReadLine();

            string wordPattern = "[" + String.Join("][", input.ToCharArray()) + "]";
            string patter = @"([^.!?]*[\w\s]*\W" + wordPattern + @"\W.*?)[\.\!\?]";

            Regex reg = new Regex(patter);

            foreach (Match item in reg.Matches(text))
            {
                Console.WriteLine(item.Groups[1].Value.Trim());
            }
        }
    }
}