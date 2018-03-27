namespace SOLID.Models.Appenders
{
    using System;
    using Interfaces;
    using Reports;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.INFO)
            : base(layout, reportLevel)
        {
        }

        public override void Append(IReport report)
        {
            Console.WriteLine(this.Layout.FormatReport(report));
            this.MessagesAppended++;
        }
    }
}
