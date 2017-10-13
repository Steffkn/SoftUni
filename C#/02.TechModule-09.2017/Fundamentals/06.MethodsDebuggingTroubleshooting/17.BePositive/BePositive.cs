// my task was to fix the bugs so that it gives correct answer, this code is not mine

namespace _17.BePositive
{
    using System;

    public class BePositive
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string outputLine = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    int currentNum = int.Parse(input[j]);

                    if (currentNum >= 0)
                    {
                        outputLine += currentNum + " ";
                    }
                    else if (j + 1 < input.Length)
                    {
                        currentNum += int.Parse(input[j + 1]);
                        j++;
                        if (currentNum >= 0)
                        {
                            outputLine += currentNum + " ";
                        }
                    }
                }

                if (outputLine.Length > 0)
                {
                    Console.WriteLine(outputLine.Trim());
                }
                else
                {
                    Console.WriteLine("(empty)");
                }
            }
        }
    }
}