namespace HTTPServer.GameStoreApplication
{
    using Microsoft.EntityFrameworkCore;

    using HTTPServer.GameStoreApplication.Controller;
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.Server.Contracts;
    using HTTPServer.Server.Routing.Contracts;
    using HTTPServer.GameStoreApplication.ViewModels;
    using System;

    public class GameStoreApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            this.ConfigureRautes(appRouteConfig);
            this.ConfigureDatabase();
        }

        private void ConfigureRautes(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get(
                    "/",
                    req => new HomeController(req).Index(req));

            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController(req).Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController(req).Register(req, new RegisterViewModel()
                    {
                        Email = req.FormData["email"] ?? null,
                        Password = req.FormData["password"] ?? null,
                        ConfirmPassword = req.FormData["confirmPassword"] ?? null,
                        FullName = req.FormData["fullName"] ?? null,
                    }));

            appRouteConfig.Post("/logout",
                req => new AccountController(req).Logout(req));

            appRouteConfig.Get("/login",
                req => new AccountController(req).Login());

            appRouteConfig.Post("/login",
                req => new AccountController(req).Login(req, new LoginViewModel
                {
                    Email = req.FormData["email"] ?? null,
                    Password = req.FormData["password"] ?? null,
                }));

            appRouteConfig
                .Get(
                    "/game/admin",
                    req => new GameController(req).Games());
            appRouteConfig
                .Get(
                    "/game/game/admin",
                    req => new GameController(req).Games());

            appRouteConfig
                .Get(
                    "/game/add",
                    req => new GameController(req).AddGame());

            appRouteConfig
                .Post(
                    "/game/add",
                    req => new GameController(req).AddGame(req, new AddGameViewModel()
                    {
                        Title = req.FormData["title"] ?? null,
                        Description = req.FormData["description"] ?? null,
                        Image = req.FormData["thumbnailUrl"] ?? null,
                        Price = decimal.Parse(req.FormData["price"] ?? "-1"),
                        SizeGB = req.FormData["size"] ?? null,
                        Trailer = req.FormData["ytVideoUrl"] ?? null,
                        ReleaseDate = DateTime.Parse(req.FormData["releaseDate"] ?? null)
                    }));

            appRouteConfig
                .Get(
                    "/cart",
                    req => new GameController(req).ShowCart(req));

            appRouteConfig
                .Get(
                    "/cart/add/{(?<id>[0-9]+)}",
                    req => new GameController(req).AddToCart(req, int.Parse(req.UrlParameters["id"])));

            appRouteConfig
                .Get(
                    "/game/details/{(?<id>[0-9]+)}",
                    req => new GameController(req).GameDetails(int.Parse(req.UrlParameters["id"])));
        }

        private void ConfigureDatabase()
        {
            var context = new GameStoreContext();
            context.Database.Migrate();
        }
    }
}
