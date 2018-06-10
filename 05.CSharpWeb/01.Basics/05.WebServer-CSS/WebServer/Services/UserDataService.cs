namespace HTTPServer.Services
{
    using HTTPServer.GameStoreApplication.Data;
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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

        public UserPrincipal Create(string email, string password, string fullName)
        {
            try
            {
                var newUser = new User
                {
                    Email = email,
                    PasswordHash = password,
                    FullName = fullName
                };

                var userRole = this.context.Roles.FirstOrDefault(r => r.Name == "User");

                newUser.UserRoles = new List<UserRole>()
                {
                    new UserRole
                    {
                        User = newUser,
                        Role =userRole
                    }
                };

                var user = this.context.Users.Add(newUser).Entity;
                this.context.SaveChanges();

                var principal = new UserPrincipal()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    IsAuthenticated = true,
                    Roles = new List<Role>() { userRole },
                };
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public UserPrincipal GetByEmail(string email)
        {
            try
            {
                var user = this.context.Users
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefault(u => u.Email == email);
                var roles = user.UserRoles.Select(r => r.Role);
                var principal = new UserPrincipal()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Roles = new List<Role>(roles),
                };

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
