namespace HTTPServer.Services.Contracts
{
    using HTTPServer.GameStoreApplication.Models;

    public interface IUserDataService
    {
        bool ExistsByEmail(string userEmail);

        UserPrincipal Create(string email, string password, string fullName);

        UserPrincipal GetByEmail(string email);
    }
}
