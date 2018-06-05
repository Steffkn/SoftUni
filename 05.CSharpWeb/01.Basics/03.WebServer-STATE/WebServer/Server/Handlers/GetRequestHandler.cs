namespace HttpWebServer.Server.Handlers
{
    using System;
    using Server.HTTP.Contracts;

    public class GetRequestHandler : RequestHandler
    {
        public GetRequestHandler(Func<IHttpRequest, IHttpResponse> func)
            : base(func)
        {
        }
    }
}
