namespace HTTPServer.GameStoreApplication.Models
{
    using HTTPServer.Server.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.UserGames = new List<UserGame>();
            this.UserRoles = new List<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FullName { get; set; }

        public ICollection<UserGame> UserGames { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
