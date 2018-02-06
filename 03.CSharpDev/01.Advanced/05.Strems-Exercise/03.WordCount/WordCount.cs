using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

public class LineNumbers
{
    public static void Main()
    {
        string wordsFileName = "words.txt";
        string inputFileName = "in-text.txt";
        string outputFileName = "result.txt";

        var dict = new Dictionary<string, int>();

        using (var wordsReader = new StreamReader(wordsFileName))
        {
            string word = wordsReader.ReadLine();

            while (!string.IsNullOrEmpty(word))
            {
                string newWord = word?.Trim(new char[] { ' ', '-', '?', '!', '.', ',', ':', ';' }).ToLower();

                if (!dict.ContainsKey(newWord))
                {
                    dict[newWord] = 0;
                }

                word = wordsReader.ReadLine();
            }
        }

        using (var reader = new StreamReader(inputFileName))
        {
            string line = reader.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                var words = line.Split(new char[] { ' ' }).Select(x => x.Trim(new char[] { ' ', '-', '?', '!', '.', ',', ':', ';' }).ToLower());

                foreach (var word in words)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                }

                line = reader.ReadLine();
            }
        }

        using (var writer = new StreamWriter(outputFileName))
        {
            foreach (var kvp in dict)
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
