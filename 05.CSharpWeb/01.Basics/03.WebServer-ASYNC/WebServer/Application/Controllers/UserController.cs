namespace HttpWebServer.Application.Controllers
{
    using HttpWebServer.Application.Views;
    using HttpWebServer.Enums;
    using HttpWebServer.Server;
    using HttpWebServer.Server.HTTP.Contracts;
    using HttpWebServer.Server.HTTP.Response;

    public class UserController
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
    }
}
