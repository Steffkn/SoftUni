namespace _02.ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulator
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                string[] args = command.Split(' ');

                if (args[0].Equals("end"))
                {
                    Console.Write("[");
                    Console.Write(String.Join(", ", array));
                    Console.WriteLine("]");
                    break;
                }
                else if (args[0].Equals("exchange"))
                {
                    int index = int.Parse(args[1]);

                    if (0 <= index && index <= array.Count())
                    {
                        List<int> resultArray = array.Skip(index + 1).ToList();
                        resultArray.AddRange(array.Take(index + 1));
                        array = resultArray;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (args[0].Equals("max"))
                {
                    int index = -1;
                    List<int> result = new List<int>();

                    if (args[1].Equals("odd"))
                    {
                        result = array.Where(x => x % 2 != 0).ToList();
                    }
                    else
                    {
                        result = array.Where(x => x % 2 == 0).ToList();
                    }

                    if (result.Count > 0)
                    {
                        index = array.LastIndexOf(result.Max());
                    }

                    if (index >= 0)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (args[0].Equals("min"))
                {
                    int index = -1;
                    List<int> result = new List<int>();

                    if (args[1].Equals("odd"))
                    {
                        result = array.Where(x => x % 2 != 0).ToList();
                    }
                    else
                    {
                        result = array.Where(x => x % 2 == 0).ToList();
                    }

                    if (result.Count > 0)
                    {
                        index = result.LastIndexOf(result.Min());
                    }

                    if (index >= 0)
                    {
                        Console.WriteLine(index);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (args[0].Equals("first"))
                {
                    int count = int.Parse(args[1]);
                    List<int> result = new List<int>();

                        if (args[2].Equals("odd"))
                        {
                            result = array.Where(x => x % 2 != 0).Take(count).ToList();
                        }
                        else
                        {
                            result = array.Where(x => x % 2 == 0).Take(count).ToList();
                        }

                    if (count >= 0 && count < result.Count())
                    {
                        Console.Write("[");
                        Console.Write(String.Join(", ", result));
                        Console.WriteLine("]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
                else if (args[0].Equals("last"))
                {
                    int count = int.Parse(args[1]);
                    List<int> result = new List<int>();

                    if (count >= 0 && count < array.Count())
                    {
                        if (args[2].Equals("odd"))
                        {
                            result = array.Where(x => x % 2 != 0).ToList();
                        }
                        else
                        {
                            result = array.Where(x => x % 2 == 0).ToList();
                        }

                        result = result.Skip(Math.Max(0, result.Count() - count)).ToList();
                        Console.Write("[");
                        Console.Write(String.Join(", ", result));
                        Console.WriteLine("]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
            }
        }
    }
}
