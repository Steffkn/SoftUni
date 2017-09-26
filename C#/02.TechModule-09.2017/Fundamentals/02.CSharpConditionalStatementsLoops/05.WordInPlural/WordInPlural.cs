namespace _05.WordInPlural
{
    using System;

    public class WordInPlural
    {
        static void Main()
        {
            string noun = Console.ReadLine();

            if (noun.EndsWith("y"))
            {
                noun = string.Format("{0}ies", noun.Remove(noun.Length - 1));
            }
            else if (noun.EndsWith("o") || noun.EndsWith("s") || noun.EndsWith("x") || noun.EndsWith("z") || noun.EndsWith("sh") || noun.EndsWith("ch"))
            {
                noun = noun + "es";
            }
            else
            {
                noun = noun + "s";
            }

            Console.WriteLine(noun);
        }
    }
}