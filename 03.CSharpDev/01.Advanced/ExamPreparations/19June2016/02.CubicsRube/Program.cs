using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CubicsRube
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long sum = 0;
            long count = n * n * n;
            string input = string.Empty;
            
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var tockens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (tockens[0] > -1 && tockens[0] < n &&
                    tockens[1] > -1 && tockens[1] < n &&
                    tockens[2] > -1 && tockens[2] < n)
                {
                    if (tockens[3] != 0)
                    {
                        count--;
                    }

                    sum += tockens[3];
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(count);
        }
    }
}
