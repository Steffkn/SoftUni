namespace SOLID.Factories
{
    using System;
    using SOLID.Interfaces;
    using SOLID.Models.Appenders;
    using SOLID.Models.FileTypes;
    using SOLID.Models.Reports;

    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";
        private readonly LayoutFactory layoutFactory;
        private int currentFileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string[] inputArgs)
        {
            var appenderName = inputArgs[0];
            var layoutType = inputArgs[1];
            var layout = this.layoutFactory.CreateLayout(layoutType);

            ReportLevel reportLevel = ReportLevel.INFO;
            if (inputArgs.Length > 2)
            {
                Enum.TryParse(inputArgs[2], out reportLevel);
            }

            switch (appenderName)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    ILogFile file = new LogFile(string.Format(DefaultFileName, this.currentFileNumber++));
                    return new FileAppender(layout, file, reportLevel);
                default:
                    throw new ArgumentException($"Invalid appender type! - {appenderName}");
            }
        }
    }
}
