using System.Linq;

namespace P04.Froggy
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Lake lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
