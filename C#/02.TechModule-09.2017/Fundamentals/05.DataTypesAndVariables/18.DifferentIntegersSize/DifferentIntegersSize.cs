namespace _18.DifferentIntegersSize
{
    using System;

    public class DifferentIntegersSize
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();

            try
            {
                long convertedNumber = Convert.ToInt64(inputNumber);

                Console.WriteLine($"{inputNumber} can fit in:");

                try
                {
                    sbyte sbyteNumber = Convert.ToSByte(inputNumber);

                    Console.WriteLine("* sbyte");
                }
                catch (OverflowException) { }

                try
                {
                    byte sbyteNumber = Convert.ToByte(inputNumber);

                    Console.WriteLine("* byte");
                }
                catch (OverflowException) { }

                try
                {
                    short sbyteNumber = Convert.ToInt16(inputNumber);

                    Console.WriteLine("* short");
                }
                catch (OverflowException) { }

                try
                {
                    ushort sbyteNumber = Convert.ToUInt16(inputNumber);

                    Console.WriteLine("* ushort");
                }
                catch (OverflowException) { }

                try
                {
                    int sbyteNumber = Convert.ToInt32(inputNumber);

                    Console.WriteLine("* int");
                }
                catch (OverflowException) { }

                try
                {
                    uint sbyteNumber = Convert.ToUInt32(inputNumber);

                    Console.WriteLine("* uint");
                }
                catch (OverflowException) { }

                Console.WriteLine("* long");
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} can't fit in any type", inputNumber);
            }

        }
    }
}
