namespace _07.BombNumbers
{
    using System;
    using System.Linq;

    public class BombNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var number = input[0];
            var power = input[1];

            int index = numbers.IndexOf(number);

            while (index >= 0)
            {
                int count = power + power + 1;
                int pos = index - power;

                if (pos < 0)
                {
                    count += pos;
                    pos = 0;
                }

                for (int i = 0; i < count; i++)
                {
                    if (numbers.Count > pos && pos >= 0)
                    {
                        numbers.RemoveAt(pos);
                    }
                }

                index = numbers.IndexOf(number);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}