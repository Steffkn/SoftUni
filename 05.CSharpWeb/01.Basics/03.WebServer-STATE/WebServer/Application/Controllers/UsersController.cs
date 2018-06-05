namespace HttpWebServer.Application.Controllers
{
    using System;
    using HttpWebServer.Application.Views;
    using HttpWebServer.Application.Views.Users;
    using HttpWebServer.Enums;
    using HttpWebServer.Server;
    using HttpWebServer.Server.HTTP;
    using HttpWebServer.Server.HTTP.Contracts;
    using HttpWebServer.Server.HTTP.Response;

    public class UsersController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }

        public IHttpResponse Login(string username, string password)
        {
            return new RedirectResponse("/");
        }

        public IHttpResponse Login()
        {
            return new ViewResponse(HttpStatusCode.OK, new LoginView());
        }

        private void LoginUser(IHttpRequest req, string username)
        {
            req.Session.Add(SessionStore.CurrentUserKey, username);
            // req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }
    }
}
