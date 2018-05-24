namespace P09.DateTimeWrapper
{
    using P09.DateTimeWrapper.Interfaces;
    using System;

    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTimeWrapper(DateTime currentDateTime)
        {
            this.CurrentDateTime = currentDateTime;
        }

        public DateTime CurrentDateTime { get; }

        public DateTime Now { get { return DateTime.Now; } }

        public void AddDays(double value)
        {
            this.CurrentDateTime.AddDays(value);
        }
    }
}
