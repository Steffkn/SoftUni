namespace HTTPServer.GameStoreApplication.Controller
{
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.Extensions;
    using HTTPServer.GameStoreApplication.Utilities;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Services;
    using HTTPServer.Services.Contracts;
    using System.Linq;

    public class HomeController : BaseController
    {
        private IGameDataService gameData;

        public HomeController(IHttpRequest req)
            : this(req, new GameDataService(new GameStoreContext()))
        {
        }

        public HomeController(IHttpRequest req, IGameDataService gameData)
            : base(req)
        {
            this.gameData = gameData;
        }

        public IHttpResponse Index(IHttpRequest req)
        {
            var games = this.gameData.GetAll().ToList();
                this.ViewData["homeContent"] = Templates.GenerateGameCards(@"shared/gameCard", games);
                this.ViewData["displayAdminBtn"] = "none";
            if (this.User != null && this.User.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    this.ViewData["displayAdminBtn"] = "inline";
                }
            }

            return this.FileViewResponse(@"home/home");
        }
    }
}
