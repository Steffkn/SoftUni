namespace P02.GenericBoxOfInt
{
    using System;
    using P00.GenericBox;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new GenericBox<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(box.ToString());
            }
        }
    }
}
