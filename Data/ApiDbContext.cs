using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data.Configuration;
using yummer_backend.Models;

namespace yummer_backend.Data
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Item>? Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfiguration(new UserConfiguration()).
                ApplyConfiguration(new ItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
