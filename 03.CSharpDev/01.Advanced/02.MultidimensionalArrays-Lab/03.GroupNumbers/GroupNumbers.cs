using System.Collections.Generic;
using System.Linq;

namespace _03.GroupNumbers
{
    using System;

    public class GroupNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] numbersJagged = new int[3][];

            var dev0 = new List<int>();
            var dev1 = new List<int>();
            var dev2 = new List<int>();

            foreach (int number in numbers)
            {
                if (Math.Abs(number) % 3 == 0)
                {
                    dev0.Add(number);
                }
                else if (Math.Abs(number) % 3 == 1)
                {
                    dev1.Add(number);
                }
                else
                {
                    dev2.Add(number);
                }
            }

            numbersJagged[0] = dev0.ToArray();
            numbersJagged[1] = dev1.ToArray();
            numbersJagged[2] = dev2.ToArray();

            for (int i = 0; i < numbersJagged.GetLongLength(0); i++)
            {
                Console.WriteLine(String.Join(" ", numbersJagged[i]));
            }
        }
    }
}
