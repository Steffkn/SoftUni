using System;
using System.Globalization;

public class DateModifier
{
    public double CaclulateDifference(string firstDate, string secondDate)
    {
        string format = "yyyy MM dd";
        var date1 = DateTime.ParseExact(firstDate, format, CultureInfo.CurrentCulture);
        var date2 = DateTime.ParseExact(secondDate, format, CultureInfo.CurrentCulture);

        return Math.Abs((date1.Date - date2.Date).Days);
    }
}
