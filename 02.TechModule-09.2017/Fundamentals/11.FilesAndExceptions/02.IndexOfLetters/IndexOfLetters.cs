namespace _02.IndexOfLetters
{
    using System;
    using System.IO;

    public class IndexOfLetters
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            char[] letters = new char['z' - 'a' + 1];
            for (int i = 0, j = 'a'; i < letters.Length; i++, j++)
            {
                letters[i] = (char)j;
            }

            string[] input;

            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                input = File.ReadAllLines(inputFilePath);

                foreach (var line in input)
                {
                    string word = line;

                    for (int i = 0; i < word.Length; i++)
                    {
                        for (int j = 0; j < letters.Length; j++)
                        {
                            if (word[i] == letters[j])
                            {
                                writer.WriteLine($"{word[i]} -> {j}");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
