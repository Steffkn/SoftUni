﻿namespace _02.NumbersEndingIn7
{
    using System;

    public class NumbersEndingIn7
    {
        static void Main()
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}