
namespace _09.ReverseCharacters
{
    using System;

    public class ReverseCharacters
    {
        static void Main()
        {
            char[] letters = new char[3];

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = Console.ReadLine()[0];
            }

            for (int i = letters.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(letters[i]);
            }
        }
    }
}
