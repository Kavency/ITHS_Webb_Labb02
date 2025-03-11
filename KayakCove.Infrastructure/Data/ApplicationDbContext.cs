using Microsoft.EntityFrameworkCore;

namespace KayakCove.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
    }
}
