namespace HTTPServer.GameStoreApplication.Controller
{
    using HTTPServer.GameStoreApplication.Extensions;
    using HTTPServer.Server.Http.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest req)
            : base(req)
        {
        }

        public IHttpResponse Index(IHttpRequest req)
        {
            if (this.User != null && this.User.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    return this.FileViewResponse(@"home/admin-home");
                }

                return this.FileViewResponse(@"home/user-home");
            }

            return this.FileViewResponse(@"home/guest-home");
        }
    }
}
