namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Linq;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }
            else
            {
                prisoner.ReleaseDate = DateTime.Now;
                context.SaveChanges();

                return $"Prisoner {prisoner.FullName} released";
            }
        }
    }
}
