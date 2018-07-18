using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookLibrary.Data
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookBorrowHistory> BookBorrowsHistory { get; set; }

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


            modelBuilder.Entity<BorrowersBooks>()
                .HasKey(bb => new { bb.BookId, bb.BorrowerId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
