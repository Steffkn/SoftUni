namespace _05.CompareCharArrays
{
    using System;

    public class CompareCharArrays
    {
        static void Main()
        {
            string array1 = Console.ReadLine().Replace(" ", "");
            string array2 = Console.ReadLine().Replace(" ", "");

            if (array1.CompareTo(array2) < 0)
            {
                Console.WriteLine(array1);
                Console.WriteLine(array2);
            }
            else
            {
                Console.WriteLine(array2);
                Console.WriteLine(array1);
            }
        }
    }
}