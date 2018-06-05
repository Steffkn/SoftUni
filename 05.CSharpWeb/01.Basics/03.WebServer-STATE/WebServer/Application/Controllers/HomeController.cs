namespace HttpWebServer.Application.Controllers
{
    using Server.HTTP.Contracts;
    using Server.HTTP.Response;
    using Enums;
    using Application.Views;
    using System;
    using HttpWebServer.Server.Common;
    using System.Linq;
    using HttpWebServer.Application.Models;
    using System.Collections.Generic;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }

        public IHttpResponse SearchGet(IDictionary<string, string> parameters)
        {
            Cake cake = null;

            if (parameters.Keys.Count > 0)
            {
                var allCakes = IOManager.ReadFromDatabase();
                var cakeString = allCakes
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault(x => x.StartsWith(parameters["cakeName"]));

                if (cakeString != null)
                {
                    var cakeArgs = cakeString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    cake = new Cake(cakeArgs[0], decimal.Parse(cakeArgs[1]));
                }
            }

            return new ViewResponse(HttpStatusCode.OK, new HomeSearchView(cake));
        }

        public IHttpResponse Search()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeSearchView(null));
        }
    }
}
