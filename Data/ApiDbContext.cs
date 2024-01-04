using Microsoft.EntityFrameworkCore;
using yummer_backend.Models;
using yummer_backend.Data.Configurations;

namespace yummer_backend.Data
{
    public class ApiDbContext : DbContext
    {
        private readonly ILogger<ApiDbContext> _logger;

        public DbSet<User> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options, ILogger<ApiDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
