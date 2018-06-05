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
                new GetRequestHandler(
                    request => new UsersController()
                    .RegisterGet()));

            appRouteConfig.AddRoute("/register",
                new PostRequestHandler(
                    request => new UsersController()
                    .RegisterPost(request.FormData["name"])));

            appRouteConfig.AddRoute("/login",
                new GetRequestHandler(
                    request => new UsersController()
                    .Login()));

            appRouteConfig.AddRoute("/login",
                new PostRequestHandler(
                    request => new UsersController()
                    .Login(request.FormData["username"], request.FormData["password"])));

            appRouteConfig.AddRoute("/users/{(?<name>[a-z]+)}",
                new GetRequestHandler(
                    request => new UsersController()
                    .Details(request.UrlParameters["name"])));

            appRouteConfig.AddRoute("/add",
                new PostRequestHandler(
                    request => new CakeController()
                    .AddPost(request.FormData["cakeName"], decimal.Parse(request.FormData["cakePrice"]))));

            appRouteConfig.AddRoute("/add",
                new GetRequestHandler(
                    request => new CakeController()
                    .AddGet()));

            appRouteConfig.AddRoute("/search",
                new GetRequestHandler(
                    request => new HomeController()
                    .SearchGet(request.QueryParameters)));

            appRouteConfig.AddRoute("/", new GetRequestHandler(request => new HomeController().Index()));
        }
    }
}
