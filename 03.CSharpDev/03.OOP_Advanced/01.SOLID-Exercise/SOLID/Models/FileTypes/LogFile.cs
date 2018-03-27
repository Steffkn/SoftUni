namespace SOLID.Models.FileTypes
{
    using System.IO;
    using SOLID.Interfaces;

    public class LogFile : ILogFile
    {
        private const string DefaulthPath = "logs\\";
        private const string DefaulthFileName = "log.txt";

        public LogFile(string fileName = DefaulthFileName)
        {
            this.Path = DefaulthPath + fileName.TrimStart(new char[] { '/', '\\' });
        }

        public string Path { get; }

        public long Size { get; private set; }

        public void Write(string reportLog)
        {
            if (!Directory.Exists(DefaulthPath))
            {
                Directory.CreateDirectory(DefaulthPath);
            }

            using (var writer = new StreamWriter(this.Path, true))
            {
                writer.WriteLine(reportLog);
            }

            foreach (char ch in reportLog)
            {
                if (char.IsLetter(ch))
                {
                    this.Size += (int)ch;
                }
            }
        }
    }
}
