namespace _13.VowelOrDigit
{
    using System;

    public class VowelOrDigit
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int digit = 0;
            if (int.TryParse(input, out digit))
            {
                Console.WriteLine("digit");
            }
            else
            {
                switch (input[0])
                {
                    case 'a':
                    case 'o':
                    case 'u':
                    case 'e':
                    case 'i':
                        Console.WriteLine("vowel");
                        break;
                    default:
                        Console.WriteLine("other");
                        break;
                }
            }
        }
    }
}
