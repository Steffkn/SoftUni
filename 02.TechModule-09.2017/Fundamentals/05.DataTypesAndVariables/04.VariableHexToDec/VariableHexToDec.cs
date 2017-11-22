namespace _04.VariableHexToDec
{
    using System;

    public class VariableHexToDec
    {
        static void Main()
        {   
            string hexValue = Console.ReadLine();

            Console.WriteLine(Convert.ToInt32(hexValue, 16));
        }
    }
}
