using HTTPServer.ByTheCake.Controllers;
using HTTPServer.Server.Routing.Contracts;

namespace HTTPServer.ByTheCake
{
    public class ByTheCakeApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            //appRouteConfig.Get(
            //    "/register",
            //        request => new UsersController()
            //        .RegisterGet()));

            //appRouteConfig.Post("/register",
            //        request => new UsersController()
            //        .RegisterPost(request.FormData["name"])));

            appRouteConfig.Get("/login",
                    request => new UsersController()
                    .Login());

            appRouteConfig.Post("/login",
                    request => new UsersController()
                    .Login(request.FormData["username"], request.FormData["password"]));

            appRouteConfig.Post("/add",
                    request => new CakeController()
                    .AddPost(request.FormData["cakeName"], decimal.Parse(request.FormData["cakePrice"])));

            appRouteConfig.Get(
                "/add",
                request => new CakeController()
                    .AddGet());

            appRouteConfig.Get(
                "/search",
                    request =>
                    {
                        if (request.UrlParameters.Count > 0)
                        {
                            return new HomeController().SearchGet(request.UrlParameters["cakeName"]);
                        }
                        else
                        {
                            return new HomeController().SearchGet("");
                        }
                    });

            appRouteConfig.Get("/about",
                    request => new HomeController()
                    .About());

            appRouteConfig.Get(
                "/",
                request => new HomeController().Index());
        }
    }
}
