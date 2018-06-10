using HTTPServer.Server.Http.Contracts;

namespace HTTPServer.GameStoreApplication.Controller
{
    public class HomeController : Server.Infrastructure.Controller
    {
        public IHttpResponse Index()
        {
            return this.FileViewResponse(@"home/index");
        }
    }
}
