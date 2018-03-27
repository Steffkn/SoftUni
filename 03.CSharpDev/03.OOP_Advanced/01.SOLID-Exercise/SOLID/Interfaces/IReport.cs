namespace SOLID.Interfaces
{
    using System;
    using Models.Reports;

    public interface IReport
    {
        DateTime DateTime { get; }

        ReportLevel Level { get; }

        string Message { get; }
    }
}
