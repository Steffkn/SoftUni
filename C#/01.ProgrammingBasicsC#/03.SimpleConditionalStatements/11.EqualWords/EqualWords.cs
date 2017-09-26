namespace _11.EqualWords
{
    using System;

    public class EqualWords
    {
        static void Main()
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();

            if (word1.Equals(word2, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
