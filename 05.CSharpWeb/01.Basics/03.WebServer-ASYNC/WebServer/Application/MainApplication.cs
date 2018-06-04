namespace HttpWebServer.Application
{
    using Application.Controllers;
    using HttpWebServer.Server.Contracts;
    using Server.Handlers;
    using Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/register",
                new PostRequestHandler(
                    request => new UserController()
                    .RegisterPost(request.FormData["name"])));

            appRouteConfig.AddRoute("/register",
                new GetRequestHandler(
                    request => new UserController()
                    .RegisterGet()));

            appRouteConfig.AddRoute("/user/{(?<name>[a-z]+)}",
                new GetRequestHandler(
                    request => new UserController()
                    .Details(request.UrlParameters["name"])));

            appRouteConfig.AddRoute("/", new GetRequestHandler(request => new HomeController().Index()));
        }
    }
}
