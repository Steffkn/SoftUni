namespace HTTPServer.GameStoreApplication.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.Extensions;
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.GameStoreApplication.Utilities;
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
                    return new RedirectResponse("/game/admin");
                }
            }

            return this.FileViewResponse(@"game\add-game");
        }

        public IHttpResponse GameDetails(int id)
        {
            var game = this.gameData.GetById(id);
            if (game == null)
            {
                return new RedirectResponse("/");
            }

            this.ViewData["id"] = game.Id.ToString();
            this.ViewData["ytVideo"] = game.Trailer;
            this.ViewData["imageUrl"] = game.Image;
            this.ViewData["title"] = game.Title;
            this.ViewData["price"] = game.Price.ToString("F2");
            this.ViewData["size"] = game.SizeGB;
            this.ViewData["description"] = game.Description;
            this.ViewData["releaseDate"] = string.Format("{0:dd/MM/yyyy}", game.ReleaseDate);
            this.ViewData["displayAdminBtn"] = "none";

            if (this.User != null && this.User.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    this.ViewData["displayAdminBtn"] = "inline";
                }
            }

            return this.FileViewResponse(@"shared\game-details");
        }

        public IHttpResponse AddToCart(IHttpRequest req, int id)
        {
            var shopingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shopingCart.Games.Any(g => g.Id == id))
            {
                return new RedirectResponse("/");
            }

            var game = this.gameData.GetById(id);

            if (game == null)
            {
                return new RedirectResponse("/");
            }

            var gameInfo = new GameInfo()
            {
                Id = game.Id,
                Title = game.Title,
                Trailer = game.Trailer,
                Image = game.Image,
                SizeGB = game.SizeGB,
                Price = game.Price,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate
            };
            shopingCart.Games.Add(gameInfo);

            req.Session.Add(ShoppingCart.SessionKey, shopingCart);

            return new RedirectResponse("/game/cart");
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shopingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            this.ViewData["totalPrice"] = "0.00";
            this.ViewData["cartContent"] = "<h1>You have not items in the cart yet!</h1>";
            if (shopingCart != null && shopingCart.Games.Count > 0)
            {
                this.ViewData["cartContent"] = Templates.GenerateGamesInCarts(@"shared/gameCart", shopingCart.Games);
                this.ViewData["totalPrice"] = shopingCart.Games.Sum(g => g.Price).ToString("F2");
            }

            return this.FileViewResponse(@"game\cart");
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
