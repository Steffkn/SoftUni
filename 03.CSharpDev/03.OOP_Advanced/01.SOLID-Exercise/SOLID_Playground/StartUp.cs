namespace SOLID_Playground
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SOLID.Factories;
    using SOLID.Interfaces;
    using SOLID.Models.Loggers;

    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = InitLogger();
            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static ILogger InitLogger()
        {
            var appenders = ReadAppenders();
            var logger = new Logger(appenders);
            return logger;
        }

        private static ICollection<IAppender> ReadAppenders()
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            ICollection<IAppender> appenders = new List<IAppender>();
            try
            {
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    var inputArgs = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var appender = appenderFactory.CreateAppender(inputArgs);
                    appenders.Add(appender);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return appenders;
        }
    }
}
