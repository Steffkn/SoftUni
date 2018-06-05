namespace HttpWebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Enums;
    using Server.Routing.Contracts;

    public class ServerRouteConfig : IServerRouteConfig
    {
        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.Routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();
            var availableMethods = Enum.GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (HttpRequestMethod requestMethod in availableMethods)
            {
                this.Routes.Add(requestMethod, new Dictionary<string, IRoutingContext>());
            }

            this.InitializeServerConfig(appRouteConfig);
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }

        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routeWithHandlers = registeredRoute.Value;

                foreach (var routeWithHandler in routeWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;

                    var args = new List<string>();
                    string parsedRegex = this.ParseRoute(route, args);
                    IRoutingContext routingContext = new RoutingContext(handler, args);
                    this.Routes[requestMethod].Add(parsedRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> args)
        {
            if (route == "/")
            {
                return "^/$";
            }
            else
            {
                string[] tokens = route.Split('/', StringSplitOptions.RemoveEmptyEntries);
                return this.ParseTokens(args, tokens);
            }
        }

        private string ParseTokens(List<string> args, string[] tokens)
        {
            var parsedRegex = new StringBuilder();
            parsedRegex.Append("^/{0,1}");

            for (int index = 0; index < tokens.Length; index++)
            {
                string end = index == tokens.Length - 1 ? "$" : "/";
                if (!tokens[index].StartsWith("{") && !tokens[index].EndsWith("}"))
                {
                    parsedRegex.Append($"{tokens[index]}{end}");
                    continue;
                }

                string pattern = "<\\w+>";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(tokens[index]);

                if (!match.Success)
                {
                    continue;
                }

                string paramName = match.Groups[0].Value.Substring(1, match.Groups[0].Length - 2);
                args.Add(paramName);
                parsedRegex.Append($"{tokens[index].Substring(1, tokens[index].Length - 2)}{end}");
            }

            return parsedRegex.ToString();
        }
    }
}
