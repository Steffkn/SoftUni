namespace SOLID.Interfaces
{
    using Models.Reports;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        void Append(IReport report);
    }
}
