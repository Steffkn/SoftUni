namespace HTTPServer.Server.Common
{
    using System.IO;

    public static class CommonPaths
    {
        public static string DatabaseFileName = "database.csv";
        public static string ApplicationName = "ByTheCake";

        public static string MainDirectory => Directory.GetCurrentDirectory();
        public static string ResourcesDirectory => Path.Combine(MainDirectory, ApplicationName + "\\Resources\\");
        public static string DatabaseDirectory => Path.Combine(Directory.GetCurrentDirectory(), ApplicationName + "\\AppData\\");
        public static string DatabaseFile => Path.Combine(Directory.GetCurrentDirectory(), ApplicationName + "\\AppData\\" + DatabaseFileName);
    }
}
