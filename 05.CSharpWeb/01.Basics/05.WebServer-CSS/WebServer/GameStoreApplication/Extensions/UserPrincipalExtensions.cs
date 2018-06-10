namespace HTTPServer.GameStoreApplication.Extensions
{
    using HTTPServer.GameStoreApplication.Models;
    using HTTPServer.Server.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public static class UserPrincipalExtensions
    {
        public static ICollection<Role> GetRoles(this IUserPrincipal user)
        {
            var userPrincipal = user as UserPrincipal;
            if (userPrincipal != null)
            {
                return userPrincipal.Roles;
            }

            return new List<Role>();
        }

        public static bool IsInRole(this IUserPrincipal user, string role)
        {
            var userPrincipal = user as UserPrincipal;
            if (userPrincipal != null)
            {
                return userPrincipal.Roles.Any(r => r.Name.ToLower() == role.ToLower());
            }

            return false;
        }
    }
}
