using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=BookStoreVersionTwoDB;Trusted_Connection=True;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(u => u.Publisher)
                .WithMany(f => f.Books)
                .HasForeignKey(fo => fo.PublisherId);

            modelBuilder.Entity<BookAuthor>()
           .HasKey(ky => new { ky.BookId, ky.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ky => ky.Book)
                .WithMany(k => k.Authors)
                .HasForeignKey(ky => ky.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ky => ky.Author)
                .WithMany(y => y.Books)
                .HasForeignKey(ky => ky.BookId);
        }


    }
}
