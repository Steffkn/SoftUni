namespace SOLID.Models.Reports
{
    using System;
    using Interfaces;

    public class Report : IReport
    {
        public Report(DateTime dateTime, ReportLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ReportLevel Level { get; }

        public string Message { get; }
    }
}
