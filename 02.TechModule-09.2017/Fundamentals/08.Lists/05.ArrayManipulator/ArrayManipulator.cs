namespace _05.ArrayManipulator
{
    using System;
    using System.Linq;
    using System.Text;

    public class ArrayManipulator
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                string[] command = input.Split(' ');
                switch (command[0])
                {
                    case "add":
                        var index = int.Parse(command[1]);
                        var value = int.Parse(command[2]);

                        numbers.Insert(index, value);
                        break;

                    case "addMany":
                        var indexMany = int.Parse(command[1]);
                        var values = command.Skip(2).Select(int.Parse).ToList();

                        numbers.InsertRange(indexMany, values);
                        break;

                    case "contains":
                        var lookingFor = int.Parse(command[1]);
                        int foundAt = numbers.IndexOf(lookingFor);
                        sb.AppendLine(foundAt.ToString());
                        break;

                    case "remove":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;

                    case "shift":
                        int positions = int.Parse(command[1]);
                        for (int i = 0; i < positions; i++)
                        {
                            int number = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(number);
                        }

                        break;

                    case "sumPairs":

                        for (int i = 0; i < numbers.Count - 1; i++)
                        {
                            int next = numbers[i + 1];
                            numbers[i] += next;
                            numbers.RemoveAt(i + 1);
                        }
                        break;

                    // print 
                    default:
                        sb.Append("[");
                        sb.Append(String.Join(", ", numbers));
                        sb.Append("]");
                        Console.WriteLine(sb.ToString());
                        return;
                }
            }
        }
    }
}