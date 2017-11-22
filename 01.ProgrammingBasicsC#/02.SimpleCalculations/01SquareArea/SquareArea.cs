namespace _01.SquareArea
{
    using System;

    public class SquareArea
    {
        static void Main()
        {
            Console.Write("a = ");
            var a = int.Parse(Console.ReadLine());
            var area = a * a;

            Console.WriteLine(string.Format("Square = {0}", area));
        }
    }
}
