namespace HTTPServer.ByTheCake.Controllers
{
    using HTTPServer.ByTheCake.Views;
    using HTTPServer.ByTheCake.Views.Users;
    using HTTPServer.Server.Enums;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;

    public class UsersController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.Ok, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Login(string username, string password)
        {
            return new RedirectResponse("/");
        }

        public IHttpResponse Login()
        {
            return new ViewResponse(HttpStatusCode.Ok, new LoginView());
        }

        private void LoginUser(IHttpRequest req, string username)
        {
            req.Session.Add(SessionStore.SessionCookieKey, username);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }
    }
}
