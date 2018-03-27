namespace SOLID.Models.Appenders
{
    using Interfaces;
    using Reports;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile file, ReportLevel reportLevel = ReportLevel.INFO)
            : base(layout, reportLevel)
        {
            this.LogFile = file;
        }

        public ILogFile LogFile { get; set; }

        public override void Append(IReport report)
        {
            this.LogFile.Write(this.Layout.FormatReport(report));
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }
    }
}
