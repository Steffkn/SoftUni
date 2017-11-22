namespace _02.Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (true)
            {
                var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0].Equals("merge"))
                {
                    StringBuilder sb = new StringBuilder();

                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex >= input.Length)
                    {
                        continue;
                    }

                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    else if (endIndex >= input.Length)
                    {
                        endIndex = input.Length - 1;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        sb.Append(input[i]);
                    }

                    input[startIndex] = sb.ToString();
                    input = RemoveElements(input, startIndex, endIndex);
                }
                else if (command[0].Equals("divide"))
                {
                    int index = int.Parse(command[1]);
                    int partititions = int.Parse(command[2]);
                    int i = 0;
                    var holder = new List<string>();

                    for (i = 0; i < index; i++)
                    {
                        holder.Add(input[i]);
                    }

                    List<string> strings = GetStrings(input[index], partititions);
                    holder.AddRange(strings);

                    for (i = index + 1; i < input.Length; i++)
                    {
                        holder.Add(input[i]);
                    }

                    input = holder.ToArray(); ;
                }
                else if (command[0].Equals("3:1"))
                {
                    Console.WriteLine(String.Join(" ", input));
                    break;
                }
            }
        }

        private static string[] RemoveElements(string[] input, int startIndex, int endIndex)
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= startIndex; i++)
            {
                result.Add(input[i]);
            }

            for (int i = endIndex + 1; i < input.Length; i++)
            {
                result.Add(input[i]);
            }

            return result.ToArray();
        }

        private static List<string> GetStrings(string indexStr, int partititions)
        {
            if (partititions > indexStr.Length)
            {
                partititions = indexStr.Length;
            }

            int partLenght = indexStr.Length / partititions;
            List<string> result = new List<string>();
            int currentPos = 0;

            for (int i = 0; i < partititions - 1; i++)
            {
                result.Add(indexStr.Substring(currentPos, partLenght));
                currentPos += partLenght;
            }

            result.Add(indexStr.Substring(currentPos));

            return result;
        }
    }
}
