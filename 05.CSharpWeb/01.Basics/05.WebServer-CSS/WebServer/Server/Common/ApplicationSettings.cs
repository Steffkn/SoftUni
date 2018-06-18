using System.IO;

namespace HTTPServer.Server.Common
{
    public static class ApplicationSettings
    {
        public static string CurrentDirrectory = Directory.GetCurrentDirectory();
        public static string ProjectName = "GameStoreApplication";
        public static string LayoutName = "layout";
        public static string DefaultPath = CurrentDirrectory + @"..\..\..\..\{0}\Resources\{1}.html";
    }
}
