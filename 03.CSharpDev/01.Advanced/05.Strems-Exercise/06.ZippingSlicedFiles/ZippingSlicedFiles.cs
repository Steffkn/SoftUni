using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

public class ZippingSlicedFiles
{
    private const int bufferSize = 4096;

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

        string extension = sourceFilesNames[0].Replace(".gz", "");
        extension = extension.Substring(extension.LastIndexOf('.'));
        string assembledFileName = string.Format("{0}/{1}{2}", destinationDirectory, "Assembled", extension);

        using (var writerStream = new FileStream(assembledFileName, FileMode.Create))
        {
            byte[] buffer = new byte[bufferSize];
            foreach (string sourcefileName in sourceFilesNames)
            {
                using (var readerStream = new GZipStream(new FileStream(sourcefileName, FileMode.Open), CompressionMode.Decompress))
                {
                    while (readerStream.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writerStream.Write(buffer, 0, bufferSize);
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

        if (destinationDirectory == string.Empty)
        {
            destinationDirectory = ".";
        }

        string extension = sourceFileName.Substring(sourceFileName.LastIndexOf('.'));

        using (var readerStream = new FileStream(sourceFileName, FileMode.Open))
        {
            long fileSize = (long)Math.Ceiling((double)readerStream.Length / count);
            for (int i = 0; i < count; i++)
            {
                long currentFileSize = 0;
                string fileName = string.Format("{0}/Part-{1}{2}.gz", destinationDirectory, i, extension);

                using (GZipStream writerStream = new GZipStream(new FileStream(fileName, FileMode.Create), CompressionLevel.Optimal))
                {
                    byte[] buffer = new byte[bufferSize];

                    while (readerStream.Read(buffer, 0, bufferSize) == bufferSize)
                    {
                        writerStream.Write(buffer, 0, bufferSize);
                        currentFileSize += bufferSize;
                        if (currentFileSize >= fileSize)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
