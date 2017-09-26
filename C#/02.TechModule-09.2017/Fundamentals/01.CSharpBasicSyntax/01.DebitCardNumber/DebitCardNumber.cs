namespace _01.DebitCardNumber
{
    using System;

    public class DebitCardNumber
    {
        static void Main()
        {
            int firstPart = int.Parse(Console.ReadLine());
            int secondPart = int.Parse(Console.ReadLine());
            int thirdPart = int.Parse(Console.ReadLine());
            int fourthPart = int.Parse(Console.ReadLine());

            Console.WriteLine($"{firstPart:D4} {secondPart:D4} {thirdPart:D4} {fourthPart:D4}");
        }
    }
}