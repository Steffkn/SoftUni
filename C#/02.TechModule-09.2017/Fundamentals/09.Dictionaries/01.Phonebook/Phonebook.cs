namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine().Split(' ');

                if (input[0].Equals("A"))
                {
                    if (!phonebook.ContainsKey(input[1]))
                    {
                        phonebook.Add(input[1], input[2]);
                    }
                    else
                    {
                        phonebook[input[1]] = input[2];
                    }
                }
                else if (input[0].Equals("S"))
                {
                    if (phonebook.ContainsKey(input[1]))
                    {
                        var person = phonebook[input[1]];
                        Console.WriteLine($"{input[1]} -> {person}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}