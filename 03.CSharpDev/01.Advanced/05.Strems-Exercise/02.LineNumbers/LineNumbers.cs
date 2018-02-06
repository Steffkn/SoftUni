using System.IO;

public class LineNumbers
{
    public static void Main()
    {
        string inputFileName = "in-text.txt";
        string outputFileName = "out-text.txt";

        using (var reader = new StreamReader(inputFileName))
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                string line = reader.ReadLine();
                int i = 1;
                while (!string.IsNullOrEmpty(line))
                {
                    writer.WriteLine(string.Format($"Line {i}: {line}"));
                    i++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
