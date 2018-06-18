using HTTPServer.GameStoreApplication.Data;
using HTTPServer.GameStoreApplication.Models;
using HTTPServer.GameStoreApplication.ViewModels;
using HTTPServer.Services.Contracts;
using System.Linq;

namespace HTTPServer.Services
{
    public class GameDataService : IGameDataService
    {
        private GameStoreContext context;

        public GameDataService(GameStoreContext context)
        {
            this.context = context;
        }

        public bool Create(AddGameViewModel model)
        {
            try
            {
                var newGame = new Game
                {
                    Title = model.Title,
                    Trailer = model.Trailer,
                    Image = model.Image,
                    SizeGB = model.SizeGB,
                    Price = model.Price,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate
                };

                var user = this.context.Games.Add(newGame).Entity;
                this.context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExistsByTitle(string title)
        {
            return this.context.Games.Any(game => game.Title == title);
        }

        public GameInfo GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
