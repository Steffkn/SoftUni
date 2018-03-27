namespace SOLID.Models.Appenders
{
    using Interfaces;
    using Reports;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        public int MessagesAppended { get; protected set; }

        public abstract void Append(IReport report);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}
