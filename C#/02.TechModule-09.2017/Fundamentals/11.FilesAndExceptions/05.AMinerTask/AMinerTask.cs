namespace _05.AMinerTask
{
    using System.Collections.Generic;
    using System.IO;

    public class AMinerTask
    {
        public const string inputFilePath = "input.txt";
        public const string outputFilePath = "output.txt";

        static void Main()
        {
            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(new FileStream(inputFilePath, FileMode.Open)))
                {
                    var minerals = new Dictionary<string, int>();

                    while (true)
                    {
                        var input = reader.ReadLine();

                        if (input.Equals("stop"))
                        {
                            foreach (var mineral in minerals)
                            {
                                writer.WriteLine($"{mineral.Key} -> {mineral.Value}");
                            }

                            break;
                        }

                        var quantity = int.Parse(reader.ReadLine());

                        if (minerals.ContainsKey(input))
                        {
                            minerals[input] += quantity;
                        }
                        else
                        {
                            minerals.Add(input, quantity);
                        }
                    }
                }
            }
        }
    }
}