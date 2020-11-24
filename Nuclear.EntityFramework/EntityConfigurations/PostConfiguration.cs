using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclear.EntityFramework.Models;

namespace Nuclear.EntityFramework.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(t => t.Body).HasMaxLength(32768);

            builder.HasOne(p => p.Owner)
                .WithMany(a => a.Posts);

            builder.HasOne(p => p.Topic)
                .WithMany(t => t.Posts);
        }
    }
}
