namespace _09.IndexOfLetters
{
    using System;

    public class IndexOfLetters
    {
        static void Main()
        {
            char[] letters = new char['z' - 'a' + 1];
            for (int i = 0, j = 'a'; i < letters.Length; i++, j++)
            {
                letters[i] = (char)j;
            }

            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    if (word[i] == letters[j])
                    {
                        Console.WriteLine($"{word[i]} -> {j}");
                        break;
                    }
                }
            }
        }
    }
}
