namespace SOLID.Interfaces
{
    public interface ILayout
    {
        string Format { get; }

        string FormatReport(IReport report);
    }
}
