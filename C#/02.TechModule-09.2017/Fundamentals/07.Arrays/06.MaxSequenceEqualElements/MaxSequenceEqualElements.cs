namespace _06.MaxSequenceEqualElements
{
    using System;
    using System.Linq;
    using System.Text;

    public class MaxSequenceEqualElements
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int possition = 0;
            int bestStart = 0;
            int bestLenght = 0;
            int counter = 1;

            if (array.Length > 0)
            {
                int prevNumber = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    // 2 1 1 2 3 3 2 2 2 1
                    if (prevNumber == array[i])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                        possition = i;
                    }

                    if (counter > bestLenght)
                    {
                        bestLenght = counter;
                        bestStart = possition;
                    }

                    prevNumber = array[i];
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int i = bestStart; i < bestStart + bestLenght; i++)
            {
                sb.AppendFormat($"{array[i]} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}