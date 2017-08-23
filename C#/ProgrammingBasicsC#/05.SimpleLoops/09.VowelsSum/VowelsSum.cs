﻿namespace _09.VowelsSum
{
    using System;

    public class VowelsSum
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int score = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                        score += 1;
                        break;
                    case 'e':
                        score += 2;
                        break;
                    case 'i':
                        score += 3;
                        break;
                    case 'o':
                        score += 4;
                        break;
                    case 'u':
                        score += 5;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(score);
        }
    }
}
