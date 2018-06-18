namespace HTTPServer.GameStoreApplication.Controller
{
    using System;
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.ViewModels;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using HTTPServer.Services;
    using HTTPServer.Services.Contracts;

    public class GameController : BaseController
    {
        private IGameDataService gameData;

        public GameController(IHttpRequest req)
            : this(req, new GameDataService(new GameStoreContext()))
        {
        }

        public GameController(IHttpRequest req, IGameDataService gameData)
            : base(req)
        {
            this.gameData = gameData;
        }

        public IHttpResponse Games()
        {
            return this.FileViewResponse(@"game\admin-games");
        }

        public IHttpResponse AddGame()
        {
            return this.FileViewResponse(@"game\add-game");
        }

        public IHttpResponse AddGame(IHttpRequest req, AddGameViewModel model)
        {
            if (model != null)
            {
                var isValid = this.ValidateGameViewModel(model);
                if (!isValid)
                {
                    return this.FileViewResponse(@"game\add-game");
                }

                var gameCreated = this.gameData.Create(model);
                if (gameCreated)
                {
                    return new RedirectResponse("game/admin");
                }
            }

            return this.FileViewResponse(@"game\add-game");
        }

        private bool ValidateGameViewModel(AddGameViewModel model)
        {
            var tittle = model.Title;
            if (string.IsNullOrEmpty(tittle) ||
                !Char.IsUpper(tittle[0]) ||
                tittle.Length < 3 ||
                tittle.Length > 100)
            {
                return false;
            }

            // TODO: check for max 2 places after the point
            var price = model.Price;
            if (price <= 0)
            {
                return false;
            }

            var size = model.SizeGB;
            int indexOfPeriod = size.IndexOf('.');
            if (!decimal.TryParse(size, out decimal sizeNumber) ||
                (indexOfPeriod != -1 && size.Substring(indexOfPeriod).Length > 2))
            {
                return false;
            }

            var trailer = model.Trailer;
            if (trailer.Length != 11)
            {
                return false;
            }

            var thumbnail = model.Image.ToLower();
            if (thumbnail != null &&
                !(thumbnail.StartsWith("http://") || thumbnail.StartsWith("https://")))
            {
                return false;
            }

            var desc = model.Description;
            if (desc.Length < 20)
            {
                return false;
            }

            return true;
        }
    }
}
