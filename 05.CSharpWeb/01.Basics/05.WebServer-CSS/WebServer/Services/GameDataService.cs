using HTTPServer.GameStoreApplication.Data;
using HTTPServer.GameStoreApplication.Models;
using HTTPServer.GameStoreApplication.ViewModels;
using HTTPServer.Services.Contracts;
using System.Collections.Generic;
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

        public IEnumerable<GameInfo> GetAll()
        {
            return this.context.Games.AsEnumerable<Game>().Select(model => new GameInfo()
            {
                Id = model.Id,
                Title = model.Title,
                Trailer = model.Trailer,
                Image = model.Image,
                SizeGB = model.SizeGB,
                Price = model.Price,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate
            });
        }

        public GameInfo GetById(int id)
        {
            var model = this.context.Games.Find(id);
            if (model != null)
            {
                return new GameInfo()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Trailer = model.Trailer,
                    Image = model.Image,
                    SizeGB = model.SizeGB,
                    Price = model.Price,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate
                };
            }
            else
            {
                return null;
            }
        }

        public GameInfo GetByTitle(string title)
        {
            var model = this.context.Games.FirstOrDefault(g => g.Title == title);
            if (model != null)
            {
                return new GameInfo()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Trailer = model.Trailer,
                    Image = model.Image,
                    SizeGB = model.SizeGB,
                    Price = model.Price,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate
                };
            }
            else
            {
                return null;
            }
        }
    }
}
