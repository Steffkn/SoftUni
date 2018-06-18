using HTTPServer.GameStoreApplication.Models;
using HTTPServer.GameStoreApplication.ViewModels;

namespace HTTPServer.Services.Contracts
{
    public interface IGameDataService
    {
        bool ExistsByTitle(string title);

        bool Create(AddGameViewModel model);

        GameInfo GetByTitle(string title);
    }
}
