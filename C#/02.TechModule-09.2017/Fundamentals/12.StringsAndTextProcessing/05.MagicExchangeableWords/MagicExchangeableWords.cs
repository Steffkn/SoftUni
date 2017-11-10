namespace _05.MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MagicExchangeableWords
    {
        static void Main()
        {
            var inputs = Console.ReadLine().Split(' ');

            string longerWord = string.Empty;
            string shorterWord = string.Empty;

            if (inputs[0].Length > inputs[1].Length)
            {
                longerWord = inputs[0];
                shorterWord = inputs[1];
            }
            else
            {
                longerWord = inputs[1];
                shorterWord = inputs[0];
            }

            bool result = AreExchangable(longerWord, shorterWord);

            Console.WriteLine(result.ToString().ToLower());
        }

        private static bool AreExchangable(string longerWord, string shorterWord)
        {
            var book = new Dictionary<char, char>();

            for (int i = 0; i < shorterWord.Length; i++)
            {
                if (!book.ContainsKey(shorterWord[i]) && !book.ContainsValue(longerWord[i]))
                {
                    book.Add(shorterWord[i], longerWord[i]);
                }
                else if (book.ContainsKey(shorterWord[i]))
                {
                    if (book[shorterWord[i]] != longerWord[i])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                if (!book.ContainsValue(longerWord[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}