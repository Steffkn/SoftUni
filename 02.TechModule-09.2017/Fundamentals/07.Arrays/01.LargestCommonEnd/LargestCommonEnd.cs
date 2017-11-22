namespace _01.LargestCommonEnd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargestCommonEnd
    {
        static void Main()
        {
            List<string> firstLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> secondLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int leftCount = 0;
            int rightCount = 0;

            // left to right
            leftCount = GetCommonStartLenght(firstLine, secondLine);

            // right to left
            firstLine.Reverse();
            secondLine.Reverse();
            rightCount = GetCommonStartLenght(firstLine, secondLine);


            Console.WriteLine(leftCount > rightCount ? leftCount : rightCount);
        }

        private static int GetCommonStartLenght(List<string> firstLine, List<string> secondLine)
        {
            int count = 0;
            int i = 0;
            while (true)
            {
                if (firstLine.Count > i && secondLine.Count > i)
                {
                    if (firstLine[i].Equals(secondLine[i]))
                    {
                        count++;
                    }
                }
                else
                {
                    break;
                }

                i++;
            }

            return count;
        }
    }
}
