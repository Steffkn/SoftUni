namespace _13._1000DaysAfterBirth
{
    using System;
    using System.Globalization;

    public class Program
    {
        const string DATE_FORMAT = "dd-MM-yyyy";

        static void Main()
        {
            var birthDate = DateTime.ParseExact(Console.ReadLine(), DATE_FORMAT, CultureInfo.InvariantCulture);
            var after1000Days = birthDate.AddDays(999);
            Console.WriteLine(after1000Days.ToString(DATE_FORMAT));
        }
    }
}
