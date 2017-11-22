namespace _02.ChangeList
{
    using System;
    using System.Linq;

    public class ChangeList
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Even"))
                {
                    Console.WriteLine(String.Join(" ", numbers.Where(x => x % 2 == 0)));
                    break;
                }
                else if ((input.Equals("Odd")))
                {
                    Console.WriteLine(String.Join(" ", numbers.Where(x => x % 2 != 0)));
                    break;
                }

                var command = input.Split(' ');

                switch (command[0])
                {
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    case "Delete":
                        numbers.RemoveAll(x => x == int.Parse(command[1]));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
