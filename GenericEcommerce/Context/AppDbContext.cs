using GenericEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
