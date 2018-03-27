using System.Linq;

namespace P07.CustomList.Models
{
    using System;
    using P07.CustomList.Interfaces;

    public class CommandInterpreter
    {
        public void InterpredCommand(string input, ICustomList<string> list)
        {
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = data[0];

            try
            {
                switch (commandName.ToLower())
                {
                    case "add":
                        list.Add(data[1]);
                        break;
                    case "remove":
                        list.Remove(int.Parse(data[1]));
                        break;
                    case "contains":
                        bool result = list.Contains(data[1]);
                        Console.WriteLine(result);
                        break;
                    case "swap":
                        list.Swap(int.Parse(data[1]), int.Parse(data[2]));
                        break;
                    case "greater":
                        int count = list.CountGreaterThan(data[1]);
                        Console.WriteLine(count);
                        break;
                    case "max":
                        var max = list.Max();
                        Console.WriteLine(max);
                        break;
                    case "min":
                        var min = list.Min();
                        Console.WriteLine(min);
                        break;
                    case "print":
                        foreach (string s in list)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case "sort":
                        Sorter<string>.Sort(list);
                        break;
                    case "end":
                        return;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }
            catch (ArgumentOutOfRangeException aOutRange)
            {
                Console.WriteLine(aOutRange.Message);
            }
        }
    }
}
