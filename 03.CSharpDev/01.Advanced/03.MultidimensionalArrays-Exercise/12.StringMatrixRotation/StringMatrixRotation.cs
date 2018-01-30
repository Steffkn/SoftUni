namespace _12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StringMatrixRotation
    {
        static void Main()
        {
            Regex reg = new Regex("([0-9]+)");
            var degrees = int.Parse(reg.Match(Console.ReadLine()).Groups[0].ToString());

            string input = Console.ReadLine();
            var text = new List<string>();
            int maxLenght = 0;
            while (!input.Equals("END"))
            {
                if (maxLenght < input.Length)
                {
                    maxLenght = input.Length;
                }

                text.Add(input);
                input = Console.ReadLine();
            }

            char[,] matrix = new char[text.Count, maxLenght];
            for (int i = 0; i < text.Count; i++)
            {
                string s = text[i];
                for (int j = 0; j < s.Length; j++)
                {
                    matrix[i, j] = s[j];
                }
            }

            switch (degrees % 360)
            {
                case 0:
                    for (int i = 0; i < text.Count; i++)
                    {
                        string s = text[i];
                        for (int j = 0; j < s.Length; j++)
                        {
                            Console.Write(s[j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 90:
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int i = matrix.GetLength(0) - 1; i > -1; i--)
                        {
                            Console.Write(matrix[i, j] != '\0' ? matrix[i, j] : ' ');
                        }
                        Console.WriteLine();
                    }
                    break;
                case 180:
                    for (int i = text.Count - 1; i > -1; i--)
                    {
                        string s = text[i];
                        Console.Write(new string(' ', maxLenght - s.Length));
                        for (int j = s.Length - 1; j > -1; j--)
                        {
                            Console.Write(s[j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 270:
                    for (int j = matrix.GetLength(1) - 1; j > -1; j--)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            Console.Write(matrix[i, j] != '\0' ? matrix[i, j] : ' ');
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}
