using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;

namespace OrbitLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
