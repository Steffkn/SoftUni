namespace _04.AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        static void Main()
        {
            var minerals = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("stop"))
                {
                    foreach (var mineral in minerals)
                    {
                        Console.WriteLine($"{mineral.Key} -> {mineral.Value}");
                    }
                    
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (minerals.ContainsKey(input))
                {
                    minerals[input] += quantity;
                }
                else
                {
                    minerals.Add(input, quantity);
                }
            }
        }
    }
}