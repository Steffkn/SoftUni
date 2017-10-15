namespace _06.SumReversedNumbers
{
    using System;
    using System.Linq;

    public class SumReversedNumbers
    {
        static void Main()
        {
            var numbers = String.Join("", Console.ReadLine().Reverse());

            var result = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Sum();

            Console.WriteLine(result);
        }
    }
}
