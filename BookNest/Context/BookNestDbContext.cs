using BookNest.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Context
{
    public class BookNestDbContext : DbContext
    {
        public BookNestDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
