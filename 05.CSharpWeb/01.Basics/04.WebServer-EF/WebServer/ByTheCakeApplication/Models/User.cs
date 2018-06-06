namespace HTTPServer.ByTheCakeApplication.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
