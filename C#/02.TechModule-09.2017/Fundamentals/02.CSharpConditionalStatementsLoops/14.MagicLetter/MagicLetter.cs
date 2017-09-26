namespace _14.MagicLetter
{
    using System;

    public class MagicLetter
    {
        static void Main()
        {
            char a = Console.ReadLine()[0];
            char z = Console.ReadLine()[0];
            char magicLetter = Console.ReadLine()[0];

            for (int i = a; i <= z; i++)
            {
                if (i == magicLetter)
                {
                    continue;
                }

                for (int j = a; j <= z; j++)
                {
                    if (j == magicLetter)
                    {
                        continue;
                    }

                    for (int k = a; k <= z; k++)
                    {
                        if (k == magicLetter)
                        {
                            continue;
                        }

                        Console.Write($"{(char)i}{(char)j}{(char)k} ");
                    }
                }
            }
        }
    }
}