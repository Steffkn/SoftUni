// my task was to fix the bugs so that it gives correct answer, this code is not mine

namespace _15.Substring
{
    using System;

    public class Substring
    {
        public static void Main()
        {
            const char Search = 'p';
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            bool hasMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(Search))
                {
                    hasMatch = true;
                    string matchedString = string.Empty;

                    if (i + count < text.Length)
                    {
                        matchedString = text.Substring(i, count + 1);
                    }
                    else
                    {
                        matchedString = text.Substring(i);
                    }

                    Console.WriteLine(matchedString);
                    i += count;
                }
            }

            if (!hasMatch)
            {
                Console.WriteLine("no");
            }
        }
    }
}