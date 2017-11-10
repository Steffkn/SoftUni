namespace _02.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command.Equals("end"))
                {
                    break;
                }
                else if (command.Equals("reverse"))
                {
                    int start = int.Parse(input[2]);
                    int count = int.Parse(input[4]);

                    if (start >= 0 && start < numbers.Count && start + count >= 0 && start + count <= numbers.Count)
                    {
                        count = count % (numbers.Count * 2);
                        numbers = ReverseArray(numbers, start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command.Equals("sort"))
                {
                    int start = int.Parse(input[2]);
                    int count = int.Parse(input[4]);

                    if (start >= 0 && start < numbers.Count && start + count >= 0 && start + count <= numbers.Count)
                    {
                        count = count % (numbers.Count * 2);
                        numbers = SortArray(numbers, start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command.Equals("rollLeft"))
                {
                    int count = int.Parse(input[1]);

                    if (count >= 0)
                    {
                        count = count % (numbers.Count);
                        numbers = ShiftLeft(numbers, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (command.Equals("rollRight"))
                {
                    int count = int.Parse(input[1]);

                    if (count >= 0)
                    {
                        count = count % (numbers.Count);
                        numbers = ShiftRight(numbers, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                //else
                //{
                //    Console.WriteLine(String.Join(" ", numbers));
                //}
            }

            Console.Write('[');
            Console.Write(String.Join(", ", numbers));
            Console.WriteLine(']');
        }

        private static List<string> ShiftLeft(List<string> array, int count)
        {
            if (array.Count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var first = array.First();
                    array.RemoveAt(0);
                    array.Add(first);
                }
            }

            return array;
        }

        private static List<string> ShiftRight(List<string> array, int count)
        {
            for (int n = 0; n < count; n++)
            {
                var result = new List<string>();
                result.Add(array.Last());

                if (array.Count > 1)
                {
                    for (int i = 0; i < array.Count - 1; i++)
                    {
                        result.Add(array[i]);
                    }
                }
                array = result;
            }

            //array.Reverse();
            //if (array.Count > 0)
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        var first = array.First();
            //        array.RemoveAt(0);
            //        array.Add(first);
            //    }
            //}

            //array.Reverse();
            return array;
        }

        private static List<string> SortArray(List<string> array, int start, int count)
        {
            var result = new List<string>();

            var sorted = array.Skip(start).Take(count).ToList();
            sorted.Sort();

            for (int i = 0; i < array.Count; i++)
            {
                if (i >= start)
                {
                    break;
                }

                result.Add(array[i]);
            }

            result.AddRange(sorted);

            for (int i = start + count; i < array.Count; i++)
            {
                result.Add(array[i]);
            }

            return result;
        }

        private static List<string> ReverseArray(List<string> array, int start, int count)
        {
            var result = new List<string>();
            var reversed = array.Skip(start).Take(count).Reverse();
            for (int i = 0; i < array.Count; i++)
            {
                if (i >= start)
                {
                    break;
                }

                result.Add(array[i]);
            }

            result.AddRange(reversed);

            for (int i = start + count; i < array.Count; i++)
            {
                result.Add(array[i]);
            }

            return result;
        }
    }
}
