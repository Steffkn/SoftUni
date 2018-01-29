namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] palindromes = new string[dimentions[0], dimentions[1]];

            for (int i = 0; i < dimentions[0]; i++)
            {
                for (int j = 0; j < dimentions[1]; j++)
                {
                    palindromes[i, j] = ("" + alphabet[i] + alphabet[i + j] + alphabet[i]);
                }
            }

            for (int i = 0; i < palindromes.GetLength(0); i++)
            {
                for (int j = 0; j < palindromes.GetLength(1) - 1; j++)
                {
                    Console.Write("{0} ", palindromes[i, j]);
                }
                Console.Write(palindromes[i, palindromes.GetLength(1) - 1]);
                Console.WriteLine();
            }
        }
    }
}
