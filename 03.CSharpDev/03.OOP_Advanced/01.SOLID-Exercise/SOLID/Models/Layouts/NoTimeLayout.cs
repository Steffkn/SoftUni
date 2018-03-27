namespace SOLID.Models.Layouts
{
    using SOLID.Interfaces;

    public class NoTimeLayout : Layout
    {
        public override string Format => "[{0}]: {1}";

        public override string FormatReport(IReport report)
        {
            string result = string.Format(this.Format, report.Level, report.Message);
            return result;
        }
    }
}
