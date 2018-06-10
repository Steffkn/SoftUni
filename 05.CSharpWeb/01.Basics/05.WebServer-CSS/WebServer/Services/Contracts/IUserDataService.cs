namespace HTTPServer.Services.Contracts
{
    public interface IUserDataService
    {
        bool ExistsByEmail(string userEmail);

        bool Create(string email, string password, string fullName);
    }
}
