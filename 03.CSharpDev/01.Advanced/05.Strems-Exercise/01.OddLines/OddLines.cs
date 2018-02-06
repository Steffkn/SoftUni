using System;
using System.IO;

public class OddLines
{
    public static void Main()
    {
        string inputFileName = "text.txt";

        using (var reader = new StreamReader(inputFileName))
        {
            string line = reader.ReadLine();
            int i = 0;
            while (!string.IsNullOrEmpty(line))
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                i++;
                line = reader.ReadLine();
            }
        }
    }
}
