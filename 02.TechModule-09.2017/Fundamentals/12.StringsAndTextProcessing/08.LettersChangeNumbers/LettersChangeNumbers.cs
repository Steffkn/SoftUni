namespace _08.LettersChangeNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LettersChangeNumbers
    {
        static void Main()
        {
            var inputs = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double sum = 0;

            Regex things = new Regex(@"([a-zA-Z])([0-9]+)([a-zA-Z])");

            foreach (var input in inputs)
            {
                var something = things.Match(input).Groups;
                char firstLetter = something[1].Value[0];
                double number = double.Parse(something[2].Value);
                char lastLetter = something[3].Value[0];

                if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    number *= ((int)firstLetter - (int)'a' + 1);
                }
                else if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    number = number / ((int)firstLetter - (int)'A' + 1);
                }


                if (lastLetter >= 'a' && lastLetter <= 'z')
                {
                    number = number + ((int)lastLetter - (int)'a' + 1);
                }
                else if (lastLetter >= 'A' && lastLetter <= 'Z')
                {
                    number = number - ((int)lastLetter - (int)'A' + 1);
                }

                sum = sum + number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}