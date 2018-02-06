using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class DirectoryTraversal
{
    public static void Main()
    {
        string dir = Console.ReadLine().Trim();
        string outputFileName = string.Format("{0}/{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");

        var fileDictionary = GetFilesFromDirectory(dir);
        PrintReport(outputFileName, fileDictionary);
    }

    private static void PrintReport(string outputFileName, Dictionary<string, Dictionary<string, long>> fileDictionary)
    {
        using (var writer = new StreamWriter(outputFileName))
        {
            foreach (var extensionGroup in fileDictionary.OrderByDescending(x => x.Value.Count))
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var file in extensionGroup.Value.OrderBy(x => x.Key))
                {
                    writer.WriteLine(string.Format("--{0} - {1:f3}kb", file.Key, file.Value / 1000.00));
                }
            }
        }
    }

    // DFS for file traversal
    private static Dictionary<string, Dictionary<string, long>> GetFilesFromDirectory(string dir, Dictionary<string, Dictionary<string, long>> fileDictionary = null)
    {
        var files = Directory.GetFiles(dir);
        if (fileDictionary == null)
        {
            fileDictionary = new Dictionary<string, Dictionary<string, long>>();
        }

        foreach (string file in files)
        {
            var fileInfo = new FileInfo(file);

            if (!fileDictionary.ContainsKey(fileInfo.Extension))
            {
                fileDictionary[fileInfo.Extension] = new Dictionary<string, long>();
            }

            fileDictionary[fileInfo.Extension][fileInfo.Name] = fileInfo.Length;
        }

        var directories = Directory.GetDirectories(dir);

        foreach (string directory in directories)
        {
            fileDictionary = GetFilesFromDirectory(directory, fileDictionary);
        }

        return fileDictionary;
    }
}
