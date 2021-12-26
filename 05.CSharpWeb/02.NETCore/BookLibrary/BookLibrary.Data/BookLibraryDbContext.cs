using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookBorrowHistory> BookBorrowsHistory { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BookLibrary;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Borrowers)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(borrower => borrower.BorrowedBooks)
                .WithOne(b => b.Borrower)
                .HasForeignKey(b => b.BorrowerId);


            modelBuilder.Entity<BorrowersMovies>()
                .HasKey(bb => new { bb.MovieId, bb.BorrowerId });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Borrowers)
                .WithOne(b => b.Movie)
                .HasForeignKey(b => b.MovieId);

            modelBuilder.Entity<Borrower>()
                .HasMany(borrower => borrower.BorrowedMovies)
                .WithOne(m => m.Borrower)
                .HasForeignKey(m => m.BorrowerId);


            modelBuilder.Entity<BorrowersBooks>()
                .HasKey(bb => new { bb.BookId, bb.BorrowerId });
            modelBuilder.Entity<BorrowersMovies>()
                .HasKey(bb => new { bb.MovieId, bb.BorrowerId });

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Username);

            base.OnModelCreating(modelBuilder);
        }
    }
}
