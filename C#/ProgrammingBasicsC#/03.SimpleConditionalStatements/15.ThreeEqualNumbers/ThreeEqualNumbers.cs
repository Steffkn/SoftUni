namespace _15.ThreeEqualNumbers
{
    using System;

    public class ThreeEqualNumbers
    {
        static void Main()
        {
            var number1 = double.Parse(Console.ReadLine());
            var number2 = double.Parse(Console.ReadLine());
            var number3 = double.Parse(Console.ReadLine());

            if (number1 == number2 && number2 == number3)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
