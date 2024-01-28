using Microsoft.EntityFrameworkCore;
using yummer_backend.Data.Configuration;
using yummer_backend.Models;

namespace yummer_backend.Data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
