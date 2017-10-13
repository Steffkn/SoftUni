namespace _03.EnglishNameOfLastDigit
{
    using System;

    public class EnglishNameOfLastDigit
    {
        static void Main()
        {
            // there was a big with the submitions of this task (it should use integers but its given floating point numbers..) 
            // this works in both ways
            string snumber = Console.ReadLine();

            string[] numberParts = snumber.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            string holePart = numberParts[0];
            string lastDigit = holePart[holePart.Length - 1] + string.Empty;

            int number = int.Parse(lastDigit);

            string digitName = ConvertToName(number);

            Console.WriteLine(digitName);
        }

        private static string ConvertToName(int lastDigit)
        {
            switch (lastDigit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "tree";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return string.Empty;
            }
        }
    }
}
