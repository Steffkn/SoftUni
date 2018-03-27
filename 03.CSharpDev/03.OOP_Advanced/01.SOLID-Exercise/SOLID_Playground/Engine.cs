namespace SOLID_Playground
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using SOLID.Interfaces;
    using SOLID.Models.Reports;

    public class Engine
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";
        private readonly ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            try
            {
                var reports = this.ReadReports();
                foreach (var report in reports)
                {
                    this.logger.Log(report);
                }

                this.PrintLoggerInfo();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        private void PrintLoggerInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var loggerAppender in this.logger.Appenders)
            {
                Console.WriteLine(loggerAppender.ToString());
            }
        }

        private IReport ReadReport(string[] args)
        {
            Enum.TryParse(args[0], out ReportLevel reportLevel);
            var dateAsString = args[1];
            var message = args[2];
            var report = new Report(
                DateTime.ParseExact(dateAsString, DateFormat, CultureInfo.InvariantCulture),
                reportLevel,
                message);

            return report;
        }

        private ICollection<IReport> ReadReports()
        {
            ICollection<IReport> reports = new List<IReport>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var report = this.ReadReport(inputArgs);
                reports.Add(report);
            }

            return reports;
        }
    }
}
