namespace HttpWebServer.Server.Handlers
{
    using System;
    using Server.HTTP.Contracts;

    public class PostRequestHandler : RequestHandler
    {
        public PostRequestHandler(Func<IHttpRequest, IHttpResponse> func)
            : base(func)
        {
        }
    }
}
