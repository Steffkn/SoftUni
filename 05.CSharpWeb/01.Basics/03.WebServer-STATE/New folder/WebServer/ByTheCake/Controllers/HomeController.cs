namespace HTTPServer.ByTheCake.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HTTPServer.ByTheCake.Models;
    using HTTPServer.ByTheCake.Views.Home;
    using HTTPServer.ByTheCake.Views.Users;
    using HTTPServer.Server.Common;
    using HTTPServer.Server.Enums;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.Ok, new HomeIndexView());
        }

        public IHttpResponse SearchGet(string cakeName)
        {
            Cake cake = null;

            if (!string.IsNullOrEmpty(cakeName))
            {
                var allCakes = IOManager.ReadFromDatabase();
                var cakeString = allCakes
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault(x => x.StartsWith(cakeName));

                if (cakeString != null)
                {
                    var cakeArgs = cakeString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    cake = new Cake(cakeArgs[0], decimal.Parse(cakeArgs[1]));
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new HomeSearchView(cake));
        }

        public IHttpResponse Search()
        {
            return new ViewResponse(HttpStatusCode.Ok, new HomeSearchView(null));
        }

        public IHttpResponse About()
        {
            return new ViewResponse(HttpStatusCode.Ok, new HomeAboutView());
        }
    }
}
