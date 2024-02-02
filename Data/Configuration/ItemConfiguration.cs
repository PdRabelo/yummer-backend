using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using yummer_backend.Models;

namespace yummer_backend.Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .HasMaxLength(100);
        }
    }
}