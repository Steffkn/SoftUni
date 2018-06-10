namespace HTTPServer.Services
{
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.Services.Contracts;
    using System.Linq;

    public class UserDataService : IUserDataService
    {
        private GameStoreContext context;

        public UserDataService(GameStoreContext context)
        {
            this.context = context;
        }

        public bool ExistsByEmail(string userEmail)
        {
            return this.context.Users.Any(u => u.Email == userEmail);
        }

        public bool Create(string email, string password, string fullName)
        {
            try
            {
                var newUser = new User
                {
                    Email = email,
                    PasswordHash = password,
                    FullName = fullName
                };

                this.context.Users.Add(newUser);
                this.context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
