﻿namespace HttpWebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Server.Handlers;
    using Server.Routing.Contracts;

    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            foreach (HttpRequestMethod requestMethod in Enum.GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>())
            {
                this.routes.Add(requestMethod, new Dictionary<string, RequestHandler>());
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => routes;

        public void AddRoute(string route, RequestHandler httpHandler)
        {
            if (httpHandler.GetType().ToString().ToLower().Contains("get"))
            {
                this.routes[HttpRequestMethod.GET].Add(route, httpHandler);
            }
            else if (httpHandler.GetType().ToString().ToLower().Contains("post"))
            {
                this.routes[HttpRequestMethod.POST].Add(route, httpHandler);
            }
        }
    }
}
