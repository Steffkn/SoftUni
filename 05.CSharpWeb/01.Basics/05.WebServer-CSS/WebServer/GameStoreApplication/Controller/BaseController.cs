namespace HTTPServer.GameStoreApplication.Controller
{
    using HTTPServer.GameStoreApplication.Extensions;
    using HTTPServer.Server.Http.Contracts;

    public class BaseController : Server.Infrastructure.Controller
    {
        protected BaseController(IHttpRequest req) : base(req)
        {
            if (this.User != null && this.User.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    this.PartialViews["navigation"] = @"shared/adminNav";
                }
                else
                {
                    this.PartialViews["navigation"] = @"shared/userNav";
                }
            }
            else
            {
                this.PartialViews["navigation"] = @"shared/guestNav";
            }
        }
    }
}
