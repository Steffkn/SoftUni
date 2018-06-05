namespace HttpWebServer.Server.Common
{
    using System.IO;

    public static class CommonPaths
    {
        public static string DatabaseFileName = "database.csv";

        public static string MainDirectory => Directory.GetCurrentDirectory();
        public static string ResourcesDirectory => Path.Combine(MainDirectory, "Application\\Resources\\");
        public static string DatabaseDirectory => Path.Combine(Directory.GetCurrentDirectory(), "Application\\AppData\\");
        public static string DatabaseFile => Path.Combine(Directory.GetCurrentDirectory(), "Application\\AppData\\" + DatabaseFileName);
    }
}
