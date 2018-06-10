namespace HTTPServer.GameStoreApplication.Models
{
    using HTTPServer.Server.Contracts;
    using System.Collections.Generic;

    public class UserPrincipal : IUserPrincipal
    {

        public UserPrincipal()
        {
            this.Roles = new List<Role>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public ICollection<Role> Roles { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
