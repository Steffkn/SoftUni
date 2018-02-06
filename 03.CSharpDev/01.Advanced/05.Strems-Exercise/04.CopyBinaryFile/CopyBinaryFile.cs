using System.IO;

public class CopyBinaryFile
{
    public static void Main()
    {
        string inputFileName = "copyMe.png";
        string outputFileName = "copyMe-Copy.png";

        using (var sourceFileStream = new FileStream(inputFileName, FileMode.Open))
        {
            using (var destinationFileStream = new FileStream(outputFileName, FileMode.Append))
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
