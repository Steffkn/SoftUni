namespace _06.Numbers
{
    using System;

    public class Numbers
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int firstNumber = (int)(N / 100) % 10;
            int secondNumber = (int)(N / 10) % 10;
            int thirdNumber = N % 10;

            int rowLenght = firstNumber + secondNumber;
            int colLenght = firstNumber + thirdNumber;

            for (int row = 0; row < rowLenght; row++)
            {
                for (int col = 0; col < colLenght; col++)
                {
                    if (N % 5 == 0)
                    {
                        N = N - firstNumber;
                    }
                    else if (N % 3 == 0)
                    {
                        N = N - secondNumber;
                    }
                    else
                    {
                        N = N + thirdNumber;
                    }
                    Console.Write(N + " ");
                }
                Console.WriteLine();
            }
        }
    }
}