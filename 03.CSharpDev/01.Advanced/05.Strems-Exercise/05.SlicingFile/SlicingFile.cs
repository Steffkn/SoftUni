using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SlicingFile
{
    public static void Main()
    {
        string sourceFileName = "../Resources/sliceMe.mp4";
        string destinationDirectory = "SliceAndDice";
        Console.Write("Enter how many parts should it be sliced: ");
        int count = int.Parse(Console.ReadLine());

        Slice(sourceFileName, destinationDirectory, count);

        var sourceFilesNames = Directory.GetFiles(destinationDirectory).ToList();

        Assemble(sourceFilesNames, destinationDirectory);
    }

    private static void Assemble(List<string> sourceFilesNames, string destinationDirectory)
    {
        if (destinationDirectory == string.Empty)
        {
            destinationDirectory = ".";
        }

        if (sourceFilesNames.Count == 0)
        {
            return;
        }

        string extension = sourceFilesNames[0].Substring(sourceFilesNames[0].IndexOf('.'));
        string fileName = string.Format("{0}/{1}{2}", destinationDirectory, "Assembled", extension);

        using (var destinationFileStream = new FileStream(fileName, FileMode.Append))
        {
            foreach (string sourcefileName in sourceFilesNames)
            {
                using (var sourceFileStream = new FileStream(sourcefileName, FileMode.Open))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        var redBytesCount = sourceFileStream.Read(buffer, 0, buffer.Length);
                        if (redBytesCount == 0)
                        {
                            break;
                        }

                        destinationFileStream.Write(buffer, 0, redBytesCount);
                    }
                }
            }
        }
    }

    private static void Slice(string sourceFileName, string destinationDirectory, int count)
    {
        if (!Directory.Exists(destinationDirectory))
        {
            Directory.CreateDirectory(destinationDirectory);
        }

        string extension = sourceFileName.Substring(sourceFileName.LastIndexOf('.'));

        using (var sourceFileStream = new FileStream(sourceFileName, FileMode.Open))
        {
            long fileSize = (long)Math.Ceiling((double)sourceFileStream.Length / count);
            for (int i = 0; i < count; i++)
            {
                long currentFileSize = 0;
                if (destinationDirectory == string.Empty)
                {
                    destinationDirectory = ".";
                }

                string fileName = string.Format("{0}/Part-{1}{2}", destinationDirectory, i, extension);

                using (var destinationFileStream = new FileStream(fileName, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (currentFileSize < fileSize)
                    {
                        var redBytesCount = sourceFileStream.Read(buffer, 0, buffer.Length);
                        if (redBytesCount == 0)
                        {
                            break;
                        }

                        destinationFileStream.Write(buffer, 0, redBytesCount);
                        currentFileSize += redBytesCount;
                    }
                }
            }
        }
    }
}
