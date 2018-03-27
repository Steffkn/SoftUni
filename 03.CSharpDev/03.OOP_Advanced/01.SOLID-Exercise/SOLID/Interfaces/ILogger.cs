namespace SOLID.Interfaces
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IReport report);

        void AddApender(IAppender newAppender);
    }
}
