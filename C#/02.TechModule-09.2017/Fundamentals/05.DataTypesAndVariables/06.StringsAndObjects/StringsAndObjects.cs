namespace _06.StringsAndObjects
{
    using System;

    public class StringsAndObjects
    {
        static void Main()
        {
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            object objectValue = $"{firstValue} {secondValue}";

            string result = (string)objectValue;

            Console.WriteLine(result);
        }
    }
}
