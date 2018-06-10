namespace HTTPServer.GameStoreApplication
{
    using Microsoft.EntityFrameworkCore;

    using HTTPServer.GameStoreApplication.Controller;
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.Server.Contracts;
    using HTTPServer.Server.Routing.Contracts;
    using HTTPServer.GameStoreApplication.ViewModels;

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
                    req => new HomeController().Index());

            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController().Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController().Register(req, new RegisterViewModel()
                    {
                        Email = req.FormData["email"],
                        Password = req.FormData["password"],
                        ConfirmPassword = req.FormData["confirmPassword"],
                        FullName = req.FormData["fullName"],
                    }));

            appRouteConfig.Post("/logout",
                req => new AccountController().Logout(req));

            appRouteConfig.Get("/login",
                req => new AccountController().Login());

            appRouteConfig.Post("/login",
                req => new AccountController().Login(req, new LoginViewModel
                {
                    Email = req.FormData["email"],
                    Password = req.FormData["password"],
                }));
        }

        private void ConfigureDatabase()
        {
            var context = new GameStoreContext();
            context.Database.Migrate();
        }
    }
}
