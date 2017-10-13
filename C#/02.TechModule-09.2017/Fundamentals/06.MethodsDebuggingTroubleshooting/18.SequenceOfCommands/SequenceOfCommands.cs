// my task was to fix the bugs so that it gives correct answer, this code is not mine

namespace _18.SequenceOfCommands
{
    using System;
    using System.Linq;

    public class SequenceOfCommands
    {
        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            while (true)
            {
                string[] line = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (line[0].Equals("stop"))
                {
                    return;
                }

                int[] args = new int[2];

                if (line.Length == 3)
                {
                    args[0] = int.Parse(line[1]) - 1;
                    args[1] = int.Parse(line[2]);
                }

                PerformAction(array, line[0], args);

                PrintArray(array);
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {
            int index = args[0];
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[index] *= value;
                    break;
                case "add":
                    array[index] += value;
                    break;
                case "subtract":
                    array[index] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            long last = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = last;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long first = array[0];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = first;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}