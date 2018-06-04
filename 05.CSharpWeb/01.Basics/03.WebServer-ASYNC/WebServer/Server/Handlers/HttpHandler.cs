namespace HttpWebServer.Server.Handlers
{
    using System.Text.RegularExpressions;
    using HttpWebServer.Server.HTTP.Response;
    using Server.Handlers.Contracts;
    using Server.HTTP.Contracts;
    using Server.Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            foreach (var kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string patter = kvp.Key;
                Regex regex = new Regex(patter);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(httpContext);
            }

            return new RedirectResponse("/");
        }
    }
}
