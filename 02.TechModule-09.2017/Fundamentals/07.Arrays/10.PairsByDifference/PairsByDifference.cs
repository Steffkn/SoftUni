namespace _10.PairsByDifference
{
    using System;
    using System.Linq;

    public class PairsByDifference
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int difference = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (array[i] - array[j] == difference || array[j] - array[i] == difference)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}