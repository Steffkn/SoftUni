using HTTPServer.GameStoreApplication.Models;
using HTTPServer.GameStoreApplication.ViewModels;
using System.Collections.Generic;

namespace HTTPServer.Services.Contracts
{
    public interface IGameDataService
    {
        bool ExistsByTitle(string title);

        bool Create(AddGameViewModel model);

        GameInfo GetByTitle(string title);

        IEnumerable<GameInfo> GetAll();

        GameInfo GetById(int id);
    }
}
