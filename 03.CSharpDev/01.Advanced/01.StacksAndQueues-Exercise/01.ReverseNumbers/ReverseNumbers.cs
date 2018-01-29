namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var numbersStack = new Stack<int>(inputNumbers);

            Console.WriteLine(String.Join(" ", numbersStack));
        }
    }
}
