namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            if (context.Users.FirstOrDefault(u => u.Username == username) == null)
            {
                return $"User {username} not found";
            }
            else if (context.Users.Any(u => u.Email == newEmail))
            {
                return $"Email {newEmail} is already taken";
            }
            else
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                user.Email = newEmail;

                context.SaveChanges();

                return $"Changed {username}'s email successfully";
            }
		}
	}
}
