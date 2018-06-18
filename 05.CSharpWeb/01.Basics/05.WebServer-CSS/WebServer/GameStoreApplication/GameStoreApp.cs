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
                        Email = req.FormData["email"],
                        Password = req.FormData["password"],
                        ConfirmPassword = req.FormData["confirmPassword"],
                        FullName = req.FormData["fullName"],
                    }));

            appRouteConfig.Post("/logout",
                req => new AccountController(req).Logout(req));

            appRouteConfig.Get("/login",
                req => new AccountController(req).Login());

            appRouteConfig.Post("/login",
                req => new AccountController(req).Login(req, new LoginViewModel
                {
                    Email = req.FormData["email"],
                    Password = req.FormData["password"],
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
                        Title = req.FormData["title"],
                        Description = req.FormData["description"],
                        Image = req.FormData["thumbnailUrl"],
                        Price = decimal.Parse(req.FormData["price"]),
                        SizeGB = req.FormData["size"],
                        Trailer = req.FormData["ytVideoUrl"],
                        ReleaseDate = DateTime.Parse(req.FormData["releaseDate"])
                    }));
        }

        private void ConfigureDatabase()
        {
            var context = new GameStoreContext();
            context.Database.Migrate();
        }
    }
}
