namespace HttpWebServer.Server.Common
{
    using System;
    using System.IO;
    using System.Text;

    public static class IOManager
    {
        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void EnsureFileExists(string path, string filename)
        {
            EnsureDirectoryExists(path);

            if (!File.Exists(path + filename))
            {
                using (File.Create(path + filename)) { }
            }
        }

        public static void WriteToDatabase(string input)
        {
            EnsureFileExists(CommonPaths.DatabaseDirectory, CommonPaths.DatabaseFileName);

            using (FileStream stream = new FileStream(CommonPaths.DatabaseFile, FileMode.Append))
            {
                var result = $"{input}{Environment.NewLine}";
                stream.Write(Encoding.UTF8.GetBytes(result), 0, result.Length);
            }
        }

        public static string ReadFromDatabase()
        {
            EnsureFileExists(CommonPaths.DatabaseDirectory, CommonPaths.DatabaseFileName);

            using (FileStream stream = new FileStream(CommonPaths.DatabaseFile, FileMode.Open))
            {
                var builder = new StringBuilder();
                while (true)
                {
                    byte[] bytesRed = new byte[1024];
                    int numberOfBytes = stream.Read(bytesRed, 0, bytesRed.Length);
                    if (numberOfBytes == 0)
                    {
                        break;
                    }
                    builder.Append(Encoding.UTF8.GetString(bytesRed));

                    if (numberOfBytes < 1024)
                    {
                        break;
                    }
                }

                return builder.ToString();
            }
        }

        public static string ReadResourceFile(string fileName)
        {
            var path = CommonPaths.ResourcesDirectory + fileName;
            var result = File.ReadAllText(path);
            return result;
        }
    }
}
