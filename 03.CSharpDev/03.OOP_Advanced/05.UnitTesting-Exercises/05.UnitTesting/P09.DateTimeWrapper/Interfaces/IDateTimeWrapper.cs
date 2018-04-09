namespace P09.DateTimeWrapper.Interfaces
{
    using System;

    public interface IDateTimeWrapper
    {
        DateTime CurrentDateTime { get; }

        DateTime Now { get; }

        void AddDays(double value);
    }
}
