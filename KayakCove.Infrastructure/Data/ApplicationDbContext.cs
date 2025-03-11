using KayakCove.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
