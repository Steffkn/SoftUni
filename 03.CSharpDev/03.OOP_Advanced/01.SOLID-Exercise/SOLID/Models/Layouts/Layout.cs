namespace SOLID.Models.Layouts
{
    using System.Globalization;
    using SOLID.Interfaces;

    public abstract class Layout : ILayout
    {
        protected const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public abstract string Format { get; }

        public virtual string FormatReport(IReport report)
        {
            string dateAsString = report.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string result = string.Format(this.Format, dateAsString, report.Level, report.Message);
            return result;
        }
    }
}
