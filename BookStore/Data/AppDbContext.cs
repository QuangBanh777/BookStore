using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasKey(am => new
            {
                am.AuthorId,
                am.BookId
            });

            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(am => am.Authors_Books).HasForeignKey(m => m.BookId);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(am => am.Authors_Books).HasForeignKey(m => m.AuthorId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Authors_Books { get; set; }
    }
}
