namespace HttpWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
