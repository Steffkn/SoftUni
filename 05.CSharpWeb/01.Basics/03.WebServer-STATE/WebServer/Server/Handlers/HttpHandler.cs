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
            var requestMethod = httpContext.Request.Method;
            var requestPath = httpContext.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                string routePattern = registeredRoute.Key;
                var routingContext = registeredRoute.Value;
                Regex routeRegex = new Regex(routePattern);
                Match match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in routingContext.Parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;
                    httpContext.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.RequestHandler.Handle(httpContext);
            }

            return new NotFoundResponse();
        }
    }
}
