namespace SOLID.Models.Loggers
{
    using System.Collections.Generic;
    using Interfaces;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(IAppender appender)
        {
            this.appenders = new List<IAppender>
            {
                appender
            };
        }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IReport report)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ReportLevel <= report.Level)
                {
                    appender.Append(report);
                }
            }
        }

        public void AddApender(IAppender newAppender)
        {
            this.appenders.Add(newAppender);
        }
    }
}
