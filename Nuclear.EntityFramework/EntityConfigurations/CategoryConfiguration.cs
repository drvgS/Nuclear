using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(64);
            builder.Property(c => c.Description).HasMaxLength(256);

            builder.HasMany(c => c.Topics)
                .WithOne(t => t.Category);

            builder.HasMany(c => c.Groups)
                .WithMany(g => g.Categories);
        }
    }
}
